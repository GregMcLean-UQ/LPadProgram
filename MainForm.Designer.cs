namespace LLogger
   {
   partial class mainForm
      {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
         {
         if (disposing && (components != null))
            {
            components.Dispose();
            }
         base.Dispose(disposing);
         }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
         {
         this.components = new System.ComponentModel.Container();
         System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Testing");
         System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Operation", new System.Windows.Forms.TreeNode[] {
            treeNode1});
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
         this.panel1 = new System.Windows.Forms.Panel();
         this.titleLabel = new System.Windows.Forms.Label();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.treeView = new System.Windows.Forms.TreeView();
         this.tabControl = new System.Windows.Forms.TabControl();
         this.operatePage = new System.Windows.Forms.TabPage();
         this.label1 = new System.Windows.Forms.Label();
         this.panel2 = new System.Windows.Forms.Panel();
         this.paramsGroup = new System.Windows.Forms.GroupBox();
         this.label13 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.wateringOffButton = new System.Windows.Forms.RadioButton();
         this.wateringOnButton = new System.Windows.Forms.RadioButton();
         this.label12 = new System.Windows.Forms.Label();
         this.expTextBox = new System.Windows.Forms.TextBox();
         this.label11 = new System.Windows.Forms.Label();
         this.intervalTextBox = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.smsNumberText = new System.Windows.Forms.TextBox();
         this.rechargeAmtSelect = new System.Windows.Forms.DomainUpDown();
         this.label8 = new System.Windows.Forms.Label();
         this.serviceButton = new System.Windows.Forms.Button();
         this.statusLabel = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.statusBox = new System.Windows.Forms.ListBox();
         this.label9 = new System.Windows.Forms.Label();
         this.testingPage = new System.Windows.Forms.TabPage();
         this.panel3 = new System.Windows.Forms.Panel();
         this.label4 = new System.Windows.Forms.Label();
         this.envTestButton = new System.Windows.Forms.Button();
         this.testList = new System.Windows.Forms.ListBox();
         this.weighTestbutton = new System.Windows.Forms.Button();
         this.deviceTestButton = new System.Windows.Forms.Button();
         this.smsButton = new System.Windows.Forms.Button();
         this.label7 = new System.Windows.Forms.Label();
         this.displayPage = new System.Windows.Forms.TabPage();
         this.envListBox = new System.Windows.Forms.CheckedListBox();
         this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.displayPanel = new System.Windows.Forms.Panel();
         this.applyButton = new System.Windows.Forms.Button();
         this.okLabel = new System.Windows.Forms.Label();
         this.potsGridView = new System.Windows.Forms.DataGridView();
         this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Water = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.allPanel = new System.Windows.Forms.Panel();
         this.wtGroupBox = new System.Windows.Forms.GroupBox();
         this.maxWtRB = new System.Windows.Forms.RadioButton();
         this.targetWtRB = new System.Windows.Forms.RadioButton();
         this.groupBox = new System.Windows.Forms.GroupBox();
         this.allButton = new System.Windows.Forms.Button();
         this.allTablesButton = new System.Windows.Forms.RadioButton();
         this.targetTextBox = new System.Windows.Forms.TextBox();
         this.allPotsButton = new System.Windows.Forms.RadioButton();
         this.weighButton = new System.Windows.Forms.Button();
         this.targetWtGridView = new System.Windows.Forms.DataGridView();
         this.Pot = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Wt = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.MaxWt = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tableLabel = new System.Windows.Forms.Label();
         this.bgSMS = new System.ComponentModel.BackgroundWorker();
         this.fileWatcher = new System.IO.FileSystemWatcher();
         this.statusTimer = new System.Windows.Forms.Timer(this.components);
         this.tbStatus = new System.Windows.Forms.Label();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.tabControl.SuspendLayout();
         this.operatePage.SuspendLayout();
         this.panel2.SuspendLayout();
         this.paramsGroup.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.testingPage.SuspendLayout();
         this.panel3.SuspendLayout();
         this.displayPage.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
         this.displayPanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.potsGridView)).BeginInit();
         this.allPanel.SuspendLayout();
         this.wtGroupBox.SuspendLayout();
         this.groupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.targetWtGridView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).BeginInit();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
         this.panel1.Controls.Add(this.titleLabel);
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(1665, 48);
         this.panel1.TabIndex = 0;
         // 
         // titleLabel
         // 
         this.titleLabel.AutoSize = true;
         this.titleLabel.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.titleLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
         this.titleLabel.Location = new System.Drawing.Point(14, 11);
         this.titleLabel.Name = "titleLabel";
         this.titleLabel.Size = new System.Drawing.Size(157, 28);
         this.titleLabel.TabIndex = 0;
         this.titleLabel.Text = "LPad Logger";
         // 
         // splitContainer1
         // 
         this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.splitContainer1.Location = new System.Drawing.Point(0, 54);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.treeView);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.tabControl);
         this.splitContainer1.Size = new System.Drawing.Size(1651, 796);
         this.splitContainer1.SplitterDistance = 264;
         this.splitContainer1.TabIndex = 1;
         // 
         // treeView
         // 
         this.treeView.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.treeView.HideSelection = false;
         this.treeView.Location = new System.Drawing.Point(3, 3);
         this.treeView.Name = "treeView";
         treeNode1.Name = "TestingNode";
         treeNode1.Text = "Testing";
         treeNode2.Name = "Operation";
         treeNode2.Text = "Operation";
         this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
         this.treeView.Size = new System.Drawing.Size(259, 790);
         this.treeView.TabIndex = 8;
         this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
         // 
         // tabControl
         // 
         this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl.Controls.Add(this.operatePage);
         this.tabControl.Controls.Add(this.testingPage);
         this.tabControl.Controls.Add(this.displayPage);
         this.tabControl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabControl.Location = new System.Drawing.Point(3, 3);
         this.tabControl.Name = "tabControl";
         this.tabControl.SelectedIndex = 0;
         this.tabControl.Size = new System.Drawing.Size(1209, 790);
         this.tabControl.TabIndex = 6;
         // 
         // operatePage
         // 
         this.operatePage.Controls.Add(this.label1);
         this.operatePage.Controls.Add(this.panel2);
         this.operatePage.Controls.Add(this.label10);
         this.operatePage.Controls.Add(this.statusBox);
         this.operatePage.Controls.Add(this.label9);
         this.operatePage.Location = new System.Drawing.Point(4, 25);
         this.operatePage.Name = "operatePage";
         this.operatePage.Padding = new System.Windows.Forms.Padding(3);
         this.operatePage.Size = new System.Drawing.Size(1201, 761);
         this.operatePage.TabIndex = 2;
         this.operatePage.Text = "Operation";
         this.operatePage.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.ForeColor = System.Drawing.Color.Blue;
         this.label1.Location = new System.Drawing.Point(40, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(60, 22);
         this.label1.TabIndex = 44;
         this.label1.Text = "Setup";
         // 
         // panel2
         // 
         this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.panel2.Controls.Add(this.tbStatus);
         this.panel2.Controls.Add(this.paramsGroup);
         this.panel2.Controls.Add(this.serviceButton);
         this.panel2.Controls.Add(this.statusLabel);
         this.panel2.Controls.Add(this.label6);
         this.panel2.Location = new System.Drawing.Point(17, 63);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(579, 676);
         this.panel2.TabIndex = 43;
         // 
         // paramsGroup
         // 
         this.paramsGroup.Controls.Add(this.label13);
         this.paramsGroup.Controls.Add(this.groupBox1);
         this.paramsGroup.Controls.Add(this.label12);
         this.paramsGroup.Controls.Add(this.expTextBox);
         this.paramsGroup.Controls.Add(this.label11);
         this.paramsGroup.Controls.Add(this.intervalTextBox);
         this.paramsGroup.Controls.Add(this.label2);
         this.paramsGroup.Controls.Add(this.label3);
         this.paramsGroup.Controls.Add(this.smsNumberText);
         this.paramsGroup.Controls.Add(this.rechargeAmtSelect);
         this.paramsGroup.Controls.Add(this.label8);
         this.paramsGroup.Enabled = false;
         this.paramsGroup.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
         this.paramsGroup.Location = new System.Drawing.Point(17, 115);
         this.paramsGroup.Name = "paramsGroup";
         this.paramsGroup.Size = new System.Drawing.Size(555, 487);
         this.paramsGroup.TabIndex = 53;
         this.paramsGroup.TabStop = false;
         this.paramsGroup.Text = "Parameters";
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label13.Location = new System.Drawing.Point(26, 266);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(118, 18);
         this.label13.TabIndex = 49;
         this.label13.Text = "Watering Status";
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.wateringOffButton);
         this.groupBox1.Controls.Add(this.wateringOnButton);
         this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox1.Location = new System.Drawing.Point(325, 245);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(108, 67);
         this.groupBox1.TabIndex = 50;
         this.groupBox1.TabStop = false;
         // 
         // wateringOffButton
         // 
         this.wateringOffButton.AutoSize = true;
         this.wateringOffButton.Location = new System.Drawing.Point(20, 35);
         this.wateringOffButton.Name = "wateringOffButton";
         this.wateringOffButton.Size = new System.Drawing.Size(53, 24);
         this.wateringOffButton.TabIndex = 44;
         this.wateringOffButton.Text = "OFF";
         this.wateringOffButton.UseVisualStyleBackColor = true;
         // 
         // wateringOnButton
         // 
         this.wateringOnButton.AutoSize = true;
         this.wateringOnButton.Checked = true;
         this.wateringOnButton.Location = new System.Drawing.Point(20, 12);
         this.wateringOnButton.Name = "wateringOnButton";
         this.wateringOnButton.Size = new System.Drawing.Size(46, 24);
         this.wateringOnButton.TabIndex = 43;
         this.wateringOnButton.TabStop = true;
         this.wateringOnButton.Text = "ON";
         this.wateringOnButton.UseVisualStyleBackColor = true;
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label12.Location = new System.Drawing.Point(25, 227);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(76, 19);
         this.label12.TabIndex = 48;
         this.label12.Text = "Watering";
         // 
         // expTextBox
         // 
         this.expTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.expTextBox.Location = new System.Drawing.Point(325, 66);
         this.expTextBox.Name = "expTextBox";
         this.expTextBox.Size = new System.Drawing.Size(215, 26);
         this.expTextBox.TabIndex = 47;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label11.Location = new System.Drawing.Point(26, 69);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(133, 18);
         this.label11.TabIndex = 46;
         this.label11.Text = "Experiment Name";
         // 
         // intervalTextBox
         // 
         this.intervalTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.intervalTextBox.Location = new System.Drawing.Point(325, 409);
         this.intervalTextBox.Name = "intervalTextBox";
         this.intervalTextBox.Size = new System.Drawing.Size(108, 26);
         this.intervalTextBox.TabIndex = 39;
         this.intervalTextBox.Text = "30";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(26, 412);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(253, 18);
         this.label2.TabIndex = 38;
         this.label2.Text = "Minimum Rewatering Interval (mins)";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(26, 134);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(102, 18);
         this.label3.TabIndex = 37;
         this.label3.Text = "SMS Number";
         // 
         // smsNumberText
         // 
         this.smsNumberText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.smsNumberText.Location = new System.Drawing.Point(325, 131);
         this.smsNumberText.Name = "smsNumberText";
         this.smsNumberText.Size = new System.Drawing.Size(108, 26);
         this.smsNumberText.TabIndex = 32;
         this.smsNumberText.Text = "0409474430";
         // 
         // rechargeAmtSelect
         // 
         this.rechargeAmtSelect.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.rechargeAmtSelect.Items.Add("250");
         this.rechargeAmtSelect.Items.Add("500");
         this.rechargeAmtSelect.Location = new System.Drawing.Point(325, 337);
         this.rechargeAmtSelect.Name = "rechargeAmtSelect";
         this.rechargeAmtSelect.Size = new System.Drawing.Size(108, 26);
         this.rechargeAmtSelect.TabIndex = 26;
         this.rechargeAmtSelect.Text = "500";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(26, 339);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(172, 18);
         this.label8.TabIndex = 25;
         this.label8.Text = "Watering Recharge (ml)";
         // 
         // serviceButton
         // 
         this.serviceButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.serviceButton.Location = new System.Drawing.Point(444, 44);
         this.serviceButton.Name = "serviceButton";
         this.serviceButton.Size = new System.Drawing.Size(113, 30);
         this.serviceButton.TabIndex = 52;
         this.serviceButton.Text = "Start Service";
         this.serviceButton.UseVisualStyleBackColor = true;
         this.serviceButton.Click += new System.EventHandler(this.serviceButton_Click);
         // 
         // statusLabel
         // 
         this.statusLabel.AutoSize = true;
         this.statusLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.statusLabel.ForeColor = System.Drawing.Color.Red;
         this.statusLabel.Location = new System.Drawing.Point(338, 47);
         this.statusLabel.Name = "statusLabel";
         this.statusLabel.Size = new System.Drawing.Size(88, 22);
         this.statusLabel.TabIndex = 51;
         this.statusLabel.Text = "Stopped";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
         this.label6.Location = new System.Drawing.Point(25, 47);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(144, 22);
         this.label6.TabIndex = 41;
         this.label6.Text = "Service Status";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label10.ForeColor = System.Drawing.Color.Navy;
         this.label10.Location = new System.Drawing.Point(948, 30);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(46, 16);
         this.label10.TabIndex = 27;
         this.label10.Text = "Status";
         // 
         // statusBox
         // 
         this.statusBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.statusBox.FormattingEnabled = true;
         this.statusBox.ItemHeight = 16;
         this.statusBox.Location = new System.Drawing.Point(616, 63);
         this.statusBox.Name = "statusBox";
         this.statusBox.Size = new System.Drawing.Size(563, 676);
         this.statusBox.TabIndex = 26;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label9.ForeColor = System.Drawing.Color.Blue;
         this.label9.Location = new System.Drawing.Point(612, 25);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(93, 22);
         this.label9.TabIndex = 25;
         this.label9.Text = "Operation";
         // 
         // testingPage
         // 
         this.testingPage.Controls.Add(this.panel3);
         this.testingPage.Controls.Add(this.label7);
         this.testingPage.Location = new System.Drawing.Point(4, 25);
         this.testingPage.Name = "testingPage";
         this.testingPage.Padding = new System.Windows.Forms.Padding(3);
         this.testingPage.Size = new System.Drawing.Size(1201, 761);
         this.testingPage.TabIndex = 0;
         this.testingPage.Text = "Testing";
         this.testingPage.UseVisualStyleBackColor = true;
         // 
         // panel3
         // 
         this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.panel3.Controls.Add(this.label4);
         this.panel3.Controls.Add(this.envTestButton);
         this.panel3.Controls.Add(this.testList);
         this.panel3.Controls.Add(this.weighTestbutton);
         this.panel3.Controls.Add(this.deviceTestButton);
         this.panel3.Controls.Add(this.smsButton);
         this.panel3.Location = new System.Drawing.Point(36, 40);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(552, 709);
         this.panel3.TabIndex = 43;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(37, 18);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(65, 19);
         this.label4.TabIndex = 41;
         this.label4.Text = "Testing";
         // 
         // envTestButton
         // 
         this.envTestButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.envTestButton.Location = new System.Drawing.Point(41, 63);
         this.envTestButton.Name = "envTestButton";
         this.envTestButton.Size = new System.Drawing.Size(181, 33);
         this.envTestButton.TabIndex = 27;
         this.envTestButton.Text = "Environment readings";
         this.envTestButton.UseVisualStyleBackColor = true;
         this.envTestButton.Click += new System.EventHandler(this.envTestButton_Click);
         // 
         // testList
         // 
         this.testList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.testList.FormattingEnabled = true;
         this.testList.ItemHeight = 18;
         this.testList.Location = new System.Drawing.Point(41, 271);
         this.testList.Name = "testList";
         this.testList.Size = new System.Drawing.Size(472, 418);
         this.testList.TabIndex = 18;
         // 
         // weighTestbutton
         // 
         this.weighTestbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.weighTestbutton.Location = new System.Drawing.Point(41, 210);
         this.weighTestbutton.Name = "weighTestbutton";
         this.weighTestbutton.Size = new System.Drawing.Size(181, 29);
         this.weighTestbutton.TabIndex = 17;
         this.weighTestbutton.Text = "Weigh Test";
         this.weighTestbutton.UseVisualStyleBackColor = true;
         this.weighTestbutton.Click += new System.EventHandler(this.weighTestbutton_Click);
         // 
         // deviceTestButton
         // 
         this.deviceTestButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.deviceTestButton.Location = new System.Drawing.Point(41, 164);
         this.deviceTestButton.Name = "deviceTestButton";
         this.deviceTestButton.Size = new System.Drawing.Size(181, 30);
         this.deviceTestButton.TabIndex = 12;
         this.deviceTestButton.Text = "Device Test";
         this.deviceTestButton.UseVisualStyleBackColor = true;
         this.deviceTestButton.Click += new System.EventHandler(this.deviceTestButton_Click);
         // 
         // smsButton
         // 
         this.smsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.smsButton.Location = new System.Drawing.Point(41, 112);
         this.smsButton.Name = "smsButton";
         this.smsButton.Size = new System.Drawing.Size(181, 33);
         this.smsButton.TabIndex = 4;
         this.smsButton.Text = "SMS Test";
         this.smsButton.UseVisualStyleBackColor = true;
         this.smsButton.Click += new System.EventHandler(this.smsButton_Click);
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.ForeColor = System.Drawing.Color.Blue;
         this.label7.Location = new System.Drawing.Point(32, 15);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(71, 22);
         this.label7.TabIndex = 24;
         this.label7.Text = "Testing";
         // 
         // displayPage
         // 
         this.displayPage.Controls.Add(this.envListBox);
         this.displayPage.Controls.Add(this.chart);
         this.displayPage.Controls.Add(this.displayPanel);
         this.displayPage.Location = new System.Drawing.Point(4, 25);
         this.displayPage.Name = "displayPage";
         this.displayPage.Padding = new System.Windows.Forms.Padding(3);
         this.displayPage.Size = new System.Drawing.Size(1201, 761);
         this.displayPage.TabIndex = 1;
         this.displayPage.Text = "Display";
         this.displayPage.UseVisualStyleBackColor = true;
         // 
         // envListBox
         // 
         this.envListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.envListBox.CheckOnClick = true;
         this.envListBox.ColumnWidth = 100;
         this.envListBox.FormattingEnabled = true;
         this.envListBox.Items.AddRange(new object[] {
            "Humidity",
            "Temperature",
            "Radiation"});
         this.envListBox.Location = new System.Drawing.Point(599, 708);
         this.envListBox.MultiColumn = true;
         this.envListBox.Name = "envListBox";
         this.envListBox.Size = new System.Drawing.Size(303, 21);
         this.envListBox.TabIndex = 9;
         this.envListBox.Visible = false;
         this.envListBox.SelectedIndexChanged += new System.EventHandler(this.envListBox_SelectedIndexChanged);
         // 
         // chart
         // 
         this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         chartArea1.AxisX.LabelStyle.Format = "H:mm dd/MM";
         chartArea1.CursorX.IsUserEnabled = true;
         chartArea1.CursorX.IsUserSelectionEnabled = true;
         chartArea1.CursorY.IsUserEnabled = true;
         chartArea1.CursorY.IsUserSelectionEnabled = true;
         chartArea1.Name = "ChartArea1";
         this.chart.ChartAreas.Add(chartArea1);
         legend1.Name = "Legend1";
         this.chart.Legends.Add(legend1);
         this.chart.Location = new System.Drawing.Point(0, 0);
         this.chart.Name = "chart";
         series1.ChartArea = "ChartArea1";
         series1.Legend = "Legend1";
         series1.Name = "Series1";
         series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
         this.chart.Series.Add(series1);
         this.chart.Size = new System.Drawing.Size(969, 739);
         this.chart.TabIndex = 8;
         this.chart.Text = "chart1";
         // 
         // displayPanel
         // 
         this.displayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.displayPanel.BackColor = System.Drawing.Color.DarkSeaGreen;
         this.displayPanel.Controls.Add(this.applyButton);
         this.displayPanel.Controls.Add(this.okLabel);
         this.displayPanel.Controls.Add(this.potsGridView);
         this.displayPanel.Controls.Add(this.allPanel);
         this.displayPanel.Controls.Add(this.weighButton);
         this.displayPanel.Controls.Add(this.targetWtGridView);
         this.displayPanel.Controls.Add(this.tableLabel);
         this.displayPanel.Location = new System.Drawing.Point(975, 6);
         this.displayPanel.Name = "displayPanel";
         this.displayPanel.Size = new System.Drawing.Size(223, 723);
         this.displayPanel.TabIndex = 7;
         // 
         // applyButton
         // 
         this.applyButton.Enabled = false;
         this.applyButton.Location = new System.Drawing.Point(22, 507);
         this.applyButton.Name = "applyButton";
         this.applyButton.Size = new System.Drawing.Size(79, 29);
         this.applyButton.TabIndex = 12;
         this.applyButton.Text = "Apply";
         this.applyButton.UseVisualStyleBackColor = true;
         this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
         // 
         // okLabel
         // 
         this.okLabel.AutoSize = true;
         this.okLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.okLabel.ForeColor = System.Drawing.Color.Red;
         this.okLabel.Location = new System.Drawing.Point(140, 515);
         this.okLabel.Name = "okLabel";
         this.okLabel.Size = new System.Drawing.Size(37, 19);
         this.okLabel.TabIndex = 18;
         this.okLabel.Text = "OK!";
         this.okLabel.Visible = false;
         // 
         // potsGridView
         // 
         this.potsGridView.AllowUserToAddRows = false;
         this.potsGridView.AllowUserToDeleteRows = false;
         this.potsGridView.AllowUserToResizeColumns = false;
         this.potsGridView.AllowUserToResizeRows = false;
         this.potsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.potsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Water});
         this.potsGridView.Location = new System.Drawing.Point(23, 44);
         this.potsGridView.Name = "potsGridView";
         this.potsGridView.RowHeadersVisible = false;
         this.potsGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.potsGridView.Size = new System.Drawing.Size(187, 200);
         this.potsGridView.TabIndex = 17;
         this.potsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.potsGridView_CellContentClick);
         // 
         // dataGridViewTextBoxColumn1
         // 
         this.dataGridViewTextBoxColumn1.HeaderText = "Pot";
         this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
         this.dataGridViewTextBoxColumn1.ReadOnly = true;
         this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
         this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         this.dataGridViewTextBoxColumn1.Width = 40;
         // 
         // dataGridViewTextBoxColumn2
         // 
         this.dataGridViewTextBoxColumn2.HeaderText = "Weight";
         this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
         this.dataGridViewTextBoxColumn2.ReadOnly = true;
         this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         this.dataGridViewTextBoxColumn2.Width = 80;
         // 
         // Water
         // 
         this.Water.HeaderText = "Water";
         this.Water.Name = "Water";
         // 
         // allPanel
         // 
         this.allPanel.Controls.Add(this.wtGroupBox);
         this.allPanel.Controls.Add(this.groupBox);
         this.allPanel.Location = new System.Drawing.Point(14, 537);
         this.allPanel.Name = "allPanel";
         this.allPanel.Size = new System.Drawing.Size(209, 136);
         this.allPanel.TabIndex = 16;
         // 
         // wtGroupBox
         // 
         this.wtGroupBox.Controls.Add(this.maxWtRB);
         this.wtGroupBox.Controls.Add(this.targetWtRB);
         this.wtGroupBox.Location = new System.Drawing.Point(7, 3);
         this.wtGroupBox.Name = "wtGroupBox";
         this.wtGroupBox.Size = new System.Drawing.Size(200, 32);
         this.wtGroupBox.TabIndex = 17;
         this.wtGroupBox.TabStop = false;
         // 
         // maxWtRB
         // 
         this.maxWtRB.AutoSize = true;
         this.maxWtRB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.maxWtRB.Location = new System.Drawing.Point(102, 11);
         this.maxWtRB.Name = "maxWtRB";
         this.maxWtRB.Size = new System.Drawing.Size(95, 19);
         this.maxWtRB.TabIndex = 1;
         this.maxWtRB.Text = "Maximum Wt";
         this.maxWtRB.UseVisualStyleBackColor = true;
         // 
         // targetWtRB
         // 
         this.targetWtRB.AutoSize = true;
         this.targetWtRB.Checked = true;
         this.targetWtRB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.targetWtRB.Location = new System.Drawing.Point(9, 11);
         this.targetWtRB.Name = "targetWtRB";
         this.targetWtRB.Size = new System.Drawing.Size(76, 19);
         this.targetWtRB.TabIndex = 0;
         this.targetWtRB.TabStop = true;
         this.targetWtRB.Text = "Target Wt";
         this.targetWtRB.UseVisualStyleBackColor = true;
         // 
         // groupBox
         // 
         this.groupBox.Controls.Add(this.allButton);
         this.groupBox.Controls.Add(this.allTablesButton);
         this.groupBox.Controls.Add(this.targetTextBox);
         this.groupBox.Controls.Add(this.allPotsButton);
         this.groupBox.Location = new System.Drawing.Point(6, 36);
         this.groupBox.Name = "groupBox";
         this.groupBox.Size = new System.Drawing.Size(201, 92);
         this.groupBox.TabIndex = 16;
         this.groupBox.TabStop = false;
         // 
         // allButton
         // 
         this.allButton.Enabled = false;
         this.allButton.Location = new System.Drawing.Point(136, 42);
         this.allButton.Name = "allButton";
         this.allButton.Size = new System.Drawing.Size(54, 28);
         this.allButton.TabIndex = 15;
         this.allButton.Text = "ALL Pots";
         this.allButton.UseVisualStyleBackColor = true;
         this.allButton.Click += new System.EventHandler(this.allButton_Click);
         // 
         // allTablesButton
         // 
         this.allTablesButton.AutoSize = true;
         this.allTablesButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.allTablesButton.Location = new System.Drawing.Point(9, 48);
         this.allTablesButton.Name = "allTablesButton";
         this.allTablesButton.Size = new System.Drawing.Size(121, 19);
         this.allTablesButton.TabIndex = 1;
         this.allTablesButton.TabStop = true;
         this.allTablesButton.Text = "All Pots All Tables";
         this.allTablesButton.UseVisualStyleBackColor = true;
         // 
         // targetTextBox
         // 
         this.targetTextBox.Location = new System.Drawing.Point(136, 16);
         this.targetTextBox.Name = "targetTextBox";
         this.targetTextBox.Size = new System.Drawing.Size(54, 22);
         this.targetTextBox.TabIndex = 14;
         this.targetTextBox.TextChanged += new System.EventHandler(this.targetTextBox_TextChanged);
         this.targetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEdit_KeyPress);
         // 
         // allPotsButton
         // 
         this.allPotsButton.AutoSize = true;
         this.allPotsButton.Checked = true;
         this.allPotsButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.allPotsButton.Location = new System.Drawing.Point(9, 19);
         this.allPotsButton.Name = "allPotsButton";
         this.allPotsButton.Size = new System.Drawing.Size(126, 19);
         this.allPotsButton.TabIndex = 0;
         this.allPotsButton.TabStop = true;
         this.allPotsButton.Text = "All Pots This Table";
         this.allPotsButton.UseVisualStyleBackColor = true;
         // 
         // weighButton
         // 
         this.weighButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
         this.weighButton.Location = new System.Drawing.Point(23, 244);
         this.weighButton.Name = "weighButton";
         this.weighButton.Size = new System.Drawing.Size(78, 28);
         this.weighButton.TabIndex = 0;
         this.weighButton.Text = "Weigh";
         this.weighButton.UseVisualStyleBackColor = true;
         this.weighButton.Click += new System.EventHandler(this.weighButton_Click);
         // 
         // targetWtGridView
         // 
         this.targetWtGridView.AllowUserToAddRows = false;
         this.targetWtGridView.AllowUserToDeleteRows = false;
         this.targetWtGridView.AllowUserToResizeColumns = false;
         this.targetWtGridView.AllowUserToResizeRows = false;
         this.targetWtGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.targetWtGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pot,
            this.Wt,
            this.MaxWt});
         this.targetWtGridView.Location = new System.Drawing.Point(23, 278);
         this.targetWtGridView.Name = "targetWtGridView";
         this.targetWtGridView.RowHeadersVisible = false;
         this.targetWtGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.targetWtGridView.Size = new System.Drawing.Size(187, 217);
         this.targetWtGridView.TabIndex = 11;
         this.targetWtGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.targetWtGridView_CellBeginEdit);
         this.targetWtGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.targetWtGridView_EditingControlShowing);
         // 
         // Pot
         // 
         this.Pot.HeaderText = "Pot";
         this.Pot.Name = "Pot";
         this.Pot.ReadOnly = true;
         this.Pot.Resizable = System.Windows.Forms.DataGridViewTriState.False;
         this.Pot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         this.Pot.Width = 40;
         // 
         // Wt
         // 
         this.Wt.HeaderText = "Target Wt";
         this.Wt.Name = "Wt";
         this.Wt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         this.Wt.Width = 70;
         // 
         // MaxWt
         // 
         this.MaxWt.HeaderText = "Maximum Wt";
         this.MaxWt.Name = "MaxWt";
         this.MaxWt.Width = 75;
         // 
         // tableLabel
         // 
         this.tableLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tableLabel.Location = new System.Drawing.Point(22, 10);
         this.tableLabel.Name = "tableLabel";
         this.tableLabel.Size = new System.Drawing.Size(188, 22);
         this.tableLabel.TabIndex = 8;
         this.tableLabel.Text = "TABLE";
         this.tableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // bgSMS
         // 
         this.bgSMS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSMS_DoWork);
         this.bgSMS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSMS_RunWorkerCompleted);
         // 
         // fileWatcher
         // 
         this.fileWatcher.EnableRaisingEvents = true;
         this.fileWatcher.Path = "\\LPAD\\Data";
         this.fileWatcher.SynchronizingObject = this;
         this.fileWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileWatcher_Changed);
         // 
         // statusTimer
         // 
         this.statusTimer.Enabled = true;
         this.statusTimer.Interval = 5000;
         this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
         // 
         // tbStatus
         // 
         this.tbStatus.AutoSize = true;
         this.tbStatus.Location = new System.Drawing.Point(347, 97);
         this.tbStatus.Name = "tbStatus";
         this.tbStatus.Size = new System.Drawing.Size(0, 16);
         this.tbStatus.TabIndex = 54;
         // 
         // mainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.DarkSeaGreen;
         this.ClientSize = new System.Drawing.Size(1492, 862);
         this.Controls.Add(this.splitContainer1);
         this.Controls.Add(this.panel1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "mainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Configure, Test and Display LPAD results.";
         this.Load += new System.EventHandler(this.mainForm_Load);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.tabControl.ResumeLayout(false);
         this.operatePage.ResumeLayout(false);
         this.operatePage.PerformLayout();
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.paramsGroup.ResumeLayout(false);
         this.paramsGroup.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.testingPage.ResumeLayout(false);
         this.testingPage.PerformLayout();
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.displayPage.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
         this.displayPanel.ResumeLayout(false);
         this.displayPanel.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.potsGridView)).EndInit();
         this.allPanel.ResumeLayout(false);
         this.wtGroupBox.ResumeLayout(false);
         this.wtGroupBox.PerformLayout();
         this.groupBox.ResumeLayout(false);
         this.groupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.targetWtGridView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).EndInit();
         this.ResumeLayout(false);

         }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label titleLabel;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.TreeView treeView;
      private System.Windows.Forms.TabControl tabControl;
      private System.Windows.Forms.TabPage testingPage;
      private System.Windows.Forms.TabPage displayPage;
      private System.Windows.Forms.DataVisualization.Charting.Chart chart;
		private System.Windows.Forms.Panel displayPanel;
		private System.Windows.Forms.Button weighButton;
      private System.Windows.Forms.Label tableLabel;
		private System.Windows.Forms.Button smsButton;
      private System.ComponentModel.BackgroundWorker bgSMS;
      private System.Windows.Forms.Button deviceTestButton;
		private System.Windows.Forms.ListBox testList;
      private System.Windows.Forms.Button weighTestbutton;
      private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button envTestButton;
		private System.Windows.Forms.TabPage operatePage;
      private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
      private System.Windows.Forms.ListBox statusBox;
		private System.Windows.Forms.DataGridView targetWtGridView;
		private System.Windows.Forms.Button applyButton;
		private System.Windows.Forms.DataGridView potsGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Water;
      private System.Windows.Forms.Label okLabel;
		  private System.Windows.Forms.CheckedListBox envListBox;
		  private System.Windows.Forms.Panel allPanel;
		  private System.Windows.Forms.GroupBox groupBox;
		  private System.Windows.Forms.Button allButton;
		  private System.Windows.Forms.RadioButton allTablesButton;
		  private System.Windows.Forms.TextBox targetTextBox;
		  private System.Windows.Forms.RadioButton allPotsButton;
		  private System.Windows.Forms.GroupBox wtGroupBox;
		  private System.Windows.Forms.RadioButton maxWtRB;
		  private System.Windows.Forms.RadioButton targetWtRB;
		  private System.Windows.Forms.DataGridViewTextBoxColumn Pot;
		  private System.Windows.Forms.DataGridViewTextBoxColumn Wt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxWt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.IO.FileSystemWatcher fileWatcher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox expTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox smsNumberText;
        private System.Windows.Forms.DomainUpDown rechargeAmtSelect;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton wateringOffButton;
        private System.Windows.Forms.RadioButton wateringOnButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox paramsGroup;
        private System.Windows.Forms.Button serviceButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.Label tbStatus;
      }
   }

