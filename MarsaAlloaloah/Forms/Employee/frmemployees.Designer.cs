namespace MarsaAlloaloah
{
    partial class frmemployees
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
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtNID = new System.Windows.Forms.TextBox();
            this.dtpExpireNID = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbJobID = new System.Windows.Forms.ComboBox();
            this.txtHousing = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBaseSalary = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTransportation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalSalary = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.dgvEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgclientname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditDocument = new System.Windows.Forms.Button();
            this.btnDeleteDocument = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnShowDocument = new System.Windows.Forms.Button();
            this.dgvdocuments = new System.Windows.Forms.DataGridView();
            this.DocumentFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageBytes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDocumentName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(119, 127);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(243, 20);
            this.txtMobileNo.TabIndex = 203;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(10, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 29);
            this.label15.TabIndex = 202;
            this.label15.Text = "رقم الجوال:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 29);
            this.label3.TabIndex = 196;
            this.label3.Text = "رقم الهوية:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 29);
            this.label5.TabIndex = 198;
            this.label5.Text = "تاريخ إنتهاء الهوية:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 29);
            this.label1.TabIndex = 197;
            this.label1.Text = "إسم الموظف:";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(119, 23);
            this.txtEmployeeName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(243, 20);
            this.txtEmployeeName.TabIndex = 199;
            // 
            // txtNID
            // 
            this.txtNID.Location = new System.Drawing.Point(119, 57);
            this.txtNID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNID.Name = "txtNID";
            this.txtNID.Size = new System.Drawing.Size(243, 20);
            this.txtNID.TabIndex = 203;
            // 
            // dtpExpireNID
            // 
            this.dtpExpireNID.Location = new System.Drawing.Point(119, 92);
            this.dtpExpireNID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpExpireNID.Name = "dtpExpireNID";
            this.dtpExpireNID.Size = new System.Drawing.Size(201, 20);
            this.dtpExpireNID.TabIndex = 204;
            this.dtpExpireNID.ValueChanged += new System.EventHandler(this.dtpExpireNID_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 29);
            this.label2.TabIndex = 202;
            this.label2.Text = "المهنة:";
            // 
            // cmbJobID
            // 
            this.cmbJobID.FormattingEnabled = true;
            this.cmbJobID.Location = new System.Drawing.Point(119, 162);
            this.cmbJobID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbJobID.Name = "cmbJobID";
            this.cmbJobID.Size = new System.Drawing.Size(243, 21);
            this.cmbJobID.TabIndex = 205;
            this.cmbJobID.SelectedIndexChanged += new System.EventHandler(this.cmbJobID_SelectedIndexChanged);
            // 
            // txtHousing
            // 
            this.txtHousing.Location = new System.Drawing.Point(491, 57);
            this.txtHousing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHousing.Name = "txtHousing";
            this.txtHousing.Size = new System.Drawing.Size(232, 20);
            this.txtHousing.TabIndex = 209;
            this.txtHousing.TextChanged += new System.EventHandler(this.txtSalary_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(389, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 29);
            this.label4.TabIndex = 206;
            this.label4.Text = "بدل سكن:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(389, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 29);
            this.label6.TabIndex = 207;
            this.label6.Text = "الراتب الأساسى:";
            // 
            // txtBaseSalary
            // 
            this.txtBaseSalary.Location = new System.Drawing.Point(491, 23);
            this.txtBaseSalary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBaseSalary.Name = "txtBaseSalary";
            this.txtBaseSalary.Size = new System.Drawing.Size(232, 20);
            this.txtBaseSalary.TabIndex = 208;
            this.txtBaseSalary.TextChanged += new System.EventHandler(this.txtSalary_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(389, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 29);
            this.label7.TabIndex = 206;
            this.label7.Text = "بدل مواصلات:";
            // 
            // txtTransportation
            // 
            this.txtTransportation.Location = new System.Drawing.Point(491, 92);
            this.txtTransportation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTransportation.Name = "txtTransportation";
            this.txtTransportation.Size = new System.Drawing.Size(232, 20);
            this.txtTransportation.TabIndex = 209;
            this.txtTransportation.TextChanged += new System.EventHandler(this.txtSalary_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(530, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 29);
            this.label8.TabIndex = 206;
            this.label8.Text = "إجمالى الراتب:";
            // 
            // lblTotalSalary
            // 
            this.lblTotalSalary.AutoSize = true;
            this.lblTotalSalary.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblTotalSalary.Location = new System.Drawing.Point(631, 126);
            this.lblTotalSalary.Name = "lblTotalSalary";
            this.lblTotalSalary.Size = new System.Drawing.Size(28, 13);
            this.lblTotalSalary.TabIndex = 210;
            this.lblTotalSalary.Text = "0.00";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(477, 153);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 29);
            this.linkLabel1.TabIndex = 211;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "السائقين";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvEmployeeID,
            this.Column1,
            this.dataGridViewTextBoxColumn2,
            this.dgclientname,
            this.dgmobile,
            this.dgnid,
            this.dataGridViewTextBoxColumn1,
            this.Column19,
            this.Column18,
            this.Column17,
            this.Column16,
            this.Column15});
            this.dgvEmployee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEmployee.Location = new System.Drawing.Point(0, 346);
            this.dgvEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowTemplate.Height = 26;
            this.dgvEmployee.Size = new System.Drawing.Size(1250, 215);
            this.dgvEmployee.TabIndex = 215;
            this.dgvEmployee.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellDoubleClick);
            // 
            // dgvEmployeeID
            // 
            this.dgvEmployeeID.DataPropertyName = "ID";
            this.dgvEmployeeID.HeaderText = "ID";
            this.dgvEmployeeID.Name = "dgvEmployeeID";
            this.dgvEmployeeID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "JobID";
            this.Column1.HeaderText = "JobID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SlNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "الرقم التسلسلى";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dgclientname
            // 
            this.dgclientname.DataPropertyName = "Name";
            this.dgclientname.HeaderText = "اسم الموظف";
            this.dgclientname.Name = "dgclientname";
            // 
            // dgmobile
            // 
            this.dgmobile.DataPropertyName = "NID";
            this.dgmobile.HeaderText = "رقم الهوية";
            this.dgmobile.Name = "dgmobile";
            // 
            // dgnid
            // 
            this.dgnid.DataPropertyName = "NIDExpireDate";
            this.dgnid.HeaderText = "تاريخ انتهاء الهوية";
            this.dgnid.Name = "dgnid";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Mobile";
            this.dataGridViewTextBoxColumn1.HeaderText = "رقم الجوال";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "JobName";
            this.Column19.HeaderText = "المهنة";
            this.Column19.Name = "Column19";
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "BaseSalary";
            this.Column18.HeaderText = "الراتب الاساسى";
            this.Column18.Name = "Column18";
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "Housing";
            this.Column17.HeaderText = "بدل سكن";
            this.Column17.Name = "Column17";
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "Transportation";
            this.Column16.HeaderText = "بدل مواصلات";
            this.Column16.Name = "Column16";
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "TotalSalary";
            this.Column15.HeaderText = "اجمالى الراتب";
            this.Column15.Name = "Column15";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditDocument);
            this.groupBox1.Controls.Add(this.btnDeleteDocument);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnShowDocument);
            this.groupBox1.Controls.Add(this.dgvdocuments);
            this.groupBox1.Controls.Add(this.btnSelectFile);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtDocumentName);
            this.groupBox1.Location = new System.Drawing.Point(732, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(538, 324);
            this.groupBox1.TabIndex = 216;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "المستندات";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnEditDocument
            // 
            this.btnEditDocument.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEditDocument.FlatAppearance.BorderSize = 0;
            this.btnEditDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDocument.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDocument.ForeColor = System.Drawing.Color.Black;
            this.btnEditDocument.Location = new System.Drawing.Point(366, 271);
            this.btnEditDocument.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnEditDocument.Name = "btnEditDocument";
            this.btnEditDocument.Size = new System.Drawing.Size(85, 27);
            this.btnEditDocument.TabIndex = 227;
            this.btnEditDocument.Text = "تعديل";
            this.btnEditDocument.UseVisualStyleBackColor = false;
            this.btnEditDocument.Click += new System.EventHandler(this.btnEditDocument_Click);
            // 
            // btnDeleteDocument
            // 
            this.btnDeleteDocument.BackColor = System.Drawing.Color.Salmon;
            this.btnDeleteDocument.FlatAppearance.BorderSize = 0;
            this.btnDeleteDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDocument.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDocument.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteDocument.Location = new System.Drawing.Point(274, 271);
            this.btnDeleteDocument.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnDeleteDocument.Name = "btnDeleteDocument";
            this.btnDeleteDocument.Size = new System.Drawing.Size(85, 27);
            this.btnDeleteDocument.TabIndex = 226;
            this.btnDeleteDocument.Text = "حذف";
            this.btnDeleteDocument.UseVisualStyleBackColor = false;
            this.btnDeleteDocument.Click += new System.EventHandler(this.btnDeleteDocument_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(90, 271);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 27);
            this.btnPrint.TabIndex = 224;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnShowDocument
            // 
            this.btnShowDocument.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnShowDocument.FlatAppearance.BorderSize = 0;
            this.btnShowDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowDocument.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDocument.ForeColor = System.Drawing.Color.Black;
            this.btnShowDocument.Location = new System.Drawing.Point(182, 271);
            this.btnShowDocument.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnShowDocument.Name = "btnShowDocument";
            this.btnShowDocument.Size = new System.Drawing.Size(85, 27);
            this.btnShowDocument.TabIndex = 225;
            this.btnShowDocument.Text = "عرض";
            this.btnShowDocument.UseVisualStyleBackColor = false;
            this.btnShowDocument.Click += new System.EventHandler(this.btnShowDocument_Click);
            // 
            // dgvdocuments
            // 
            this.dgvdocuments.AllowUserToAddRows = false;
            this.dgvdocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentFile,
            this.DocumentName,
            this.Notes,
            this.ImageBytes,
            this.Column3});
            this.dgvdocuments.Location = new System.Drawing.Point(26, 76);
            this.dgvdocuments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvdocuments.Name = "dgvdocuments";
            this.dgvdocuments.RowTemplate.Height = 26;
            this.dgvdocuments.Size = new System.Drawing.Size(487, 179);
            this.dgvdocuments.TabIndex = 223;
            // 
            // DocumentFile
            // 
            this.DocumentFile.DataPropertyName = "DocumentFile";
            this.DocumentFile.HeaderText = "اسم الملف";
            this.DocumentFile.Name = "DocumentFile";
            // 
            // DocumentName
            // 
            this.DocumentName.DataPropertyName = "DocumentName";
            this.DocumentName.HeaderText = "اسم المستند";
            this.DocumentName.Name = "DocumentName";
            // 
            // Notes
            // 
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "ملاحظات";
            this.Notes.Name = "Notes";
            // 
            // ImageBytes
            // 
            this.ImageBytes.DataPropertyName = "ImageBytes";
            this.ImageBytes.HeaderText = "ImageBytes";
            this.ImageBytes.Name = "ImageBytes";
            this.ImageBytes.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ID";
            this.Column3.HeaderText = "ID";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFile.Location = new System.Drawing.Point(73, 28);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(79, 27);
            this.btnSelectFile.TabIndex = 222;
            this.btnSelectFile.Text = "اختر الملف";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(441, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 29);
            this.label19.TabIndex = 219;
            this.label19.Text = "اسم المستند:";
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.Location = new System.Drawing.Point(158, 33);
            this.txtDocumentName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.Size = new System.Drawing.Size(279, 20);
            this.txtDocumentName.TabIndex = 221;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(394, 309);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 231;
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
            this.btnDelete.Location = new System.Drawing.Point(302, 309);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 230;
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
            this.btnSave.Location = new System.Drawing.Point(118, 309);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 228;
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
            this.btnClear.Location = new System.Drawing.Point(210, 309);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 229;
            this.btnClear.Text = "مسح";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmemployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 561);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTotalSalary);
            this.Controls.Add(this.txtTransportation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHousing);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBaseSalary);
            this.Controls.Add(this.cmbJobID);
            this.Controls.Add(this.dtpExpireNID);
            this.Controls.Add(this.txtNID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmployeeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmemployees";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الموظفين";
            this.Load += new System.EventHandler(this.frmemployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdocuments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtNID;
        private System.Windows.Forms.DateTimePicker dtpExpireNID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbJobID;
        private System.Windows.Forms.TextBox txtHousing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBaseSalary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTransportation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalSalary;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEditDocument;
        private System.Windows.Forms.Button btnDeleteDocument;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnShowDocument;
        private System.Windows.Forms.DataGridView dgvdocuments;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageBytes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDocumentName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgclientname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
    }
}