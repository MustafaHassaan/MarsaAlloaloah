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
using MarsaAlloaloah.Utility;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using static System.Net.WebRequestMethods;

namespace MarsaAlloaloah
{
    public partial class frmtreasury : Form
    {
        int SelectedTreasuryID;
        string Balance;
        string OldStartingBalance;

        public frmtreasury()
        {
            InitializeComponent();
        }

        private void frmtreasury_Load(object sender, EventArgs e)
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
            //dgvTreasury.Rows.Add("1", "الخزينة الإفتراضية", "0");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTreasuryName.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال إسم الخزينة.", MsgBoxStyle.Information, "الخزائن");
                return;
            }

            if (btnSave.Text == "حفظ")
            {
                //AddTreasury();
                txtTreasuryName.Text = "";

            }
            else
            {
                UpdateTreasury();
                txtTreasuryName.Text = "";
                btnSave.Text = "حفظ";
                btnSave.Enabled = false;
            }
        }

        private void AddTreasury()
        {
            try
            {
                //StartingBalance
                SQLConn.sqL = "INSERT INTO Treasury(Name, Balance, StartingBalance, UserID) VALUES(@Name, @StartingBalance, @StartingBalance,@UserID) ; SELECT CAST(scope_identity() AS int)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtTreasuryName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@StartingBalance", txtStartingBalance.Text);
                SQLConn.cmd.Parameters.AddWithValue("@UserID", Data.UserID);
                int idTreasury = (int)SQLConn.cmd.ExecuteScalar();
                Interaction.MsgBox("تم حفظ بيانات الخزينة.", MsgBoxStyle.Information, "اضافة خزينة");

                //Add transaction
                Decimal.TryParse(txtStartingBalance.Text, out decimal amount);
                if (amount > 0)
                {
                    //SQLConn.UpdateUserTreasury(idTreasury, amount, SQLConn.trans);
                    SQLConn.UpdateTreasuryStartingTransactions(idTreasury, amount, SQLConn.trans, "إظافة الرصيد الافتتاحي للخزينة " + txtTreasuryName.Text);
                }
                //txtStartingBalance.ReadOnly = true;
                //txtStartingBalance.Enabled = false;
                // ReLoad
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
        private void UpdateTreasury()
        {
            try
            {
                //decimal balance = 0;

                //Decimal.TryParse(Balance, out balance);

                //Decimal.TryParse(OldStartingBalance, out decimal oldStartingB);
                Decimal.TryParse(txtStartingBalance.Text, out decimal amount);
                //if (oldStartingB != amount)
                //{
                //    // Update Balance
                //    decimal oldDiff = balance - oldStartingB;
                //    balance = oldDiff + amount;
                //}


                SQLConn.sqL = "UPDATE Treasury SET Name= @Name, Balance=((Balance - StartingBalance) + @StartingBalance), StartingBalance=@StartingBalance WHERE ID = '" + SelectedTreasuryID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtTreasuryName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@StartingBalance", (Common.ConvertTxtToDecimal(txtStartingBalance.Text != "" ? txtStartingBalance.Text : "0")));
                
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات الخزينة");
                
                //Add transaction
                if (amount > 0)
                {                    
                    SQLConn.UpdateTreasuryStartingTransactions(SelectedTreasuryID, amount, SQLConn.trans, "تحديث الرصيد الافتتاحي للخزينة " + txtTreasuryName.Text);
                }
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
                dtbl = TreasuryGridFill();
                dgvTreasury.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        public DataTable TreasuryGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var role = Data.Role;
                var user = Data.UserID;
                if (role == "كاشير")
                {
                    label2.Visible = false;
                    txtTreasuryName.Visible = false;
                    label3.Visible = false;
                    txtStartingBalance.Visible = false;
                    btnSave.Visible = false;
                    btnClear.Visible = false;
                    btnDelete.Visible = false;
                    btnClose.Visible = false;
                    //button1.Visible = false;
                    var DTS = DateTime.Now.ToString("yyyy-MM-dd");
                    SQLConn.sqL = @"SELECT 
                                    Treasury.ID,
									Treasury.Name, 
                                    Treasury.Balance                                   
                                    FROM Treasury
                                    where Treasury.UserID = '" + user + "' "+
                                  @"Group By 
									Treasury.ID,
									Treasury.Name,
									Treasury.Balance";
                }
                else
                {
                    SQLConn.sqL = "SELECT ID, Name, Balance,StartingBalance  FROM Treasury";
                }
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
                DataTable TreasuryInfo = TreasuryView(SelectedTreasuryID);
                txtTreasuryName.Text = TreasuryInfo.Rows[0]["Name"].ToString();
                txtStartingBalance.Text = TreasuryInfo.Rows[0]["StartingBalance"].ToString();
                Balance = TreasuryInfo.Rows[0]["Balance"].ToString();
                OldStartingBalance = txtStartingBalance.Text;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        public DataTable TreasuryView(int TreasuryID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select * from Treasury where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", TreasuryID);
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
        private void dgvTreasury_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSave.Enabled = true;
                if (e.RowIndex != -1)
                {
                    SelectedTreasuryID = Convert.ToInt32(dgvTreasury.CurrentRow.Cells["dgvTreasuryID"].Value);
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
        public void ClearFunction()
        {
            try
            {
                txtTreasuryName.Clear();
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
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذه الخزينة", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
                txtTreasuryName.Text = "";
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                return;
            }

        }
        private void DeleteFunction()
        {

            try
            {
                SQLConn.sqL = "Delete From Treasury WHERE ID = " + SelectedTreasuryID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف الخزينة");
                // Todo : add transaction


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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "الخزائن", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
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
            Interaction.MsgBox("تم تحديث قائمة الخزائن بنجاح ", MsgBoxStyle.Information, "الخزائن");
        }
    }
}
