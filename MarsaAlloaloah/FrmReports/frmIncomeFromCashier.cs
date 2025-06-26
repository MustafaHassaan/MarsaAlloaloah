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

namespace MarsaAlloaloah
{
    public partial class frmIncomeFromCashier : Form
    {
        public frmIncomeFromCashier()
        {
            InitializeComponent();
            cmbCashier.SelectedIndex = 0;
            txtCard.Text = "0.00";
            txtCash.Text = "0.00";
        }

        private void frmReportCashier_Load(object sender, EventArgs e)
        {
            //Initialise the cashier list
            cmbCashierFill();
        }
        /// <summary>
        /// Get all cashier Names
        /// </summary>
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
            Where Role.Name = 'كاشير'";
                dtbl = SQLConn.getTable(Qur);
                //dtbl = SQLConn.getTable(@"SELECT Users.ID as ID, Employees.Name as Name
                //      FROM Users INNER JOIN
                //      Employees ON Users.EmployeeID = Employees.ID INNER JOIN
                //      Jobs ON Employees.JobID = Jobs.ID INNER JOIN
                //      Role ON Users.RoleID = Role.ID 
                //      WHERE     ( Role.ID = 2)"); //كاشير
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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "استلام الكاشير", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCash.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال المبلغ المستلم.", MsgBoxStyle.Information, "استلام الكاشير");
                return;
            }
            Addtoifc();
            //AddIncomeFromCashier();
        }
        //IncomeFromCashier
        private void Addtoifc()
        {
            try
            {
                SQLConn.sqL = "Insert into IncomeFromCashier(StartDate, StartTime,UserID,PayCash) values(@StartDate,@StartTime,@UserID,@PayCash); SELECT CAST(scope_identity() AS int)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@StartDate", dtpDate.Value.ToShortDateString());
                SQLConn.cmd.Parameters.AddWithValue("@StartTime", dtpDate.Value.TimeOfDay);
                SQLConn.cmd.Parameters.AddWithValue("@UserID", cmbCashier.SelectedValue);
                SQLConn.cmd.Parameters.AddWithValue("@PayCash", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtCash.Text));
                var idIncomfromcashier = (int)SQLConn.cmd.ExecuteScalar();
                UAccountTreasury(idIncomfromcashier);
                //SQLConn.cmd.ExecuteNonQuery();
                //Interaction.MsgBox("تم حفظ البيانات بنجاح.", MsgBoxStyle.Information, "استلام الاموال");
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
        //Update Treasury For Accountant
        private void UAccountTreasury(int idincom)
        {
            try
            {
                var amount = Common.ConvertCurrencyFieldToStringOnSqlQuery(txtCash.Text);
                var Qur = @"Update Treasury Set Balance = Balance +  @NewBalance where UserID=@UserID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@UserID", Data.UserID);
                SQLConn.cmd.ExecuteNonQuery();

                int id = SQLConn.GetTreasuryIDForCurrentUser((int)cmbCashier.SelectedValue);

                int treasuryID = SQLConn.GetPrincipalTreasuryID(Data.UserID);
                if (treasuryID > 0)
                {
                    SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID, IncomeFromCashierID,Libelle, Date) 
                                    values( @NewBalance, @treasuryID, @IncomeFromCashierID, @Libelle,@Date)";

                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", treasuryID);
                    SQLConn.cmd.Parameters.AddWithValue("@IncomeFromCashierID", idincom);
                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", "استلام الاموال من الكاشير");
                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    SQLConn.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            UCashierTreasury(idincom);
        }

        //Add Data To TreasuryTransactions
        private void UCashierTreasury(int idincom)
        {
            try
            {
                var amount = Common.ConvertCurrencyFieldToStringOnSqlQuery(txtCash.Text);
                var Qur = @"Update Treasury Set Balance = Balance -  @NewBalance where UserID=@UserID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@UserID", cmbCashier.SelectedValue);
                SQLConn.cmd.ExecuteNonQuery();


                int treasuryID = SQLConn.GetPrincipalTreasuryID((int)cmbCashier.SelectedValue);
                if (treasuryID > 0)
                {
                    SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID, IncomeFromCashierID,Libelle, Date) 
                                    values( @NewBalance, @treasuryID, @IncomeFromCashierID, @Libelle,@Date)";

                    var NA = 0 - Convert.ToDecimal(amount);
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", NA);
                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", treasuryID);
                    SQLConn.cmd.Parameters.AddWithValue("@IncomeFromCashierID", idincom);
                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", "تسليم الاموال الى الكاشير");
                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    SQLConn.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            Interaction.MsgBox("تم حفظ بيانات استلام الكاشير.", MsgBoxStyle.Information, "استلام الاموال من الكاشير");
            txtCash.Text = "0.00";
        }
        private void AddIncomeFromCashier()
        {
            try
            {
                SQLConn.sqL = @"Insert into IncomeFromCashier(StartDate, StartTime,UserID,PayCash) 
                values(@StartDate,@StartTime,@UserID,@PayCash); SELECT CAST(scope_identity() AS int)";

                SQLConn.ConnDB();
                SQLConn.BeginTransaction();

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@StartDate", dtpDate.Value.ToShortDateString());
                SQLConn.cmd.Parameters.AddWithValue("@StartTime", dtpDate.Value.TimeOfDay);
                SQLConn.cmd.Parameters.AddWithValue("@UserID", cmbCashier.SelectedValue);
                SQLConn.cmd.Parameters.AddWithValue("@PayCash", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtCash.Text));
                
                int idIncome = (int)SQLConn.cmd.ExecuteScalar();

                Decimal.TryParse(txtCash.Text, out decimal amountBank);
                var Cashuid = (int)cmbCashier.SelectedValue;
                //int Cashierid = SQLConn.GetTreasuryIDForCurrentUser((int)cmbCashier.SelectedValue);



                // Accountant
                SQLConn.UpdatePrincipalTreasuryBalance(amountBank, SQLConn.trans);
                SQLConn.UpdatePrincipalTreasuryIncomeFromCashierTransactions(amountBank, SQLConn.trans, Cashuid, "استلام الاموال من الكاشير");

                int id=SQLConn.GetTreasuryIDForCurrentUser((int)cmbCashier.SelectedValue);

                
                
                
                SQLConn.UpdatePrincipalTreasuryIncomeFromCashierTransactions(id, -amountBank, SQLConn.trans, idIncome, "استلام الاموال من الكاشير");

                //SQLConn.trans.Commit();

                // Update principal Treasury 
                Interaction.MsgBox("تم حفظ بيانات استلام الكاشير.", MsgBoxStyle.Information, "استلام الاموال من الكاشير");
                txtCash.Text = "0.00";
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
    }
}
