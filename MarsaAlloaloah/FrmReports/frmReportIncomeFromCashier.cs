using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    public partial class frmReportIncomeFromCashier : Form
    {
        public frmReportIncomeFromCashier()
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
                frmReportPrint frmReportPrint = new frmReportPrint(dateStart, dateEnd, cashierId, "IncomeCashier");
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                _ = frmReportPrint.ShowDialog();
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
                //      WHERE     (Role.ID = 2)");//كاشير
                // TODO : Verify this information
                // the id 2 must be fix in an enumeration

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
