using JRINCCustomControls;
namespace MarsaAlloaloah
{
    partial class frmEditTicket
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTicketNo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCustIDHidden = new System.Windows.Forms.Label();
            this.btnFrmCustomer = new System.Windows.Forms.Button();
            this.lblCustNotFound = new System.Windows.Forms.Label();
            this.txtCustNID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustMobile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTypeID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSeaTransportID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDuration = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDiscountPercent = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiscountValue = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblPriceAfterDiscount = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbDrivers = new System.Windows.Forms.ComboBox();
            this.cmbAddons = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtAddonQty = new System.Windows.Forms.TextBox();
            this.txtAddonPrice = new System.Windows.Forms.TextBox();
            this.btnAddAddon = new System.Windows.Forms.Button();
            this.btnRremoveAddon = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblAddonTotal = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lblTotalCashAndBank = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpaycard = new System.Windows.Forms.TextBox();
            this.txtpaycash = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearchDriverByID = new System.Windows.Forms.TextBox();
            this.txtSearchBoatByID = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbCompanyDiscount = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.lblVAT = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.lblTotalAfterVAT = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvAddons = new System.Windows.Forms.DataGridView();
            this.tiad_Addons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_addons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Addons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_addons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAddonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QRPic = new System.Windows.Forms.PictureBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Btnchangetot = new System.Windows.Forms.Button();
            this.txtchangetot = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.transpay = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddons)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRPic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 29);
            this.label1.TabIndex = 208;
            this.label1.Text = "رقم التذكرة:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTicketNo
            // 
            this.txtTicketNo.Enabled = false;
            this.txtTicketNo.Location = new System.Drawing.Point(171, 13);
            this.txtTicketNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTicketNo.Name = "txtTicketNo";
            this.txtTicketNo.Size = new System.Drawing.Size(147, 20);
            this.txtTicketNo.TabIndex = 224;
            this.txtTicketNo.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCustIDHidden);
            this.groupBox1.Controls.Add(this.btnFrmCustomer);
            this.groupBox1.Controls.Add(this.lblCustNotFound);
            this.groupBox1.Controls.Add(this.txtCustNID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCustName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCustMobile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(64, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(432, 132);
            this.groupBox1.TabIndex = 225;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات العميل";
            // 
            // lblCustIDHidden
            // 
            this.lblCustIDHidden.AutoSize = true;
            this.lblCustIDHidden.ForeColor = System.Drawing.Color.Maroon;
            this.lblCustIDHidden.Location = new System.Drawing.Point(247, 44);
            this.lblCustIDHidden.Name = "lblCustIDHidden";
            this.lblCustIDHidden.Size = new System.Drawing.Size(0, 13);
            this.lblCustIDHidden.TabIndex = 227;
            this.lblCustIDHidden.Visible = false;
            // 
            // btnFrmCustomer
            // 
            this.btnFrmCustomer.Location = new System.Drawing.Point(10, 24);
            this.btnFrmCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFrmCustomer.Name = "btnFrmCustomer";
            this.btnFrmCustomer.Size = new System.Drawing.Size(22, 20);
            this.btnFrmCustomer.TabIndex = 226;
            this.btnFrmCustomer.Text = "+";
            this.btnFrmCustomer.UseVisualStyleBackColor = true;
            this.btnFrmCustomer.Click += new System.EventHandler(this.btnFrmCustomer_Click);
            // 
            // lblCustNotFound
            // 
            this.lblCustNotFound.AutoSize = true;
            this.lblCustNotFound.ForeColor = System.Drawing.Color.Maroon;
            this.lblCustNotFound.Location = new System.Drawing.Point(53, 83);
            this.lblCustNotFound.Name = "lblCustNotFound";
            this.lblCustNotFound.Size = new System.Drawing.Size(251, 13);
            this.lblCustNotFound.TabIndex = 225;
            this.lblCustNotFound.Text = "من فضلك تأكد من رقم الهوية أو قم بإضافة عميل جديد";
            this.lblCustNotFound.Visible = false;
            // 
            // txtCustNID
            // 
            this.txtCustNID.Location = new System.Drawing.Point(37, 62);
            this.txtCustNID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustNID.Name = "txtCustNID";
            this.txtCustNID.Size = new System.Drawing.Size(289, 20);
            this.txtCustNID.TabIndex = 1;
            this.txtCustNID.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.txtCustNID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustNID_KeyDown);
            this.txtCustNID.Leave += new System.EventHandler(this.txtCustNID_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(356, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 29);
            this.label4.TabIndex = 208;
            this.label4.Text = "رقم الهوية:";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(37, 99);
            this.txtCustName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(289, 20);
            this.txtCustName.TabIndex = 2;
            this.txtCustName.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.txtCustName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(379, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 29);
            this.label2.TabIndex = 208;
            this.label2.Text = "الإسم:";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCustMobile
            // 
            this.txtCustMobile.Location = new System.Drawing.Point(37, 25);
            this.txtCustMobile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustMobile.Name = "txtCustMobile";
            this.txtCustMobile.Size = new System.Drawing.Size(289, 20);
            this.txtCustMobile.TabIndex = 0;
            this.txtCustMobile.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.txtCustMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustMobile_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(350, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 29);
            this.label3.TabIndex = 208;
            this.label3.Text = "رقم الجوال:";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbTypeID
            // 
            this.cmbTypeID.FormattingEnabled = true;
            this.cmbTypeID.Location = new System.Drawing.Point(48, 44);
            this.cmbTypeID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTypeID.Name = "cmbTypeID";
            this.cmbTypeID.Size = new System.Drawing.Size(285, 21);
            this.cmbTypeID.TabIndex = 5;
            this.cmbTypeID.SelectedIndexChanged += new System.EventHandler(this.cmbTypeID_SelectedIndexChanged);
            this.cmbTypeID.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeID_SelectionChangeCommitted);
            this.cmbTypeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTypeID_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(337, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 29);
            this.label5.TabIndex = 228;
            this.label5.Text = "نوع الواسطة البحرية:";
            // 
            // cmbSeaTransportID
            // 
            this.cmbSeaTransportID.FormattingEnabled = true;
            this.cmbSeaTransportID.Location = new System.Drawing.Point(48, 74);
            this.cmbSeaTransportID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSeaTransportID.Name = "cmbSeaTransportID";
            this.cmbSeaTransportID.Size = new System.Drawing.Size(222, 21);
            this.cmbSeaTransportID.TabIndex = 6;
            this.cmbSeaTransportID.SelectedIndexChanged += new System.EventHandler(this.cmbSeaTransportID_SelectedIndexChanged);
            this.cmbSeaTransportID.DropDownClosed += new System.EventHandler(this.cmbSeaTransportID_DropDownClosed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(359, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 29);
            this.label6.TabIndex = 230;
            this.label6.Text = "الواسطة البحرية:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(376, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 29);
            this.label7.TabIndex = 230;
            this.label7.Text = "المدة الزمنية:";
            // 
            // cmbDuration
            // 
            this.cmbDuration.FormattingEnabled = true;
            this.cmbDuration.Location = new System.Drawing.Point(48, 129);
            this.cmbDuration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDuration.Name = "cmbDuration";
            this.cmbDuration.Size = new System.Drawing.Size(285, 21);
            this.cmbDuration.TabIndex = 8;
            this.cmbDuration.SelectionChangeCommitted += new System.EventHandler(this.cmbDuration_SelectionChangeCommitted);
            this.cmbDuration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDuration_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(410, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 29);
            this.label8.TabIndex = 230;
            this.label8.Text = "السعر:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(261, 218);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(39, 17);
            this.lblPrice.TabIndex = 234;
            this.lblPrice.Text = "0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(406, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 29);
            this.label10.TabIndex = 230;
            this.label10.Text = "السائق:";
            // 
            // txtDiscountPercent
            // 
            this.txtDiscountPercent.Enabled = false;
            this.txtDiscountPercent.Location = new System.Drawing.Point(66, 181);
            this.txtDiscountPercent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountPercent.Name = "txtDiscountPercent";
            this.txtDiscountPercent.Size = new System.Drawing.Size(91, 20);
            this.txtDiscountPercent.TabIndex = 10;
            this.txtDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiscountPercent.TextChanged += new System.EventHandler(this.txtDiscountPercent_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(377, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 29);
            this.label12.TabIndex = 235;
            this.label12.Text = "قيمة الخصم:";
            // 
            // txtDiscountValue
            // 
            this.txtDiscountValue.Enabled = false;
            this.txtDiscountValue.Location = new System.Drawing.Point(251, 181);
            this.txtDiscountValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountValue.Name = "txtDiscountValue";
            this.txtDiscountValue.Size = new System.Drawing.Size(82, 20);
            this.txtDiscountValue.TabIndex = 9;
            this.txtDiscountValue.TextChanged += new System.EventHandler(this.txtDiscountValue_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 185);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 235;
            this.label13.Text = "%";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(348, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 29);
            this.label14.TabIndex = 208;
            this.label14.Text = "وقت بداية الرحلة:";
            this.label14.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(155, 20);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpStartDate.RightToLeftLayout = true;
            this.dtpStartDate.Size = new System.Drawing.Size(178, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(48, 20);
            this.dtpStartTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(103, 20);
            this.dtpStartTime.TabIndex = 4;
            // 
            // lblPriceAfterDiscount
            // 
            this.lblPriceAfterDiscount.AutoSize = true;
            this.lblPriceAfterDiscount.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblPriceAfterDiscount.Location = new System.Drawing.Point(261, 244);
            this.lblPriceAfterDiscount.Name = "lblPriceAfterDiscount";
            this.lblPriceAfterDiscount.Size = new System.Drawing.Size(39, 17);
            this.lblPriceAfterDiscount.TabIndex = 240;
            this.lblPriceAfterDiscount.Text = "0.00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(344, 239);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 29);
            this.label16.TabIndex = 239;
            this.label16.Text = "السعر بعد الخصم:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(609, 474);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 244;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(419, 474);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 241;
            this.btnSave.Text = "تحديث";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbDrivers
            // 
            this.cmbDrivers.FormattingEnabled = true;
            this.cmbDrivers.Location = new System.Drawing.Point(48, 102);
            this.cmbDrivers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDrivers.Name = "cmbDrivers";
            this.cmbDrivers.Size = new System.Drawing.Size(222, 21);
            this.cmbDrivers.TabIndex = 7;
            this.cmbDrivers.SelectedIndexChanged += new System.EventHandler(this.cmbDrivers_SelectedIndexChanged);
            this.cmbDrivers.SelectedValueChanged += new System.EventHandler(this.cmbDrivers_SelectedValueChanged);
            // 
            // cmbAddons
            // 
            this.cmbAddons.FormattingEnabled = true;
            this.cmbAddons.Location = new System.Drawing.Point(128, 20);
            this.cmbAddons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAddons.Name = "cmbAddons";
            this.cmbAddons.Size = new System.Drawing.Size(206, 21);
            this.cmbAddons.TabIndex = 11;
            this.cmbAddons.SelectedIndexChanged += new System.EventHandler(this.cmbAddons_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(340, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 29);
            this.label17.TabIndex = 247;
            this.label17.Text = "إسم الإضافة:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(372, 47);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 29);
            this.label18.TabIndex = 248;
            this.label18.Text = "الكمية:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(211, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 24);
            this.label19.TabIndex = 249;
            this.label19.Text = "السعر:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(189, 196);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 29);
            this.label20.TabIndex = 250;
            this.label20.Text = "الاجمالي للاضافات:";
            // 
            // txtAddonQty
            // 
            this.txtAddonQty.Location = new System.Drawing.Point(257, 51);
            this.txtAddonQty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddonQty.Name = "txtAddonQty";
            this.txtAddonQty.Size = new System.Drawing.Size(77, 20);
            this.txtAddonQty.TabIndex = 12;
            // 
            // txtAddonPrice
            // 
            this.txtAddonPrice.Location = new System.Drawing.Point(128, 51);
            this.txtAddonPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddonPrice.Name = "txtAddonPrice";
            this.txtAddonPrice.Size = new System.Drawing.Size(77, 20);
            this.txtAddonPrice.TabIndex = 13;
            // 
            // btnAddAddon
            // 
            this.btnAddAddon.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAddon.Location = new System.Drawing.Point(65, 28);
            this.btnAddAddon.Name = "btnAddAddon";
            this.btnAddAddon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddAddon.Size = new System.Drawing.Size(37, 30);
            this.btnAddAddon.TabIndex = 254;
            this.btnAddAddon.Text = "+";
            this.btnAddAddon.UseVisualStyleBackColor = true;
            this.btnAddAddon.Click += new System.EventHandler(this.btnAddAddon_Click);
            // 
            // btnRremoveAddon
            // 
            this.btnRremoveAddon.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRremoveAddon.Location = new System.Drawing.Point(6, 81);
            this.btnRremoveAddon.Name = "btnRremoveAddon";
            this.btnRremoveAddon.Size = new System.Drawing.Size(26, 28);
            this.btnRremoveAddon.TabIndex = 255;
            this.btnRremoveAddon.Text = "-";
            this.btnRremoveAddon.UseVisualStyleBackColor = true;
            this.btnRremoveAddon.Click += new System.EventHandler(this.btnRremoveAddon_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(128, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 29);
            this.label21.TabIndex = 256;
            this.label21.Text = "المبلغ الإجمالى:";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(145, 50);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 29);
            this.label24.TabIndex = 258;
            this.label24.Text = "قيمة الضريبة:";
            this.label24.Click += new System.EventHandler(this.label24_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(133, 78);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(89, 29);
            this.label26.TabIndex = 260;
            this.label26.Text = "إجمالى الفاتورة:";
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // lblAddonTotal
            // 
            this.lblAddonTotal.AutoSize = true;
            this.lblAddonTotal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblAddonTotal.Location = new System.Drawing.Point(128, 202);
            this.lblAddonTotal.Name = "lblAddonTotal";
            this.lblAddonTotal.Size = new System.Drawing.Size(39, 17);
            this.lblAddonTotal.TabIndex = 262;
            this.lblAddonTotal.Text = "0.00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.transpay);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.lblTotalCashAndBank);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtpaycard);
            this.groupBox2.Controls.Add(this.txtpaycash);
            this.groupBox2.Location = new System.Drawing.Point(502, 289);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(242, 178);
            this.groupBox2.TabIndex = 263;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "طريقة الدفع";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(194, 104);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 29);
            this.label31.TabIndex = 280;
            this.label31.Text = "تمارا :";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(15, 109);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(127, 20);
            this.textBox6.TabIndex = 279;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            this.textBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // lblTotalCashAndBank
            // 
            this.lblTotalCashAndBank.DecimalPlaces = 2;
            this.lblTotalCashAndBank.DecimalsSeparator = '.';
            this.lblTotalCashAndBank.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblTotalCashAndBank.Location = new System.Drawing.Point(15, 140);
            this.lblTotalCashAndBank.Name = "lblTotalCashAndBank";
            this.lblTotalCashAndBank.PreFix = null;
            this.lblTotalCashAndBank.ReadOnly = true;
            this.lblTotalCashAndBank.Size = new System.Drawing.Size(127, 24);
            this.lblTotalCashAndBank.TabIndex = 240;
            this.lblTotalCashAndBank.Text = "0.00";
            this.lblTotalCashAndBank.ThousandsSeparator = ' ';
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(181, 135);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 29);
            this.label22.TabIndex = 239;
            this.label22.Text = "الإجمالى:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(161, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 29);
            this.label15.TabIndex = 239;
            this.label15.Text = "بطاقة بنكية:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(198, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 29);
            this.label9.TabIndex = 239;
            this.label9.Text = "نقدا:";
            // 
            // txtpaycard
            // 
            this.txtpaycard.Location = new System.Drawing.Point(15, 27);
            this.txtpaycard.Name = "txtpaycard";
            this.txtpaycard.Size = new System.Drawing.Size(127, 20);
            this.txtpaycard.TabIndex = 15;
            this.txtpaycard.TextChanged += new System.EventHandler(this.txtpaycard_TextChanged);
            this.txtpaycard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpaycard_KeyDown);
            // 
            // txtpaycash
            // 
            this.txtpaycash.Location = new System.Drawing.Point(15, 80);
            this.txtpaycash.Name = "txtpaycash";
            this.txtpaycash.Size = new System.Drawing.Size(127, 20);
            this.txtpaycash.TabIndex = 14;
            this.txtpaycash.TextChanged += new System.EventHandler(this.txtpaycash_TextChanged);
            this.txtpaycash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpaycash_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(163, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 29);
            this.label11.TabIndex = 264;
            this.label11.Text = "نسبة الخصم:";
            // 
            // txtSearchDriverByID
            // 
            this.txtSearchDriverByID.Location = new System.Drawing.Point(276, 101);
            this.txtSearchDriverByID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchDriverByID.Name = "txtSearchDriverByID";
            this.txtSearchDriverByID.Size = new System.Drawing.Size(57, 20);
            this.txtSearchDriverByID.TabIndex = 9;
            this.txtSearchDriverByID.TextChanged += new System.EventHandler(this.txtDiscountValue_TextChanged);
            this.txtSearchDriverByID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchDriverByID_KeyDown);
            // 
            // txtSearchBoatByID
            // 
            this.txtSearchBoatByID.Location = new System.Drawing.Point(276, 75);
            this.txtSearchBoatByID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchBoatByID.Name = "txtSearchBoatByID";
            this.txtSearchBoatByID.Size = new System.Drawing.Size(57, 20);
            this.txtSearchBoatByID.TabIndex = 265;
            this.txtSearchBoatByID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBoatByID_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(362, 151);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(97, 29);
            this.label23.TabIndex = 230;
            this.label23.Text = "خصم الشركات:";
            // 
            // cmbCompanyDiscount
            // 
            this.cmbCompanyDiscount.FormattingEnabled = true;
            this.cmbCompanyDiscount.Location = new System.Drawing.Point(48, 154);
            this.cmbCompanyDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCompanyDiscount.Name = "cmbCompanyDiscount";
            this.cmbCompanyDiscount.Size = new System.Drawing.Size(285, 21);
            this.cmbCompanyDiscount.TabIndex = 266;
            this.cmbCompanyDiscount.SelectedIndexChanged += new System.EventHandler(this.cmbCompanyDiscount_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.lblVAT);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.lblTotalAfterVAT);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(750, 289);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 114);
            this.groupBox3.TabIndex = 267;
            this.groupBox3.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.DecimalPlaces = 2;
            this.lblTotal.DecimalsSeparator = '.';
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(21, 27);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.PreFix = null;
            this.lblTotal.ReadOnly = true;
            this.lblTotal.Size = new System.Drawing.Size(101, 24);
            this.lblTotal.TabIndex = 257;
            this.lblTotal.Text = "0.00";
            this.lblTotal.ThousandsSeparator = ' ';
            this.lblTotal.Click += new System.EventHandler(this.label22_Click);
            // 
            // lblVAT
            // 
            this.lblVAT.DecimalPlaces = 2;
            this.lblVAT.DecimalsSeparator = '.';
            this.lblVAT.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVAT.Location = new System.Drawing.Point(21, 54);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.PreFix = null;
            this.lblVAT.ReadOnly = true;
            this.lblVAT.Size = new System.Drawing.Size(101, 24);
            this.lblVAT.TabIndex = 259;
            this.lblVAT.Text = "0.00";
            this.lblVAT.ThousandsSeparator = ' ';
            // 
            // lblTotalAfterVAT
            // 
            this.lblTotalAfterVAT.DecimalPlaces = 2;
            this.lblTotalAfterVAT.DecimalsSeparator = '.';
            this.lblTotalAfterVAT.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAfterVAT.Location = new System.Drawing.Point(21, 82);
            this.lblTotalAfterVAT.Name = "lblTotalAfterVAT";
            this.lblTotalAfterVAT.PreFix = null;
            this.lblTotalAfterVAT.ReadOnly = true;
            this.lblTotalAfterVAT.Size = new System.Drawing.Size(101, 24);
            this.lblTotalAfterVAT.TabIndex = 261;
            this.lblTotalAfterVAT.Text = "0.00";
            this.lblTotalAfterVAT.ThousandsSeparator = ' ';
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvAddons);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.cmbAddons);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.txtAddonQty);
            this.groupBox4.Controls.Add(this.btnRremoveAddon);
            this.groupBox4.Controls.Add(this.lblAddonTotal);
            this.groupBox4.Controls.Add(this.btnAddAddon);
            this.groupBox4.Controls.Add(this.txtAddonPrice);
            this.groupBox4.Location = new System.Drawing.Point(63, 174);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(433, 229);
            this.groupBox4.TabIndex = 268;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "الاضافات:";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // dgvAddons
            // 
            this.dgvAddons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tiad_Addons,
            this.Name_addons,
            this.ID_Addons,
            this.Price,
            this.Quantity,
            this.Total_addons});
            this.dgvAddons.Location = new System.Drawing.Point(42, 77);
            this.dgvAddons.Name = "dgvAddons";
            this.dgvAddons.Size = new System.Drawing.Size(385, 107);
            this.dgvAddons.TabIndex = 263;
            // 
            // tiad_Addons
            // 
            this.tiad_Addons.DataPropertyName = "ID";
            this.tiad_Addons.HeaderText = "رقم تسلسلي";
            this.tiad_Addons.Name = "tiad_Addons";
            this.tiad_Addons.Width = 40;
            // 
            // Name_addons
            // 
            this.Name_addons.DataPropertyName = "Name";
            this.Name_addons.HeaderText = "اسم الاضافة";
            this.Name_addons.Name = "Name_addons";
            // 
            // ID_Addons
            // 
            this.ID_Addons.DataPropertyName = "AddonID";
            this.ID_Addons.HeaderText = "AddonID";
            this.ID_Addons.Name = "ID_Addons";
            this.ID_Addons.Visible = false;
            this.ID_Addons.Width = 5;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "السعر";
            this.Price.Name = "Price";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "الكمية";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 50;
            // 
            // Total_addons
            // 
            this.Total_addons.DataPropertyName = "Total";
            this.Total_addons.HeaderText = "الاجمالي";
            this.Total_addons.Name = "Total_addons";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.cmbTypeID);
            this.groupBox5.Controls.Add(this.cmbCompanyDiscount);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtSearchBoatByID);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.cmbSeaTransportID);
            this.groupBox5.Controls.Add(this.cmbDrivers);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.cmbDuration);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.lblPriceAfterDiscount);
            this.groupBox5.Controls.Add(this.lblPrice);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.dtpStartTime);
            this.groupBox5.Controls.Add(this.txtDiscountPercent);
            this.groupBox5.Controls.Add(this.dtpStartDate);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtSearchDriverByID);
            this.groupBox5.Controls.Add(this.txtDiscountValue);
            this.groupBox5.Location = new System.Drawing.Point(502, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(503, 276);
            this.groupBox5.TabIndex = 269;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "تفاصيل الرحلة";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Salmon;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(514, 474);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 30);
            this.btnPrint.TabIndex = 270;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "ID";
            this.Column8.HeaderText = "رقم تسلسلي";
            this.Column8.Name = "Column8";
            this.Column8.Width = 40;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Name";
            this.Column9.HeaderText = "اسم الاضافة";
            this.Column9.Name = "Column9";
            // 
            // dgvAddonID
            // 
            this.dgvAddonID.DataPropertyName = "AddonID";
            this.dgvAddonID.HeaderText = "AddonID";
            this.dgvAddonID.Name = "dgvAddonID";
            this.dgvAddonID.Visible = false;
            this.dgvAddonID.Width = 5;
            // 
            // dgvPrice
            // 
            this.dgvPrice.DataPropertyName = "Price";
            this.dgvPrice.HeaderText = "السعر";
            this.dgvPrice.Name = "dgvPrice";
            // 
            // dgvQuantity
            // 
            this.dgvQuantity.DataPropertyName = "Quantity";
            this.dgvQuantity.HeaderText = "الكمية";
            this.dgvQuantity.Name = "dgvQuantity";
            this.dgvQuantity.Width = 50;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "الاجمالي";
            this.Total.Name = "Total";
            // 
            // QRPic
            // 
            this.QRPic.Location = new System.Drawing.Point(792, 419);
            this.QRPic.Name = "QRPic";
            this.QRPic.Size = new System.Drawing.Size(83, 83);
            this.QRPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QRPic.TabIndex = 274;
            this.QRPic.TabStop = false;
            this.QRPic.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(64, 421);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(77, 29);
            this.label27.TabIndex = 276;
            this.label27.Text = "الملاحظات :";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(145, 426);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(320, 20);
            this.txtNote.TabIndex = 275;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(883, 472);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 279;
            this.button1.Text = "0 هللة";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // Btnchangetot
            // 
            this.Btnchangetot.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Btnchangetot.FlatAppearance.BorderSize = 0;
            this.Btnchangetot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnchangetot.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnchangetot.ForeColor = System.Drawing.Color.Black;
            this.Btnchangetot.Location = new System.Drawing.Point(883, 437);
            this.Btnchangetot.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Btnchangetot.Name = "Btnchangetot";
            this.Btnchangetot.Size = new System.Drawing.Size(100, 30);
            this.Btnchangetot.TabIndex = 278;
            this.Btnchangetot.Text = "تغيير الاجمالي";
            this.Btnchangetot.UseVisualStyleBackColor = false;
            this.Btnchangetot.Click += new System.EventHandler(this.Btnchangetot_Click);
            // 
            // txtchangetot
            // 
            this.txtchangetot.Location = new System.Drawing.Point(883, 409);
            this.txtchangetot.Name = "txtchangetot";
            this.txtchangetot.Size = new System.Drawing.Size(100, 20);
            this.txtchangetot.TabIndex = 277;
            this.txtchangetot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(70, 462);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(76, 29);
            this.label28.TabIndex = 284;
            this.label28.Text = "رقم المرجع :";
            this.label28.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(153, 467);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(201, 20);
            this.textBox4.TabIndex = 283;
            this.textBox4.Visible = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(159, 49);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(76, 29);
            this.label29.TabIndex = 282;
            this.label29.Text = "تحويل بنكي:";
            // 
            // transpay
            // 
            this.transpay.Location = new System.Drawing.Point(13, 54);
            this.transpay.Name = "transpay";
            this.transpay.Size = new System.Drawing.Size(129, 20);
            this.transpay.TabIndex = 281;
            this.transpay.TextChanged += new System.EventHandler(this.transpay_TextChanged);
            this.transpay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.transpay_KeyDown);
            // 
            // frmEditTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MarsaAlloaloah.Properties.Resources.BackgroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1057, 515);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btnchangetot);
            this.Controls.Add(this.txtchangetot);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.QRPic);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTicketNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmEditTicket";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "التذاكر";
            this.Load += new System.EventHandler(this.frmticket_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddons)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTicketNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustNID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustMobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTypeID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSeaTransportID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDuration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDiscountPercent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDiscountValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblPriceAfterDiscount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbDrivers;
        private System.Windows.Forms.ComboBox cmbAddons;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtAddonQty;
        private System.Windows.Forms.TextBox txtAddonPrice;
        private System.Windows.Forms.Button btnAddAddon;
        private System.Windows.Forms.Button btnRremoveAddon;
        private System.Windows.Forms.Label label21;
        private JRINCCustomControls.CurrencyTextBox lblTotal = new JRINCCustomControls.CurrencyTextBox();
        private JRINCCustomControls.CurrencyTextBox lblVAT = new JRINCCustomControls.CurrencyTextBox();
        private System.Windows.Forms.Label label24;
        private JRINCCustomControls.CurrencyTextBox lblTotalAfterVAT = new JRINCCustomControls.CurrencyTextBox();
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblAddonTotal;
        private System.Windows.Forms.Button btnFrmCustomer;
        private System.Windows.Forms.Label lblCustNotFound;
        private System.Windows.Forms.Label lblCustIDHidden;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtpaycash;
        private System.Windows.Forms.TextBox txtpaycard;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSearchDriverByID;
        private System.Windows.Forms.TextBox txtSearchBoatByID;
        public JRINCCustomControls.CurrencyTextBox lblTotalCashAndBank = new JRINCCustomControls.CurrencyTextBox();
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbCompanyDiscount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAddonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridView dgvAddons;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiad_Addons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_addons;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Addons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_addons;
        private System.Windows.Forms.PictureBox QRPic;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btnchangetot;
        private System.Windows.Forms.TextBox txtchangetot;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox transpay;
    }
}