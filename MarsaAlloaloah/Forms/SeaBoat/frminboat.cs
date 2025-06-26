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
    public partial class frminboat : Form
    {
        int id;

        public int InSeaTransportid { get; private set; }

        public frminboat()
        {
            InitializeComponent();
        }
        public void SeaTransportTypeFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM SeaTransportType");
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "إنزال واسطة بحرية", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                id = Int32.Parse(dataGridView1.SelectedRows[0].Cells["IDD"].Value.ToString());
            }
            if (btnSave.Text == "حفظ")
            {
                AddInSeaTransport();
                GridFill();
            }
            else
            {
                Updatelanding(id);
                GridFill();
            }


        }

        private void Updatelanding(int id)
        {
            string selectedSearch = string.Empty;

            if (int.Parse(cmbTypeID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر نوع الواسطة البحرية");
                return;
            }

            if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الواسطة البحرية");
                return;
            }

            if (textBox1.Text == "")
            {
                Interaction.MsgBox("من فضلك أدخل عداد الخروج");
                return;
            }
            if (textBox2.Text == "")
            {
                Interaction.MsgBox("من فضلك  أدخل إسم الشخص");
                return;
            }

            if (textBox4.Text == "")
            {
                Interaction.MsgBox("من فضلك  أدخل السبب");
                return;
            }

            try
            {
                SQLConn.sqL = @" update  InSeaTransport set SeatransportID=@SeaTransportID,Date= @Date,Time=@Time,Reason=@Reason,PersonName=@PersonName ,InCounter=@InCounter where ID=@id ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.Add("@SeaTransportID", SqlDbType.Int).Value = int.Parse(cmbSeaTransportID.SelectedValue.ToString());
                SQLConn.cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                SQLConn.cmd.Parameters.Add("@Time", SqlDbType.DateTime).Value = dateTimePicker2.Value;
                SQLConn.cmd.Parameters.AddWithValue("@Reason", textBox4.Text);
                SQLConn.cmd.Parameters.AddWithValue("@PersonName", textBox2.Text);
                SQLConn.cmd.Parameters.Add("@InCounter", SqlDbType.Int).Value = int.Parse(textBox1.Text);
                SQLConn.cmd.Parameters.AddWithValue("@id", id);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم التحديث  بنجاح.", MsgBoxStyle.Information, " التحديث ");
                Clear();
                btnSave.Text = "حفظ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Clear()
        {
            btnSave.Text = "حفظ";

            cmbTypeID.Text = "";
            cmbSeaTransportID.Text = "";
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox2.Text = "";
            textBox4.Text = "";
            SeaTransportTypeFill();
        }

        private void AddInSeaTransport()
        {
            string selectedSearch = string.Empty;

            if (int.Parse(cmbTypeID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر نوع الواسطة البحرية");
                return;
            }

            if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الواسطة البحرية");
                return;
            }

            if (textBox1.Text == "")
            {
                Interaction.MsgBox("من فضلك أدخل عداد الدخول");
                return;
            }
            if (textBox2.Text == "")
            {
                Interaction.MsgBox("من فضلك  أدخل إسم الشخص");
                return;
            }

            if (textBox4.Text == "")
            {
                Interaction.MsgBox("من فضلك  أدخل السبب");
                return;
            }


            SQLConn.sqL = @" INSERT INTO InSeaTransport( SeatransportID, Date, Time, Reason, PersonName,InCounter)
                    VALUES ( @SeatransportID, @Date, @Time, @Reason,@PersonName,@InCounter); SELECT CAST(scope_identity() AS int) ";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);

            SQLConn.cmd.Parameters.Add("@SeaTransportID", SqlDbType.Int).Value = int.Parse(cmbSeaTransportID.SelectedValue.ToString());
            SQLConn.cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dateTimePicker1.Value;
            SQLConn.cmd.Parameters.Add("@Time", SqlDbType.DateTime).Value = dateTimePicker2.Value;
            SQLConn.cmd.Parameters.AddWithValue("@Reason", textBox4.Text);
            SQLConn.cmd.Parameters.AddWithValue("@PersonName", textBox2.Text);
            SQLConn.cmd.Parameters.Add("@InCounter", SqlDbType.Int).Value = int.Parse(textBox1.Text);
            SQLConn.cmd.ExecuteScalar();
            Interaction.MsgBox("تمت الإضافة بنجاح.", MsgBoxStyle.Information, "  إنزال واسطة بحرية ");
            //Clear();
            btnSave.Text = "حفظ";

        
    }
        public void verif_entier(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private DataTable InSeaTransportGridFill()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT SeaTransportType.Name as TypeName ,SeaTransport.Name,InSeaTransport.ID, InSeaTransport.Date, InSeaTransport.Time, InSeaTransport.Reason, InSeaTransport.PersonName, InSeaTransport.InCounter
                FROM         InSeaTransport 
INNER JOIN
                      SeaTransport ON InSeaTransport.SeatransportID = SeaTransport.ID
INNER JOIN
                SeaTransportType ON SeaTransport.TypeID = SeaTransportType.ID   ";
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

        public void GridFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = InSeaTransportGridFill();
                dataGridView1.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void frminboat_Load(object sender, EventArgs e)
        {
            GridFill();
            SeaTransportTypeFill();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            verif_entier(e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DateTime dt = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["dgclientname"].Value.ToString());
                    dateTimePicker1.Value = dt;
                    DateTime dt2 = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["dgnid"].Value.ToString());
                    dateTimePicker2.Value = dt2;
                    
                    cmbTypeID.Text = dataGridView1.SelectedRows[0].Cells["TypeName"].Value.ToString(); 
                    
                    cmbSeaTransportID.Text = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                    
                    textBox1.Text = dataGridView1.SelectedRows[0].Cells["dgmobile"].Value.ToString();
                    textBox2.Text = dataGridView1.SelectedRows[0].Cells["Column2"].Value.ToString();
                    textBox4.Text = dataGridView1.SelectedRows[0].Cells["السبب"].Value.ToString();
                    btnSave.Text = "تحديث";
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void DeleteFunction()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                InSeaTransportid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDD"].Value);
                try
                {
                    SQLConn.ConnDB();
                    SQLConn.sqL = "Delete  From InSeaTransport   WHERE   ID=@InSeaTransportid";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.Parameters.AddWithValue("@InSeaTransportid", InSeaTransportid);
                    SQLConn.cmd.ExecuteNonQuery();
                    Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف   إنزال واسطة بحرية");
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
                    Clear();
                }
            }
            else
            {
                Interaction.MsgBox("يجب عليك تحديد عملية الانزال التي تريد حذفها أولاً");
                return;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف دخول هذه الواسطة", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
            }
            else
            {
                return;
            }
        }

        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();
            int id = int.Parse(SelectedValue);
            if (id > 0)
            {
                FillSeaTransportFill(id);
            }
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

    }
}
