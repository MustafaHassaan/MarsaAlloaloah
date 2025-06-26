using MarsaAlloaloah.Forms.SeaBoat;
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
    public partial class frmBoatsOrder : Form
    {
        public static int SelectedSeaTransportID;

        public frmBoatsOrder()
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
                //dr["ID"] = 0;
                //dr["Name"] = "--اختر--";
                //dtbl.Rows.InsertAt(dr, 0);
                cmbTypeID.DataSource = dtbl;
                // cmbTypeID.ValueMember = "ID";
                // cmbTypeID.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        private void frmBoatsOrder_Load(object sender, EventArgs e)
        {
            SeaTransportTypeFill();
        }

        #region GridFill
        public void Gridfill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = ProductsFill(SelectedSeaTransportID);
                dgvSeaTransport.DataSource = dtbl;
            }
            catch (Exception ex)
            {

                Interaction.MsgBox(ex.ToString());
            }
        }
        public DataTable ProductsFill(int SeaTransportType)
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            try
            {
                //SQLConn.sqL = "SELECT ID,Name ,SeaTransportOrder FROM SeaTransport Where TypeID= " + SeaTransportType + " Order by SeaTransportOrder";
                SQLConn.sqL = @"SELECT 
                                ID,
                                Name,
                                SeaTransportOrder
                                FROM SeaTransport 
                                Where TypeID =  " + SeaTransportType +""+
                                @"And InService = 1 
                                And ID Not IN(
                                SELECT      
                                SeaTransport.ID
                                FROM Tickets 
                                Inner JOIN SeaTransport 
                                ON Tickets.SeaTransportID = SeaTransport.ID
                                WHERE (IsBusy = 1) And  
                                (Tickets.StartDate = CAST(GETDATE() as DATE)) 
                                And(EndTime > CONVERT(TIME, SYSDATETIME())))
                                Order by SeaTransportOrder";
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
        #endregion
        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSeaTransportID = int.Parse(cmbTypeID.SelectedValue.ToString());
            Gridfill();
        }
        private void UpdateOrder(int Order, int ID)
        {
            try
            {
                SQLConn.sqL = "Update SeaTransport Set SeaTransportOrder= @Order Where ID = @ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Order", Order);
                SQLConn.cmd.Parameters.AddWithValue("@ID", ID);
                SQLConn.cmd.ExecuteNonQuery();
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
            try
            {
                for (int i = 0; i < dgvSeaTransport.Rows.Count - 1; i++)
                {
                    int id = 0, order = 0;
                    if (dgvSeaTransport.Rows[i].Cells["ID"] != null && dgvSeaTransport.Rows[i].Cells["ID"].Value != null)
                        id = Convert.ToInt32(dgvSeaTransport.Rows[i].Cells["ID"].Value);
                    if (dgvSeaTransport.Rows[i].Cells["SeaTransportOrder"] != null && dgvSeaTransport.Rows[i].Cells["SeaTransportOrder"].Value != null)
                        order = Convert.ToInt32(dgvSeaTransport.Rows[i].Cells["SeaTransportOrder"].Value);
                    if (order > 0 && id > 0)
                        UpdateOrder(order, id);

                }
                Interaction.MsgBox("تم ترتيب سير الوسائط البحرية بنجاح.", MsgBoxStyle.Information, "ترتيب سير الوسائط البحرية");
                Gridfill();

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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "ترتيب سير الوسائط البحرية", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmsortboats  FSB = new Frmsortboats();
            FSB.Show();
        }
    }
}
