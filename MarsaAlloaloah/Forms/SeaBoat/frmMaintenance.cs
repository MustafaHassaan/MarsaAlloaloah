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
    public partial class frmMaintenance : Form
    {
        private int id;
        private int idmaintenance;

        public frmMaintenance()
        {
            InitializeComponent();
        }

        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            GridFill();
            SeaTransportTypeFill();            
        }
        public void SeaTransportTypeFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM SeaTransportType Order by ID, Name ");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbTypeID.DataSource = dtbl;
                cmbTypeID.ValueMember = "ID";
                cmbTypeID.DisplayMember = "Name";
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

        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(cmbSeaTransportID.Text))
            //{
                var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();
                int id = int.Parse(SelectedValue);
                if (id > 0)
                {
                    FillSeaTransportFill(id);
                }
            //}
        }

        public void FillSeaTransportFill(int TypeID)
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"SELECT ID, Name, TypeID FROM SeaTransport Where TypeID = " + TypeID + " And InService = 1 "
                        + " Order by TypeID, ID, Name ");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbSeaTransportID.DataSource = dtbl;
                cmbSeaTransportID.ValueMember = "ID";
                cmbSeaTransportID.DisplayMember = "Name";
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
        private void GridFill()
        {
            
                try
                {
                    DataTable dtbl = new DataTable();
                    dtbl = MaintenanceGridFill();
                    dataGridView1.DataSource = dtbl;
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.ToString());
                }

        }

        private DataTable MaintenanceGridFill()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT SeaTransport.Name AS SeaName, SeaTransportType.Name AS TypeName, Maintenance.Date, Maintenance.Notes, Maintenance.ID
FROM         SeaTransport INNER JOIN
                      SeaTransportType ON SeaTransport.TypeID = SeaTransportType.ID INNER JOIN
                      Maintenance ON SeaTransport.ID = Maintenance.SeaTransportID ";
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

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "صيانة واسطة بحرية", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
             id = Int32.Parse(dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString());
            }
            if (btnSave.Text == "حفظ")
            {
                AddMaintenance();
                GridFill();
            }
            else
            {
                UpdateMaintenance(id);
                GridFill();
            }


        }

        private void UpdateMaintenance(int id)
        {
            string selectedSearch = string.Empty;


            if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الواسطة البحرية:");
                return;
            }
            if (textBox2.Text == "")
            {
                Interaction.MsgBox("من فضلك  أدخل الملاحظات:");
                return;
            }


            try
            {
                SQLConn.sqL = @" update  Maintenance set Date= @Date,Notes=@Notes,SeaTransportID=@SeaTransportID where ID=@id ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                SQLConn.cmd.Parameters.AddWithValue("@Notes", textBox2.Text);
                SQLConn.cmd.Parameters.Add("@SeaTransportID", SqlDbType.Int).Value = int.Parse(cmbSeaTransportID.SelectedValue.ToString());
                SQLConn.cmd.Parameters.AddWithValue("@id", id);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم التحديث الصيانة بنجاح.", MsgBoxStyle.Information, "تحديث الصيانة");
                Clear();
                btnSave.Text = "حفظ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddMaintenance()
        {
            string selectedSearch = string.Empty;

            if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الواسطة البحرية:");
                return;
            }
            if (textBox2.Text == "")
            {
                Interaction.MsgBox("من فضلك  أدخل الملاحظات:");
                return;
            }


            SQLConn.sqL = @" INSERT INTO Maintenance( Date, Notes, SeatransportID)
                    VALUES ( @Date, @Notes, @SeatransportID); SELECT CAST(scope_identity() AS int) ";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SQLConn.cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dateTimePicker1.Value;
            SQLConn.cmd.Parameters.AddWithValue("@Notes", textBox2.Text);
            SQLConn.cmd.Parameters.Add("@SeaTransportID", SqlDbType.Int).Value = int.Parse(cmbSeaTransportID.SelectedValue.ToString());
            SQLConn.cmd.ExecuteScalar();
            Interaction.MsgBox("تمت الإضافة بنجاح.", MsgBoxStyle.Information, "  صيانة واسطة بحرية  ");
           Clear();
            btnSave.Text = "حفظ";


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DateTime dt = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["date"].Value.ToString());
                    dateTimePicker1.Value = dt;
                    cmbTypeID.Text = dataGridView1.SelectedRows[0].Cells["Type"].Value.ToString();
                    cmbSeaTransportID.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                    textBox2.Text = dataGridView1.SelectedRows[0].Cells["dgmobile"].Value.ToString();
                    btnSave.Text = "تحديث";
                    btnDelete.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            btnSave.Text = "حفظ";
            cmbTypeID.Text = "";          
            dateTimePicker1.Value = DateTime.Now;
            textBox2.Text = "";
            cmbSeaTransportID.Text = "";
            SeaTransportTypeFill();
        }
        private void DeleteFunction()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idmaintenance = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Column1"].Value);

                try
                {
                    SQLConn.sqL = "Delete  From Maintenance   WHERE   ID=@id";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                    SQLConn.cmd.Parameters.AddWithValue("@id", idmaintenance);
                    SQLConn.cmd.ExecuteNonQuery();  
                  Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف  صيانة واسطة بحرية");
                    Clear();
                    GridFill();
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
            else
            {
                Interaction.MsgBox("يجب عليك تحديد عملية الصيانة التي تريد حذفها أولاً");
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا الكارت", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
            }
            else
            {
                return;
            }
        }

        private void cmbSeaTransportID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    }
