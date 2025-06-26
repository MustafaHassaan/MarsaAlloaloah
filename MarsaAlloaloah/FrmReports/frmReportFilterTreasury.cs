using MarsaAlloaloah.CrystalReports;
using MarsaAlloaloah.FrmReports;
using MarsaAlloaloah.Utility;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using SmartArabXLSX.Office2010.Excel;
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
using static System.Net.WebRequestMethods;

namespace MarsaAlloaloah
{
    public partial class frmReportFilterTreasury : Form
    {
        public frmReportFilterTreasury()
        {
            InitializeComponent();
            GetTreasuryList();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            var TCash = (int)cmbSearch.SelectedValue;
            int selectedSearchItem = 1;
            if (cmbSearch.SelectedValue != null)
            {
                //selectedSearchItem = (int)cmbSearch.SelectedValue;
                DateTime dateStart = dtpStart.Value;
                DateTime dateEnd = dtpEnd.Value;
                dsMarsa Ds = new dsMarsa();
                //                frmReportPrint frmReportPrint = new frmReportPrint(dateStart, dateEnd, selectedSearchItem, "Treasury");
                //#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                //                _ = frmReportPrint.ShowDialog();
                decimal Balance = 0;
                bool Iswhile = false;
                var Qur = @"SELECT 
                            Tickets.ID As 'Invoiceid',
                            TreasuryTransactions.ID, 
                            Treasury.StartingBalance,
                            TreasuryTransactions.TransfertAmount, 
                            TreasuryTransactions.Libelle,
                            TreasuryTransactions.Date, 
                            Treasury.Name
                            FROM Treasury 
                            Left Outer JOIN TreasuryTransactions 
                            ON TreasuryTransactions.TreasuryID = Treasury.ID
                            Left Outer JOIN Tickets 
                            ON TreasuryTransactions.TicketID = Tickets.ID
                            Left Outer Join Returned
                            On TreasuryTransactions.TicketID = Returned.Invoiceid
                            where Treasury.ID = " + TCash + " "+
                            "and TreasuryTransactions.Date >= '"+ dateStart.ToString("yyyy-MM-dd") + "' "+
                            "and TreasuryTransactions.Date <= '"+ dateEnd.ToString("yyyy-MM-dd") + "' "+
                            "Order by TreasuryTransactions.Date";

                //var Qur = @"SELECT 
                //            TreasuryTransactions.ID, 
                //            Treasury.StartingBalance,
                //            TreasuryTransactions.TransfertAmount, 
                //            TreasuryTransactions.Libelle,
                //            TreasuryTransactions.Date, 
                //            Treasury.Name
                //            FROM Treasury 
                //            Left Outer JOIN TreasuryTransactions 
                //            ON TreasuryTransactions.TreasuryID = Treasury.ID
                //            where Treasury.ID = " + TCash + " "+
                //           "and TreasuryTransactions.Date >= '"+ dateStart.ToString("yyyy-MM-dd") + "' "+
                //           "and TreasuryTransactions.Date <= '" + dateEnd.ToString("yyyy-MM-dd") + "' "+
                //           "Order by TreasuryTransactions.Date";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                while (SQLConn.dr.Read())
                {
                    Iswhile = true;
                    string ID = SQLConn.dr["ID"].ToString();
                    string Invoiceid = SQLConn.dr["Invoiceid"].ToString();
                    var TransfertAmount = Convert.ToDecimal(SQLConn.dr["TransfertAmount"].ToString());
                    var StartingBalance = Convert.ToDecimal(SQLConn.dr["StartingBalance"].ToString());
                    var Libelle = SQLConn.dr["Libelle"].ToString();
                    var Date = SQLConn.dr["Date"].ToString();
                    var Name = SQLConn.dr["Name"].ToString();
                    Balance += TransfertAmount;
                    Ds.Treasury.Rows.Add(new object[] {
                        Invoiceid,Name,StartingBalance,TransfertAmount,Balance,Date,Libelle
                    });
                }
                if (Iswhile != true)
                {
                    //var Qur1 = @"SELECT 
                    //        TreasuryTransactions.ID, 
                    //        Treasury.StartingBalance,
                    //        TreasuryTransactions.TransfertAmount, 
                    //        TreasuryTransactions.Libelle,
                    //        TreasuryTransactions.Date, 
                    //        Treasury.Name
                    //        FROM Treasury 
                    //        Left Outer JOIN TreasuryTransactions 
                    //        ON TreasuryTransactions.TreasuryID = Treasury.ID
                    //        where Treasury.ID = " + cmbSearch.SelectedValue + " ";
                    var Qur1 = @"Select
                                 Tickets.ID,
                                 TreasuryTransactions.ID, 
                                 Treasury.StartingBalance,
                                 TreasuryTransactions.TransfertAmount, 
                                 TreasuryTransactions.Libelle,
                                 TreasuryTransactions.Date, 
                                 Treasury.Name
                                 FROM Treasury 
                                 Left Outer JOIN TreasuryTransactions 
                                 ON TreasuryTransactions.TreasuryID = Treasury.ID
                                 Left Outer JOIN Tickets 
                                 ON TreasuryTransactions.TicketID = Tickets.ID
                                 Left Outer Join Returned
                                 On TreasuryTransactions.TicketID = Returned.Invoiceid "+
                                 "where Treasury.ID = " + cmbSearch.SelectedValue;
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(Qur1, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();
                    while (SQLConn.dr.Read())
                    {
                        string Invoiceid = SQLConn.dr[0].ToString();
                        var TransfertAmount = Convert.ToDecimal(SQLConn.dr["TransfertAmount"].ToString());
                        var StartingBalance = Convert.ToDecimal(SQLConn.dr["StartingBalance"].ToString());
                        var Libelle = SQLConn.dr["Libelle"].ToString();
                        var Date = SQLConn.dr["Date"].ToString();
                        var Name = SQLConn.dr["Name"].ToString();
                        Balance += TransfertAmount;
                        Ds.Treasury.Rows.Add(new object[] {
                        //Invoiceid,Name,StartingBalance,TransfertAmount,Balance,null,Libelle
                        Invoiceid,Name,StartingBalance,TransfertAmount,Balance,Date,Libelle
                    });
                    }
                }
                NewRep NRP = new NewRep();
                rptTreasury RT = new rptTreasury();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير الخزينة ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        public void GetTreasuryList()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"select ID, Name from Treasury");
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

        private void frmReportFilterTreasury_Load(object sender, EventArgs e)
        {

        }
    }
}
