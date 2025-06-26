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
    public partial class FrmRepTicketsvat : Form
    {
        public FrmRepTicketsvat()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير التذاكر الضريبي ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
            var Qur = "Select " +
                      "Tickets.ID," +
                      "StartDate, " +
                      "VAT, " +
                      "PriceAfterVAT, " +
                      "Customers.Name As CustomerName " +
                      "From Tickets " +
                      "Join Customers " +
                      "On Tickets.CustomerID = Customers.ID " +
                      "Where StartDate >= '"+ dateStart + "' And StartDate <= '"+ dateEnd + "'";
            Con.Open();
            SqlDataAdapter Da = new SqlDataAdapter(Qur, Con);
            DataSet Ds = new DataSet();
            Da.Fill(Ds, "ClientTicket");
            Con.Close();
            NewRep NRP = new NewRep();
            rptTvat2 RT2 = new rptTvat2();
            RT2.SetDataSource(Ds);
            NRP.FRA.ReportSource = RT2;
            NRP.FRA.Refresh();
            NRP.Show();
        }
    }
}
