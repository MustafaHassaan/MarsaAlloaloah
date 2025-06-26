using MarsaAlloaloah.CrystalReports.CQR;
using Microsoft.VisualBasic;
using SmartArabXLSX.Drawing.Charts;
using SmartArabXLSX.Drawing;
using SmartArabXLSX.Office2010.Excel;
using SmartArabXLSX.Spreadsheet;
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
using DataTable = System.Data.DataTable;
using SmartArabXLSX.Wordprocessing;
using System.Data.Common;
using static MarsaAlloaloah.dsMarsa;
using SmartArabXLSX.Office2013.Drawing.ChartStyle;
using ZXing;
using SmartArabXLSX.Office2013.Drawing.Chart;
using System.Reflection;
using System.Xml.Linq;
using MarsaAlloaloah.Utility.Ado.net;

namespace MarsaAlloaloah.Forms.Boats
{
    public partial class Boatowners : Form
    {
        DataGridView Dati;
        int DGi = 0;
        string Resitem = "";
        public Boatowners()
        {
            InitializeComponent();
        }
        private void Getcat()
        {

            DataTable dt = new DataTable();
            SQLConn.sqL = @"Select Name From SeaTransportType";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.da.Fill(dt);
            SQLConn.conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dr.ItemArray.Length; i++)
                {
                    var item = dr.ItemArray[i].ToString();
                    int DGI = 0;
                    int loc = 15;
                    foreach (System.Windows.Forms.Control c in Controls)
                    {
                        if (c.GetType().Name.ToString() == "DataGridView")
                        {
                            loc = c.Location.X - 160;
                        }
                    }
                    Dati = new DataGridView();
                    Dati.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    Dati.Anchor = AnchorStyles.Right;
                    Dati.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    Dati.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Dati.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    Dati.Location = new System.Drawing.Point(loc, 20);
                    Dati.Name = item;
                    Dati.Size = new System.Drawing.Size(225, 325);
                    Dati.TabIndex = DGI;
                    Dati.Visible = true;
                    Dati.Columns.Add("Boat name", item);
                    GetCatchiled(item);
                    flowLayoutPanel1.Controls.Add(Dati);
                    DGI++;
                }
            }
        }
        private void GetCatchiled(string BT)
        {
            SQLConn.ConnDB();
            var Qurtn = @"SELECT 
                            SeaTransportOrder,
                            SeaTransport.Name As 'Boatname',
                            SeaTransportType.Name As 'Boattype'
                            FROM SeaTransport 
                            Inner Join SeaTransportType
                            On SeaTransport.TypeID = SeaTransportType.ID
                            Where InService = 1
                            And SeaTransport.ID Not IN(
                            SELECT      
                            SeaTransport.ID
                            FROM Tickets 
                            Inner JOIN SeaTransport 
                            ON Tickets.SeaTransportID = SeaTransport.ID								
                            WHERE (IsBusy = 1) And  
                            (Tickets.StartDate = CAST(GETDATE() as DATE)) 
                            And(EndTime > CONVERT(TIME, SYSDATETIME())))
                            And SeaTransportType.Name = N'" + BT + "' "+
                            "Order by SeaTransportOrder";
            SQLConn.cmd = new SqlCommand(Qurtn, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            while (SQLConn.dr.Read())
            {
                Resitem = SQLConn.dr["Boatname"].ToString();
                Dati.Rows.Add(Resitem);
            }
            SQLConn.conn.Close();
            SQLConn.conn.Dispose();
            GC.Collect();
        }
        private void Boatowners_Load(object sender, EventArgs e)
        {
            Getcat();
            timer.Start();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            Dati.Rows.Clear();
            Getcat();
        }
    }
}
