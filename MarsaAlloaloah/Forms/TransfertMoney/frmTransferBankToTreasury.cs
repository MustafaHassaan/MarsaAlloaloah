using MarsaAlloaloah.Utility;
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
    public partial class frmTransferBankToTreasury : Form
    {
        public frmTransferBankToTreasury()
        {
            InitializeComponent();
        }

        private void frmTransferBankToTreasury_Load(object sender, EventArgs e)
        {
            //Get bank Account Name
            GetBankAccountName();
            
            GetTreasuryList();
        }


        public void GetBankAccountName()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"Select ID,Name from BankAccounts");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbBankAccount.DataSource = dtbl;
                cmbBankAccount.ValueMember = "ID";
                cmbBankAccount.DisplayMember = "Name";
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
                cmbTreasury.DataSource = dtbl;
                cmbTreasury.ValueMember = "ID";
                cmbTreasury.DisplayMember = "Name";
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (int.Parse(cmbBankAccount.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الحساب البنكي");
                return;
            }
            if (int.Parse(cmbTreasury.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الخزينة");
                return;
            }
            if (txtAmountTransfert.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال المبلغ.", MsgBoxStyle.Information, "تحويل الأموال - من الحساب البنكي إلى الخزينة");
                return;
            }


            string amount = Common.ConvertCurrencyFieldToStringOnSqlQuery(txtAmountTransfert.Text);

            try
            {
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();

                Decimal.TryParse(amount, out decimal amountBank);
                int bankId = (int)cmbBankAccount.SelectedValue;
                int treasId = (int)cmbTreasury.SelectedValue;
                SQLConn.UpdateBankAccountByID(bankId , - amountBank, SQLConn.trans);
                SQLConn.UpdateBankAccountTransactions(bankId, -amountBank, " تحويل الأموال - من الحساب البنكي إلى الخزينة",SQLConn.trans);


                SQLConn.UpdateUserTreasury(treasId, amountBank, SQLConn.trans);
                SQLConn.UpdateUserTreasuryTransactions((int)cmbTreasury.SelectedValue, amountBank, SQLConn.trans, bankId, "تحويل الأموال - من الحساب البنكي إلى الخزينة");

                SQLConn.trans.Commit();

                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحويل الأموال - من الحساب البنكي إلى الخزينة");

                txtAmountTransfert.Text = "";
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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تحويل الأموال - من الحساب البنكي إلى الخزينة  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
