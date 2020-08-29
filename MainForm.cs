using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Threading;
using Tables;
using System.Diagnostics;
using System.IO.Pipes;

namespace LLogger
{

    public partial class mainForm : Form
    {

        LPad lpad;
        int currTable = 0, currPot = 0;
        string xmlfileName = @"\LPAD\LPAD.xml";

        public mainForm(string arg)
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // read parameters
            readParameters();

            #region LoadTree  // set up the tree
            for (int i = 0; i < lpad.nTables; i++)
            {
                TreeNode table = treeView.Nodes.Add("Table" + (i + 1).ToString());
                for (int j = 0; j < lpad.nPots; j++)
                {
                    table.Nodes.Add("Pot " + (j + 1).ToString());
                }
            }
            treeView.Nodes.Add("Environment");

            #endregion

            for (int i = 0; i < envListBox.Items.Count; i++)
                envListBox.SetItemChecked(i, true);
        }

        private void readParameters()
        {
            // read the file and load the data structures

            if (!fileReady(xmlfileName))
            {
                MessageBox.Show("Cannot open " + xmlfileName);
                return;
            }
            lpad = new LPad(xmlfileName);


            // get the status
            if (SeviceRunning() == -1)
                lpad.active = false;
            else
                lpad.active = true;
            setStatus();

            // update edit boxes
            expTextBox.Text = lpad.expName;
            rechargeAmtSelect.Text = lpad.recharge.ToString();
            smsNumberText.Text = lpad.SMS;
            intervalTextBox.Text = lpad.wateringInterval.ToString();
            wateringOnButton.Checked = lpad.wateringON;
            wateringOffButton.Checked = !lpad.wateringON;
            // read current data
            readData();
            readLog();
            titleLabel.Text = "LPad Logger - " + lpad.expName;
        }

        private void readLog()
        {
            // read the log file and display the last 40 lines
            statusBox.Items.Clear();
            if (File.Exists(lpad.logFileName))
            {
                try
                {
                    FileStream fs = new FileStream(lpad.logFileName, FileMode.Open, FileAccess.Read, System.IO.FileShare.ReadWrite);
                    StreamReader sr = new System.IO.StreamReader(fs);
                    List<String> lines = new List<string>();
                    while (!sr.EndOfStream)
                        lines.Add(sr.ReadLine());
                    int start = Math.Max(0, lines.Count() - 40);
                    for (int j = start; j < lines.Count(); j++)
                        statusBox.Items.Add(lines[j]);
                    statusBox.Refresh();
                    fs.Close();

                }
                catch (Exception ex)
                {
                    statusBox.Items.Add("Problem reading Log File : " + ex.Message);
                }
            }
            else
                MessageBox.Show("Error opening " + lpad.logFileName);
        }

