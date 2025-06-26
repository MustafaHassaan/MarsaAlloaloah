using MarsaAlloaloah.CrystalReports;
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

namespace MarsaAlloaloah.FrmReports
{
    public partial class MPM : Form
    {
        public MPM()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تقرير جميع الوسائط", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void MPM_Load(object sender, EventArgs e)
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
                dr["ID"] = 0;
                dr["Name"] = "--الكل--";
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
        public void FillSeaTransportFill(int TypeID)
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"SELECT ID, Name, TypeID FROM SeaTransport Where TypeID = " + TypeID + " And InService = 1 "
                        //+ @"  and ID not IN(
                        //    SELECT      SeaTransport.ID
                        //    FROM         Tickets LEFT OUTER JOIN
                        //    SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID
                        //   WHERE(Tickets.StartDate = CAST(GETDATE() as DATE)) and(EndTime > CONVERT(TIME, SYSDATETIME()))
                        //    ) 
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
        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();
            if (int.Parse(SelectedValue) > 0)
            {
                FillSeaTransportFill(int.Parse(SelectedValue));
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var Cs = Properties.Settings.Default.Connectionstring;
            SqlConnection Con = new SqlConnection(Cs);
            var Qur = "Select " +
                      "SeaTransport.Name As STName," +
                      "SeaTransportType.Name As STTName," +
                      "Landing.PaymentDoneToDate As LandDate," +
                      "Drivers.MobileNo As OMN," +
                      "Drivers.Name As Owner " +
                      "From SeaTransport " +
                      "Join SeaTransportType " +
                      "On SeaTransport.TypeID = SeaTransportType.ID " +
                      "Left Outer Join Landing " +
                      "On Landing.SeaTransportID = SeaTransport.ID " +
                      "Join Drivers " +
                      "On SeaTransport.DriverID = Drivers.ID ";
                      //"Where DriverTypeID = 2 ";
            Con.Open();
            if (cmbTypeID.Text != "--الكل--")
            {
                Qur += "Where SeaTransportType.Name = '" + cmbTypeID.Text + "' And SeaTransport.Name = '" + cmbSeaTransportID.Text + "'";
            }
            SqlDataAdapter Da = new SqlDataAdapter(Qur, Con);
            DataSet Ds = new DataSet();
            Da.Fill(Ds, "MPDt");
            Con.Close();
            NewRep NRP = new NewRep();
            MPMRep MR  = new MPMRep();
            MR.SetDataSource(Ds);
            NRP.FRA.ReportSource = MR;
            NRP.FRA.Refresh();
            NRP.Show();
        }
    }
}
