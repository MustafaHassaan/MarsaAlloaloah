using MarsaAlloaloah.CrystalReports;
using MarsaAlloaloah.FrmReports;
using MarsaAlloaloah.Utility;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    public partial class frmReportCashier : Form
    {
        public frmReportCashier()
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
            var DTS = dtpStart.Value.ToString("yyyy-MM-dd");
            var DTE = dtpEnd.Value.ToString("yyyy-MM-dd");
            if (cmbCashier.SelectedValue != null && cmbCashier.SelectedValue.ToString() != "0")
            {
                string query = @"SELECT     
                                 Tickets.ID, 
                                 Tickets.UserID, 
                                 Users.UserName, 
                                 Tickets.PriceAfterVAT, 
                                 Customers.ID AS CustomerID, 
                                 Customers.Name AS CustomerName, 
                                 Tickets.StartDate, 
                                 Tickets.StartTime, 
                                 Tickets.PayCash, 
                                 Tickets.PayCard, 
                                 Tickets.Paytamara, 
                                 Tickets.Paytransfer, 
                                 Employees.Name AS EmployeName, 
                                 Drivers.Name AS DriverName, 
                                 SeaTransport.Name AS BoatName
                                 FROM Tickets 
                                 INNER JOIN Customers 
                                 ON Tickets.CustomerID = Customers.ID 
                                 INNER JOIN Users 
                                 ON Tickets.UserID = Users.ID 
                                 INNER JOIN Employees 
                                 ON Users.EmployeeID = Employees.ID  
                                 LEFT OUTER JOIN Drivers 
                                 ON Tickets.DriverID = Drivers.ID  
                                 LEFT OUTER JOIN SeaTransport 
                                 ON Tickets.SeaTransportID = SeaTransport.ID 
                                 Left outer Join Returned
								 On Tickets.ID = Returned.Invoiceid
                                 WHERE Users.ID = " + cmbCashier.SelectedValue + " "+
                                //"and Tickets.ID Not In(Select Invoiceid from Returned)" +
                                "and Tickets.StartDate >= '" + DTS +"' "+
                                "and Tickets.StartDate <= '" + DTE + "' " +
                                "order by Tickets.ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(query, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                dsMarsa Ds = new dsMarsa();
                while (SQLConn.dr.Read())
                {
                    int ID = Convert.ToInt32(SQLConn.dr["ID"].ToString());
                    var Userid = SQLConn.dr["UserID"].ToString();
                    var EmployeName = SQLConn.dr["EmployeName"].ToString();
                    var CustomerID = SQLConn.dr["CustomerID"].ToString();
                    var PayCash = SQLConn.dr["PayCash"].ToString();
                    var PayCard = SQLConn.dr["PayCard"].ToString();
                    var CustomerName = SQLConn.dr["CustomerName"].ToString();
                    var StartDate = SQLConn.dr["StartDate"].ToString();
                    var PriceAfterVAT = SQLConn.dr["PriceAfterVAT"].ToString();
                    var DriverName = SQLConn.dr["DriverName"].ToString();
                    var BoatName = SQLConn.dr["BoatName"].ToString();
                    var Paytamara = SQLConn.dr["Paytamara"].ToString();
                    if (Paytamara == "")
                    {
                        Paytamara = "0.00";
                    }
                    var Paytransfer = SQLConn.dr["Paytransfer"].ToString();
                    if (Paytransfer == "")
                    {
                        Paytransfer = "0.00";
                    }
                    Ds.Tickets.Rows.Add(new object[] {
                        ID,Userid,CustomerID,PayCash,PayCard,CustomerName,null,
                        StartDate,EmployeName,PriceAfterVAT,null,DriverName,
                        BoatName,Paytamara,Paytransfer
                    });
                }
                NewRep NRP = new NewRep();
                rptCollection RT = new rptCollection();
                RT.SetDataSource(Ds);
                NRP.FRA.ReportSource = RT;
                NRP.FRA.Refresh();
                NRP.Show();
                //                int.TryParse(cmbCashier.SelectedValue.ToString(), out cashierId);
                //                DateTime dateStart = dtpStart.Value;
                //                DateTime dateEnd = dtpEnd.Value;
                //                // We use the UserId Corresponding to the cashier
                //                frmReportPrint frmReportPrint = new frmReportPrint(dateStart, dateEnd, cashierId, "Cashier");
                //#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                //                _ = frmReportPrint.ShowDialog();
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
                dtbl = SQLConn.getTable(Qur);//كاشير
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