        protected static bool fileReady(string fileName)
        {
            // try a few times until the file becomes available.
            // if that does not happen, return false
            FileStream stream = null;
            FileInfo file = new FileInfo(fileName);
            int nTries = 20;
            bool ready = false;
            for (int i = 0; i < nTries && !ready; i++)
            {
                Thread.Sleep(100);
                try
                {
                    stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch (IOException)
                {
                    //the file is unavailable because it is still being written to or being processed by another thread
                    nTries++;
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                    ready = true;
                }
            }
            return ready;
        }

        private void readData()
        {
            // read the data file 
            if (File.Exists(lpad.dataFileName))
            {
                try
                {
                    FileStream fs = new FileStream(lpad.dataFileName, FileMode.Open, FileAccess.Read, System.IO.FileShare.ReadWrite);
                    StreamReader sr = new System.IO.StreamReader(fs);
                    statusBox.Items.Clear();
                    List<String> lines = new List<string>();
                    while (!sr.EndOfStream)
                        lines.Add(sr.ReadLine());

                    fs.Close();
                    LoadData(lines);
                }
                catch (Exception ex)
                {
                    statusBox.Items.Add("Problem reading Data File : " + ex.Message);
                }
            }

            else
                MessageBox.Show("Error opening " + lpad.dataFileName);

        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //select the correct sheet
            envListBox.Visible = false;

            if (e.Node.Text == "Operation")
            {
                tabControl.SelectedIndex = 0;
                tabControl.TabPages[2].Text = "Display";
            }
            else if (e.Node.Text == "Setup")
            {
                tabControl.SelectedIndex = 1;
                tabControl.TabPages[2].Text = "Display";
            }
            else
            {
                tabControl.SelectedIndex = 2;
                if (e.Node.Level == 0)      // table or environment level
                {
                    if (e.Node.Text == "Environment")
                    {
                        envListBox.Visible = true;

                        allPanel.Visible = false;
                        if (dataTables != null) DrawEnvGraph();
                        chart.Width = displayPage.Width;
                        tabControl.TabPages[2].Text = "Environment";
                    }
                    else             // table
                    {
                        allPanel.Visible = true;
                        chart.Width = displayPage.Width - displayPanel.Width;

                        currTable = e.Node.Index - 1;
                        currPot = -1;
                        clearDisplay();
                        tabControl.TabPages[2].Text = "Table " + (currTable + 1).ToString();
                        tableLabel.Text = tabControl.TabPages[2].Text;
                        if (dataTables != null) DrawGraph(currTable, -1);

                    }
                }
                else                     // pot level
                {
                    allPanel.Visible = false;
                    chart.Width = displayPage.Width - displayPanel.Width;

                    currTable = e.Node.Parent.Index - 1;
                    currPot = e.Node.Index;
                    clearDisplay();
                    tabControl.TabPages[2].Text = "Table " + (currTable + 1).ToString() + " Pot " + (currPot + 1).ToString();
                    tableLabel.Text = tabControl.TabPages[2].Text;
                    if (dataTables != null) DrawGraph(currTable, currPot);
                }
            }
        }

        private void clearDisplay()
        {
            // clear the Display page
            targetWtGridView.Rows.Clear();
            potsGridView.Rows.Clear();
            if (currPot == -1)
            {
                for (int i = 0; i < 8; i++)
                {
                    int indx = targetWtGridView.Rows.Add();
                    targetWtGridView.Rows[indx].Cells[0].Value = i + 1;
                    targetWtGridView.Rows[indx].Cells[1].Value = lpad.tables[currTable].pots[i].targetWt.ToString("F0");
                    targetWtGridView.Rows[indx].Cells[2].Value = lpad.tables[currTable].pots[i].maximumWt.ToString("F0");

                    indx = potsGridView.Rows.Add();
                    potsGridView.Rows[indx].Cells[0].Value = i + 1;

                }
            }
            else
            {
                int indx = targetWtGridView.Rows.Add();
                targetWtGridView.Rows[indx].Cells[0].Value = currPot + 1;
                targetWtGridView.Rows[indx].Cells[1].Value = lpad.tables[currTable].pots[currPot].targetWt.ToString("F0");
                targetWtGridView.Rows[indx].Cells[2].Value = lpad.tables[currTable].pots[currPot].maximumWt.ToString("F0");

                indx = potsGridView.Rows.Add();
                potsGridView.Rows[indx].Cells[0].Value = currPot + 1;
            }

            tableLabel.Text = tabControl.TabPages[1].Text;
            applyButton.Enabled = false;
            allButton.Enabled = false;
        }

        private void weighButton_Click(object sender, EventArgs e)
        {
            // get the weight for the current table/pot
            if (systemBusy())
                return;
            // weigh all items in the potsGridView
            foreach (DataGridViewRow row in potsGridView.Rows)
            {
                int pot = (int)row.Cells[0].Value - 1;
                //            row.Cells[1].Value = lpad.tables[currTable].pots[pot].stableWeight().ToString("F5");
                row.Cells[1].Value = lpad.tables[currTable].pots[pot].FilteredWeight().ToString("F5");
            }
        }

        private bool systemBusy()
        {
            // called from test pages 
            // change to checking the value of the status variable in the xml file
            if (lpad.active)	// something happening
            {
                MessageBox.Show("LPadService is ACTIVE.\nActions can only be performed when the LPadService is Stopped.");
                return true;
            }
            else
            {
                if (!lpad.cutoutSerialPort.IsOpen) lpad.cutoutSerialPort.Open();
                if (!lpad.rs485.IsOpen) lpad.rs485.Open();
            }
            return false;
        }

        private void smsButton_Click(object sender, EventArgs e)
        {
            // test button fot sms
            testList.Items.Clear();
            testList.Items.Add("Sending SMS");
            SendSMS("Test");
        }

        private void deviceTestButton_Click(object sender, EventArgs e)
        {
            // see what devices are available
            if (systemBusy()) return;

            // check each address and display
            testList.Items.Clear();
            char[] charSeparators = { ',' };
            string[] devices = lpad.CheckDevices().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string dev in devices)
                testList.Items.Add(dev);

            testList.Refresh();
        }

