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

namespace MarsaAlloaloah.Forms.SeaBoat
{
    public partial class Frmsortboats : Form
    {
        public static int SelectedSeaTransportID;
        public Frmsortboats()
        {
            InitializeComponent();
        }

        private void Frmsortboats_Load(object sender, EventArgs e)
        {
            SeaTransportTypeFill();
        }
        public void SeaTransportTypeFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM SeaTransportType");
                DataRow dr = dtbl.NewRow();
                cmbTypeID.DataSource = dtbl;
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
                                Name
                                FROM SeaTransport 
                                Where TypeID =  " + SeaTransportType + "" +
                                @"And InService = 1 
                                And ID IN(
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
        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSeaTransportID = int.Parse(cmbTypeID.SelectedValue.ToString());
            Gridfill();
        }
    }
}
