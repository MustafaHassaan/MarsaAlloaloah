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

namespace MarsaAlloaloah.FrmReports
{
    public partial class frmReportFilterbank : Form
    {
        public frmReportFilterbank()
        {
            InitializeComponent();
            GetBankList();
        }
        public void GetBankList()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"select ID, Name from BankAccounts");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbSearch.DataSource = dtbl;
                cmbSearch.ValueMember = "ID";
                cmbSearch.DisplayMember = "Name";
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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير البنك", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            int selectedSearchItem = 1;
            if (cmbSearch.SelectedValue != null)
            {
                selectedSearchItem = (int)cmbSearch.SelectedValue;
                DateTime dateStart = dtpStart.Value;
                DateTime dateEnd = dtpEnd.Value;
                dsMarsa Ds = new dsMarsa();
                bool Iswhile = false;
                var Qur = @"SELECT 
                            BankAccountTransactions.ID, 
                            BankAccountTransactions.Amount,
                            BankAccounts.Name,
                            BankAccountTransactions.Libelle,
                            BankAccountTransactions.Date
                            FROM BankAccountTransactions
                            Inner Join BankAccounts
                            On BankAccountTransactions.BankID = BankAccounts.ID
                            where BankAccountTransactions.BankID = " + selectedSearchItem + " "+
                            "and BankAccountTransactions.Date <= '" + dateEnd + "' " +
                            "and BankAccountTransactions.Date >= '" + dateStart + "' ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                while (SQLConn.dr.Read())
                {
                    Iswhile = true;
                    int ID = Convert.ToInt32(SQLConn.dr["ID"].ToString());
                    var TransfertAmount = Convert.ToDecimal(SQLConn.dr["Amount"].ToString());
                    var Libelle = SQLConn.dr["Libelle"].ToString();
                    var Name = SQLConn.dr["Name"].ToString();
                    var Date = SQLConn.dr["Date"].ToString();
                    Ds.Bankaccount.Rows.Add(new object[] {
                        ID,Name,TransfertAmount,Libelle,Date
                    });
                }
                if (Iswhile != true)
                {
                    var Qur1 = @"SELECT 
                            BankAccountTransactions.ID, 
                            BankAccountTransactions.Amount,
                            BankAccounts.Name,
                            BankAccountTransactions.Libelle,
                            BankAccountTransactions.Date
                            FROM BankAccountTransactions
                            Inner Join BankAccounts
                            On BankAccountTransactions.BankID = BankAccounts.ID
                            where BankAccountTransactions.BankID = " + selectedSearchItem + " " +
                            "and BankAccountTransactions.Date <= '" + dateEnd + "' " +
                            "and BankAccountTransactions.Date >= '" + dateStart + "' ";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(Qur1, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();
                    if (SQLConn.dr.Read())
                    {
                        int ID = Convert.ToInt32(SQLConn.dr["ID"].ToString());
                        var TransfertAmount = Convert.ToDecimal(SQLConn.dr["Amount"].ToString());
                        var Libelle = SQLConn.dr["Libelle"].ToString();
                        var Name = SQLConn.dr["Name"].ToString();
                        var Date = SQLConn.dr["Date"].ToString();
                        Ds.Bankaccount.Rows.Add(new object[] {
                        ID,Name,TransfertAmount,Libelle,Date
                        });
                    }
                }
                NewRep NRP = new NewRep();
                rptBankaccount RT = new rptBankaccount();
                RT.SetDataSource(Ds);
                NRP.FRA.ReportSource = RT;
                NRP.FRA.Refresh();
                NRP.Show();
            }
            else
            {
                Interaction.MsgBox("من فضلك إختر نوع البحث");
                return;
            }
        }
    }
}
