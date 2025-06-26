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

namespace MarsaAlloaloah.Forms
{
    public partial class Jobs : Form
    {
        public Jobs()
        {
            InitializeComponent();
        }
        int SelectedRoleID;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRole.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال اسم الوظيفة.", MsgBoxStyle.Information, "الصلاحيات");
                return;
            }
            if (btnSave.Text == "حفظ")
            {
                AddRole();
                txtRole.Text = "";
            }
            else
            {
                UpdateRole();
                txtRole.Text = "";
                btnSave.Text = "حفظ";
            }
        }
        private void AddRole()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO Jobs (JobName) VALUES (N'" + txtRole.Text + "')";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حفظ بيانات الوظيفة.", MsgBoxStyle.Information, "اضافة وظبفة");
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
        private void UpdateRole()
        {
            try
            {
                SQLConn.sqL = "UPDATE Jobs SET JobName= N'" + txtRole.Text + "' WHERE ID = '" + SelectedRoleID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات الوظيفة");
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
        public void ClearFunction()
        {
            try
            {
                txtRole.Clear();
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
                SQLConn.sqL = "Delete From Jobs WHERE ID = " + SelectedRoleID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف وظبفة");
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFunction();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذه الوظيفة", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
            }
            else
            {
                return;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "الوظائف", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        private void Jobs_Load(object sender, EventArgs e)
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
        public void Gridfill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                //RoleSP spRole = new RoleSP();
                dtbl = RoleViewGridFill();
                dgvRoles.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        public DataTable RoleViewGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("ID", typeof(int));
            dtbl.Columns["ID"].AutoIncrement = true;
            dtbl.Columns["ID"].AutoIncrementSeed = 1;
            dtbl.Columns["ID"].AutoIncrementStep = 1;
            try
            {

                SQLConn.sqL = "select * from Jobs";
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
                DataTable RoleInfo = RoleView(SelectedRoleID);
                txtRole.Text = RoleInfo.Rows[0]["JobName"].ToString();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        public DataTable RoleView(int RoleID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select * from Jobs where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", RoleID);
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
        private void dgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    SelectedRoleID = Convert.ToInt32(dgvRoles.CurrentRow.Cells["ID"].Value);
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
