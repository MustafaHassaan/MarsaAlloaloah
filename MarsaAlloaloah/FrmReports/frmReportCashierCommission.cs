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
    public partial class frmReportCashierCommission : Form
    {
        public frmReportCashierCommission()
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
            int cashierId = 1;
            if(cmbCashier.SelectedValue != null && cmbCashier.SelectedValue.ToString() != "0")
            {
                int.TryParse(cmbCashier.SelectedValue.ToString(), out cashierId);
                DateTime dateStart = dtpStart.Value;
                DateTime dateEnd = dtpEnd.Value;
                // We use the UserId Corresponding to the cashier
                //                frmReportPrint frmReportPrint = new frmReportPrint(dateStart, dateEnd, cashierId, "CashierCommission", cmbCashier.Text);
                //#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                //                _ = frmReportPrint.ShowDialog();
                string query = @"SELECT DISTINCT 
Tickets.ID,
SeaTransport.Name,
Tickets.StartDate AS StartDateTicket, 
CAST(Tickets.StartTime AS time(0)) AS StartTimeTicket, 
Tickets.DurationValue AS 'AccountantAmount', 
Price.Duration, 
Customers.Name AS CustomerName,   
Drivers.Name AS DriverName, 
Tickets.PriceAfterVAT as PriceTicketAfterVAT,
Price.CashierCommission 'CashierAmount' ,
Price.CashierExternCommission,
SeaTransport.OwnerID, 
SeaTransport.OwnerTypeID
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
ON Tickets.UserID = Users.ID 
                      WHERE  Users.ID = " + cashierId
                      + @" and Tickets.ID Not IN (Select Invoiceid From Returned Where Type='ارتجاع تذكرة')"
                       + @" and ( Tickets.StartDate <= '" + dateEnd +
                       @"' and  Tickets.StartDate >= '" + dateStart + "') Order by Tickets.StartDate desc";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(query, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                dsMarsa Ds = new dsMarsa();
                rptCashierCommission RSTWH = new rptCashierCommission();
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
                    //var OwnerID = int.Parse(SQLConn.dr["OwnerID"].ToString());
                    //var OwnerTypeID = int.Parse(SQLConn.dr["OwnerTypeID"].ToString());
                    //var DriverCommission = SQLConn.dr["ID"].ToString();
                    if (CashierAmount == "" || CashierExternCommission == "")
                    {
                        CashierAmount = "0.00";
                        CashierExternCommission = "0.00";
                    }
                    Ds.SeaTransport.Rows.Add(new object[] {
                    ID,Name,StartDateTicket,Duration,CustomerName,
                    StartTimeTicket,DriverName,null,PriceTicketAfterVAT,
                    CashierAmount,AccountantAmount,CashierExternCommission,
                    null,null,null
                });
                }
                RSTWH.SetDataSource(Ds);
                RSTWH.SetParameterValue("Sumtimes", GTF);
                RSTWH.SetParameterValue("CashierName", cmbCashier.Text);
                BF.CRV.ReportSource = RSTWH;
                BF.CRV.Refresh();
                BF.Show();
            }
            else if (cmbCashier.SelectedValue == null || cmbCashier.SelectedValue.ToString() == "0")
            {
                Interaction.MsgBox("من فضلك إختر إسم الكاشير");
                return;
            }
        }

        private void frmReportCashier_Load(object sender, EventArgs e)
        {
            //Initialise the cashier list
            cmbCashierFill();
        }

        private void cmbCashierFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                var Qur = @"SELECT 
                            Users.ID as ID, 
                            Employees.Name as Name
                            FROM Users 
                            INNER JOIN Employees 
                            ON Users.EmployeeID = Employees.ID 
                            INNER JOIN Jobs 
                            ON Employees.JobID = Jobs.ID 
                            INNER JOIN Role 
                            ON Users.RoleID = Role.ID 
                            Where Role.Name = N'كاشير'";
                dtbl = SQLConn.getTable(Qur);
                //dtbl = SQLConn.getTable(@"SELECT Users.ID as ID, Employees.Name as Name
                //      FROM Users INNER JOIN
                //      Employees ON Users.EmployeeID = Employees.ID INNER JOIN
                //      Jobs ON Employees.JobID = Jobs.ID INNER JOIN
                //      Role ON Users.RoleID = Role.ID 
                //      WHERE     (Jobs.ID = 3)");//كاشير
                // TODO : Verify this information
                // the id 3 must be fix in an enumeration

                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";

                dtbl.Rows.InsertAt(dr, 0);

                cmbCashier.DataSource = dtbl;
                cmbCashier.ValueMember = "ID";
                cmbCashier.DisplayMember = "Name";
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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير الكاشير", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
