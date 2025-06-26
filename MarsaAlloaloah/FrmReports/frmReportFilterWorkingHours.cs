using MarsaAlloaloah.CrystalReports;
using MarsaAlloaloah.CrystalReports.CQR;
using MarsaAlloaloah.FrmReports;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using SmartArabXLSX.Vml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    public partial class frmReportFilterWorkingHours : Form
    {
        public frmReportFilterWorkingHours()
        {
            InitializeComponent();
        }

        private void frmReportFilterWorkingHours_Load(object sender, EventArgs e)
        {
            SeaTransportTypeFill();
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

            selectedSearch = cmbSeaTransportID.SelectedValue.ToString();
            DateTime dateStart = dtpStart.Value;
            DateTime dateEnd = dtpEnd.Value;
            //            frmReportPrint frmReportPrint = new frmReportPrint(dateStart, dateEnd, selectedSearch, "SeaTransportWorkingHours");
            //#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
            //            _ = frmReportPrint.ShowDialog();
            string query = @"SELECT DISTINCT SeaTransport.Name,Tickets.ID, Tickets.StartDate AS StartDateTicket, 
                                CAST(Tickets.StartTime AS time(0)) AS StartTimeTicket, Price.Duration, 
                                Customers.Name AS CustomerName,   Drivers.Name AS DriverName, 
                         Tickets.PriceAfterDiscount,Tickets.PriceAfterVAT as PriceTicketAfterVAT,
                         Price.CashierCommission as CashierAmount, Price.CashierExternCommission, 
                        Tickets.DurationValue as 'AccountantAmount',
                      SeaTransport.OwnerID, SeaTransport.OwnerTypeID
                       FROM         Tickets INNER JOIN
                      Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                      SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID INNER JOIN
                      Price ON Tickets.DurationID = Price.ID INNER JOIN
                      SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID INNER JOIN
                      Drivers ON Tickets.DriverID = Drivers.ID where SeaTransport.ID = " + selectedSearch
                                   + @" and ( Tickets.StartDate <= '" + dateEnd +"' "+
                                   @" and  Tickets.StartDate >= '" + dateStart + "')  Order by Tickets.StartDate desc";

            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(query, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            dsMarsa Ds = new dsMarsa();
            rptSeaTransportWorkingHours RSTWH = new rptSeaTransportWorkingHours();
            Frmreports BF = new Frmreports();
            TimeSpan Timeres = new TimeSpan();
            TimeSpan Mresult;
            TimeSpan Hresult;
            TimeSpan RTime = new TimeSpan();
            string GTF = "";
            var TM = 0;
            int TMI = 0;
            var GEtTD = 0.00;
            while (SQLConn.dr.Read())
            {
                var ID = SQLConn.dr["ID"].ToString();
                var Name = SQLConn.dr["Name"].ToString();
                var StartDateTicket = SQLConn.dr["StartDateTicket"].ToString();
                var Duration = SQLConn.dr["Duration"].ToString();
                var CustomerName = SQLConn.dr["CustomerName"].ToString();
                var StartTimeTicket = SQLConn.dr["StartTimeTicket"].ToString();
                var DriverName = SQLConn.dr["DriverName"].ToString();
                //var DriverAmount = SQLConn.dr["ID"].ToString();
                var PriceTicketAfterVAT = SQLConn.dr["PriceTicketAfterVAT"].ToString();
                var CashierAmount = SQLConn.dr["CashierAmount"].ToString();
                var AccountantAmount = SQLConn.dr["AccountantAmount"].ToString();
                string Letter = string.Concat(Duration.Where(Char.IsLetter));
                if (Letter != "")
                {
                    TM = Convert.ToInt32(AccountantAmount);
                    //if (Letter == "ساعه")
                    //{
                    //    Hresult = TimeSpan.FromHours(TM);
                    //    //string fromTimeString = Hresult.ToString("hh':'mm");
                    //}
                    //if (Letter == "دقيقة")
                    //{
                    //    TMI = TM;
                    //    Mresult = TimeSpan.FromMinutes(TM);
                    //    Timeres = Timeres + Mresult;
                    //    //string fromTimeString = Mresult.ToString("hh':'mm");
                    //}
                    //var TMR = Timeres;
                    //GTF = TMR.ToString();
                    GEtTD += TM;
                }
                double AD = GEtTD / 60;
                double AP = AD - Math.Truncate(AD);
                decimal CAD = Convert.ToDecimal(AD);
                var HH = decimal.Floor(CAD);
                var MM = AP * 60;
                var MM2 = HH + ":" + MM;
                GTF = MM2.ToString();
                var CashierExternCommission = SQLConn.dr["CashierExternCommission"].ToString();
                var OwnerID = SQLConn.dr["OwnerID"].ToString();
                var OwnerTypeID = SQLConn.dr["OwnerTypeID"].ToString();
                //var DriverCommission = SQLConn.dr["ID"].ToString();
                Ds.SeaTransport.Rows.Add(new object[] {
                    ID,Name,StartDateTicket,Duration,CustomerName,
                    StartTimeTicket,DriverName,null,PriceTicketAfterVAT,
                    CashierAmount,AccountantAmount,CashierExternCommission,
                    OwnerID,OwnerTypeID,null
                });
            }            
            RSTWH.SetDataSource(Ds);
            RSTWH.SetParameterValue("Sumtimes", GTF);
            BF.CRV.ReportSource = RSTWH;
            BF.CRV.Refresh();
            BF.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير ساعات التشغيل", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
    }
}
