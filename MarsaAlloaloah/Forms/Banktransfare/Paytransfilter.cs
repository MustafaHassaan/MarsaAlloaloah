using MarsaAlloaloah.CrystalReports.CQR;
using MarsaAlloaloah.CrystalReports;
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

namespace MarsaAlloaloah.Forms.Banktransfare
{
    public partial class Paytransfilter : Form
    {
        public Paytransfilter()
        {
            InitializeComponent();
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
            ON Users.RoleID = Role.ID ";
                dtbl = SQLConn.getTable(Qur);
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
        private void Paytransfilter_Load(object sender, EventArgs e)
        {
            cmbCashierFill();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var Cs = Properties.Settings.Default.Connectionstring;
            SqlConnection Con = new SqlConnection(Cs);
            Formrp FRep = new Formrp();
            var Qur = @"Select 
                        Tickets.ID,
                        Tamara.Refnummber,
                        Tickets.StartDate,
                        Customers.Name,
                        Customers.Mobile,
                        Tickets.Paytransfer,
                        Users.UserName
                        From Tickets
                        Left Outer Join Customers
                        on Tickets.CustomerID = Customers.ID
                        Left Outer Join Users
                        on Tickets.UserID = Users.ID
                        Left Outer Join Tamara
                        on Tamara.Ticketid = Tickets.ID
                        Where Tickets.Flagpayment Is Not Null
                        and (tickets.startDate >= '" + dtpStart.Value.ToString("yyyy-MM-dd") + "' and tickets.startDate <= '" + dtpEnd.Value.ToString("yyyy-MM-dd") + "') ";
            if (cmbCashier.Text != "--اختر--")
            {
                Qur += "And Tickets.UserID = " + cmbCashier.SelectedValue;
            }
            Con.Open();
            SqlDataAdapter Da = new SqlDataAdapter(Qur, Con);
            QRds Ds = new QRds();
            Da.Fill(Ds, "Banktransfers");
            Con.Close();
            CRBanktransfers BF = new CRBanktransfers();
            BF.SetDataSource(Ds);
            BF.SetParameterValue("DT", dtpStart.Value.ToString("yyyy-MM-dd"));
            BF.SetParameterValue("DF", dtpEnd.Value.ToString("yyyy-MM-dd"));
            FRep.CRV.ReportSource = BF;
            FRep.CRV.Refresh();
            FRep.Show();
        }
    }
}
