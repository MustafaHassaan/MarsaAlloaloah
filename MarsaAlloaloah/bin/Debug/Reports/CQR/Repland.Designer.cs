﻿
namespace MarsaAlloaloah.CrystalReports.CQR
{
    partial class Repland
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
            this.CVL = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CVL
            // 
            this.CVL.ActiveViewIndex = -1;
            this.CVL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CVL.Cursor = System.Windows.Forms.Cursors.Default;
            this.CVL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CVL.Location = new System.Drawing.Point(0, 0);
            this.CVL.Name = "CVL";
            this.CVL.Size = new System.Drawing.Size(387, 579);
            this.CVL.TabIndex = 0;
            this.CVL.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Repland
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(387, 579);
            this.Controls.Add(this.CVL);
            this.Name = "Repland";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير دفع الارساء";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CVL;
    }
}