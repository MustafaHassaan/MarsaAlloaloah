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
    public partial class BoatfixReport : Form
    {
        public BoatfixReport()
        {
            InitializeComponent();
        }
        private void BoatfixReport_Load(object sender, EventArgs e)
        {
            SeaTransportTypeFill();
        }
        private void SeaTransportTypeFill()
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
            //var DF = dtpStart.Value.ToString("yyyy-MM-dd");
            //var DT = dtpEnd.Value.ToString("yyyy-MM-dd");
            var Cs = Properties.Settings.Default.Connectionstring;
            SqlConnection Con = new SqlConnection(Cs);
            var Qur = @"SELECT 
                        SeaTransport.Name AS SeaName, 
                        SeaTransportType.Name AS TypeName, 
                        Maintenance.Date, 
                        Maintenance.Notes, 
                        Maintenance.ID
                        FROM SeaTransport 
                        INNER JOIN SeaTransportType 
                        ON SeaTransport.TypeID = SeaTransportType.ID 
                        INNER JOIN Maintenance 
                        ON SeaTransport.ID = Maintenance.SeaTransportID ";
            Con.Open();
            if (cmbTypeID.Text != "--الكل--")
            {
                Qur += "And SeaTransportType.Name = '" + cmbTypeID.Text + "' " +
                       "And SeaTransport.Name = '" + cmbSeaTransportID.Text + "' ";
                       //"And Maintenance.Date >= '" + DF +"' "+
                       //"And Maintenance.Date <= '" + DT + "'";
            }
            SqlDataAdapter Da = new SqlDataAdapter(Qur, Con);
            DataSet Ds = new DataSet();
            Da.Fill(Ds, "Boatfix");
            Con.Close();
            Frmreports FR = new Frmreports();
            Boatfixing BF = new Boatfixing();
            BF.SetDataSource(Ds);
            FR.CRV.ReportSource = BF;
            FR.CRV.Refresh();
            FR.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
