using MarsaAlloaloah.CrystalReports;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah.FrmReports
{
    public partial class FrmRepIncom : Form
    {
        public FrmRepIncom()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير الايرادات الضريبي ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dateStart = dtpStart.Value;
            DateTime dateEnd = dtpEnd.Value;
            var Cs = Properties.Settings.Default.Connectionstring;
            SqlConnection Con = new SqlConnection(Cs);
            var Qur = "SELECT " +
                      "Income.ID, " +
                      "Income.IncomeName, " +
                      "Income.Description, " +
                      "Income.Amount, " +
                      "Income.VAT, " +
                      "Income.AmountAfterVAT, " +
                      "Income.IncomeTypeID, " +
                      "IncomeType.Name AS IncomeType, " +
                      "Income.IsTaxInvoice, " +
                      "Income.Date " +
                      "FROM  IncomeType " +
                      "INNER JOIN Income " +
                      "ON IncomeType.ID = Income.IncomeTypeID " +
                      "Where Income.Date >= '" + dateStart + "' " +
                      "and Income.Date <= '" + dateEnd + "'"; 
            Con.Open();
            SqlDataAdapter Da = new SqlDataAdapter(Qur, Con);
            DataSet Ds = new DataSet();
            Da.Fill(Ds, "Income");
            Con.Close();
            NewRep NRP = new NewRep();
            rptTvat RT = new rptTvat();
            RT.SetDataSource(Ds);
            NRP.FRA.ReportSource = RT;
            NRP.FRA.Refresh();
            NRP.Show();
        }
    }
}
