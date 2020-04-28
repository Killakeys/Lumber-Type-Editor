namespace CCDLumberTypeEditor
{
    partial class frmEditFields
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
            this.lblLumberDescription = new System.Windows.Forms.Label();
            this.chkStocked = new System.Windows.Forms.CheckBox();
            this.chkUseAsStud = new System.Windows.Forms.CheckBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblCurrentPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLumberDescription
            // 
            this.lblLumberDescription.AutoSize = true;
            this.lblLumberDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLumberDescription.Location = new System.Drawing.Point(22, 9);
            this.lblLumberDescription.Name = "lblLumberDescription";
            this.lblLumberDescription.Size = new System.Drawing.Size(79, 16);
            this.lblLumberDescription.TabIndex = 1;
            this.lblLumberDescription.Text = "2x4 #3 10ft";
            // 
            // chkStocked
            // 
            this.chkStocked.AutoSize = true;
            this.chkStocked.Location = new System.Drawing.Point(25, 45);
            this.chkStocked.Name = "chkStocked";
            this.chkStocked.Size = new System.Drawing.Size(66, 17);
            this.chkStocked.TabIndex = 2;
            this.chkStocked.Text = "Stocked";
            this.chkStocked.UseVisualStyleBackColor = true;
            // 
            // chkUseAsStud
            // 
            this.chkUseAsStud.AutoSize = true;
            this.chkUseAsStud.Location = new System.Drawing.Point(25, 68);
            this.chkUseAsStud.Name = "chkUseAsStud";
            this.chkUseAsStud.Size = new System.Drawing.Size(84, 17);
            this.chkUseAsStud.TabIndex = 3;
            this.chkUseAsStud.Text = "Use as Stud";
            this.chkUseAsStud.UseVisualStyleBackColor = true;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(99, 127);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(58, 20);
            this.txtPrice.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current Price";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 175);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(134, 50);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblCurrentPrice
            // 
            this.lblCurrentPrice.AutoSize = true;
            this.lblCurrentPrice.Location = new System.Drawing.Point(96, 102);
            this.lblCurrentPrice.Name = "lblCurrentPrice";
            this.lblCurrentPrice.Size = new System.Drawing.Size(68, 13);
            this.lblCurrentPrice.TabIndex = 7;
            this.lblCurrentPrice.Text = "Current Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "New Price";
            // 
            // frmEditFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 237);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCurrentPrice);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.chkUseAsStud);
            this.Controls.Add(this.chkStocked);
            this.Controls.Add(this.lblLumberDescription);
            this.Name = "frmEditFields";
            this.Text = "Update Lumber Type";
            this.Load += new System.EventHandler(this.frmEditFields_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLumberDescription;
        private System.Windows.Forms.CheckBox chkStocked;
        private System.Windows.Forms.CheckBox chkUseAsStud;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblCurrentPrice;
        private System.Windows.Forms.Label label3;
    }
}