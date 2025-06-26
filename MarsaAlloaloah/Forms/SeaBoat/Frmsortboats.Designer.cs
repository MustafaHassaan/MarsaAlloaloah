namespace MarsaAlloaloah.Forms.SeaBoat
{
    partial class Frmsortboats
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
            this.dgvSeaTransport = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTypeID = new System.Windows.Forms.ComboBox();
            this.dgvtxtSlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeaTransport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSeaTransport
            // 
            this.dgvSeaTransport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeaTransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeaTransport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtxtSlNo,
            this.Column1,
            this.ID});
            this.dgvSeaTransport.Location = new System.Drawing.Point(12, 62);
            this.dgvSeaTransport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSeaTransport.Name = "dgvSeaTransport";
            this.dgvSeaTransport.RowTemplate.Height = 26;
            this.dgvSeaTransport.Size = new System.Drawing.Size(432, 322);
            this.dgvSeaTransport.TabIndex = 214;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Traditional Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 29);
            this.label1.TabIndex = 213;
            this.label1.Text = "نوع الواسطة البحرية:";
            // 
            // cmbTypeID
            // 
            this.cmbTypeID.DisplayMember = "Name";
            this.cmbTypeID.FormattingEnabled = true;
            this.cmbTypeID.Location = new System.Drawing.Point(171, 22);
            this.cmbTypeID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTypeID.Name = "cmbTypeID";
            this.cmbTypeID.Size = new System.Drawing.Size(247, 21);
            this.cmbTypeID.TabIndex = 212;
            this.cmbTypeID.ValueMember = "ID";
            this.cmbTypeID.SelectedIndexChanged += new System.EventHandler(this.cmbTypeID_SelectedIndexChanged);
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
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Frmsortboats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 395);
            this.Controls.Add(this.dgvSeaTransport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTypeID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frmsortboats";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "القوارب المشغولة";
            this.Load += new System.EventHandler(this.Frmsortboats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeaTransport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSeaTransport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtSlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}