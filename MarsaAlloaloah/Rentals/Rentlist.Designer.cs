namespace MarsaAlloaloah.Rentals
{
    partial class Rentlist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DTT = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DTF = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ticketid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seatransporttypename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seatransportname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Startdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Starttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dauration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rentstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DTT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DTF);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(894, 105);
            this.groupBox1.TabIndex = 277;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات البحث و الفلترة";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(394, 64);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 30);
            this.btnSearch.TabIndex = 291;
            this.btnSearch.Text = "بحث";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 29);
            this.label3.TabIndex = 283;
            this.label3.Text = "تاريخ الحجز الى : ";
            // 
            // DTT
            // 
            this.DTT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTT.Location = new System.Drawing.Point(22, 30);
            this.DTT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DTT.Name = "DTT";
            this.DTT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTT.RightToLeftLayout = true;
            this.DTT.Size = new System.Drawing.Size(305, 20);
            this.DTT.TabIndex = 281;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(780, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 29);
            this.label1.TabIndex = 280;
            this.label1.Text = "تاريخ الحجز من : ";
            // 
            // DTF
            // 
            this.DTF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTF.Location = new System.Drawing.Point(497, 30);
            this.DTF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DTF.Name = "DTF";
            this.DTF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTF.RightToLeftLayout = true;
            this.DTF.Size = new System.Drawing.Size(277, 20);
            this.DTF.TabIndex = 279;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Ticketid,
            this.Customername,
            this.Seatransporttypename,
            this.Seatransportname,
            this.Rentdate,
            this.Startdate,
            this.Starttime,
            this.Dauration,
            this.Rentstatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(12, 121);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(894, 494);
            this.dataGridView1.TabIndex = 290;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "رقم الحجز";
            this.ID.Name = "ID";
            // 
            // Ticketid
            // 
            this.Ticketid.DataPropertyName = "Ticketid";
            this.Ticketid.HeaderText = "رقم التذكرة";
            this.Ticketid.Name = "Ticketid";
            // 
            // Customername
            // 
            this.Customername.DataPropertyName = "Customername";
            this.Customername.HeaderText = "اسم العميل";
            this.Customername.Name = "Customername";
            // 
            // Seatransporttypename
            // 
            this.Seatransporttypename.DataPropertyName = "Seatransporttypename";
            this.Seatransporttypename.HeaderText = "نوع القارب";
            this.Seatransporttypename.Name = "Seatransporttypename";
            // 
            // Seatransportname
            // 
            this.Seatransportname.DataPropertyName = "Seatransportname";
            this.Seatransportname.HeaderText = "اسم القارب";
            this.Seatransportname.Name = "Seatransportname";
            // 
            // Rentdate
            // 
            this.Rentdate.DataPropertyName = "Rentdate";
            this.Rentdate.HeaderText = "تاريخ الحجز";
            this.Rentdate.Name = "Rentdate";
            // 
            // Startdate
            // 
            this.Startdate.DataPropertyName = "Startdate";
            this.Startdate.HeaderText = "تاريخ الرحلة";
            this.Startdate.Name = "Startdate";
            // 
            // Starttime
            // 
            this.Starttime.DataPropertyName = "Starttime";
            this.Starttime.HeaderText = "وقت الرحلة";
            this.Starttime.Name = "Starttime";
            // 
            // Dauration
            // 
            this.Dauration.DataPropertyName = "Dauration";
            this.Dauration.HeaderText = "المدة الزمنية";
            this.Dauration.Name = "Dauration";
            // 
            // Rentstatus
            // 
            this.Rentstatus.DataPropertyName = "Rentstatus";
            this.Rentstatus.HeaderText = "الحالة";
            this.Rentstatus.Name = "Rentstatus";
            // 
            // Rentlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 627);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Rentlist";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قائمة الحجوزات";
            this.Load += new System.EventHandler(this.Rentlist_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTT;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticketid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customername;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seatransporttypename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seatransportname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Startdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Starttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dauration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentstatus;
        private System.Windows.Forms.Button btnSearch;
    }
}