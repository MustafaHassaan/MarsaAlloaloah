using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    public partial class frmReportFilterExpenses : Form
    {
        public frmReportFilterExpenses()
        {
            InitializeComponent();            
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            int selectedSearchItem = 1;

            DateTime dateStart = dtpStart.Value;
            DateTime dateEnd = dtpEnd.Value;


            frmReportPrint frmReportPrint = new frmReportPrint(dateStart, dateEnd, selectedSearchItem, "Expenses");
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
            _ = frmReportPrint.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير المصروفات ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
    }
}
