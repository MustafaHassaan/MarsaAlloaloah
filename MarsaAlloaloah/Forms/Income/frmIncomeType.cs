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
    public partial class frmIncomeType : Form
    {
        int selectedIncomeTypeID;

        public frmIncomeType()
        {
            InitializeComponent();
        }

        private void frmIncomeType_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtIncomeType.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال نوع الإيراد.", MsgBoxStyle.Information, " نوع الإيراد");
                return;
            }

            if (btnSave.Text == "حفظ")
            {
                AddIncomeType();
                txtIncomeType.Text = "";
            }
            else
            {
                UpdateIncomeType();
                txtIncomeType.Text = "";
                btnSave.Text = "حفظ";
            }
        }

        private void AddIncomeType()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO IncomeType(Name) VALUES(@Name)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtIncomeType.Text);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حفظ بيانات  نوع الإيراد بنجاح.", MsgBoxStyle.Information, " نوع الإيراد");
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
        private void UpdateIncomeType()
        {
            try
            {
                SQLConn.sqL = "UPDATE IncomeType SET Name =@Name WHERE  ID = '" + selectedIncomeTypeID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtIncomeType.Text);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات نوع الإيراد");
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
                dtbl = IncomeTypeGridFill();
                dgvIncomeType.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        public DataTable IncomeTypeGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            try
            {
                SQLConn.sqL = "Select * from IncomeType";
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

        private void dgvIncomeType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && dgvIncomeType.CurrentRow.Cells["ID"] != null && dgvIncomeType.CurrentRow.Cells["ID"].Value != null )
                {
                    selectedIncomeTypeID = Convert.ToInt32(dgvIncomeType.CurrentRow.Cells["ID"].Value);
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
                DataTable IncomeType = GetIncomeType(selectedIncomeTypeID);
                txtIncomeType.Text = IncomeType.Rows[0]["Name"].ToString();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable GetIncomeType(int incomeTypeID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select * from IncomeType where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", incomeTypeID);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "نوع الإيراد", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
                txtIncomeType.Clear();
                btnSave.Text = "حفظ";
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف نوع الايراد", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
                txtIncomeType.Clear();
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
                SQLConn.sqL = "Delete From IncomeType WHERE ID = " + selectedIncomeTypeID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف نوع الإيراد");
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
    }
}
