using MarsaAlloaloah.CrystalReports;
using MarsaAlloaloah.FrmReports;
using MarsaAlloaloah.Utility.Ado.net;
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

namespace MarsaAlloaloah
{
    public partial class frmReportGeneral : Form
    {
        public frmReportGeneral()
        {
            InitializeComponent();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            rptGeneralReport GR = new rptGeneralReport();
            NewRep FRP = new NewRep();

            dsMarsa Dsm = new dsMarsa();
            var Dts = dtpStart.Value.ToString("MM-dd-yy");
            var Dte = dtpEnd.Value.ToString("MM-dd-yy");
            //Tickets Done
            var Qurtickets = @"SELECT 
                               ISNULL(sum(Tickets.PayCash),0) as TicPayCash, 
                               ISNULL(sum(Tickets.PayCard),0) as TicPayCard,
                               ISNULL(sum(Tickets.Paytamara),0) as TicPayTamara,
                               ISNULL(sum(Tickets.Paytransfer),0) as TicPayTrans
                               FROM Tickets
                               WHERE tickets.startDate >= '" + Dts + "' "+ 
                              "And tickets.startDate <= '"+ Dte +"' ";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qurtickets, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.cmd.CommandText = Qurtickets;
            SQLConn.cmd.Connection = SQLConn.conn;
            SQLConn.cmd.CommandType = CommandType.Text;
            SQLConn.da.SelectCommand = SQLConn.cmd;
            SQLConn.da.Fill(Dsm, "Qurtickets");

            //var Qurincomefromcashier = @"SELECT   
            //                             sum(IncomeFromCashier.PayCash) as ICPayCash , 
            //                             sum(IncomeFromCashier.PayCard) as ICPayCard
            //                             FROM IncomeFromCashier 
            //                             Where (IncomeFromCashier.StartDate >= '" + Dts + "' ) "+
            //                            "and (IncomeFromCashier.StartDate <= '" + Dte + "' )";
            //SQLConn.ConnDB();
            //SQLConn.cmd = new SqlCommand(Qurincomefromcashier, SQLConn.conn);
            //SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            //SQLConn.cmd.CommandText = Qurincomefromcashier;
            //SQLConn.cmd.Connection = SQLConn.conn;
            //SQLConn.cmd.CommandType = CommandType.Text;
            //SQLConn.da.SelectCommand = SQLConn.cmd;
            //SQLConn.da.Fill(Dsm, "Qurincomefromcashier");

            //Income Done
            var Qurincome = @"SELECT 
                              ISNULL(sum(Income.AmountAfterVAT),0) as Incamount
                              FROM  Income 
                              Where 
                              Income.Date >= '" + Dts + "' and Income.Date <= '"+ Dte +"'";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qurincome, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.cmd.CommandText = Qurincome;
            SQLConn.cmd.Connection = SQLConn.conn;
            SQLConn.cmd.CommandType = CommandType.Text;
            SQLConn.da.SelectCommand = SQLConn.cmd;
            SQLConn.da.Fill(Dsm, "Qurincome");

            //Expenses Done
            var Qurexpences = @"SELECT 
                                ISNULL(Sum(Expenses.AmountAfterVAT),0) as Expamount
                                FROM Expenses  
                                Where Expenses.Date >= '" + Dts + "' And Expenses.Date <= '"+ Dte +"' ";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qurexpences, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.cmd.CommandText = Qurexpences;
            SQLConn.cmd.Connection = SQLConn.conn;
            SQLConn.cmd.CommandType = CommandType.Text;
            SQLConn.da.SelectCommand = SQLConn.cmd;
            SQLConn.da.Fill(Dsm, "Qurexpences");

            //Landing
            var Qurlandingpayment = @"SELECT 
                                      ISNULL(Sum(LandingPaymentTransaction.PayCash),0) as LandPayCash, 
                                      ISNULL(Sum(LandingPaymentTransaction.PayCard),0) as LandPayCard
                                      FROM LandingPaymentTransaction 
                                      INNER JOIN Landing 
                                      ON LandingPaymentTransaction.LandingID = Landing.ID 
                                      INNER JOIN SeaTransport 
                                      ON Landing.SeaTransportID = SeaTransport.ID 
                                      LEFT OUTER JOIN Drivers 
                                      ON SeaTransport.OwnerID = Drivers.ID 
                                      LEFT OUTER JOIN BankAccountTransactions 
                                      ON LandingPaymentTransaction.ID = BankAccountTransactions.LandingPaymentID 
                                      LEFT OUTER JOIN BankAccounts 
                                      ON BankAccountTransactions.BankID = BankAccounts.ID 
                                      WHERE LandingPaymentTransaction.Date >= '" + Dts + "' and LandingPaymentTransaction.Date <= '" + Dte + "' ";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qurlandingpayment, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.cmd.CommandText = Qurlandingpayment;
            SQLConn.cmd.Connection = SQLConn.conn;
            SQLConn.cmd.CommandType = CommandType.Text;
            SQLConn.da.SelectCommand = SQLConn.cmd;
            SQLConn.da.Fill(Dsm, "Qurlandingpayment");

            //Done
            var Qurticketreturned = @"Select 
                                      ISNULL(-Sum(Tickets.PayCash),0) As RTPayCash,
                                      ISNULL(-Sum(Tickets.PayCard),0) As RTPayCard,
									  ISNULL(-Sum(Tickets.Paytamara),0) As RTPaytamara,
									  ISNULL(-Sum(Tickets.Paytransfer),0) As RTPaytransfer
                                      From Tickets
                                      Left Outer Join Returned
                                      On Tickets.ID = Returned.Invoiceid
                                      Where Tickets.ID IN (Select Invoiceid from Returned) 
                                      And tickets.startDate >= '" + Dts +"' And tickets.startDate <= '"+ Dte +"'";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qurticketreturned, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.cmd.CommandText = Qurticketreturned;
            SQLConn.cmd.Connection = SQLConn.conn;
            SQLConn.cmd.CommandType = CommandType.Text;
            SQLConn.da.SelectCommand = SQLConn.cmd;
            SQLConn.da.Fill(Dsm, "Qurticketreturned");


            //Done
            var Qurlandingtreturned = @"SELECT  
                                        ISNULL(-sum(LandingPaymentTransaction.PayCash),0) as RLPayCash, 
                                        ISNULL(-sum(LandingPaymentTransaction.PayCard),0) as RLPayCard,
                                        ISNULL(-sum(LandingPaymentTransaction.Paytamara),0) as RLPaytamara,
                                        ISNULL(-sum(LandingPaymentTransaction.Paytranse),0) as RLPaytranse
                                        FROM LandingPaymentTransaction 
                                        INNER JOIN Landing 
                                        ON LandingPaymentTransaction.LandingID = Landing.ID 
                                        INNER JOIN SeaTransport 
                                        ON Landing.SeaTransportID = SeaTransport.ID 
                                        LEFT OUTER JOIN Drivers 
                                        ON SeaTransport.OwnerID = Drivers.ID 
                                        LEFT OUTER JOIN BankAccountTransactions 
                                        ON LandingPaymentTransaction.ID = BankAccountTransactions.LandingPaymentID 
                                        LEFT OUTER JOIN BankAccounts 
                                        ON BankAccountTransactions.BankID = BankAccounts.ID 
                                        WHERE LandingPaymentTransaction.Date >= '" + Dts +"' And LandingPaymentTransaction.Date <= '"+ Dte+"' ";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qurlandingtreturned, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.cmd.CommandText = Qurlandingtreturned;
            SQLConn.cmd.Connection = SQLConn.conn;
            SQLConn.cmd.CommandType = CommandType.Text;
            SQLConn.da.SelectCommand = SQLConn.cmd;
            SQLConn.da.Fill(Dsm, "Qurlandingtreturned");
            GR.SetDataSource(Dsm);
            GR.SetParameterValue("DateReport", Dts);
            FRP.FRA.ReportSource = GR;
            FRP.FRA.Refresh();
            FRP.Show();

            // DateTime dateStart = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day);
            //            string d = dtpStart.Value.ToShortDateString();
            //            DateTime dateS = DateTime.Parse(d);


            //            // DateTime dateEnd = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day);
            //            string ds = dtpEnd.Value.ToShortDateString();
            //            DateTime dateE = DateTime.Parse(ds);

            //            frmReportPrint frmReportPrint = new frmReportPrint(dateS, dateE, "GeneralReport");
            //#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
            //            _ = frmReportPrint.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "التقرير الشامل ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
