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
    public partial class frmExpensesType : Form
    {
        int selectedExpensesTypeID;

        public frmExpensesType()
        {
            InitializeComponent();
        }


        private void frmExpensesType_Load(object sender, EventArgs e)
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtExpensesType.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال نوع المصروف.", MsgBoxStyle.Information, "نوع المصروف");
                return;
            }

            if (btnSave.Text == "حفظ")
            {
                AddExpensesType();
                txtExpensesType.Text = "";
            }
            else
            {
                UpdateExpensesType();
                txtExpensesType.Text = "";
                btnSave.Text = "حفظ";
            }
        }

        private void UpdateExpensesType()
        {
            try
            {
                SQLConn.sqL = "UPDATE ExpensesType SET ExpensesType =@ExpensesType WHERE  ID = '" + txtExpensesType.Text + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@ExpensesType", txtExpensesType.Text);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات نوع المصروف");
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

        private void AddExpensesType()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO ExpensesType(ExpensesType) VALUES(@ExpensesType)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@ExpensesType", txtExpensesType.Text);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حفظ بيانات  نوع المصروف بنجاح.", MsgBoxStyle.Information, "نوع المصروف");
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
                dtbl = ExpensesTypeGridFill();
                dgvExpensesType.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private DataTable ExpensesTypeGridFill()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = "Select * from ExpensesType";
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

        private void dgvExpensesType_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void FillControls()
        {
            try
            {
                DataTable expensesTypeInfo = GetExpensesType(selectedExpensesTypeID); 
                txtExpensesType.Text = expensesTypeInfo.Rows[0]["ExpensesType"].ToString();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private DataTable GetExpensesType(int selectedExpensesTypeID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = "select * from ExpensesType where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", selectedExpensesTypeID);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف نوع المصروف", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
                txtExpensesType.Clear();
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
                SQLConn.sqL = "Delete From ExpensesType WHERE ID = " + selectedExpensesTypeID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف نوع المصروف");
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "نوع المصروف", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
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

        public void ClearFunction()
        {
            try
            {
                txtExpensesType.Clear();
                btnSave.Text = "حفظ";
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void dgvExpensesType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && dgvExpensesType.CurrentRow.Cells[0] != null && dgvExpensesType.CurrentRow.Cells[0].Value != null)
                {
                    selectedExpensesTypeID = Convert.ToInt32(dgvExpensesType.CurrentRow.Cells[0].Value);
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
    }
}
