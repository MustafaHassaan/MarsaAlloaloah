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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    public partial class frmExpenses : Form
    {
        int? selectedExpensesID;
        string oldAmount;

        public frmExpenses()
        {
            InitializeComponent();
        }

        private void frmExpenses_Load(object sender, EventArgs e)
        {
            // fill cmbExpensesType
            cmbExpensesTypeFill();
            chboxIsVAT.Checked = false;

            lblAmountAfterVAT.Visible = false;
            LblVAT.Visible = false;
            AmountAfterVAT.Visible = false;
            VAT.Visible = false;

            ExpensesListFill();
        }

        /// <summary>
        /// Get all Names
        /// </summary>
        private void cmbExpensesTypeFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"SELECT   ID, ExpensesType  FROM  ExpensesType");

                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["ExpensesType"] = "--اختر--";

                dtbl.Rows.InsertAt(dr, 0);

                cmbExpensesType.DataSource = dtbl;
                cmbExpensesType.ValueMember = "ID";
                cmbExpensesType.DisplayMember = "ExpensesType";
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxIsVAT.Checked)
            {
                lblAmountAfterVAT.Visible = true;
                LblVAT.Visible = true;
                AmountAfterVAT.Visible = true;
                VAT.Visible = true;
            }
            else
            {
                lblAmountAfterVAT.Visible = false;
                LblVAT.Visible = false;
                AmountAfterVAT.Visible = false;
                VAT.Visible = false;
            }

            // Get the TVA from setting
            GetSystemSettingsData();
        }


        public void GetSystemSettingsData()
        {
            DataTable dtbl = new DataTable();
            try
            {
                dtbl = SQLConn.GetSystemSettingsData();
                bool isApplyVAT = Convert.ToBoolean(dtbl.Rows[0]["IsApplyVAT"].ToString());
                if (isApplyVAT)
                {
                    VAT.Text = dtbl.Rows[0]["VATPercent"].ToString();
                    if (!string.IsNullOrEmpty(txtExpensesAmount.Text)) //= Common.ConvertCurrencyFieldToStringOnSqlQuery(txtIncomeAmount.Text);
                    {
                        double currency = Common.num_repl(txtExpensesAmount.Text);
                        double vat = Common.num_repl(VAT.Text);
                        double amountAfterVAT = (currency * vat) / 100 + currency;
                        AmountAfterVAT.Text = amountAfterVAT.ToString();
                        var IA = Convert.ToDecimal(AmountAfterVAT.Text) - Convert.ToDecimal(txtExpensesAmount.Text);
                        VAT.Text = Convert.ToString(IA);
                    }
                }
                else
                {
                    VAT.Text = "0.00";
                    AmountAfterVAT.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbExpensesType.SelectedValue == null
               || cmbExpensesType.SelectedValue.ToString().Trim() == string.Empty
               || cmbExpensesType.SelectedValue.ToString() == "0")
            {
                Interaction.MsgBox("الرجاء إدخال نوع المصروف.", MsgBoxStyle.Information, " نوع المصروف");
                return;
            }

            if (!chboxIsVAT.Checked)
            {
                AmountAfterVAT.Text = txtExpensesAmount.Text;
            }
            if (btnSave.Text == "حفظ")
            {
                AddExpenses();
                ClearFields();
            }
            else
            {
                UpdateExpenses();
                ClearFields();
                btnSave.Text = "حفظ";
            }
        }

        private void UpdateExpenses()
        {
            try
            {
                SQLConn.sqL = @"UPDATE Expenses SET ExpensesName=@ExpensesName, SeaTransportID=@SeaTransportID, Amount=@Amount, VAT=@VAT, 
                                AmountAfterVAT=@AmountAfterVAT, ExpensesTypeID=@ExpensesTypeID, IsTaxInvoice=@IsTaxInvoice, 
                                Date=@Date WHERE  ID = '" + selectedExpensesID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@ExpensesName", txtExpensesName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", txtSeaTransportID.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Amount", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtExpensesAmount.Text));
                if (chboxIsVAT.Checked)
                {
                    SQLConn.cmd.Parameters.AddWithValue("@AmountAfterVAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(AmountAfterVAT.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@VAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(VAT.Text));
                }
                else
                {
                    SQLConn.cmd.Parameters.AddWithValue("@AmountAfterVAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtExpensesAmount.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@VAT", Convert.ToDecimal(0.00));
                }              
                SQLConn.cmd.Parameters.AddWithValue("@ExpensesTypeID", cmbExpensesType.SelectedValue.ToString());
                SQLConn.cmd.Parameters.AddWithValue("@IsTaxInvoice", chboxIsVAT.Checked);
                SQLConn.cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToShortDateString());
                SQLConn.cmd.ExecuteNonQuery();

                // Delete old amount from treasury and the add the new
                if (!string.IsNullOrEmpty(oldAmount))
                {
                    Decimal.TryParse(oldAmount, out decimal amount);
                    SQLConn.UpdatePrincipalTreasuryBalance(amount, SQLConn.trans);
                    //SQLConn.UpdatePrincipalTreasuryTransactions(amount, SQLConn.trans);
                    SQLConn.UpdatePrincipalTreasuryExpensesTransactions(amount, SQLConn.trans, selectedExpensesID.Value, "حذف المصروف" + txtExpensesName.Text);
                }

                decimal amountBank = 0;
                if (chboxIsVAT.Checked)
                    Decimal.TryParse(AmountAfterVAT.Text, out amountBank);
                else
                    Decimal.TryParse(txtExpensesAmount.Text, out amountBank);

                SQLConn.UpdatePrincipalTreasuryBalance(-amountBank, SQLConn.trans);
                //SQLConn.UpdatePrincipalTreasuryTransactions(-amountBank, SQLConn.trans);
                SQLConn.UpdatePrincipalTreasuryExpensesTransactions(-amountBank, SQLConn.trans, selectedExpensesID.Value, "تحديث بيانات المصروف" + txtExpensesName.Text);

                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات المصروف");

                // Fill the datagrid of list income
                ExpensesListFill();
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

        private void AddExpenses()
        {
            //Insert into table Income
            SQLConn.sqL = @"INSERT INTO Expenses(ExpensesName, SeaTransportID, Amount, VAT, AmountAfterVAT, ExpensesTypeID, IsTaxInvoice, Date)  
                            VALUES(@ExpensesName, @SeaTransportID, @Amount, @VAT, @AmountAfterVAT, @ExpensesTypeID, @IsTaxInvoice, @Date); SELECT CAST(scope_identity() AS int) ";
            try
            {
                SQLConn.ConnDB();
                //SQLConn.BeginTransaction();

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@ExpensesName", txtExpensesName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", txtSeaTransportID.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Amount", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtExpensesAmount.Text));
                if (chboxIsVAT.Checked)
                {
                    SQLConn.cmd.Parameters.AddWithValue("@AmountAfterVAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(AmountAfterVAT.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@VAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(VAT.Text));
                }
                else
                {
                    SQLConn.cmd.Parameters.AddWithValue("@AmountAfterVAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtExpensesAmount.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@VAT", Convert.ToDecimal(0.00));
                }
                SQLConn.cmd.Parameters.AddWithValue("@ExpensesTypeID", cmbExpensesType.SelectedValue.ToString());
                SQLConn.cmd.Parameters.AddWithValue("@IsTaxInvoice", chboxIsVAT.Checked);
                SQLConn.cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToShortDateString());

                int expensesId = (int)SQLConn.cmd.ExecuteScalar();

                decimal amountBank = 0;
                if (chboxIsVAT.Checked)
                    Decimal.TryParse(AmountAfterVAT.Text, out amountBank);
                else
                    Decimal.TryParse(txtExpensesAmount.Text, out amountBank);

                SQLConn.UpdatePrincipalTreasuryBalance(-amountBank, SQLConn.trans);
                SQLConn.UpdatePrincipalTreasuryExpensesTransactions(-amountBank, SQLConn.trans, expensesId, " مصروف " + txtExpensesName.Text);

                //SQLConn.trans.Commit();

                Interaction.MsgBox("تم حفظ بيانات المصروف.", MsgBoxStyle.Information, "المصروف");

                //dgvListIncome load
                // Fill the datagrid of list income
                ExpensesListFill();
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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "المصروفات", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا المصروف", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
                ClearFields();
            }
            else
            {
                return;
            }
        }

        public void ClearFields()
        {
            try
            {
                txtExpensesName.Clear();
                txtSeaTransportID.Clear();
                cmbExpensesType.SelectedValue = 0;
                txtExpensesAmount.Clear();
                chboxIsVAT.Checked = false;
                VAT.Text = string.Empty;
                AmountAfterVAT.Text = string.Empty;

                btnSave.Text = "حفظ";
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void DeleteFunction()
        {
            try
            {
                SQLConn.sqL = "Delete From Expenses WHERE ID = " + selectedExpensesID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(oldAmount))
                {
                    Decimal.TryParse(oldAmount, out decimal amount);
                    SQLConn.UpdatePrincipalTreasuryBalance(amount, SQLConn.trans);
                    //SQLConn.UpdatePrincipalTreasuryTransactions(amount, SQLConn.trans);
                    SQLConn.UpdatePrincipalTreasuryExpensesTransactions(amount, SQLConn.trans, selectedExpensesID.Value, "حذف المصروف" + txtExpensesName.Text);
                }

                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف المصروفات");
                // Fill the datagrid of list income
                ExpensesListFill();
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

       
        public void ExpensesListFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = IncomeListGridFill();
                dgvListExpenses.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable IncomeListGridFill()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT   Expenses.ID, Expenses.ExpensesName, Expenses.Amount, Expenses.VAT, Expenses.AmountAfterVAT,  
                      Expenses.SeaTransportID, ExpensesType.ExpensesType
FROM         Expenses INNER JOIN
                      ExpensesType ON Expenses.ExpensesTypeID = ExpensesType.ID";
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

        private void dgvListExpenses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && dgvListExpenses.CurrentRow.Cells[0] != null && dgvListExpenses.CurrentRow.Cells[0].Value != null)
                {
                    selectedExpensesID = Convert.ToInt32(dgvListExpenses.CurrentRow.Cells[0].Value);
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

        public void FillControls()
        {
            try
            {
                if (selectedExpensesID.HasValue)
                {
                    DataTable incomeTypeInfo = GetExpensesByID(selectedExpensesID.Value);
                    txtExpensesName.Text = incomeTypeInfo.Rows[0]["ExpensesName"].ToString();
                    txtSeaTransportID.Text = incomeTypeInfo.Rows[0]["SeaTransportID"].ToString();
                    cmbExpensesType.SelectedValue = incomeTypeInfo.Rows[0]["ExpensesTypeID"].ToString();
                    txtExpensesAmount.Text = incomeTypeInfo.Rows[0]["Amount"].ToString();
                    chboxIsVAT.Checked = Boolean.Parse(incomeTypeInfo.Rows[0]["IsTaxInvoice"].ToString());
                    VAT.Text = incomeTypeInfo.Rows[0]["VAT"].ToString();
                    AmountAfterVAT.Text = incomeTypeInfo.Rows[0]["AmountAfterVAT"].ToString();
                    if (chboxIsVAT.Checked)
                        oldAmount = AmountAfterVAT.Text;
                    else
                        oldAmount = txtExpensesAmount.Text;

                    dtpDate.Text = incomeTypeInfo.Rows[0]["Date"].ToString();

                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable GetExpensesByID(int selectedExpensesID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT Expenses.ID, Expenses.ExpensesName, Expenses.Amount, Expenses.VAT, Expenses.AmountAfterVAT, Expenses.SeaTransportID,  
                       ExpensesType.ExpensesType, ExpensesTypeID,  Expenses.IsTaxInvoice, Expenses.Date

                      FROM         Expenses INNER JOIN
                      ExpensesType ON Expenses.ExpensesTypeID = ExpensesType.ID where  Expenses.ID= @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", selectedExpensesID);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
