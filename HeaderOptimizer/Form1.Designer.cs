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
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgvLumberType = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboTreatment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboUseAsStud = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboStocked = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSpecies = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboLength = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboWidth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDepth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPriceHistory = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLumberType)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(56, 28);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(152, 80);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit Selected Lumber Type";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // dgvLumberType
            // 
            this.dgvLumberType.AllowUserToAddRows = false;
            this.dgvLumberType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvLumberType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLumberType.Location = new System.Drawing.Point(12, 204);
            this.dgvLumberType.MultiSelect = false;
            this.dgvLumberType.Name = "dgvLumberType";
            this.dgvLumberType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLumberType.Size = new System.Drawing.Size(1106, 526);
            this.dgvLumberType.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResetFilters);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.cboTreatment);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboUseAsStud);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboStocked);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboSpecies);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboLength);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboGrade);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboWidth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboDepth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 66);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter By";
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Location = new System.Drawing.Point(684, 11);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(46, 49);
            this.btnResetFilters.TabIndex = 20;
            this.btnResetFilters.Text = "Clear Filter";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(588, 11);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(46, 49);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cboTreatment
            // 
            this.cboTreatment.FormattingEnabled = true;
            this.cboTreatment.Location = new System.Drawing.Point(373, 32);
            this.cboTreatment.Name = "cboTreatment";
            this.cboTreatment.Size = new System.Drawing.Size(61, 21);
            this.cboTreatment.TabIndex = 19;
            this.cboTreatment.SelectedIndexChanged += new System.EventHandler(this.cboTreatment_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(379, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Treatment";
            // 
            // cboUseAsStud
            // 
            this.cboUseAsStud.FormattingEnabled = true;
            this.cboUseAsStud.Location = new System.Drawing.Point(511, 32);
            this.cboUseAsStud.Name = "cboUseAsStud";
            this.cboUseAsStud.Size = new System.Drawing.Size(61, 21);
            this.cboUseAsStud.TabIndex = 17;
            this.cboUseAsStud.SelectedIndexChanged += new System.EventHandler(this.cboUseAsStud_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(508, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Use as Stud";
            // 
            // cboStocked
            // 
            this.cboStocked.FormattingEnabled = true;
            this.cboStocked.Location = new System.Drawing.Point(440, 32);
            this.cboStocked.Name = "cboStocked";
            this.cboStocked.Size = new System.Drawing.Size(61, 21);
            this.cboStocked.TabIndex = 15;
            this.cboStocked.SelectedIndexChanged += new System.EventHandler(this.cboStocked_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(446, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Stocked";
            // 
            // cboSpecies
            // 
            this.cboSpecies.FormattingEnabled = true;
            this.cboSpecies.Location = new System.Drawing.Point(300, 32);
            this.cboSpecies.Name = "cboSpecies";
            this.cboSpecies.Size = new System.Drawing.Size(63, 21);
            this.cboSpecies.TabIndex = 13;
            this.cboSpecies.SelectedIndexChanged += new System.EventHandler(this.cboSpecies_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Species";
            // 
            // cboLength
            // 
            this.cboLength.FormattingEnabled = true;
            this.cboLength.Location = new System.Drawing.Point(228, 32);
            this.cboLength.Name = "cboLength";
            this.cboLength.Size = new System.Drawing.Size(65, 21);
            this.cboLength.TabIndex = 11;
            this.cboLength.SelectedIndexChanged += new System.EventHandler(this.cboLength_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Length";
            // 
            // cboGrade
            // 
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(123, 32);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(99, 21);
            this.cboGrade.TabIndex = 9;
            this.cboGrade.SelectedIndexChanged += new System.EventHandler(this.cboGrade_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Grade";
            // 
            // cboWidth
            // 
            this.cboWidth.FormattingEnabled = true;
            this.cboWidth.Location = new System.Drawing.Point(63, 32);
            this.cboWidth.Name = "cboWidth";
            this.cboWidth.Size = new System.Drawing.Size(54, 21);
            this.cboWidth.TabIndex = 7;
            this.cboWidth.SelectedIndexChanged += new System.EventHandler(this.cboWidth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Width";
            // 
            // cboDepth
            // 
            this.cboDepth.FormattingEnabled = true;
            this.cboDepth.Location = new System.Drawing.Point(0, 32);
            this.cboDepth.Name = "cboDepth";
            this.cboDepth.Size = new System.Drawing.Size(57, 21);
            this.cboDepth.TabIndex = 5;
            this.cboDepth.SelectedIndexChanged += new System.EventHandler(this.cboDepth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Depth";
            // 
            // btnPriceHistory
            // 
            this.btnPriceHistory.Location = new System.Drawing.Point(214, 28);
            this.btnPriceHistory.Name = "btnPriceHistory";
            this.btnPriceHistory.Size = new System.Drawing.Size(152, 80);
            this.btnPriceHistory.TabIndex = 5;
            this.btnPriceHistory.Text = "See Selected Lumber Type\'s Price History";
            this.btnPriceHistory.UseVisualStyleBackColor = true;
            this.btnPriceHistory.Click += new System.EventHandler(this.btnPriceHistory_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(372, 28);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(152, 80);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export Grid to CSV File";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmEditLumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 742);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPriceHistory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvLumberType);
            this.Controls.Add(this.btnEdit);
            this.Name = "frmEditLumber";
            this.Text = "Edit Lumber Type";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditLumber_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLumberType)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dgvLumberType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cboUseAsStud;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboStocked;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSpecies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTreatment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Button btnPriceHistory;
        private System.Windows.Forms.Button btnExport;
    }
}

