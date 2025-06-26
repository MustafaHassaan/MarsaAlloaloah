namespace MarsaAlloaloah
{
    partial class frmprice
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
            this.dgvPriceGroupChange = new System.Windows.Forms.DataGridView();
            this.cmbPriceGroup = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeaTransportTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashierCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashierExternCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupprBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceGroupChange)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "اسم مجموعة التسعير:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvPriceGroupChange
            // 
            this.dgvPriceGroupChange.AllowUserToAddRows = false;
            this.dgvPriceGroupChange.AllowUserToDeleteRows = false;
            this.dgvPriceGroupChange.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPriceGroupChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceGroupChange.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SeaTransportTypeID,
            this.gvDuration,
            this.SlNo,
            this.Duration,
            this.Price,
            this.Percentage,
            this.DriverCommission,
            this.CashierCommission,
            this.CashierExternCommission,
            this.SupprBtn});
            this.dgvPriceGroupChange.Location = new System.Drawing.Point(17, 68);
            this.dgvPriceGroupChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPriceGroupChange.MultiSelect = false;
            this.dgvPriceGroupChange.Name = "dgvPriceGroupChange";
            this.dgvPriceGroupChange.ReadOnly = true;
            this.dgvPriceGroupChange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPriceGroupChange.RowTemplate.Height = 26;
            this.dgvPriceGroupChange.Size = new System.Drawing.Size(614, 264);
            this.dgvPriceGroupChange.TabIndex = 206;
            this.dgvPriceGroupChange.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPriceGroupChange_CellContentClick);
            // 
            // cmbPriceGroup
            // 
            this.cmbPriceGroup.DisplayMember = "Name";
            this.cmbPriceGroup.FormattingEnabled = true;
            this.cmbPriceGroup.Location = new System.Drawing.Point(204, 20);
            this.cmbPriceGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPriceGroup.Name = "cmbPriceGroup";
            this.cmbPriceGroup.Size = new System.Drawing.Size(320, 21);
            this.cmbPriceGroup.TabIndex = 207;
            this.cmbPriceGroup.ValueMember = "ID";
            this.cmbPriceGroup.SelectedIndexChanged += new System.EventHandler(this.cbPriceGroup_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(418, 356);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 241;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(235, 356);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 238;
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
            this.btnClear.Location = new System.Drawing.Point(326, 356);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 239;
            this.btnClear.Text = "مسح";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(144, 356);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 242;
            this.button1.Text = "اضافة";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // SeaTransportTypeID
            // 
            this.SeaTransportTypeID.DataPropertyName = "SeaTransportTypeID";
            this.SeaTransportTypeID.HeaderText = "SeaTransportTypeID";
            this.SeaTransportTypeID.Name = "SeaTransportTypeID";
            this.SeaTransportTypeID.ReadOnly = true;
            this.SeaTransportTypeID.Visible = false;
            // 
            // gvDuration
            // 
            this.gvDuration.HeaderText = "Duration";
            this.gvDuration.Name = "gvDuration";
            this.gvDuration.ReadOnly = true;
            this.gvDuration.Visible = false;
            // 
            // SlNo
            // 
            this.SlNo.DataPropertyName = "SlNo";
            this.SlNo.FillWeight = 135.8577F;
            this.SlNo.HeaderText = "الرقم التسلسلى";
            this.SlNo.Name = "SlNo";
            this.SlNo.ReadOnly = true;
            // 
            // Duration
            // 
            this.Duration.DataPropertyName = "Duration";
            this.Duration.FillWeight = 53.30196F;
            this.Duration.HeaderText = "المدة الزمنية";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.FillWeight = 54.11712F;
            this.Price.HeaderText = "السعر";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Percentage
            // 
            this.Percentage.DataPropertyName = "Percentage";
            this.Percentage.HeaderText = "النسبه";
            this.Percentage.Name = "Percentage";
            this.Percentage.ReadOnly = true;
            // 
            // DriverCommission
            // 
            this.DriverCommission.DataPropertyName = "DriverCommission";
            this.DriverCommission.HeaderText = "عمولة السائق";
            this.DriverCommission.Name = "DriverCommission";
            this.DriverCommission.ReadOnly = true;
            // 
            // CashierCommission
            // 
            this.CashierCommission.DataPropertyName = "CashierCommission";
            this.CashierCommission.FillWeight = 84.63938F;
            this.CashierCommission.HeaderText = "عمولة الكاشير";
            this.CashierCommission.Name = "CashierCommission";
            this.CashierCommission.ReadOnly = true;
            // 
            // CashierExternCommission
            // 
            this.CashierExternCommission.DataPropertyName = "CashierExternCommission";
            this.CashierExternCommission.FillWeight = 176.8584F;
            this.CashierExternCommission.HeaderText = "عمولة كاشير مراكب خارجية";
            this.CashierExternCommission.Name = "CashierExternCommission";
            this.CashierExternCommission.ReadOnly = true;
            // 
            // SupprBtn
            // 
            this.SupprBtn.FillWeight = 30.50463F;
            this.SupprBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SupprBtn.HeaderText = "";
            this.SupprBtn.Name = "SupprBtn";
            this.SupprBtn.ReadOnly = true;
            this.SupprBtn.Text = "حذف";
            this.SupprBtn.UseColumnTextForButtonValue = true;
            // 
            // frmprice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 395);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbPriceGroup);
            this.Controls.Add(this.dgvPriceGroupChange);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmprice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مجموعة التسعير";
            this.Load += new System.EventHandler(this.frmprice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceGroupChange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPriceGroupChange;
        private System.Windows.Forms.ComboBox cmbPriceGroup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeaTransportTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierExternCommission;
        private System.Windows.Forms.DataGridViewButtonColumn SupprBtn;
    }
}