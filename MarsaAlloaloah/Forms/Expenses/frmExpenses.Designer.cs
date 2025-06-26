namespace MarsaAlloaloah
{
    partial class frmExpenses
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
            this.txtSeaTransportID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExpensesName = new System.Windows.Forms.TextBox();
            this.cmbExpensesType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListExpenses = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtExpensesAmount = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.LblVAT = new System.Windows.Forms.Label();
            this.VAT = new System.Windows.Forms.Label();
            this.AmountAfterVAT = new System.Windows.Forms.Label();
            this.lblAmountAfterVAT = new System.Windows.Forms.Label();
            this.chboxIsVAT = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSeaTransportID
            // 
            this.txtSeaTransportID.Location = new System.Drawing.Point(140, 54);
            this.txtSeaTransportID.Name = "txtSeaTransportID";
            this.txtSeaTransportID.Size = new System.Drawing.Size(256, 20);
            this.txtSeaTransportID.TabIndex = 275;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 29);
            this.label4.TabIndex = 274;
            this.label4.Text = "رقم الواسطة البحرية:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 29);
            this.label3.TabIndex = 273;
            this.label3.Text = "إسم المصروف:";
            // 
            // txtExpensesName
            // 
            this.txtExpensesName.Location = new System.Drawing.Point(140, 16);
            this.txtExpensesName.Name = "txtExpensesName";
            this.txtExpensesName.Size = new System.Drawing.Size(256, 20);
            this.txtExpensesName.TabIndex = 272;
            // 
            // cmbExpensesType
            // 
            this.cmbExpensesType.FormattingEnabled = true;
            this.cmbExpensesType.Items.AddRange(new object[] {
            "يومى ",
            "صيانة قوارب",
            "علاج ",
            "أخرى"});
            this.cmbExpensesType.Location = new System.Drawing.Point(499, 16);
            this.cmbExpensesType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbExpensesType.Name = "cmbExpensesType";
            this.cmbExpensesType.Size = new System.Drawing.Size(256, 21);
            this.cmbExpensesType.TabIndex = 271;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(462, 174);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 270;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Salmon;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(370, 174);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 269;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(186, 174);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 267;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(278, 174);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 268;
            this.btnClear.Text = "مسح";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(406, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 29);
            this.label2.TabIndex = 266;
            this.label2.Text = "نوع المصروف:";
            // 
            // dgvListExpenses
            // 
            this.dgvListExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvListExpenses.Location = new System.Drawing.Point(12, 216);
            this.dgvListExpenses.Name = "dgvListExpenses";
            this.dgvListExpenses.Size = new System.Drawing.Size(747, 230);
            this.dgvListExpenses.TabIndex = 263;
            this.dgvListExpenses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListExpenses_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "رقم تسلسلي";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ExpensesName";
            this.Column3.HeaderText = "إسم المصروف";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ExpensesType";
            this.Column2.HeaderText = "نوع المصروف";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SeaTransportID";
            this.Column4.HeaderText = "رقم القارب";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "amount";
            this.Column5.HeaderText = "المبلغ";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "VAT";
            this.Column6.HeaderText = "الضريبة المضافة";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "AmountAfterVAT";
            this.Column7.HeaderText = "المبلغ بعد الضريبة";
            this.Column7.Name = "Column7";
            // 
            // txtExpensesAmount
            // 
            this.txtExpensesAmount.DecimalPlaces = 2;
            this.txtExpensesAmount.DecimalsSeparator = '.';
            this.txtExpensesAmount.Location = new System.Drawing.Point(140, 90);
            this.txtExpensesAmount.Name = "txtExpensesAmount";
            this.txtExpensesAmount.PreFix = null;
            this.txtExpensesAmount.Size = new System.Drawing.Size(177, 20);
            this.txtExpensesAmount.TabIndex = 285;
            this.txtExpensesAmount.ThousandsSeparator = ' ';
            this.txtExpensesAmount.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 29);
            this.label6.TabIndex = 284;
            this.label6.Text = "المبلغ:";
            // 
            // LblVAT
            // 
            this.LblVAT.AutoSize = true;
            this.LblVAT.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVAT.Location = new System.Drawing.Point(275, 121);
            this.LblVAT.Name = "LblVAT";
            this.LblVAT.Size = new System.Drawing.Size(131, 29);
            this.LblVAT.TabIndex = 286;
            this.LblVAT.Text = "قيمة الضريبة المضافة:";
            // 
            // VAT
            // 
            this.VAT.AutoSize = true;
            this.VAT.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VAT.Location = new System.Drawing.Point(412, 127);
            this.VAT.Name = "VAT";
            this.VAT.Size = new System.Drawing.Size(36, 17);
            this.VAT.TabIndex = 287;
            this.VAT.Text = "0.00";
            // 
            // AmountAfterVAT
            // 
            this.AmountAfterVAT.AutoSize = true;
            this.AmountAfterVAT.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountAfterVAT.Location = new System.Drawing.Point(615, 127);
            this.AmountAfterVAT.Name = "AmountAfterVAT";
            this.AmountAfterVAT.Size = new System.Drawing.Size(36, 17);
            this.AmountAfterVAT.TabIndex = 289;
            this.AmountAfterVAT.Text = "0.00";
            // 
            // lblAmountAfterVAT
            // 
            this.lblAmountAfterVAT.AutoSize = true;
            this.lblAmountAfterVAT.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountAfterVAT.Location = new System.Drawing.Point(492, 121);
            this.lblAmountAfterVAT.Name = "lblAmountAfterVAT";
            this.lblAmountAfterVAT.Size = new System.Drawing.Size(117, 29);
            this.lblAmountAfterVAT.TabIndex = 288;
            this.lblAmountAfterVAT.Text = "المبلغ بعد الضريبة:";
            // 
            // chboxIsVAT
            // 
            this.chboxIsVAT.AutoSize = true;
            this.chboxIsVAT.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxIsVAT.Location = new System.Drawing.Point(140, 120);
            this.chboxIsVAT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chboxIsVAT.Name = "chboxIsVAT";
            this.chboxIsVAT.Size = new System.Drawing.Size(99, 33);
            this.chboxIsVAT.TabIndex = 290;
            this.chboxIsVAT.Text = "فاتورة ضريبية";
            this.chboxIsVAT.UseVisualStyleBackColor = true;
            this.chboxIsVAT.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(410, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 29);
            this.label7.TabIndex = 299;
            this.label7.Text = "التاريخ:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(499, 90);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(256, 20);
            this.dtpDate.TabIndex = 300;
            // 
            // frmExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 457);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.chboxIsVAT);
            this.Controls.Add(this.AmountAfterVAT);
            this.Controls.Add(this.lblAmountAfterVAT);
            this.Controls.Add(this.VAT);
            this.Controls.Add(this.LblVAT);
            this.Controls.Add(this.txtExpensesAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSeaTransportID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExpensesName);
            this.Controls.Add(this.cmbExpensesType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListExpenses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmExpenses";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المصروفات";
            this.Load += new System.EventHandler(this.frmExpenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListExpenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSeaTransportID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExpensesName;
        private System.Windows.Forms.ComboBox cmbExpensesType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvListExpenses;
        private JRINCCustomControls.CurrencyTextBox txtExpensesAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblVAT;
        private System.Windows.Forms.Label VAT;
        private System.Windows.Forms.Label AmountAfterVAT;
        private System.Windows.Forms.Label lblAmountAfterVAT;
        private System.Windows.Forms.CheckBox chboxIsVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}