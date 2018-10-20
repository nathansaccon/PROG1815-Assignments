namespace NSacconAssignment3
{
    partial class NSacconAssignment3
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.gbxFile = new System.Windows.Forms.GroupBox();
            this.radExisting = new System.Windows.Forms.RadioButton();
            this.radNew = new System.Windows.Forms.RadioButton();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTransationNumber = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTool = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnWriteRecord = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.txtTransationNumberToDelete = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDisplayData = new System.Windows.Forms.RichTextBox();
            this.btnDisplayData = new System.Windows.Forms.Button();
            this.btnCloseFile = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDisplayMessage = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblFileStatus = new System.Windows.Forms.Label();
            this.btnAutoFill = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.gbxFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Filename:";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(17, 29);
            this.txtFilename.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(197, 20);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.Leave += new System.EventHandler(this.txtFilename_Leave);
            // 
            // gbxFile
            // 
            this.gbxFile.Controls.Add(this.radExisting);
            this.gbxFile.Controls.Add(this.radNew);
            this.gbxFile.Location = new System.Drawing.Point(218, 13);
            this.gbxFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbxFile.Name = "gbxFile";
            this.gbxFile.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbxFile.Size = new System.Drawing.Size(187, 38);
            this.gbxFile.TabIndex = 10;
            this.gbxFile.TabStop = false;
            this.gbxFile.Text = "File";
            // 
            // radExisting
            // 
            this.radExisting.AutoSize = true;
            this.radExisting.Checked = true;
            this.radExisting.Location = new System.Drawing.Point(95, 18);
            this.radExisting.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radExisting.Name = "radExisting";
            this.radExisting.Size = new System.Drawing.Size(90, 17);
            this.radExisting.TabIndex = 1;
            this.radExisting.TabStop = true;
            this.radExisting.Text = "Open Existing";
            this.radExisting.UseVisualStyleBackColor = true;
            // 
            // radNew
            // 
            this.radNew.AutoSize = true;
            this.radNew.Location = new System.Drawing.Point(7, 18);
            this.radNew.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radNew.Name = "radNew";
            this.radNew.Size = new System.Drawing.Size(81, 17);
            this.radNew.TabIndex = 1;
            this.radNew.Text = "Create New";
            this.radNew.UseVisualStyleBackColor = true;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(409, 27);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(137, 23);
            this.btnOpenFile.TabIndex = 7;
            this.btnOpenFile.TabStop = false;
            this.btnOpenFile.Text = "Create / Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Transaction #";
            // 
            // txtTransationNumber
            // 
            this.txtTransationNumber.HideSelection = false;
            this.txtTransationNumber.Location = new System.Drawing.Point(12, 91);
            this.txtTransationNumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTransationNumber.Name = "txtTransationNumber";
            this.txtTransationNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTransationNumber.TabIndex = 1;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(119, 91);
            this.txtDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(75, 20);
            this.txtDate.TabIndex = 2;
            this.txtDate.Enter += new System.EventHandler(this.txtDate_Enter);
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Date";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(198, 91);
            this.txtSerialNumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(89, 20);
            this.txtSerialNumber.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Serial Number";
            // 
            // txtTool
            // 
            this.txtTool.Location = new System.Drawing.Point(294, 91);
            this.txtTool.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTool.Name = "txtTool";
            this.txtTool.Size = new System.Drawing.Size(159, 20);
            this.txtTool.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tool Purchased";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(458, 91);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(77, 20);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(456, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Price";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(541, 91);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(53, 20);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(539, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Quantity";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmount.Location = new System.Drawing.Point(601, 91);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(599, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Amount";
            // 
            // btnWriteRecord
            // 
            this.btnWriteRecord.Location = new System.Drawing.Point(13, 140);
            this.btnWriteRecord.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnWriteRecord.Name = "btnWriteRecord";
            this.btnWriteRecord.Size = new System.Drawing.Size(98, 23);
            this.btnWriteRecord.TabIndex = 22;
            this.btnWriteRecord.Text = "Write A Record";
            this.btnWriteRecord.UseVisualStyleBackColor = true;
            this.btnWriteRecord.Click += new System.EventHandler(this.btnWriteRecord_Click);
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Location = new System.Drawing.Point(119, 140);
            this.btnDeleteRecord.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(187, 23);
            this.btnDeleteRecord.TabIndex = 23;
            this.btnDeleteRecord.Text = "Delete Record By Transaction #:";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // txtTransationNumberToDelete
            // 
            this.txtTransationNumberToDelete.Location = new System.Drawing.Point(313, 141);
            this.txtTransationNumberToDelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTransationNumberToDelete.Name = "txtTransationNumberToDelete";
            this.txtTransationNumberToDelete.Size = new System.Drawing.Size(100, 20);
            this.txtTransationNumberToDelete.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(311, 126);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Transaction #";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 180);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Data Display";
            // 
            // txtDisplayData
            // 
            this.txtDisplayData.BackColor = System.Drawing.SystemColors.Window;
            this.txtDisplayData.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplayData.Location = new System.Drawing.Point(12, 196);
            this.txtDisplayData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDisplayData.Name = "txtDisplayData";
            this.txtDisplayData.ReadOnly = true;
            this.txtDisplayData.Size = new System.Drawing.Size(707, 225);
            this.txtDisplayData.TabIndex = 27;
            this.txtDisplayData.Text = "";
            // 
            // btnDisplayData
            // 
            this.btnDisplayData.Location = new System.Drawing.Point(13, 428);
            this.btnDisplayData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDisplayData.Name = "btnDisplayData";
            this.btnDisplayData.Size = new System.Drawing.Size(74, 23);
            this.btnDisplayData.TabIndex = 28;
            this.btnDisplayData.Text = "Display Data";
            this.btnDisplayData.UseVisualStyleBackColor = true;
            this.btnDisplayData.Click += new System.EventHandler(this.btnDisplayData_Click);
            // 
            // btnCloseFile
            // 
            this.btnCloseFile.Location = new System.Drawing.Point(95, 428);
            this.btnCloseFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCloseFile.Name = "btnCloseFile";
            this.btnCloseFile.Size = new System.Drawing.Size(74, 23);
            this.btnCloseFile.TabIndex = 29;
            this.btnCloseFile.Text = "Close File";
            this.btnCloseFile.UseVisualStyleBackColor = true;
            this.btnCloseFile.Click += new System.EventHandler(this.btnCloseFile_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(175, 428);
            this.btnDeleteFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(74, 23);
            this.btnDeleteFile.TabIndex = 30;
            this.btnDeleteFile.Text = "Delete File";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 464);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Message Display";
            // 
            // txtDisplayMessage
            // 
            this.txtDisplayMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtDisplayMessage.ForeColor = System.Drawing.Color.Red;
            this.txtDisplayMessage.Location = new System.Drawing.Point(12, 479);
            this.txtDisplayMessage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDisplayMessage.Name = "txtDisplayMessage";
            this.txtDisplayMessage.ReadOnly = true;
            this.txtDisplayMessage.Size = new System.Drawing.Size(707, 51);
            this.txtDisplayMessage.TabIndex = 32;
            this.txtDisplayMessage.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(617, 16);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "File Status:";
            // 
            // lblFileStatus
            // 
            this.lblFileStatus.AutoSize = true;
            this.lblFileStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFileStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileStatus.ForeColor = System.Drawing.Color.Red;
            this.lblFileStatus.Location = new System.Drawing.Point(617, 31);
            this.lblFileStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFileStatus.Name = "lblFileStatus";
            this.lblFileStatus.Size = new System.Drawing.Size(69, 24);
            this.lblFileStatus.TabIndex = 34;
            this.lblFileStatus.Text = "Closed";
            this.lblFileStatus.Click += new System.EventHandler(this.lblFileStatus_Click);
            // 
            // btnAutoFill
            // 
            this.btnAutoFill.Location = new System.Drawing.Point(643, 451);
            this.btnAutoFill.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAutoFill.Name = "btnAutoFill";
            this.btnAutoFill.Size = new System.Drawing.Size(74, 23);
            this.btnAutoFill.TabIndex = 35;
            this.btnAutoFill.Text = "Auto Fill";
            this.btnAutoFill.UseVisualStyleBackColor = true;
            this.btnAutoFill.Click += new System.EventHandler(this.btnAutoFill_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(563, 451);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(74, 23);
            this.btnAbout.TabIndex = 36;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // chkAutoUpdate
            // 
            this.chkAutoUpdate.AutoSize = true;
            this.chkAutoUpdate.Location = new System.Drawing.Point(254, 432);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new System.Drawing.Size(123, 17);
            this.chkAutoUpdate.TabIndex = 37;
            this.chkAutoUpdate.Text = "Auto-Update Display";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;
            this.chkAutoUpdate.CheckedChanged += new System.EventHandler(this.chkAutoUpdate_CheckedChanged);
            // 
            // NSacconAssignment3
            // 
            this.AcceptButton = this.btnWriteRecord;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(731, 543);
            this.Controls.Add(this.chkAutoUpdate);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnAutoFill);
            this.Controls.Add(this.lblFileStatus);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDisplayMessage);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.btnCloseFile);
            this.Controls.Add(this.btnDisplayData);
            this.Controls.Add(this.txtDisplayData);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTransationNumberToDelete);
            this.Controls.Add(this.btnDeleteRecord);
            this.Controls.Add(this.btnWriteRecord);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTool);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTransationNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.gbxFile);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "NSacconAssignment3";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NSacconAssignment3_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxFile.ResumeLayout(false);
            this.gbxFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.GroupBox gbxFile;
        private System.Windows.Forms.RadioButton radExisting;
        private System.Windows.Forms.RadioButton radNew;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTransationNumber;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTool;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnWriteRecord;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.TextBox txtTransationNumberToDelete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox txtDisplayData;
        private System.Windows.Forms.Button btnDisplayData;
        private System.Windows.Forms.Button btnCloseFile;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox txtDisplayMessage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblFileStatus;
        private System.Windows.Forms.Button btnAutoFill;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.CheckBox chkAutoUpdate;
    }
}

