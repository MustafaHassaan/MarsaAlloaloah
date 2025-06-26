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
    public partial class frmReportDriverCommission : Form
    {
        public frmReportDriverCommission()
        {
            InitializeComponent();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int driverId = 1;
            if(cmbDriver.SelectedValue != null && cmbDriver.SelectedValue.ToString() != "0")
            {
                int.TryParse(cmbDriver.SelectedValue.ToString(), out driverId);
                DateTime dateStart = dtpStart.Value;
                DateTime dateEnd = dtpEnd.Value;
                //                // We use the UserId Corresponding to the cashier
                //                frmReportPrint frmReportPrint = new frmReportPrint(dateStart, dateEnd, driverId, "DriverCommission", cmbDriver.Text);
                //#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                //                _ = frmReportPrint.ShowDialog();

                string query = @"SELECT DISTINCT 
SeaTransport.ID, 
SeaTransport.Name,
Tickets.ID, 
Tickets.StartDate AS StartDateTicket,
CAST(Tickets.StartTime AS time(0)) AS StartTimeTicket, 
Tickets.DurationValue as 'AccountantAmount', 
Price.Duration, 
Customers.Name AS CustomerName,   
Drivers.Name AS DriverName, 
Tickets.PriceAfterVAT as PriceTicketAfterVAT,
Price.CashierCommission as CashierAmount, 
Price.CashierExternCommission, 
SeaTransport.OwnerID, 
SeaTransport.OwnerTypeID, 
Price.DriverCommission As 'DriverCommission'
FROM Tickets 
Left Outer JOIN Customers 
ON Tickets.CustomerID = Customers.ID 
Left Outer JOIN SeaTransportType 
ON Tickets.SeaTransportTypeID = SeaTransportType.ID 
Left Outer JOIN Price 
ON Tickets.DurationID = Price.ID 
Left Outer JOIN SeaTransport 
ON Tickets.SeaTransportID = SeaTransport.ID 
Left Outer JOIN Drivers 
ON Tickets.DriverID = Drivers.ID 
Left Outer JOIN Users 
ON Tickets.UserID = Users.ID  WHERE  Drivers.ID = " + driverId +
                      @" and Tickets.ID Not IN (Select Invoiceid From Returned Where Type='ارتجاع تذكرة')"
                         + @" and ( Tickets.StartDate <= '" + dateEnd +
                         @"' and  Tickets.StartDate >= '" + dateStart + "')  Order by Tickets.StartDate desc";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(query, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                dsMarsa Ds = new dsMarsa();
                rptDriverCommission RSTWH = new rptDriverCommission();
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
                    var DriverCommission = SQLConn.dr["DriverCommission"].ToString();
                    Ds.SeaTransport.Rows.Add(new object[] {
                    ID,Name,StartDateTicket,Duration,CustomerName,
                    StartTimeTicket,DriverName,null,PriceTicketAfterVAT,
                    CashierAmount,AccountantAmount,CashierExternCommission,
                    OwnerID,OwnerTypeID,DriverCommission
                });
                }
                RSTWH.SetDataSource(Ds);
                RSTWH.SetParameterValue("Sumtimes", GTF);
                RSTWH.SetParameterValue("CashierName", cmbDriver.Text);
                BF.CRV.ReportSource = RSTWH;
                BF.CRV.Refresh();
                BF.Show();
            }
            else if (cmbDriver.SelectedValue == null || cmbDriver.SelectedValue.ToString() == "0")
            {
                Interaction.MsgBox("من فضلك إختر إسم السائق");
                return;
            }
        }

        private void frmReportCashier_Load(object sender, EventArgs e)
        {
            //Initialise the driver list
            cmbDriverFill();
        }

        private void cmbDriverFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"SELECT  distinct ID, Name FROM  Drivers ");                

                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";

                dtbl.Rows.InsertAt(dr, 0);

                cmbDriver.DataSource = dtbl;
                cmbDriver.ValueMember = "ID";
                cmbDriver.DisplayMember = "Name";
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير السائق", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
