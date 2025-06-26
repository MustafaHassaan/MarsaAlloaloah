namespace MarsaAlloaloah
{
    partial class frmcustomers
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtNID = new System.Windows.Forms.TextBox();
            this.dgvCusomers = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSearchByName = new System.Windows.Forms.TextBox();
            this.txtSearchByNID = new System.Windows.Forms.TextBox();
            this.txtSearchByMobile = new System.Windows.Forms.TextBox();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Taxnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusomers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم العميل:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "رقم الجوال:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "رقم الهوية:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(149, 21);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(311, 20);
            this.txtCustomerName.TabIndex = 0;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(149, 49);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(311, 20);
            this.txtMobileNo.TabIndex = 1;
            // 
            // txtNID
            // 
            this.txtNID.Location = new System.Drawing.Point(149, 78);
            this.txtNID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNID.Name = "txtNID";
            this.txtNID.Size = new System.Drawing.Size(311, 20);
            this.txtNID.TabIndex = 2;
            // 
            // dgvCusomers
            // 
            this.dgvCusomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCusomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCusomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dgvClientName,
            this.dgnid,
            this.dgmobile,
            this.dgvCustomerID,
            this.Taxnumber,
            this.Address});
            this.dgvCusomers.Location = new System.Drawing.Point(12, 237);
            this.dgvCusomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCusomers.Name = "dgvCusomers";
            this.dgvCusomers.RowTemplate.Height = 26;
            this.dgvCusomers.Size = new System.Drawing.Size(496, 229);
            this.dgvCusomers.TabIndex = 3;
            this.dgvCusomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCusomers_CellDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(375, 167);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 188;
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
            this.btnDelete.Location = new System.Drawing.Point(283, 167);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 187;
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
            this.btnSave.Location = new System.Drawing.Point(99, 167);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 185;
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
            this.btnClear.Location = new System.Drawing.Point(191, 167);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 186;
            this.btnClear.Text = "مسح";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(69, 206);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 29);
            this.label22.TabIndex = 266;
            this.label22.Text = "بحث :";
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.BackColor = System.Drawing.Color.Yellow;
            this.txtSearchByName.Location = new System.Drawing.Point(166, 211);
            this.txtSearchByName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.Size = new System.Drawing.Size(110, 20);
            this.txtSearchByName.TabIndex = 265;
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged);
            // 
            // txtSearchByNID
            // 
            this.txtSearchByNID.BackColor = System.Drawing.Color.Yellow;
            this.txtSearchByNID.Location = new System.Drawing.Point(282, 211);
            this.txtSearchByNID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchByNID.Name = "txtSearchByNID";
            this.txtSearchByNID.Size = new System.Drawing.Size(111, 20);
            this.txtSearchByNID.TabIndex = 264;
            this.txtSearchByNID.TextChanged += new System.EventHandler(this.txtSearchByNID_TextChanged);
            // 
            // txtSearchByMobile
            // 
            this.txtSearchByMobile.BackColor = System.Drawing.Color.Yellow;
            this.txtSearchByMobile.Location = new System.Drawing.Point(397, 211);
            this.txtSearchByMobile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchByMobile.Name = "txtSearchByMobile";
            this.txtSearchByMobile.Size = new System.Drawing.Size(111, 20);
            this.txtSearchByMobile.TabIndex = 267;
            this.txtSearchByMobile.TextChanged += new System.EventHandler(this.txtSearchByMobile_TextChanged);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExportExcel.Location = new System.Drawing.Point(516, 237);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(104, 67);
            this.btnExportExcel.TabIndex = 291;
            this.btnExportExcel.Text = "تقرير العملاء  (Excel) ";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 105);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 20);
            this.textBox1.TabIndex = 293;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 29);
            this.label4.TabIndex = 292;
            this.label4.Text = "العنوان :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(149, 132);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(311, 20);
            this.textBox2.TabIndex = 295;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 29);
            this.label5.TabIndex = 294;
            this.label5.Text = "الرقم الضريبي :";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SlNo";
            this.Column1.HeaderText = "الرقم التسلسلى";
            this.Column1.Name = "Column1";
            // 
            // dgvClientName
            // 
            this.dgvClientName.DataPropertyName = "Name";
            this.dgvClientName.HeaderText = "اسم العميل";
            this.dgvClientName.Name = "dgvClientName";
            // 
            // dgnid
            // 
            this.dgnid.DataPropertyName = "NID";
            this.dgnid.HeaderText = "رقم الهوية";
            this.dgnid.Name = "dgnid";
            // 
            // dgmobile
            // 
            this.dgmobile.DataPropertyName = "Mobile";
            this.dgmobile.HeaderText = "رقم الجوال";
            this.dgmobile.Name = "dgmobile";
            // 
            // dgvCustomerID
            // 
            this.dgvCustomerID.DataPropertyName = "ID";
            this.dgvCustomerID.HeaderText = "CustomerID";
            this.dgvCustomerID.Name = "dgvCustomerID";
            this.dgvCustomerID.Visible = false;
            // 
            // Taxnumber
            // 
            this.Taxnumber.DataPropertyName = "Taxnumber";
            this.Taxnumber.HeaderText = "الرقم الضريبي";
            this.Taxnumber.Name = "Taxnumber";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "العنوان";
            this.Address.Name = "Address";
            // 
            // frmcustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 475);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.txtSearchByMobile);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtSearchByName);
            this.Controls.Add(this.txtSearchByNID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvCusomers);
            this.Controls.Add(this.txtNID);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmcustomers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "العملاء";
            this.Load += new System.EventHandler(this.frmcustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtNID;
        private System.Windows.Forms.DataGridView dgvCusomers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtSearchByName;
        private System.Windows.Forms.TextBox txtSearchByNID;
        private System.Windows.Forms.TextBox txtSearchByMobile;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Taxnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}

