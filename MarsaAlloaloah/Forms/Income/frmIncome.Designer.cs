using System;

namespace MarsaAlloaloah
{
    partial class frmIncome
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListIncome = new System.Windows.Forms.DataGridView();
            this.cmbIncomeType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIncomeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.AmountAfterVAT = new System.Windows.Forms.Label();
            this.lblAmountAfterVAT = new System.Windows.Forms.Label();
            this.VAT = new System.Windows.Forms.Label();
            this.LblVAT = new System.Windows.Forms.Label();
            this.txtIncomeAmount = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.chboxIsVAT = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.Btnprint = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Custname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QRPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListIncome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRPic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(396, 158);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 257;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Salmon;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(304, 158);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 256;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(120, 158);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 254;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(212, 158);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 255;
            this.btnClear.Text = "مسح";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(390, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 29);
            this.label2.TabIndex = 253;
            this.label2.Text = "نوع الإيراد:";
            // 
            // dgvListIncome
            // 
            this.dgvListIncome.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListIncome.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column6,
            this.Custname});
            this.dgvListIncome.Location = new System.Drawing.Point(12, 210);
            this.dgvListIncome.Name = "dgvListIncome";
            this.dgvListIncome.Size = new System.Drawing.Size(714, 266);
            this.dgvListIncome.TabIndex = 249;
            this.dgvListIncome.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListIncome_CellDoubleClick);
            // 
            // cmbIncomeType
            // 
            this.cmbIncomeType.FormattingEnabled = true;
            this.cmbIncomeType.Location = new System.Drawing.Point(467, 21);
            this.cmbIncomeType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbIncomeType.Name = "cmbIncomeType";
            this.cmbIncomeType.Size = new System.Drawing.Size(242, 21);
            this.cmbIncomeType.TabIndex = 258;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 29);
            this.label3.TabIndex = 260;
            this.label3.Text = "إسم الإيراد:";
            // 
            // txtIncomeName
            // 
            this.txtIncomeName.Location = new System.Drawing.Point(123, 21);
            this.txtIncomeName.Name = "txtIncomeName";
            this.txtIncomeName.Size = new System.Drawing.Size(256, 20);
            this.txtIncomeName.TabIndex = 259;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 29);
            this.label4.TabIndex = 261;
            this.label4.Text = "بيان الإيراد:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(124, 51);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(255, 20);
            this.txtDescription.TabIndex = 262;
            // 
            // AmountAfterVAT
            // 
            this.AmountAfterVAT.AutoSize = true;
            this.AmountAfterVAT.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountAfterVAT.Location = new System.Drawing.Point(589, 114);
            this.AmountAfterVAT.Name = "AmountAfterVAT";
            this.AmountAfterVAT.Size = new System.Drawing.Size(36, 17);
            this.AmountAfterVAT.TabIndex = 295;
            this.AmountAfterVAT.Text = "0.00";
            // 
            // lblAmountAfterVAT
            // 
            this.lblAmountAfterVAT.AutoSize = true;
            this.lblAmountAfterVAT.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountAfterVAT.Location = new System.Drawing.Point(454, 108);
            this.lblAmountAfterVAT.Name = "lblAmountAfterVAT";
            this.lblAmountAfterVAT.Size = new System.Drawing.Size(107, 29);
            this.lblAmountAfterVAT.TabIndex = 294;
            this.lblAmountAfterVAT.Text = "المبلغ بعد الضريبة";
            // 
            // VAT
            // 
            this.VAT.AutoSize = true;
            this.VAT.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VAT.Location = new System.Drawing.Point(393, 114);
            this.VAT.Name = "VAT";
            this.VAT.Size = new System.Drawing.Size(36, 17);
            this.VAT.TabIndex = 293;
            this.VAT.Text = "0.00";
            // 
            // LblVAT
            // 
            this.LblVAT.AutoSize = true;
            this.LblVAT.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVAT.Location = new System.Drawing.Point(261, 108);
            this.LblVAT.Name = "LblVAT";
            this.LblVAT.Size = new System.Drawing.Size(121, 29);
            this.LblVAT.TabIndex = 292;
            this.LblVAT.Text = "قيمة الضريبة المضافة";
            // 
            // txtIncomeAmount
            // 
            this.txtIncomeAmount.DecimalPlaces = 2;
            this.txtIncomeAmount.DecimalsSeparator = '.';
            this.txtIncomeAmount.Location = new System.Drawing.Point(123, 79);
            this.txtIncomeAmount.Name = "txtIncomeAmount";
            this.txtIncomeAmount.PreFix = null;
            this.txtIncomeAmount.Size = new System.Drawing.Size(207, 20);
            this.txtIncomeAmount.TabIndex = 291;
            this.txtIncomeAmount.ThousandsSeparator = ' ';
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 29);
            this.label9.TabIndex = 290;
            this.label9.Text = "المبلغ:";
            // 
            // chboxIsVAT
            // 
            this.chboxIsVAT.AutoSize = true;
            this.chboxIsVAT.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxIsVAT.Location = new System.Drawing.Point(123, 106);
            this.chboxIsVAT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chboxIsVAT.Name = "chboxIsVAT";
            this.chboxIsVAT.Size = new System.Drawing.Size(99, 33);
            this.chboxIsVAT.TabIndex = 296;
            this.chboxIsVAT.Text = "فاتورة ضريبية";
            this.chboxIsVAT.UseVisualStyleBackColor = true;
            this.chboxIsVAT.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(390, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 29);
            this.label7.TabIndex = 297;
            this.label7.Text = "التاريخ:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(467, 48);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(242, 20);
            this.dtpDate.TabIndex = 298;
            // 
            // Btnprint
            // 
            this.Btnprint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Btnprint.FlatAppearance.BorderSize = 0;
            this.Btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnprint.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnprint.ForeColor = System.Drawing.Color.Black;
            this.Btnprint.Location = new System.Drawing.Point(491, 158);
            this.Btnprint.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Btnprint.Name = "Btnprint";
            this.Btnprint.Size = new System.Drawing.Size(85, 30);
            this.Btnprint.TabIndex = 299;
            this.Btnprint.Text = "طباعة";
            this.Btnprint.UseVisualStyleBackColor = false;
            this.Btnprint.Click += new System.EventHandler(this.Btnprint_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(467, 80);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(242, 21);
            this.comboBox1.TabIndex = 301;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(390, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 29);
            this.label1.TabIndex = 300;
            this.label1.Text = "العميل :";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "رقم تسلسلي";
            this.Column1.Name = "Column1";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Date";
            this.Column8.HeaderText = "التاريخ";
            this.Column8.Name = "Column8";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "IncomeName";
            this.Column3.HeaderText = "إسم الإيراد";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "نوع الإيراد";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Description";
            this.Column4.HeaderText = "بيان الإيراد";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Amount";
            this.Column5.HeaderText = "المبلغ";
            this.Column5.Name = "Column5";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "VAT";
            this.Column7.HeaderText = "الضريبة المضافة";
            this.Column7.Name = "Column7";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "AmountAfterVAT";
            this.Column6.HeaderText = "المبلغ بعد الضريبة";
            this.Column6.Name = "Column6";
            // 
            // Custname
            // 
            this.Custname.DataPropertyName = "Custname";
            this.Custname.HeaderText = "العميل";
            this.Custname.Name = "Custname";
            // 
            // QRPic
            // 
            this.QRPic.Location = new System.Drawing.Point(12, 114);
            this.QRPic.Name = "QRPic";
            this.QRPic.Size = new System.Drawing.Size(100, 92);
            this.QRPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QRPic.TabIndex = 302;
            this.QRPic.TabStop = false;
            this.QRPic.Visible = false;
            // 
            // frmIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 497);
            this.Controls.Add(this.QRPic);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btnprint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.chboxIsVAT);
            this.Controls.Add(this.AmountAfterVAT);
            this.Controls.Add(this.lblAmountAfterVAT);
            this.Controls.Add(this.VAT);
            this.Controls.Add(this.LblVAT);
            this.Controls.Add(this.txtIncomeAmount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIncomeName);
            this.Controls.Add(this.cmbIncomeType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListIncome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmIncome";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الإيرادات";
            this.Load += new System.EventHandler(this.frmIncome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvListIncome;
        private System.Windows.Forms.ComboBox cmbIncomeType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIncomeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label AmountAfterVAT;
        private System.Windows.Forms.Label lblAmountAfterVAT;
        private System.Windows.Forms.Label VAT;
        private System.Windows.Forms.Label LblVAT;
        private JRINCCustomControls.CurrencyTextBox txtIncomeAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chboxIsVAT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button Btnprint;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Custname;
        private System.Windows.Forms.PictureBox QRPic;
    }
}