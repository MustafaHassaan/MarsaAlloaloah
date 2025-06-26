using MarsaAlloaloah.CrystalReports.CQR;
using MarsaAlloaloah.Utility;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace MarsaAlloaloah.Forms.Returned
{
    public partial class Returnedform : Form
    {
        public Returnedform()
        {
            InitializeComponent();
        }
        int Billinvoice = 0;
        int Cashid = 0;
        private void GetInvoiceid()
        {
            try
            {
                var Qur = @"Select * From Returned ORDER BY ID DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read())
                {
                    //Invoiceno
                    if (SQLConn.dr["ID"].ToString() == "")
                    {
                        Billinvoice = 1;
                        textBox1.Text = Convert.ToString(Billinvoice);
                    }
                    else
                    {
                        Billinvoice = Convert.ToInt32(SQLConn.dr["ID"]) + 1;
                        textBox1.Text = Convert.ToString(Billinvoice);
                    }
                }
                else
                {
                    Billinvoice = 1;
                    textBox1.Text = Convert.ToString(Billinvoice);
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
        private void GetCashier()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"Select 
                                          Treasury.ID,
                                          Treasury.Name 
                                          From Treasury
                                          Inner Join Users
                                          On Treasury.UserID = Users.ID");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                CBCashier.DataSource = dtbl;
                CBCashier.ValueMember = "ID";
                CBCashier.DisplayMember = "Name";
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
        private void Returnedform_Load(object sender, EventArgs e)
        {
            GetCashier();
            GetInvoiceid();
            comboBox1.SelectedIndex = 0;
            paymentMethod.SelectedIndex = 0;
            Retpay.SelectedIndex = 0;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
        public void Clear()
        {
            textBox2.Clear();
            comboBox1.SelectedIndex = 0;
            txtpaycash.Text = "0";
            txtpaycard.Text = "0";
            richTextBox1.Clear();
            richTextBox2.Clear();
            comboBox2.DataSource = null;
            GetInvoiceid();
            HiddenFild();
            HiddenretFilds();
            Retpay.SelectedIndex = 0;
            paymentMethod.SelectedIndex = 0;
            lblrettot.Text = "0";
            lbltot.Text = "0";
        }
        public void GetTotalPay()
        {
            if (txtpaycash.Text == "")
            {
                txtpaycash.Text = "0.00";
            }
            if (txtpaycard.Text == "")
            {
                txtpaycard.Text = "0.00";
            }
            if (tamarapay.Text == "")
            {
                tamarapay.Text = "0.00";
            }
            if (transpay.Text == "")
            {
                transpay.Text = "0.00";
            }
            decimal CashValue = 0;
            Decimal.TryParse(txtpaycash.Text, out CashValue);
            decimal BankValue = 0;
            Decimal.TryParse(txtpaycard.Text, out BankValue);
            decimal TamaraValue = 0;
            Decimal.TryParse(tamarapay.Text, out TamaraValue);
            decimal TransValue = 0;
            Decimal.TryParse(transpay.Text, out TransValue);
            decimal totalPay = CashValue + BankValue + TamaraValue + TransValue;
            lbltot.Text = totalPay.ToString();
        }
        public void GetRetTotalPay()
        {
            if (txtretcash.Text == "")
            {
                txtretcash.Text = "0.00";
            }
            if (txtretbank.Text == "")
            {
                txtretbank.Text = "0.00";
            }
            if (txtrettamara.Text == "")
            {
                txtrettamara.Text = "0.00";
            }
            if (txtrettrans.Text == "")
            {
                txtrettrans.Text = "0.00";
            }
            decimal CashValue = 0;
            Decimal.TryParse(txtretcash.Text, out CashValue);
            decimal BankValue = 0;
            Decimal.TryParse(txtretbank.Text, out BankValue);
            decimal TamaraValue = 0;
            Decimal.TryParse(txtrettamara.Text, out TamaraValue);
            decimal TransValue = 0;
            Decimal.TryParse(txtrettrans.Text, out TransValue);
            decimal totalPay = CashValue + BankValue + TamaraValue + TransValue;
            lblrettot.Text = totalPay.ToString();
        }
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "صفر";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " مليون ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " الف ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " مائة ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "و ";

                var unitsMap = new[] { "صفر", "واحد", "اثنين", "ثلاثة", "اربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة", "عشرة", "احدى عشرة", "اثنتا عشرة", "ثلاثة عشرة", "اربعة عشرة", "خمسة عشرة", "ستة عشرة", "سبعة عشرة", "ثمانية عشرة", "تسعة عشرة" };
                var tensMap = new[] { "صفر", "عشرة", "عشرين", "ثلاثون", "اربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
        string DT;
        private void btnSave_Click(object sender, EventArgs e)
        {
            DT = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            if (Retpay.SelectedIndex == 0)
            {
                MessageBox.Show("برجاء اختيار لأي مكان سوف يتم الارتجاع", "خطأ");
                return;
            }
            if (decimal.Parse(lblrettot.Text) != decimal.Parse(lbltot.Text))
            {
                MessageBox.Show("المبلغ المرتجع غير صحيح", "خطأ");
                return;
            }
            //Data.UserName
            //var DUT = Data.UserID;
            //SQLConn.sqL = @"SELECT * From Treasury where UserID = " + DUT +" ";
            //SQLConn.ConnDB();
            //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            //SQLConn.dr = SQLConn.cmd.ExecuteReader();
            //if (SQLConn.dr.Read())
            //{

            //}
            //int TID = Convert.ToInt32(SQLConn.dr["ID"].ToString());
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "0")
            {
                MessageBox.Show("برجاء اضافة رقم الفاتورة", "خطأ");
                return;
            }
            if (comboBox1.Text == "--اختر--")
            {
                MessageBox.Show("برجاء اضافة نوع الفاتورة", "خطأ");
                return;
            }
            if (string.IsNullOrEmpty(txtpaycash.Text))
            {
                MessageBox.Show("برجاء اضافة مبلغ الفاتورة", "خطأ");
                return;
            }
            if (string.IsNullOrEmpty(txtpaycard.Text))
            {
                MessageBox.Show("برجاء اضافة مبلغ الفاتورة", "خطأ");
                return;
            }
            if (txtpaycash.Text == "0" && txtpaycard.Text == "0")
            {
                MessageBox.Show("لا يمكن ان تكون الفاتورة بدون رصيد", "خطأ");
                return;
            }
            if (comboBox2.Text == "--اختر--")
            {
                MessageBox.Show("برجاء العميل الى الفاتورة", "خطأ");
                return;
            }
            if (CBCashier.Text == "--اختر--")
            {
                MessageBox.Show("برجاء الكاشير الى الفاتورة", "خطأ");
                return;
            }
            try
            {

                SQLConn.sqL = "INSERT INTO Returned(ID,Invoiceid,Status,Note,Type,Custid,Date,Paycard,Paycash,Paytamara,Paytrans) VALUES" +
                                                  "(@ID,@Inviceid,@Status,@Note,@Type,@Custid,@Date,@Paycard,@Paycash,@Paytamara,@Paytrans)";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.ConnDB();
                SQLConn.cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox1.Text));
                SQLConn.cmd.Parameters.AddWithValue("@Inviceid", Convert.ToInt32(textBox2.Text));
                SQLConn.cmd.Parameters.AddWithValue("@Status", richTextBox1.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Note", richTextBox2.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Custid", comboBox2.SelectedValue);
                SQLConn.cmd.Parameters.AddWithValue("@Date", DT);
                SQLConn.cmd.Parameters.AddWithValue("@Paycard", txtretcash.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Paycash", txtretcash.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Paytamara", txtrettamara.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Paytrans", txtrettrans.Text);
                SQLConn.cmd.ExecuteNonQuery();
                SQLConn.ConnDB();
                //textBox3.Text = نقدي
                //textBox4.Text = بنكي
                if (comboBox1.Text == "ارتجاع تذكرة")
                {
                    var Case = Retpay.Text;
                    switch (Case)
                    {
                        case "نقدي":
                            Ticketcashretpay();
                            break;
                        case "بنكي":
                            Ticketcardretpay();
                            break;
                        case "تحويل بنكي":
                            Tickettransretpay();
                            break;
                        case "تمارا":
                            Tickettamararetpay();
                            break;
                        case "نقدي وبنكي":
                            Ticketcashretpay();
                            Ticketcardretpay();
                            break;
                        case "نقدي وتحويل":
                            Ticketcashretpay();
                            Tickettransretpay();
                            break;
                        case "تمارا ونقدي":
                            Ticketcashretpay();
                            Tickettamararetpay();
                            break;
                        case "بنكي وتحويل":
                            Ticketcardretpay();
                            Tickettransretpay();
                            break;
                        case "تمارا وبنكي":
                            Ticketcardretpay();
                            Tickettamararetpay();
                            break;
                        case "نقدي وبنكي وتحويل":
                            Ticketcashretpay();
                            Ticketcardretpay();
                            Tickettransretpay();
                            break;
                        case "تمارا وتحويل":
                            Tickettransretpay();
                            Tickettamararetpay();
                            break;
                        case "تمارا ونقدي وبنكي":
                            Ticketcashretpay();
                            Ticketcardretpay();
                            Tickettamararetpay();
                            break;
                        case "تمارا ونقدي وبنكي وتحويل":
                            Ticketcashretpay();
                            Ticketcardretpay();
                            Tickettamararetpay();
                            Tickettransretpay();
                            break;
                        case "--اختر--":
                            MessageBox.Show("برجاء ادخال طريقة المرتجع عن طريق", "خطأ");
                            break;
                    }
                }
                if (comboBox1.Text == "ارتجاع ارساء")
                {
                    var Case = Retpay.Text;
                    switch (Case)
                    {
                        case "نقدي":
                            Landingcashretpay();
                            break;
                        case "بنكي":
                            Landingcardretpay();
                            break;
                        case "تحويل بنكي":
                            Landingtransretpay();
                            break;
                        case "تمارا":
                            Landingtamararetpay();
                            break;
                        case "نقدي وبنكي":
                            Landingcashretpay();
                            Landingcardretpay();
                            break;
                        case "نقدي وتحويل":
                            Landingcashretpay();
                            Landingtransretpay();
                            break;
                        case "تمارا ونقدي":
                            Landingcashretpay();
                            Landingtamararetpay();
                            break;
                        case "بنكي وتحويل":
                            Landingcardretpay();
                            Landingtransretpay();
                            break;
                        case "تمارا وبنكي":
                            Landingcardretpay();
                            Landingtamararetpay();
                            break;
                        case "نقدي وبنكي وتحويل":
                            Landingcashretpay();
                            Landingcardretpay();
                            Landingtransretpay();
                            break;
                        case "تمارا وتحويل":
                            Landingtransretpay();
                            Landingtamararetpay();
                            break;
                        case "تمارا ونقدي وبنكي":
                            Landingcashretpay();
                            Landingcardretpay();
                            Landingtamararetpay();
                            break;
                        case "تمارا ونقدي وبنكي وتحويل":
                            Landingcashretpay();
                            Landingcardretpay();
                            Landingtamararetpay();
                            Landingtransretpay();
                            break;
                        case "--اختر--":
                            MessageBox.Show("برجاء ادخال طريقة المرتجع عن طريق", "خطأ");
                            break;
                    }
                }
                if (comboBox1.Text == "ارتجاع حجز")
                {
                    var Case = Retpay.Text;
                    switch (Case)
                    {
                        case "نقدي":
                            Rentalcashretpay();
                            break;
                        case "بنكي":
                            Rentalcardretpay();
                            break;
                        case "تحويل بنكي":
                            Rentaltransretpay();
                            break;
                        case "تمارا":
                            Rentaltamararetpay();
                            break;
                        case "نقدي وبنكي":
                            Rentalcashretpay();
                            Rentalcardretpay();
                            break;
                        case "نقدي وتحويل":
                            Rentalcashretpay();
                            Rentaltransretpay();
                            break;
                        case "تمارا ونقدي":
                            Rentalcashretpay();
                            Rentaltamararetpay();
                            break;
                        case "بنكي وتحويل":
                            Rentalcardretpay();
                            Rentaltransretpay();
                            break;
                        case "تمارا وبنكي":
                            Rentalcardretpay();
                            Rentaltamararetpay();
                            break;
                        case "نقدي وبنكي وتحويل":
                            Rentalcashretpay();
                            Rentalcardretpay();
                            Rentaltransretpay();
                            break;
                        case "تمارا وتحويل":
                            Rentaltransretpay();
                            Rentaltamararetpay();
                            break;
                        case "تمارا ونقدي وبنكي":
                            Rentalcashretpay();
                            Rentalcardretpay();
                            Rentaltamararetpay();
                            break;
                        case "تمارا ونقدي وبنكي وتحويل":
                            Rentalcashretpay();
                            Rentalcardretpay();
                            Rentaltamararetpay();
                            Rentaltransretpay();
                            break;
                        case "--اختر--":
                            MessageBox.Show("برجاء ادخال طريقة المرتجع عن طريق", "خطأ");
                            break;
                    }
                    try
                    {
                        var Tickid = Convert.ToInt32(textBox2.Text);
                        SQLConn.sqL = "Update Rental Set Rentstatus = 'ارتجاع حجز' " +
                                      "Where ID = @ID";
                        SQLConn.ConnDB();
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                        SQLConn.cmd.Parameters.AddWithValue("@ID", Tickid);
                        SQLConn.cmd.ExecuteNonQuery();
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
                Cursor.Current = Cursors.Default;
                MessageBox.Show("تم الحفظ بنجاح", "تم");

                var Rep = MessageBox.Show("هل تريد ايصال المرتجع", "تقرير", MessageBoxButtons.YesNo);
                if (Rep == DialogResult.Yes)
                {
                    Retrepform RRF = new Retrepform();
                    Returnedrep RRR = new Returnedrep();
                    string Status = "";
                    if (comboBox1.Text == "ارتجاع تذكرة")
                    {
                        Status = "الغاء تذكرة";
                    }
                    else if (comboBox1.Text == "ارتجاع حجز")
                    {
                        Status = "الغاء حجز";
                    }
                    else
                    {
                        Status = "الغاء ارساء";
                    }
                    var Id = textBox1.Text;
                    var Tottal = Convert.ToDecimal(txtpaycash.Text) + Convert.ToDecimal(txtpaycard.Text);
                    var CTW = Convert.ToInt32(Tottal);
                    var NTW = NumberToWords(CTW);
                    var Clientname = comboBox2.Text;
                    QRds ds = new QRds();
                    ds.Returned.Rows.Add(new object[] {
                    Clientname,Tottal,Id,Status,NTW
                });
                    RRR.SetDataSource(ds);
                    RRF.RCR.ReportSource = RRR;
                    RRF.RCR.Refresh();
                    RRF.Show();
                }
                else
                {
                    return;
                }
                Clear();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.conn.Close();
            }

            Cursor.Current = Cursors.WaitCursor;
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (comboBox1.Text == "ارتجاع تذكرة")
            {
                SQLConn.ConnDB();
                DataTable DT = new DataTable();
                DT = SQLConn.getTable("SELECT * FROM Customers");
                DataRow DTR = DT.NewRow();
                DTR["ID"] = 0;
                DTR["Name"] = "--اختر--";
                DT.Rows.InsertAt(DTR, 0);
                comboBox2.DataSource = DT;
                comboBox2.ValueMember = "ID";
                comboBox2.DisplayMember = "Name";
            }
            if (comboBox1.Text == "ارتجاع ارساء")
            {
                SQLConn.ConnDB();
                DataTable DT = new DataTable();
                DT = SQLConn.getTable("SELECT * FROM Drivers Where IsEmployee = 0");
                DataRow DTR = DT.NewRow();
                DTR["ID"] = 0;
                DTR["Name"] = "--اختر--";
                DT.Rows.InsertAt(DTR, 0);
                comboBox2.DataSource = DT;
                comboBox2.ValueMember = "ID";
                comboBox2.DisplayMember = "Name";
            }
            if (comboBox1.Text == "ارتجاع حجز")
            {
                SQLConn.ConnDB();
                DataTable DT = new DataTable();
                DT = SQLConn.getTable("SELECT * FROM Customers");
                DataRow DTR = DT.NewRow();
                DTR["ID"] = 0;
                DTR["Name"] = "--اختر--";
                DT.Rows.InsertAt(DTR, 0);
                comboBox2.DataSource = DT;
                comboBox2.ValueMember = "ID";
                comboBox2.DisplayMember = "Name";
            }
            Cursor.Current = Cursors.Default;
        }
        private void btnFrmCustomer_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "--اختر--")
            {
                Customersform CF = new Customersform(this);
                DataTable Dt = new DataTable();
                string sql = "";
                if (comboBox1.Text == "ارتجاع تذكرة")
                {
                    sql = @"Select ID,Name From Customers";
                }
                if (comboBox1.Text == "ارتجاع ارساء")
                {
                    sql = @"SELECT ID,Name FROM Drivers Where IsEmployee = 0";
                }
                if (comboBox1.Text == "ارتجاع حجز")
                {
                    sql = @"SELECT ID,Name FROM Customers";
                }
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(sql, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(Dt);
                CF.DGV.DataSource = Dt;
                CF.ShowDialog();
            }
            else
            {
                MessageBox.Show("برجاء اختيار نوع التذكرة","خطأ");
                return;
            }
        }
        private void Btnsearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "0")
            {
                MessageBox.Show("برجاء اضافة رقم الفاتورة", "خطأ");
                return;
            }
            else if (comboBox1.Text == "--اختر--")
            {
                MessageBox.Show("برجاء اضافة نوع الفاتورة", "خطأ");
                return;
            }
            else
            {
                try
                {
                    var Tickid = Convert.ToInt32(textBox2.Text);
                    if (comboBox1.Text == "ارتجاع تذكرة")
                    {
                        var Qur = @"Select 
                                Treasury.ID,
                                Tickets.PayCash As 'Tickcash',
                                Tickets.PayCard As 'Tickcard',
                                Tickets.CustomerID,
                                Rental.Ticketid,
                                Rentaltransactions.PayCash As 'Rentcash',
								Rentaltransactions.PayCard As 'Rentcard'
                                From Tickets 
                                Inner Join Treasury
                                On Tickets.UserID = Treasury.UserID
                                Left Outer Join Rental
                                Left Outer Join Rentaltransactions
								On Rentaltransactions.ID = Rental.RTId
								On Rental.Ticketid = Tickets.ID
                                where Tickets.ID =" + Tickid;
                        SQLConn.ConnDB();
                        SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                        SQLConn.dr = SQLConn.cmd.ExecuteReader();
                        if (SQLConn.dr.Read() == true)
                        {
                            CBCashier.SelectedValue = Convert.ToInt32(SQLConn.dr["ID"].ToString());
                            comboBox2.SelectedValue = Convert.ToInt32(SQLConn.dr["CustomerID"].ToString());
                            var Ticket = SQLConn.dr["Ticketid"].ToString();
                            if (Ticket != "")
                            {
                                var Rentcash = Convert.ToDecimal(SQLConn.dr["Rentcash"].ToString());
                                var Rentcard = Convert.ToDecimal(SQLConn.dr["Rentcard"].ToString());
                                var Tickcash = Convert.ToDecimal(SQLConn.dr["Tickcash"].ToString());
                                var Tickcard = Convert.ToDecimal(SQLConn.dr["Tickcard"].ToString());
                                var Cashtot = Rentcash + Tickcash;
                                var Cardtot = Rentcard + Tickcard;
                                txtpaycash.Text = Cashtot.ToString();
                                txtpaycard.Text = Cardtot.ToString();
                            }
                            else
                            {
                                txtpaycash.Text = SQLConn.dr["Tickcash"].ToString();
                                txtpaycard.Text = SQLConn.dr["Tickcard"].ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("لا يوجد فاتورة رقم هذه الفاتورة");
                            return;
                        }
                    }
                    if (comboBox1.Text == "ارتجاع ارساء")
                    {
                        var Qur = @"Select 
                                Landing.ID,
                                LandingPaymentTransaction.PayCash,
                                LandingPaymentTransaction.PayCard,
								Treasury.ID As Treasuryid,
								Treasury.Name,
								Drivers.ID As Driverid,
								Drivers.Name As Drivername
                                From LandingPaymentTransaction 
                                Inner Join Landing
                                On LandingPaymentTransaction.LandingID = Landing.ID 
								Inner Join Treasury
                                On Landing.Userid = Treasury.UserID  
								Inner Join SeaTransport
                                On Landing.SeaTransportID = SeaTransport.ID
								Inner Join Drivers
                                On SeaTransport.DriverID = Drivers.ID
                                where Landing.ID = " + Tickid ;
                        SQLConn.ConnDB();
                        SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                        SQLConn.dr = SQLConn.cmd.ExecuteReader();
                        if (SQLConn.dr.Read() == true)
                        {
                            var UID = SQLConn.dr["Treasuryid"].ToString();
                            CBCashier.SelectedValue = Convert.ToInt32(UID);
                            comboBox2.SelectedValue = Convert.ToInt32(SQLConn.dr["Driverid"].ToString());
                            txtpaycash.Text = SQLConn.dr["PayCash"].ToString();
                            txtpaycard.Text = SQLConn.dr["PayCard"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("لا يوجد فاتورة رقم هذه الفاتورة");
                            return;
                        }
                    }
                    if (comboBox1.Text == "ارتجاع حجز")
                    {
                        var Qur = @"Select 
                                    Rental.ID,
                                Rentaltransactions.PayCash,
                                Rentaltransactions.PayCard,
								Rentaltransactions.Paytamara,
								Rentaltransactions.Paytransfer,
                                Customers.ID As 'CustomerID',
								Customers.Name,
								Treasury.ID As Treasuryid,
								Treasury.Name,
                                Rental.Rentstatus,
                                Rental.Paymethode
                                From Rentaltransactions 
                                Left Outer Join Rental
                                On Rental.RTId = Rentaltransactions.ID 
								Left Outer Join Treasury
                                On Rental.Treasuryid = Treasury.UserID  
								Left Outer Join SeaTransport
                                On Rental.Searentid = SeaTransport.ID
                                Left Outer Join Customers
								On Rental.Customerid = Customers.ID
                                where Rental.ID = " + Tickid;
                        SQLConn.ConnDB();
                        SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                        SQLConn.dr = SQLConn.cmd.ExecuteReader();
                        if (SQLConn.dr.Read() == true)
                        {
                            var Ticket = SQLConn.dr["Rentstatus"].ToString();
                            if (Ticket != "")
                            {
                                MessageBox.Show("لا يمكن ارتجاع هذا الحجز برجاء مراجعة التذاكر","خطأ");
                                return;
                            }
                            else
                            {
                                var UID = SQLConn.dr["Treasuryid"].ToString();
                                CBCashier.SelectedValue = Convert.ToInt32(UID);
                                comboBox2.SelectedValue = Convert.ToInt32(SQLConn.dr["CustomerID"].ToString());
                                paymentMethod.Text = SQLConn.dr["Paymethode"].ToString();
                                txtpaycash.Text = SQLConn.dr["PayCash"].ToString();
                                txtpaycard.Text = SQLConn.dr["PayCard"].ToString();
                                tamarapay.Text = SQLConn.dr["Paytamara"].ToString();
                                transpay.Text = SQLConn.dr["Paytransfer"].ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("لا يوجد فاتورة رقم هذه الفاتورة");
                            return;
                        }
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
        }
        private void HiddenFild()
        {
            label6.Visible = false;
            txtpaycard.Visible = false;
            txtpaycard.Text = "0";
            label29.Visible = false;
            transpay.Visible = false;
            transpay.Text = "0";
            txtpaycash.Visible = false;
            txtpaycash.Text = "0";
            label31.Visible = false;
            tamarapay.Visible = false;
            tamarapay.Text = "0";
            label7.Visible = false;
        }
        public void Cheackpayment()
        {
            var Case = paymentMethod.Text;
            switch (Case)
            {
                case "نقدي":
                    HiddenFild();
                    txtpaycard.Text = "0";
                    txtpaycash.Visible = true;
                    label6.Visible = true;
                    break;
                case "بنكي":
                    HiddenFild();
                    txtpaycard.Visible = true;
                    label7.Visible = true;
                    break;
                case "تحويل بنكي":
                    HiddenFild();
                    label29.Visible = true;
                    transpay.Visible = true;
                    break;
                case "تمارا":
                    HiddenFild();
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    break;
                case "نقدي وبنكي":
                    HiddenFild();
                    label6.Visible = true;
                    label7.Visible = true;
                    txtpaycard.Visible = true;
                    txtpaycash.Visible = true;
                    break;
                case "نقدي وتحويل":
                    HiddenFild();
                    txtpaycash.Text = "0";
                    txtpaycash.Visible = true;
                    label6.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    transpay.Text = "0";
                    break;
                case "تمارا ونقدي":
                    HiddenFild();
                    txtpaycash.Visible = true;
                    label6.Visible = true;
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    break;
                case "بنكي وتحويل":
                    HiddenFild();
                    txtpaycard.Text = "0";
                    txtpaycard.Visible = true;
                    label7.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    transpay.Text = "0";
                    break;
                case "تمارا وبنكي":
                    HiddenFild();
                    txtpaycard.Visible = true;
                    label31.Visible = true;
                    label7.Visible = true;
                    tamarapay.Visible = true;
                    break;
                case "نقدي وبنكي وتحويل":
                    HiddenFild();
                    //label31.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    txtpaycard.Visible = true;
                    txtpaycash.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    break;
                case "تمارا وتحويل":
                    HiddenFild();
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    break;
                case "تمارا ونقدي وبنكي":
                    HiddenFild();
                    txtpaycash.Visible = true;
                    txtpaycard.Visible = true;
                    label7.Visible = true;
                    label6.Visible = true;
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    break;
                case "تمارا ونقدي وبنكي وتحويل":
                    HiddenFild();
                    txtpaycash.Visible = true;
                    txtpaycard.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    break;
                case "--اختر--":
                    HiddenFild();
                    break;
            }
        }
        private void paymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cheackpayment();
        }
        
        // Tickets
        public void Ticketcashretpay()
        {
            if (!string.IsNullOrEmpty(txtretcash.Text) && txtretcash.Text != "0")
            {
                SQLConn.sqL = "INSERT INTO TreasuryTransactions(TransfertAmount,TicketID,Libelle,TreasuryID,Date) VALUES" +
                                                              "(@TransfertAmount,@TicketID,@Libelle,@TreasuryID,@Date)";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.ConnDB();
                SQLConn.cmd.Parameters.AddWithValue("@TransfertAmount", -Convert.ToDecimal(txtretcash.Text));
                SQLConn.cmd.Parameters.AddWithValue("@TicketID", Convert.ToInt32(textBox2.Text));
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", comboBox1.Text);
                //SQLConn.cmd.Parameters.AddWithValue("@TreasuryID", TID);
                SQLConn.cmd.Parameters.AddWithValue("@TreasuryID", Convert.ToInt32(CBCashier.SelectedValue.ToString()));
                SQLConn.cmd.Parameters.AddWithValue("@Date", DT);
                SQLConn.cmd.ExecuteNonQuery();
                SQLConn.ConnDB();

                //var Qur = @"Select * From Treasury Where ID = " + TID + " ";
                var Qur = @"Select * From Treasury Where ID = " + Convert.ToInt32(CBCashier.SelectedValue.ToString()) + " ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                Double Bal = 0.00;
                if (SQLConn.dr.Read() == true)
                {
                    Bal = Convert.ToDouble(SQLConn.dr["Balance"].ToString());
                }
                //سيتم خصم المبلغ الاجمالي من الكاشير
                var Tot = Convert.ToDouble(txtretcash.Text) + Convert.ToDouble(txtretbank.Text);
                Double Res = Bal - Tot;
                SQLConn.sqL = "Update Treasury Set Balance = @Balance where ID = " + Convert.ToInt32(CBCashier.SelectedValue.ToString()) + " ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Balance", Res);
                SQLConn.cmd.ExecuteNonQuery();
            }
        }
        public void Ticketcardretpay()
        {
            if (!string.IsNullOrEmpty(txtretbank.Text) && txtretbank.Text != "0")
            {
                SQLConn.sqL = "INSERT INTO BankAccountTransactions(Amount,TicketID,Libelle,BankID,Date) VALUES" +
                                                              "(@Amount,@TicketID,@Libelle,@BankID,@Date)";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.ConnDB();
                SQLConn.cmd.Parameters.AddWithValue("@Amount", -Convert.ToDecimal(txtretbank.Text));
                SQLConn.cmd.Parameters.AddWithValue("@TicketID", Convert.ToInt32(textBox2.Text));
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", comboBox1.Text);
                SQLConn.cmd.Parameters.AddWithValue("@BankID", 1);
                SQLConn.cmd.Parameters.AddWithValue("@Date", DT);
                SQLConn.cmd.ExecuteNonQuery();
                SQLConn.ConnDB();

                var Qur = @"Select * From BankAccounts Where ID = 1";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                Double Bal = 0.00;
                if (SQLConn.dr.Read() == true)
                {
                    var BA = SQLConn.dr["Balance"].ToString();
                    if (string.IsNullOrEmpty(BA))
                    {
                        BA = "0.00";
                    }
                    else
                    {
                        Bal = Convert.ToDouble(BA);

                    }
                }
                //سيتم خصم المبلغ الاجمالي من البنك
                var Tot = Convert.ToDouble(txtretbank.Text) + Convert.ToDouble(txtretcash.Text);
                Double Res = Bal - Tot;
                SQLConn.sqL = "Update BankAccounts Set Balance = @Balance where ID = 1";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Balance", Res);
                SQLConn.cmd.ExecuteNonQuery();
            }
        }
        public void Tickettransretpay()
        {
            SQLConn.sqL = "INSERT INTO Banktransfers(Amount,Ticketid) VALUES" +
                                              "(@Amount,@TicketID)";
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.ConnDB();
            SQLConn.cmd.Parameters.AddWithValue("@Amount", -Convert.ToDecimal(txtrettrans.Text));
            SQLConn.cmd.Parameters.AddWithValue("@TicketID", Convert.ToInt32(textBox2.Text));
            SQLConn.cmd.ExecuteNonQuery();
            SQLConn.ConnDB();
        }
        public void Tickettamararetpay()
        {
            SQLConn.sqL = "INSERT INTO Tamara(Amount,Ticketid) VALUES" +
                                  "(@Amount,@TicketID)";
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.ConnDB();
            SQLConn.cmd.Parameters.AddWithValue("@Amount", -Convert.ToDecimal(txtrettamara.Text));
            SQLConn.cmd.Parameters.AddWithValue("@TicketID", Convert.ToInt32(textBox2.Text));
            SQLConn.cmd.ExecuteNonQuery();
            SQLConn.ConnDB();
        }
        // End Tickets


        // Landing
        public void Landingcashretpay()
        {
            if (!string.IsNullOrEmpty(txtretcash.Text) && txtretcash.Text != "0")
            {
                try
                {
                    //Update Landing And Landing Payment Transactions
                    var Qurlandingtrans = @"Select * From LandingPaymentTransaction Where ID = '" + Convert.ToInt32(textBox2.Text) + "'";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(Qurlandingtrans, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();
                    decimal PayCash = 0;
                    decimal PayCard = 0;
                    int LandingID = 0;
                    string PaymentDoneToDate = "";
                    string PaymentTransactionStartDate = "";
                    int id = 0;
                    if (SQLConn.dr.Read() == true)
                    {
                        id = Convert.ToInt32(SQLConn.dr["ID"].ToString());
                        PayCash = Convert.ToDecimal(SQLConn.dr["PayCash"].ToString());
                        PayCard = Convert.ToDecimal(SQLConn.dr["PayCard"].ToString());
                        LandingID = Convert.ToInt32(SQLConn.dr["LandingID"].ToString());
                        PaymentDoneToDate = SQLConn.dr["PaymentDoneToDate"].ToString();
                        PaymentTransactionStartDate = SQLConn.dr["PaymentTransactionStartDate"].ToString();
                    }
                    SQLConn.ConnDB();

                    SQLConn.sqL = "INSERT INTO LandingPaymentTransaction(PayCash,PayCard,Date,LandingID,PaymentDoneToDate,PaymentTransactionStartDate,Userid) VALUES" +
                                          "(@PayCash,@PayCard,@Date,@LandingID,@PaymentDoneToDate,@PaymentTransactionStartDate,@Userid)";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.ConnDB();
                    SQLConn.cmd.Parameters.AddWithValue("@PayCash", -Convert.ToDecimal(PayCash));
                    SQLConn.cmd.Parameters.AddWithValue("@PayCard", -Convert.ToDecimal(PayCard));
                    SQLConn.cmd.Parameters.AddWithValue("@Date", DT);
                    SQLConn.cmd.Parameters.AddWithValue("@Userid", Data.UserID);
                    SQLConn.cmd.Parameters.AddWithValue("@LandingID", LandingID);
                    SQLConn.cmd.Parameters.AddWithValue("@PaymentDoneToDate", PaymentDoneToDate);
                    SQLConn.cmd.Parameters.AddWithValue("@PaymentTransactionStartDate", PaymentTransactionStartDate);
                    SQLConn.cmd.ExecuteNonQuery();
                    SQLConn.ConnDB();

                    var Qurlanding = @"Select * From Landing Where ID = '" + id + "'";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(Qurlanding, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();
                    decimal Amount = 0;
                    string StartDate = "";
                    string EndDate = "";
                    int SeaTransportID = 0;
                    decimal DailyAmount = 0;
                    if (SQLConn.dr.Read() == true)
                    {
                        Amount = Convert.ToDecimal(SQLConn.dr["Amount"].ToString());

                        StartDate = SQLConn.dr["StartDate"].ToString();
                        EndDate = SQLConn.dr["EndDate"].ToString();
                        SeaTransportID = Convert.ToInt32(SQLConn.dr["SeaTransportID"].ToString());
                        DailyAmount = Convert.ToDecimal(SQLConn.dr["DailyAmount"].ToString());
                        PaymentDoneToDate = SQLConn.dr["PaymentDoneToDate"].ToString();
                    }
                    SQLConn.ConnDB();

                    SQLConn.sqL = "INSERT INTO Landing(Amount,StartDate,EndDate,SeaTransportID,DailyAmount,PaymentDoneToDate,Userid) VALUES" +
                                          "(@Amount,@StartDate,@EndDate,@SeaTransportID,@DailyAmount,@PaymentDoneToDate,@Userid)";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.ConnDB();
                    SQLConn.cmd.Parameters.AddWithValue("@Amount", -Convert.ToDecimal(Amount));
                    SQLConn.cmd.Parameters.AddWithValue("@StartDate", StartDate);
                    SQLConn.cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    SQLConn.cmd.Parameters.AddWithValue("@Userid", Data.UserID);
                    SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", SeaTransportID);
                    SQLConn.cmd.Parameters.AddWithValue("@DailyAmount", -Convert.ToDecimal(DailyAmount));
                    SQLConn.cmd.Parameters.AddWithValue("@PaymentDoneToDate", PaymentDoneToDate);
                    SQLConn.cmd.ExecuteNonQuery();
                    SQLConn.ConnDB();
                    //End Update Landing And Landing Payment Transactions

                    //Update Treasury And Treasury Transactions
                    var GTID = SQLConn.GetTreasuryIDForCurrentUser(Data.UserID);
                    SQLConn.sqL = @"INSERT INTO TreasuryTransactions (TransfertAmount,LandingPaymentID,Libelle,TreasuryID,Date) 
                                            VALUES (@TransfertAmount,@LandingPaymentID,@Libelle,@TreasuryID,@Date)";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.ConnDB();
                    SQLConn.cmd.Parameters.AddWithValue("@TransfertAmount", -Convert.ToDecimal(txtretcash.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@LandingPaymentID", id);
                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", comboBox1.Text);
                    SQLConn.cmd.Parameters.AddWithValue("@TreasuryID", GTID);
                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    SQLConn.cmd.ExecuteNonQuery();
                    SQLConn.ConnDB();

                    var Qur = @"Select * From Treasury Where ID = " + GTID;
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();
                    Double Bal = 0.00;
                    if (SQLConn.dr.Read() == true)
                    {
                        Bal = Convert.ToDouble(SQLConn.dr["Balance"].ToString());
                    }
                    var Tot = Convert.ToDouble(txtretcash.Text) + Convert.ToDouble(txtretbank.Text);
                    Double Res = Bal - Tot;
                    SQLConn.sqL = "Update Treasury Set Balance = @Balance where ID = " + GTID;
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.Parameters.AddWithValue("@Balance", Res);
                    SQLConn.cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("هذه الفاتورة غير موجودة", "خطأ");
                    return;
                }
                //End Update Treasury And Treasury Transactions
            }
        }
        public void Landingcardretpay()
        {
            if (!string.IsNullOrEmpty(txtretbank.Text) && txtretbank.Text != "0")
            {
                //Update Bank And Bank Transactions
                try
                {
                    var Qurlandingtrans = @"Select * From LandingPaymentTransaction Where ID = '" + Convert.ToInt32(textBox2.Text) + "'";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(Qurlandingtrans, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();
                    decimal PayCash = 0;
                    decimal PayCard = 0;
                    int LandingID = 0;
                    string PaymentDoneToDate = "";
                    string PaymentTransactionStartDate = "";
                    int id = 0;
                    if (SQLConn.dr.Read() == true)
                    {
                        id = Convert.ToInt32(SQLConn.dr["ID"].ToString());
                        PayCash = Convert.ToDecimal(SQLConn.dr["PayCash"].ToString());
                        PayCard = Convert.ToDecimal(SQLConn.dr["PayCard"].ToString());
                        LandingID = Convert.ToInt32(SQLConn.dr["LandingID"].ToString());
                        PaymentDoneToDate = SQLConn.dr["PaymentDoneToDate"].ToString();
                        PaymentTransactionStartDate = SQLConn.dr["PaymentTransactionStartDate"].ToString();
                    }
                    SQLConn.ConnDB();

                    var Qurlanding = @"Select * From Landing Where ID = '" + LandingID + "'";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(Qurlanding, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();
                    decimal Amount = 0;
                    string StartDate = "";
                    string EndDate = "";
                    int SeaTransportID = 0;
                    decimal DailyAmount = 0;
                    if (SQLConn.dr.Read() == true)
                    {
                        Amount = Convert.ToDecimal(SQLConn.dr["Amount"].ToString());

                        StartDate = SQLConn.dr["StartDate"].ToString();
                        EndDate = SQLConn.dr["EndDate"].ToString();
                        SeaTransportID = Convert.ToInt32(SQLConn.dr["SeaTransportID"].ToString());
                        DailyAmount = Convert.ToDecimal(SQLConn.dr["DailyAmount"].ToString());
                        PaymentDoneToDate = SQLConn.dr["PaymentDoneToDate"].ToString();
                    }
                    SQLConn.ConnDB();

                    SQLConn.sqL = "INSERT INTO BankAccountTransactions(Amount,LandingPaymentID,Libelle,BankID,Date) VALUES" +
                                                                 "(@Amount,@LandingPaymentID,@Libelle,@BankID,@Date)";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.ConnDB();
                    SQLConn.cmd.Parameters.AddWithValue("@Amount", -Convert.ToDecimal(txtretbank.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@LandingPaymentID", id);
                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", comboBox1.Text);
                    SQLConn.cmd.Parameters.AddWithValue("@BankID", 1);
                    SQLConn.cmd.Parameters.AddWithValue("@Date", DT);
                    SQLConn.cmd.ExecuteNonQuery();
                    SQLConn.ConnDB();

                    var Qur = @"Select * From BankAccounts Where ID = 1";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();
                    Double Bal = 0.00;
                    if (SQLConn.dr.Read() == true)
                    {
                        Bal = Convert.ToDouble(SQLConn.dr["Balance"].ToString());
                    }
                    var Tot = Convert.ToDouble(txtretcash.Text) + Convert.ToDouble(txtretbank.Text);
                    Double Res = Bal - Tot;
                    SQLConn.sqL = "Update BankAccounts Set Balance = @Balance where ID = 1";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.Parameters.AddWithValue("@Balance", Res);
                    SQLConn.cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("هذه الفاتورة غير موجودة", "خطأ");
                    return;
                }
                //End Update Bank And Bank Transactions
            }
        }
        public void Landingtransretpay()
        {
            SQLConn.sqL = "INSERT INTO Banktransfers(Amount,LandingPaymentID) VALUES" +
                                              "(@Amount,@LandingPaymentID)";
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.ConnDB();
            SQLConn.cmd.Parameters.AddWithValue("@Amount", -Convert.ToDecimal(txtrettrans.Text));
            SQLConn.cmd.Parameters.AddWithValue("@LandingPaymentID", Convert.ToInt32(textBox2.Text));
            SQLConn.cmd.ExecuteNonQuery();
            SQLConn.ConnDB();
        }
        public void Landingtamararetpay()
        {
            SQLConn.sqL = "INSERT INTO Tamara(Amount,LandingPaymentID) VALUES" +
                                  "(@Amount,@LandingPaymentID)";
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.ConnDB();
            SQLConn.cmd.Parameters.AddWithValue("@Amount", -Convert.ToDecimal(txtrettamara.Text));
            SQLConn.cmd.Parameters.AddWithValue("@LandingPaymentID", Convert.ToInt32(textBox2.Text));
            SQLConn.cmd.ExecuteNonQuery();
            SQLConn.ConnDB();
        }
        //End Landing



        // Rentals
        public void Rentalcashretpay()
        {
            if (!string.IsNullOrEmpty(txtretcash.Text) && txtretcash.Text != "0")
            {

                SQLConn.sqL = "INSERT INTO TreasuryTransactions(TransfertAmount,TicketID,Libelle,TreasuryID,Date) VALUES" +
                                                              "(@TransfertAmount,@TicketID,@Libelle,@TreasuryID,@Date)";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.ConnDB();
                SQLConn.cmd.Parameters.AddWithValue("@TransfertAmount", -Convert.ToDecimal(txtretcash.Text));
                SQLConn.cmd.Parameters.AddWithValue("@TicketID", Convert.ToInt32(textBox2.Text));
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", comboBox1.Text);
                //SQLConn.cmd.Parameters.AddWithValue("@TreasuryID", TID);
                SQLConn.cmd.Parameters.AddWithValue("@TreasuryID", Convert.ToInt32(CBCashier.SelectedValue.ToString()));
                SQLConn.cmd.Parameters.AddWithValue("@Date", DT);
                SQLConn.cmd.ExecuteNonQuery();
                SQLConn.ConnDB();

                //var Qur = @"Select * From Treasury Where ID = " + TID + " ";
                var Qur = @"Select * From Treasury Where ID = " + Convert.ToInt32(CBCashier.SelectedValue.ToString()) + " ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                Double Bal = 0.00;
                if (SQLConn.dr.Read() == true)
                {
                    Bal = Convert.ToDouble(SQLConn.dr["Balance"].ToString());
                }
                var Tot = Convert.ToDouble(txtretcash.Text) + Convert.ToDouble(txtretbank.Text);
                Double Res = Bal - Tot;
                SQLConn.sqL = "Update Treasury Set Balance = @Balance where ID = " + Convert.ToInt32(CBCashier.SelectedValue.ToString()) + " ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Balance", Res);
                SQLConn.cmd.ExecuteNonQuery();
            }
        }
        public void Rentalcardretpay()
        {
            if (!string.IsNullOrEmpty(txtretbank.Text) && txtretbank.Text != "0")
            {
                SQLConn.sqL = "INSERT INTO BankAccountTransactions(Amount,TicketID,Libelle,BankID,Date) VALUES" +
                                                              "(@Amount,@TicketID,@Libelle,@BankID,@Date)";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.ConnDB();
                SQLConn.cmd.Parameters.AddWithValue("@Amount", -Convert.ToDecimal(txtretbank.Text));
                SQLConn.cmd.Parameters.AddWithValue("@TicketID", Convert.ToInt32(textBox2.Text));
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", comboBox1.Text);
                SQLConn.cmd.Parameters.AddWithValue("@BankID", 1);
                SQLConn.cmd.Parameters.AddWithValue("@Date", DT);
                SQLConn.cmd.ExecuteNonQuery();
                SQLConn.ConnDB();

                var Qur = @"Select * From BankAccounts Where ID = 1";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                Double Bal = 0.00;
                if (SQLConn.dr.Read() == true)
                {
                    var BA = SQLConn.dr["Balance"].ToString();
                    if (string.IsNullOrEmpty(BA))
                    {
                        BA = "0.00";
                    }
                    else
                    {
                        Bal = Convert.ToDouble(BA);

                    }
                }
                var Tot = Convert.ToDouble(txtretcash.Text) + Convert.ToDouble(txtretbank.Text);
                Double Res = Bal - Tot;
                SQLConn.sqL = "Update BankAccounts Set Balance = @Balance where ID = 1";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Balance", Res);
                SQLConn.cmd.ExecuteNonQuery();
            }
        }
        public void Rentaltransretpay()
        {
            SQLConn.sqL = "INSERT INTO Banktransfers(Amount,Rentalid) VALUES" +
                                              "(@Amount,@Rentalid)";
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.ConnDB();
            SQLConn.cmd.Parameters.AddWithValue("@Amount", -Convert.ToDecimal(txtrettrans.Text));
            SQLConn.cmd.Parameters.AddWithValue("@Rentalid", Convert.ToInt32(textBox2.Text));
            SQLConn.cmd.ExecuteNonQuery();
            SQLConn.ConnDB();
        }
        public void Rentaltamararetpay()
        {
            SQLConn.sqL = "INSERT INTO Tamara(Amount,Rentalid) VALUES" +
                                  "(@Amount,@Rentalid)";
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.ConnDB();
            SQLConn.cmd.Parameters.AddWithValue("@Amount", -Convert.ToDecimal(txtrettamara.Text));
            SQLConn.cmd.Parameters.AddWithValue("@Rentalid", Convert.ToInt32(textBox2.Text));
            SQLConn.cmd.ExecuteNonQuery();
            SQLConn.ConnDB();
        }
        //End Rentals


        public void HiddenretFilds()
        {
            txtretcash.Text = "0";
            txtretcash.Visible = false;
            txtretbank.Text = "0";
            txtretbank.Visible = false;
            txtrettrans.Text = "0";
            txtrettrans.Visible = false;
            txtrettamara.Text = "0";
            txtrettamara.Visible = false;
            lblcash.Visible = false;
            lblbank.Visible = false;
            lbltrans.Visible = false;
            lbltamara.Visible = false;
        }
        public void Cheackretpayment()
        {
            var Case = Retpay.Text;
            switch (Case)
            {
                case "نقدي":
                    HiddenretFilds();
                    txtretcash.Text = "0";
                    txtretcash.Visible = true;
                    lblcash.Visible = true;
                    break;
                case "بنكي":
                    HiddenretFilds();
                    txtretbank.Text = "0";
                    txtretbank.Visible = true;
                    lblbank.Visible = true;
                    break;
                case "تحويل بنكي":
                    HiddenretFilds();
                    lbltrans.Visible = true;
                    txtrettrans.Text = "0";
                    txtrettrans.Visible = true;
                    break;
                case "تمارا":
                    HiddenretFilds();
                    lbltamara.Visible = true;
                    txtrettamara.Text = "0";
                    txtrettamara.Visible = true;
                    break;
                case "نقدي وبنكي":
                    HiddenretFilds();
                    txtretcash.Text = "0";
                    txtretcash.Visible = true;
                    lblcash.Visible = true;
                    txtretbank.Text = "0";
                    txtretbank.Visible = true;
                    lblbank.Visible = true;
                    break;
                case "نقدي وتحويل":
                    HiddenretFilds();
                    txtretcash.Text = "0";
                    txtretcash.Visible = true;
                    lblcash.Visible = true;
                    lbltrans.Visible = true;
                    txtrettrans.Text = "0";
                    txtrettrans.Visible = true;
                    break;
                case "تمارا ونقدي":
                    HiddenretFilds();
                    txtretcash.Text = "0";
                    txtretcash.Visible = true;
                    lblcash.Visible = true;
                    lbltamara.Visible = true;
                    txtrettamara.Text = "0";
                    txtrettamara.Visible = true;
                    break;
                case "بنكي وتحويل":
                    HiddenretFilds();
                    lblbank.Visible = true;
                    txtretbank.Text = "0";
                    txtretbank.Visible = true;
                    lbltrans.Visible= true;
                    txtrettrans.Text = "0";
                    txtrettrans.Visible = true;
                    break;
                case "تمارا وبنكي":
                    HiddenretFilds();
                    lblbank.Visible = true;
                    txtretbank.Text = "0";
                    txtretbank.Visible = true;
                    lbltamara.Visible = true;
                    txtrettamara.Text = "0";
                    txtrettamara.Visible = true;
                    break;
                case "نقدي وبنكي وتحويل":
                    HiddenretFilds();
                    lblcash.Visible = true;
                    txtretcash.Text = "0";
                    txtretcash.Visible = true;
                    lblbank.Visible = true;
                    txtretbank.Text = "0";
                    txtretbank.Visible = true;
                    lbltrans.Visible = true;
                    txtrettrans.Text = "0";
                    txtrettrans.Visible = true;
                    break;
                case "تمارا وتحويل":
                    HiddenretFilds();
                    lbltamara.Visible = true;
                    txtrettamara.Text = "0";
                    txtrettamara.Visible = true;
                    lbltrans.Visible = true;
                    txtrettrans.Text = "0";
                    txtrettrans.Visible = true;
                    break;
                case "تمارا ونقدي وبنكي":
                    HiddenretFilds();
                    lblcash.Visible = true;
                    txtretcash.Text = "0";
                    txtretcash.Visible = true;
                    lblbank.Visible = true;
                    txtretbank.Text = "0";
                    txtretbank.Visible = true;
                    lbltamara.Visible = true;
                    txtrettamara.Text = "0";
                    txtrettamara.Visible = true;
                    break;
                case "تمارا ونقدي وبنكي وتحويل":
                    HiddenretFilds();
                    lblcash.Visible = true;
                    txtretcash.Text = "0";
                    txtretcash.Visible = true;
                    lblbank.Visible = true;
                    txtretbank.Text = "0";
                    txtretbank.Visible = true;
                    lbltamara.Visible = true;
                    txtrettamara.Text = "0";
                    txtrettamara.Visible = true;
                    lbltrans.Visible = true;
                    txtrettrans.Text = "0";
                    txtrettrans.Visible = true;
                    break;
                case "--اختر--":
                    HiddenretFilds();
                    break;
            }
        }
        private void Retpay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cheackretpayment();
        }
        private void txtpaycash_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpaycash.Text))
            {
                GetTotalPay();
            }
        }
        private void txtpaycard_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpaycard.Text))
            {
                GetTotalPay();
            }
        }
        private void transpay_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(transpay.Text))
            {
                GetTotalPay();
            }
        }
        private void tamarapay_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tamarapay.Text))
            {
                GetTotalPay();
            }
        }
        private void txtretcash_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtretcash.Text))
            {
                GetRetTotalPay();
            }
        }
        private void txtretbank_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtretbank.Text))
            {
                GetRetTotalPay();
            }
        }
        private void txtrettrans_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtrettrans.Text))
            {
                GetRetTotalPay();
            }
        }
        private void txtrettamara_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtrettamara.Text))
            {
                GetRetTotalPay();
            }
        }
    }
}
