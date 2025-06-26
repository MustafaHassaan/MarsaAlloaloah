namespace MarsaKanzAbhar
{
    partial class frmBusyBoats
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
            this.dgvbusySeatransport = new System.Windows.Forms.DataGridView();
            this.dgvtxtSlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDurationValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Counter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RestTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvSeaTransportTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvSeaTransportID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbusySeatransport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvbusySeatransport
            // 
            this.dgvbusySeatransport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvbusySeatransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbusySeatransport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtxtSlNo,
            this.Column1,
            this.dgvDurationValue,
            this.dgvStartTime,
            this.dgvEndTime,
            this.Counter,
            this.RestTime,
            this.Column6,
            this.gvSeaTransportTypeID,
            this.gvOrder,
            this.gvSeaTransportID});
            this.dgvbusySeatransport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvbusySeatransport.Location = new System.Drawing.Point(0, 0);
            this.dgvbusySeatransport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvbusySeatransport.Name = "dgvbusySeatransport";
            this.dgvbusySeatransport.RowTemplate.Height = 26;
            this.dgvbusySeatransport.Size = new System.Drawing.Size(845, 429);
            this.dgvbusySeatransport.TabIndex = 196;
            // 
            // dgvtxtSlNo
            // 
            this.dgvtxtSlNo.DataPropertyName = "SlNo";
            this.dgvtxtSlNo.HeaderText = "الرقم التسلسلى";
            this.dgvtxtSlNo.Name = "dgvtxtSlNo";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "الواسطة البحرية";
            this.Column1.Name = "Column1";
            // 
            // dgvDurationValue
            // 
            this.dgvDurationValue.DataPropertyName = "DurationValue";
            this.dgvDurationValue.HeaderText = "المدة";
            this.dgvDurationValue.Name = "dgvDurationValue";
            // 
            // dgvStartTime
            // 
            this.dgvStartTime.DataPropertyName = "StartTime";
            this.dgvStartTime.HeaderText = "من";
            this.dgvStartTime.Name = "dgvStartTime";
            // 
            // dgvEndTime
            // 
            this.dgvEndTime.DataPropertyName = "EndTime";
            this.dgvEndTime.HeaderText = "إلى";
            this.dgvEndTime.Name = "dgvEndTime";
            // 
            // Counter
            // 
            this.Counter.DataPropertyName = "Counter";
            this.Counter.HeaderText = "الوقت المتبقى";
            this.Counter.Name = "Counter";
            // 
            // RestTime
            // 
            this.RestTime.DataPropertyName = "RestTime";
            this.RestTime.HeaderText = "RestTime";
            this.RestTime.Name = "RestTime";
            this.RestTime.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "StartDate";
            this.Column6.HeaderText = "StartDate";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // gvSeaTransportTypeID
            // 
            this.gvSeaTransportTypeID.DataPropertyName = "TypeID";
            this.gvSeaTransportTypeID.HeaderText = "SeaTransportTypeID";
            this.gvSeaTransportTypeID.Name = "gvSeaTransportTypeID";
            this.gvSeaTransportTypeID.Visible = false;
            // 
            // gvOrder
            // 
            this.gvOrder.DataPropertyName = "SeaTransportOrder";
            this.gvOrder.HeaderText = "SeaTransportOrder";
            this.gvOrder.Name = "gvOrder";
            this.gvOrder.Visible = false;
            // 
            // gvSeaTransportID
            // 
            this.gvSeaTransportID.DataPropertyName = "ID";
            this.gvSeaTransportID.HeaderText = "SeaTransportID";
            this.gvSeaTransportID.Name = "gvSeaTransportID";
            this.gvSeaTransportID.Visible = false;
            // 
            // frmBusyBoats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 429);
            this.Controls.Add(this.dgvbusySeatransport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmBusyBoats";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "القوارب المشغولة";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBusyBoats_FormClosed);
            this.Load += new System.EventHandler(this.frmBusyBoats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbusySeatransport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvbusySeatransport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtSlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDurationValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Counter;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvSeaTransportTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvSeaTransportID;
    }
}