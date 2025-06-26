using MarsaAlloaloah.CrystalReports;
using MarsaAlloaloah.FrmReports;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using SmartArabXLSX.Office2010.Excel;
using SmartArabXLSX.Vml;
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
    public partial class frmReportFilterLandingPayment : Form
    {
        public frmReportFilterLandingPayment()
        {
            InitializeComponent();
        }

        private void frmReportFilterLandingPayment_Load(object sender, EventArgs e)
        {
            SeaTransportTypeFill();

            DateTime selectedDate = DTP.Value;
            DateTime lastDayOfMonth = new DateTime(
                selectedDate.Year,
                selectedDate.Month,
                DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month));
            DTP.Value = lastDayOfMonth;
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            string selectedSearch = string.Empty;

            if (int.Parse(cmbTypeID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر نوع الواسطة البحرية");
                return;
            }
            if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الواسطة البحرية");
                return;
            }
            try
            {
                dsMarsa Ds = new dsMarsa();

                SQLConn.conn.Close();
                var DTS = DTP.Value.ToString("yyyy-MM-dd");
                //var Cs = Properties.Settings.Default.Connectionstring;
                //SqlConnection Con = new SqlConnection(Cs);
                //var Qur = "SELECT DISTINCT " +
                //          "LandingPaymentTransaction.ID, "+
                //          "LandingPaymentTransaction.PayCash,  "+
                //          "LandingPaymentTransaction.PayCard,  "+
                //          "LandingPaymentTransaction.Date,  "+
                //          "LandingPaymentTransaction.LandingID,  "+
                //          "Landing.Amount,  "+
                //          "Landing.StartDate,  "+
                //          "Landing.EndDate,  "+
                //          "Landing.PaymentDoneToDate,  "+
                //          "SeaTransport.Name as SeaName,  "+
                //          "LandingPaymentTransaction.PaymentDoneToDate as PaymentDateTransaction "+
                //          "FROM LandingPaymentTransaction "+
                //          "INNER JOIN Landing ON LandingPaymentTransaction.LandingID = Landing.ID "+
                //          "INNER JOIN SeaTransport ON Landing.SeaTransportID = SeaTransport.ID "+
                //          "where Landing.SeaTransportID = '"+ int.Parse(cmbSeaTransportID.SelectedValue.ToString())  + "'";
                var Qur = @"Select DISTINCT 
                            Landing.ID,
                            LandingPaymentTransaction.PayCash,
                            LandingPaymentTransaction.PayCard,
                            LandingPaymentTransaction.Date,
                            LandingPaymentTransaction.PaymentDoneToDate as PaymentDateTransaction,
                            Landing.DailyAmount,
                            Landing.Amount,
                            Landing.StartDate,
                            Landing.EndDate,
                            Landing.PaymentDoneToDate,
                            SeaTransport.Name as SeaName
                            From Landing
                            Inner Join SeaTransport
                            ON Landing.SeaTransportID = SeaTransport.ID
                            Left outer JOIN LandingPaymentTransaction 
                            ON LandingPaymentTransaction.LandingID = Landing.ID 
                            where Landing.SeaTransportID = '" + int.Parse(cmbSeaTransportID.SelectedValue.ToString())  + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                while (SQLConn.dr.Read())
                {
                    int ID = Convert.ToInt32(SQLConn.dr["ID"].ToString());

                    string PayCash = SQLConn.dr["PayCash"].ToString();
                    if (PayCash == "")
                    {
                        PayCash = "0";
                    }

                    string PayCard = SQLConn.dr["PayCard"].ToString();
                    if (PayCard == "")
                    {
                        PayCard = "0";
                    }

                    var DT = SQLConn.dr["Date"].ToString();
                    DateTime? Date = null;
                    if (DT != "")
                    {
                        Date = Convert.ToDateTime(DT);
                    }
                    string DTA = SQLConn.dr["PaymentDateTransaction"].ToString();
                    DateTime? PaymentDateTransaction = null;
                    if (DTA != "")
                    {
                        PaymentDateTransaction = Convert.ToDateTime(DTA);
                    }
                    string Amount = SQLConn.dr["Amount"].ToString();
                    //string StartDate = SQLConn.dr["StartDate"].ToString();
                    string DTB = SQLConn.dr["StartDate"].ToString();
                    DateTime? StartDate = null;
                    if (DTB != "")
                    {
                        StartDate = Convert.ToDateTime(DTB);
                    }
                    string EndDate = DTS;

                    //decimal val = 0;
                    //Decimal.TryParse(Amount, out val);
                    var nbdays = (DTP.Value - StartDate.Value).Days;
                    //var Tot = (nbdays + 1) * val;


                    string DTC = SQLConn.dr["EndDate"].ToString();
                    DateTime? EndLandingDate = null;
                    if (DTC != "")
                    {
                        EndLandingDate = Convert.ToDateTime(DTC);
                    }
                    //string PaymentDoneToDate = SQLConn.dr["PaymentDoneToDate"].ToString();
                    //string DTD = SQLConn.dr["PaymentDoneToDate"].ToString();
                    string DTD = SQLConn.dr["EndDate"].ToString();
                    DateTime? PaymentDoneToDate = null;
                    if (DTD != "")
                    {
                        PaymentDoneToDate = Convert.ToDateTime(DTD);
                        
                    }
                    string SeaName = SQLConn.dr["SeaName"].ToString();

                    Ds.LandingPayment.Rows.Add(new object[] {
                        ID,Date, StartDate, EndDate,PaymentDoneToDate,
                        SeaName,Amount,PayCash,PayCard,
                        null,null,PaymentDateTransaction,null,(nbdays+1),EndLandingDate,null,null
                        
                    });
                }
                NewRep NRP = new NewRep();
                rptLandingPayment RLP = new rptLandingPayment();
                RLP.SetDataSource(Ds);
                NRP.FRA.ReportSource = RLP;
                NRP.FRA.Refresh();
                NRP.Show();
                //if (CBA.Checked)
                //{
                //    Qur += " And LandingPaymentTransaction.Date <= '" + DTS + "'";
                //}
                //SQLConn.conn.Close();
                //SqlDataAdapter Da = new SqlDataAdapter(Qur, SQLConn.conn);

                //Da.Fill(Ds, "LandingPayment");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير دفوعات الإرساء", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        /// <summary>
        /// Avoir la liste des type de transport boat types
        /// </summary>
        public void SeaTransportTypeFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM SeaTransportType");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbTypeID.DataSource = dtbl;
                cmbTypeID.ValueMember = "ID";
                cmbTypeID.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }



        public void FillSeaTransportFill(int TypeID)
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"SELECT ID, Name, TypeID FROM SeaTransport Where TypeID = " + TypeID + " And InService = 1 "
                        //+ @"  and ID not IN(
                        //    SELECT      SeaTransport.ID
                        //    FROM         Tickets LEFT OUTER JOIN
                        //    SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID
                        //   WHERE(Tickets.StartDate = CAST(GETDATE() as DATE)) and(EndTime > CONVERT(TIME, SYSDATETIME()))
                        //    ) 
                        + " Order by TypeID, ID, Name ");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbSeaTransportID.DataSource = dtbl;
                cmbSeaTransportID.ValueMember = "ID";
                cmbSeaTransportID.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }

        }

        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();

            if (int.Parse(SelectedValue) > 0)
            {
                FillSeaTransportFill(int.Parse(SelectedValue));
            }
        }

        private void cmbSeaTransportID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedValue = ((DataRowView)cmbSeaTransportID.SelectedItem).Row[0].ToString();
            var Qur = "Select Landing.Contract From Landing " +
                      "where SeaTransportID = '"+ SelectedValue + "'";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            if(SQLConn.dr.Read())
            {
                var data = SQLConn.dr["Contract"].ToString();
                if (data != "")
                {
                    var ISEnded = Convert.ToBoolean(data);
                    if (ISEnded)
                    {
                        DTP.Enabled = false;
                    }
                    else
                    {
                        DTP.Enabled = true;
                    }
                }
                else
                {
                    DTP.Enabled = true;
                }
            }
            else { DTP.Enabled = true; }
        }
    }
}
