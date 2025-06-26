
namespace MarsaAlloaloah.FrmReports
{
    partial class NewRep
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
            this.FRA = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // FRA
            // 
            this.FRA.ActiveViewIndex = -1;
            this.FRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FRA.Cursor = System.Windows.Forms.Cursors.Default;
            this.FRA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FRA.Location = new System.Drawing.Point(0, 0);
            this.FRA.Name = "FRA";
            this.FRA.Size = new System.Drawing.Size(906, 416);
            this.FRA.TabIndex = 0;
            this.FRA.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmRports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 416);
            this.Controls.Add(this.FRA);
            this.MinimizeBox = false;
            this.Name = "FrmRports";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "التقارير";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer FRA;
    }
}