        private void weighTestbutton_Click(object sender, EventArgs e)
        {
            // test each pot to get the weight
            if (systemBusy()) return;
            // weight test of all available pots
            testList.Items.Clear();
            testList.Items.Add("Not implemented");
        }

        private void envTestButton_Click(object sender, EventArgs e)
        {
            // test the environment sensors
            if (systemBusy()) return;
            lpad.environment.getEnvironment();
            testList.Items.Clear();
            testList.Items.Add("Inside");
            testList.Items.Add("Humidity : " + lpad.environment.humidity().ToString("F2"));
            testList.Items.Add("Temperature : " + lpad.environment.temperature().ToString("F2"));
            testList.Items.Add("Radiation : " + lpad.environment.radiation.ToString("F2"));
            testList.Items.Add("Outside");
            testList.Items.Add("Humidity : " + lpad.environment.humidity2().ToString("F2"));
            testList.Items.Add("Temperature : " + lpad.environment.temperature2().ToString("F2"));
            testList.Items.Add("Radiation : " + lpad.environment.radiation2.ToString("F2"));
            for (int i = 0; i < lpad.environment.rtdTemperatures.Count(); i++)
                testList.Items.Add("T" + (i + 1).ToString() + " : " + lpad.environment.rtdTemperatures[i].ToString("F2"));


        }

