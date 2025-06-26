using MarsaAlloaloah.CrystalReports;
using MarsaAlloaloah.FrmReports;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah.Rentals
{
    public partial class frmReportFilterRental : Form
    {
        public frmReportFilterRental()
        {
            InitializeComponent();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            DateTime dateStart = dtpStart.Value;
            DateTime dateEnd = dtpEnd.Value;
            dsMarsa Ds = new dsMarsa();
            var Qur = @"Select 
                        Rental.ID, 
                        Rental.Rentdate,
                        Rental.Startdate,
                        Rental.Starttime,
                        SeaTransportType.Name As 'Seatransporttypename',
                        SeaTransport.Name As 'Seatransportname',
                        Customers.Name As 'Customername',
                        Rental.Ticketid,
                        Rental.Dauration,
                        Rental.Rentstatus,
                        Treasury.Name As 'Cashiername',
						Rentaltransactions.DiscountPercent,
						Rentaltransactions.DiscountAmount,
						Rentaltransactions.Price,
						Rentaltransactions.PriceAfterDiscount,
						Rentaltransactions.VAT,
						Rentaltransactions.PriceAfterDiscount + Rentaltransactions.VAT As 'Priceaftervat',
						Rentaltransactions.PayCash + Rentaltransactions.PayCard As 'Payed',
						(Rentaltransactions.PriceAfterDiscount + Rentaltransactions.VAT) - (Rentaltransactions.PayCash + Rentaltransactions.PayCard) As 'Remaining',
                        Rental.Note As 'Notetext'
                        From Rental
                        Left Outer Join SeaTransportType
                        On Rental.Seatypeid = SeaTransportType.ID
                        Left Outer Join SeaTransport
                        On Rental.Searentid = SeaTransport.ID
                        Inner Join Customers
                        On Rental.Customerid = Customers.ID
                        Inner Join Treasury
						On Rental.Treasuryid = Treasury.UserID
						Left Outer Join Rentaltransactions
						On Rental.RTId = Rentaltransactions.ID " +
                       "Where Rental.Rentdate >= '" + dateStart.ToString("yyyy-MM-dd") + "' " +
                       "and Rental.Rentdate <= '" + dateEnd.ToString("yyyy-MM-dd") + "' ";
                       //"Order by Rental.Rentdate";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            while (SQLConn.dr.Read())
            {
                var ID = SQLConn.dr[0].ToString();
                var Rentdate = SQLConn.dr[1].ToString();
                var Startdate = SQLConn.dr[2].ToString();
                var Starttime = SQLConn.dr[3].ToString();
                var Seatransporttypename = SQLConn.dr[4].ToString();
                var Seatransportname = SQLConn.dr[5].ToString();
                var Customername = SQLConn.dr[6].ToString();
                var Ticketid = SQLConn.dr[7].ToString();
                var Dauration = SQLConn.dr[8].ToString();
                var Rentstatus = SQLConn.dr[9].ToString();
                var Cashiername = SQLConn.dr[10].ToString();
                var DiscountPercent = Convert.ToString(Convert.ToInt32(Convert.ToDecimal(SQLConn.dr[11].ToString()) * 100));
                var DiscountAmount = SQLConn.dr[12].ToString();
                var Price = SQLConn.dr[13].ToString();
                var PriceAfterDiscount = SQLConn.dr[14].ToString();
                var VAT = SQLConn.dr[15].ToString();
                var Priceaftervat = SQLConn.dr[16].ToString();
                var Payed = SQLConn.dr[17].ToString();
                var Remaining = SQLConn.dr[18].ToString();
                var Notetext = SQLConn.dr[19].ToString();
                Ds.Rentalbill.Rows.Add(new object[] {
                    ID,
                    Rentdate,
                    Startdate,
                    Starttime,
                    Seatransporttypename,
                    Seatransportname,
                    Customername,
                    null,
                    null,
                    Ticketid,
                    Dauration,
                    Rentstatus,
                    Cashiername,
                    DiscountPercent,
                    DiscountAmount,
                    Price,
                    PriceAfterDiscount,
                    VAT,
                    Priceaftervat,
                    Payed,
                    Remaining,
                    Notetext
                });
            }
            NewRep NRP = new NewRep();
            Rentalreport RT = new Rentalreport();
            RT.SetDataSource(Ds);
            NRP.FRA.ReportSource = RT;
            NRP.FRA.Refresh();
            NRP.Show();
        }
    }
}
