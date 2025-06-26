namespace MarsaAlloaloah
{
    partial class frmlanding
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpContractStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpContractEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTypeID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSeaTransportID = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.CBA = new System.Windows.Forms.CheckBox();
            this.DTP = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmbowner = new System.Windows.Forms.ComboBox();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drivername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DailyAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contract = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Endcontract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(310, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "تاريخ بداية الإرساء:";
            // 
            // dtpContractStartDate
            // 
            this.dtpContractStartDate.Location = new System.Drawing.Point(452, 6);
            this.dtpContractStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpContractStartDate.Name = "dtpContractStartDate";
            this.dtpContractStartDate.Size = new System.Drawing.Size(223, 20);
            this.dtpContractStartDate.TabIndex = 3;
            // 
            // dtpContractEndDate
            // 
            this.dtpContractEndDate.Location = new System.Drawing.Point(452, 39);
            this.dtpContractEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpContractEndDate.Name = "dtpContractEndDate";
            this.dtpContractEndDate.Size = new System.Drawing.Size(223, 20);
            this.dtpContractEndDate.TabIndex = 5;
            this.dtpContractEndDate.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(310, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "تاريخ نهاية الإرساء:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(135, 70);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(172, 20);
            this.txtAmount.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "قيمة الإرساء:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(467, 140);
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
            this.btnDelete.Location = new System.Drawing.Point(375, 140);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 274;
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
            this.btnSave.Location = new System.Drawing.Point(191, 140);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 272;
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
            this.btnClear.Location = new System.Drawing.Point(283, 140);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 273;
            this.btnClear.Text = "مسح";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 29);
            this.label5.TabIndex = 278;
            this.label5.Text = "نوع الواسطة البحرية:";
            // 
            // cmbTypeID
            // 
            this.cmbTypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbTypeID.FormattingEnabled = true;
            this.cmbTypeID.Location = new System.Drawing.Point(135, 6);
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
            this.label6.Location = new System.Drawing.Point(12, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 29);
            this.label6.TabIndex = 279;
            this.label6.Text = "الواسطة البحرية:";
            // 
            // cmbSeaTransportID
            // 
            this.cmbSeaTransportID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbSeaTransportID.FormattingEnabled = true;
            this.cmbSeaTransportID.Location = new System.Drawing.Point(135, 39);
            this.cmbSeaTransportID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSeaTransportID.Name = "cmbSeaTransportID";
            this.cmbSeaTransportID.Size = new System.Drawing.Size(172, 21);
            this.cmbSeaTransportID.TabIndex = 277;
            this.cmbSeaTransportID.SelectedIndexChanged += new System.EventHandler(this.cmbSeaTransportID_SelectedIndexChanged);
            this.cmbSeaTransportID.SelectionChangeCommitted += new System.EventHandler(this.cmbSeaTransportID_SelectionChangeCommitted);
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column1,
            this.Drivername,
            this.Column3,
            this.DailyAmount,
            this.Column2,
            this.Column4,
            this.Contract,
            this.Endcontract});
            this.dgvData.Location = new System.Drawing.Point(12, 186);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(728, 208);
            this.dgvData.TabIndex = 280;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // CBA
            // 
            this.CBA.AutoSize = true;
            this.CBA.Location = new System.Drawing.Point(452, 108);
            this.CBA.Name = "CBA";
            this.CBA.Size = new System.Drawing.Size(121, 17);
            this.CBA.TabIndex = 281;
            this.CBA.Text = "تم انتهاء عقد الارساء";
            this.CBA.UseVisualStyleBackColor = true;
            this.CBA.CheckedChanged += new System.EventHandler(this.CBA_CheckedChanged);
            // 
            // DTP
            // 
            this.DTP.Location = new System.Drawing.Point(452, 70);
            this.DTP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DTP.Name = "DTP";
            this.DTP.Size = new System.Drawing.Size(223, 20);
            this.DTP.TabIndex = 282;
            this.DTP.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 29);
            this.label1.TabIndex = 283;
            this.label1.Text = "المالك :";
            // 
            // Cmbowner
            // 
            this.Cmbowner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Cmbowner.FormattingEnabled = true;
            this.Cmbowner.Location = new System.Drawing.Point(135, 106);
            this.Cmbowner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cmbowner.Name = "Cmbowner";
            this.Cmbowner.Size = new System.Drawing.Size(172, 21);
            this.Cmbowner.TabIndex = 284;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ID";
            this.Column5.HeaderText = "ID";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "SeaTransportType";
            this.Column6.HeaderText = "نوع الواسطة البحرية";
            this.Column6.Name = "Column6";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "الواسطة البحرية";
            this.Column1.Name = "Column1";
            // 
            // Drivername
            // 
            this.Drivername.DataPropertyName = "Drivername";
            this.Drivername.HeaderText = "المالك";
            this.Drivername.Name = "Drivername";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Amount";
            this.Column3.HeaderText = "قيمة الإرساء";
            this.Column3.Name = "Column3";
            // 
            // DailyAmount
            // 
            this.DailyAmount.DataPropertyName = "DailyAmount";
            this.DailyAmount.HeaderText = "اليومية";
            this.DailyAmount.Name = "DailyAmount";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "StartDate";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column2.HeaderText = "تاريخ بداية الإرساء ";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "EndDate";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column4.HeaderText = "تاريخ نهاية الإرساء";
            this.Column4.Name = "Column4";
            // 
            // Contract
            // 
            this.Contract.DataPropertyName = "Contract";
            this.Contract.HeaderText = "العقد";
            this.Contract.Name = "Contract";
            // 
            // Endcontract
            // 
            this.Endcontract.DataPropertyName = "Endcontract";
            this.Endcontract.HeaderText = "نهاية العقد";
            this.Endcontract.Name = "Endcontract";
            // 
            // frmlanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 406);
            this.Controls.Add(this.Cmbowner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTP);
            this.Controls.Add(this.CBA);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTypeID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSeaTransportID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpContractEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpContractStartDate);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmlanding";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الإرساءات - عقد الإرساء";
            this.Load += new System.EventHandler(this.frmlanding_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpContractStartDate;
        private System.Windows.Forms.DateTimePicker dtpContractEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTypeID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSeaTransportID;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.CheckBox CBA;
        private System.Windows.Forms.DateTimePicker DTP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmbowner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drivername;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DailyAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Contract;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endcontract;
    }
}