namespace MarsaAlloaloah
{
    partial class frmCompanyDiscount
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
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.dgvCusomers = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dtbStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtbEndDate = new System.Windows.Forms.DateTimePicker();
            this.ckbIsActive = new System.Windows.Forms.CheckBox();
            this.Admin = new System.Windows.Forms.CheckBox();
            this.Cashier = new System.Windows.Forms.CheckBox();
            this.Comptable = new System.Windows.Forms.CheckBox();
            this.EntringData = new System.Windows.Forms.CheckBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCompanyDiscountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adminfield = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cashierfield = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comptablefield = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntringDatafield = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusomers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم الشركة:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "نسبة الخصم:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = " بداية الخصم:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(115, 20);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(370, 20);
            this.txtCompanyName.TabIndex = 0;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(115, 53);
            this.txtValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(70, 20);
            this.txtValue.TabIndex = 1;
            // 
            // dgvCusomers
            // 
            this.dgvCusomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCusomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCusomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dgvCompanyName,
            this.DiscountValue,
            this.dgmobile,
            this.Column2,
            this.Column3,
            this.dgvCompanyDiscountID,
            this.Adminfield,
            this.Cashierfield,
            this.Comptablefield,
            this.EntringDatafield});
            this.dgvCusomers.Location = new System.Drawing.Point(12, 287);
            this.dgvCusomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCusomers.Name = "dgvCusomers";
            this.dgvCusomers.RowTemplate.Height = 26;
            this.dgvCusomers.Size = new System.Drawing.Size(530, 244);
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
            this.btnClose.Location = new System.Drawing.Point(391, 245);
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
            this.btnDelete.Location = new System.Drawing.Point(299, 245);
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
            this.btnSave.Location = new System.Drawing.Point(115, 245);
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
            this.btnClear.Location = new System.Drawing.Point(207, 245);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 186;
            this.btnClear.Text = "مسح";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dtbStartDate
            // 
            this.dtbStartDate.Location = new System.Drawing.Point(115, 90);
            this.dtbStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtbStartDate.Name = "dtbStartDate";
            this.dtbStartDate.Size = new System.Drawing.Size(204, 20);
            this.dtbStartDate.TabIndex = 225;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = " نهاية الخصم:";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // dtbEndDate
            // 
            this.dtbEndDate.Location = new System.Drawing.Point(115, 130);
            this.dtbEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtbEndDate.Name = "dtbEndDate";
            this.dtbEndDate.Size = new System.Drawing.Size(204, 20);
            this.dtbEndDate.TabIndex = 225;
            // 
            // ckbIsActive
            // 
            this.ckbIsActive.AutoSize = true;
            this.ckbIsActive.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbIsActive.Location = new System.Drawing.Point(115, 165);
            this.ckbIsActive.Name = "ckbIsActive";
            this.ckbIsActive.Size = new System.Drawing.Size(92, 33);
            this.ckbIsActive.TabIndex = 226;
            this.ckbIsActive.Text = "خصم مفعل";
            this.ckbIsActive.UseVisualStyleBackColor = true;
            this.ckbIsActive.CheckedChanged += new System.EventHandler(this.ckbIsActive_CheckedChanged);
            // 
            // Admin
            // 
            this.Admin.AutoSize = true;
            this.Admin.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin.Location = new System.Drawing.Point(115, 204);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(92, 33);
            this.Admin.TabIndex = 227;
            this.Admin.Text = "مدير النظام";
            this.Admin.UseVisualStyleBackColor = true;
            // 
            // Cashier
            // 
            this.Cashier.AutoSize = true;
            this.Cashier.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cashier.Location = new System.Drawing.Point(213, 204);
            this.Cashier.Name = "Cashier";
            this.Cashier.Size = new System.Drawing.Size(63, 33);
            this.Cashier.TabIndex = 228;
            this.Cashier.Text = "كاشير";
            this.Cashier.UseVisualStyleBackColor = true;
            // 
            // Comptable
            // 
            this.Comptable.AutoSize = true;
            this.Comptable.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comptable.Location = new System.Drawing.Point(282, 204);
            this.Comptable.Name = "Comptable";
            this.Comptable.Size = new System.Drawing.Size(68, 33);
            this.Comptable.TabIndex = 229;
            this.Comptable.Text = "محاسب";
            this.Comptable.UseVisualStyleBackColor = true;
            // 
            // EntringData
            // 
            this.EntringData.AutoSize = true;
            this.EntringData.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntringData.Location = new System.Drawing.Point(356, 204);
            this.EntringData.Name = "EntringData";
            this.EntringData.Size = new System.Drawing.Size(101, 33);
            this.EntringData.TabIndex = 230;
            this.EntringData.Text = "مدخل بيانات";
            this.EntringData.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SlNo";
            this.Column1.HeaderText = "الرقم التسلسلى";
            this.Column1.Name = "Column1";
            // 
            // dgvCompanyName
            // 
            this.dgvCompanyName.DataPropertyName = "CompanyName";
            this.dgvCompanyName.HeaderText = "اسم الشركة";
            this.dgvCompanyName.Name = "dgvCompanyName";
            // 
            // DiscountValue
            // 
            this.DiscountValue.DataPropertyName = "DiscountValue";
            this.DiscountValue.HeaderText = "نسبة الخصم";
            this.DiscountValue.Name = "DiscountValue";
            // 
            // dgmobile
            // 
            this.dgmobile.DataPropertyName = "StartDate";
            this.dgmobile.HeaderText = "بداية الخصم";
            this.dgmobile.Name = "dgmobile";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "EndDate";
            this.Column2.HeaderText = "نهاية الخصم";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "IsActive";
            this.Column3.HeaderText = "مفعل";
            this.Column3.Name = "Column3";
            // 
            // dgvCompanyDiscountID
            // 
            this.dgvCompanyDiscountID.DataPropertyName = "ID";
            this.dgvCompanyDiscountID.HeaderText = "CompanyDiscountID";
            this.dgvCompanyDiscountID.Name = "dgvCompanyDiscountID";
            this.dgvCompanyDiscountID.Visible = false;
            // 
            // Adminfield
            // 
            this.Adminfield.DataPropertyName = "Admin";
            this.Adminfield.HeaderText = "مدير النظام";
            this.Adminfield.Name = "Adminfield";
            this.Adminfield.Visible = false;
            // 
            // Cashierfield
            // 
            this.Cashierfield.DataPropertyName = "Cashier";
            this.Cashierfield.HeaderText = "كاشير";
            this.Cashierfield.Name = "Cashierfield";
            this.Cashierfield.Visible = false;
            // 
            // Comptablefield
            // 
            this.Comptablefield.DataPropertyName = "Comptable";
            this.Comptablefield.HeaderText = "محاسب";
            this.Comptablefield.Name = "Comptablefield";
            this.Comptablefield.Visible = false;
            // 
            // EntringDatafield
            // 
            this.EntringDatafield.DataPropertyName = "EntringData";
            this.EntringDatafield.HeaderText = "مدخل بيانات";
            this.EntringDatafield.Name = "EntringDatafield";
            this.EntringDatafield.Visible = false;
            // 
            // frmCompanyDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 536);
            this.Controls.Add(this.EntringData);
            this.Controls.Add(this.Comptable);
            this.Controls.Add(this.Cashier);
            this.Controls.Add(this.Admin);
            this.Controls.Add(this.ckbIsActive);
            this.Controls.Add(this.dtbEndDate);
            this.Controls.Add(this.dtbStartDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvCusomers);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmCompanyDiscount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خصومات الشركات ";
            this.Load += new System.EventHandler(this.frmCompanyDiscount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.DataGridView dgvCusomers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DateTimePicker dtbStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtbEndDate;
        private System.Windows.Forms.CheckBox ckbIsActive;
        private System.Windows.Forms.CheckBox Admin;
        private System.Windows.Forms.CheckBox Cashier;
        private System.Windows.Forms.CheckBox Comptable;
        private System.Windows.Forms.CheckBox EntringData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCompanyDiscountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adminfield;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cashierfield;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comptablefield;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntringDatafield;
    }
}

