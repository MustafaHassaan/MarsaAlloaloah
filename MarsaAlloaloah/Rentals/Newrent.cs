using CrystalDecisions.Shared.Json;
using MarsaAlloaloah.CrystalReports;
using MarsaAlloaloah.CrystalReports.CQR;
using MarsaAlloaloah.FrmReports;
using MarsaAlloaloah.Utility;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Utilities.Collections;
using SmartArabXLSX.Drawing.Charts;
using SmartArabXLSX.Spreadsheet;
using SmartArabXLSX.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data = MarsaAlloaloah.Utility.Data;
using DataTable = System.Data.DataTable;

namespace MarsaAlloaloah.Rentals
{
    public partial class Newrent : Form
    {
        public Newrent()
        {
            InitializeComponent();
        }
        decimal totalBeforeVAT;
        decimal PriceBeforeDiscount = 0.0m;
        decimal VatPercent = 0.0m;
        bool ISVAT;
        double VP;
        public int idnum { get; set; }
        public int idtnum { get; set; }
        public string Lastcash { get; set; }
        public string Lastcard { get; set; }
        public string Lastdp { get; set; }
        private void AddTransaction()
        {
            try
            {
                SQLConn.sqL = "Insert Into Rentaltransactions (Price,DiscountAmount,DiscountPercent,PriceAfterDiscount,VAT,PriceAfterVAT,PayCash,PayCard,Paytransfer,Paytamara)" +
                              "OUTPUT INSERTED.ID "+
                              "VALUES (@Price,@DiscountAmount,@DiscountPercent,@PriceAfterDiscount,@VAT,@PriceAfterVAT,@PayCash,@PayCard,@Paytransfer,@Paytamara);";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(lblPrice.Text));
                SQLConn.cmd.Parameters.AddWithValue("@DiscountAmount", Convert.ToDecimal(lbldisc.Text));
                SQLConn.cmd.Parameters.AddWithValue("@DiscountPercent", Convert.ToDecimal(txtDiscountPercent.Text)/100);
                SQLConn.cmd.Parameters.AddWithValue("@PriceAfterDiscount", Convert.ToDecimal(lblTotal.Text));
                SQLConn.cmd.Parameters.AddWithValue("@VAT", Convert.ToDecimal(lblVAT.Text));
                SQLConn.cmd.Parameters.AddWithValue("@PriceAfterVAT", Convert.ToDecimal(lblTotalAfterVAT.Text));
                SQLConn.cmd.Parameters.AddWithValue("@PayCash", Convert.ToDecimal(txtpaycash.Text));
                SQLConn.cmd.Parameters.AddWithValue("@PayCard", Convert.ToDecimal(txtpaycard.Text));
                SQLConn.cmd.Parameters.AddWithValue("@Paytamara", Convert.ToDecimal(tamarapay.Text));
                SQLConn.cmd.Parameters.AddWithValue("@Paytransfer", Convert.ToDecimal(transpay.Text));
                idtnum = (Int32)SQLConn.cmd.ExecuteScalar();
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
        private void EditTransaction()
        {
            try
            {
                SQLConn.sqL = "Update Rentaltransactions Set " +
                              "Price = @Price, " +
                              "DiscountAmount = @DiscountAmount, " +
                              "DiscountPercent = @DiscountPercent, " +
                              "PriceAfterDiscount = @PriceAfterDiscount, " +
                              "VAT = @VAT, " +
                              "PriceAfterVAT = @PriceAfterVAT, " +
                              "PayCash = @PayCash, " +
                              "PayCard = @PayCard "+
                              "@Paytransfer = Paytransfer," +
                              "@Paytamara = Paytamara "+
                              "Where ID = @ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@ID", idtnum);
                SQLConn.cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(lblPrice.Text));
                SQLConn.cmd.Parameters.AddWithValue("@DiscountAmount", Convert.ToDecimal(lbldisc.Text));
                SQLConn.cmd.Parameters.AddWithValue("@DiscountPercent", Convert.ToDecimal(txtDiscountPercent.Text) / 100);
                SQLConn.cmd.Parameters.AddWithValue("@PriceAfterDiscount", Convert.ToDecimal(lblTotal.Text));
                SQLConn.cmd.Parameters.AddWithValue("@VAT", Convert.ToDecimal(lblVAT.Text));
                SQLConn.cmd.Parameters.AddWithValue("@PriceAfterVAT", Convert.ToDecimal(lblTotalAfterVAT.Text));
                SQLConn.cmd.Parameters.AddWithValue("@PayCash", Convert.ToDecimal(txtpaycash.Text));
                SQLConn.cmd.Parameters.AddWithValue("@PayCard", Convert.ToDecimal(txtpaycard.Text));
                SQLConn.cmd.Parameters.AddWithValue("@Paytamara", Convert.ToDecimal(tamarapay.Text));
                SQLConn.cmd.Parameters.AddWithValue("@Paytransfer", Convert.ToDecimal(transpay.Text));
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
        private void DeleteTransaction()
        {
            try
            {
                SQLConn.sqL = "Delete From Rentaltransactions " +
                              "Where ID = @ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@ID", idtnum);
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
        private void Rentprint()
        {
            var Qur = @"Select 
                        Rental.ID, 
                        Rental.Rentdate,
                        Rental.Startdate,
                        Rental.Starttime,
                        SeaTransportType.Name As 'Seatransporttypename',
                        SeaTransport.Name As 'Seatransportname',
                        Customers.Name As 'Customername',
						Customers.Mobile,
						Customers.NID,
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
						Rentaltransactions.PayCash + Rentaltransactions.PayCard +
						Rentaltransactions.Paytransfer + Rentaltransactions.Paytamara 
                        As 'Payed',
						(Rentaltransactions.PriceAfterDiscount + Rentaltransactions.VAT) - 
                        (Rentaltransactions.PayCash + Rentaltransactions.PayCard +
						Rentaltransactions.Paytransfer + Rentaltransactions.Paytamara) As 'Remaining',
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
						On Rental.RTId = Rentaltransactions.ID
                        Where Rental.ID = " + idnum;
            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.ConnDB();
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            Rental Rentbill = new Rental();
            dsMarsa ds = new dsMarsa();
            while (SQLConn.dr.Read())
            {
                var ID = SQLConn.dr[0].ToString();
                var Rentdate = SQLConn.dr[1].ToString();
                var Startdate = SQLConn.dr[2].ToString();
                var Starttime = SQLConn.dr[3].ToString();
                var Seatransporttypename = SQLConn.dr[4].ToString();
                var Seatransportname = SQLConn.dr[5].ToString();
                var Customername = SQLConn.dr[6].ToString();
                var Mobile = SQLConn.dr[7].ToString();
                var NID = SQLConn.dr[8].ToString();
                var Ticketid = SQLConn.dr[9].ToString();
                var Dauration = SQLConn.dr[10].ToString();
                var Rentstatus = SQLConn.dr[11].ToString();
                var Cashiername = SQLConn.dr[12].ToString();
                var DiscountPercent = SQLConn.dr[13].ToString();
                if (DiscountPercent != "")
                {
                    DiscountPercent = Convert.ToString(Convert.ToInt32(Convert.ToDecimal(SQLConn.dr[13].ToString()) * 100));
                }
                var DiscountAmount = SQLConn.dr[14].ToString();
                var Price = SQLConn.dr[15].ToString();
                var PriceAfterDiscount = SQLConn.dr[16].ToString();
                var VAT = SQLConn.dr[17].ToString();
                var Priceaftervat = SQLConn.dr[18].ToString();
                var Payed = SQLConn.dr[19].ToString();
                var Remaining = SQLConn.dr[20].ToString();
                var Notetext = SQLConn.dr[21].ToString();
                ds.Rentalbill.Rows.Add(new object[] {
                    ID,
                    Rentdate,
                    Startdate,
                    Starttime,
                    Seatransporttypename,
                    Seatransportname,
                    Customername,
                    Mobile,
                    NID,
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
            SQLConn.conn.Close();

            //NewRep NRP = new NewRep();
            //NRP.FRA.ReportSource = Rentbill;
            //NRP.FRA.Refresh();
            //NRP.Show();


            Rentbill.SetDataSource(ds);
            Rentbill.PrintOptions.PrinterName = Properties.Settings.Default.Printername;
            var server = new LocalPrintServer();
            PrintQueue queue = server.DefaultPrintQueue;

            var DN = queue.Name;
            var EN = Properties.Settings.Default.Printername;
            if (DN == EN)
            {
                if (queue.IsOffline)
                {
                    MessageBox.Show("يرجى توصيل الطابعه", "خطأ");
                }
                else if (queue.HasPaperProblem)
                {
                    MessageBox.Show("يرجى التحقق من توصيلات الطابعه", "خطأ");
                }
                else if (queue.IsOutOfPaper)
                {
                    MessageBox.Show("برجاء اضافة اوراق طباعه", "خطأ");
                }
                else
                {
                    Rentbill.PrintToPrinter(1, true, 1, 1);
                    Rentbill.Dispose();
                    SQLConn.conn.Dispose();
                    GC.Collect();
                }
            }
            else
            {
                MessageBox.Show("يرجى التحقق من الطابعه", "خطأ");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "حفظ")
            {
                if (txtCustMobile.Text != null && (txtCustMobile.Text.Length < 10 || txtCustMobile.Text.Length > 10))
                {
                    Interaction.MsgBox("الرجاء التثبت من رقم الجوال");
                    return;
                }
                if (paymentMethod.SelectedIndex == 0)
                {
                    Interaction.MsgBox("الرجاء ادخال نوع الدفع");
                    return;
                }
                Makerent();
            }
            else
            {
                Deleterentpay();
                Updaterent();
                if (transpay.Text != "0.00")
                {
                    SQLConn.sqL = @"INSERT INTO Banktransfers (Amount,Rentalid)
                                                 Values(@Amount,@Rentalid)";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                    SQLConn.cmd.Parameters.AddWithValue("@Amount", transpay.Text);
                    SQLConn.cmd.Parameters.AddWithValue("@Rentalid", idnum);
                    SQLConn.ConnDB();
                    SQLConn.cmd.ExecuteNonQuery();
                }
                if (tamarapay.Text != "0.00")
                {
                    SQLConn.sqL = @"INSERT INTO Tamara (Amount,Rentalid)
                                                 Values(@Amount,@Rentalid)";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                    SQLConn.cmd.Parameters.AddWithValue("@Amount", tamarapay.Text);
                    SQLConn.cmd.Parameters.AddWithValue("@Rentalid", idnum);
                    SQLConn.ConnDB();
                    SQLConn.cmd.ExecuteNonQuery();
                }
            }
        }
        private void Updaterent()
        {
            try
            {
                SQLConn.sqL = "Select Ticketid From Rental Where ID = @ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@ID", idnum);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read())
                {
                    var reder = SQLConn.dr["Ticketid"].ToString();
                    if (reder == "")
                    {
                        var RD = Rentaldate.Value.ToString("yyyy-MM-dd");
                        var SD = dtpStartDate.Value.ToString("yyyy-MM-dd");
                        var ST = dtpStartTime.Value.ToString("HH:mm:ss");
                        if (int.Parse(cmbTypeID.SelectedValue.ToString()) != 0)
                        {
                            if (idtnum == 0)
                            {
                                AddTransaction();
                            }
                            else
                            {
                                EditTransaction();
                            }
                        }
                        try
                        {
                            SQLConn.sqL = "Update Rental Set " +
                                          "ID = @ID," +
                                          "Rentdate = @Rentdate," +
                                          "Startdate = @Startdate," +
                                          "Starttime = @Starttime," +
                                          "Seatypeid = @Seatypeid," +
                                          "Searentid = @Searentid," +
                                          "Customerid = @Customerid," +
                                          "Ticketid = @Ticketid," +
                                          "Dauration = @Dauration," +
                                          "Rentstatus = @Rentstatus, " +
                                          "RTId = @RTId, " +
                                          "Treasuryid = @Treasuryid, " +
                                          "Note = @Note " +
                                          "Where ID = @ID";
                            SQLConn.ConnDB();
                            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                            SQLConn.cmd.Parameters.AddWithValue("@ID", idnum);
                            SQLConn.cmd.Parameters.AddWithValue("@Rentdate", RD);
                            SQLConn.cmd.Parameters.AddWithValue("@Startdate", SD);
                            SQLConn.cmd.Parameters.AddWithValue("@Starttime", ST);
                            if (int.Parse(cmbTypeID.SelectedValue.ToString()) != 0)
                            {
                                SQLConn.cmd.Parameters.AddWithValue("@Seatypeid", cmbTypeID.SelectedValue);
                            }
                            else
                            {
                                SQLConn.cmd.Parameters.AddWithValue("@Seatypeid", DBNull.Value);
                            }
                            if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) != 0)
                            {
                                SQLConn.cmd.Parameters.AddWithValue("@Searentid", cmbSeaTransportID.SelectedValue);
                            }
                            else
                            {
                                SQLConn.cmd.Parameters.AddWithValue("@Searentid", DBNull.Value);
                            }
                            SQLConn.cmd.Parameters.AddWithValue("@Customerid", Convert.ToInt32(lblCustIDHidden.Text));
                            SQLConn.cmd.Parameters.AddWithValue("@Ticketid", DBNull.Value);
                            SQLConn.cmd.Parameters.AddWithValue("@Dauration", cmbDuration.Text);
                            SQLConn.cmd.Parameters.AddWithValue("@Rentstatus", DBNull.Value);
                            SQLConn.cmd.Parameters.AddWithValue("@RTId", idtnum);
                            SQLConn.cmd.Parameters.AddWithValue("@Note", Note.Text);
                            SQLConn.cmd.Parameters.AddWithValue("@Treasuryid", Data.UserID);
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
                        //Update Treasury Balance For Current User 
                        SQLConn.ConnDB();
                        decimal cash = decimal.Parse(txtpaycash.Text);
                        decimal card = decimal.Parse(txtpaycard.Text);
                        int bankId = SQLConn.GetBankAccountID();
                        if (cash.ToString() != "0.00")
                        {
                            //update TreasuryTransactions
                            SQLConn.GetTreasuryIDForCurrentUser(Data.UserID);
                            if (Data.UserTreasuryID > 0)
                            {
                                if (cash > 0)
                                {
                                    try
                                    {
                                        SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID,TicketID, Libelle, Date) 
                                                        values(@NewBalance, @treasuryID, @TicketID, @Libelle,@Date )";

                                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                        SQLConn.cmd.Parameters.AddWithValue("@NewBalance", -Convert.ToDecimal(Lastcash));
                                        SQLConn.cmd.Parameters.AddWithValue("@treasuryID", Data.UserTreasuryID);
                                        SQLConn.cmd.Parameters.AddWithValue("@TicketID", DBNull.Value);
                                        SQLConn.cmd.Parameters.AddWithValue("@Libelle", "تحديث حجز - سحب المبلغ النقدي القديم");
                                        SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                                        SQLConn.cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        Interaction.MsgBox(ex.ToString());
                                    }
                                    try
                                    {
                                        SQLConn.sqL = "Update Treasury Set Balance = Balance +  @NewBalance where ID = @treasuryID";
                                        //SQLConn.ConnDB();
                                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                        SQLConn.cmd.Parameters.AddWithValue("@NewBalance", -Convert.ToDecimal(Lastcash));
                                        SQLConn.cmd.Parameters.AddWithValue("@treasuryID", Data.UserTreasuryID);
                                        SQLConn.cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        Interaction.MsgBox(ex.ToString());
                                    }
                                }
                                try
                                {
                                    SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID,TicketID, Libelle, Date) 
                                                        values(@NewBalance, @treasuryID, @TicketID, @Libelle,@Date )";

                                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", cash);
                                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", Data.UserTreasuryID);
                                    SQLConn.cmd.Parameters.AddWithValue("@TicketID", DBNull.Value);
                                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", "تحديث حجز - المبلغ النقدي الجديد");
                                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                                    SQLConn.cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    Interaction.MsgBox(ex.ToString());
                                }
                                try
                                {
                                    SQLConn.sqL = "Update Treasury Set Balance = Balance +  @NewBalance where ID = @treasuryID";
                                    //SQLConn.ConnDB();
                                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", cash);
                                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", Data.UserTreasuryID);
                                    SQLConn.cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    Interaction.MsgBox(ex.ToString());
                                }
                            }
                        }
                        //Update Bank Account Balance
                        if (card.ToString() != "0.00")
                        {

                            if (bankId > 0)
                            {
                                if (card > 0)
                                {
                                    try
                                    {
                                        SQLConn.sqL = @"insert into BankAccountTransactions (Amount, BankID, TicketID, Libelle,Date)  
                                            values( @NewBalance, @BankID ,@TicketID, @Libelle,@Date)";

                                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                        SQLConn.cmd.Parameters.AddWithValue("@NewBalance", -Convert.ToDecimal(Lastcard));
                                        SQLConn.cmd.Parameters.AddWithValue("@BankID", bankId);
                                        SQLConn.cmd.Parameters.AddWithValue("@TicketID", DBNull.Value);
                                        SQLConn.cmd.Parameters.AddWithValue("@Libelle", "تحديث حجز - سحب المبلغ البنكي القديم");
                                        SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                                        SQLConn.cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        Interaction.MsgBox(ex.ToString());
                                    }
                                    try
                                    {
                                        SQLConn.sqL = "Update BankAccounts Set Balance = Balance +  @NewBalance where ID =" + bankId;

                                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                        SQLConn.cmd.Parameters.AddWithValue("@NewBalance", -Convert.ToDecimal(Lastcard));
                                        SQLConn.cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        Interaction.MsgBox(ex.ToString());
                                    }
                                }
                                try
                                {
                                    SQLConn.sqL = @"insert into BankAccountTransactions (Amount, BankID, TicketID, Libelle,Date)  
                                            values( @NewBalance, @BankID ,@TicketID, @Libelle,@Date)";

                                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", card);
                                    SQLConn.cmd.Parameters.AddWithValue("@BankID", bankId);
                                    SQLConn.cmd.Parameters.AddWithValue("@TicketID", DBNull.Value);
                                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", "تحديث حجز - إظافة المبلغ البنكي الجديد");
                                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                                    SQLConn.cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    Interaction.MsgBox(ex.ToString());
                                }
                                try
                                {
                                    SQLConn.sqL = "Update BankAccounts Set Balance = Balance +  @NewBalance where ID =" + bankId;

                                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", card);
                                    SQLConn.cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    Interaction.MsgBox(ex.ToString());
                                }
                            }
                        }
                        Rentprint();
                        MessageBox.Show("تم تعديل الرحلة بنجاح");
                        ClearFields();
                        GetRentals();
                    }
                    else
                    {
                        MessageBox.Show("لا يمكن تعديل الرحلة");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void GetProductNo()
        {
            try
            {
                SQLConn.sqL = "SELECT ID FROM Rental ORDER BY ID DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    idnum = Convert.ToInt32(SQLConn.dr["ID"].ToString()) + 1;
                }
                else
                {
                    idnum = 1;
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
        private void Makerent()
        {
            var RD = Rentaldate.Value.ToString("yyyy-MM-dd");
            var SD = dtpStartDate.Value.ToString("yyyy-MM-dd");
            var ST = dtpStartTime.Value.ToString("HH:mm:ss");
            var VC = lblCustIDHidden.Text;

            if (VC == "")
            {
                MessageBox.Show("برجاء التحقق من بيانات العميل او اضافته الى العملاء");
                return;
            }
            else
            {
                try
                {
                    if (int.Parse(cmbTypeID.SelectedValue.ToString()) != 0)
                    {
                        AddTransaction();
                    }
                    //if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
                    //{
                    //    Interaction.MsgBox("من فضلك إختر الواسطة البحرية");
                    //    return;
                    //}
                    SQLConn.sqL = "Insert Into Rental (ID,Rentdate,Startdate,Starttime,Seatypeid,Searentid,Customerid,Ticketid,Dauration,Rentstatus,RTId,Note,Treasuryid,Paymethode)" +
                                  "VALUES (@ID,@Rentdate,@Startdate,@Starttime,@Seatypeid,@Searentid,@Customerid,@Ticketid,@Dauration,@Rentstatus,@RTId,@Note,@Treasuryid,@Paymethode)";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.Parameters.AddWithValue("@ID", idnum);
                    SQLConn.cmd.Parameters.AddWithValue("@Rentdate", RD);
                    SQLConn.cmd.Parameters.AddWithValue("@Startdate", SD);
                    SQLConn.cmd.Parameters.AddWithValue("@Starttime", ST);
                    if (int.Parse(cmbTypeID.SelectedValue.ToString()) == 0)
                    {
                        SQLConn.cmd.Parameters.AddWithValue("@Seatypeid", DBNull.Value);
                    }
                    else
                    {
                        SQLConn.cmd.Parameters.AddWithValue("@Seatypeid", cmbTypeID.SelectedValue);
                    }
                    if (cmbSeaTransportID.Text == "")
                    {
                        SQLConn.cmd.Parameters.AddWithValue("@Searentid", DBNull.Value);
                    }
                    else
                    {
                        SQLConn.cmd.Parameters.AddWithValue("@Searentid", cmbSeaTransportID.SelectedValue);
                    }
                    SQLConn.cmd.Parameters.AddWithValue("@Customerid", Convert.ToInt32(lblCustIDHidden.Text));
                    SQLConn.cmd.Parameters.AddWithValue("@Ticketid", DBNull.Value);
                    SQLConn.cmd.Parameters.AddWithValue("@Dauration", cmbDuration.Text);
                    SQLConn.cmd.Parameters.AddWithValue("@Rentstatus", DBNull.Value);
                    SQLConn.cmd.Parameters.AddWithValue("@RTId", idtnum);
                    SQLConn.cmd.Parameters.AddWithValue("@Note", Note.Text);
                    SQLConn.cmd.Parameters.AddWithValue("@Treasuryid", Data.UserID);
                    SQLConn.cmd.Parameters.AddWithValue("@Paymethode", paymentMethod.Text);
                    SQLConn.cmd.ExecuteNonQuery();

                    //Update Treasury Balance For Current User 
                    if (txtpaycash.Text != "0.00")
                    {
                        SQLConn.GetTreasuryIDForCurrentUser(Data.UserID);

                        //update TreasuryTransactions
                        if (Data.UserTreasuryID > 0)
                        {
                            try
                            {
                                SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID,Rentalid, Libelle, Date) 
                                values( @NewBalance, @treasuryID, @Rentalid, @Libelle,@Date )";

                                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", Convert.ToDecimal(txtpaycash.Text));
                                SQLConn.cmd.Parameters.AddWithValue("@treasuryID", Data.UserTreasuryID);
                                SQLConn.cmd.Parameters.AddWithValue("@Rentalid", idnum);
                                SQLConn.cmd.Parameters.AddWithValue("@Libelle", "إظافة حجز");
                                SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                                SQLConn.cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Interaction.MsgBox(ex.ToString());
                            }
                            try
                            {
                                SQLConn.sqL = "Update Treasury Set Balance = Balance +  @NewBalance where ID = @treasuryID";
                                //SQLConn.ConnDB();
                                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", Convert.ToDecimal(txtpaycash.Text));
                                SQLConn.cmd.Parameters.AddWithValue("@treasuryID", Data.UserTreasuryID);
                                SQLConn.cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Interaction.MsgBox(ex.ToString());
                            }
                        }
                    }
                    //Update Bank Account Balance
                    if (txtpaycard.Text != "0.00")
                    {
                        //Decimal.TryParse(txtpaycard.Text, out payCard);

                        int bankId = SQLConn.GetBankAccountID();
                        if (bankId > 0)
                        {
                            try
                            {
                                SQLConn.sqL = @"insert into BankAccountTransactions (Amount, BankID, Rentalid, Libelle,Date)  
                                            values( @NewBalance, @BankID ,@Rentalid, @Libelle,@Date)";

                                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", Convert.ToDecimal(txtpaycard.Text));
                                SQLConn.cmd.Parameters.AddWithValue("@BankID", bankId);
                                SQLConn.cmd.Parameters.AddWithValue("@Rentalid", idnum);
                                SQLConn.cmd.Parameters.AddWithValue("@Libelle", "إظافة حجز");
                                SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                                SQLConn.cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Interaction.MsgBox(ex.ToString());
                            }
                            try
                            {
                                SQLConn.sqL = "Update BankAccounts Set Balance = Balance +  @NewBalance where ID =" + bankId;

                                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", Convert.ToDecimal(txtpaycard.Text));
                                SQLConn.cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Interaction.MsgBox(ex.ToString());
                            }
                        }
                    }

                    if (transpay.Text != "0.00")
                    {
                        SQLConn.sqL = @"INSERT INTO Banktransfers (Amount,Rentalid)
                                                 Values(@Amount,@Rentalid)";
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                        SQLConn.cmd.Parameters.AddWithValue("@Amount", transpay.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@Rentalid", idnum);
                        SQLConn.ConnDB();
                        SQLConn.cmd.ExecuteNonQuery();
                    }
                    if (tamarapay.Text != "0.00")
                    {
                        SQLConn.sqL = @"INSERT INTO Tamara (Amount,Rentalid)
                                                 Values(@Amount,@Rentalid)";
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                        SQLConn.cmd.Parameters.AddWithValue("@Amount", tamarapay.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@Rentalid", idnum);
                        SQLConn.ConnDB();
                        SQLConn.cmd.ExecuteNonQuery();
                    }

                    Rentprint();
                    MessageBox.Show("تم حجز الرحلة بنجاح");
                    ClearFields();
                    GetRentals();
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
        private void ClearFields()
        {
            paymentMethod.SelectedIndex = 0;
            HiddenFild();
            cmbSeaTransportID.SelectedValue = -1;
            cmbDuration.SelectedValue = -1;
            cmbTypeID.SelectedValue = -1;
            btnSave.Text = "حفظ";
            txtCustMobile.Text = "";
            txtCustName.Text = "";
            txtCustNID.Text = "";
            GetProductNo();
            SeaTransportTypeFill();
            FillDuration();

            Rentaldate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Now;

            txtDiscountPercent.Text = "";
            txtpaycash.Text = "0.00";
            txtpaycard.Text = "0.00";
            lbldisc.Text = "0.00";
            lblPrice.Text = "0.00";
            lblTotal.Text = "0.00";
            lblVAT.Text = "0.00";
            lblTotalAfterVAT.Text = "0.00";
            lblTotalCashAndBank.Text = "0.00";
            Payed.Text = "0.00";
            Remaining.Text = "0.00";
            Note.Clear();
            textBox1.Clear();
        }
        private void Deleterentpay()
        {
            SQLConn.sqL = "Delete  From Tamara WHERE Rentalid=@Rentalid";
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SQLConn.cmd.Parameters.AddWithValue("@Rentalid", idnum);
            SQLConn.cmd.ExecuteNonQuery();


            SQLConn.sqL = "Delete  From Banktransfers  WHERE  Rentalid=@Rentalid";
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SQLConn.cmd.Parameters.AddWithValue("@Rentalid", idnum);
            SQLConn.cmd.ExecuteNonQuery();
        }
        private void btnFrmCustomer_Click(object sender, EventArgs e)
        {
            frmcustomers cust = new frmcustomers(txtCustName.Text, txtCustMobile.Text, txtCustNID.Text);
            cust.ShowDialog();
        }
        public DataTable GetCustomerByMobile(string Mobile)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select ID,Name,Mobile,NID from Customers Where Mobile = '" + Mobile + "'";
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
        private bool IsExitingClientByMobile()
        {
            //if (string.IsNullOrEmpty(txtCustMobile.Text) || ( !string.IsNullOrEmpty(txtCustMobile.Text) && (txtCustMobile.Text.Length < 10 || txtCustMobile.Text.Length > 10)))
            //{
            //    Interaction.MsgBox("الرجاء التثبت من رقم الجوال");
            //    return false;
            //}

            if (!string.IsNullOrEmpty(txtCustMobile.Text))
            {
                DataTable dtblCust = GetCustomerByMobile(txtCustMobile.Text);
                if (dtblCust.Rows.Count > 0)
                {
                    txtCustName.Text = dtblCust.Rows[0]["Name"].ToString();
                    txtCustMobile.Text = dtblCust.Rows[0]["Mobile"].ToString();
                    lblCustIDHidden.Text = dtblCust.Rows[0]["ID"].ToString();
                    txtCustNID.Text = dtblCust.Rows[0]["NID"].ToString();

                    txtCustNID.Focus();
                    return true;
                }
            }
            return false;
        }
        private void txtCustMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (!IsExitingClientByMobile())
                    txtCustNID.Focus();
            }
        }
        public void SeaTransportTypeFill()
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
                cmbTypeID.DataSource = dtbl;
                cmbTypeID.ValueMember = "ID";
                cmbTypeID.DisplayMember = "Name";
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
        public void FillSeaTransportFill(int TypeID)
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"SELECT 
                                        ID,
                                        Name,
                                        TypeID 
                                        FROM SeaTransport 
                                        Where TypeID = "+ cmbTypeID.SelectedValue +" " +
                                        @"And InService = 1
                                        and ID not IN(SELECT      
                                        SeaTransport.ID
                                        FROM         
                                        Rental 
                                        Inner JOIN SeaTransport 
                                        ON Rental.Searentid = SeaTransport.ID
                                        WHERE (IsBusy = 1) and  
                                        (Startdate = CAST(GETDATE() as DATE)) and
                                        (Starttime > CONVERT(TIME, SYSDATETIME())))
                                        Order by SeaTransportOrder");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbSeaTransportID.DataSource = dtbl;
                cmbSeaTransportID.ValueMember = "ID";
                cmbSeaTransportID.DisplayMember = "Name";
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
        public void FillDuration()
        {
            try
            {
                int id = 0;
                Int32.TryParse(cmbTypeID.SelectedValue.ToString(), out id);
                if (id > 0)
                {
                    SQLConn.ConnDB();
                    DataTable dtbl = new DataTable();
                    dtbl = SQLConn.getTable("SELECT  ID, Duration, DurationValue FROM Price where SeaTransportTypeID= " + id + " ");
                    //DataRow dr = dtbl.NewRow();
                    //dr["Value"] = 0;
                    //dr["Duration"] = "--اختر--";
                    //dtbl.Rows.InsertAt(dr, 0);
                    cmbDuration.DataSource = dtbl;
                    cmbDuration.ValueMember = "ID";
                    cmbDuration.DisplayMember = "Duration";
                    cmbDuration.Text = "30 دقيقة";
                    /*
                     cmbSeaTransportID.ValueMember = "ID";
                    cmbSeaTransportID.DisplayMember = "Name";
                     */
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
        private decimal Cheacdiscavilable()
        {
            SQLConn.sqL = @"SELECT * FROM Users Where ID = " + Data.UserID + " ";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            decimal Discountpercent = 0;
            if (SQLConn.dr.Read())
            {
                var Disc = SQLConn.dr["Discountpercent"].ToString();
                if (!string.IsNullOrEmpty(Disc) && Disc != "0.00")
                {
                    Discountpercent = Convert.ToDecimal(Disc);
                }
            }
            return Discountpercent;
        }
        public void Gvat()
        {

            try
            {
                var Qur = "Select * From SystemSettings";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read() == true)
                {
                    ISVAT = Convert.ToBoolean(SQLConn.dr[1]);
                    VP = Convert.ToDouble(SQLConn.dr[2]) / 100;
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
        private void SelectVATValue()
        {

            try
            {

                SQLConn.sqL = "SELECT VATPercent FROM SystemSettings";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                if (SQLConn.cmd.ExecuteScalar() != null)
                {
                    Decimal.TryParse(SQLConn.cmd.ExecuteScalar().ToString(), out VatPercent);
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
        private void Newrent_Load(object sender, EventArgs e)
        {
            var CDV = Cheacdiscavilable();
            if (CDV == 0)
            {
                txtDiscountPercent.Enabled = false;
            }
            else
            {
                txtDiscountPercent.Enabled = true;
            }
            Gvat();
            lblCustIDHidden.Text = string.Empty;
            SelectVATValue();


            GetRentals();
            GetProductNo();
            SeaTransportTypeFill();
            FillDuration();
            dtpStartDate.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Now;
        }
        private void Getcustomer(string custname)
        {
            var Qur = @"Select * From Customers Where Name = '"+ custname +"'";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            if (SQLConn.dr.Read())
            {
                lblCustIDHidden.Text = SQLConn.dr["ID"].ToString();
                txtCustMobile.Text = SQLConn.dr["Mobile"].ToString();
                txtCustNID.Text = SQLConn.dr["NID"].ToString();
                txtCustName.Text = SQLConn.dr["Name"].ToString();
            }
        }
        private void GetRentals()
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
                        Rental.Rentstatus,
                        Treasury.Name As 'Cashiername',
                        Rental.RTId,
                        Rental.Note As 'Notetext',
                        Rental.Paymethode
                        From Rental
                        Left Outer Join SeaTransportType
                        On Rental.Seatypeid = SeaTransportType.ID
                        Left Outer Join SeaTransport
                        On Rental.Searentid = SeaTransport.ID
                        Inner Join Customers
                        On Rental.Customerid = Customers.ID
                        Inner Join Treasury
						On Rental.Treasuryid = Treasury.UserID
                        where Rentdate BETWEEN GETDATE()-7 AND GETDATE()";

            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        private void GetRentalid(string req)
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
                        Rental.Rentstatus,
                        Treasury.Name As 'Cashiername',
                        Rental.RTId,
                        Rental.Note As 'Notetext',
                        Rental.Paymethode
                        From Rental
                        Left Outer Join SeaTransportType
                        On Rental.Seatypeid = SeaTransportType.ID
                        Left Outer Join SeaTransport
                        On Rental.Searentid = SeaTransport.ID
                        Inner Join Customers
                        On Rental.Customerid = Customers.ID
                        Inner Join Treasury
						On Rental.Treasuryid = Treasury.UserID
                        Where Rental.ID = " + Convert.ToInt32(req);

            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        private decimal GetPrice(int PriceGroupID, bool IsDifferentPricing, string duration)
        {

            decimal price = 0.0m;
            try
            {
                if (IsDifferentPricing == true)
                {
                    SQLConn.sqL = "SELECT Price FROM PriceChanging Where SeaTransportTypeID = " + PriceGroupID + " and Duration = @Duration ";
                }
                else
                {
                    SQLConn.sqL = "SELECT Price FROM Price Where SeaTransportTypeID = " + PriceGroupID + " and Duration = @Duration ";
                }

                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Duration", duration);
                if (SQLConn.cmd.ExecuteScalar() != null)
                {
                    price = 0;
                    Decimal.TryParse(SQLConn.cmd.ExecuteScalar().ToString(), out price);
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
            return price;
        }
        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Duration = "0";
            if (cmbTypeID.SelectedItem != null)
            {
                var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();

                if (int.Parse(SelectedValue) > 0)
                {
                    FillSeaTransportFill(int.Parse(SelectedValue));

                    FillDuration();

                    Duration = cmbDuration.Text; // 

                    if (Duration != null)
                    {
                        var price = GetPrice(int.Parse(SelectedValue), false, Duration);
                        lblPrice.Text = price.ToString();
                    }
                }
            }
            SetTotal();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearFields();
            //txtDiscountPercent.Visible = false;
            //lbldiscpercent.Visible = true;
            try
            {
                if (e.RowIndex != -1)
                {
                    var Rentid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                    var Ticket = dataGridView1.CurrentRow.Cells["Ticketid"].Value.ToString();
                    if (Ticket != "")
                    {
                        var Ticketid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Ticketid"].Value);
                    }
                    var Rentdate = dataGridView1.CurrentRow.Cells["Rentdate"].Value.ToString();
                    var Startdate = dataGridView1.CurrentRow.Cells["Startdate"].Value.ToString();
                    var Starttime = dataGridView1.CurrentRow.Cells["Starttime"].Value.ToString();
                    var Seatransporttypename = dataGridView1.CurrentRow.Cells["Seatransporttypename"].Value.ToString();
                    var Seatransportname = dataGridView1.CurrentRow.Cells["Seatransportname"].Value.ToString();
                    var Customername = dataGridView1.CurrentRow.Cells["Customername"].Value.ToString();
                    var Duration = dataGridView1.CurrentRow.Cells["Dauration"].Value.ToString();
                    var Rentstatus = dataGridView1.CurrentRow.Cells["Rentstatus"].Value.ToString();
                    var RTId = dataGridView1.CurrentRow.Cells["RTId"].Value.ToString();
                    var Notetext = dataGridView1.CurrentRow.Cells["Notetext"].Value.ToString();
                    var Paymethode = dataGridView1.CurrentRow.Cells["Paymethode"].Value.ToString();
                    paymentMethod.Text = Paymethode;
                    var Case = paymentMethod.Text;
                    Cheackpayment();
                    if (RTId != "" && RTId != "0")
                    {
                        Gettransaction(Convert.ToInt32(RTId));
                        idtnum = Convert.ToInt32(RTId);
                    }
                    else
                    {
                        Lastdp = "0.00";
                    }
                    idnum = Rentid;
                    Getcustomer(Customername);
                    Rentaldate.Value = Convert.ToDateTime(Rentdate);
                    dtpStartDate.Value = Convert.ToDateTime(Startdate);
                    dtpStartTime.Value = Convert.ToDateTime(Starttime);
                    cmbTypeID.Text = Seatransporttypename;
                    cmbSeaTransportID.Text = Seatransportname;
                    cmbDuration.Text = Duration;
                    Note.Text = Notetext;
                    btnSave.Text = "تحديث";
                    btnDelete.Enabled = true;
                    var LU = Lastdp;
                    if (LU == null)
                    {
                        txtDiscountPercent.Text = "";
                    }
                    else
                    {
                        txtDiscountPercent.Text = Lastdp.ToString();
                    }
                    GetTotalPay();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Gettransaction(int Transid)
        {
            var Qur = @"Select 
                        Price,
                        DiscountAmount,
                        DiscountPercent,
                        PriceAfterDiscount,
                        VAT,
                        PriceAfterVAT,
                        PayCash,
                        PayCard,
                        Paytransfer,
                        Paytamara
                        From Rentaltransactions Where ID = '" + Transid + "'";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            if (SQLConn.dr.Read())
            {
                var Paye = Convert.ToDecimal(SQLConn.dr["PayCash"].ToString()) + Convert.ToDecimal(SQLConn.dr["PayCard"].ToString());
                var Remain = Convert.ToDecimal(SQLConn.dr["PriceAfterVAT"].ToString()) - Paye;
                var DP = Convert.ToDecimal(SQLConn.dr["DiscountPercent"].ToString()) * 100;
                var CDP = Convert.ToInt32(DP);
                var PayCash = SQLConn.dr["PayCash"].ToString();
                var PayCard = SQLConn.dr["PayCard"].ToString();
                var DiscountAmount = SQLConn.dr["DiscountAmount"].ToString();
                var Price = SQLConn.dr["Price"].ToString();
                var PriceAfterDiscount = SQLConn.dr["PriceAfterDiscount"].ToString();
                var VAT = SQLConn.dr["VAT"].ToString();
                var PriceAfterVAT = SQLConn.dr["PriceAfterVAT"].ToString();
                var Paytamara = SQLConn.dr["Paytamara"].ToString();
                var Paytransfer = SQLConn.dr["Paytransfer"].ToString();

                // lbldiscpercent.Text = CDP.ToString();
                txtpaycash.Text = PayCash;
                txtpaycard.Text = PayCard;
                tamarapay.Text = Paytamara;
                transpay.Text = Paytransfer;
                lbldisc.Text = DiscountAmount;
                lblPrice.Text = Price;
                lblTotal.Text = PriceAfterDiscount;
                lblVAT.Text = VAT;
                lblTotalAfterVAT.Text = PriceAfterVAT;
                lblTotalCashAndBank.Text = PriceAfterVAT;
                Payed.Text = Paye.ToString();
                Remaining.Text = Remain.ToString();
                Lastcash = PayCash;
                Lastcard = PayCard;
                Lastdp = CDP.ToString();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا الحجز", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SQLConn.sqL = "Select ID,RTId From Rental WHERE ID = " + idnum + "";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();
                    if (SQLConn.dr.Read())
                    {
                        var id = SQLConn.dr["ID"].ToString();
                        var RTId = SQLConn.dr["RTId"].ToString();
                        idnum = Convert.ToInt32(id);
                        if (!string.IsNullOrEmpty(RTId))
                        {
                            idtnum = Convert.ToInt32(RTId);
                            DeleteTransaction();
                        }
                    }
                    SQLConn.sqL = "Delete From Rental WHERE ID = " + idnum + "";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);                  
                    SQLConn.cmd.ExecuteNonQuery();
                    //Update Treasury Balance For Current User 
                    SQLConn.ConnDB();
                    decimal cash = decimal.Parse(txtpaycash.Text);
                    decimal card = decimal.Parse(txtpaycard.Text);
                    int bankId = SQLConn.GetBankAccountID();
                    if (cash.ToString() != "0.00")
                    {
                        //update TreasuryTransactions
                        SQLConn.GetTreasuryIDForCurrentUser(Data.UserID);
                        if (Data.UserTreasuryID > 0)
                        {
                            if (cash > 0)
                            {
                                try
                                {
                                    SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID,TicketID, Libelle, Date) 
                                                        values(@NewBalance, @treasuryID, @TicketID, @Libelle,@Date )";

                                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", -Convert.ToDecimal(Lastcash));
                                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", Data.UserTreasuryID);
                                    SQLConn.cmd.Parameters.AddWithValue("@TicketID", DBNull.Value);
                                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", "الغاء حجز - سحب المبلغ النقدي القديم");
                                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                                    SQLConn.cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    Interaction.MsgBox(ex.ToString());
                                }
                                try
                                {
                                    SQLConn.sqL = "Update Treasury Set Balance = Balance +  @NewBalance where ID = @treasuryID";
                                    //SQLConn.ConnDB();
                                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", -Convert.ToDecimal(Lastcash));
                                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", Data.UserTreasuryID);
                                    SQLConn.cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    Interaction.MsgBox(ex.ToString());
                                }
                            }
                        }
                    }
                    //Update Bank Account Balance
                    if (card.ToString() != "0.00")
                    {

                        if (bankId > 0)
                        {
                            if (card > 0)
                            {
                                try
                                {
                                    SQLConn.sqL = @"insert into BankAccountTransactions (Amount, BankID, TicketID, Libelle,Date)  
                                            values( @NewBalance, @BankID ,@TicketID, @Libelle,@Date)";

                                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", -Convert.ToDecimal(Lastcard));
                                    SQLConn.cmd.Parameters.AddWithValue("@BankID", bankId);
                                    SQLConn.cmd.Parameters.AddWithValue("@TicketID", DBNull.Value);
                                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", "الغاء حجز - سحب المبلغ البنكي القديم");
                                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                                    SQLConn.cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    Interaction.MsgBox(ex.ToString());
                                }
                                try
                                {
                                    SQLConn.sqL = "Update BankAccounts Set Balance = Balance +  @NewBalance where ID =" + bankId;

                                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", -Convert.ToDecimal(Lastcard));
                                    SQLConn.cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    Interaction.MsgBox(ex.ToString());
                                }
                            }
                        }
                    }
                    SQLConn.sqL = "Delete  From Banktransfers  WHERE  Rentalid=@Rentalid";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                    SQLConn.cmd.Parameters.AddWithValue("@Rentalid", idnum);
                    SQLConn.cmd.ExecuteNonQuery();


                    SQLConn.sqL = "Delete  From Tamara  WHERE  Rentalid=@Rentalid";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                    SQLConn.cmd.Parameters.AddWithValue("@Rentalid", idnum);
                    SQLConn.cmd.ExecuteNonQuery();
                    ClearFields();
                    GetRentals();
                    MessageBox.Show("تم حذف الحجز");
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
                return;
            }
        }
        private void btnticket_Click(object sender, EventArgs e)
        {
            try
            {
                SQLConn.sqL = "Select Ticketid From Rental Where ID = @ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@ID", idnum);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read())
                {
                    var reder = SQLConn.dr["Ticketid"].ToString();
                    if (reder == "")
                    {
                        frmticket frmticket = new frmticket();
                        frmticket.Rentalid = idnum;
                        frmticket.lblCustIDHidden.Text = lblCustIDHidden.Text;
                        frmticket.txtCustMobile.Text = txtCustMobile.Text;
                        frmticket.txtCustNID.Text = txtCustNID.Text;
                        frmticket.txtCustName.Text = txtCustName.Text;
                        frmticket.DTS = dtpStartDate.Value;
                        frmticket.DST = dtpStartTime.Value;
                        frmticket.STT = cmbTypeID.Text;
                        frmticket.STS = cmbSeaTransportID.Text;
                        frmticket.DRV = cmbDuration.Text;
                        frmticket.TDP = txtDiscountPercent.Text;
                        frmticket.Payed = Convert.ToDecimal(Payed.Text);
                        frmticket.Cash = Convert.ToDecimal(txtpaycash.Text);
                        frmticket.Card = Convert.ToDecimal(txtpaycard.Text);
                        frmticket.lblrent.Text = idnum.ToString();
                        frmticket.paymentMethod.Text = paymentMethod.Text;
                        frmticket.tamarapay.Text = tamarapay.Text;
                        frmticket.transpay.Text = transpay.Text;
                        frmticket.txtpaycard.Text = txtpaycard.Text;
                        frmticket.txtpaycash.Text = txtpaycash.Text;
                        frmticket.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("لا يمكن انشاء تذكرة لهذه الرحلة");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                GetRentals();
            }
            else
            {
                GetRentalid(textBox1.Text);
            }
        }
        private void cmbDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeID.SelectedItem != null)
            {
                var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();

                if (int.Parse(SelectedValue) > 0)
                {
                    GetPrice();
                }
            }
        }
        private void GetPrice()
        {
            //Get Price from SeaTransport PriceGroup
            txtDiscountPercent.Text = "";
            if (cmbDuration.Text != null)
            {
                var SelectedValue = cmbDuration.Text;
                if (SelectedValue != "")
                {
                    bool IsDifferentPricing = false;
                    int PriceGroupID = (int)cmbTypeID.SelectedValue;
                    string Duration = cmbDuration.Text;
                    decimal Price = GetPrice(PriceGroupID, IsDifferentPricing, Duration);
                    lblPrice.Text = Price.ToString();
                    PriceBeforeDiscount = Price;
                }
            }
            SetTotal();
        }
        private void SetTotal()
        {
            totalBeforeVAT = PriceBeforeDiscount;
            decimal VatValue = (totalBeforeVAT * VatPercent) / 100;
            decimal totalAfterVAT = totalBeforeVAT + VatValue;
            lblTotal.Text = Math.Round(totalBeforeVAT, 2).ToString();
            lblVAT.Text = Math.Round(VatValue, 2).ToString();
            lblTotalAfterVAT.Text = Math.Round(totalAfterVAT, 2).ToString();
            lblTotalCashAndBank.Text = lblTotalAfterVAT.Text;


            decimal CashValue = 0;
            Decimal.TryParse(txtpaycash.Text, out CashValue);

            decimal CardValue = 0;
            Decimal.TryParse(txtpaycard.Text, out CardValue);

            decimal BalanceValue = CashValue + CardValue;

            Payed.Text = BalanceValue.ToString();

            decimal TotalValue = 0;
            Decimal.TryParse(Payed.Text, out TotalValue);

            decimal TotalCashAndBank = 0;
            Decimal.TryParse(lblTotalCashAndBank.Text, out TotalCashAndBank);


            decimal RemainValue = 0;
            Decimal.TryParse(Remaining.Text, out RemainValue);
            RemainValue = TotalCashAndBank - TotalValue;
            Remaining.Text = RemainValue.ToString();
        }
        private void txtDiscountPercent_TextChanged(object sender, EventArgs e) 
        {
            if (!string.IsNullOrEmpty(txtDiscountPercent.Text))
            {
                var CDV = Cheacdiscavilable();
                decimal Dicper = 0;
                if (!string.IsNullOrEmpty(txtDiscountPercent.Text))
                {
                    Dicper = Convert.ToDecimal(txtDiscountPercent.Text);
                    if (Dicper > CDV)
                    {
                        MessageBox.Show("غير مسموح لك بأضافة اكثر من " + CDV + "");
                        txtDiscountPercent.Clear();
                    }
                    else
                    {
                        if (PriceBeforeDiscount == 0)
                        {
                            Decimal.TryParse(lblPrice.Text, out PriceBeforeDiscount);
                        }
                        decimal DiscountPercent = Common.ConvertTxtToDecimal(txtDiscountPercent.Text.ToString() != "" ? txtDiscountPercent.Text.ToString() : "0");

                        decimal DiscountValue = (PriceBeforeDiscount * DiscountPercent) / 100;
                        //lbldisc.Text = DiscountValue.ToString();
                        lbldisc.Text = Math.Round(DiscountValue, 2).ToString();
                        decimal PriceAfterDiscount = PriceBeforeDiscount - DiscountValue;
                        lblTotal.Text = PriceAfterDiscount.ToString();
                        var CLT = Convert.ToDecimal(lblTotal.Text);
                        totalBeforeVAT = Math.Round(CLT, 2);
                        decimal VatValue = (totalBeforeVAT * VatPercent) / 100;
                        decimal totalAfterVAT = totalBeforeVAT + VatValue;
                        lblTotal.Text = Math.Round(totalBeforeVAT, 2).ToString();
                        lblVAT.Text = Math.Round(VatValue, 2).ToString();
                        lblTotalAfterVAT.Text = Math.Round(totalAfterVAT, 2).ToString();
                        lblTotalCashAndBank.Text = lblTotalAfterVAT.Text;


                        decimal CashValue = 0;
                        Decimal.TryParse(txtpaycash.Text, out CashValue);

                        decimal CardValue = 0;
                        Decimal.TryParse(txtpaycard.Text, out CardValue);

                        decimal BalanceValue = CashValue + CardValue;

                        Payed.Text = BalanceValue.ToString();

                        decimal TotalValue = 0;
                        Decimal.TryParse(Payed.Text, out TotalValue);

                        decimal TotalCashAndBank = 0;
                        Decimal.TryParse(lblTotalCashAndBank.Text, out TotalCashAndBank);


                        decimal RemainValue = 0;
                        Decimal.TryParse(Remaining.Text, out RemainValue);
                        RemainValue = TotalCashAndBank - TotalValue;
                        Remaining.Text = RemainValue.ToString();
                    }
                }
            }
            else
            {
                txtDiscountPercent.Text = "0.00";
                SetTotal();
            }
        }
        public void GetTotalPay()
        {
            decimal CashValue = 0;
            Decimal.TryParse(txtpaycash.Text, out CashValue);
            decimal BankValue = 0;
            Decimal.TryParse(txtpaycard.Text, out BankValue);
            decimal TamaraValue = 0;
            Decimal.TryParse(tamarapay.Text, out TamaraValue);
            decimal TransValue = 0;
            Decimal.TryParse(transpay.Text, out TransValue);
            decimal totalPay = CashValue + BankValue + TamaraValue + TransValue;
            Payed.Text = totalPay.ToString();

            decimal PayedValue = 0;
            Decimal.TryParse(Payed.Text, out PayedValue);

            decimal TotalValue = 0;
            Decimal.TryParse(lblTotalCashAndBank.Text, out TotalValue);


            decimal RemainValue = 0;
            Decimal.TryParse(Remaining.Text, out RemainValue);
            RemainValue = TotalValue - PayedValue;
            Remaining.Text = RemainValue.ToString();
        }
        private void txtpaycash_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpaycash.Text))
            {
                GetTotalPay();
            }
            else
            {
                txtpaycash.Text = "0.00";
            }
        }
        private void txtpaycard_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpaycard.Text))
            {
                GetTotalPay();
            }
            else
            {
                txtpaycard.Text = "0.00";
            }
        }
        private void txtDiscountPercent_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void HiddenFild()
        {
            label17.Visible = false;
            label16.Visible = false;
            label29.Visible = false;
            label31.Visible = false;
            label32.Visible = false;
            txtpaycard.Visible = false;
            txtpaycard.Text = "0.00";
            transpay.Visible = false;
            transpay.Text = "0.00";
            txtpaycash.Visible = false;
            txtpaycash.Text = "0.00";
            tamarapay.Visible = false;
            tamarapay.Text = "0.00";
            textBox5.Visible = false;
            textBox5.Text = "";
            lblTotalCashAndBank.Text = "0.00";
        }
        public void Cheackpayment()
        {
            var Case = paymentMethod.Text;
            switch (Case)
            {
                case "نقدي":
                    HiddenFild();
                    txtpaycard.Text = "0.00";
                    txtpaycash.Visible = true;
                    label17.Visible = true;
                    break;
                case "بنكي":
                    HiddenFild();
                    txtpaycard.Visible = true;
                    label16.Visible = true;
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
                    lblTotalCashAndBank.Text = lblTotalAfterVAT.Text;
                    label32.Visible = true;
                    textBox5.Visible = true;
                    break;
                case "نقدي وبنكي":
                    HiddenFild();
                    label16.Visible = true;
                    label17.Visible = true;
                    txtpaycard.Visible = true;
                    txtpaycash.Visible = true;
                    break;
                case "نقدي وتحويل":
                    HiddenFild();
                    txtpaycash.Text = "0.00";
                    txtpaycash.Visible = true;
                    label17.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    transpay.Text = "0.00";
                    break;
                case "تمارا ونقدي":
                    HiddenFild();
                    txtpaycash.Visible = true;
                    label17.Visible = true;
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    lblTotalCashAndBank.Text = lblTotalAfterVAT.Text;
                    label32.Visible = true;
                    textBox5.Visible = true;
                    break;
                case "بنكي وتحويل":
                    HiddenFild();
                    txtpaycard.Text = "0.00";
                    txtpaycard.Visible = true;
                    label16.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    transpay.Text = "0.00";
                    break;
                case "تمارا وبنكي":
                    HiddenFild();
                    txtpaycard.Visible = true;
                    label16.Visible = true;
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    lblTotalCashAndBank.Text = lblTotalAfterVAT.Text;
                    label32.Visible = true;
                    textBox5.Visible = true;
                    break;
                case "نقدي وبنكي وتحويل":
                    HiddenFild();
                    label9.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    txtpaycard.Visible = true;
                    txtpaycash.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    break;
                case "تمارا وتحويل":
                    HiddenFild();
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    lblTotalCashAndBank.Text = lblTotalAfterVAT.Text;
                    label32.Visible = true;
                    textBox5.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    break;
                case "تمارا ونقدي وبنكي":
                    HiddenFild();
                    txtpaycash.Visible = true;
                    txtpaycard.Visible = true;
                    label15.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    label9.Visible = true;
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    lblTotalCashAndBank.Text = lblTotalAfterVAT.Text;
                    label32.Visible = true;
                    textBox5.Visible = true;
                    break;
                case "تمارا ونقدي وبنكي وتحويل":
                    HiddenFild();
                    txtpaycash.Visible = true;
                    txtpaycard.Visible = true;
                    label15.Visible = true;
                    label9.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    lblTotalCashAndBank.Text = lblTotalAfterVAT.Text;
                    label32.Visible = true;
                    textBox5.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    break;
                case "--اختر--":
                    HiddenFild();
                    break;
            }
        }
        private void paymentMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cheackpayment();
        }

        private void tamarapay_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tamarapay.Text))
            {
                GetTotalPay();
            }
            else
            {
                tamarapay.Text = "0.00";
            }
        }

        private void transpay_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(transpay.Text))
            {
                GetTotalPay();
            }
            else
            {
                transpay.Text = "0.00";
            }
        }

        private void paymentMethod_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void paymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
