using MarsaAlloaloah.Utility.Ado.net;
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

namespace MarsaAlloaloah.Rentals
{
    public partial class Rentlist : Form
    {
        public Rentlist()
        {
            InitializeComponent();
        }
        private void GetRentals(string qur)
        {
            DataTable dtbl = new DataTable();
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
                        Rental.Rentstatus
                        From Rental
                        Left outer Join SeaTransportType
                        On Rental.Seatypeid = SeaTransportType.ID
                        Left outer Join SeaTransport
                        On Rental.Searentid = SeaTransport.ID
                        Left outer Join Customers
                        On Rental.Customerid = Customers.ID ";
            if (qur != "")
            {
                Qur += "Where Rental.Rentdate >='"+ DTF.Value.ToString("yyyy-MM-dd") +"' " +
                       "And Rental.Rentdate <='"+ DTT.Value.ToString("yyyy-MM-dd")+"' ";
            }
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        private void Rentlist_Load(object sender, EventArgs e)
        {
            GetRentals("");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetRentals(btnSearch.Text);
        }
    }
}
