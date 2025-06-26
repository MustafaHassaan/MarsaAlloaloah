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
    public partial class Customersform : Form
    {
        private Returnedform FSB = null;
        public Customersform(Form CF)
        {
            InitializeComponent();
            FSB = CF as Returnedform;
        }

        private void Customersform_Load(object sender, EventArgs e)
        {

        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Rows.Count > 0)
            {
                FSB.comboBox2.SelectedValue = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value.ToString());
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                (DGV.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name='{0}'", textBox1.Text);
            }
            else
            {
                if (FSB.comboBox1.Text != "--اختر--")
                {
                    string sql = "";
                    if (FSB.comboBox1.Text == "ارتجاع تذكرة")
                    {
                        sql = @"Select ID,Name From Customers";
                    }
                    if (FSB.comboBox1.Text == "ارتجاع ارساء")
                    {
                        sql = @"SELECT * FROM Drivers Where IsEmployee = 0";
                    }
                    DataTable Dt = new DataTable();
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(sql, SQLConn.conn);
                    SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                    SQLConn.da.Fill(Dt);
                    DGV.DataSource = Dt;
                }
                else
                {
                    MessageBox.Show("برجاء اختيار نوع التذكرة", "خطأ");
                    return;
                }
            }
        }
    }
}
