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
    public partial class FrmExratios : Form
    {
        public FrmExratios()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير نسب التشغيل الخارجية ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
            var DF = dtpStart.Value.ToShortDateString();
            var DT = dtpEnd.Value.ToShortDateString();
            var Cs = Properties.Settings.Default.Connectionstring;
            SqlConnection Con = new SqlConnection(Cs);
            var Qur = "Select "+
                      "SeaTransport.Name As SeaTransportname, " +
                      "Drivers.Name As Ownername, "+
                      "cast(round(Sum(Tickets.DurationValue) / 60.0, 2) as decimal(18, 2)) As HOD, "+
                      "Cast(Round(Sum(Tickets.PriceAfterVAT) / 1.15, 2)AS numeric(36, 2)) As PriceAfterDiscount, "+
                      "Cast(Round((Sum(Tickets.PriceAfterVAT) / 1.15) * 0.70, 2)As decimal(18, 2)) As POwner, " +
                      "Cast(Round((Sum(Tickets.PriceAfterVAT) / 1.15) * 0.30, 2)As decimal(18, 2)) As PLanding, "+
                      "'" + DF + "' As Fromdate, " +
                      "'" + DT + "' As Todate "+
                      "From Tickets " +
                      "Inner Join SeaTransport "+
                      "On Tickets.SeaTransportID = SeaTransport.ID "+
                      "Inner Join SeaTransportType "+
                      "On Tickets.SeaTransportTypeID = SeaTransportType.ID "+
                      "Inner Join Customers "+
                      "On Tickets.CustomerID = Customers.ID "+
                      "Inner Join Users "+
                      "On Tickets.UserID = Users.ID "+
                      "Inner Join Drivers "+
                      "On SeaTransport.OwnerID = Drivers.ID " +
                      "Left outer Join Returned " +
                      "On Returned.Invoiceid = Tickets.ID " +
                      "Where Tickets.StartDate >= '"+DF+"' And Tickets.StartDate <= '"+DT+ "' And Drivers.IsEmployee = 0 " +
                      "and Tickets.ID Not IN (Select Invoiceid From Returned Where Type='ارتجاع تذكرة') " +
                      "Group By "+
                      "SeaTransport.Name, "+
                      "Drivers.Name";
            Con.Open();
            SqlDataAdapter Da = new SqlDataAdapter(Qur, Con);
            DataSet Ds = new DataSet();
            Da.Fill(Ds, "EOR");
            Con.Close();
            NewRep NRP = new NewRep();
            Rpteor REO = new Rpteor();
            REO.SetDataSource(Ds);
            NRP.FRA.ReportSource = REO;
            NRP.FRA.Refresh();
            NRP.Show();
        }
    }
}
