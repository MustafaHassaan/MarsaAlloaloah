
namespace frmemployees.Forms.Returned
{
    partial class Frmreturn
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
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalCashAndBank = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpaycard = new System.Windows.Forms.TextBox();
            this.txtpaycash = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblAddonTotal = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.QRPic = new System.Windows.Forms.PictureBox();
            this.dgvQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAddonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPriceAfterDiscount = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtDiscountPercent = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiscountValue = new System.Windows.Forms.TextBox();
            this.Total_addons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTotal = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.lblVAT = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.lblTotalAfterVAT = new JRINCCustomControls.CurrencyTextBox(this.components);
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Addons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_addons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiad_Addons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAddons = new System.Windows.Forms.DataGridView();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCustNID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustMobile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTicketNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRPic)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddons)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // lblTotalCashAndBank
            // 
            this.lblTotalCashAndBank.DecimalPlaces = 2;
            this.lblTotalCashAndBank.DecimalsSeparator = '.';
            this.lblTotalCashAndBank.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblTotalCashAndBank.Location = new System.Drawing.Point(61, 78);
            this.lblTotalCashAndBank.Name = "lblTotalCashAndBank";
            this.lblTotalCashAndBank.PreFix = null;
            this.lblTotalCashAndBank.ReadOnly = true;
            this.lblTotalCashAndBank.Size = new System.Drawing.Size(100, 24);
            this.lblTotalCashAndBank.TabIndex = 240;
            this.lblTotalCashAndBank.Text = "0.00";
            this.lblTotalCashAndBank.ThousandsSeparator = ' ';
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(174, 73);
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
            this.label9.Location = new System.Drawing.Point(198, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 29);
            this.label9.TabIndex = 239;
            this.label9.Text = "نقدا:";
            // 
            // txtpaycard
            // 
            this.txtpaycard.Location = new System.Drawing.Point(61, 27);
            this.txtpaycard.Name = "txtpaycard";
            this.txtpaycard.Size = new System.Drawing.Size(100, 20);
            this.txtpaycard.TabIndex = 15;
            // 
            // txtpaycash
            // 
            this.txtpaycash.Location = new System.Drawing.Point(61, 53);
            this.txtpaycash.Name = "txtpaycash";
            this.txtpaycash.Size = new System.Drawing.Size(100, 20);
            this.txtpaycash.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalCashAndBank);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtpaycard);
            this.groupBox2.Controls.Add(this.txtpaycash);
            this.groupBox2.Location = new System.Drawing.Point(442, 289);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(242, 114);
            this.groupBox2.TabIndex = 280;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "طريقة الدفع";
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
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(133, 78);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(89, 29);
            this.label26.TabIndex = 260;
            this.label26.Text = "إجمالى الفاتورة:";
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
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(145, 50);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 29);
            this.label24.TabIndex = 258;
            this.label24.Text = "قيمة الضريبة:";
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
            // QRPic
            // 
            this.QRPic.Location = new System.Drawing.Point(872, 409);
            this.QRPic.Name = "QRPic";
            this.QRPic.Size = new System.Drawing.Size(73, 70);
            this.QRPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QRPic.TabIndex = 285;
            this.QRPic.TabStop = false;
            this.QRPic.Visible = false;
            // 
            // dgvQuantity
            // 
            this.dgvQuantity.DataPropertyName = "Quantity";
            this.dgvQuantity.HeaderText = "الكمية";
            this.dgvQuantity.Name = "dgvQuantity";
            this.dgvQuantity.Width = 50;
            // 
            // dgvPrice
            // 
            this.dgvPrice.DataPropertyName = "Price";
            this.dgvPrice.HeaderText = "السعر";
            this.dgvPrice.Name = "dgvPrice";
            // 
            // dgvAddonID
            // 
            this.dgvAddonID.DataPropertyName = "AddonID";
            this.dgvAddonID.HeaderText = "AddonID";
            this.dgvAddonID.Name = "dgvAddonID";
            this.dgvAddonID.Visible = false;
            this.dgvAddonID.Width = 5;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Name";
            this.Column9.HeaderText = "اسم الاضافة";
            this.Column9.Name = "Column9";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "ID";
            this.Column8.HeaderText = "رقم تسلسلي";
            this.Column8.Name = "Column8";
            this.Column8.Width = 40;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.lblPriceAfterDiscount);
            this.groupBox5.Controls.Add(this.lblPrice);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.dtpStartTime);
            this.groupBox5.Controls.Add(this.txtDiscountPercent);
            this.groupBox5.Controls.Add(this.dtpStartDate);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtDiscountValue);
            this.groupBox5.Location = new System.Drawing.Point(442, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(503, 276);
            this.groupBox5.TabIndex = 283;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "تفاصيل الرحلة";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 185);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 13);
            this.label13.TabIndex = 235;
            this.label13.Text = "%";
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
            // txtDiscountPercent
            // 
            this.txtDiscountPercent.Location = new System.Drawing.Point(66, 181);
            this.txtDiscountPercent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountPercent.Name = "txtDiscountPercent";
            this.txtDiscountPercent.Size = new System.Drawing.Size(91, 20);
            this.txtDiscountPercent.TabIndex = 10;
            this.txtDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.txtDiscountValue.Location = new System.Drawing.Point(251, 181);
            this.txtDiscountValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountValue.Name = "txtDiscountValue";
            this.txtDiscountValue.Size = new System.Drawing.Size(82, 20);
            this.txtDiscountValue.TabIndex = 9;
            // 
            // Total_addons
            // 
            this.Total_addons.DataPropertyName = "Total";
            this.Total_addons.HeaderText = "الاجمالي";
            this.Total_addons.Name = "Total_addons";
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
            this.groupBox3.Location = new System.Drawing.Point(690, 289);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 114);
            this.groupBox3.TabIndex = 281;
            this.groupBox3.TabStop = false;
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
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "الكمية";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 50;
            // 
            // ID_Addons
            // 
            this.ID_Addons.DataPropertyName = "AddonID";
            this.ID_Addons.HeaderText = "AddonID";
            this.ID_Addons.Name = "ID_Addons";
            this.ID_Addons.Visible = false;
            this.ID_Addons.Width = 5;
            // 
            // Name_addons
            // 
            this.Name_addons.DataPropertyName = "Name";
            this.Name_addons.HeaderText = "اسم الاضافة";
            this.Name_addons.Name = "Name_addons";
            // 
            // tiad_Addons
            // 
            this.tiad_Addons.DataPropertyName = "ID";
            this.tiad_Addons.HeaderText = "رقم تسلسلي";
            this.tiad_Addons.Name = "tiad_Addons";
            this.tiad_Addons.Width = 40;
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
            this.dgvAddons.Location = new System.Drawing.Point(42, 19);
            this.dgvAddons.Name = "dgvAddons";
            this.dgvAddons.Size = new System.Drawing.Size(385, 165);
            this.dgvAddons.TabIndex = 263;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "السعر";
            this.Price.Name = "Price";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvAddons);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.lblAddonTotal);
            this.groupBox4.Location = new System.Drawing.Point(3, 174);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(433, 229);
            this.groupBox4.TabIndex = 282;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "الاضافات:";
            // 
            // txtCustNID
            // 
            this.txtCustNID.Location = new System.Drawing.Point(37, 62);
            this.txtCustNID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustNID.Name = "txtCustNID";
            this.txtCustNID.Size = new System.Drawing.Size(289, 20);
            this.txtCustNID.TabIndex = 1;
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
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(37, 99);
            this.txtCustName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(289, 20);
            this.txtCustName.TabIndex = 2;
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
            // 
            // txtCustMobile
            // 
            this.txtCustMobile.Location = new System.Drawing.Point(37, 25);
            this.txtCustMobile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustMobile.Name = "txtCustMobile";
            this.txtCustMobile.Size = new System.Drawing.Size(289, 20);
            this.txtCustMobile.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustNID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCustName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCustMobile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(432, 132);
            this.groupBox1.TabIndex = 277;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات العميل";
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
            // 
            // txtTicketNo
            // 
            this.txtTicketNo.Enabled = false;
            this.txtTicketNo.Location = new System.Drawing.Point(111, 13);
            this.txtTicketNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTicketNo.Name = "txtTicketNo";
            this.txtTicketNo.Size = new System.Drawing.Size(147, 20);
            this.txtTicketNo.TabIndex = 276;
            this.txtTicketNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTicketNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 29);
            this.label1.TabIndex = 275;
            this.label1.Text = "رقم التذكرة:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(496, 427);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 279;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(401, 427);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 278;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "الاجمالي";
            this.Total.Name = "Total";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 47);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 20);
            this.textBox1.TabIndex = 209;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(48, 75);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(283, 20);
            this.textBox2.TabIndex = 265;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(50, 103);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(283, 20);
            this.textBox3.TabIndex = 266;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(48, 131);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(283, 20);
            this.textBox4.TabIndex = 267;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(50, 157);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(283, 20);
            this.textBox5.TabIndex = 268;
            // 
            // Frmreturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 484);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.QRPic);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTicketNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "Frmreturn";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مرتجع تذكرة";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRPic)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddons)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        public JRINCCustomControls.CurrencyTextBox lblTotalCashAndBank;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtpaycard;
        private System.Windows.Forms.TextBox txtpaycash;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblAddonTotal;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox QRPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAddonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPriceAfterDiscount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.TextBox txtDiscountPercent;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDiscountValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_addons;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label21;
        private JRINCCustomControls.CurrencyTextBox lblTotal;
        private JRINCCustomControls.CurrencyTextBox lblVAT;
        private JRINCCustomControls.CurrencyTextBox lblTotalAfterVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Addons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_addons;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiad_Addons;
        private System.Windows.Forms.DataGridView dgvAddons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCustNID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustMobile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTicketNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}