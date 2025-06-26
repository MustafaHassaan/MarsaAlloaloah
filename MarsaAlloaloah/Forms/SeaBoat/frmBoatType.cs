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
    public partial class frmBoatType : Form
    {
        int SelectedSeaTransportTypeID;

        public frmBoatType()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSeaTrasportType.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال نوع الواسطة البحرية.", MsgBoxStyle.Information, "نوع الواسطة البحرية");
                return;
            }

            if (btnSave.Text == "حفظ")
            {
                AddSeaTransportType();
                txtSeaTrasportType.Text = "";
            }
            else
            {
                UpdateSeaTransportType();
                txtSeaTrasportType.Text = "";
                btnSave.Text = "حفظ";
            }

        }

        private void AddSeaTransportType()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO SeaTransportType(Name) VALUES(@Name)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtSeaTrasportType.Text);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حفظ بيانات نوع الواسطة البحرية بنجاح.", MsgBoxStyle.Information, "اضافة واسطة بحرية");
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
        private void UpdateSeaTransportType()
        {
            try
            {
                SQLConn.sqL = "UPDATE SeaTransportType SET Name= '" + txtSeaTrasportType.Text + "' WHERE ID = '" + SelectedSeaTransportTypeID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات نوع الواسطة البحرية");
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
        private void dgvSeatransportType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    SelectedSeaTransportTypeID = Convert.ToInt32(dgvSeatransportType.CurrentRow.Cells["dgvSeaTransportID"].Value);
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

        private void frmBoatType_Load(object sender, EventArgs e)
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
                dgvSeatransportType.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        public DataTable RoleViewGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {

                SQLConn.sqL = "select * from SeaTransportType";
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
                DataTable SeatransportInfo = SeaTransportTypeView(SelectedSeaTransportTypeID);
                txtSeaTrasportType.Text = SeatransportInfo.Rows[0]["Name"].ToString();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable SeaTransportTypeView(int SeaTransportTypeID)
        {
            DataTable dtbl = new DataTable();        
            try
            {

                SQLConn.sqL = "select * from SeaTransportType where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", SeaTransportTypeID);
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
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف نوع الواسطة", "رسالة تأكيد", MessageBoxButtons.YesNo);
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
                SQLConn.sqL = "Delete From SeaTransportType WHERE ID = " + SelectedSeaTransportTypeID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف نوع الواسطة البحرية");
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

        public void ClearFunction()
        {
            try
            {
                txtSeaTrasportType.Clear();
                btnSave.Text = "حفظ";
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "نوع الوسائط البحرية", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }

        }


        public static void CloseMessage(System.Windows.Forms.Form frm)
        {
           
        }
    }
}
