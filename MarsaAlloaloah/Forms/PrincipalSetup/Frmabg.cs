using MarsaAlloaloah;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using SmartArabXLSX.Bibliography;
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

namespace MarsaAlloaloah.Forms.PrincipalSetup
{
    public partial class Frmabg : Form
    {

        public Frmabg()
        {
            InitializeComponent();
        }
        public int PGID { get; set; }
        public int DGID { get; set; }
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
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Frmabg_Load(object sender, EventArgs e)
        {
            loadSeaTransportType();
            //comboBox1.SelectedIndex = 0;
            if (DGID != null)
            {
                cmbPriceGroup.SelectedValue = DGID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbPriceGroup.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("برجاء ادخال اسم المجموعة", "خطأ");
                return;
            }
            if (Duration.Value <= 0)
            {
                MessageBox.Show("برجاء ادخال عدد الساعات","خطأ");
                return;
            }
            if (comboBox1.Text == "-- اختر --")
            {
                MessageBox.Show("برجاء ادخال المدة الزمنية", "خطأ");
                return;
            }
            if (btnSave.Text == "حفظ")
            {
                try
                {
                    SQLConn.sqL = @"INSERT INTO Price(Price,Percentage,Duration,CashierCommission,DriverCommission,CashierExternCommission,SeaTransportTypeID) 
                                VALUES(@Price,@Percentage,@Duration,@CashierCommission,@DriverCommission,@CashierExternCommission,@SeaTransportTypeID)";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(Price.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@Percentage", Convert.ToDecimal(txtPercentage.Text));
                    if (comboBox1.Text == "ساعه")
                    {
                        var DV = int.Parse(Duration.Text);
                        int minutes = DV * 60;
                        SQLConn.cmd.Parameters.AddWithValue("@Duration", minutes + " " + "دقيقة");
                    }
                    else
                    {
                        SQLConn.cmd.Parameters.AddWithValue("@Duration", Duration.Text + " " + comboBox1.Text);
                    }
                    SQLConn.cmd.Parameters.AddWithValue("@CashierCommission", Convert.ToDecimal(CashierCommission.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@DriverCommission", Convert.ToDecimal(DriverCommission.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@CashierExternCommission", Convert.ToDecimal(CashierExternCommission.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@SeaTransportTypeID", cmbPriceGroup.SelectedValue);
                    var DC = Convert.ToDecimal(DriverCommission.Text);
                    SQLConn.cmd.ExecuteNonQuery();
                    Interaction.MsgBox("تم حفظ بيانات مجموعة التسعير بنجاح.", MsgBoxStyle.Information, "اضافة مجموعة التسعير");
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
            else
            {
                try
                {
                    SQLConn.sqL = @"Update Price Set 
                                           Price = @Price,
                                           Percentage = @Percentage,
                                           Duration = @Duration,
                                           CashierCommission = @CashierCommission,
                                           DriverCommission = @DriverCommission,
                                           CashierExternCommission = @CashierExternCommission,
                                           SeaTransportTypeID = @SeaTransportTypeID
                                           Where ID = @ID";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(Price.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@Percentage", Convert.ToDecimal(txtPercentage.Text));
                    if (comboBox1.Text == "ساعه")
                    {
                        var DV = int.Parse(Duration.Text);
                        int minutes = DV * 60;
                        SQLConn.cmd.Parameters.AddWithValue("@Duration", minutes + " " + "دقيقة");
                    }
                    else
                    {
                        SQLConn.cmd.Parameters.AddWithValue("@Duration", Duration.Text + " " + comboBox1.Text);
                    }
                    SQLConn.cmd.Parameters.AddWithValue("@CashierCommission", Convert.ToDecimal(CashierCommission.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@DriverCommission", Convert.ToDecimal(DriverCommission.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@CashierExternCommission", Convert.ToDecimal(CashierExternCommission.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@SeaTransportTypeID", cmbPriceGroup.SelectedValue);
                    SQLConn.cmd.Parameters.AddWithValue("@ID", PGID);
                    var DC = Convert.ToDecimal(DriverCommission.Text);
                    SQLConn.cmd.ExecuteNonQuery();
                    Interaction.MsgBox("تم تعديل بيانات مجموعة التسعير بنجاح.", MsgBoxStyle.Information, "تعديل مجموعة التسعير");
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
        }
    }
}
