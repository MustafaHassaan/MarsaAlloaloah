using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using SmartArabXLSX.Office.Word;
using SmartArabXLSX.Office2010.Excel;
using SmartArabXLSX.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace MarsaAlloaloah.Forms.PrincipalSetup
{
    public partial class Frmpricing : Form
    {
        public Frmpricing()
        {
            InitializeComponent();
        }
        public string Outper { get; set; }
        public string Driverper { get; set; }
        public string DCashierper { get; set; }
        public string DPercent { get; set; }
        public string DPrice { get; set; }
        public string DDuration { get; set; }
        public string STTID { get; set; }
        public string DID { get; set; }
        public void loadSeaTransportType()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM SeaTransportType");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbPriceGroup.DataSource = dtbl;
                cmbPriceGroup.ValueMember = "ID";
                cmbPriceGroup.DisplayMember = "Name";
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

        private void Frmpricing_Load(object sender, EventArgs e)
        {
            loadSeaTransportType();
        }

        private void cmbPriceGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Gridfill();
        }

        private void Gridfill()
        {
            DataTable dt = new DataTable();
            SQLConn.sqL = @"select ID,SeaTransportTypeID, Duration, Price,Percentage, DriverCommission, CashierCommission, CashierExternCommission
                                from Price Where SeaTransportTypeID= " + int.Parse(cmbPriceGroup.SelectedValue.ToString()) + " order by DurationValue";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.da.Fill(dt);
            DGV.DataSource = dt;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (DGV.Rows.Count > 0)
            {
                DID = DGV.CurrentRow.Cells[0].Value.ToString();
                STTID = DGV.CurrentRow.Cells[1].Value.ToString();
                DDuration = DGV.CurrentRow.Cells[2].Value.ToString();
                DPrice = DGV.CurrentRow.Cells[3].Value.ToString();
                DPercent = DGV.CurrentRow.Cells[4].Value.ToString();
                DCashierper = DGV.CurrentRow.Cells[5].Value.ToString();
                Driverper = DGV.CurrentRow.Cells[6].Value.ToString();
                Outper = DGV.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DID == null)
            {
                MessageBox.Show("برجاء اختيار التسعير", "خطأ");
                return;
            }
            Frmabg abg = new Frmabg();
            abg.btnSave.Text = "تعديل";
            abg.Text = "تعديل سعر";
            abg.PGID = int.Parse(DID);
            abg.DGID = int.Parse(STTID);
            string Letter = string.Concat(DDuration.Where(Char.IsLetter));
            string Number = string.Concat(DDuration.Where(Char.IsDigit));
            abg.Duration.Minimum = Convert.ToDecimal(Number);
            abg.comboBox1.SelectedItem = Letter;
            abg.Price.Text = DPrice;
            abg.txtPercentage.Text = DPercent;
            abg.CashierCommission.Text = DCashierper;
            abg.CashierExternCommission.Text = Outper;
            abg.DriverCommission.Text = Driverper;
            abg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmabg abg = new Frmabg();
            abg.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (DID == null)
            {
                MessageBox.Show("برجاء ادخال hgjsudv", "خطأ");
                return;
            }
            else
            {
                DialogResult Cheack = (DialogResult)MessageBox.Show("هل تريد حذف هذا التسعير", "حذف تسعير", MessageBoxButton.YesNo);
                if (Cheack == DialogResult.Yes)
                {
                    SQLConn.sqL = "Delete From Price WHERE ID=@ID ";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.Parameters.AddWithValue("@ID", DID);
                    SQLConn.cmd.ExecuteNonQuery();
                    Interaction.MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "حذف تسعير");
                    Gridfill();
                }
            }
        }
    }
}
