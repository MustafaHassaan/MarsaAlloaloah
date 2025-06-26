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
    public partial class FrmRepExpenses : Form
    {
        public FrmRepExpenses()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var DF = dtpStart.Value.ToString("yyyy-MM-dd");
            var DT = dtpEnd.Value.ToString("yyyy-MM-dd");
            var Cs = Properties.Settings.Default.Connectionstring;
            SqlConnection Con = new SqlConnection(Cs);
            var Qur = @"Select 
                      ExpensesName As EN, 
                      Amount As EA, 
                      Vat As EV, 
                      AmountAfterVAt As EAV, 
                      ExpensesType.ExpensesType As ET, 
                      SeaTransport.Name As EST, "+
                      " '" + DF + "' As Fromdate, "+
                      " '" + DT + "' As Todate, "+
					  @"convert(varchar, Expenses.Date, 105) As ED
                      From Expenses
                      Join ExpensesType
                      On Expenses.ExpensesTypeID = ExpensesType.ID
                      Join SeaTransport
                      On Expenses.SeaTransportID = SeaTransport.ID
                      Where Expenses.Date >= '" + DF+ "' And Expenses.Date <= '" + DT + "'";
            Con.Open();
            SqlDataAdapter Da = new SqlDataAdapter(Qur, Con);
            DataSet Ds = new DataSet();
            Da.Fill(Ds, "EXDt");
            Con.Close();
            NewRep NRP = new NewRep();
            RptExpenvat REV = new RptExpenvat();
            REV.SetDataSource(Ds);
            NRP.FRA.ReportSource = REV;
            NRP.FRA.Refresh();
            NRP.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير المصروفات الضريبي ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
