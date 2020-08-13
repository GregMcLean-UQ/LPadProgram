using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Net;
using System.Collections.Specialized;
using Tables;


namespace LLogger
{

    public partial class mainForm : Form
    {

        List<DataTable> dataTables;
        DataEnvironment environment;

        // Classes
        public class Weight
        {
            public DateTime time;
            public double wt;
            public Weight(DateTime _t, double _wt)
            {
                time = _t;
                wt = _wt;
            }
        }
        public class DataPot
        {
            public List<Weight> weights;
        }
        public class DataTable
        {
            public List<DataPot> pots;

        }
        public class EnvReading
        {
            public DateTime time;
            public List<double> reading;
            public EnvReading(DateTime _t, List<double> _reading)
            {
                time = _t;
                reading = _reading;
            }
        }
        public class DataEnvironment
        {
            public List<String> traits = new List<string>() { "Humidity", "Temperature", "Radiation" };
            public List<EnvReading> envs;
            public int nTraits;
            public DataEnvironment()
            {
                nTraits = traits.Count;
            }
        }

        // graphics
        public void LoadData(List<string> lines)
        {

            // 22/09/2010 1:56:07 PM,69255.3,64079,68218.3,61192.3,65349,63770.6,68001.1,66934.1,  etc
            // last 3 values are humidity, temperature and solar
            // now has temperature for each table


            char[] charSeparators = { ',' };
            string[] parseline = lines[0].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);


            dataTables = new List<DataTable>();
            environment = new DataEnvironment
            {
                envs = new List<EnvReading>()
            };

            for (int i = 0; i < lpad.nTables; i++)
            {
                DataTable t = new DataTable
                {
                    pots = new List<DataPot>()
                };
                for (int j = 0; j < lpad.nPots; j++)
                {
                    DataPot p = new DataPot
                    {
                        weights = new List<Weight>()
                    };
                    t.pots.Add(p);
                }
                dataTables.Add(t);
            }



            foreach (string line in lines.Skip(1))
            {
                // 22/09/2010 1:56:07 PM,69255.3,64079,68218.3,61192.3,65349,63770.6,68001.1,66934.1,  etc
                // last 3 values are humidity, temperature and solar
                // 4 is test weight
                parseline = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (parseline.Count() < 9)
                    continue;
                DateTime aTime = DateTime.Parse(parseline[0]);

                // 
                //int nReadings = parseline.Count();
                //for (int i = 1; i < nReadings - 3; i++)
                for (int i = 1; i < lpad.nPots * lpad.nTables + 1; i++)
                {
                    int potNo = (i - 1) % lpad.nPots;
                    int tableNo = (i - 1) / 8;
                    Weight wt = new Weight(aTime, Convert.ToDouble(parseline[i]));
                    dataTables[tableNo].pots[potNo].weights.Add(wt);
                }

                // get the environment data
                List<double> readings = new List<double>();
                //for (int i = 3; i > 0; i--)
                for (int i = lpad.nPots * lpad.nTables + 1; i < lpad.nPots * lpad.nTables + 4; i++)
                    readings.Add(Convert.ToDouble(parseline[i]));
                EnvReading env = new EnvReading(aTime, readings);
                environment.envs.Add(env);
            }

        }
        public void DrawEnvGraph()
        {
            chart.Series.Clear();
            for (int i = 0; i < environment.nTraits; i++)
            {
                if (envListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    String seriesName = environment.traits[i];
                    Series envSeries = chart.Series.Add(seriesName);
                    envSeries.ChartType = SeriesChartType.Line;
                    envSeries.ToolTip = seriesName;
                    if (seriesName == "Radiation")
                        envSeries.YAxisType = AxisType.Secondary;
                    foreach (EnvReading env in environment.envs)
                    {
                        chart.Series.Last().Points.AddXY(env.time, env.reading[i]);
                    }
                }
            }
        }
        public void DrawGraph(int tableIndx, int potIndx)
        {
            chart.Series.Clear();
            if (tableIndx >= dataTables.Count) return;
            if (potIndx == -1)   // graph the whole table
            {
                // add nPots (8) series
                for (int potNo = 0; potNo < lpad.nPots; potNo++)
                    AddSeries(tableIndx, potNo);
            }
            else
            {
                AddSeries(tableIndx, potIndx);
            }
            chart.ChartAreas[0].AxisY.IsStartedFromZero = false;
        }
        public void AddSeries(int tableIndx, int potIndx)
        {
            String seriesName = "Table " + (tableIndx + 1).ToString() + " Pot " + (potIndx + 1).ToString();
            Series newSeries = chart.Series.Add(seriesName);
            newSeries.ChartType = SeriesChartType.Line;
            newSeries.ToolTip = seriesName;
            foreach (Weight wt in dataTables[tableIndx].pots[potIndx].weights)
            {
                if (wt.wt > 2000)
                    newSeries.Points.AddXY(wt.time, wt.wt);
            }
        }





        //					  - SMS
        private void SendSMS(string msg)
        {
            //	61412140375@email.smsglobal.com Q@@fiGatt0n
            bgSMS.RunWorkerAsync(msg);
        }
        private void BgSMS_DoWork(object sender, DoWorkEventArgs e)
        {
            // send an sms
            string msg = (string)e.Argument;
            string toAddr = smsNumberText.Text + "@email.smsglobal.com";

            //// get the outbox
            //Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
            //Microsoft.Office.Interop.Outlook.NameSpace mapiNameSpace = outlookApp.GetNamespace("MAPI");
            //mapiNameSpace.Logon(null, null, true, true);
            //Microsoft.Office.Interop.Outlook.MAPIFolder outboxFolder =
            //	mapiNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderOutbox);

            //// create a mail item
            //Microsoft.Office.Interop.Outlook._MailItem mailItem =
            //	(Microsoft.Office.Interop.Outlook._MailItem)outlookApp.
            //		CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            //mailItem.To = smsNumberText.Text + "@sms.smsglobal.com.au";
            //mailItem.Subject = "LYSIMETER ALERT";
            //mailItem.Body = "LYSIMETER ALERT  " + msg + "  " + DateTime.Now.ToString();

            //// add to out box
            //mailItem.SaveSentMessageFolder = outboxFolder;

            ////send
            //mailItem.Send();

        }
        private void BgSMS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                testList.Items.Add("ERROR " + e.Error.Message);
            }
            else
                testList.Items.Add("SMS Sent successfully");
        }

        string HttpPost(string uri, string parameters, ref string reply)
        {
            // send parameters to uri
            // parameters: name1=value1&name2=value2	// configure the webrequest
            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            reply = " Data Sent OK";

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(parameters);
            Stream os = null;
            try
            { // send the Post
                webRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex)
            {
                reply = ex.Message;
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            try
            { // get the response
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                {
                    reply = "No Response from the Web Server";
                }
                else
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                    reply = sr.ReadToEnd().Trim();
                    if (reply.Contains("LPAD"))
                        reply = "Data sent OK";
                    else
                        reply = "Data Problem";
                }
            }
            catch (WebException ex)
            {
                reply = ex.Message;
            }
            return reply;
        } // end HttpPost 

        public string HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            string response = "FAIL";
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                response = reader2.ReadToEnd();
                //webBrowser1.DocumentText = response;
                if (response.Contains("OK"))
                    response = "OK";
            }
            catch (Exception)
            {
                response = "FAIL";
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
            return response;
        }


    }

}