namespace CCDLumberTypeEditor
{
    partial class frmEditLumber
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
            this.btnEditLumber = new System.Windows.Forms.Button();
            this.dgvLumberType = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTypeResetFilters = new System.Windows.Forms.Button();
            this.cboTypeTreatment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTypeUseAsStud = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTypeStocked = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTypeSpecies = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTypeLength = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTypeGrade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTypeWidth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTypeDepth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPriceHistoryLumber = new System.Windows.Forms.Button();
            this.btnTypeExportLumber = new System.Windows.Forms.Button();
            this.tabLumberTools = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpUsedLumber = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpUsedEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpUsedStart = new System.Windows.Forms.DateTimePicker();
            this.chkShowUsedLumber = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalPieces = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblBoardFeet = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBundlesTotalsQty = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnInventoryExport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInventoryClearFilter = new System.Windows.Forms.Button();
            this.cboInventoryTreatment = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboInventorySpecies = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboInventoryLength = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboInventoryGrade = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboInventoryWidth = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cboInventoryDepth = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnEditSheathing = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cboTreatmentSheathing = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboStructualSheathing = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboLengthSheathing = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cboGradeSheathing = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cboWidthSheathing = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cboThicknessSheathing = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.dgvSheathingType = new System.Windows.Forms.DataGridView();
            this.btnTypeExportSheathing = new System.Windows.Forms.Button();
            this.btnPriceHistorySheathing = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLumberType)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabLumberTools.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpUsedLumber.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSheathingType)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditLumber
            // 
            this.btnEditLumber.Location = new System.Drawing.Point(62, 85);
            this.btnEditLumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditLumber.Name = "btnEditLumber";
            this.btnEditLumber.Size = new System.Drawing.Size(228, 122);
            this.btnEditLumber.TabIndex = 0;
            this.btnEditLumber.Text = "Edit Selected Lumber Type";
            this.btnEditLumber.UseVisualStyleBackColor = true;
            this.btnEditLumber.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // dgvLumberType
            // 
            this.dgvLumberType.AllowUserToAddRows = false;
            this.dgvLumberType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvLumberType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLumberType.Location = new System.Drawing.Point(62, 361);
            this.dgvLumberType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLumberType.MultiSelect = false;
            this.dgvLumberType.Name = "dgvLumberType";
            this.dgvLumberType.RowHeadersWidth = 62;
            this.dgvLumberType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLumberType.Size = new System.Drawing.Size(1659, 809);
            this.dgvLumberType.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTypeResetFilters);
            this.groupBox1.Controls.Add(this.cboTypeTreatment);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboTypeUseAsStud);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboTypeStocked);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboTypeSpecies);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboTypeLength);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboTypeGrade);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboTypeWidth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboTypeDepth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(62, 251);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(982, 101);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter By";
            // 
            // btnTypeResetFilters
            // 
            this.btnTypeResetFilters.Location = new System.Drawing.Point(892, 25);
            this.btnTypeResetFilters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTypeResetFilters.Name = "btnTypeResetFilters";
            this.btnTypeResetFilters.Size = new System.Drawing.Size(69, 75);
            this.btnTypeResetFilters.TabIndex = 20;
            this.btnTypeResetFilters.Text = "Clear Filter";
            this.btnTypeResetFilters.UseVisualStyleBackColor = true;
            this.btnTypeResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // cboTypeTreatment
            // 
            this.cboTypeTreatment.FormattingEnabled = true;
            this.cboTypeTreatment.Location = new System.Drawing.Point(559, 49);
            this.cboTypeTreatment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTypeTreatment.Name = "cboTypeTreatment";
            this.cboTypeTreatment.Size = new System.Drawing.Size(90, 28);
            this.cboTypeTreatment.TabIndex = 19;
            this.cboTypeTreatment.SelectedIndexChanged += new System.EventHandler(this.cboTreatment_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(568, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Treatment";
            // 
            // cboTypeUseAsStud
            // 
            this.cboTypeUseAsStud.FormattingEnabled = true;
            this.cboTypeUseAsStud.Location = new System.Drawing.Point(766, 49);
            this.cboTypeUseAsStud.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTypeUseAsStud.Name = "cboTypeUseAsStud";
            this.cboTypeUseAsStud.Size = new System.Drawing.Size(90, 28);
            this.cboTypeUseAsStud.TabIndex = 17;
            this.cboTypeUseAsStud.SelectedIndexChanged += new System.EventHandler(this.cboUseAsStud_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(762, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Use as Stud";
            // 
            // cboTypeStocked
            // 
            this.cboTypeStocked.FormattingEnabled = true;
            this.cboTypeStocked.Location = new System.Drawing.Point(660, 49);
            this.cboTypeStocked.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTypeStocked.Name = "cboTypeStocked";
            this.cboTypeStocked.Size = new System.Drawing.Size(90, 28);
            this.cboTypeStocked.TabIndex = 15;
            this.cboTypeStocked.SelectedIndexChanged += new System.EventHandler(this.cboStocked_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(669, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Stocked";
            // 
            // cboTypeSpecies
            // 
            this.cboTypeSpecies.FormattingEnabled = true;
            this.cboTypeSpecies.Location = new System.Drawing.Point(450, 49);
            this.cboTypeSpecies.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTypeSpecies.Name = "cboTypeSpecies";
            this.cboTypeSpecies.Size = new System.Drawing.Size(93, 28);
            this.cboTypeSpecies.TabIndex = 13;
            this.cboTypeSpecies.SelectedIndexChanged += new System.EventHandler(this.cboSpecies_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Species";
            // 
            // cboTypeLength
            // 
            this.cboTypeLength.FormattingEnabled = true;
            this.cboTypeLength.Location = new System.Drawing.Point(342, 49);
            this.cboTypeLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTypeLength.Name = "cboTypeLength";
            this.cboTypeLength.Size = new System.Drawing.Size(95, 28);
            this.cboTypeLength.TabIndex = 11;
            this.cboTypeLength.SelectedIndexChanged += new System.EventHandler(this.cboLength_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Length";
            // 
            // cboTypeGrade
            // 
            this.cboTypeGrade.FormattingEnabled = true;
            this.cboTypeGrade.Location = new System.Drawing.Point(184, 49);
            this.cboTypeGrade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTypeGrade.Name = "cboTypeGrade";
            this.cboTypeGrade.Size = new System.Drawing.Size(147, 28);
            this.cboTypeGrade.TabIndex = 9;
            this.cboTypeGrade.SelectedIndexChanged += new System.EventHandler(this.cboGrade_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Grade";
            // 
            // cboTypeWidth
            // 
            this.cboTypeWidth.FormattingEnabled = true;
            this.cboTypeWidth.Location = new System.Drawing.Point(94, 49);
            this.cboTypeWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTypeWidth.Name = "cboTypeWidth";
            this.cboTypeWidth.Size = new System.Drawing.Size(79, 28);
            this.cboTypeWidth.TabIndex = 7;
            this.cboTypeWidth.SelectedIndexChanged += new System.EventHandler(this.cboWidth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Width";
            // 
            // cboTypeDepth
            // 
            this.cboTypeDepth.FormattingEnabled = true;
            this.cboTypeDepth.Location = new System.Drawing.Point(0, 49);
            this.cboTypeDepth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTypeDepth.Name = "cboTypeDepth";
            this.cboTypeDepth.Size = new System.Drawing.Size(84, 28);
            this.cboTypeDepth.TabIndex = 5;
            this.cboTypeDepth.SelectedIndexChanged += new System.EventHandler(this.cboDepth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Depth";
            // 
            // btnPriceHistoryLumber
            // 
            this.btnPriceHistoryLumber.Location = new System.Drawing.Point(298, 82);
            this.btnPriceHistoryLumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPriceHistoryLumber.Name = "btnPriceHistoryLumber";
            this.btnPriceHistoryLumber.Size = new System.Drawing.Size(228, 122);
            this.btnPriceHistoryLumber.TabIndex = 5;
            this.btnPriceHistoryLumber.Text = "See Selected Lumber Type\'s Price History";
            this.btnPriceHistoryLumber.UseVisualStyleBackColor = true;
            this.btnPriceHistoryLumber.Click += new System.EventHandler(this.btnPriceHistory_Click);
            // 
            // btnTypeExportLumber
            // 
            this.btnTypeExportLumber.Location = new System.Drawing.Point(536, 82);
            this.btnTypeExportLumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTypeExportLumber.Name = "btnTypeExportLumber";
            this.btnTypeExportLumber.Size = new System.Drawing.Size(228, 122);
            this.btnTypeExportLumber.TabIndex = 6;
            this.btnTypeExportLumber.Text = "Export Grid to CSV File";
            this.btnTypeExportLumber.UseVisualStyleBackColor = true;
            this.btnTypeExportLumber.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabLumberTools
            // 
            this.tabLumberTools.Controls.Add(this.tabPage1);
            this.tabLumberTools.Controls.Add(this.tabPage2);
            this.tabLumberTools.Controls.Add(this.tabPage3);
            this.tabLumberTools.Location = new System.Drawing.Point(40, 34);
            this.tabLumberTools.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLumberTools.Name = "tabLumberTools";
            this.tabLumberTools.SelectedIndex = 0;
            this.tabLumberTools.Size = new System.Drawing.Size(1866, 1326);
            this.tabLumberTools.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnEditLumber);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.dgvLumberType);
            this.tabPage1.Controls.Add(this.btnTypeExportLumber);
            this.tabPage1.Controls.Add(this.btnPriceHistoryLumber);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1858, 1293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Edit Lumber Types";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpUsedLumber);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.btnInventoryExport);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.dgvInventory);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1858, 1293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Current Inventory";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpUsedLumber
            // 
            this.grpUsedLumber.Controls.Add(this.label13);
            this.grpUsedLumber.Controls.Add(this.label10);
            this.grpUsedLumber.Controls.Add(this.dtpUsedEnd);
            this.grpUsedLumber.Controls.Add(this.dtpUsedStart);
            this.grpUsedLumber.Controls.Add(this.chkShowUsedLumber);
            this.grpUsedLumber.Location = new System.Drawing.Point(914, 34);
            this.grpUsedLumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpUsedLumber.Name = "grpUsedLumber";
            this.grpUsedLumber.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpUsedLumber.Size = new System.Drawing.Size(912, 234);
            this.grpUsedLumber.TabIndex = 42;
            this.grpUsedLumber.TabStop = false;
            this.grpUsedLumber.Text = "Used";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 20);
            this.label13.TabIndex = 45;
            this.label13.Text = "To";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 44;
            this.label10.Text = "From";
            // 
            // dtpUsedEnd
            // 
            this.dtpUsedEnd.Location = new System.Drawing.Point(95, 132);
            this.dtpUsedEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpUsedEnd.Name = "dtpUsedEnd";
            this.dtpUsedEnd.Size = new System.Drawing.Size(272, 26);
            this.dtpUsedEnd.TabIndex = 43;
            this.dtpUsedEnd.ValueChanged += new System.EventHandler(this.dtpUsedEnd_ValueChanged);
            // 
            // dtpUsedStart
            // 
            this.dtpUsedStart.Location = new System.Drawing.Point(95, 80);
            this.dtpUsedStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpUsedStart.Name = "dtpUsedStart";
            this.dtpUsedStart.Size = new System.Drawing.Size(272, 26);
            this.dtpUsedStart.TabIndex = 42;
            this.dtpUsedStart.ValueChanged += new System.EventHandler(this.dtpUsedStart_ValueChanged);
            // 
            // chkShowUsedLumber
            // 
            this.chkShowUsedLumber.AutoSize = true;
            this.chkShowUsedLumber.Location = new System.Drawing.Point(9, 40);
            this.chkShowUsedLumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkShowUsedLumber.Name = "chkShowUsedLumber";
            this.chkShowUsedLumber.Size = new System.Drawing.Size(175, 24);
            this.chkShowUsedLumber.TabIndex = 41;
            this.chkShowUsedLumber.Text = "Show Lumber Used";
            this.chkShowUsedLumber.UseVisualStyleBackColor = true;
            this.chkShowUsedLumber.CheckedChanged += new System.EventHandler(this.chkShowUsedLumber_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTotalPieces);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lblBoardFeet);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lblBundlesTotalsQty);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(377, 9);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(342, 148);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Totals";
            // 
            // lblTotalPieces
            // 
            this.lblTotalPieces.AutoSize = true;
            this.lblTotalPieces.Location = new System.Drawing.Point(150, 105);
            this.lblTotalPieces.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPieces.Name = "lblTotalPieces";
            this.lblTotalPieces.Size = new System.Drawing.Size(56, 20);
            this.lblTotalPieces.TabIndex = 5;
            this.lblTotalPieces.Text = "Pieces";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 105);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Pieces:";
            // 
            // lblBoardFeet
            // 
            this.lblBoardFeet.AutoSize = true;
            this.lblBoardFeet.Location = new System.Drawing.Point(150, 69);
            this.lblBoardFeet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBoardFeet.Name = "lblBoardFeet";
            this.lblBoardFeet.Size = new System.Drawing.Size(85, 20);
            this.lblBoardFeet.TabIndex = 3;
            this.lblBoardFeet.Text = "BoardFeet";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 69);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Board Feet:";
            // 
            // lblBundlesTotalsQty
            // 
            this.lblBundlesTotalsQty.AutoSize = true;
            this.lblBundlesTotalsQty.Location = new System.Drawing.Point(150, 35);
            this.lblBundlesTotalsQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBundlesTotalsQty.Name = "lblBundlesTotalsQty";
            this.lblBundlesTotalsQty.Size = new System.Drawing.Size(71, 20);
            this.lblBundlesTotalsQty.TabIndex = 1;
            this.lblBundlesTotalsQty.Text = "Bundles:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 35);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Bundles:";
            // 
            // btnInventoryExport
            // 
            this.btnInventoryExport.Location = new System.Drawing.Point(104, 34);
            this.btnInventoryExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInventoryExport.Name = "btnInventoryExport";
            this.btnInventoryExport.Size = new System.Drawing.Size(228, 122);
            this.btnInventoryExport.TabIndex = 39;
            this.btnInventoryExport.Text = "Export Grid to CSV File";
            this.btnInventoryExport.UseVisualStyleBackColor = true;
            this.btnInventoryExport.Click += new System.EventHandler(this.btnInventoryExport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInventoryClearFilter);
            this.groupBox2.Controls.Add(this.cboInventoryTreatment);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.cboInventorySpecies);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.cboInventoryLength);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cboInventoryGrade);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.cboInventoryWidth);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.cboInventoryDepth);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Location = new System.Drawing.Point(104, 166);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(801, 101);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter By";
            // 
            // btnInventoryClearFilter
            // 
            this.btnInventoryClearFilter.Location = new System.Drawing.Point(703, 18);
            this.btnInventoryClearFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInventoryClearFilter.Name = "btnInventoryClearFilter";
            this.btnInventoryClearFilter.Size = new System.Drawing.Size(69, 75);
            this.btnInventoryClearFilter.TabIndex = 20;
            this.btnInventoryClearFilter.Text = "Clear Filter";
            this.btnInventoryClearFilter.UseVisualStyleBackColor = true;
            this.btnInventoryClearFilter.Click += new System.EventHandler(this.btnInventoryClearFilter_Click);
            // 
            // cboInventoryTreatment
            // 
            this.cboInventoryTreatment.FormattingEnabled = true;
            this.cboInventoryTreatment.Location = new System.Drawing.Point(559, 49);
            this.cboInventoryTreatment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboInventoryTreatment.Name = "cboInventoryTreatment";
            this.cboInventoryTreatment.Size = new System.Drawing.Size(90, 28);
            this.cboInventoryTreatment.TabIndex = 19;
            this.cboInventoryTreatment.SelectedIndexChanged += new System.EventHandler(this.cboInventoryTreatment_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(568, 25);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 20);
            this.label16.TabIndex = 18;
            this.label16.Text = "Treatment";
            // 
            // cboInventorySpecies
            // 
            this.cboInventorySpecies.FormattingEnabled = true;
            this.cboInventorySpecies.Location = new System.Drawing.Point(450, 49);
            this.cboInventorySpecies.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboInventorySpecies.Name = "cboInventorySpecies";
            this.cboInventorySpecies.Size = new System.Drawing.Size(93, 28);
            this.cboInventorySpecies.TabIndex = 13;
            this.cboInventorySpecies.SelectedIndexChanged += new System.EventHandler(this.cboInventorySpecies_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(464, 25);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 20);
            this.label19.TabIndex = 12;
            this.label19.Text = "Species";
            // 
            // cboInventoryLength
            // 
            this.cboInventoryLength.FormattingEnabled = true;
            this.cboInventoryLength.Location = new System.Drawing.Point(342, 49);
            this.cboInventoryLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboInventoryLength.Name = "cboInventoryLength";
            this.cboInventoryLength.Size = new System.Drawing.Size(95, 28);
            this.cboInventoryLength.TabIndex = 11;
            this.cboInventoryLength.SelectedIndexChanged += new System.EventHandler(this.cboInventoryLength_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(363, 25);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 20);
            this.label20.TabIndex = 10;
            this.label20.Text = "Length";
            // 
            // cboInventoryGrade
            // 
            this.cboInventoryGrade.FormattingEnabled = true;
            this.cboInventoryGrade.Location = new System.Drawing.Point(184, 49);
            this.cboInventoryGrade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboInventoryGrade.Name = "cboInventoryGrade";
            this.cboInventoryGrade.Size = new System.Drawing.Size(147, 28);
            this.cboInventoryGrade.TabIndex = 9;
            this.cboInventoryGrade.SelectedIndexChanged += new System.EventHandler(this.cboInventoryGrade_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(233, 25);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 20);
            this.label21.TabIndex = 8;
            this.label21.Text = "Grade";
            // 
            // cboInventoryWidth
            // 
            this.cboInventoryWidth.FormattingEnabled = true;
            this.cboInventoryWidth.Location = new System.Drawing.Point(94, 49);
            this.cboInventoryWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboInventoryWidth.Name = "cboInventoryWidth";
            this.cboInventoryWidth.Size = new System.Drawing.Size(79, 28);
            this.cboInventoryWidth.TabIndex = 7;
            this.cboInventoryWidth.SelectedIndexChanged += new System.EventHandler(this.cboInventoryWidth_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(104, 25);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 20);
            this.label22.TabIndex = 6;
            this.label22.Text = "Width";
            // 
            // cboInventoryDepth
            // 
            this.cboInventoryDepth.FormattingEnabled = true;
            this.cboInventoryDepth.Location = new System.Drawing.Point(0, 49);
            this.cboInventoryDepth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboInventoryDepth.Name = "cboInventoryDepth";
            this.cboInventoryDepth.Size = new System.Drawing.Size(84, 28);
            this.cboInventoryDepth.TabIndex = 5;
            this.cboInventoryDepth.SelectedIndexChanged += new System.EventHandler(this.cboInventoryDepth_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 25);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 20);
            this.label23.TabIndex = 4;
            this.label23.Text = "Depth";
            // 
            // dgvInventory
            // 
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(9, 294);
            this.dgvInventory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowHeadersWidth = 62;
            this.dgvInventory.Size = new System.Drawing.Size(1836, 955);
            this.dgvInventory.TabIndex = 0;
            this.dgvInventory.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInventory_ColumnHeaderMouseClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnEditSheathing);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.dgvSheathingType);
            this.tabPage3.Controls.Add(this.btnTypeExportSheathing);
            this.tabPage3.Controls.Add(this.btnPriceHistorySheathing);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1858, 1293);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Edit Sheathing Types";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnEditSheathing
            // 
            this.btnEditSheathing.Location = new System.Drawing.Point(100, 105);
            this.btnEditSheathing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditSheathing.Name = "btnEditSheathing";
            this.btnEditSheathing.Size = new System.Drawing.Size(228, 122);
            this.btnEditSheathing.TabIndex = 7;
            this.btnEditSheathing.Text = "Edit Selected Sheathing Type";
            this.btnEditSheathing.UseVisualStyleBackColor = true;
            this.btnEditSheathing.Click += new System.EventHandler(this.btnEditSheathing_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.cboTreatmentSheathing);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.cboStructualSheathing);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.cboLengthSheathing);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.cboGradeSheathing);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.cboWidthSheathing);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.cboThicknessSheathing);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Location = new System.Drawing.Point(100, 271);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(982, 101);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter By";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(892, 25);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 75);
            this.button2.TabIndex = 20;
            this.button2.Text = "Clear Filter";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cboTreatmentSheathing
            // 
            this.cboTreatmentSheathing.FormattingEnabled = true;
            this.cboTreatmentSheathing.Location = new System.Drawing.Point(559, 49);
            this.cboTreatmentSheathing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTreatmentSheathing.Name = "cboTreatmentSheathing";
            this.cboTreatmentSheathing.Size = new System.Drawing.Size(90, 28);
            this.cboTreatmentSheathing.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(568, 25);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 20);
            this.label14.TabIndex = 18;
            this.label14.Text = "Treatment";
            // 
            // cboStructualSheathing
            // 
            this.cboStructualSheathing.FormattingEnabled = true;
            this.cboStructualSheathing.Location = new System.Drawing.Point(450, 49);
            this.cboStructualSheathing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboStructualSheathing.Name = "cboStructualSheathing";
            this.cboStructualSheathing.Size = new System.Drawing.Size(93, 28);
            this.cboStructualSheathing.TabIndex = 13;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(460, 24);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 20);
            this.label18.TabIndex = 12;
            this.label18.Text = "Structual";
            // 
            // cboLengthSheathing
            // 
            this.cboLengthSheathing.FormattingEnabled = true;
            this.cboLengthSheathing.Location = new System.Drawing.Point(182, 48);
            this.cboLengthSheathing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLengthSheathing.Name = "cboLengthSheathing";
            this.cboLengthSheathing.Size = new System.Drawing.Size(95, 28);
            this.cboLengthSheathing.TabIndex = 11;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(203, 24);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 20);
            this.label24.TabIndex = 10;
            this.label24.Text = "Length";
            // 
            // cboGradeSheathing
            // 
            this.cboGradeSheathing.FormattingEnabled = true;
            this.cboGradeSheathing.Location = new System.Drawing.Point(296, 49);
            this.cboGradeSheathing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboGradeSheathing.Name = "cboGradeSheathing";
            this.cboGradeSheathing.Size = new System.Drawing.Size(147, 28);
            this.cboGradeSheathing.TabIndex = 9;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(345, 25);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 20);
            this.label25.TabIndex = 8;
            this.label25.Text = "Grade";
            // 
            // cboWidthSheathing
            // 
            this.cboWidthSheathing.FormattingEnabled = true;
            this.cboWidthSheathing.Location = new System.Drawing.Point(94, 49);
            this.cboWidthSheathing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboWidthSheathing.Name = "cboWidthSheathing";
            this.cboWidthSheathing.Size = new System.Drawing.Size(79, 28);
            this.cboWidthSheathing.TabIndex = 7;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(104, 25);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(50, 20);
            this.label26.TabIndex = 6;
            this.label26.Text = "Width";
            // 
            // cboThicknessSheathing
            // 
            this.cboThicknessSheathing.FormattingEnabled = true;
            this.cboThicknessSheathing.Location = new System.Drawing.Point(0, 49);
            this.cboThicknessSheathing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboThicknessSheathing.Name = "cboThicknessSheathing";
            this.cboThicknessSheathing.Size = new System.Drawing.Size(84, 28);
            this.cboThicknessSheathing.TabIndex = 5;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(9, 25);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 20);
            this.label27.TabIndex = 4;
            this.label27.Text = "Thickness";
            // 
            // dgvSheathingType
            // 
            this.dgvSheathingType.AllowUserToAddRows = false;
            this.dgvSheathingType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvSheathingType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSheathingType.Location = new System.Drawing.Point(100, 381);
            this.dgvSheathingType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSheathingType.MultiSelect = false;
            this.dgvSheathingType.Name = "dgvSheathingType";
            this.dgvSheathingType.RowHeadersWidth = 62;
            this.dgvSheathingType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSheathingType.Size = new System.Drawing.Size(1659, 809);
            this.dgvSheathingType.TabIndex = 8;
            // 
            // btnTypeExportSheathing
            // 
            this.btnTypeExportSheathing.Location = new System.Drawing.Point(574, 102);
            this.btnTypeExportSheathing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTypeExportSheathing.Name = "btnTypeExportSheathing";
            this.btnTypeExportSheathing.Size = new System.Drawing.Size(228, 122);
            this.btnTypeExportSheathing.TabIndex = 11;
            this.btnTypeExportSheathing.Text = "Export Grid to CSV File";
            this.btnTypeExportSheathing.UseVisualStyleBackColor = true;
            // 
            // btnPriceHistorySheathing
            // 
            this.btnPriceHistorySheathing.Location = new System.Drawing.Point(336, 102);
            this.btnPriceHistorySheathing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPriceHistorySheathing.Name = "btnPriceHistorySheathing";
            this.btnPriceHistorySheathing.Size = new System.Drawing.Size(228, 122);
            this.btnPriceHistorySheathing.TabIndex = 10;
            this.btnPriceHistorySheathing.Text = "See Selected Sheathing Type\'s Price History";
            this.btnPriceHistorySheathing.UseVisualStyleBackColor = true;
            // 
            // frmEditLumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1909, 1391);
            this.Controls.Add(this.tabLumberTools);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmEditLumber";
            this.Text = "Clearspan Material Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditLumber_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLumberType)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabLumberTools.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grpUsedLumber.ResumeLayout(false);
            this.grpUsedLumber.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSheathingType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditLumber;
        private System.Windows.Forms.DataGridView dgvLumberType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTypeDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTypeUseAsStud;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTypeStocked;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTypeSpecies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTypeLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTypeGrade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTypeWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTypeTreatment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnTypeResetFilters;
        private System.Windows.Forms.Button btnPriceHistoryLumber;
        private System.Windows.Forms.Button btnTypeExportLumber;
        private System.Windows.Forms.TabControl tabLumberTools;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInventoryClearFilter;
        private System.Windows.Forms.ComboBox cboInventoryTreatment;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboInventorySpecies;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboInventoryLength;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboInventoryGrade;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboInventoryWidth;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cboInventoryDepth;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnInventoryExport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblBoardFeet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBundlesTotalsQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalPieces;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkShowUsedLumber;
        private System.Windows.Forms.GroupBox grpUsedLumber;
        private System.Windows.Forms.DateTimePicker dtpUsedEnd;
        private System.Windows.Forms.DateTimePicker dtpUsedStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnEditSheathing;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboTreatmentSheathing;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboStructualSheathing;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboLengthSheathing;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cboGradeSheathing;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cboWidthSheathing;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cboThicknessSheathing;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DataGridView dgvSheathingType;
        private System.Windows.Forms.Button btnTypeExportSheathing;
        private System.Windows.Forms.Button btnPriceHistorySheathing;
    }
}

