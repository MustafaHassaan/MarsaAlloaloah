
namespace MarsaAlloaloah.Forms.PrincipalSetup
{
    partial class Frmabg
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
            this.cmbPriceGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.Duration = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Price = new System.Windows.Forms.TextBox();
            this.DriverCommission = new System.Windows.Forms.TextBox();
            this.CashierCommission = new System.Windows.Forms.TextBox();
            this.CashierExternCommission = new System.Windows.Forms.TextBox();
            this.txtPercentage = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Duration)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "اسم مجموعة التسعير:";
            // 
            // cmbPriceGroup
            // 
            this.cmbPriceGroup.DisplayMember = "Name";
            this.cmbPriceGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriceGroup.FormattingEnabled = true;
            this.cmbPriceGroup.Location = new System.Drawing.Point(185, 14);
            this.cmbPriceGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPriceGroup.Name = "cmbPriceGroup";
            this.cmbPriceGroup.Size = new System.Drawing.Size(210, 21);
            this.cmbPriceGroup.TabIndex = 208;
            this.cmbPriceGroup.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 209;
            this.label2.Text = "المدة الزمنية :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 29);
            this.label3.TabIndex = 210;
            this.label3.Text = "التوقيت :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 29);
            this.label4.TabIndex = 211;
            this.label4.Text = "السعر :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 29);
            this.label5.TabIndex = 212;
            this.label5.Text = "عمولة السائق :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 29);
            this.label6.TabIndex = 213;
            this.label6.Text = "عمولة الكاشير :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 29);
            this.label7.TabIndex = 214;
            this.label7.Text = "عمولة كاشير مراكب خارجية :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(167, 248);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 239;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Duration
            // 
            this.Duration.Location = new System.Drawing.Point(185, 44);
            this.Duration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(210, 20);
            this.Duration.TabIndex = 240;
            this.Duration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Duration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "-- اختر --",
            "دقيقة",
            "ساعه"});
            this.comboBox1.Location = new System.Drawing.Point(185, 72);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(210, 21);
            this.comboBox1.TabIndex = 241;
            this.comboBox1.ValueMember = "ID";
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(185, 101);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(210, 20);
            this.Price.TabIndex = 242;
            this.Price.Text = "0.00";
            this.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // DriverCommission
            // 
            this.DriverCommission.Location = new System.Drawing.Point(185, 216);
            this.DriverCommission.Name = "DriverCommission";
            this.DriverCommission.Size = new System.Drawing.Size(210, 20);
            this.DriverCommission.TabIndex = 243;
            this.DriverCommission.Text = "0.00";
            this.DriverCommission.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DriverCommission.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // CashierCommission
            // 
            this.CashierCommission.Location = new System.Drawing.Point(185, 153);
            this.CashierCommission.Name = "CashierCommission";
            this.CashierCommission.Size = new System.Drawing.Size(210, 20);
            this.CashierCommission.TabIndex = 244;
            this.CashierCommission.Text = "0.00";
            this.CashierCommission.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CashierCommission.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // CashierExternCommission
            // 
            this.CashierExternCommission.Location = new System.Drawing.Point(185, 182);
            this.CashierExternCommission.Name = "CashierExternCommission";
            this.CashierExternCommission.Size = new System.Drawing.Size(210, 20);
            this.CashierExternCommission.TabIndex = 245;
            this.CashierExternCommission.Text = "0.00";
            this.CashierExternCommission.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CashierExternCommission.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // txtPercentage
            // 
            this.txtPercentage.Location = new System.Drawing.Point(185, 127);
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.Size = new System.Drawing.Size(174, 20);
            this.txtPercentage.TabIndex = 247;
            this.txtPercentage.Text = "0.00";
            this.txtPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 29);
            this.label8.TabIndex = 246;
            this.label8.Text = "النسبة :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(365, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 29);
            this.label9.TabIndex = 248;
            this.label9.Text = "%";
            this.label9.Visible = false;
            // 
            // Frmabg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 290);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPercentage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CashierExternCommission);
            this.Controls.Add(this.CashierCommission);
            this.Controls.Add(this.DriverCommission);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Duration);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPriceGroup);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmabg";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "أضافة سعر جديد";
            this.Load += new System.EventHandler(this.Frmabg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Duration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cmbPriceGroup;
        public System.Windows.Forms.NumericUpDown Duration;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox Price;
        public System.Windows.Forms.TextBox DriverCommission;
        public System.Windows.Forms.TextBox CashierCommission;
        public System.Windows.Forms.TextBox CashierExternCommission;
        public System.Windows.Forms.TextBox txtPercentage;
        public System.Windows.Forms.Button btnSave;
    }
}