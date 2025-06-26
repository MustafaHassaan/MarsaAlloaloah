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
using MarsaAlloaloah;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;

namespace MarsaAlloaloah
{
    public partial class frmBankAccount : Form
    {
        int SelectedBankAccountID;
        public frmBankAccount()
        {
            InitializeComponent();
        }

        private void frmBankAccount_Load(object sender, EventArgs e)
        {
            try
            {
                Gridfill();
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            //dgvBankAccounts.Rows.Add("1", "الحساب البنكى الإفتراضية", "0");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBankAccount.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال إسم الحساب البنكى.", MsgBoxStyle.Information, "الحسابات البنكية");
                return;
            }

            if (btnSave.Text == "حفظ")
            {
                AddBankAccounts();
                txtBankAccount.Text = "";

            }
            else
            {
                UpdateBankAccounts();
                txtBankAccount.Text = "";
                btnSave.Text = "حفظ";
            }
        }

        private void AddBankAccounts()
        {
            try
            {
                // 1-Verify if there is another bank with the same name
                // 2- we can't have more than one bank "eftiradhi"
                int existingID = SQLConn.GetExistingBankAccountIDByName(txtBankAccount.Text);
                if (existingID == 0)
                {
                    SQLConn.sqL = "INSERT INTO BankAccounts(Name) VALUES(@Name)";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                    SQLConn.cmd.Parameters.AddWithValue("@Name", txtBankAccount.Text);
                    SQLConn.cmd.ExecuteNonQuery();
                    Interaction.MsgBox("تم حفظ بيانات الحساب البنكى.", MsgBoxStyle.Information, "اضافة حساب بنكى");
                    Gridfill();
                }
                else
                {
                    Interaction.MsgBox(" لا يمكن إظافة أكثر من حساب  إفتراضي  واحد.", MsgBoxStyle.Information, "اضافة حساب بنكى");
                }
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
        private void UpdateBankAccounts()
        {
            try
            {
                SQLConn.sqL = "UPDATE BankAccounts SET Name=@Name WHERE ID = '" + SelectedBankAccountID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtBankAccount.Text);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات الحساب البنكى");
                Gridfill();
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
        public void Gridfill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = BankAccountsGridFill();
                dgvBankAccount.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        public DataTable BankAccountsGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                //SQLConn.sqL = "select * from BankAccounts";
                SQLConn.sqL = @"select 
                                BankAccounts.ID,
                                Name,
                                Sum(BankAccountTransactions.Amount) As 'Balance'
                                from BankAccounts
                                Left Outer Join BankAccountTransactions 
                                On BankAccountTransactions.BankID = BankAccounts.ID
                                Group by BankAccounts.ID,BankAccounts.Name";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(dtbl);



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
            return dtbl;
        }
        public void FillControls()
        {
            try
            {
                DataTable BankAccountsInfo = BankAccountsView(SelectedBankAccountID);
                txtBankAccount.Text = BankAccountsInfo.Rows[0]["Name"].ToString();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        public DataTable BankAccountsView(int BankAccountsID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select * from BankAccounts where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", BankAccountsID);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(dtbl);

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
            return dtbl;

        }

        public void ClearFunction()
        {
            try
            {
                txtBankAccount.Clear();
                btnSave.Text = "حفظ";
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFunction();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا الحساب", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
            }
            else
            {
                return;
            }
        }
        private void DeleteFunction()
        {

            try
            {
                SQLConn.sqL = "Delete From BankAccounts WHERE ID = " + SelectedBankAccountID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف الحساب البنكى");
                Gridfill();
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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "الحسابات البنكية", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void dgvBankAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    SelectedBankAccountID = Convert.ToInt32(dgvBankAccount.CurrentRow.Cells["dgvBankAccountID"].Value);
                    FillControls();
                    btnSave.Text = "تحديث";
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gridfill();
            Interaction.MsgBox("تم تحديث  قائمة الحسابات البنكية بنجاح ", MsgBoxStyle.Information, "الحسابات البنكية");
        }
    }
}
