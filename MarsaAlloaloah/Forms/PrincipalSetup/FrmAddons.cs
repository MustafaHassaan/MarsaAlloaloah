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
    public partial class FrmAddons : Form
    {
        int SelectedAddon;
        public FrmAddons()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAddonName.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال إسم الإضافة.", MsgBoxStyle.Information, "الإضافات");
                return;
            }

            if (btnSave.Text == "حفظ")
            {
                AddFunction();
                ClearFunction();
            }
            else
            {

                UpdateFunction();
                ClearFunction();


            }
        }


        private void AddFunction()
        {

            try
            {
                SQLConn.sqL = "INSERT INTO Addons(Name,Price) VALUES(@Name,@Price)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtAddonName.Text);
                SQLConn.cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Common.ConvertTxtToDecimal(txtPrice.Text);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حفظ بيانات الإضافة بنجاح.", MsgBoxStyle.Information, "اضافة إضافة");
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
        private void UpdateFunction()
        {
            try
            {
                SQLConn.sqL = "UPDATE Addons SET Name= @Name,Price= @Price WHERE ID = @ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtAddonName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@ID", SelectedAddon);
                SQLConn.cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Common.ConvertTxtToDecimal(txtPrice.Text);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات الإضافة");
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
        private void Gridfill()
        {

            try
            {
                DataTable dtbl = new DataTable();
                dtbl = AddonsGridFill();
                dgvAddons.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        public DataTable AddonsGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {

                SQLConn.sqL = "select * from Addons";
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
        private void ClearFunction()
        {
            btnSave.Text = "حفظ";
            txtAddonName.Text = "";
            txtPrice.Text = "";
        }

        private void dgvAddons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    SelectedAddon= Convert.ToInt32(dgvAddons.CurrentRow.Cells["dgvAddonID"].Value);
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
        private void FillControls()
        {
            try
            {
                DataTable SeatransportInfo = AddonView(SelectedAddon);
                txtAddonName.Text = SeatransportInfo.Rows[0]["Name"].ToString();
                txtPrice.Text = SeatransportInfo.Rows[0]["Price"].ToString();

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable AddonView(int AddonID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = "select * from Addons where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", AddonID);
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

        private void FrmAddons_Load(object sender, EventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFunction();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذه الاضافه", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
                ClearFunction();
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
                SQLConn.sqL = "Delete From Addons WHERE ID = " + SelectedAddon + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف إضافة");
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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "الاضافات", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
