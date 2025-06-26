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

namespace MarsaAlloaloah.Forms
{
    public partial class Returnedlist : Form
    {
        public Returnedlist()
        {
            InitializeComponent();
        }
        private DataTable Getall(string Qur)
        {
            DataTable dtbl = new DataTable();
            try
            {
                var DTF = dtpStart.Value.ToShortDateString();
                var DTT = dtpEnd.Value.ToShortDateString();
                SQLConn.sqL = @"Select *,
                                Case
                                When Returned.Type = N'ارتجاع تذكرة' Then
                                (Select Customers.Name From Customers Where Returned.Custid = Customers.ID)
                                Else
                                (Select Drivers.Name From Drivers Where Returned.Custid = Drivers.ID)
                                END AS Customername
                                From Returned
                                where (Returned.Date >= '"+ DTF + "' and Returned.Date <= '"+ DTT + "') " + Qur ;
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        private void Getfilter()
        {
            var Qur = "";
            try
            {
                DataTable dtbl = new DataTable();
                if (comboBox1.Text != "--اختر--")
                {
                    Qur += "And Returned.Type =" + "'" + comboBox1.Text + "'";
                }
                if (Idtxt.Text != "")
                {
                    Qur += "And Returned.ID =" + Idtxt.Text;
                }
                if (textBox1.Text != "")
                {
                    Qur += "And Returned.Invoiceid =" + textBox1.Text;
                }

                dtbl = Getall(Qur);
                dataGridView1.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Returnedlist_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            Getall("");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Getfilter();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            Getfilter();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
