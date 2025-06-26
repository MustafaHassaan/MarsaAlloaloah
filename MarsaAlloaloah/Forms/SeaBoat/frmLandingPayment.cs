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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace MarsaAlloaloah
{
    public partial class frmLandingPayment : Form
    {
        public int id;

        public int SelectedLandingPaymentID;
        public decimal PayCash = 0;
        public decimal PayCard = 0;
        public int SelectedBankID = -1;
        public frmLandingPayment()
        {
            InitializeComponent();
        }

        private void frmLandingPayment_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            SeaTransportTypeFill();
            GridFill();
            GetBankAccountList();
            lblBankAccount.Visible = false;
            cmbBankAccount.Visible = false;
            //
            btnPrint.Enabled = false; 
            dtpPaymentDoneToDate.Value = dtpContractStartDate.Value;

        }

        private decimal dailyAmount = 0;
        private DateTime contractStartDate = DateTime.Now.Date;
        private int landingID = 0;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "حفظ")
            {
                AddLanding();
                /**/

                GridFill();
            }
            else
            {
                // if (SelectedLandingPaymentID > 0)
                //     Updatelanding(SelectedLandingPaymentID);

                //GridFill();
            }
            #region old code
            //string selectedSearch = string.Empty;

            //if (int.Parse(cmbTypeID.SelectedValue.ToString()) == 0)
            //{
            //    Interaction.MsgBox("من فضلك إختر نوع الواسطة البحرية");
            //    return;
            //}
            //if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
            //{
            //    Interaction.MsgBox("من فضلك إختر الواسطة البحرية");
            //    return;
            //}
            //decimal payCash = 0, payCard = 0;
            //if (!string.IsNullOrEmpty(txtpaycash.Text))
            //{
            //    Decimal.TryParse(txtpaycash.Text, out payCash);
            //}

            //if (!string.IsNullOrEmpty(txtpaycard.Text))
            //{
            //    Decimal.TryParse(txtpaycard.Text, out payCard);

            //    if (payCard > 0 && int.Parse(cmbBankAccount.SelectedValue.ToString()) == 0)
            //    {
            //        Interaction.MsgBox("من فضلك إختر الحساب البنكى");
            //        return;
            //    }
            //}

            //// Get all sum of amount payed before
            //decimal sumPayedBefore = 0;
            //sumPayedBefore = GetTotalPayedBefore(landingID); 

            //// TODO : do the same when deleting a line in this table
            //decimal totalPayed = Decimal.Parse(lblTotalCashAndBank.Text) + sumPayedBefore;

            //if (dailyAmount > 0 && totalPayed > 0)
            //{
            //    int nbDaysPayed = Convert.ToInt32(totalPayed / dailyAmount);
            //    if (DateTime.TryParse(dtpContractStartDate.Text, out contractStartDate))
            //    {
            //        dtpPaymentDoneToDate.Value = contractStartDate.AddDays(nbDaysPayed);
            //    }
            //}

            ////Insert into LandingPaymentTransaction
            //int newID = 0;
            //SQLConn.sqL = @"INSERT into LandingPaymentTransaction (PayCash, PayCard, Date, LandingID) 
            //                VALUES (@PayCash, @PayCard, @Date, @LandingID); 
            //                SELECT CAST(scope_identity() AS int)";
            //SQLConn.ConnDB();
            ////Create Transaction            
            //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            //SQLConn.cmd.Parameters.AddWithValue("@PayCash", Common.ConvertTxtToDecimal(txtpaycash.Text));
            //SQLConn.cmd.Parameters.AddWithValue("@PayCard", Common.ConvertTxtToDecimal(txtpaycard.Text));
            //SQLConn.cmd.Parameters.Add("@LandingID", SqlDbType.Int).Value = landingID;
            //SQLConn.cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now.Date;
            //newID = (int)SQLConn.cmd.ExecuteScalar();

            //// Update dtpPaymentDoneToDate
            //SQLConn.sqL = @"Update Landing set PaymentDoneToDate=@PaymentDoneToDate where ID =" + landingID;
            //SQLConn.ConnDB();
            ////Create Transaction            
            //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);

            //SQLConn.cmd.Parameters.Add("@PaymentDoneToDate", SqlDbType.DateTime).Value = dtpPaymentDoneToDate.Value;
            //SQLConn.cmd.ExecuteScalar();

            ////TODO : Update treasury and bank account
            ////Update Treasury Balance For Current User 
            //if (txtpaycash.Text != "")
            //{
            //    SQLConn.UpdatePrincipalTreasuryTransactions(payCash, SQLConn.trans);
            //    //newID, "إظافة دفعة إرساء ");
            //    SQLConn.UpdatePrincipalTreasuryBalance(payCash, SQLConn.trans);
            //}
            ////Update Bank Account Balance
            //if (txtpaycard.Text != "")
            //{
            //    int bankId = int.Parse(cmbBankAccount.SelectedValue.ToString());

            //    if (bankId > 0)
            //    {
            //        SQLConn.UpdateBankAccountTransactions(bankId, payCard, SQLConn.trans);
            //        SQLConn.UpdateBankAccountByID(bankId, payCard, SQLConn.trans);
            //    }
            //}

            //GridFill();
            #endregion
        }

        private void PrintLandingPaymentReport(int id)
        {
            if (id > 0)
            {
                frmReportPrint frmReportPrint = new frmReportPrint(id, lblTotalCashAndBank.Text, "LandingPaymentPart");
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                _ = frmReportPrint.ShowDialog();
            }
        }

        private void Updatelanding(int id)
        {
            string selectedSearch = string.Empty;

            if (int.Parse(cmbTypeID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر نوع الواسطة البحرية");
                return;
            }
            if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الواسطة البحرية");
                return;
            }
            decimal payCash = 0, payCard = 0, oldAmountCash = 0, oldAmountCard = 0;
            if (!string.IsNullOrEmpty(txtpaycash.Text))
            {
                Decimal.TryParse(txtpaycash.Text, out payCash);
            }

            if (dgvdata.SelectedRows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dgvdata.CurrentRow.Cells["cash"].Value.ToString()))
                {
                    Decimal.TryParse(dgvdata.CurrentRow.Cells["cash"].Value.ToString(), out oldAmountCash);
                }

                if (!string.IsNullOrEmpty(dgvdata.CurrentRow.Cells["card"].Value.ToString()))
                {
                    Decimal.TryParse(dgvdata.CurrentRow.Cells["card"].Value.ToString(), out oldAmountCard);
                }
            }

            if (!string.IsNullOrEmpty(txtpaycard.Text))
            {
                Decimal.TryParse(txtpaycard.Text, out payCard);

                if (payCard > 0 && int.Parse(cmbBankAccount.SelectedValue.ToString()) == 0)
                {
                    Interaction.MsgBox("من فضلك إختر الحساب البنكى");
                    return;
                }
            }
            if ((dtpContractEndDate.Value - dtpContractStartDate.Value).Days <= 0)
            {
                Interaction.MsgBox("تاريخ بداية الإرساء لا يمكن ان يكون أكبر أو يساوي تاريخ نهاية الإرساء  ");
                return;
            }
            dailyAmount = GetDailyAmoutPayment();

            // Calculate the date that correspond to this payment
            DateTime startDate = dtpPaymentDoneToDate.Value;
            DateTime nextDate = startDate;
            decimal sum = payCash + payCard;
            int nbNewDays = Convert.ToInt32(sum / dailyAmount);
            if (DateTime.TryParse(dtpContractStartDate.Text, out contractStartDate))
            {
                nextDate = startDate.AddDays(nbNewDays);
            }

            GetPaymentDoneToDate();

            //Insert into LandingPaymentTransaction

            SQLConn.sqL = @"update   LandingPaymentTransaction set PayCash=@PayCash, 
                                     PayCard=@PayCard, Date=@Date, LandingID =@LandingID, 
                                     PaymentDoneToDate =@PaymentDoneToDate,
                                     PaymentTransactionStartDate =@PaymentTransactionStartDate
                            where ID=@id";
            SQLConn.ConnDB();

            //Create Transaction

            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SQLConn.cmd.Parameters.AddWithValue("@PayCash", Common.ConvertTxtToDecimal(txtpaycash.Text));
            SQLConn.cmd.Parameters.AddWithValue("@PayCard", Common.ConvertTxtToDecimal(txtpaycard.Text));
            SQLConn.cmd.Parameters.Add("@LandingID", SqlDbType.Int).Value = landingID;
            SQLConn.cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dtpDate.Value;

            SQLConn.cmd.Parameters.Add("@PaymentDoneToDate", SqlDbType.DateTime).Value = startDate;
            SQLConn.cmd.Parameters.Add("@PaymentTransactionStartDate", SqlDbType.DateTime).Value = nextDate;

            SQLConn.cmd.Parameters.AddWithValue("@id", id);
            SQLConn.cmd.ExecuteScalar();

            SQLConn.sqL = @"Update Landing set PaymentDoneToDate=@PaymentDoneToDate , EndDate =@EndDate where ID =" + landingID;
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SQLConn.cmd.Parameters.Add("@PaymentDoneToDate", SqlDbType.DateTime).Value = dtpPaymentDoneToDate.Value.ToString("yyyy-MM-dd");
            SQLConn.cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dtpContractEndDate.Value;
            SQLConn.cmd.ExecuteScalar();

            //TODO : Update treasury and bank account            
            if (txtpaycash.Text != "")
            {
                SQLConn.UpdatePrincipalTreasuryLandingTransactions(-oldAmountCash, SQLConn.trans, id, "تحديث دفعة إرساء");
                SQLConn.UpdatePrincipalTreasuryBalance(-oldAmountCash, SQLConn.trans);
                SQLConn.UpdatePrincipalTreasuryLandingTransactions(payCash, SQLConn.trans, id, "تحديث دفعة إرساء");
                SQLConn.UpdatePrincipalTreasuryBalance(payCash, SQLConn.trans);
            }
            //Update Bank Account Balance
            if (txtpaycard.Text != "")
            {
                UpdateBankAccountWhenEditing(id, payCard, oldAmountCard);
            }


            Interaction.MsgBox("تم التحديث  بنجاح ", MsgBoxStyle.Information, " التحديث ");
            Clear();
            btnSave.Text = "حفظ";
        }

        private void GetPaymentDoneToDate()
        {
            // Get all sum of amount payed before
            decimal sumPayedBefore = 0;
            sumPayedBefore = GetTotalPayedBefore(landingID, SelectedLandingPaymentID);

            // TODO : do the same when deleting a line in this table
            decimal totalPayed = Decimal.Parse(lblTotalCashAndBank.Text) + sumPayedBefore;

            if (dailyAmount > 0 && totalPayed > 0)
            {
                int nbDaysPayed = Convert.ToInt32(totalPayed / dailyAmount);
                if (DateTime.TryParse(dtpContractStartDate.Text, out contractStartDate))
                {
                    dtpPaymentDoneToDate.Value = contractStartDate.AddDays(nbDaysPayed);
                }
            }
        }

        private void GetPaymentDoneToDateWhenDeletingTransaction()
        {
            // Get all sum of amount payed before
            decimal sumPayedBefore = 0;
            sumPayedBefore = GetTotalPayedBefore(landingID, SelectedLandingPaymentID);

            // TODO : do the same when deleting a line in this table
            decimal totalPayed = sumPayedBefore;

            if (dailyAmount > 0 && totalPayed >= 0)
            {
                int nbDaysPayed = Convert.ToInt32(totalPayed / dailyAmount);
                if (DateTime.TryParse(dtpContractStartDate.Text, out contractStartDate))
                {
                    dtpPaymentDoneToDate.Value = contractStartDate.AddDays(nbDaysPayed);
                }
            }
        }

        private void UpdateBankAccountWhenEditing(int id, decimal payCard, decimal oldAmountCard)
        {
            if (cmbBankAccount.SelectedValue != null && !string.IsNullOrEmpty(cmbBankAccount.SelectedValue.ToString()))
            {
                int bankId = int.Parse(cmbBankAccount.SelectedValue.ToString());

                if (bankId > 0)
                {
                    // Delete old amount  
                    SQLConn.UpdateBankAccountLandingPaymentTransactions(bankId, -oldAmountCard, id, "تحديث دفعة إرساء - سحب المبلغ النقدي القديم", SQLConn.trans);
                    SQLConn.UpdateBankAccountByID(bankId, -oldAmountCard, SQLConn.trans);
                    // then add new amount
                    SQLConn.UpdateBankAccountLandingPaymentTransactions(bankId, payCard, id, "تحديث دفعة إرساء - إظافة المبلغ النقدي الجديد", SQLConn.trans);
                    SQLConn.UpdateBankAccountByID(bankId, payCard, SQLConn.trans);
                }
            }
        }

        private void AddLanding()
        {
            string selectedSearch = string.Empty;

            if (int.Parse(cmbTypeID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر نوع الواسطة البحرية");
                return;
            }
            if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الواسطة البحرية");
                return;
            }
            decimal payCash = 0, payCard = 0;
            decimal payTrans = 0, payTamara = 0;
            if (!string.IsNullOrEmpty(txtpaycash.Text))
            {
                Decimal.TryParse(txtpaycash.Text, out payCash);
            }
            if (!string.IsNullOrEmpty(txtpaycard.Text))
            {
                Decimal.TryParse(txtpaycard.Text, out payCard);

                if (payCard > 0 && int.Parse(cmbBankAccount.SelectedValue.ToString()) == 0)
                {
                    Interaction.MsgBox("من فضلك إختر الحساب البنكى");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txtpaytamara.Text))
            {
                Decimal.TryParse(txtpaytamara.Text, out payTamara);
            }
            if (!string.IsNullOrEmpty(txtpaytrans.Text))
            {
                Decimal.TryParse(txtpaytrans.Text, out payTrans);
            }
            if ((dtpContractEndDate.Value - dtpContractStartDate.Value).Days <= 0)
            {
                Interaction.MsgBox("تاريخ بداية الإرساء لا يمكن ان يكون أكبر أو يساوي تاريخ نهاية الإرساء  ");
                return;
            }
            dailyAmount = GetDailyAmoutPayment();

            // Calculate the date that correspond to this payment
            var startDate = dtpStartDateTransaction.Value.ToString("yyyy-MM-dd");
            var nextDate = dtpEndDateTransaction.Value.ToString("yyyy-MM-dd");

            // Get all sum of amount payed before
            decimal sumPayedBefore = 0;
            sumPayedBefore = GetTotalPayedBefore(landingID, 0);

            // TODO : do the same when deleting a line in this table
            decimal totalPayed = Decimal.Parse(lblTotalCashAndBank.Text) + sumPayedBefore;

            if (dailyAmount > 0 && totalPayed > 0)
            {
                int nbDaysPayed = Convert.ToInt32(totalPayed / dailyAmount);
                if (DateTime.TryParse(dtpContractStartDate.Text, out contractStartDate))
                {
                    dtpPaymentDoneToDate.Value = contractStartDate.AddDays(nbDaysPayed);
                }
            }
            else
                return;

            //Insert into LandingPaymentTransaction
            SelectedLandingPaymentID = 0;
            SQLConn.sqL = @"INSERT into LandingPaymentTransaction (PayCash, PayCard,Paytranse,Paytamara, Date, LandingID, PaymentDoneToDate, PaymentTransactionStartDate,Userid,Payreftamara) 
                            VALUES (@PayCash, @PayCard,@Paytranse,@Paytamara, @Date, @LandingID, @PaymentDoneToDate, @PaymentTransactionStartDate,@Userid,@Payreftamara); 
                            SELECT CAST(scope_identity() AS int)";
            SQLConn.ConnDB();
            //SQLConn.BeginTransaction();
            //Create Transaction            
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SQLConn.cmd.Parameters.AddWithValue("@PayCash", Common.ConvertTxtToDecimal(txtpaycash.Text));
            SQLConn.cmd.Parameters.AddWithValue("@PayCard", Common.ConvertTxtToDecimal(txtpaycard.Text));
            SQLConn.cmd.Parameters.AddWithValue("@Paytranse", Common.ConvertTxtToDecimal(txtpaytrans.Text));
            SQLConn.cmd.Parameters.AddWithValue("@Paytamara", Common.ConvertTxtToDecimal(txtpaytamara.Text));
            SQLConn.cmd.Parameters.AddWithValue("@Payreftamara", txtref.Text);
            SQLConn.cmd.Parameters.AddWithValue("@Userid", Data.UserID);
            SQLConn.cmd.Parameters.Add("@LandingID", SqlDbType.Int).Value = landingID;
            SQLConn.cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dtpDate.Value.ToString("yyyy-MM-dd");

            SQLConn.cmd.Parameters.Add("@PaymentTransactionStartDate", SqlDbType.DateTime).Value = startDate;
            SQLConn.cmd.Parameters.Add("@PaymentDoneToDate", SqlDbType.DateTime).Value = nextDate;

            SelectedLandingPaymentID = (int)SQLConn.cmd.ExecuteScalar();

            // Update dtpPaymentDoneToDate : conserver tj la dernière date
            SQLConn.sqL = @"Update Landing set PaymentDoneToDate=@PaymentDoneToDate , EndDate =@EndDate where ID =" + landingID;
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SQLConn.cmd.Parameters.Add("@PaymentDoneToDate", SqlDbType.DateTime).Value = nextDate;
            SQLConn.cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dtpContractEndDate.Value.ToString("yyyy-MM-dd");
            SQLConn.cmd.ExecuteScalar();

            // TODO : Update treasury and bank account
            // Update Treasury Balance For Current User 
            if (payCash >= 0)
            {
                SQLConn.UpdatePrincipalTreasuryLandingTransactions(payCash, SQLConn.trans, SelectedLandingPaymentID, "إظافة دفعة إرساء ");
                SQLConn.UpdatePrincipalTreasuryBalance(payCash, SQLConn.trans);
            }
            //Update Bank Account Balance
            if (payCard >= 0)
            {
                if (cmbBankAccount.SelectedValue != null && !string.IsNullOrEmpty(cmbBankAccount.SelectedValue.ToString()))
                {
                    int bankId = int.Parse(cmbBankAccount.SelectedValue.ToString());

                    if (bankId > 0)
                    {
                        SQLConn.UpdateBankAccountLandingPaymentTransactions(bankId, payCard, SelectedLandingPaymentID, "إظافة دفعة إرساء ", SQLConn.trans);
                        SQLConn.UpdateBankAccountByID(bankId, payCard, SQLConn.trans);
                    }
                }
            }
            //Update Banktransfers Account Balance
            if (payTrans >= 0)
            {
                SQLConn.sqL = @"INSERT INTO Banktransfers (Amount,LandingPaymentID)
                                                 Values(@Amount,@LandingPaymentID)";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Amount", txtpaytrans.Text);
                SQLConn.cmd.Parameters.AddWithValue("@LandingPaymentID", SelectedLandingPaymentID);
                SQLConn.ConnDB();
                SQLConn.cmd.ExecuteNonQuery();

            }
            //Update Tamara Account Balance
            if (payTamara >= 0)
            {
                SQLConn.sqL = @"INSERT INTO Tamara (Refnummber,Amount,LandingPaymentID)
                                                 Values(@Refnummber,@Amount,@LandingPaymentID)";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Refnummber", txtref.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Amount", txtpaytamara.Text);
                SQLConn.cmd.Parameters.AddWithValue("@LandingPaymentID", SelectedLandingPaymentID);
                SQLConn.ConnDB();
                SQLConn.cmd.ExecuteNonQuery();

            }
            //SQLConn.trans.Commit();
            Interaction.MsgBox("تمت الإضافة بنجاح", MsgBoxStyle.Information, "دفوعات الإرساء");
            Clear();

        }
        private decimal PaymentCheack()
        {
            decimal Totland = 0;
            SQLConn.sqL = "Select Sum(PayCash + PayCard + Paytranse + Paytamara) From LandingPaymentTransaction Left Outer Join Landing on LandingPaymentTransaction.LandingID = Landing.ID Where Landing.SeaTransportID = '" + cmbSeaTransportID.SelectedValue + "'";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            if (SQLConn.dr.Read())
            {
                var data = SQLConn.dr[0].ToString();
                if (!string.IsNullOrEmpty(data))
                {
                    Totland = Convert.ToDecimal(SQLConn.dr[0].ToString());
                }
            }
            return Totland;
        }
        private void CalculateNextDateTransaction(decimal payCash, decimal payCard,decimal paytrans, decimal paytamara, out DateTime startDate, out DateTime nextDate)
        {
            //startDate = dtpStartDateTransaction.Value;
            startDate = dtpContractStartDate.Value;
            nextDate = startDate;
            if (dailyAmount > 0)
            {
                //var PC = PaymentCheack();
                decimal sum = payCash + payCard + paytrans + paytamara;
                int nbNewDays = Convert.ToInt32(sum / dailyAmount);
                nextDate = startDate.AddDays(nbNewDays-1);
            }
        }

        private decimal GetDailyAmoutPayment()
        {
            decimal dailyAmount = 0; 
            int nbdays = 0;
            if (!string.IsNullOrEmpty(txtAmount.Text))
            {
                decimal val = 0;
                Decimal.TryParse(txtAmount.Text, out val);
                //nbdays = (dtpContractEndDate.Value - dtpContractStartDate.Value).Days;
                //dailyAmount = Decimal.Round(val / nbdays, 2);
                dailyAmount = Decimal.Round(val / 365, 2);
            }

            return dailyAmount;
        }

        private decimal GetTotalPayedBefore(int landingID, int selectedLandingPaymentId)
        {
            decimal total = 0;
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT sum (LandingPaymentTransaction.PayCash + LandingPaymentTransaction.PayCard ) AS total
                    FROM         LandingPaymentTransaction INNER JOIN
                      Landing ON LandingPaymentTransaction.LandingID = Landing.ID INNER JOIN
                      SeaTransport ON Landing.SeaTransportID = SeaTransport.ID  where Landing.ID = " + landingID +
                      @" and LandingPaymentTransaction.ID <> " + selectedLandingPaymentId;

                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    Decimal.TryParse(dtbl.Rows[0]["total"].ToString(), out total);
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
            return total;
        }

        public void GridFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = LandingGridFill();
                dgvdata.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private DataTable LandingGridFill()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT LandingPaymentTransaction.PayCash, LandingPaymentTransaction.PayCard,LandingPaymentTransaction.Paytranse,LandingPaymentTransaction.Paytamara, LandingPaymentTransaction.Date, SeaTransport.Name, 
                    LandingPaymentTransaction.ID,   (LandingPaymentTransaction.PayCash + LandingPaymentTransaction.PayCard ) AS total, 
                    LandingPaymentTransaction.LandingID,LandingPaymentTransaction.Payreftamara
                    FROM         LandingPaymentTransaction INNER JOIN
                      Landing ON LandingPaymentTransaction.LandingID = Landing.ID INNER JOIN
                      SeaTransport ON Landing.SeaTransportID = SeaTransport.ID Order BY LandingPaymentTransaction.Date";
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "دفوعات الإرساء", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        /// <summary>
        /// Avoir la liste des type de transport boat types
        /// </summary>
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

        /// <summary>
        /// Avoir la liste des banks account
        /// </summary>
        public void GetBankAccountList()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM BankAccounts");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbBankAccount.DataSource = dtbl;
                cmbBankAccount.ValueMember = "ID";
                cmbBankAccount.DisplayMember = "Name";
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
                dtbl = SQLConn.getTable(@"SELECT ID, Name, TypeID FROM SeaTransport Where TypeID = " + TypeID + " "
                        + " Order by TypeID, ID, Name ");
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

        public void GetPaymentDoneToDate(int seaTransportID)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT     PaymentDoneToDate
                      FROM         Landing SeaTransportID = " + seaTransportID + " ";

                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(dt);

                string date = dt.Rows[0]["PaymentDoneToDate"].ToString();
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


        public void FillLandingDetails(int id)
        {
            try
            {
                DataTable LandingDetails = new DataTable();
                SQLConn.sqL = @"SELECT Landing.ID as LandingID,  Landing.Amount, Landing.StartDate, Landing.EndDate, SeaTransport.Name, 
                      SeaTransportType.Name AS TransportType,Landing.DailyAmount, Landing.PaymentDoneToDate,
                      SeaTransportType.ID AS TypeID, 
                      SeaTransport.ID

                      FROM         Landing INNER JOIN
                      SeaTransport ON Landing.SeaTransportID = SeaTransport.ID INNER JOIN
                      SeaTransportType ON SeaTransport.TypeID = SeaTransportType.ID 
                      Where SeaTransport.ID = " + id + " Order by Landing.ID DESC ";

                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(LandingDetails);
                if (LandingDetails.Rows.Count > 0)
                {
                    // TODO : add lainding ID
                    landingID = Int32.Parse(LandingDetails.Rows[0]["LandingID"].ToString());

                    txtAmount.Text = LandingDetails.Rows[0]["Amount"].ToString();
                    cmbTypeID.SelectedValue = LandingDetails.Rows[0]["TypeID"].ToString();

                    dtpContractStartDate.Text = LandingDetails.Rows[0]["StartDate"].ToString();
                    dtpContractEndDate.Text = LandingDetails.Rows[0]["EndDate"].ToString();


                    dtpPaymentDoneToDate.Text = String.IsNullOrEmpty(LandingDetails.Rows[0]["PaymentDoneToDate"].ToString()) ? LandingDetails.Rows[0]["EndDate"].ToString() : LandingDetails.Rows[0]["PaymentDoneToDate"].ToString();



                    dailyAmount = Decimal.Parse(LandingDetails.Rows[0]["DailyAmount"].ToString());

                    cmbSeaTransportID.SelectedValue = LandingDetails.Rows[0]["ID"].ToString() == "" ? "0" : LandingDetails.Rows[0]["ID"].ToString();
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

        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();
            int id = int.Parse(SelectedValue);
            if (id > 0)
            {
                FillSeaTransportFill(id);
            }
        }

        private void cmbSeaTransportID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the landing details for selected item
            var SelectedValue = ((DataRowView)cmbSeaTransportID.SelectedItem).Row[0].ToString();
            int id = int.Parse(SelectedValue);
            if (id > 0)
            {
                FillLandingDetails(id);
            }
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
            if (txtpaytrans.Text == "")
            {
                txtpaytrans.Text = "0.00";
            }
            if (txtpaytamara.Text == "")
            {
                txtpaytamara.Text = "0.00";
            }
            decimal CashValue = 0;
            Decimal.TryParse(txtpaycash.Text, out CashValue);
            decimal BankValue = 0;
            Decimal.TryParse(txtpaycard.Text, out BankValue);
            decimal TransValue = 0;
            Decimal.TryParse(txtpaytrans.Text, out TransValue);
            decimal TamaraValue = 0;
            Decimal.TryParse(txtpaytamara.Text, out TamaraValue);
            decimal totalPay = CashValue + BankValue + TransValue + TamaraValue;
            lblTotalCashAndBank.Text = totalPay.ToString();
            
             dailyAmount = GetDailyAmoutPayment();
            // Calculate the date that correspond to this payment
            DateTime startDate, nextDate;
            CalculateNextDateTransaction(CashValue, BankValue, TransValue, TamaraValue, out startDate, out nextDate);
            dtpStartDateTransaction.Value = startDate;
            dtpEndDateTransaction.Value = nextDate;
            
        }

        private void txtpaycash_TextChanged(object sender, EventArgs e)
        {
            if (txtpaycash.Text != "")
            {
                GetTotalPay();
            }
        }

        private void txtpaycard_TextChanged(object sender, EventArgs e)
        {
            if (txtpaycard.Text != "" && txtpaycard.Text != "0.00")
            {
                lblBankAccount.Visible = true;
                cmbBankAccount.Visible = true;
                GetTotalPay();
            }
            else
            {
                lblBankAccount.Visible = false;
                cmbBankAccount.Visible = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            CmdPay.Text = "";
            HiddenFild();
            btnSave.Enabled = true;
            txtpaytrans.Visible = false;
            txtpaytrans.Clear();
            txtpaytamara.Visible = false;
            txtpaytamara.Clear();
            btnSave.Text = "حفظ";
            cmbTypeID.Text = "";
            txtAmount.Text = "";
            dtpContractStartDate.Value = DateTime.Now;
            dtpContractEndDate.Value = DateTime.Now;
            dtpPaymentDoneToDate.Value = DateTime.Now;
            dtpStartDateTransaction.Value = DateTime.Now;
            dtpEndDateTransaction.Value = DateTime.Now;
            txtpaycard.Text = "";
            txtpaycash.Text = "";
            cmbBankAccount.Text = "";
            cmbSeaTransportID.Text = "";
            lblTotalCashAndBank.Text = "";
            SeaTransportTypeFill();
            GetBankAccountList();
            SelectedLandingPaymentID = -1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف دفع هذا الارساء", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
                Clear();
                GridFill();
            }
            else
            {
                return;
            }
        }

        private void DeleteFunction()
        {
            int SelectedLandingID = Convert.ToInt32(dgvdata.CurrentRow.Cells["Column5"].Value);
            try
            {
                dailyAmount = GetDailyAmoutPayment();

                GetPaymentDoneToDateWhenDeletingTransaction();

                SQLConn.ConnDB();
                SQLConn.BeginTransaction();
                SQLConn.sqL = @"Update Landing set PaymentDoneToDate=@PaymentDoneToDate , EndDate =@EndDate where ID =" + landingID;

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.Add("@PaymentDoneToDate", SqlDbType.DateTime).Value = dtpPaymentDoneToDate.Value.ToString("yyyy-MM-dd");
                SQLConn.cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dtpContractEndDate.Value;
                SQLConn.cmd.ExecuteScalar();

                //
                // update bank and treasury   PayCash  
                //
                if (PayCash > 0 && SelectedLandingPaymentID > 0)
                {
                    //If Treasury transaction
                    SQLConn.UpdatePrincipalTreasuryLandingTransactions(-PayCash, SQLConn.trans, SelectedLandingPaymentID, "حذف دفعة إرساء");

                    SQLConn.UpdatePrincipalTreasuryBalance(-PayCash, SQLConn.trans);

                    SQLConn.sqL = @"Delete from TreasuryTransactions where LandingPaymentID=@LandingPaymentID";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                    SQLConn.cmd.Parameters.AddWithValue("@LandingPaymentID", SelectedLandingPaymentID);
                    SQLConn.cmd.ExecuteScalar();
                }

                if (PayCard > 0 && SelectedLandingPaymentID > 0)
                {
                    if (SelectedBankID > 0)
                    {
                        //If bank transaction  BankAccountTransactions                      

                        SQLConn.UpdateBankAccountLandingPaymentTransactions(SelectedBankID, -PayCard, SelectedLandingPaymentID, "حذف دفعة إرساء ", SQLConn.trans);

                        SQLConn.UpdateBankAccountByID(SelectedBankID, -PayCard, SQLConn.trans);

                        SQLConn.sqL = @"Delete from BankAccountTransactions where LandingPaymentID=@LandingPaymentID";
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                        SQLConn.cmd.Parameters.AddWithValue("@LandingPaymentID", SelectedLandingPaymentID);
                        SQLConn.cmd.ExecuteScalar();
                    }
                }

                SQLConn.sqL = "Delete  From LandingPaymentTransaction  WHERE   ID=@idlanging";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@idlanging", SelectedLandingPaymentID);
                SQLConn.cmd.ExecuteScalar();


                SQLConn.sqL = "Delete  From Banktransfers  WHERE  LandingPaymentID=@idlanging";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@idlanging", SelectedLandingPaymentID);
                SQLConn.cmd.ExecuteNonQuery();


                SQLConn.sqL = "Delete  From Tamara  WHERE  LandingPaymentID=@idlanging";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@idlanging", SelectedLandingPaymentID);
                SQLConn.cmd.ExecuteNonQuery();

                //TODO : update Dates to every transaction related to this boat

                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "دفوعات الإرساء");

                //SQLConn.trans.Commit();
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

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    SelectedLandingPaymentID = Convert.ToInt32(dgvdata.CurrentRow.Cells["Column5"].Value);
                    FillControls();
                    btnPrint.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void FillControls()
        {
            try
            {
                DataTable LandingDetails = new DataTable();
                SQLConn.sqL = @"SELECT distinct  Landing.ID AS LandingID, Landing.Amount, Landing.StartDate, Landing.EndDate, SeaTransport.Name, SeaTransportType.Name AS TransportType, 
                      Landing.DailyAmount, Landing.PaymentDoneToDate, SeaTransportType.ID AS TypeID, SeaTransport.ID, LandingPaymentTransaction.PayCash, LandingPaymentTransaction.Paytranse,LandingPaymentTransaction.Paytamara,
                      LandingPaymentTransaction.PayCard, BankAccounts.ID as BankID, LandingPaymentTransaction.Date, 
                      LandingPaymentTransaction.PaymentTransactionStartDate, LandingPaymentTransaction.PaymentDoneToDate as EndDateTrans,LandingPaymentTransaction.Payreftamara
FROM         Landing INNER JOIN
                      SeaTransport ON Landing.SeaTransportID = SeaTransport.ID INNER JOIN
                      SeaTransportType ON SeaTransport.TypeID = SeaTransportType.ID INNER JOIN
                      LandingPaymentTransaction ON Landing.ID = LandingPaymentTransaction.LandingID  LEFT OUTER JOIN
                      BankAccountTransactions ON LandingPaymentTransaction.ID = BankAccountTransactions.LandingPaymentID LEFT OUTER JOIN
                      BankAccounts ON BankAccountTransactions.BankID = BankAccounts.ID
WHERE     (LandingPaymentTransaction.ID = " + SelectedLandingPaymentID + ") ORDER BY SeaTransport.ID";

                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
                SQLConn.da.Fill(LandingDetails);
                if (LandingDetails.Rows.Count > 0)
                {

                    landingID = Int32.Parse(LandingDetails.Rows[0]["LandingID"].ToString());

                    txtAmount.Text = LandingDetails.Rows[0]["Amount"].ToString();
                    cmbTypeID.SelectedValue = LandingDetails.Rows[0]["TypeID"].ToString();

                    if (!string.IsNullOrEmpty(LandingDetails.Rows[0]["BankID"].ToString()))
                    {
                        cmbBankAccount.SelectedValue = LandingDetails.Rows[0]["BankID"].ToString();

                        Int32.TryParse(cmbBankAccount.SelectedValue.ToString(), out SelectedBankID);
                    }
                    else
                        cmbBankAccount.SelectedIndex = -1;

                    dtpContractStartDate.Text = LandingDetails.Rows[0]["StartDate"].ToString();
                    dtpContractEndDate.Text = LandingDetails.Rows[0]["EndDate"].ToString();


                    dtpPaymentDoneToDate.Text = LandingDetails.Rows[0]["PaymentDoneToDate"].ToString() == null ? dtpContractStartDate.Value.ToShortDateString() : LandingDetails.Rows[0]["PaymentDoneToDate"].ToString();

                    dailyAmount = Decimal.Parse(LandingDetails.Rows[0]["DailyAmount"].ToString());

                    cmbSeaTransportID.SelectedValue = LandingDetails.Rows[0]["ID"].ToString() == "" ? "0" : LandingDetails.Rows[0]["ID"].ToString();
                    CmdPay.Text = "تمارا ونقدي وبنكي وتحويل";
                    Cheackpayment();
                    txtpaycard.Text = LandingDetails.Rows[0]["PayCard"].ToString();
                    txtpaycash.Text = LandingDetails.Rows[0]["PayCash"].ToString();
                    txtpaytrans.Text = LandingDetails.Rows[0]["Paytranse"].ToString();
                    txtpaytamara.Text = LandingDetails.Rows[0]["Paytamara"].ToString();
                    txtref.Text = LandingDetails.Rows[0]["Payreftamara"].ToString();


                    Decimal.TryParse(LandingDetails.Rows[0]["PayCash"].ToString(), out PayCash);
                    Decimal.TryParse(LandingDetails.Rows[0]["PayCard"].ToString(), out PayCard);

                    dtpDate.Text = LandingDetails.Rows[0]["Date"].ToString();
                    dtpStartDateTransaction.Text = LandingDetails.Rows[0]["PaymentTransactionStartDate"].ToString(); // @PaymentDoneToDate, @PaymentTransactionStartDate
                    dtpEndDateTransaction.Text = LandingDetails.Rows[0]["EndDateTrans"].ToString();

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
        Double Tax;
        Double GTBV;
        Double GTAV;
        void DQ()
        {
            String Seller = "شركة مرسى اللؤلؤة للتأجير";
            String VatNo = "311593635600003";
            DateTime dTime = DateTime.Now;
            Double Total = Convert.ToDouble(lblTotalCashAndBank.Text);
            var tbv = Total / 1.15;
            GTBV = Math.Round(tbv,2);
            var tav = tbv * 0.15;
            GTAV = Math.Round(tav, 2);
            Tax = Math.Round(tav,2);

            TLV tlv = new TLV(Seller, VatNo, dTime, Total, Tax);
            QRPic.Image = tlv.toQrCode();
            Photo = CTB(QRPic.Image);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            DQ();
            Repland FRP = new Repland();
            var Qur = "SELECT DISTINCT "+
                      "LandingPaymentTransaction.ID, "+
                      "LandingPaymentTransaction.PayCash, "+
                      "LandingPaymentTransaction.PayCard, "+
                      "LandingPaymentTransaction.Date, "+
                      "LandingPaymentTransaction.LandingID, "+
                      "Landing.Amount, "+
                      "Landing.StartDate, "+
                      "Landing.EndDate, "+
                      "Landing.PaymentDoneToDate, "+
                      "SeaTransport.Name AS SeaName,"+
                      "SeaTransportType.Name As Seatype," +
                      "LandingPaymentTransaction.PaymentDoneToDate AS PaymentDateTransaction, "+
                      "BankAccounts.Name AS BankName, "+
                      "Landing.Owner as OwnerName, " +
                      "SeaTransport.Number AS BoatNumber, "+
                      "LandingPaymentTransaction.PaymentTransactionStartDate, "+
                      "LandingPaymentTransaction.PaymentDoneToDate AS PaymentTransactionEndDate, "+
                      "Drivers.Taxnumber " +
                      "FROM LandingPaymentTransaction " +
                      "INNER JOIN Landing "+
                      "ON LandingPaymentTransaction.LandingID = Landing.ID "+
                      "INNER JOIN SeaTransport "+
                      "ON Landing.SeaTransportID = SeaTransport.ID "+
                      "LEFT OUTER JOIN Drivers "+
                      "ON SeaTransport.OwnerID = Drivers.ID "+
                      "LEFT OUTER JOIN BankAccountTransactions "+
                      "ON LandingPaymentTransaction.ID = BankAccountTransactions.LandingPaymentID "+
                      "LEFT OUTER JOIN BankAccounts "+
                      "ON BankAccountTransactions.BankID = BankAccounts.ID "+
                      "INNER Join SeaTransportType "+
                      "ON SeaTransport.TypeID = SeaTransportType.ID "+
                      "WHERE LandingPaymentTransaction.ID = " + SelectedLandingPaymentID;

            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.ConnDB();
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            LRReport LRR = new LRReport();
            QRds ds = new QRds();
            var TN = "";
            while (SQLConn.dr.Read())
            {
                TN = SQLConn.dr["Taxnumber"].ToString();
                var Billnumber = SQLConn.dr[0].ToString();
                var Owner = SQLConn.dr[13].ToString();
                var Transporter = SQLConn.dr[9].ToString();
                var Transportertype = SQLConn.dr[10].ToString();
                var a = Convert.ToDouble(SQLConn.dr[1].ToString());
                var b = Convert.ToDouble(SQLConn.dr[2].ToString());
                var Res = a + b;
                var Paymentme = Convert.ToString(Res);
                var Paymentmethod = "";
                if (SQLConn.dr[1].ToString() == "0.00")
                {
                    Paymentmethod = "بطاقة ائتمانية";
                }
                else if (SQLConn.dr[2].ToString() == "0.00")
                {
                    Paymentmethod = "نقدي";
                }
                else
                {
                    Paymentmethod = "نقدي وبنك";
                }
                var TBV = Convert.ToDouble(Paymentme) -
                          Convert.ToDouble(Tax);
                var From = SQLConn.dr[6].ToString();
                var To = SQLConn.dr[8].ToString();
                ds.Landingpayment.Rows.Add(new object[] {
                    Billnumber,Owner,Transporter,Transportertype,
                    Paymentmethod,TBV,Tax,Paymentme,From,To,Photo
                    });
            }
            SQLConn.conn.Close();

            LRR.SetDataSource(ds);
            LRR.SetParameterValue("Taxnumber",TN);
            FRP.CVL.ReportSource = LRR;
            FRP.Show();
            //LRR.PrintOptions.PrinterName = "Microsoft Print to PDF";
            //LRR.PrintToPrinter(1, true, 1, 1);
            QRPic.Image = null;
            if (SelectedLandingPaymentID > 0)
                PrintLandingPaymentReport(SelectedLandingPaymentID);
        }

        private void lblTotalCashAndBank_TextChanged(object sender, EventArgs e)
        {
            decimal CashValue = 0;
            Decimal.TryParse(txtpaycash.Text, out CashValue);
            decimal BankValue = 0;
            Decimal.TryParse(txtpaycard.Text, out BankValue);
            decimal TransValue = 0;
            Decimal.TryParse(txtpaytrans.Text, out TransValue);
            decimal TamaraValue = 0;
            Decimal.TryParse(txtpaytamara.Text, out TamaraValue);
            
            dailyAmount = GetDailyAmoutPayment();

            // Calculate the date that correspond to this payment
            DateTime startDate, nextDate;
            CalculateNextDateTransaction(CashValue, BankValue, TransValue, TamaraValue, out startDate, out nextDate);
            dtpStartDateTransaction.Value = startDate;
            dtpEndDateTransaction.Value = nextDate;
            
        }
        public void Cheackpayment()
        {
            var Case = CmdPay.Text;
            switch (Case)
            {
                case "نقدي":
                    HiddenFild();
                    txtpaycard.Text = "0.00";
                    txtpaycash.Visible = true;
                    label9.Visible = true;
                    break;
                case "بنكي":
                    HiddenFild();
                    txtpaycard.Visible = true;
                    label15.Visible = true;
                    break;
                case "تحويل بنكي":
                    HiddenFild();
                    label11.Visible = true;
                    txtpaytrans.Visible = true;
                    break;
                case "تمارا":
                    HiddenFild();
                    label12.Visible = true;
                    txtpaytamara.Visible = true;
                    txtref.Visible = true;
                    label32.Visible = true;
                    break;
                case "نقدي وبنكي":
                    HiddenFild();
                    label9.Visible = true;
                    label15.Visible = true;
                    txtpaycard.Visible = true;
                    txtpaycash.Visible = true;
                    break;
                case "نقدي وتحويل":
                    HiddenFild();
                    txtpaycash.Text = "0.00";
                    txtpaytrans.Text = "0.00";
                    txtpaycash.Visible = true;
                    label9.Visible = true;
                    label11.Visible = true;
                    txtpaytrans.Visible = true;
                    break;
                case "تمارا ونقدي":
                    HiddenFild();
                    txtpaycash.Visible = true;
                    label9.Visible = true;
                    label12.Visible = true;
                    txtpaytamara.Visible = true;
                    txtref.Visible = true;
                    label32.Visible = true;
                    break;
                case "بنكي وتحويل":
                    HiddenFild();
                    txtpaycard.Text = "0.00";
                    txtpaycard.Visible = true;
                    label15.Visible = true;
                    label11.Visible = true;
                    txtpaytrans.Visible = true;
                    txtpaytrans.Text = "0.00";
                    break;
                case "تمارا وبنكي":
                    HiddenFild();
                    txtpaycard.Visible = true;
                    label15.Visible = true;
                    label12.Visible = true;
                    txtpaytamara.Visible = true;
                    txtref.Visible = true;
                    label32.Visible = true;
                    break;
                case "نقدي وبنكي وتحويل":
                    HiddenFild();
                    label9.Visible = true;
                    label15.Visible = true;
                    txtpaycard.Visible = true;
                    txtpaycash.Visible = true;
                    label11.Visible = true;
                    txtpaytrans.Visible = true;
                    txtpaytrans.Text = "0.00";
                    break;
                case "تمارا وتحويل":
                    HiddenFild();
                    label11.Visible = true;
                    txtpaytrans.Visible = true;
                    txtpaytrans.Text = "0.00";
                    label12.Visible = true;
                    txtpaytamara.Visible = true;
                    txtref.Visible = true;
                    label32.Visible = true;
                    break;
                case "تمارا ونقدي وبنكي":
                    HiddenFild();
                    txtpaycash.Visible = true;
                    txtpaycard.Visible = true;
                    label15.Visible = true;
                    label9.Visible = true;
                    label12.Visible = true;
                    txtpaytamara.Visible = true;
                    txtref.Visible = true;
                    label32.Visible = true;
                    break;
                case "تمارا ونقدي وبنكي وتحويل":
                    HiddenFild();
                    txtpaycash.Visible = true;
                    txtpaycard.Visible = true;
                    label15.Visible = true;
                    label9.Visible = true;
                    label12.Visible = true;
                    txtpaytamara.Visible = true;
                    label11.Visible = true;
                    txtpaytrans.Visible = true;
                    txtpaytrans.Text = "0.00";
                    txtref.Visible = true;
                    label32.Visible = true;
                    break;
            }
        }
        private void HiddenFild()
        {
            label15.Visible = false;
            txtpaycard.Visible = false;
            txtpaycard.Text = "0.00";
            label9.Visible = false;
            txtpaycash.Visible = false;
            txtpaycash.Text = "0.00";
            label11.Visible = false;
            txtpaytrans.Visible = false;
            txtpaytrans.Text = "0.00";
            label12.Visible = false;
            txtpaytamara.Visible = false;
            txtpaytamara.Text = "0.00";
            txtref.Text = string.Empty;
            label32.Visible = false;
            txtref.Visible = false;
            label32.Visible = false;
        }

        private void txtpaytrans_TextChanged(object sender, EventArgs e)
        {
            if (txtpaytrans.Text != "")
            {
                GetTotalPay();
            }
        }

        private void txtpaytamara_TextChanged(object sender, EventArgs e)
        {
            if (txtpaytamara.Text != "")
            {
                GetTotalPay();
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void CmdPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cheackpayment();
        }
    }
}
