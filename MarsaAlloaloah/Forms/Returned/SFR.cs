using MarsaAlloaloah.CrystalReports.CQR;
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

namespace MarsaAlloaloah.Forms.Returned
{
    public partial class SFR : Form
    {
        public SFR()
        {
            InitializeComponent();
        }
        //SFR : Search Filter Report
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SFR_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var DTS = dtpStart.Value.ToString("yyyy-MM-dd");
            var DTT = dtpEnd.Value.ToString("yyyy-MM-dd");
            Retrepform RRF = new Retrepform();
            Returnedreport RRR = new Returnedreport();
            QRds ds = new QRds();
            var Qur = @"Select Returned.ID,
	                    Returned.Invoiceid,
	                    Returned.Status,
	                    Returned.Note,
	                    Returned.Date,
	                    Returned.Type,
	                    Returned.Paycard,
	                    Returned.Paycash,
	                    Tickets.PriceAfterDiscount,
	                    Tickets.VAT,
                        Case
                        When Returned.Type = 'ارتجاع تذكرة' Then
                        (Select Customers.Name From Customers Where Returned.Custid = Customers.ID)
                        Else
                        (Select Drivers.Name From Drivers Where Returned.Custid = Drivers.ID)
                        END AS Customername
                        From Returned
                        Inner Join Tickets
						On Returned.Invoiceid = Tickets.ID
                        Where Returned.Date >= '" + DTS +"' And Returned.Date <= '"+ DTT +"' ";
            if (comboBox1.SelectedIndex == 1)
            {
                Qur += "And Returned.Type = 'ارتجاع ارساء' ";
                
            }
            if (comboBox1.SelectedIndex == 2)
            {
                //Qur += "And Returned.Type = 'ارتجاع تذكرة' ";
                Qur += "And Returned.Type = 'ارتجاع تذكرة' ";
              
            }
            if (comboBox1.SelectedIndex == 3)
            {
                //Qur += "And Returned.Type = 'ارتجاع تذكرة' ";
                Qur += "And Returned.Type = 'ارتجاع حجز' ";

            }
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            while (SQLConn.dr.Read())
            {
                var Customername = SQLConn.dr["Customername"].ToString();
                var Paycash = SQLConn.dr["Paycash"].ToString();
                if (Paycash == "")
                {
                    Paycash = "0.00";
                }
                var Paycard = SQLConn.dr["Paycard"].ToString();
                if (Paycard == "")
                {
                    Paycard = "0.00";
                }
                var Amount = Convert.ToString(Convert.ToDecimal(Paycash) + Convert.ToDecimal(Paycard));
                var Billnumber = SQLConn.dr["Invoiceid"].ToString();   
                var RID = SQLConn.dr["ID"].ToString();   
                var Status = SQLConn.dr["Status"].ToString();
                var Note = SQLConn.dr["Note"].ToString();           
                //var Type = SQLConn.dr["Type"].ToString();
                var Type = SQLConn.dr["Type"].ToString();
                if (Type == "ارتجاع تذكرة")
                {
                    Type = "مستند دائن";
                }
                var Date = SQLConn.dr["Date"].ToString();
                var PriceAfterDiscount = SQLConn.dr["PriceAfterDiscount"].ToString();
                var VAT = SQLConn.dr["VAT"].ToString();

                ds.Returnedlist.Rows.Add(new object[] {
                    RID,Customername,Amount,Billnumber,Status,Note,Type,Date,PriceAfterDiscount,VAT
                });
            }
            RRR.SetDataSource(ds);

            RRR.SetParameterValue("DF",DTS);
            RRR.SetParameterValue("DT",DTT);
            if (comboBox1.SelectedIndex == 1)
            {
                RRR.SetParameterValue("Title", "ارسائات");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                RRR.SetParameterValue("Title", "تذاكر");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                RRR.SetParameterValue("Title", "حجوزات");
            }
            else
            {
                RRR.SetParameterValue("Title", "الكل");
            }
            RRF.RCR.ReportSource = RRR;
            RRF.RCR.Refresh();
            RRF.Show();
        }
    }
}
