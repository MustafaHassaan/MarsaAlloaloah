namespace MarsaAlloaloah
{
    partial class frmTransferTreasuryToBank
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAmountTransfert = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTreasury = new System.Windows.Forms.ComboBox();
            this.cmbBankAccount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(253, 157);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 255;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(158, 157);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 254;
            this.btnSave.Text = "تحويل";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAmountTransfert
            // 
            this.txtAmountTransfert.DecimalPlaces = 2;
            this.txtAmountTransfert.DecimalsSeparator = '.';
            this.txtAmountTransfert.Location = new System.Drawing.Point(138, 95);
            this.txtAmountTransfert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAmountTransfert.Name = "txtAmountTransfert";
            this.txtAmountTransfert.PreFix = null;
            this.txtAmountTransfert.Size = new System.Drawing.Size(204, 20);
            this.txtAmountTransfert.TabIndex = 253;
            this.txtAmountTransfert.ThousandsSeparator = ' ';
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 29);
            this.label3.TabIndex = 252;
            this.label3.Text = "المبلغ:";
            // 
            // cmbTreasury
            // 
            this.cmbTreasury.FormattingEnabled = true;
            this.cmbTreasury.Location = new System.Drawing.Point(138, 24);
            this.cmbTreasury.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTreasury.Name = "cmbTreasury";
            this.cmbTreasury.Size = new System.Drawing.Size(310, 21);
            this.cmbTreasury.TabIndex = 251;
            // 
            // cmbBankAccount
            // 
            this.cmbBankAccount.FormattingEnabled = true;
            this.cmbBankAccount.Location = new System.Drawing.Point(138, 60);
            this.cmbBankAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBankAccount.Name = "cmbBankAccount";
            this.cmbBankAccount.Size = new System.Drawing.Size(310, 21);
            this.cmbBankAccount.TabIndex = 250;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 56);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(103, 29);
            this.label2.TabIndex = 249;
            this.label2.Text = "الحساب البنكي:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 29);
            this.label4.TabIndex = 248;
            this.label4.Text = "الخزينة:";
            // 
            // frmTransferTreasuryToBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 222);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAmountTransfert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTreasury);
            this.Controls.Add(this.cmbBankAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTransferTreasuryToBank";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تحويل الأموال - من الخزينة إلى الحساب البنكي";
            this.Load += new System.EventHandler(this.frmTransferTreasuryToBank_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private JRINCCustomControls.CurrencyTextBox txtAmountTransfert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTreasury;
        private System.Windows.Forms.ComboBox cmbBankAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}