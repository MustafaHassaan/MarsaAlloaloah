
namespace MarsaAlloaloah.Forms.Returned
{
    partial class Returnedform
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtpaycash = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtpaycard = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnFrmCustomer = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.CBCashier = new System.Windows.Forms.ComboBox();
            this.Btnsearch = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.paymentMethod = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.transpay = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tamarapay = new System.Windows.Forms.TextBox();
            this.Retpay = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbltrans = new System.Windows.Forms.Label();
            this.txtrettrans = new System.Windows.Forms.TextBox();
            this.lbltamara = new System.Windows.Forms.Label();
            this.txtrettamara = new System.Windows.Forms.TextBox();
            this.txtretbank = new System.Windows.Forms.TextBox();
            this.lblbank = new System.Windows.Forms.Label();
            this.txtretcash = new System.Windows.Forms.TextBox();
            this.lblcash = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbltot = new System.Windows.Forms.Label();
            this.lblrettot = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "--اختر--",
            "ارتجاع تذكرة",
            "ارتجاع ارساء",
            "ارتجاع حجز"});
            this.comboBox1.Location = new System.Drawing.Point(380, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(100, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(380, 85);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(178, 96);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "رقم الأرتجاع :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "رقم الفاتورة :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(100, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(178, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "نوع الفاتورة :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "سبب الارتجاع :";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(380, 185);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(178, 44);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "ملاحظات :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(305, 356);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtpaycash
            // 
            this.txtpaycash.Enabled = false;
            this.txtpaycash.Location = new System.Drawing.Point(100, 112);
            this.txtpaycash.Name = "txtpaycash";
            this.txtpaycash.Size = new System.Drawing.Size(178, 20);
            this.txtpaycash.TabIndex = 2;
            this.txtpaycash.Text = "0";
            this.txtpaycash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtpaycash.Visible = false;
            this.txtpaycash.TextChanged += new System.EventHandler(this.txtpaycash_TextChanged);
            this.txtpaycash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 280;
            this.label6.Text = "المبلغ النقدي :";
            this.label6.Visible = false;
            // 
            // txtpaycard
            // 
            this.txtpaycard.Enabled = false;
            this.txtpaycard.Location = new System.Drawing.Point(100, 138);
            this.txtpaycard.Name = "txtpaycard";
            this.txtpaycard.Size = new System.Drawing.Size(178, 20);
            this.txtpaycard.TabIndex = 3;
            this.txtpaycard.Text = "0";
            this.txtpaycard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtpaycard.Visible = false;
            this.txtpaycard.TextChanged += new System.EventHandler(this.txtpaycard_TextChanged);
            this.txtpaycard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 282;
            this.label7.Text = "المبلغ البنكي :";
            this.label7.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(380, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(178, 20);
            this.dateTimePicker1.TabIndex = 283;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 284;
            this.label8.Text = "تاريخ الارتجاع :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 286;
            this.label9.Text = "اسم العميل :";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(100, 58);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(150, 21);
            this.comboBox2.TabIndex = 285;
            // 
            // btnFrmCustomer
            // 
            this.btnFrmCustomer.Enabled = false;
            this.btnFrmCustomer.Location = new System.Drawing.Point(256, 57);
            this.btnFrmCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFrmCustomer.Name = "btnFrmCustomer";
            this.btnFrmCustomer.Size = new System.Drawing.Size(22, 20);
            this.btnFrmCustomer.TabIndex = 287;
            this.btnFrmCustomer.Text = "+";
            this.btnFrmCustomer.UseVisualStyleBackColor = true;
            this.btnFrmCustomer.Click += new System.EventHandler(this.btnFrmCustomer_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(308, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 289;
            this.label10.Text = "الكاشير :";
            // 
            // CBCashier
            // 
            this.CBCashier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCashier.Enabled = false;
            this.CBCashier.FormattingEnabled = true;
            this.CBCashier.Items.AddRange(new object[] {
            "--اختر--",
            "ارتجاع تذكرة",
            "ارتجاع ارساء"});
            this.CBCashier.Location = new System.Drawing.Point(380, 58);
            this.CBCashier.Name = "CBCashier";
            this.CBCashier.Size = new System.Drawing.Size(178, 21);
            this.CBCashier.TabIndex = 288;
            // 
            // Btnsearch
            // 
            this.Btnsearch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Btnsearch.FlatAppearance.BorderSize = 0;
            this.Btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnsearch.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnsearch.ForeColor = System.Drawing.Color.Black;
            this.Btnsearch.Location = new System.Drawing.Point(210, 356);
            this.Btnsearch.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Btnsearch.Name = "Btnsearch";
            this.Btnsearch.Size = new System.Drawing.Size(85, 30);
            this.Btnsearch.TabIndex = 290;
            this.Btnsearch.Text = "بحث";
            this.Btnsearch.UseVisualStyleBackColor = false;
            this.Btnsearch.Click += new System.EventHandler(this.Btnsearch_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label28.Location = new System.Drawing.Point(37, 91);
            this.label28.Name = "label28";
            this.label28.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label28.Size = new System.Drawing.Size(57, 13);
            this.label28.TabIndex = 295;
            this.label28.Text = "نوع الدفع :";
            // 
            // paymentMethod
            // 
            this.paymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentMethod.FormattingEnabled = true;
            this.paymentMethod.Items.AddRange(new object[] {
            "--اختر--",
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
            this.paymentMethod.Location = new System.Drawing.Point(100, 85);
            this.paymentMethod.Name = "paymentMethod";
            this.paymentMethod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.paymentMethod.Size = new System.Drawing.Size(178, 21);
            this.paymentMethod.TabIndex = 294;
            this.paymentMethod.SelectedIndexChanged += new System.EventHandler(this.paymentMethod_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label29.Location = new System.Drawing.Point(28, 167);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(66, 13);
            this.label29.TabIndex = 299;
            this.label29.Text = "تحويل بنكي:";
            this.label29.Visible = false;
            // 
            // transpay
            // 
            this.transpay.Enabled = false;
            this.transpay.Location = new System.Drawing.Point(100, 164);
            this.transpay.Name = "transpay";
            this.transpay.Size = new System.Drawing.Size(178, 20);
            this.transpay.TabIndex = 298;
            this.transpay.Text = "0";
            this.transpay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.transpay.Visible = false;
            this.transpay.TextChanged += new System.EventHandler(this.transpay_TextChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label31.Location = new System.Drawing.Point(60, 193);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(34, 13);
            this.label31.TabIndex = 297;
            this.label31.Text = "تمارا :";
            this.label31.Visible = false;
            // 
            // tamarapay
            // 
            this.tamarapay.Enabled = false;
            this.tamarapay.Location = new System.Drawing.Point(100, 190);
            this.tamarapay.Name = "tamarapay";
            this.tamarapay.Size = new System.Drawing.Size(178, 20);
            this.tamarapay.TabIndex = 296;
            this.tamarapay.Text = "0";
            this.tamarapay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tamarapay.Visible = false;
            this.tamarapay.TextChanged += new System.EventHandler(this.tamarapay_TextChanged);
            // 
            // Retpay
            // 
            this.Retpay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Retpay.FormattingEnabled = true;
            this.Retpay.Items.AddRange(new object[] {
            "--اختر--",
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
            this.Retpay.Location = new System.Drawing.Point(100, 245);
            this.Retpay.Name = "Retpay";
            this.Retpay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Retpay.Size = new System.Drawing.Size(458, 21);
            this.Retpay.TabIndex = 300;
            this.Retpay.SelectedIndexChanged += new System.EventHandler(this.Retpay_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.Location = new System.Drawing.Point(6, 248);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 301;
            this.label11.Text = "ارتجاع عن طريق :";
            // 
            // lbltrans
            // 
            this.lbltrans.AutoSize = true;
            this.lbltrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbltrans.Location = new System.Drawing.Point(308, 275);
            this.lbltrans.Name = "lbltrans";
            this.lbltrans.Size = new System.Drawing.Size(66, 13);
            this.lbltrans.TabIndex = 309;
            this.lbltrans.Text = "تحويل بنكي:";
            this.lbltrans.Visible = false;
            // 
            // txtrettrans
            // 
            this.txtrettrans.Location = new System.Drawing.Point(380, 272);
            this.txtrettrans.Name = "txtrettrans";
            this.txtrettrans.Size = new System.Drawing.Size(178, 20);
            this.txtrettrans.TabIndex = 308;
            this.txtrettrans.Text = "0";
            this.txtrettrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtrettrans.Visible = false;
            this.txtrettrans.TextChanged += new System.EventHandler(this.txtrettrans_TextChanged);
            // 
            // lbltamara
            // 
            this.lbltamara.AutoSize = true;
            this.lbltamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbltamara.Location = new System.Drawing.Point(340, 301);
            this.lbltamara.Name = "lbltamara";
            this.lbltamara.Size = new System.Drawing.Size(34, 13);
            this.lbltamara.TabIndex = 307;
            this.lbltamara.Text = "تمارا :";
            this.lbltamara.Visible = false;
            // 
            // txtrettamara
            // 
            this.txtrettamara.Location = new System.Drawing.Point(380, 298);
            this.txtrettamara.Name = "txtrettamara";
            this.txtrettamara.Size = new System.Drawing.Size(178, 20);
            this.txtrettamara.TabIndex = 306;
            this.txtrettamara.Text = "0";
            this.txtrettamara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtrettamara.Visible = false;
            this.txtrettamara.TextChanged += new System.EventHandler(this.txtrettamara_TextChanged);
            // 
            // txtretbank
            // 
            this.txtretbank.Location = new System.Drawing.Point(100, 298);
            this.txtretbank.Name = "txtretbank";
            this.txtretbank.Size = new System.Drawing.Size(178, 20);
            this.txtretbank.TabIndex = 303;
            this.txtretbank.Text = "0";
            this.txtretbank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtretbank.Visible = false;
            this.txtretbank.TextChanged += new System.EventHandler(this.txtretbank_TextChanged);
            // 
            // lblbank
            // 
            this.lblbank.AutoSize = true;
            this.lblbank.Location = new System.Drawing.Point(22, 301);
            this.lblbank.Name = "lblbank";
            this.lblbank.Size = new System.Drawing.Size(72, 13);
            this.lblbank.TabIndex = 305;
            this.lblbank.Text = "المبلغ البنكي :";
            this.lblbank.Visible = false;
            // 
            // txtretcash
            // 
            this.txtretcash.Location = new System.Drawing.Point(100, 272);
            this.txtretcash.Name = "txtretcash";
            this.txtretcash.Size = new System.Drawing.Size(178, 20);
            this.txtretcash.TabIndex = 302;
            this.txtretcash.Text = "0";
            this.txtretcash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtretcash.Visible = false;
            this.txtretcash.TextChanged += new System.EventHandler(this.txtretcash_TextChanged);
            // 
            // lblcash
            // 
            this.lblcash.AutoSize = true;
            this.lblcash.Location = new System.Drawing.Point(22, 275);
            this.lblcash.Name = "lblcash";
            this.lblcash.Size = new System.Drawing.Size(71, 13);
            this.lblcash.TabIndex = 304;
            this.lblcash.Text = "المبلغ النقدي :";
            this.lblcash.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(97, 216);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 310;
            this.label12.Text = "الاجمالي :";
            // 
            // lbltot
            // 
            this.lbltot.AutoSize = true;
            this.lbltot.Location = new System.Drawing.Point(182, 216);
            this.lbltot.Name = "lbltot";
            this.lbltot.Size = new System.Drawing.Size(13, 13);
            this.lbltot.TabIndex = 311;
            this.lbltot.Text = "0";
            // 
            // lblrettot
            // 
            this.lblrettot.AutoSize = true;
            this.lblrettot.Location = new System.Drawing.Point(182, 326);
            this.lblrettot.Name = "lblrettot";
            this.lblrettot.Size = new System.Drawing.Size(13, 13);
            this.lblrettot.TabIndex = 313;
            this.lblrettot.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(97, 326);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 312;
            this.label15.Text = "الاجمالي :";
            // 
            // Returnedform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 405);
            this.Controls.Add(this.lblrettot);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lbltot);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbltrans);
            this.Controls.Add(this.txtrettrans);
            this.Controls.Add(this.lbltamara);
            this.Controls.Add(this.txtrettamara);
            this.Controls.Add(this.txtretbank);
            this.Controls.Add(this.lblbank);
            this.Controls.Add(this.txtretcash);
            this.Controls.Add(this.lblcash);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Retpay);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.transpay);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.tamarapay);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.paymentMethod);
            this.Controls.Add(this.Btnsearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CBCashier);
            this.Controls.Add(this.btnFrmCustomer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtpaycard);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtpaycash);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.MaximizeBox = false;
            this.Name = "Returnedform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مرتجعات";
            this.Load += new System.EventHandler(this.Returnedform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtpaycash;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtpaycard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnFrmCustomer;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox CBCashier;
        private System.Windows.Forms.Button Btnsearch;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox paymentMethod;
        private System.Windows.Forms.Label label29;
        public System.Windows.Forms.TextBox transpay;
        private System.Windows.Forms.Label label31;
        public System.Windows.Forms.TextBox tamarapay;
        private System.Windows.Forms.ComboBox Retpay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbltrans;
        public System.Windows.Forms.TextBox txtrettrans;
        private System.Windows.Forms.Label lbltamara;
        public System.Windows.Forms.TextBox txtrettamara;
        private System.Windows.Forms.TextBox txtretbank;
        private System.Windows.Forms.Label lblbank;
        private System.Windows.Forms.TextBox txtretcash;
        private System.Windows.Forms.Label lblcash;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbltot;
        private System.Windows.Forms.Label lblrettot;
        private System.Windows.Forms.Label label15;
    }
}