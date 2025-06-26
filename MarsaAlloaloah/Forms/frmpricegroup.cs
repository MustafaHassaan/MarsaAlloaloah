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
    public partial class frmpricegroup : Form
    {
        int SelectedPriceGroupID;
        public frmpricegroup()
        {
            InitializeComponent();
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPriceGroup.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال مجموعة التسعير.", MsgBoxStyle.Information, "مجموعة التسعير");
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
        private void UpdateFunction()
        {
            try
            {
                SQLConn.sqL = "UPDATE PriceGroup SET Name= '" + txtPriceGroup.Text + "' WHERE ID = '" + SelectedPriceGroupID + "'";
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

        private void AddFunction()
        {

            try
            {
                SQLConn.sqL = "INSERT INTO PriceGroup(Name) VALUES(@Name); SELECT CAST(scope_identity() AS int);";
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtPriceGroup.Text);
                
                int newID = (int)SQLConn.cmd.ExecuteScalar();
                
                if (newID > 0)
                {
                    SQLConn.trans.Commit();
                    Interaction.MsgBox("تم حفظ بيانات مجموعة التسعير بنجاح.", MsgBoxStyle.Information, "اضافة مجموعة التسعير");
                    Gridfill();
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

        public void Gridfill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = PriceGroupGridFill();
                dgvPriceGroup.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        public DataTable PriceGroupGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {

                SQLConn.sqL = "select * from PriceGroup";
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
        public void ClearFunction()
        {
            try
            {
                txtPriceGroup.Clear();
                btnSave.Text = "حفظ";
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void dgvPriceGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    SelectedPriceGroupID = Convert.ToInt32(dgvPriceGroup.CurrentRow.Cells["dgvPriceGroupID"].Value);
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
                DataTable SeatransportInfo = PriceGroupView(SelectedPriceGroupID);
                txtPriceGroup.Text = SeatransportInfo.Rows[0]["Name"].ToString();
            

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable PriceGroupView(int PriceGroupID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select * from PriceGroup where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", PriceGroupID);
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

        private void frmpricegroup_Load(object sender, EventArgs e)
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
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذه المجموعة", "رسالة تأكيد", MessageBoxButtons.YesNo);
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
                SQLConn.sqL = "Delete From PriceGroup WHERE ID = " + SelectedPriceGroupID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف مجموعة التسعير");
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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "التسعير", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
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
