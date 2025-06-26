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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace MarsaAlloaloah.Forms.TransfertMoney
{
    public partial class frmTransfertreasurytotreasury : Form
    {
        public frmTransfertreasurytotreasury()
        {
            InitializeComponent();
            GetTreasuryLista();
            GetTreasuryListb();
        }
        public void GetTreasuryLista()
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
                treasury_a.DataSource = dtbl;
                treasury_a.ValueMember = "ID";
                treasury_a.DisplayMember = "Name";
                treasury_b.DataSource = dtbl;
                treasury_b.ValueMember = "ID";
                treasury_b.DisplayMember = "Name";
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
        public void GetTreasuryListb()
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
                treasury_b.DataSource = dtbl;
                treasury_b.ValueMember = "ID";
                treasury_b.DisplayMember = "Name";
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (int.Parse(treasury_a.SelectedValue.ToString()) == int.Parse(treasury_b.SelectedValue.ToString()))
            {
                Interaction.MsgBox("لا يمكن التحويل لنفس الخزينه");
                return;
            }
            if (int.Parse(treasury_a.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الخزينة");
                return;
            }
            if (int.Parse(treasury_b.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الخزينة");
                return;
            }
            if (txtAmountTransfert.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال المبلغ.", MsgBoxStyle.Information, "تحويل الأموال - من الخزينه إلى الخزينة");
                return;
            }
            string amount = Common.ConvertCurrencyFieldToStringOnSqlQuery(txtAmountTransfert.Text);
            var Am = Convert.ToDecimal(amount);
            SQLConn.ConnDB();
            SQLConn.UpdateUserTreasury((int)treasury_a.SelectedValue, -Am, SQLConn.trans);
            //SQLConn.UpdateUserTreasuryTransactions((int)treasury_a.SelectedValue, -Am, SQLConn.trans, (int)treasury_b.SelectedValue, "تحويل الأموال - من الخزينة إلى الخزينة");
            try
            {
                SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID,Libelle, Date) 
values( @NewBalance, @treasuryID , @Libelle, @Date)";

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", -Am);
                SQLConn.cmd.Parameters.AddWithValue("@treasuryID", (int)treasury_a.SelectedValue);
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", "تحويل الأموال - من الخزينة إلى الخزينة");
                SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            SQLConn.UpdateUserTreasury((int)treasury_b.SelectedValue, Am, SQLConn.trans);
            MessageBox.Show("تم تحويل الاموال","التحويل");
            GetTreasuryLista();
            GetTreasuryListb();
            txtAmountTransfert.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