        private void targetWtGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            applyButton.Enabled = true;
        }

        private void targetWtGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (targetWtGridView.CurrentCell.ColumnIndex == 1)
            {

                TextBox txtEdit = e.Control as TextBox;
                txtEdit.KeyPress += new KeyPressEventHandler(txtEdit_KeyPress);
            }
        }

        private void txtEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar) == -1)
                e.Handled = true;
        }

        private void targetTextBox_TextChanged(object sender, EventArgs e)
        {
            allButton.Enabled = true;
        }

        private void potsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // manually water the pots
            if (systemBusy())
                return;
            if (e.ColumnIndex != 2)
                return;

            // get the pot clicked and the state it is in now
            int row = e.RowIndex;
            int selectedPot = (int)potsGridView.Rows[row].Cells[0].Value - 1;
            DataGridViewCheckBoxCell cellClicked = (DataGridViewCheckBoxCell)potsGridView.Rows[row].Cells[2];
            bool clickState = (bool)cellClicked.EditingCellFormattedValue;

            // turn off all valves on the table
            foreach (Pot pot in lpad.tables[currTable].pots)
                pot.stopWatering();

            // if clicked, try to open the selected valve. 
            if (clickState)
                lpad.tables[currTable].pots[selectedPot].water();

            // set the value of each cell to the state of the corresponding valve
            foreach (DataGridViewRow aRow in potsGridView.Rows)
            {
                int potNo = (int)aRow.Cells[0].Value - 1;
                bool potWatering = lpad.tables[currTable].pots[potNo].isWatering();
                aRow.Cells[2].Value = potWatering;
                ((DataGridViewCheckBoxCell)aRow.Cells[2]).EditingCellFormattedValue = potWatering;
            }

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            // update the xml file with the values from the grid
            XDocument xmlDoc = XDocument.Load(xmlfileName);
            XElement tableElement = xmlDoc.Descendants("Table").Where(c => c.Attribute("TableNo").Value.Equals((currTable + 1).ToString())).FirstOrDefault();

            foreach (DataGridViewRow row in targetWtGridView.Rows)
            {
                int pot = (int)row.Cells[0].Value;
                XElement potElement = tableElement.Descendants("Pot").Where(c => c.Attribute("PotNo").Value.Equals(pot.ToString())).FirstOrDefault();
                potElement.SetElementValue("TargetWt", row.Cells[1].Value);
                lpad.tables[currTable].pots[pot - 1].targetWt = Convert.ToDouble(row.Cells[1].Value);
                potElement.SetElementValue("MaximumWt", row.Cells[2].Value);
                lpad.tables[currTable].pots[pot - 1].maximumWt = Convert.ToDouble(row.Cells[2].Value);
            }
            xmlDoc.Save(xmlfileName);
            okLabel.Visible = true; okLabel.Refresh();
            applyButton.Enabled = false;
            Thread.Sleep(2000);
            okLabel.Visible = false;
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            // changes all pots on a table or all tables with the entered value
            // changes either target weight or maximum weight
            // 
            if (targetTextBox.Text == "") return;
            string lbl = "Maximum";
            if (targetWtRB.Checked)
                lbl = "Target";
            DialogResult answer = MessageBox.Show("WARNING! This will change the " + lbl + " Weights for multiple Pots!\n Do you want to proceed? ",
                "Change Target Weights",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (answer == DialogResult.Cancel)
                return;

            int value = Convert.ToInt32(targetTextBox.Text);

            XDocument xmlDoc = XDocument.Load(xmlfileName);
            if (allPotsButton.Checked)       // change all pots on this table
            {
                XElement tableElement = xmlDoc.Descendants("Table").Where(c => c.Attribute("TableNo").Value.Equals((currTable + 1).ToString())).FirstOrDefault();
                for (int pot = 1; pot <= lpad.nPots; pot++)
                {
                    XElement potElement = tableElement.Descendants("Pot").Where(c => c.Attribute("PotNo").Value.Equals(pot.ToString())).FirstOrDefault();
                    if (targetWtRB.Checked)
                    {
                        potElement.SetElementValue("TargetWt", value);
                        lpad.tables[currTable].pots[pot - 1].targetWt = value;
                    }
                    else
                    {
                        potElement.SetElementValue("MaximumWt", value);
                        lpad.tables[currTable].pots[pot - 1].maximumWt = value;
                    }

                }
            }
            else
            {
                for (int tbl = 1; tbl <= lpad.nTables; tbl++)
                {
                    XElement tableElement = xmlDoc.Descendants("Table").Where(c => c.Attribute("TableNo").Value.Equals(tbl.ToString())).FirstOrDefault();
                    for (int pot = 1; pot <= lpad.nPots; pot++)
                    {
                        XElement potElement = tableElement.Descendants("Pot").Where(c => c.Attribute("PotNo").Value.Equals(pot.ToString())).FirstOrDefault();
                        if (targetWtRB.Checked)
                        {
                            potElement.SetElementValue("TargetWt", value);
                            lpad.tables[tbl - 1].pots[pot - 1].targetWt = value;
                        }
                        else
                        {
                            potElement.SetElementValue("MaximumWt", value);
                            lpad.tables[tbl - 1].pots[pot - 1].maximumWt = value;
                        }
                    }
                }
            }
            for (int pot = 1; pot <= 8; pot++)
            {
                targetWtGridView.Rows[pot - 1].Cells[1].Value = lpad.tables[currTable].pots[pot - 1].targetWt.ToString("F0");
                targetWtGridView.Rows[pot - 1].Cells[2].Value = lpad.tables[currTable].pots[pot - 1].maximumWt.ToString("F0");
            }

            File.Copy(xmlfileName, xmlfileName + ".bak", true);
            xmlDoc.Save(xmlfileName);
            okLabel.Visible = true; okLabel.Refresh();
            allButton.Enabled = false;
            Thread.Sleep(2000);
            okLabel.Visible = false;
        }

        private void toolStripDropDownButton_Click(object sender, EventArgs e)
        {
            // extend the window when the setup panel is hidden
            if (chart.Width < displayPage.Width - 20)
                chart.Width = displayPage.Width;
            else
                chart.Width = displayPage.Width - displayPanel.Width;
        }

        private void envListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // when a different selection for the environment is made redo the env graph
            DrawEnvGraph();
        }

        public string SanitizeFileName(string fileName)
        {
            // remove any incorrect characters so the experiment name can be used as a filename
            char[] cBad = Path.GetInvalidFileNameChars();
            foreach (char c in Path.GetInvalidFileNameChars())
                fileName = fileName.Replace(c, '_');
            return fileName;
        }

        private void exportGraph()
        {
            // select each table then export the chart to a file
            //treeView.SelectedNode 
            foreach (TreeNode node in treeView.Nodes)
            {
                string TableName = node.Text;
                if (TableName[0] == 'T')
                {
                    treeView.SelectedNode = node;
                    string fileName = @"c:\LPAD\images\" + TableName + ".png";
                    chart.SaveImage(fileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            // monitor the data directory. If the data file changes re-read the data
            //if the log file changes update the status
            try
            {
                fileWatcher.EnableRaisingEvents = false;
                if (e.Name == Path.GetFileName(lpad.dataFileName))
                    readData();
                else if (e.Name == Path.GetFileName(lpad.logFileName))
                    readLog();
            }
            finally
            {
                fileWatcher.EnableRaisingEvents = true;
            }
        }

        private void serviceButton_Click(object sender, EventArgs e)
        {

            if (lpad.active)
            {
                // send a message to the service to shutdown
                sendMessage("Shutdown");
                // wait until service has shutdown
                tbStatus.Text = "Waiting for the service to shut down";
                int procId = SeviceRunning();
                while (procId != -1)
                {
                    Thread.Sleep(1000);
                    procId = SeviceRunning();
                }
                tbStatus.Text = "";

                lpad.active = false;
                lpad.rs485.Open();
                lpad.cutoutSerialPort.Open();
                stopWateringAllPots();
                // update the file
                XDocument xmlDoc = XDocument.Load(xmlfileName);
                xmlDoc.Root.Element("Configuration").Element("Status").Value = "INACTIVE";
                xmlDoc.Save(xmlfileName);
            }

            // Startup Sequence  if the service is not running, update the xml, close the ports and start the service
            else
            {

                if (lpad.rs485.IsOpen)
                    lpad.rs485.Close();
                if (lpad.cutoutSerialPort.IsOpen)
                    lpad.cutoutSerialPort.Close();


                // replace the values in the configuration file with the values on the page
                // check to make sure there is an experiment name
                if (expTextBox.Text == "")
                {
                    // create a name
                    expTextBox.Text = DateTime.Now.ToString("MMMMyyyy");
                }
                string expName = SanitizeFileName(expTextBox.Text);
                string smsNumber = smsNumberText.Text;
                string wateringOn = (wateringOnButton.Checked ? "ON" : "OFF");
                string recharge = rechargeAmtSelect.Text;
                string minInterval = intervalTextBox.Text;


                // update the file
                XDocument xmlDoc = XDocument.Load(xmlfileName);
                xmlDoc.Root.Element("Configuration").Element("ExperimentName").Value = expName;
                xmlDoc.Root.Element("Configuration").Element("SMS").Value = smsNumber;
                xmlDoc.Root.Element("Configuration").Element("Watering").Value = wateringOn;
                xmlDoc.Root.Element("Configuration").Element("Recharge").Value = recharge;
                xmlDoc.Root.Element("Configuration").Element("WateringInterval").Value = minInterval;
                xmlDoc.Root.Element("Configuration").Element("Status").Value = "ACTIVE";

                xmlDoc.Save(xmlfileName);


                lpad.active = true;
                Process.Start(@"\LPAD\Programs\LPadService\bin\Release\LPadService.exe");

            }
            setStatus();
            // update parameters
            readParameters();
        }

        private void sendMessage(string message)
        {
            using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "LPadMessages", PipeDirection.Out, PipeOptions.Asynchronous))
            {
                tbStatus.Text = "Attempting to connect to service...";
                try
                {
                    pipeClient.Connect(2000);
                }
                catch
                {
                    MessageBox.Show("The service must be started in order to send data to it.");
                    return;
                }
                tbStatus.Text = "Connected to service.";
                using (StreamWriter sw = new StreamWriter(pipeClient))
                {
                    sw.Write("Shutdown");
                }
            }
            tbStatus.Text = "";

        }

        private void setStatus()
        {
            // if the service is running parameters are unavailable
            // 
            if (lpad.active)
            {
                serviceButton.Text = "Stop Service";
                statusLabel.Text = "ACTIVE";
                statusLabel.ForeColor = Color.Green;
                paramsGroup.Enabled = false;
            }
            else
            {
                serviceButton.Text = "Start Service";
                statusLabel.Text = "Stopped";
                statusLabel.ForeColor = Color.Red;
                paramsGroup.Enabled = true;
            }
        }

        private int SeviceRunning()
        {
            // test to see if the program is running
            Process[] processes = Process.GetProcessesByName("LPadService");
            if (processes.Count() > 0)
                return processes[0].Id;
            return -1;
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            int procId = SeviceRunning();
            // if status is out of sync fix
            if (lpad.active && procId == -1)  // NO PROCESS RUNNING
            {
                lpad.active = false;
                // update the file
                XDocument xmlDoc = XDocument.Load(xmlfileName);
                xmlDoc.Root.Element("Configuration").Element("Status").Value = "INACTIVE";
                xmlDoc.Save(xmlfileName);
            }
            setStatus();
        }

        private void stopWateringAllPots()
        {
            // stop Watering All Pots
            if (lpad.cutoutSerialPort.IsOpen)
            {
                lpad.cutoutSerialPort.Close();
            }

            if (lpad.rs485.IsOpen)
            {
                foreach (Table tbl in lpad.tables)
                    foreach (Pot pot in tbl.pots)
                        pot.stopWatering();
            }

        }

    }
}

