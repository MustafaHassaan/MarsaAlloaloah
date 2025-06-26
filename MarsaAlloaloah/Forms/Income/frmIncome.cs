using MarsaAlloaloah.CrystalReports;
using MarsaAlloaloah.CrystalReports.CQR;
using MarsaAlloaloah.Qrmodel;
using MarsaAlloaloah.Utility;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    public partial class frmIncome : Form
    {
        public frmIncome()
        {
            InitializeComponent();
        }

        private int? selectedIncomeID;
        string oldAmount;

        private void frmIncome_Load(object sender, EventArgs e)
        {
            //Load Income Type
            cmbIncomeTypeFill();
            cmbcustomer();
            chboxIsVAT.Checked = false;

            lblAmountAfterVAT.Visible = false;
            LblVAT.Visible = false;
            AmountAfterVAT.Visible = false;
            VAT.Visible = false;

            // Fill the datagrid of list income
            IncomeListFill();
        }
        public void IncomeListFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = IncomeListGridFill();
                dgvListIncome.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        public DataTable IncomeListGridFill()
        {
            DataTable dtbl = new DataTable();
            //dtbl.Columns.Add("SlNo", typeof(int));
            //dtbl.Columns["SlNo"].AutoIncrement = true;
            //dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            try
            {
                SQLConn.sqL = @"SELECT     
                                Income.ID, 
                                Income.IncomeName, 
                                Income.Description, 
                                Income.Amount, 
                                Income.VAT, 
                                Income.AmountAfterVAT, 
                                Income.Date, 
                                IncomeType.Name,
                                Customers.Name As 'Custname'
                                FROM Income 
                                INNER JOIN IncomeType 
                                ON Income.IncomeTypeID = IncomeType.ID
                                Left Outer JOIN Customers 
                                ON Income.Custid = Customers.ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(dtbl);
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
            return dtbl;
        }


        /// <summary>
        /// Get all Names
        /// </summary>
        private void cmbIncomeTypeFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"SELECT   ID, Name  FROM  IncomeType");

                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";

                dtbl.Rows.InsertAt(dr, 0);

                cmbIncomeType.DataSource = dtbl;
                cmbIncomeType.ValueMember = "ID";
                cmbIncomeType.DisplayMember = "Name";
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

        private void cmbcustomer()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"SELECT   ID, Name  FROM  Customers");

                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";

                dtbl.Rows.InsertAt(dr, 0);

                comboBox1.DataSource = dtbl;
                comboBox1.ValueMember = "ID";
                comboBox1.DisplayMember = "Name";
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
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbIncomeType.SelectedValue == null
                || cmbIncomeType.SelectedValue.ToString().Trim() == string.Empty
                || cmbIncomeType.SelectedValue.ToString() == "0")
            {
                Interaction.MsgBox("الرجاء إدخال نوع الإيراد.", MsgBoxStyle.Information, " نوع الإيراد");
                return;
            }
            if (comboBox1.SelectedValue == null
                || comboBox1.SelectedValue.ToString().Trim() == string.Empty
                || comboBox1.SelectedValue.ToString() == "0")
            {
                Interaction.MsgBox("الرجاء إدخال العميل.", MsgBoxStyle.Information, " نوع الإيراد");
                return;
            }
            if (!chboxIsVAT.Checked)
            {
                AmountAfterVAT.Text = txtIncomeAmount.Text;
            }

            if (btnSave.Text == "حفظ")
            {
                AddIncome();
                ClearFields();
            }
            else
            {
                UpdateIncome();
                ClearFields();
                btnSave.Text = "حفظ";
            }
        }

        private void UpdateIncome()
        {
            try
            {
                SQLConn.sqL = @"UPDATE Income SET IncomeName=@IncomeName, Description=@Description, Amount=@Amount, VAT=@VAT, 
                                AmountAfterVAT=@AmountAfterVAT, IncomeTypeID=@IncomeTypeID, IsTaxInvoice=@IsTaxInvoice, 
                                Date=@Date, Custid=@Custid WHERE  ID = '" + selectedIncomeID + "'";
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@IncomeName", txtIncomeName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Amount", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtIncomeAmount.Text));
                if (chboxIsVAT.Checked)
                {
                    SQLConn.cmd.Parameters.AddWithValue("@AmountAfterVAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(AmountAfterVAT.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@VAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(VAT.Text));
                }
                else
                {
                    SQLConn.cmd.Parameters.AddWithValue("@AmountAfterVAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtIncomeAmount.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@VAT", Convert.ToDecimal(0.00));
                }
                SQLConn.cmd.Parameters.AddWithValue("@IncomeTypeID", cmbIncomeType.SelectedValue.ToString());
                SQLConn.cmd.Parameters.AddWithValue("@Custid", comboBox1.SelectedValue.ToString());
                SQLConn.cmd.Parameters.AddWithValue("@IsTaxInvoice", chboxIsVAT.Checked);
                SQLConn.cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToShortDateString());
                SQLConn.cmd.ExecuteNonQuery();

                // Delete old amount from treasury and the add the new
                if(!string.IsNullOrEmpty(oldAmount))
                {
                    Decimal.TryParse(oldAmount, out decimal amount);
                    SQLConn.UpdatePrincipalTreasuryBalance(-amount, SQLConn.trans);
                    SQLConn.UpdatePrincipalTreasuryIncomeTransactions(-amount, SQLConn.trans, selectedIncomeID, txtIncomeName.Text);
                }

                UpdateTreasury();

                SQLConn.trans.Commit();

                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات الإيراد");

                // Fill the datagrid of list income
                IncomeListFill();
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

        private void AddIncome()
        {
            //Insert into table Income
            SQLConn.sqL = @"INSERT INTO Income(IncomeName, Description, Amount, VAT, AmountAfterVAT, IncomeTypeID, IsTaxInvoice, Date, Custid)  
                            VALUES(@IncomeName, @Description, @Amount, @VAT, @AmountAfterVAT, @IncomeTypeID, @IsTaxInvoice, @Date,@Custid);  SELECT CAST(scope_identity() AS int)";
            //try
            //{    
            //    SQLConn.ConnDB();
            //    SQLConn.BeginTransaction();
            //    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            //    SQLConn.cmd.Parameters.AddWithValue("@IncomeName", txtIncomeName.Text);
            //    SQLConn.cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            //    SQLConn.cmd.Parameters.AddWithValue("@Amount", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtIncomeAmount.Text));
            //    if (chboxIsVAT.Checked)
            //    {
            //        SQLConn.cmd.Parameters.AddWithValue("@AmountAfterVAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(AmountAfterVAT.Text));
            //        SQLConn.cmd.Parameters.AddWithValue("@VAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(VAT.Text));
            //    }
            //    else
            //    {
            //        SQLConn.cmd.Parameters.AddWithValue("@AmountAfterVAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtIncomeAmount.Text));
            //        SQLConn.cmd.Parameters.AddWithValue("@VAT", Convert.ToDecimal(0.00));
            //    }

            //    SQLConn.cmd.Parameters.AddWithValue("@IncomeTypeID", cmbIncomeType.SelectedValue.ToString());
            //    SQLConn.cmd.Parameters.AddWithValue("@Custid", comboBox1.SelectedValue.ToString());
            //    SQLConn.cmd.Parameters.AddWithValue("@IsTaxInvoice", chboxIsVAT.Checked);
            //    SQLConn.cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToShortDateString());

            //    selectedIncomeID = (int)SQLConn.cmd.ExecuteScalar();
            //    UpdateTreasury();

            //    //SQLConn.trans.Commit();

            //    Interaction.MsgBox("تم حفظ بيانات الإيراد.", MsgBoxStyle.Information, "الإيراد");

            //    //dgvListIncome load
            //    // Fill the datagrid of list income
            //    IncomeListFill();
            //}
            //catch (Exception ex)
            //{
            //    Interaction.MsgBox(ex.ToString());
            //}
            //finally
            //{
            //    SQLConn.cmd.Dispose();
            //    SQLConn.conn.Close();
            //}



            try
            {
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@IncomeName", txtIncomeName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Amount", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtIncomeAmount.Text));
                if (chboxIsVAT.Checked)
                {
                    SQLConn.cmd.Parameters.AddWithValue("@AmountAfterVAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(AmountAfterVAT.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@VAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(VAT.Text));
                }
                else
                {
                    SQLConn.cmd.Parameters.AddWithValue("@AmountAfterVAT", Common.ConvertCurrencyFieldToStringOnSqlQuery(txtIncomeAmount.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@VAT", Convert.ToDecimal(0.00));
                }

                SQLConn.cmd.Parameters.AddWithValue("@IncomeTypeID", cmbIncomeType.SelectedValue.ToString());
                SQLConn.cmd.Parameters.AddWithValue("@Custid", comboBox1.SelectedValue.ToString());
                SQLConn.cmd.Parameters.AddWithValue("@IsTaxInvoice", chboxIsVAT.Checked);
                SQLConn.cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToShortDateString());

                selectedIncomeID = Convert.ToInt32(SQLConn.cmd.ExecuteNonQuery());
                UpdateTreasury();

                //SQLConn.trans.Commit();

                Interaction.MsgBox("تم حفظ بيانات الإيراد.", MsgBoxStyle.Information, "الإيراد");

                //dgvListIncome load
                // Fill the datagrid of list income
                IncomeListFill();
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

        private void UpdateTreasury()
        {
            decimal amountBank = 0;
            if (chboxIsVAT.Checked)
                Decimal.TryParse(AmountAfterVAT.Text, out amountBank);
            else
                Decimal.TryParse(txtIncomeAmount.Text, out amountBank);

            SQLConn.UpdatePrincipalTreasuryBalance(amountBank, SQLConn.trans);
            SQLConn.UpdatePrincipalTreasuryIncomeTransactions(amountBank, SQLConn.trans, selectedIncomeID, "الإيراد" + txtIncomeName.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        public void ClearFields()
        {
            try
            {
                txtIncomeName.Clear();
                txtDescription.Clear();
                cmbIncomeType.SelectedValue = 0;
                comboBox1.SelectedValue = 0;
                txtIncomeAmount.Clear();
                chboxIsVAT.Checked = false;
                VAT.Text = string.Empty;
                AmountAfterVAT.Text = string.Empty;

                btnSave.Text = "حفظ";
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا الايراد", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
                ClearFields();
            }
            else
            {
                return;
            }
        }

        private void DeleteFunction()
        {
            try
            {
                SQLConn.ConnDB();
                


                if (!string.IsNullOrEmpty(oldAmount))
                {
                    Decimal.TryParse(oldAmount, out decimal amount);
                    SQLConn.UpdatePrincipalTreasuryBalance(-amount, SQLConn.trans);
                    SQLConn.UpdatePrincipalTreasuryIncomeTransactions(-amount, SQLConn.trans, selectedIncomeID, "حذف الإيراد " + txtIncomeName.Text);
                }

                SQLConn.sqL = "Delete From Income WHERE ID = " + selectedIncomeID + "";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                int res = SQLConn.cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف الإيراد");
                    // Fill the datagrid of list income
                    IncomeListFill();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "الإيرادات", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxIsVAT.Checked)
            {
                lblAmountAfterVAT.Visible = true;
                LblVAT.Visible = true;
                AmountAfterVAT.Visible = true;
                VAT.Visible = true;
            }
            else
            {
                lblAmountAfterVAT.Visible = false;
                LblVAT.Visible = false;
                AmountAfterVAT.Visible = false;
                VAT.Visible = false;
            }

            // Get the TVA from setting
            GetSystemSettingsData();
        }


        public void GetSystemSettingsData()
        {
            DataTable dtbl = new DataTable();
            try
            {
                dtbl = SQLConn.GetSystemSettingsData();
                bool isApplyVAT = Convert.ToBoolean(dtbl.Rows[0]["IsApplyVAT"].ToString());
                if (isApplyVAT)
                {
                    VAT.Text = dtbl.Rows[0]["VATPercent"].ToString();
                    if (!string.IsNullOrEmpty(txtIncomeAmount.Text)) //= Common.ConvertCurrencyFieldToStringOnSqlQuery(txtIncomeAmount.Text);
                    {
                        double currency = Common.num_repl(txtIncomeAmount.Text);
                        double vat = Common.num_repl(VAT.Text);
                        double amountAfterVAT = (currency * vat) / 100 + currency;
                        AmountAfterVAT.Text = amountAfterVAT.ToString();
                        var IA =  Convert.ToDecimal(AmountAfterVAT.Text) - Convert.ToDecimal(txtIncomeAmount.Text);
                        VAT.Text = Convert.ToString(IA);
                    }
                }
                else
                {
                    VAT.Text = "0.00";
                    AmountAfterVAT.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void dgvListIncome_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && dgvListIncome.CurrentRow.Cells[0] != null && dgvListIncome.CurrentRow.Cells[0].Value != null)
                {
                    selectedIncomeID = Convert.ToInt32(dgvListIncome.CurrentRow.Cells[0].Value);
                    FillControls();
                    btnSave.Text = "تحديث";
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public void FillControls()
        {
            try
            {
                if (selectedIncomeID.HasValue)
                {
                    DataTable incomeTypeInfo = GetIncomeByID(selectedIncomeID.Value);
                    txtIncomeName.Text = incomeTypeInfo.Rows[0]["IncomeName"].ToString();
                    txtDescription.Text = incomeTypeInfo.Rows[0]["Description"].ToString();
                    cmbIncomeType.SelectedValue = incomeTypeInfo.Rows[0]["IncomeTypeID"].ToString();
                    var Customer = incomeTypeInfo.Rows[0]["Custid"].ToString();
                    if (Customer != "")
                    {
                        comboBox1.SelectedValue = incomeTypeInfo.Rows[0]["Custid"].ToString();
                    }
                    txtIncomeAmount.Text = incomeTypeInfo.Rows[0]["Amount"].ToString();
                    chboxIsVAT.Checked = Boolean.Parse(incomeTypeInfo.Rows[0]["IsTaxInvoice"].ToString());
                    VAT.Text = incomeTypeInfo.Rows[0]["VAT"].ToString();
                    AmountAfterVAT.Text = incomeTypeInfo.Rows[0]["AmountAfterVAT"].ToString();

                    if (chboxIsVAT.Checked)
                        oldAmount = AmountAfterVAT.Text;
                    else
                        oldAmount = txtIncomeAmount.Text;

                    dtpDate.Text = incomeTypeInfo.Rows[0]["Date"].ToString();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable GetIncomeByID(int selectedIncomeID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT     
                                Income.ID, 
                                Income.IncomeName, 
                                Income.Description, 
                                Income.Amount, 
                                Income.VAT, 
                                Income.AmountAfterVAT, 
                                Income.Date, 
                                IncomeType.Name, 
                                Income.IncomeTypeID,
                                Income.IsTaxInvoice, 
                                Income.Date,
                                Income.Custid
                                FROM Income 
                                INNER JOIN IncomeType 
                                ON Income.IncomeTypeID = IncomeType.ID 
                                Left Outer JOIN Customers 
                                ON Income.Custid = Customers.ID 
                                where  Income.ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", selectedIncomeID);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(dtbl);
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
            return dtbl;

        }
        // CTB : Convert From Image To Binary
        Byte[] Photo;
        byte[] CTB(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        void DQ()
        {
            String Seller = "شركة مرسى أبحر";
            String VatNo = "310705230800003";
            DateTime dTime = DateTime.Now;
            Double Total = Convert.ToDouble(AmountAfterVAT.Text);
            Double Tax = Convert.ToDouble(VAT.Text);

            TLV tlv = new TLV(Seller, VatNo, dTime, Total, Tax);
            QRPic.Image = tlv.toQrCode();
            Photo = CTB(QRPic.Image);
        }
        private void Btnprint_Click(object sender, EventArgs e)
        {
            DQ();
            var Qur = @"Select
                        Income.IncomeName,
                        IncomeType.Name,
                        Income.Description,
                        Income.Amount,
                        Income.VAT,
                        Income.AmountAfterVAT,
                        Customers.Name,
                        Customers.Address,
                        Customers.Taxnumber
                        From Income
                        Join IncomeType
                        On Income.IncomeTypeID = IncomeType.ID
                        Join Customers
                        On Income.Custid = Customers.ID
                        Where Income.ID = '"+ selectedIncomeID + "'";

            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.ConnDB();
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            BIR IR = new BIR();
            QRds ds = new QRds();
            while (SQLConn.dr.Read())
            {
                var Incomname = SQLConn.dr[0].ToString();
                var Typename = SQLConn.dr[1].ToString();
                var Discription = SQLConn.dr[2].ToString();
                var Amount = SQLConn.dr[3].ToString();
                var VAT = SQLConn.dr[4].ToString();
                var Amountaftervat = SQLConn.dr[5].ToString();
                var Customername = SQLConn.dr[6].ToString();
                var Custaddress = SQLConn.dr[7].ToString();
                var Custtax = SQLConn.dr[8].ToString();
                ds.Incom.Rows.Add(new object[] {
                        Incomname,
                        Typename,
                        Discription,
                        Amount,
                        VAT,
                        Amountaftervat,
                        Customername,
                        Custaddress,
                        Custtax,
                        Photo
                    });
            }
            SQLConn.conn.Close();
            IR.SetDataSource(ds);
            IR.PrintOptions.PrinterName = "Microsoft Print to PDF";
            IR.PrintToPrinter(1, true, 1, 1);
            QRPic.Image = null;
        }
    }
}
