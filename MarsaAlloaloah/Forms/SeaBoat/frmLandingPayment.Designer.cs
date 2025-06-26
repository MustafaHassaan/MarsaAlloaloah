namespace MarsaAlloaloah
{
    partial class frmLandingPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpContractStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpContractEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTypeID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSeaTransportID = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtref = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.CmdPay = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtpaytamara = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtpaytrans = new System.Windows.Forms.TextBox();
            this.QRPic = new System.Windows.Forms.PictureBox();
            this.dtpEndDateTransaction = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDateTransaction = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.cmbBankAccount = new System.Windows.Forms.ComboBox();
            this.lblTotalCashAndBank = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpaycard = new System.Windows.Forms.TextBox();
            this.txtpaycash = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpPaymentDoneToDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.card = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paytranse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paytamara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payreftamara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRPic)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(331, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "تاريخ بداية الإرساء:";
            // 
            // dtpContractStartDate
            // 
            this.dtpContractStartDate.Enabled = false;
            this.dtpContractStartDate.Location = new System.Drawing.Point(92, 21);
            this.dtpContractStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpContractStartDate.Name = "dtpContractStartDate";
            this.dtpContractStartDate.Size = new System.Drawing.Size(234, 20);
            this.dtpContractStartDate.TabIndex = 3;
            // 
            // dtpContractEndDate
            // 
            this.dtpContractEndDate.Location = new System.Drawing.Point(92, 54);
            this.dtpContractEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpContractEndDate.Name = "dtpContractEndDate";
            this.dtpContractEndDate.Size = new System.Drawing.Size(234, 20);
            this.dtpContractEndDate.TabIndex = 5;
            this.dtpContractEndDate.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "تاريخ نهاية الإرساء:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(541, 374);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 275;
            this.button1.Text = "إغلاق";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Salmon;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(355, 374);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 274;
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
            this.btnSave.Location = new System.Drawing.Point(169, 374);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 272;
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
            this.btnClear.Location = new System.Drawing.Point(262, 374);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 273;
            this.btnClear.Text = "مسح";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvdata
            // 
            this.dgvdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.card,
            this.cash,
            this.Paytranse,
            this.Paytamara,
            this.Column4,
            this.Column2,
            this.Payreftamara,
            this.Column5,
            this.Column3});
            this.dgvdata.Location = new System.Drawing.Point(12, 415);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.Size = new System.Drawing.Size(772, 193);
            this.dgvdata.TabIndex = 271;
            this.dgvdata.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(632, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 29);
            this.label5.TabIndex = 278;
            this.label5.Text = "نوع الواسطة البحرية:";
            // 
            // cmbTypeID
            // 
            this.cmbTypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbTypeID.FormattingEnabled = true;
            this.cmbTypeID.Location = new System.Drawing.Point(456, 21);
            this.cmbTypeID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTypeID.Name = "cmbTypeID";
            this.cmbTypeID.Size = new System.Drawing.Size(172, 21);
            this.cmbTypeID.TabIndex = 276;
            this.cmbTypeID.SelectedIndexChanged += new System.EventHandler(this.cmbTypeID_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(654, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 29);
            this.label6.TabIndex = 279;
            this.label6.Text = "الواسطة البحرية:";
            // 
            // cmbSeaTransportID
            // 
            this.cmbSeaTransportID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbSeaTransportID.FormattingEnabled = true;
            this.cmbSeaTransportID.Location = new System.Drawing.Point(456, 53);
            this.cmbSeaTransportID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSeaTransportID.Name = "cmbSeaTransportID";
            this.cmbSeaTransportID.Size = new System.Drawing.Size(172, 21);
            this.cmbSeaTransportID.TabIndex = 277;
            this.cmbSeaTransportID.SelectedIndexChanged += new System.EventHandler(this.cmbSeaTransportID_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.txtref);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.CmdPay);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtpaytamara);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtpaytrans);
            this.groupBox2.Controls.Add(this.QRPic);
            this.groupBox2.Controls.Add(this.dtpEndDateTransaction);
            this.groupBox2.Controls.Add(this.dtpStartDateTransaction);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dtpDate);
            this.groupBox2.Controls.Add(this.lblBankAccount);
            this.groupBox2.Controls.Add(this.cmbBankAccount);
            this.groupBox2.Controls.Add(this.lblTotalCashAndBank);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtpaycard);
            this.groupBox2.Controls.Add(this.txtpaycash);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(772, 223);
            this.groupBox2.TabIndex = 282;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "طريقة الدفع";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(208, 180);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(76, 29);
            this.label32.TabIndex = 295;
            this.label32.Text = "رقم المرجع :";
            this.label32.Visible = false;
            // 
            // txtref
            // 
            this.txtref.Location = new System.Drawing.Point(6, 185);
            this.txtref.Name = "txtref";
            this.txtref.Size = new System.Drawing.Size(196, 20);
            this.txtref.TabIndex = 294;
            this.txtref.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(660, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 29);
            this.label13.TabIndex = 293;
            this.label13.Text = "الدفع بواسطة :";
            // 
            // CmdPay
            // 
            this.CmdPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CmdPay.FormattingEnabled = true;
            this.CmdPay.Items.AddRange(new object[] {
            "نقدي",
            "بنكي",
            "تحويل بنكي",
            "تمارا",
            "نقدي وبنكي",
            "نقدي وتحويل",
            "تمارا ونقدي",
            "بنكي وتحويل",
            "نقدي وبنكي وتحويل",
            "تمارا وبنكي",
            "تمارا وتحويل",
            "تمارا ونقدي وبنكي",
            "تمارا ونقدي وبنكي وتحويل"});
            this.CmdPay.Location = new System.Drawing.Point(439, 55);
            this.CmdPay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmdPay.Name = "CmdPay";
            this.CmdPay.Size = new System.Drawing.Size(219, 21);
            this.CmdPay.TabIndex = 292;
            this.CmdPay.SelectedIndexChanged += new System.EventHandler(this.CmdPay_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(713, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 29);
            this.label12.TabIndex = 291;
            this.label12.Text = "تمارا :";
            this.label12.Visible = false;
            // 
            // txtpaytamara
            // 
            this.txtpaytamara.Location = new System.Drawing.Point(549, 185);
            this.txtpaytamara.Name = "txtpaytamara";
            this.txtpaytamara.Size = new System.Drawing.Size(108, 20);
            this.txtpaytamara.TabIndex = 290;
            this.txtpaytamara.Visible = false;
            this.txtpaytamara.TextChanged += new System.EventHandler(this.txtpaytamara_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(673, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 29);
            this.label11.TabIndex = 289;
            this.label11.Text = "تحويل بنكي :";
            this.label11.Visible = false;
            // 
            // txtpaytrans
            // 
            this.txtpaytrans.Location = new System.Drawing.Point(549, 152);
            this.txtpaytrans.Name = "txtpaytrans";
            this.txtpaytrans.Size = new System.Drawing.Size(108, 20);
            this.txtpaytrans.TabIndex = 288;
            this.txtpaytrans.Visible = false;
            this.txtpaytrans.TextChanged += new System.EventHandler(this.txtpaytrans_TextChanged);
            // 
            // QRPic
            // 
            this.QRPic.Location = new System.Drawing.Point(6, 18);
            this.QRPic.Name = "QRPic";
            this.QRPic.Size = new System.Drawing.Size(122, 126);
            this.QRPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QRPic.TabIndex = 287;
            this.QRPic.TabStop = false;
            this.QRPic.Visible = false;
            // 
            // dtpEndDateTransaction
            // 
            this.dtpEndDateTransaction.Location = new System.Drawing.Point(154, 149);
            this.dtpEndDateTransaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEndDateTransaction.Name = "dtpEndDateTransaction";
            this.dtpEndDateTransaction.Size = new System.Drawing.Size(225, 20);
            this.dtpEndDateTransaction.TabIndex = 286;
            // 
            // dtpStartDateTransaction
            // 
            this.dtpStartDateTransaction.Enabled = false;
            this.dtpStartDateTransaction.Location = new System.Drawing.Point(154, 123);
            this.dtpStartDateTransaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartDateTransaction.Name = "dtpStartDateTransaction";
            this.dtpStartDateTransaction.Size = new System.Drawing.Size(225, 20);
            this.dtpStartDateTransaction.TabIndex = 282;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(384, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 29);
            this.label10.TabIndex = 285;
            this.label10.Text = "الى :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(384, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 29);
            this.label8.TabIndex = 284;
            this.label8.Text = "المدة الزمنية المدفوعة من :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(673, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 29);
            this.label7.TabIndex = 282;
            this.label7.Text = "تاريخ الدُفعة:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(439, 21);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(219, 20);
            this.dtpDate.TabIndex = 283;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankAccount.Location = new System.Drawing.Point(381, 88);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(98, 29);
            this.lblBankAccount.TabIndex = 242;
            this.lblBankAccount.Text = "الحساب البنكى:";
            // 
            // cmbBankAccount
            // 
            this.cmbBankAccount.FormattingEnabled = true;
            this.cmbBankAccount.Location = new System.Drawing.Point(154, 91);
            this.cmbBankAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBankAccount.Name = "cmbBankAccount";
            this.cmbBankAccount.Size = new System.Drawing.Size(225, 21);
            this.cmbBankAccount.TabIndex = 241;
            // 
            // lblTotalCashAndBank
            // 
            this.lblTotalCashAndBank.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblTotalCashAndBank.Location = new System.Drawing.Point(277, 183);
            this.lblTotalCashAndBank.Name = "lblTotalCashAndBank";
            this.lblTotalCashAndBank.Size = new System.Drawing.Size(100, 23);
            this.lblTotalCashAndBank.TabIndex = 240;
            this.lblTotalCashAndBank.Text = "0.00";
            this.lblTotalCashAndBank.TextChanged += new System.EventHandler(this.lblTotalCashAndBank_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(384, 180);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(91, 29);
            this.label22.TabIndex = 239;
            this.label22.Text = "إجمالى الدُفعة :";
            this.label22.Click += new System.EventHandler(this.label22_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(678, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 29);
            this.label15.TabIndex = 239;
            this.label15.Text = "بطاقة بنكية:";
            this.label15.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(715, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 29);
            this.label9.TabIndex = 239;
            this.label9.Text = "نقدا:";
            this.label9.Visible = false;
            // 
            // txtpaycard
            // 
            this.txtpaycard.Location = new System.Drawing.Point(550, 90);
            this.txtpaycard.Name = "txtpaycard";
            this.txtpaycard.Size = new System.Drawing.Size(108, 20);
            this.txtpaycard.TabIndex = 15;
            this.txtpaycard.Visible = false;
            this.txtpaycard.TextChanged += new System.EventHandler(this.txtpaycard_TextChanged);
            // 
            // txtpaycash
            // 
            this.txtpaycash.Location = new System.Drawing.Point(550, 120);
            this.txtpaycash.Name = "txtpaycash";
            this.txtpaycash.Size = new System.Drawing.Size(108, 20);
            this.txtpaycash.TabIndex = 14;
            this.txtpaycash.Visible = false;
            this.txtpaycash.TextChanged += new System.EventHandler(this.txtpaycash_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpPaymentDoneToDate);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpContractStartDate);
            this.groupBox1.Controls.Add(this.cmbTypeID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpContractEndDate);
            this.groupBox1.Controls.Add(this.cmbSeaTransportID);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(770, 123);
            this.groupBox1.TabIndex = 283;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات البحث";
            // 
            // dtpPaymentDoneToDate
            // 
            this.dtpPaymentDoneToDate.Enabled = false;
            this.dtpPaymentDoneToDate.Location = new System.Drawing.Point(92, 89);
            this.dtpPaymentDoneToDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpPaymentDoneToDate.Name = "dtpPaymentDoneToDate";
            this.dtpPaymentDoneToDate.Size = new System.Drawing.Size(234, 20);
            this.dtpPaymentDoneToDate.TabIndex = 242;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(511, 89);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(117, 20);
            this.txtAmount.TabIndex = 281;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(332, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 29);
            this.label1.TabIndex = 241;
            this.label1.Text = "قيمة الإرساء مدفوعة الى تاريخ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(674, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 29);
            this.label4.TabIndex = 280;
            this.label4.Text = "قيمة الإرساء:";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(448, 374);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 30);
            this.btnPrint.TabIndex = 290;
            this.btnPrint.Text = "طباعة  ";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "الواسطة البحرية";
            this.Column1.Name = "Column1";
            // 
            // card
            // 
            this.card.DataPropertyName = "PayCard";
            this.card.HeaderText = "قيمة الدفعة ـ بطاقة بنكية";
            this.card.Name = "card";
            // 
            // cash
            // 
            this.cash.DataPropertyName = "PayCash";
            this.cash.HeaderText = "قيمة الدفعة نقدا";
            this.cash.Name = "cash";
            // 
            // Paytranse
            // 
            this.Paytranse.DataPropertyName = "Paytranse";
            this.Paytranse.HeaderText = "قيمة التحويل البنكي";
            this.Paytranse.Name = "Paytranse";
            // 
            // Paytamara
            // 
            this.Paytamara.DataPropertyName = "Paytamara";
            this.Paytamara.HeaderText = "قيمة الدفع بواسطة تمارا";
            this.Paytamara.Name = "Paytamara";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "total";
            this.Column4.HeaderText = "إجمالي الدفعة";
            this.Column4.Name = "Column4";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Date";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "تاريخ  الدفعة ";
            this.Column2.Name = "Column2";
            // 
            // Payreftamara
            // 
            this.Payreftamara.DataPropertyName = "Payreftamara";
            this.Payreftamara.HeaderText = "رقم المرجع";
            this.Payreftamara.Name = "Payreftamara";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ID";
            this.Column5.HeaderText = "ID";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LandingID";
            this.Column3.HeaderText = "LandingID";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // frmLandingPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 620);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvdata);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmLandingPayment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دفوعات الإرساء";
            this.Load += new System.EventHandler(this.frmLandingPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRPic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpContractStartDate;
        private System.Windows.Forms.DateTimePicker dtpContractEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTypeID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSeaTransportID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalCashAndBank;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtpaycard;
        private System.Windows.Forms.TextBox txtpaycash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpPaymentDoneToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBankAccount;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpEndDateTransaction;
        private System.Windows.Forms.DateTimePicker dtpStartDateTransaction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox QRPic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtpaytamara;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtpaytrans;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CmdPay;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtref;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn card;
        private System.Windows.Forms.DataGridViewTextBoxColumn cash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paytranse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paytamara;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payreftamara;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}