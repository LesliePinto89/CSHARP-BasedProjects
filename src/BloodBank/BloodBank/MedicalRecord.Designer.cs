namespace BloodBank
{
    partial class MedicalRecord
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
            this.txtBloodType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRHFactor = new System.Windows.Forms.TextBox();
            this.txtMedicalHistory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNHSNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEthnicity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dobPicker = new System.Windows.Forms.DateTimePicker();
            this.gpdrAgreeBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.submitDonorDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBloodType
            // 
            this.txtBloodType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtBloodType.Location = new System.Drawing.Point(155, 239);
            this.txtBloodType.Name = "txtBloodType";
            this.txtBloodType.Size = new System.Drawing.Size(197, 26);
            this.txtBloodType.TabIndex = 0;
            this.txtBloodType.TextChanged += new System.EventHandler(this.TxtBloodType_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Blood Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(55, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rhesus (Rh) factor ";
            // 
            // txtRHFactor
            // 
            this.txtRHFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtRHFactor.Location = new System.Drawing.Point(209, 286);
            this.txtRHFactor.Name = "txtRHFactor";
            this.txtRHFactor.Size = new System.Drawing.Size(143, 26);
            this.txtRHFactor.TabIndex = 5;
            this.txtRHFactor.TextChanged += new System.EventHandler(this.TxtRHFactor_TextChanged);
            // 
            // txtMedicalHistory
            // 
            this.txtMedicalHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtMedicalHistory.Location = new System.Drawing.Point(414, 73);
            this.txtMedicalHistory.Multiline = true;
            this.txtMedicalHistory.Name = "txtMedicalHistory";
            this.txtMedicalHistory.Size = new System.Drawing.Size(362, 178);
            this.txtMedicalHistory.TabIndex = 8;
            this.txtMedicalHistory.TextChanged += new System.EventHandler(this.TxtMedicalHistory_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(410, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Medical History";
            // 
            // txtGender
            // 
            this.txtGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtGender.Location = new System.Drawing.Point(142, 142);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(210, 26);
            this.txtGender.TabIndex = 10;
            this.txtGender.TextChanged += new System.EventHandler(this.TxtGender_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(55, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Gender";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(55, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "DOB";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // txtNHSNumber
            // 
            this.txtNHSNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtNHSNumber.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtNHSNumber.Location = new System.Drawing.Point(175, 50);
            this.txtNHSNumber.Name = "txtNHSNumber";
            this.txtNHSNumber.Size = new System.Drawing.Size(177, 26);
            this.txtNHSNumber.TabIndex = 14;
            this.txtNHSNumber.TextChanged += new System.EventHandler(this.TxtNHSNumber_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(55, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "NHS Number";
            // 
            // txtEthnicity
            // 
            this.txtEthnicity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtEthnicity.Location = new System.Drawing.Point(142, 187);
            this.txtEthnicity.Name = "txtEthnicity";
            this.txtEthnicity.Size = new System.Drawing.Size(210, 26);
            this.txtEthnicity.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(55, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Ethnicity";
            // 
            // dobPicker
            // 
            this.dobPicker.Location = new System.Drawing.Point(142, 100);
            this.dobPicker.Name = "dobPicker";
            this.dobPicker.Size = new System.Drawing.Size(210, 20);
            this.dobPicker.TabIndex = 18;
            // 
            // gpdrAgreeBox
            // 
            this.gpdrAgreeBox.AutoSize = true;
            this.gpdrAgreeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.gpdrAgreeBox.Location = new System.Drawing.Point(704, 288);
            this.gpdrAgreeBox.Name = "gpdrAgreeBox";
            this.gpdrAgreeBox.Size = new System.Drawing.Size(72, 24);
            this.gpdrAgreeBox.TabIndex = 19;
            this.gpdrAgreeBox.Text = "Agree";
            this.gpdrAgreeBox.UseVisualStyleBackColor = true;
            this.gpdrAgreeBox.CheckedChanged += new System.EventHandler(this.GpdrAgreeBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(410, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 60);
            this.label3.TabIndex = 20;
            this.label3.Text = "You must check to agree to us using \r\nyour information in accordance with \r\nthe G" +
    "DPR. ";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // submitDonorDetails
            // 
            this.submitDonorDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.submitDonorDetails.Location = new System.Drawing.Point(701, 323);
            this.submitDonorDetails.Name = "submitDonorDetails";
            this.submitDonorDetails.Size = new System.Drawing.Size(75, 32);
            this.submitDonorDetails.TabIndex = 21;
            this.submitDonorDetails.Text = "Submit";
            this.submitDonorDetails.UseVisualStyleBackColor = true;
            this.submitDonorDetails.Click += new System.EventHandler(this.submitDonorDetails_Click);
            // 
            // MedicalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.submitDonorDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gpdrAgreeBox);
            this.Controls.Add(this.dobPicker);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEthnicity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNHSNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMedicalHistory);
            this.Controls.Add(this.txtRHFactor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBloodType);
            this.Name = "MedicalRecord";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBloodType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRHFactor;
        private System.Windows.Forms.TextBox txtMedicalHistory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNHSNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEthnicity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dobPicker;
        private System.Windows.Forms.CheckBox gpdrAgreeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitDonorDetails;
    }
}