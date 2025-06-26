
namespace MarsaAlloaloah.Forms.Returned
{
    partial class Retrepform
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
            this.RCR = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RCR
            // 
            this.RCR.ActiveViewIndex = -1;
            this.RCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RCR.Cursor = System.Windows.Forms.Cursors.Default;
            this.RCR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RCR.Location = new System.Drawing.Point(0, 0);
            this.RCR.Name = "RCR";
            this.RCR.Size = new System.Drawing.Size(800, 522);
            this.RCR.TabIndex = 0;
            this.RCR.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Retrepform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 522);
            this.Controls.Add(this.RCR);
            this.Name = "Retrepform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ايصال المرتجعات";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer RCR;
    }
}