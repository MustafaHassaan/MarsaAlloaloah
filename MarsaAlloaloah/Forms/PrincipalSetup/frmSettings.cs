using MarsaAlloaloah.Utility;
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

namespace MarsaAlloaloah
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsVatApplied.Checked == true)
            {
                txtVatValue.Visible = true;
                label1.Visible = true;
            }
            else
            {
                txtVatValue.Visible = false;
                label1.Visible = false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveFunction();

        }

        private void SaveFunction()
        {

            //Select If Vat Record Inserted
            var IsInserted=CheckIfVatInserted();
            if (IsInserted == false)
            {
                AddFunction();
            }
            else
            {
                UpdateFunction();
            }     

        }

        private void UpdateFunction()
        {
            try
            {
                SQLConn.sqL = "UPDATE SystemSettings SET IsApplyVAT= @IsApplyVAT,VATPercent= @VATPercent";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.Add("@IsApplyVAT", SqlDbType.Bit).Value = cbIsVatApplied.Checked;
                if (cbIsVatApplied.Checked)
                {
                    if (txtVatValue.Text == "")
                    {
                        Interaction.MsgBox("من فضلك قم بإدخال قيمة ضريبة القيمة المضافة");
                        return;

                    }
                    else
                    {
                        SQLConn.cmd.Parameters.Add("@VATPercent", SqlDbType.Decimal).Value = Common.ConvertTxtToDecimal(txtVatValue.Text);

                    }
                }
                else
                {
                    SQLConn.cmd.Parameters.Add("@VATPercent", SqlDbType.Decimal).Value = 0.0m;

                }
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حفظ إعدادات النظام بنجاح.", MsgBoxStyle.Information, "إعدادات النظام");

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

        private void AddFunction()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO SystemSettings(IsApplyVAT,VATPercent) VALUES(@IsApplyVAT,@VATPercent)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.Add("@IsApplyVAT", SqlDbType.Bit).Value = cbIsVatApplied.Checked;
                if (cbIsVatApplied.Checked)
                {
                    if (txtVatValue.Text == "")
                    {
                        Interaction.MsgBox("من فضلك قم بإدخال قيمة ضريبة القيمة المضافة");
                        return;

                    }
                    else
                    {
                        SQLConn.cmd.Parameters.Add("@VATPercent", SqlDbType.Decimal).Value = Common.ConvertTxtToDecimal(txtVatValue.Text);

                    }
                }
                else
                {
                    SQLConn.cmd.Parameters.Add("@VATPercent", SqlDbType.Decimal).Value = 0.0m;

                }
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حفظ إعدادات النظام بنجاح.", MsgBoxStyle.Information, "إعدادات النظام");
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

        private bool CheckIfVatInserted()
        {
            DataTable dtbl = new DataTable();
            bool IsInserted = false;
            try
            {

                SQLConn.sqL = "select * from SystemSettings";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(dtbl);
                if (dtbl.Rows.Count > 0)
                {
                    IsInserted = true;
                }
                else
                {
                    IsInserted = false;
                }

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
            return IsInserted;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

            try
            {
                GetSystemSettingsData();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }

        }

        public void GetSystemSettingsData()
        {
            DataTable dtbl = new DataTable();   
            try
            {

                dtbl = SQLConn.GetSystemSettingsData();         
                cbIsVatApplied.Checked =Convert.ToBoolean(dtbl.Rows[0]["IsApplyVAT"].ToString());
                txtVatValue.Text = dtbl.Rows[0]["VATPercent"].ToString();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "إعدادات النظام", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
    }
}
