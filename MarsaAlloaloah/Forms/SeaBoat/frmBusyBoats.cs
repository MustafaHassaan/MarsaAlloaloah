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
using System.Diagnostics;

namespace MarsaKanzAbhar
{
    public partial class frmBusyBoats : Form
    {

        System.Windows.Forms.Timer timer = new Timer();
        public frmBusyBoats()
        {
            InitializeComponent();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (dgvbusySeatransport.Rows.Count >= 1)
            {
                for (int i = 0; i < dgvbusySeatransport.Rows.Count - 1; i++)
                {
                    if (dgvbusySeatransport.Rows[i].Cells["Counter"] != null && dgvbusySeatransport.Rows[i].Cells["Counter"].Value != null
                        && !string.IsNullOrEmpty(dgvbusySeatransport.Rows[i].Cells["Counter"].Value.ToString()))
                    {
                        TimeSpan RestTime = TimeSpan.Parse(dgvbusySeatransport.Rows[i].Cells["Counter"].Value.ToString());
                        TimeSpan tick = new TimeSpan(0, 0, 1);
                        var S = RestTime.Subtract(tick);
                        dgvbusySeatransport.Rows[i].Cells["Counter"].Value = S;
                        //Reorder SeaTransport
                        int TypeID = 0, SeaTransportID = 0;
                        if (dgvbusySeatransport.Rows[i].Cells["gvSeaTransportTypeID"] != null
                            && dgvbusySeatransport.Rows[i].Cells["gvSeaTransportTypeID"].Value != null
                            && string.IsNullOrEmpty(dgvbusySeatransport.Rows[i].Cells["gvSeaTransportTypeID"].Value.ToString()))
                        {
                            TypeID = int.Parse(dgvbusySeatransport.Rows[i].Cells["gvSeaTransportTypeID"].Value.ToString());
                        }
                        if (dgvbusySeatransport.Rows[i].Cells["gvSeaTransportID"] != null && dgvbusySeatransport.Rows[i].Cells["gvSeaTransportID"].Value != null
                            && !string.IsNullOrEmpty(dgvbusySeatransport.Rows[i].Cells["gvSeaTransportID"].Value.ToString()))
                            SeaTransportID = int.Parse(dgvbusySeatransport.Rows[i].Cells["gvSeaTransportID"].Value.ToString());

                        int Order = 1;
                        if (dgvbusySeatransport.Rows[i].Cells["gvOrder"] != null
                            && dgvbusySeatransport.Rows[i].Cells["gvOrder"].Value != null
                            && !string.IsNullOrEmpty(dgvbusySeatransport.Rows[i].Cells["gvOrder"].Value.ToString()))
                            Order = int.Parse(dgvbusySeatransport.Rows[i].Cells["gvOrder"].Value.ToString());

                        DataTable dtblLastOrder = SelectLastSeaTransportOrderByType(TypeID);

                        int LastOrderNo = 0;
                        if (dtblLastOrder.Rows.Count > 0 && dtblLastOrder.Rows[0]["SeaTransportOrder"] != null
                            && !string.IsNullOrEmpty(dtblLastOrder.Rows[0]["SeaTransportOrder"].ToString()))
                            LastOrderNo = int.Parse(dtblLastOrder.Rows[0]["SeaTransportOrder"].ToString());

                        int LastSeaTransportID = 0;
                        if (dtblLastOrder.Rows.Count > 0 && dtblLastOrder.Rows[0]["ID"] != null && !string.IsNullOrEmpty(dtblLastOrder.Rows[0]["ID"].ToString()))
                            LastSeaTransportID = int.Parse(dtblLastOrder.Rows[0]["ID"].ToString());

                        if (S.TotalSeconds < tick.TotalSeconds)
                        {
                            Gridfill();
                            //Update Replace Order
                            UpdateOrder(SeaTransportID, LastOrderNo);

                            UpdateOrder(LastSeaTransportID, Order);
                        }
                    }
                }
            }
        }

        #region GridFill
        DataTable dtbl = new DataTable();

        public void Gridfill()
        {
            try
            {
                dtbl = SeaTransportFill();
                dtbl.Columns.Add("EndTime");
                dtbl.Columns.Add("RestTime");
                dtbl.Columns.Add("Counter");

                for (int i = 0; i < dtbl.Rows.Count; i++)
                {
                    DateTime StartTime = Convert.ToDateTime(dtbl.Rows[i]["StartTime"].ToString());
                    double Duration = Convert.ToDouble(dtbl.Rows[i]["DurationValue"].ToString());
                    DateTime EndTime = StartTime.AddMinutes(Duration);

                    dtbl.Rows[i]["EndTime"] = EndTime.ToShortTimeString();

                    TimeSpan RestTime = EndTime.Subtract(DateTime.Now);

                    dtbl.Rows[i]["RestTime"] = RestTime;
                    dtbl.Rows[i]["Counter"] = RestTime;
                }
                dgvbusySeatransport.DataSource = dtbl;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Enabled = true;
                timer.Interval = 1000; // 1 second
                timer.Start();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        public DataTable SeaTransportFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {

                SQLConn.sqL = @"SET DATEFORMAT ymd; SELECT dbo.Tickets.StartDate,dbo.SeaTransport.Name,dbo.SeaTransport.TypeID,dbo.SeaTransport.ID,
                                dbo.SeaTransport.SeaTransportOrder, dbo.Tickets.DurationValue,dbo.Tickets.StartTime
                                FROM dbo.Tickets INNER JOIN dbo.SeaTransport ON dbo.Tickets.SeaTransportID = dbo.SeaTransport.ID 
                                Where ( StartDate = CAST(GETDATE() as date) )  and   EndTime > CONVERT ( time, SYSDATETIME() ) ; ";
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

        private void frmBusyBoats_Load(object sender, EventArgs e)
        {
            Gridfill();
        }
        public DataTable SelectLastSeaTransportOrderByType(int TypeID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"select *  from (
                Select Max(dbo.SeaTransport.SeaTransportOrder) as SeaTransportOrder ,dbo.SeaTransport.ID,dbo.SeaTransport.TypeID  
                From [dbo].[SeaTransport]
                group by dbo.SeaTransport.ID, dbo.SeaTransport.TypeID) as s  where s.TypeID = " + TypeID + " order by SeaTransportOrder desc";
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

        private void UpdateOrder(int SeaTransportID, int SeaTransportOrder)
        {
            try
            {
                SQLConn.sqL = "Update SeaTransport  SET SeaTransportOrder=@Order WHERE ID = @SeaTransportID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Order", SeaTransportOrder);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", SeaTransportID);
                SQLConn.cmd.ExecuteNonQuery();
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

        private void frmBusyBoats_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
