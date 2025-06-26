using CrystalDecisions.ReportAppServer.CommonControls;
using MarsaAlloaloah.CrystalReports.CQR;
using MarsaAlloaloah.Qrmodel;
using MarsaAlloaloah.Utility;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Utilities.Collections;
using SmartArabXLSX.Wordprocessing;
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
    public partial class frmEditTicket : Form
    {
        int addonID;
        string total;
        string name;
        string vat;
        int id;
        public FrmTickets frm;
        decimal PriceBeforeDiscount = 0.0m;
        decimal VatPercent = 0.0m;
        int PayementType;

        // fields for ticket details // TODO/ creat an object Ticket
        public int id1;
        public int idTicket;
        public string tel;
        public DateTime StartDate;
        public DateTime StartTime;
        public DateTime EndTime;
        public string SeaTransportTypeID;
        public string SeaTransportID;
        public string DriverID;
        public string CustomerID;
        public string CustomerName;
        public string CustomerNID;
        public string DurationID;
        public string DurationValue;
        public string PriceAfterDiscoun;
        public string TicketUserID;
        public string CompanyNam;
        public string paychash;
        public string paycard;
        public string Duration;
        public string SeaName;
        public string DriverName;
        public string DiscountAmount;
        public string DiscountPercent;

        public string TextBoxCustomerName
        {
            get { return txtCustName.Text; }
            private set { txtCustName.Text = value; }
        }
        public string TextBoxCustomerMobile
        {
            get { return txtCustMobile.Text; }
            private set { txtCustMobile.Text = value; }
        }

        public string TextBoxCustomerNID
        {
            get { return txtCustNID.Text; }
            private set { txtCustNID.Text = value; }
        }
        public frmEditTicket()
        {
            InitializeComponent();
        }

        public frmEditTicket(int idTicket)
        {
            InitializeComponent();
            this.idTicket = idTicket;
            userid = Data.UserID;
        }

        private void GetTicketByID(int idTicket)
        {
            try
            {
                this.idTicket = idTicket;
                DataTable ticketInfo = TicketView(idTicket);

                if (ticketInfo.Rows.Count > 0)
                {
                    int id = 0;
                    SeaTransportTypeID = ticketInfo.Rows[id]["SeaTransportTypeID"].ToString();
                    SeaTransportID = ticketInfo.Rows[id]["SeaTransportID"].ToString();
                    CustomerID = ticketInfo.Rows[id]["CustomerID"].ToString();
                    CustomerName = ticketInfo.Rows[id]["Name"].ToString();
                    CustomerNID = ticketInfo.Rows[id]["NID"].ToString();
                    TicketUserID = ticketInfo.Rows[id]["UserID"].ToString();
                    tel = ticketInfo.Rows[id]["Mobile"].ToString();
                    DurationID = ticketInfo.Rows[id]["DurationID"].ToString();
                    StartDate = DateTime.Parse(ticketInfo.Rows[id]["StartDate"].ToString());
                    StartTime = DateTime.Parse(ticketInfo.Rows[id]["StartTime"].ToString());
                    EndTime = DateTime.Parse(ticketInfo.Rows[id]["EndTime"].ToString());
                    DriverID = ticketInfo.Rows[id]["DriverID"].ToString();
                    CompanyNam = ticketInfo.Rows[id]["CompanyName"].ToString();
                    PriceAfterDiscoun = ticketInfo.Rows[id]["PriceAfterDiscount"].ToString();

                    lblPrice.Text = ticketInfo.Rows[id]["Price"].ToString();
                    DateTime dt = DateTime.Parse(ticketInfo.Rows[id]["StartDate"].ToString());
                    dtpStartDate.Value = dt;
                    DateTime dt1 = DateTime.Parse(ticketInfo.Rows[id]["StartTime"].ToString());
                    dtpStartTime.Value = dt1;

                    txtpaycard.Text = ticketInfo.Rows[id]["PayCash"].ToString();
                    paychash = ticketInfo.Rows[id]["PayCash"].ToString();

                    txtpaycash.Text = ticketInfo.Rows[id]["PayCard"].ToString();
                    paycard = ticketInfo.Rows[id]["PayCard"].ToString();
                    textBox6.Text = ticketInfo.Rows[id]["Paytamara"].ToString();
                    transpay.Text = ticketInfo.Rows[id]["Paytransfer"].ToString();
                    txtSearchDriverByID.Text = ticketInfo.Rows[id]["DriverID"].ToString();
                    txtSearchBoatByID.Text = ticketInfo.Rows[id]["SeaTransportID"].ToString();
                    lblVAT.Text = Common.MettreEnFormeMontantDecimal(ticketInfo.Rows[id]["VAT"].ToString());
                    DiscountAmount = ticketInfo.Rows[id]["DiscountAmount"].ToString();
                    //DiscountPercent = ticketInfo.Rows[id]["DiscountPercent"].ToString();
                    //vat = ticketInfo.Rows[id]["VAT"].ToString();
                    Duration = ticketInfo.Rows[id]["DurationID"].ToString();
                    SeaName = ticketInfo.Rows[id]["SeaName"].ToString();
                    DriverName = ticketInfo.Rows[id]["DriverName"].ToString();
                    txtNote.Text = ticketInfo.Rows[id]["Note"].ToString();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private DataTable TicketView(int idTicket)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT        Tickets.ID, Tickets.StartDate, Tickets.StartTime, Tickets.EndTime, Tickets.SeaTransportTypeID, Tickets.SeaTransportID, Tickets.DriverID, Tickets.CustomerID, Tickets.DurationID, Tickets.DurationValue, Tickets.Price, 
                         Tickets.DiscountAmount, Tickets.DiscountPercent, Tickets.PriceAfterDiscount, Tickets.VAT, Tickets.PriceAfterVAT, Tickets.UserID, Tickets.PayCash, Tickets.PayCard,Tickets.Paytamara,Tickets.Paytransfer, Customers.Mobile, Customers.Name, Customers.NID, 
                         CompanyDiscount.CompanyName, Duration.Duration, SeaTransport.Name AS SeaName, Drivers.Name AS DriverName, Tickets.Note
                         FROM            Tickets INNER JOIN
                         Customers ON Tickets.CustomerID = Customers.ID LEFT OUTER JOIN
                         Drivers ON Tickets.DriverID = Drivers.ID LEFT OUTER JOIN
                         SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID LEFT OUTER JOIN
                         Duration ON Tickets.DurationID = Duration.ID LEFT OUTER JOIN
                         CompanyDiscount ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue
                            where Tickets.ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", idTicket);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        public void GetTotalAddonsTicket()
        {
            try
            {
                SQLConn.sqL = @"select  sum(lnkTicketAddon.Total) as Total FROM lnkTicketAddon LEFT OUTER JOIN  Addons ON lnkTicketAddon.AddonID = Addons.ID where lnkTicketAddon.TicketID=@id";

                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@id", idTicket);
                SqlDataReader reader = SQLConn.cmd.ExecuteReader();
                while (reader.Read())
                {
                    total = reader["Total"].ToString();
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

        public DataTable FillGridAddON()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"select lnkTicketAddon.ID, lnkTicketAddon.AddonID,Addons.Name,lnkTicketAddon.Quantity,lnkTicketAddon.Price, lnkTicketAddon.Total FROM lnkTicketAddon LEFT OUTER JOIN  Addons ON lnkTicketAddon.AddonID = Addons.ID where lnkTicketAddon.TicketID=@id";

                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@id", idTicket);
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
        public void GetData()
        {
            SQLConn.sqL = @"select ID,StartDate,StartTime,EndTime,SeaTransportTypeID,SeaTransportID,UserID,
                DriverID,CustomerID, DurationID, DurationValue,Price,DiscountAmount,DiscountPercent,PriceAfterDiscount,VAT,PriceAfterVAT,PayCash,PayCard
                From Tickets where Tickets.ID=@id";

            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SQLConn.cmd.Parameters.AddWithValue("@id", idTicket);
            SqlDataReader reader = SQLConn.cmd.ExecuteReader();
            while (reader.Read())
            {
                int var1 = (int)reader["ID"];
                lblPrice.Text = reader["Price"].ToString();
                DateTime dt = DateTime.Parse(reader["StartDate"].ToString());
                dtpStartDate.Value = dt;
                DateTime dt1 = DateTime.Parse(reader["StartTime"].ToString());
                dtpStartTime.Value = dt1;
                txtpaycard.Text = reader["PayCash"].ToString();
                txtpaycash.Text = reader["PayCard"].ToString();
                txtSearchDriverByID.Text = reader["DriverID"].ToString();
                txtSearchBoatByID.Text = reader["SeaTransportID"].ToString();
                lblVAT.Text = reader["VAT"].ToString();
                txtDiscountValue.Text = reader["DiscountAmount"].ToString();
                txtDiscountPercent.Text = reader["DiscountPercent"].ToString();
                vat = reader["VAT"].ToString();
            }

        }
        public int userid { get; set; }
        private decimal Cheacdiscavilable()
        {
            SQLConn.sqL = @"SELECT * FROM Users Where ID = " + userid + " ";
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
                    txtDiscountPercent.Text = Convert.ToString(Convert.ToInt32(Discountpercent));
                    //txtchangetot.Visible = false;
                    //Btnchangetot.Visible = false;
                }
            }
            return Discountpercent;
        }
        private void frmticket_Load(object sender, EventArgs e)
        {
            var CDV = Cheacdiscavilable();
            if (CDV > 0)
            {
                //txtDiscountPercent.Enabled = true;
                txtchangetot.Visible = true;
                Btnchangetot.Visible = true;
            }
            else
            {
                //txtDiscountPercent.Enabled = false;
                txtchangetot.Visible = false;
                Btnchangetot.Visible = false;
            }
            AddonsFill();
            lblAddonTotal.Text = "0.00";
            GetProductNo();
            SeaTransportTypeFill();
            FillDuration();
            SelectVATValue();
            FillDrivers();
            CompanyDiscountFill();

            txtCustMobile.Focus();

            dtpStartDate.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Now;

            this.BackgroundImage = (Image)(Properties.Resources.BackgroundImage);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            lblCustIDHidden.Text = string.Empty;
            //GetData();



            // Get TicketDetails by ID
            GetTicketByID(idTicket);

            txtTicketNo.Text = idTicket.ToString();
            txtCustMobile.Text = tel;
            txtCustNID.Text = CustomerNID;
            txtCustName.Text = CustomerName;
            if (SeaTransportTypeID != null)
                cmbTypeID.SelectedValue = Int32.Parse(SeaTransportTypeID);
            cmbSeaTransportID.Text = SeaName;
            cmbDrivers.Text = DriverName;
            FillDuration();
            if (!string.IsNullOrEmpty(Duration))
                cmbDuration.SelectedValue = Int32.Parse(Duration);
            cmbCompanyDiscount.Text = CompanyNam;

            txtDiscountValue.Text = Common.MettreEnFormeMontantDecimal(DiscountAmount);
            //txtDiscountPercent.Text = Common.MettreEnFormeMontantDecimal(DiscountPercent);
            txtpaycard.Text = Common.MettreEnFormeMontantDecimal(paycard);
            txtpaycash.Text = Common.MettreEnFormeMontantDecimal(paychash);
            lblPriceAfterDiscount.Text = Common.MettreEnFormeMontantDecimal(PriceAfterDiscoun);

            DataTable dtbl = new DataTable();
            dtbl = FillGridAddON();
            dgvAddons.DataSource = dtbl;

            GetTotalAddonsTicket();

            lblAddonTotal.Text = Common.MettreEnFormeMontantDecimal(total);
            Gvat();
            SetTotal();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "تحديث التذاكر", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cmbTypeID.SelectedValue = 0;
            btnSave.Text = "حفظ";
            txtAddonPrice.Text = "";
            txtAddonQty.Text = "";
            txtCustMobile.Text = "";
            txtCustName.Text = "";
            txtCustNID.Text = "";
            txtAddonPrice.Text = "";
            //txtDiscountPercent.Text = "";
            txtTicketNo.Text = "";
            cmbAddons.SelectedValue = 0;
            cmbDrivers.SelectedValue = 0;
            cmbSeaTransportID.SelectedValue = 0;

            dgvAddons.Rows.Clear();
            dgvAddons.DataSource = null;

            txtSearchBoatByID.Text = "";
            txtSearchDriverByID.Text = "";

            //Reset Ticket
            AddonsFill();
            GetProductNo();
            SeaTransportTypeFill();
            FillDuration();
            SelectVATValue();
            cmbDuration.SelectedIndex = 1;

            CompanyDiscountFill();

            dtpStartDate.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Now;

            lblTotal.Text = "0.00";
            lblVAT.Text = "0.00";

            lblTotalCashAndBank.Text = "0.00";
            lblTotalAfterVAT.Text = "0.00";
            lblAddonTotal.Text = "0.00";
            txtpaycard.Text = "0.00";
            txtpaycash.Text = "0.00";
            lblPrice.Text = "0.00";
            lblPriceAfterDiscount.Text = "0.00";
        }
        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        public void AddonsFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM Addons");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbAddons.DataSource = dtbl;
                cmbAddons.ValueMember = "ID";
                cmbAddons.DisplayMember = "Name";

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

        private void btnAddAddon_Click(object sender, EventArgs e)
        {
            if (int.Parse(cmbAddons.SelectedValue.ToString()) > 0)
            {
                //Check If Customer Dublicate 
                for (int i = 0; i < dgvAddons.Rows.Count; i++)
                {
                    string InsertedRowID = dgvAddons.Rows[i].Cells[2].Value == null ? "" : dgvAddons.Rows[i].Cells[2].Value.ToString();
                    if (cmbAddons.Text == InsertedRowID)
                    {
                        Interaction.MsgBox("لايمكن تكرار الإضافة");
                        return;
                    }
                }

                DataTable dataTable = (DataTable)dgvAddons.DataSource;
                DataRow drToAdd = dataTable.NewRow();
                drToAdd[1] = ((DataRowView)cmbAddons.SelectedItem).Row[0].ToString();
                drToAdd[2] = cmbAddons.Text;
                drToAdd[4] = txtAddonPrice.Text;
                drToAdd[0] = -dgvAddons.Rows.Count;
                drToAdd[3] = txtAddonQty.Text == "" ? "1" : txtAddonQty.Text;
                //total
                decimal q = 0, p = 0;
                Decimal.TryParse(txtAddonQty.Text, out q);
                Decimal.TryParse(txtAddonPrice.Text, out p);
                drToAdd[5] = (p * q).ToString();
                //drToAdd["ID"] = 0;
                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();

                lblAddonTotal.Text = GetAddonsTotal().ToString();

            }
            SetTotal();


        }

        private void cmbAddons_SelectedIndexChanged(object sender, EventArgs e)
        {

            var SelectedValue = ((DataRowView)cmbAddons.SelectedItem).Row[0].ToString();
            if (int.Parse(SelectedValue) > 0)
            {
                txtAddonPrice.Text = GetAddonPrice(int.Parse(SelectedValue)).ToString();

            }

        }
        private decimal GetAddonsTotal()
        {
            decimal TotalAddon = 0.0m;
            for (int i = 0; i < dgvAddons.Rows.Count - 1; i++)
            {
                if (dgvAddons.Rows[i].Cells["Total_addons"] != null && dgvAddons.Rows[i].Cells["Total_addons"].Value != null
                    && !string.IsNullOrEmpty(dgvAddons.Rows[i].Cells["Total_addons"].Value.ToString()))
                {
                    var AddonPrice = Common.ConvertTxtToDecimal(dgvAddons.Rows[i].Cells["Total_addons"].Value.ToString());
                    TotalAddon += AddonPrice;
                }
            }
            return TotalAddon;
        }
        private int GetAddonPrice(int id)
        {
            int Price = 0;

            try
            {
                SQLConn.sqL = "Select Price From Addons Where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", id);
                if (SQLConn.cmd.ExecuteScalar() != null)
                {
                    Price = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
                }
                // int vv =  int.Parse(SQLConn.cmd.ExecuteScalar().ToString());

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
            return Price;
        }

        private void btnRremoveAddon_Click(object sender, EventArgs e)
        {
            int SelectedRowsCount = dgvAddons.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (SelectedRowsCount > 0)
            {
                for (int i = 0; i < SelectedRowsCount; i++)
                {
                    dgvAddons.Rows.RemoveAt(dgvAddons.SelectedRows[0].Index);

                }
            }
            lblAddonTotal.Text = GetAddonsTotal().ToString();

            // ReOrder Serial No
            for (int i = 0; i < dgvAddons.Rows.Count - 1; i++)
            {
                dgvAddons.Rows[i].Cells[0].Value = i + 1;

            }
            SetTotal();
        }
        private void GetProductNo()
        {
            try
            {
                SQLConn.sqL = "SELECT ID FROM Tickets ORDER BY ID DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    txtTicketNo.Text = (Convert.ToInt32(SQLConn.dr["ID"]) + 1).ToString();
                }
                else
                {
                    txtTicketNo.Text = "1";
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
                dtbl = SQLConn.getTable(@"SELECT ID,Name,TypeID FROM SeaTransport Where TypeID = " + TypeID + " And InService = 1 " +
                    @"  and ID not IN(
                        SELECT      SeaTransport.ID
                        FROM         Tickets Inner JOIN
                        SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID
                        WHERE(Tickets.StartDate = CAST(GETDATE() as DATE)) and(EndTime > CONVERT(TIME, SYSDATETIME()))
                        )" +
                    "Order by TypeID, ID, Name ");
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
        public void FillDrivers()
        {

            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT dbo.Drivers.Name, dbo.Drivers.ID FROM dbo.Drivers");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbDrivers.DataSource = dtbl;
                cmbDrivers.ValueMember = "ID";
                cmbDrivers.DisplayMember = "Name";
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

        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var Duration = "0";

            //var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();

            //if (int.Parse(SelectedValue) > 0)
            //{
            //    FillSeaTransportFill(int.Parse(SelectedValue));

            //    FillDuration();
            //    //Renewduration();
            //    //Duration = cmbDuration.Text; // 

            //    //if (Duration != null)
            //    //{
            //    //    var price = GetPrice(int.Parse(SelectedValue), false, Duration);
            //    //    lblPrice.Text = price.ToString();
            //    //    lblPriceAfterDiscount.Text = price.ToString();
            //    //}
            //}

            //SetTotal();
        }
        private void txtCustNID_Leave(object sender, EventArgs e)
        {

        }


        private void btnFrmCustomer_Click(object sender, EventArgs e)
        {
            frmcustomers cust = new frmcustomers(txtCustName.Text, txtCustMobile.Text, txtCustNID.Text);
            cust.ShowDialog();
        }

        private void cmbSeaTransportID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeaTransportID.SelectedIndex != -1)
            {
                txtSearchBoatByID.Text = cmbSeaTransportID.SelectedValue.ToString();
                // If we also wanted to get the displayed text we could use
                // the SelectedItem item property:
                // string s = ((USState)ListBox1.SelectedItem).LongName;
            }

            //if ((DataRowView)cmbSeaTransportID.SelectedItem != null)
            //{
            //    var SelectedValue = ((DataRowView)cmbSeaTransportID.SelectedItem).Row[0].ToString();
            //    //if (int.Parse(SelectedValue) > 0)
            //    //{
            //    //    var DriverID = GetDefaultDriverID(int.Parse(SelectedValue));

            //    //    //set cmbDrivers from SeaTransport Drive
            //    //    //if (DriverID != 0)
            //    //    //{
            //    //    //    cmbDrivers.SelectedValue = DriverID;
            //    //    //    txtSearchDriverByID.Text = DriverID.ToString();
            //    //    //}

            //    //    //FillDrivers(int.Parse(SelectedValue));
            //    //    //Get Price       
            //    //   // GetPrice();
            //    //}
            //}
        }

        private void cmbDuration_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void GetPrice()
        {
            //Get Price from SeaTransport PriceGroup
            //txtDiscountPercent.Text = "";
            //txtDiscountValue.Text = "";
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
                    lblPriceAfterDiscount.Text = Price.ToString();
                    PriceBeforeDiscount = Price;

                }
            }
            SetTotal();
        }
        //Select Price 

        private DataTable GetPriceGroupBySeaTransportID(int SeaTransportID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = "SELECT PriceGroupID,IsDifferentPricing FROM SeaTransport Where ID = " + SeaTransportID + "";
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
        private decimal GetPriceBySeaTransportTypeID(int PriceGroupID, string duration)
        {
            decimal price = 0.0m;
            try
            {

                SQLConn.sqL = "SELECT Price FROM Price Where SeaTransportTypeID = " + PriceGroupID + " and Duration = @Duration";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Duration", duration);
                if (SQLConn.cmd.ExecuteScalar() != null)
                {
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
        private void txtDiscountValue_TextChanged(object sender, EventArgs e)
        {
            //UpdatePricesAfterDiscount();
        }

        private void txtDiscountPercent_TextChanged(object sender, EventArgs e)
        {
            //UpdatePricesAfterDiscount();
        }

        private void UpdatePricesAfterDiscount()
        {
            if (PriceBeforeDiscount == 0)
            {
                Decimal.TryParse(lblPrice.Text, out PriceBeforeDiscount);
            }
            decimal DiscountPercent = Common.ConvertTxtToDecimal(txtDiscountPercent.Text.ToString() != "" ? txtDiscountPercent.Text.ToString() : "0");
            decimal DiscountValue = 0;
            if (DiscountPercent > 0)
            {
                DiscountValue = (PriceBeforeDiscount * DiscountPercent) / 100;
            }
            else
            {
                DiscountValue = Common.ConvertTxtToDecimal(txtDiscountValue.Text.ToString() != "" ? txtDiscountValue.Text.ToString() : "0");
            }

            decimal PriceAfterDiscount = PriceBeforeDiscount - DiscountValue;

            lblPriceAfterDiscount.Text = PriceAfterDiscount.ToString("N2");

            SetTotal();
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
        private void SetTotal()
        {
            decimal priceAfterDiscount = 0;
            Decimal.TryParse(lblPriceAfterDiscount.Text, out priceAfterDiscount);

            decimal totalAddOn = 0;
            Decimal.TryParse((lblAddonTotal.Text), out totalAddOn);
            decimal totalBeforeVAT = priceAfterDiscount + totalAddOn;
            decimal VatValue = (totalBeforeVAT * VatPercent) / 100;
            decimal totalAfterVAT = totalBeforeVAT + VatValue;
            lblTotal.Text = Common.MettreEnFormeMontantDecimal(totalBeforeVAT.ToString());
            lblVAT.Text = Common.MettreEnFormeMontantDecimal(VatValue.ToString());
            lblTotalAfterVAT.Text = Common.MettreEnFormeMontantDecimal(totalAfterVAT.ToString());
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
            String Seller = "شركة مرسى اللؤلؤة";
            String VatNo = "311593635600003";
            DateTime dTime = DateTime.Now;
            Double Total = Convert.ToDouble(lblTotalCashAndBank.Text);
            Double Tax = Convert.ToDouble(lblVAT.Text);

            TLV tlv = new TLV(Seller, VatNo, dTime, Total, Tax);
            QRPic.Image = tlv.toQrCode();
            Photo = CTB(QRPic.Image);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DQ();
            UpdateTicket(idTicket);
        }

        private void UpdateTicket(int id)
        {
            if (!IsExitingClientByMobile())
            {
                AddCustomerFunction();
            }

            //Validation

            if (txtCustMobile.Text != null && (txtCustMobile.Text.Length < 10 || txtCustMobile.Text.Length > 10))
            {
                Interaction.MsgBox("الرجاء التثبت من رقم الجوال");
                return;
            }
            if (int.Parse(cmbTypeID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر نوع الواسطة البحرية");
                return;
            }
            //if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
            //{
            //    Interaction.MsgBox("من فضلك إختر الواسطة البحرية");
            //    return;
            //}
            if (string.IsNullOrEmpty(lblCustIDHidden.Text) || (!int.TryParse(lblCustIDHidden.Text.ToString(), out int a)) || string.IsNullOrEmpty(txtCustMobile.Text)
                || string.IsNullOrEmpty(txtCustName.Text) || string.IsNullOrEmpty(txtCustNID.Text))
            {
                Interaction.MsgBox("من فضلك إختر بيانات العميل");
                return;
            }
            if (cmbDuration.SelectedValue == null)
            {
                Interaction.MsgBox("من فضلك إختر مدة الرحلة");
                return;
            }
            decimal totalCashAndBank = 0, totalAfterVAT = 0;
            if (Decimal.TryParse(lblTotalCashAndBank.Text, out totalCashAndBank))
            {
                if (Decimal.TryParse(lblTotalAfterVAT.Text, out totalAfterVAT))
                {
                    //if (totalCashAndBank != totalAfterVAT)
                    //{
                    //    Interaction.MsgBox("المبلغ المدفوع لايطابق الإجمالى");
                    //    return;
                    //}
                }
                else
                {
                    //Interaction.MsgBox("المبلغ المدفوع لايطابق الإجمالى");
                    //return;
                }
            }
            else
            {
                //Interaction.MsgBox("المبلغ المدفوع لايطابق الإجمالى");
                //return;
            }

            if (string.IsNullOrEmpty(lblCustIDHidden.Text))
            {
                Interaction.MsgBox(lblCustNotFound.Text);
                return;
            }
            if (cmbDrivers.SelectedValue == null)
            {
                //Interaction.MsgBox("من فضلك إختر السائق");
                //return;
            }
            //var b = ((DataRowView)cmbDuration.SelectedItem).Row[2].ToString();// Take the value on minutes of duration
            var b = ((DataRowView)cmbDuration.SelectedItem).Row[1].ToString();// Take the value on minutes of duration
            string output = string.Concat(b.Where(Char.IsDigit));
            string Coutput = string.Concat(b.Where(Char.IsLetter));
            TimeSpan TicketDuration = new TimeSpan(0, int.Parse(output), 0);

            //TimeSpan TicketDuration = new TimeSpan(0, int.Parse(b), 0);

            DateTime endTime = dtpStartDate.Value;
            //if (dtpStartTime.Value.TimeOfDay.Add(TicketDuration).TotalHours > 24)
            //{
            endTime = dtpStartDate.Value.Date.Add(dtpStartTime.Value.TimeOfDay.Add(TicketDuration));
            //}           

            decimal payCash = 0, payCard = 0;
            if (!string.IsNullOrEmpty(txtpaycash.Text))
                Decimal.TryParse(txtpaycash.Text, out payCash);

            if (!string.IsNullOrEmpty(txtpaycard.Text))
                Decimal.TryParse(txtpaycard.Text, out payCard);

            decimal discountValue = 0;
            if (!string.IsNullOrEmpty(txtDiscountPercent.Text) && string.IsNullOrEmpty(txtDiscountValue.Text))
            {
                decimal DiscountPercent = Common.ConvertTxtToDecimal(txtDiscountPercent.Text.ToString() != "" ? txtDiscountPercent.Text.ToString() : "0");
                discountValue = (PriceBeforeDiscount * DiscountPercent) / 100;
            }
            else
            {
                Decimal.TryParse(txtDiscountValue.Text, out discountValue);
            }
            //Validation
            int newid;
            try
            {
              SQLConn.sqL = @"update Tickets set " +
                            @"StartDate='" + dtpStartDate.Value.ToString("yyyy-MM-dd") + "'," +
                            @"StartTime='" + dtpStartTime.Value.TimeOfDay + "'," +
                            @"EndTime= '" + endTime.TimeOfDay + "'," +
                            @"SeaTransportTypeID=" + cmbTypeID.SelectedValue + "," +
                            @"SeaTransportID=" + int.Parse(txtSearchBoatByID.Text) + "," +
                            @"DriverID=" + int.Parse(txtSearchDriverByID.Text) + "," +
                            @"CustomerID=" + int.Parse(lblCustIDHidden.Text) + "," +
                            @"DurationID=" + cmbDuration.SelectedValue + "," +
                            @"DurationValue=" + Convert.ToInt32(output) + "," +
                            @"DiscountAmount=" + discountValue + "," +
                            @"PriceAfterDiscount=" + Common.ConvertTxtToDecimal(lblPriceAfterDiscount.Text) + "," +
                            @"VAT=" + Common.ConvertTxtToDecimal(lblVAT.Text) + "," +
                            @"PriceAfterVAT=" + Common.ConvertTxtToDecimal(lblTotalAfterVAT.Text) + "," +
                            @"PayCash=" + Convert.ToDecimal(txtpaycash.Text) + "," +
                            @"PayCard=" + Convert.ToDecimal(txtpaycard.Text) + "," +
                            @"Paytamara=" + Convert.ToDecimal(textBox6.Text) + "," +
                            @"Paytransfer=" + Convert.ToDecimal(transpay.Text) + "," +
                            @"Note='" + txtNote.Text + "' " +
                            @"where ID= " + idTicket;
                SQLConn.conn.Open();
                //SQLConn.ConnDB();
                //SQLConn.BeginTransaction();
                //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                SQLConn.conn.Close();



                SQLConn.sqL = @"update Tamara set " +
                              @"Refnummber='" + textBox4.Text + "'," +
                              @"Amount='" + textBox6.Text + "' " +
                              @"where Ticketid= " + int.Parse(txtTicketNo.Text);
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.ExecuteNonQuery();



                SQLConn.sqL = @"update Banktransfers set " +
                              @"Amount='" + transpay.Text + "' " +
                              @"where Ticketid= " + int.Parse(txtTicketNo.Text);
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.ExecuteNonQuery();
                //SQLConn.sqL = @"update  Tickets set  
                //                StartDate=@StartDate,
                //                StartTime=@StartTime,
                //                EndTime=@EndTime,
                //                SeaTransportTypeID=@SeaTransportTypeID,
                //                SeaTransportID=@SeaTransportID,               
                //                DriverID=@DriverID,
                //                CustomerID=@CustomerID,
                //                DurationID=@DurationID,
                //                DurationValue=@DurationValue,
                //                DiscountAmount=@DiscountAmount,
                //                PriceAfterDiscount=@PriceAfterDiscount,
                //                VAT=@VAT,
                //                PriceAfterVAT=@PriceAfterVAT,
                //                PayCash=@PayCash,
                //                PayCard=@PayCard,
                //                Paytamara=@Paytamara,
                //                Note = @Note
                //                where ID=@id";
                //SQLConn.ConnDB();
                ////SQLConn.BeginTransaction();

                //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                //SQLConn.cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                //SQLConn.cmd.Parameters.AddWithValue("@StartTime", dtpStartTime.Value.TimeOfDay);
                //SQLConn.cmd.Parameters.AddWithValue("@EndTime", endTime.TimeOfDay);

                //SQLConn.cmd.Parameters.AddWithValue("@SeaTransportTypeID", cmbTypeID.SelectedValue);
                //SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", cmbSeaTransportID.SelectedValue);
                //SQLConn.cmd.Parameters.AddWithValue("@DriverID", int.Parse(txtSearchDriverByID.Text));
                //SQLConn.cmd.Parameters.AddWithValue("@CustomerID", int.Parse(lblCustIDHidden.Text));
                ////DurationID
                //SQLConn.cmd.Parameters.AddWithValue("@DurationID", cmbDuration.SelectedValue);
                ////SQLConn.cmd.Parameters.AddWithValue("@DurationValue", b);
                //SQLConn.cmd.Parameters.AddWithValue("@DurationValue", Convert.ToInt32(output));
                ////var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();

                //SQLConn.cmd.Parameters.AddWithValue("@DiscountAmount", discountValue);
                ////SQLConn.cmd.Parameters.AddWithValue("@DiscountPercent", Common.ConvertTxtToDecimal(txtDiscountPercent.Text != "" ? txtDiscountPercent.Text : "0"));
                //SQLConn.cmd.Parameters.AddWithValue("@PriceAfterDiscount", Common.ConvertTxtToDecimal(lblPriceAfterDiscount.Text));
                //SQLConn.cmd.Parameters.AddWithValue("@VAT", Common.ConvertTxtToDecimal(lblVAT.Text));
                //SQLConn.cmd.Parameters.AddWithValue("@PriceAfterVAT", Common.ConvertTxtToDecimal(lblTotalAfterVAT.Text));
                //// SQLConn.cmd.Parameters.AddWithValue("@PayementType", SqlDbType.Int).Value = PayementType;

                //SQLConn.cmd.Parameters.AddWithValue("@PayCash", Convert.ToDecimal(txtpaycash.Text));
                //SQLConn.cmd.Parameters.AddWithValue("@PayCard", Convert.ToDecimal(txtpaycard.Text));
                //SQLConn.cmd.Parameters.AddWithValue("@Paytamara", Convert.ToDecimal(textBox6.Text));
                //SQLConn.cmd.Parameters.AddWithValue("@Note", txtNote.Text);
                //SQLConn.cmd.Parameters.AddWithValue("@id", idTicket);

                //SQLConn.cmd.ExecuteScalar();

                //Update Treasury Balance For Current User 

                decimal cash = Decimal.Parse(paychash);
                decimal card = decimal.Parse(paycard);

                if (payCash >= 0)
                {
                    if (!string.IsNullOrEmpty("TicketUserID") && Int32.TryParse(TicketUserID, out int val) && val > 0)
                        SQLConn.GetTreasuryIDForCurrentUser(val);// Must be the the userid of the ticket

                    //update TreasuryTransactions
                    if (Data.UserTreasuryID > 0)
                    {
                        if (cash > 0)
                        {
                            SQLConn.UpdateUserTreasuryTicketTransactions(Data.UserTreasuryID, -cash, SQLConn.trans, idTicket, " تحديث تذكرة - سحب المبلغ النقدي القديم ");
                            SQLConn.UpdateUserTreasury(Data.UserTreasuryID, -cash, SQLConn.trans);
                        }
                        SQLConn.UpdateUserTreasuryTicketTransactions(Data.UserTreasuryID, payCash, SQLConn.trans, idTicket, " تحديث تذكرة - إظافة المبلغ النقدي الجديد ");
                        SQLConn.UpdateUserTreasury(Data.UserTreasuryID, payCash, SQLConn.trans);
                    }
                }
                //Update Bank Account Balance
                if (payCard >= 0)
                {
                    //Decimal.TryParse(txtpaycard.Text, out payCard);

                    int bankId = GetBankAccountID();

                    if (bankId > 0)
                    {
                        if (card > 0)
                        {
                            SQLConn.UpdateBankAccountTicketTransactions(bankId, -card, idTicket, " تحديث تذكرة - سحب المبلغ البنكي القديم ", SQLConn.trans);
                            SQLConn.UpdateBankAccountByID(bankId, -card, SQLConn.trans);
                        }
                        SQLConn.UpdateBankAccountTicketTransactions(bankId, payCard, idTicket, " تحديث تذكرة - إظافة المبلغ البنكي الجديد ", SQLConn.trans);
                        SQLConn.UpdateBankAccountByID(bankId, payCard, SQLConn.trans);
                    }
                }

                decimal quantity = 0, price = 0, total = 0;
                //Add lnkTicketAddon 
                if (dgvAddons.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvAddons.Rows.Count - 1; i++)
                    {
                        int lineID = int.Parse(dgvAddons.Rows[i].Cells["tiad_Addons"].Value.ToString());

                        var addonID = int.Parse(dgvAddons.Rows[i].Cells["ID_Addons"].Value.ToString());
                        if (dgvAddons.Rows[i].Cells["Quantity"] != null && dgvAddons.Rows[i].Cells["Quantity"].Value != null && !string.IsNullOrEmpty(dgvAddons.Rows[i].Cells["Quantity"].Value.ToString()))
                            quantity = Common.ConvertTxtToDecimal(dgvAddons.Rows[i].Cells["Quantity"].Value.ToString());
                        if (dgvAddons.Rows[i].Cells["Price"] != null && dgvAddons.Rows[i].Cells["Price"].Value != null && !string.IsNullOrEmpty(dgvAddons.Rows[i].Cells["Price"].Value.ToString()))
                            price = Common.ConvertTxtToDecimal(dgvAddons.Rows[i].Cells["Price"].Value.ToString());

                        total = price * quantity;

                        if (lineID < 0)
                        {
                            AddTicketsAddons(idTicket, addonID, quantity, price, total, SQLConn.trans);
                        }
                        else //if(lineID  0)
                        {
                            UpdateTicketsAddons(idTicket, addonID, quantity, price, total, SQLConn.trans);
                        }
                    }
                }

                SQLConn.trans.Commit();

                txtCustMobile.Focus();

                Interaction.MsgBox("تم التحديث  بنجاح.", MsgBoxStyle.Information, " التحديث ");
                //PrintTicket();

                //this.Hide();
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
        string Paytamara = "0";
        string Paytrans = "0";
        private void PrintTicket()
        {
            var b = ((DataRowView)cmbDuration.SelectedItem).Row[1].ToString();// Take the value on minutes of duration
            string Coutput = string.Concat(b.Where(Char.IsLetter));
            //string query = @" SELECT  Tickets.ID, Tickets.StartDate,  CAST(Tickets.StartTime AS time(0)) AS StartTime, 
            //            Customers.Name AS CustomerName, Customers.Mobile, 
            //            Customers.NID, SeaTransport.Name AS SeaTransportName, 
            //            Tickets.DurationValue, Tickets.VAT, Tickets.PriceAfterDiscount, 
            //            Tickets.PriceAfterVAT, Employees.Name AS CashierName, 
            //            SeaTransportType.Name AS SeaType, Drivers.Name AS DriverName, Tickets.PayCash, 
            //          Tickets.PayCard, CompanyDiscount.CompanyName, CompanyDiscount.DiscountValue, Tickets.DiscountAmount

            //          FROM         Tickets INNER JOIN
            //          Users ON Tickets.UserID = Users.ID INNER JOIN
            //          Role ON Users.RoleID = Role.ID INNER JOIN
            //          Employees ON Users.EmployeeID = Employees.ID INNER JOIN
            //          Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
            //          SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID LEFT OUTER JOIN
            //          Drivers ON Tickets.DriverID = Drivers.ID LEFT OUTER JOIN
            //          SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID LEFT OUTER JOIN
            //          CompanyDiscount ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue
            //          WHERE     (Role.ID = 2) and dbo.Tickets.ID = " + idTicket + " ";

            //string sql = @"SELECT dbo.lnkTicketAddon.AddonID, dbo.lnkTicketAddon.Quantity, dbo.lnkTicketAddon.Price, dbo.lnkTicketAddon.Total, dbo.Addons.Name
            //      FROM  dbo.lnkTicketAddon LEFT OUTER JOIN
            //      dbo.Addons ON dbo.lnkTicketAddon.AddonID = dbo.Addons.ID Where dbo.lnkTicketAddon.TicketID = " + idTicket + "";

            //SQLConn.Preview_ticket(query, sql);



            var Qur = "Select " +
          "Tickets.ID,  " +
          "CAST(Tickets.StartTime AS time(0)) AS StartTime, " +
          "Tickets.StartDate, " +
          "Tickets.DurationValue,  " +
          "Tickets.VAT,  " +
          "Tickets.PriceAfterDiscount,  " +
          "Tickets.PriceAfterVAT, " +
          "Tickets.PayCash,  " +
          "Tickets.PayCard, " +
          "Tickets.DiscountAmount, " +
          "CompanyDiscount.CompanyName,  " +
          "CompanyDiscount.DiscountValue,  " +
          "Customers.Name AS CustomerName,  " +
          "Customers.Mobile,  " +
          "Customers.NID, " +
          "SeaTransportType.Name AS SeaType, " +
          "SeaTransport.Name AS SeaTransportName, " +
          "Drivers.Name AS DriverName, " +
          "Users.UserName AS CashierName, " +
          "Tickets.Note, " +
          "lnkTicketAddon.Quantity, " +
          "lnkTicketAddon.Price, " +
          "lnkTicketAddon.Total, " +
          "Addons.Name, " +
          "Customers.Taxnumber, " +
          "Tickets.Paytamara, " +
          "Tickets.Paytransfer " +
          "From Tickets " +
          "INNER JOIN Customers " +
          "ON Tickets.CustomerID = Customers.ID " +
          "LEFT OUTER JOIN SeaTransport " +
          "ON Tickets.SeaTransportID = SeaTransport.ID " +
          "INNER JOIN SeaTransportType " +
          "ON Tickets.SeaTransportTypeID = SeaTransportType.ID " +
          "LEFT OUTER JOIN CompanyDiscount " +
          "ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue " +
          "LEFT OUTER JOIN Drivers " +
          "ON Tickets.DriverID = Drivers.ID " +
          "INNER JOIN Users " +
          "ON Users.ID = Tickets.UserID " +
          "Left Outer Join lnkTicketAddon " +
          "On lnkTicketAddon.TicketID = Tickets.ID " +
          "Left Outer Join Addons " +
          "On lnkTicketAddon.AddonID = Addons.ID " +
          "Where Tickets.ID = " + idTicket + " ";
            SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            SQLConn.ConnDB();
            SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            QRbill qrbill = new QRbill();
            QRds ds = new QRds();
            var ISTax = false;
            var Taxnum = "";
            while (SQLConn.dr.Read())
            {
                var Ticketid = SQLConn.dr[0].ToString();
                var Customername = SQLConn.dr[12].ToString();
                var Customerphone = SQLConn.dr[13].ToString();
                var Customerid = SQLConn.dr[14].ToString();
                var Cashiername = SQLConn.dr[18].ToString();
                var Seatransportname = SQLConn.dr[16].ToString();
                var Seatransporttype = SQLConn.dr[15].ToString();
                var Valuetime = SQLConn.dr[3].ToString();
                var Date = SQLConn.dr[2].ToString();
                var Time = SQLConn.dr[1].ToString();
                var Drivername = SQLConn.dr[17].ToString();
                var Discounttype = SQLConn.dr[11].ToString();
                var Totalafterdiscound = SQLConn.dr[5].ToString();
                var Vat = SQLConn.dr[4].ToString();
                var Priceaftervat = SQLConn.dr[6].ToString();
                var Note = SQLConn.dr[19].ToString();
                var AdQuantity = SQLConn.dr[20].ToString();
                var AdPrice = SQLConn.dr[21].ToString();
                var AdTotal = SQLConn.dr[22].ToString();
                var AdName = SQLConn.dr[23].ToString();
                var Discound = SQLConn.dr[9].ToString();
                var bPaycash = SQLConn.dr[7].ToString();
                var bPaycard = SQLConn.dr[8].ToString();
                Paytamara = SQLConn.dr["Paytamara"].ToString();
                Paytrans = SQLConn.dr["Paytransfer"].ToString();
                if (AdQuantity == "" && AdPrice == "" && AdTotal == "")
                {
                    AdQuantity = "0.00";
                    AdPrice = "0.00";
                    AdTotal = "0.00";
                }
                var Taxnumber = SQLConn.dr["Taxnumber"].ToString();
                if (Taxnumber != "")
                {
                    ISTax = true;
                    Taxnum = Taxnumber;
                }
                ds.Tickts.Rows.Add(new object[] {
                        Ticketid,Customername,Customerphone,Customerid,Cashiername,
                        Seatransportname,Seatransporttype,Valuetime,Date,Time,
                        Drivername,Discounttype,Totalafterdiscound,Vat,Priceaftervat,
                        Photo,Note,AdQuantity,AdPrice,AdTotal,
                        AdName,Discound,bPaycash,bPaycard,Paytrans
                    });
            }
            //string sql = @"SELECT dbo.lnkTicketAddon.AddonID, dbo.lnkTicketAddon.Quantity, dbo.lnkTicketAddon.Price, dbo.lnkTicketAddon.Total, dbo.Addons.Name
            //  FROM  dbo.lnkTicketAddon LEFT OUTER JOIN
            //  dbo.Addons ON dbo.lnkTicketAddon.AddonID = dbo.Addons.ID Where dbo.lnkTicketAddon.TicketID = " + ticketId + "";
            SQLConn.conn.Close();
            //SQLConn.Preview_ticket("", sql);

            qrbill.SetDataSource(ds);
            qrbill.SetParameterValue("Tamara", Paytamara);
            qrbill.SetParameterValue("Timelatter", Coutput);
            if (ISTax)
            {
                qrbill.SetParameterValue("Taxnutitle", " : الرقم الضريبي");
                qrbill.SetParameterValue("Taxnum", Taxnum);
            }
            else
            {
                qrbill.SetParameterValue("Taxnutitle", "");
                qrbill.SetParameterValue("Taxnum", "");
            }
            qrbill.PrintOptions.PrinterName = Properties.Settings.Default.Printername;
            qrbill.PrintToPrinter(1, true, 1, 1);
            QRPic.Image = null;
        }
        /* private void AddTicket()
         {
             // Add new customer
             if (!IsExitingClient())
             {
                 if (btnSave.Text == "حفظ")
                 {
                     AddCustomerFunction();
                     // ClearCustomerInfoFunction();
                 }
             }


             ticketId = 0;
             //Validation

             if (txtCustMobile.Text != null && (txtCustMobile.Text.Length < 10 || txtCustMobile.Text.Length > 10))
             {
                 Interaction.MsgBox("الرجاء التثبت من رقم الجوال");
                 return;
             }
             if (int.Parse(cmbTypeID.SelectedValue.ToString()) == 0)
             {
                 Interaction.MsgBox("من فضلك إختر نوع الواسطة البحرية");
                 return;
             }
             //if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
             //{
             //    Interaction.MsgBox("من فضلك إختر الواسطة البحرية");
             //    return;
             //}
             if (string.IsNullOrEmpty(lblCustIDHidden.Text) || (!int.TryParse(lblCustIDHidden.Text.ToString(), out int a)) || string.IsNullOrEmpty(txtCustMobile.Text)
                 || string.IsNullOrEmpty(txtCustName.Text) || string.IsNullOrEmpty(txtCustNID.Text))
             {
                 Interaction.MsgBox("من فضلك إختر بيانات العميل");
                 return;
             }
             if (cmbDuration.SelectedValue == null)
             {
                 Interaction.MsgBox("من فضلك إختر مدة الرحلة");
                 return;
             }
             decimal totalCashAndBank = 0, totalAfterVAT = 0;
             if (Decimal.TryParse(lblTotalCashAndBank.Text, out totalCashAndBank))
             {
                 if (Decimal.TryParse(lblTotalAfterVAT.Text, out totalAfterVAT))
                 {
                     if (totalCashAndBank != totalAfterVAT)
                     {
                         Interaction.MsgBox("المبلغ المدفوع لايطابق الإجمالى");
                         return;
                     }
                 }
                 else
                 {
                     Interaction.MsgBox("المبلغ المدفوع لايطابق الإجمالى");
                     return;
                 }
             }
             else
             {
                 Interaction.MsgBox("المبلغ المدفوع لايطابق الإجمالى");
                 return;
             }

             if (string.IsNullOrEmpty(lblCustIDHidden.Text))
             {
                 Interaction.MsgBox(lblCustNotFound.Text);
                 return;
             }
             if (cmbDrivers.SelectedValue == null)
             {
                 //Interaction.MsgBox("من فضلك إختر السائق");
                 //return;
             }
             var b = ((DataRowView)cmbDuration.SelectedItem).Row[2].ToString();// Take the value on minutes of duration

             TimeSpan TicketDuration = new TimeSpan(0, int.Parse(b), 0);

             DateTime endTime = dtpStartDate.Value;
             //if (dtpStartTime.Value.TimeOfDay.Add(TicketDuration).TotalHours > 24)
             //{
             endTime = dtpStartDate.Value.Date.Add(dtpStartTime.Value.TimeOfDay.Add(TicketDuration));
             //}           

             decimal payCash = 0, payCard = 0;
             if (!string.IsNullOrEmpty(txtpaycash.Text))
                 Decimal.TryParse(txtpaycash.Text, out payCash);

             if (!string.IsNullOrEmpty(txtpaycard.Text))
                 Decimal.TryParse(txtpaycard.Text, out payCard);

             decimal discountValue = 0;
             if (!string.IsNullOrEmpty(txtDiscountPercent.Text) && string.IsNullOrEmpty(txtDiscountValue.Text))
             {
                 decimal DiscountPercent = Common.ConvertTxtToDecimal(txtDiscountPercent.Text.ToString() != "" ? txtDiscountPercent.Text.ToString() : "0");
                 discountValue = (PriceBeforeDiscount * DiscountPercent) / 100;
             }
             else
             {
                 Decimal.TryParse(txtDiscountValue.Text, out discountValue);
             }
             //Validation
             int newid;
             try
             {

                 SQLConn.sqL = @"INSERT INTO Tickets (StartDate,StartTime,EndTime,SeaTransportTypeID,SeaTransportID,UserID,
                 DriverID,CustomerID, DurationID, DurationValue,DiscountAmount,DiscountPercent,PriceAfterDiscount,VAT,PriceAfterVAT,PayCash,PayCard)
                 Values(@StartDate,@StartTime,@EndTime, @SeaTransportTypeID,@SeaTransportID,
                 @UserID,@DriverID,@CustomerID,@DurationID, @DurationValue,@DiscountAmount,@DiscountPercent,@PriceAfterDiscount,@VAT,@PriceAfterVAT,@PayCash,@PayCard);
                 SELECT CAST(scope_identity() AS int)";

                 SQLConn.ConnDB();
                 SQLConn.BeginTransaction();

                 SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                 SQLConn.cmd.Parameters.AddWithValue("@ID", int.Parse(txtTicketNo.Text));
                 SQLConn.cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                 SQLConn.cmd.Parameters.AddWithValue("@StartTime", dtpStartTime.Value.TimeOfDay);
                 SQLConn.cmd.Parameters.AddWithValue("@EndTime", endTime.TimeOfDay);

                 SQLConn.cmd.Parameters.AddWithValue("@SeaTransportTypeID", cmbTypeID.SelectedValue);
                 SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", cmbSeaTransportID.SelectedValue);
                 SQLConn.cmd.Parameters.AddWithValue("@DriverID", cmbDrivers.SelectedValue);
                 SQLConn.cmd.Parameters.AddWithValue("@CustomerID", int.Parse(lblCustIDHidden.Text));
                 //DurationID
                 SQLConn.cmd.Parameters.AddWithValue("@DurationID", cmbDuration.SelectedValue);
                 SQLConn.cmd.Parameters.AddWithValue("@DurationValue", b);
                 //var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();

                 SQLConn.cmd.Parameters.AddWithValue("@DiscountAmount", discountValue);
                 SQLConn.cmd.Parameters.AddWithValue("@DiscountPercent", Common.ConvertTxtToDecimal(txtDiscountPercent.Text != "" ? txtDiscountPercent.Text : "0"));
                 SQLConn.cmd.Parameters.AddWithValue("@PriceAfterDiscount", Common.ConvertTxtToDecimal(lblPriceAfterDiscount.Text));
                 SQLConn.cmd.Parameters.AddWithValue("@VAT", Common.ConvertTxtToDecimal(lblVAT.Text));
                 SQLConn.cmd.Parameters.AddWithValue("@PriceAfterVAT", Common.ConvertTxtToDecimal(lblTotalAfterVAT.Text));
                 // SQLConn.cmd.Parameters.AddWithValue("@PayementType", SqlDbType.Int).Value = PayementType;
                 SQLConn.cmd.Parameters.AddWithValue("@UserID", Data.UserID);
                 SQLConn.cmd.Parameters.AddWithValue("@PayCash", payCash);
                 SQLConn.cmd.Parameters.AddWithValue("@PayCard", payCard);

                 ticketId = (int)SQLConn.cmd.ExecuteScalar();

                 //Update Treasury Balance For Current User 
                 if (txtpaycash.Text != "")
                 {
                     SQLConn.GetTreasuryIDForCurrentUser(Data.UserID);

                     //update TreasuryTransactions
                     if (Data.UserTreasuryID > 0)
                     {
                         SQLConn.UpdateUserTreasuryTicketTransactions(Data.UserTreasuryID, payCash, SQLConn.trans, ticketId, "إظافة تذكرة ");

                         SQLConn.UpdateUserTreasury(Data.UserTreasuryID, payCash, SQLConn.trans);
                     }
                 }
                 //Update Bank Account Balance
                 if (txtpaycard.Text != "")
                 {
                     //Decimal.TryParse(txtpaycard.Text, out payCard);

                     int bankId = GetBankAccountID();

                     if (bankId > 0)
                     {
                         SQLConn.UpdateBankAccountTransactions(bankId, payCard, SQLConn.trans);
                         SQLConn.UpdateBankAccountByID(bankId, payCard, SQLConn.trans);
                     }
                 }

                 decimal quantity = 0, price = 0, total = 0;
                 //Add lnkTicketAddon 
                 if (dgvAddons.Rows.Count > 0)
                 {
                     for (int i = 0; i < dgvAddons.Rows.Count - 1; i++)
                     {
                         var addonID = int.Parse(dgvAddons.Rows[i].Cells["dgvAddonID"].Value.ToString());
                         if (dgvAddons.Rows[i].Cells["dgvQuantity"] != null && dgvAddons.Rows[i].Cells["dgvQuantity"].Value != null && !string.IsNullOrEmpty(dgvAddons.Rows[i].Cells["dgvQuantity"].Value.ToString()))
                             quantity = Common.ConvertTxtToDecimal(dgvAddons.Rows[i].Cells["dgvQuantity"].Value.ToString());
                         if (dgvAddons.Rows[i].Cells["dgvPrice"] != null && dgvAddons.Rows[i].Cells["dgvPrice"].Value != null && !string.IsNullOrEmpty(dgvAddons.Rows[i].Cells["dgvPrice"].Value.ToString()))
                             price = Common.ConvertTxtToDecimal(dgvAddons.Rows[i].Cells["dgvPrice"].Value.ToString());

                         total = price * quantity;
                         AddTicketsAddons(ticketId, addonID, quantity, price, total, SQLConn.trans);
                     }
                 }

                 // Update SeaTransportID : isBusy= true 
                 UpdateSeaTransportByID(true, SQLConn.trans);

                 //SQLConn.ConnDB();
                 SQLConn.trans.Commit();
                 ClearFields();
                 txtCustMobile.Focus();

                 //                DateTime dateStart = DateTime.Now;
                 //                DateTime dateEnd = DateTime.Now;
                 //                // We use the UserId Corresponding to the cashier
                 //                frmReportPrint frmReportPrint = new frmReportPrint(dateStart, dateEnd, ticketId, "Ticket");
                 //#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                 //                _ = frmReportPrint.ShowDialog();

                 string query = @" SELECT  Tickets.ID, Tickets.StartDate,  CAST(Tickets.StartTime AS time(0)) AS StartTime, 
                         Customers.Name AS CustomerName, Customers.Mobile, 
                         Customers.NID, SeaTransport.Name AS SeaTransportName, 
                         Tickets.DurationValue, Tickets.VAT, Tickets.PriceAfterDiscount, 
                         Tickets.PriceAfterVAT, Employees.Name AS CashierName, 
                         SeaTransportType.Name AS SeaType, Drivers.Name AS DriverName, Tickets.PayCash, 
                       Tickets.PayCard, CompanyDiscount.CompanyName, CompanyDiscount.DiscountValue, Tickets.DiscountAmount

                       FROM         Tickets INNER JOIN
                       Users ON Tickets.UserID = Users.ID INNER JOIN
                       Role ON Users.RoleID = Role.ID INNER JOIN
                       Employees ON Users.EmployeeID = Employees.ID INNER JOIN
                       Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                       SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID LEFT OUTER JOIN
                       Drivers ON Tickets.DriverID = Drivers.ID LEFT OUTER JOIN
                       SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID LEFT OUTER JOIN
                       CompanyDiscount ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue
                       WHERE     (Role.ID = 2) and dbo.Tickets.ID = " + ticketId + " ";

                 string sql = @"SELECT dbo.lnkTicketAddon.AddonID, dbo.lnkTicketAddon.Quantity, dbo.lnkTicketAddon.Price, dbo.lnkTicketAddon.Total, dbo.Addons.Name
                   FROM  dbo.lnkTicketAddon LEFT OUTER JOIN
                   dbo.Addons ON dbo.lnkTicketAddon.AddonID = dbo.Addons.ID Where dbo.lnkTicketAddon.TicketID = " + ticketId + "";

                 SQLConn.Preview_ticket(query, sql);
             }
             catch (Exception ex)
             {
                 SQLConn.trans.Rollback();
                 Interaction.MsgBox(ex.ToString());
             }
             finally
             {
                 SQLConn.cmd.Dispose();
                 SQLConn.conn.Close();
             }
         }
        */
        private void UpdateSeaTransportByID(bool isBusy, SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = "Update SeaTransport Set IsBusy =   @IsBusy";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@IsBusy", isBusy ? 1 : 0);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void UpdateTicketsAddons(int TicketID, int AddonID, decimal Quantity, decimal Price, decimal Total, SqlTransaction transaction)
        {
            try
            {
                //TODO : Redone this code : verify if addons is there the update it else insert new one
                SQLConn.sqL = "UPDATE  lnkTicketAddon SET TicketID=@TicketID,AddonID=@AddonID,Quantity=@Quantity,Price=@Price,Total=@Total Where TicketID=@TicketID";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@TicketID", TicketID);
                SQLConn.cmd.Parameters.AddWithValue("@AddonID", AddonID);
                SQLConn.cmd.Parameters.AddWithValue("@Quantity", Quantity);
                SQLConn.cmd.Parameters.AddWithValue("@Price", Price);
                SQLConn.cmd.Parameters.AddWithValue("@Total", Total);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                //SQLConn.cmd.Dispose();
                //SQLConn.conn.Close();
            }
        }

        private void AddTicketsAddons(int TicketID, int AddonID, decimal Quantity, decimal Price, decimal Total, SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = "INSERT INTO lnkTicketAddon(TicketID,AddonID,Quantity,Price,Total) VALUES(@TicketID,@AddonID,@Quantity,@Price,@Total)";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@TicketID", TicketID);
                SQLConn.cmd.Parameters.AddWithValue("@AddonID", AddonID);
                SQLConn.cmd.Parameters.AddWithValue("@Quantity", Quantity);
                SQLConn.cmd.Parameters.AddWithValue("@Price", Price);
                SQLConn.cmd.Parameters.AddWithValue("@Total", Total);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                //SQLConn.cmd.Dispose();
                //SQLConn.conn.Close();
            }
        }
        private void cblstPayementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int selected = cblstPayementType.SelectedIndex;
            //for (int i = 0; i < cblstPayementType.Items.Count; i++)
            //{
            //    if (cblstPayementType.GetItemChecked(i))
            //    {
            //        var row = ((DataRowView)cblstPayementType.Items[i]);
            //        PayementType = int.Parse(row[0].ToString());

            //    }
            //}
        }



        private void txtCustNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                IsExitingClientByNID();

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtCustName.Focus();
        }

        private bool IsExitingClientByMobile()
        {
            //if (string.IsNullOrEmpty(txtCustMobile.Text) || (!string.IsNullOrEmpty(txtCustMobile.Text) && (txtCustMobile.Text.Length < 10 || txtCustMobile.Text.Length > 10)))
            //{
            //    Interaction.MsgBox("الرجاء التثبت من رقم الجوال");
            //    return false;
            //}

            if (!string.IsNullOrEmpty(txtCustMobile.Text))
            {
                DataTable dtblCust = SQLConn.GetCustomerByMobile(txtCustMobile.Text);
                if (dtblCust.Rows.Count > 0)
                {
                    txtCustName.Text = dtblCust.Rows[0]["Name"].ToString();
                    txtCustMobile.Text = dtblCust.Rows[0]["Mobile"].ToString();
                    lblCustIDHidden.Text = dtblCust.Rows[0]["ID"].ToString();
                    txtCustNID.Text = dtblCust.Rows[0]["NID"].ToString();
                    lblCustNotFound.Visible = false;

                    txtCustNID.Focus();
                    return true;
                }
            }
            return false;
        }

        private bool IsExitingClientByNID()
        {
            //if (string.IsNullOrEmpty(txtCustNID.Text) || (!string.IsNullOrEmpty(txtCustNID.Text) && (txtCustNID.Text.Length < 10 || txtCustNID.Text.Length > 10)))
            //{
            //    Interaction.MsgBox("الرجاء التثبت من رقم الهوية");
            //    return false;
            //}

            if (!string.IsNullOrEmpty(txtCustNID.Text))
            {
                DataTable dtblCust = SQLConn.GetCustomerByNID(txtCustNID.Text);
                if (dtblCust.Rows.Count > 0)
                {
                    txtCustName.Text = dtblCust.Rows[0]["Name"].ToString();
                    txtCustMobile.Text = dtblCust.Rows[0]["Mobile"].ToString();
                    lblCustIDHidden.Text = dtblCust.Rows[0]["ID"].ToString();
                    txtCustNID.Text = dtblCust.Rows[0]["NID"].ToString();
                    lblCustNotFound.Visible = false;

                    txtCustNID.Focus();
                    return true;
                }
            }
            return false;
        }

        private void txtCustMobile_KeyDown(object sender, KeyEventArgs e)
        {
            IsExitingClientByMobile();
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtCustNID.Focus();
        }

        #region Add New customer
        public bool CheckIfNIDDublicate(string NID)
        {
            bool IsNIDDublicated = false;
            try
            {
                SQLConn.sqL = @"select Count(NID) from Customers where NID = @NID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@NID", NID);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    IsNIDDublicated = true;
                }
                else
                {
                    IsNIDDublicated = false;
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
            return IsNIDDublicated;
        }

        public bool CheckIfMobileDublicate(string Mobile)
        {

            bool IsMobileDublicated = false;
            try
            {

                SQLConn.sqL = @"select Count(Mobile) from Customers where Mobile = @Mobile";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Mobile", Mobile);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    IsMobileDublicated = true;
                }
                else
                {
                    IsMobileDublicated = false;
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
            return IsMobileDublicated;


        }

        public bool CheckIfCustomerNameDublicate(string ClientName)
        {

            bool IsNameDublicated = false;
            try
            {

                SQLConn.sqL = @"select Count(Name) from Customers where Name = @ClientName";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@ClientName", ClientName);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    IsNameDublicated = true;
                }
                else
                {
                    IsNameDublicated = false;

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
            return IsNameDublicated;


        }


        private void AddCustomerFunction()
        {
            try
            {
                if (txtCustName.Text.Trim() == string.Empty)
                {
                    Interaction.MsgBox("الرجاء إدخال إسم العميل.", MsgBoxStyle.Information, "التذاكر");
                    return;
                }
                if (txtCustMobile.Text != null && (txtCustMobile.Text.Length < 10 || txtCustMobile.Text.Length > 10))
                {
                    Interaction.MsgBox("الرجاء التثبت من رقم الجوال");
                    return;
                }

                //if (CheckIfCustomerNameDublicate(txtCustName.Text))
                //{
                //    Interaction.MsgBox("لايمكن تكرار إسم العميل");
                //    return;
                //}
                if (CheckIfMobileDublicate(txtCustMobile.Text))
                {
                    Interaction.MsgBox("رقم الموبايل مستخدم من قبل");
                    return;
                }
                if (CheckIfNIDDublicate(txtCustNID.Text))
                {
                    Interaction.MsgBox("رقم الهوية مستخدم من قبل");
                    return;
                }


                SQLConn.ConnDB();
                //SQLConn.BeginTransaction();
                SQLConn.sqL = "INSERT INTO Customers(Name,Mobile,NID) VALUES (@Name,@Mobile,@NID) ;SELECT CAST(scope_identity() AS int)";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtCustName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Mobile", txtCustMobile.Text);
                SQLConn.cmd.Parameters.AddWithValue("@NID", txtCustNID.Text);
                int newID = (int)SQLConn.cmd.ExecuteScalar();
                if (newID > 0)
                {
                    // Get the id of the customer
                    lblCustIDHidden.Text = newID.ToString();
                }
                else
                {
                    lblCustNotFound.Visible = true;
                    Interaction.MsgBox(lblCustNotFound.Text, MsgBoxStyle.Information, "العملاء");
                    return;
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

        public void ClearCustomerInfoFunction()
        {
            try
            {
                txtCustName.Clear();
                txtCustMobile.Clear();
                txtCustNID.Clear();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        #endregion

        public int GetDefaultDriverID(int SeaTransportID)
        {

            int DriverID = 0;
            try
            {

                SQLConn.sqL = @"select DriverID from SeaTransport where ID = @SeaTransportID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", SeaTransportID);
                if (SQLConn.cmd.ExecuteScalar() != System.DBNull.Value)
                {
                    DriverID = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
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
            return DriverID;


        }
        //Insert Null Value
        private SqlParameter SetDBNullIfEmpty(string Parmname, string Parmvalue)
        {
            return new SqlParameter(Parmname, String.IsNullOrEmpty(Parmvalue) ? DBNull.Value : (object)Parmvalue);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtSearchDriverByID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //Search Driver By Primary Key
                if (!string.IsNullOrEmpty(txtSearchDriverByID.Text) && int.TryParse(txtSearchDriverByID.Text, out int DriverByID) && DriverByID > 0)
                {
                    DataTable Driver = GetDriver(DriverByID);
                    if (Driver.Rows.Count != 0)
                    {
                        cmbDrivers.SelectedValue = Driver.Rows[0]["ID"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("لم يتم ايجاد سائق برقم'" + txtSearchDriverByID.Text + "'");
                    }
                }
                cmbDuration.Focus();
            }
        }

        public DataTable GetDriver(int DriverID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select ID,Name from Drivers where ID = @Id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", DriverID);
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
        public DataTable GetSeaTransportByID(int SeaTransportID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = "select ID,Name,TypeID from SeaTransport where NumberReference = @Id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Id", SeaTransportID);
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

        private void txtSearchBoatByID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbSeaTransportID.SelectedValue = int.Parse(txtSearchBoatByID.Text);
                if (!string.IsNullOrEmpty(txtSearchBoatByID.Text) && int.TryParse(txtSearchBoatByID.Text, out int boatID) && boatID > 0)
                {
                    //Search Driver By Primary Key
                    DataTable SeaTransport = GetSeaTransportByID(boatID);
                    if (SeaTransport.Rows.Count != 0)
                    {
                        cmbSeaTransportID.DataSource = SeaTransport;
                        cmbTypeID.SelectedValue = SeaTransport.Rows[0]["TypeID"].ToString();
                        cmbSeaTransportID.SelectedValue = SeaTransport.Rows[0]["ID"].ToString();
                        cmbSeaTransportID.DisplayMember = SeaTransport.Rows[0]["Name"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("لم يتم ايجاد واسطة بحرية برقم'" + txtSearchBoatByID.Text + "'");
                    }
                }
                txtSearchDriverByID.Focus();
            }
        }

        private void txtpaycash_TextChanged(object sender, EventArgs e)
        {
            if (txtpaycash.Text != "")
            {
                GetTotalPay();
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
            if (textBox6.Text == "")
            {
                textBox6.Text = "0.00";
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
            Decimal.TryParse(textBox6.Text, out TamaraValue);
            decimal TransValue = 0;
            Decimal.TryParse(transpay.Text, out TransValue);
            decimal totalPay = CashValue + BankValue + TamaraValue + TransValue;
            lblTotalCashAndBank.Text = totalPay.ToString();
        }

        private void txtpaycard_TextChanged(object sender, EventArgs e)
        {

            if (txtpaycard.Text != "")
            {
                GetTotalPay();
            }

        }
        DataTable DisCompanydtbl = new DataTable();
        private readonly object txtTreasuryName;

        public void CompanyDiscountFill()
        {

            try
            {
                SQLConn.ConnDB();

                DisCompanydtbl = SQLConn.getTable("SELECT ID,CompanyName,DiscountValue FROM CompanyDiscount where IsActive = 1 and EndDate >= GetDate() ");
                DataRow dr = DisCompanydtbl.NewRow();
                dr["ID"] = 0;
                dr["CompanyName"] = "--اختر--";
                DisCompanydtbl.Rows.InsertAt(dr, 0);
                cmbCompanyDiscount.DataSource = DisCompanydtbl;
                cmbCompanyDiscount.ValueMember = "ID";
                cmbCompanyDiscount.DisplayMember = "CompanyName";
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
        private void cmbCompanyDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCompanyDiscount.SelectedItem != null)
            {
                var SelectedValue = ((DataRowView)cmbCompanyDiscount.SelectedItem).Row[0].ToString();
                if (int.Parse(SelectedValue) > 0)
                {
                    DataRow x = DisCompanydtbl.AsEnumerable().Where
                    (r => r.Field<int>("ID") == int.Parse(SelectedValue.ToString())).FirstOrDefault();
                    if (x != null)
                    {
                        txtDiscountPercent.Text = x["DiscountValue"].ToString();

                    }
                }
            }
        }

        #region Accounting
        //Get treasury ID For Current User 
        //private int GetTreasuryIDForCurrentUser(int userid)
        //{
        //    int ID = 0;
        //    try
        //    {
        //        SQLConn.sqL = "Select ID From Treasury Where UserID = @id";
        //        //SQLConn.ConnDB();
        //        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
        //        SQLConn.cmd.Parameters.AddWithValue("@id", userid);
        //        if (SQLConn.cmd.ExecuteScalar() != null)
        //        {
        //            ID = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
        //            Data.UserTreasuryID = ID;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox(ex.ToString());
        //    }
        //    finally
        //    {
        //        //SQLConn.cmd.Dispose();
        //        //SQLConn.conn.Close();
        //    }
        //    return ID;
        //}

        private int GetBankAccountID()
        {
            int id = 0;
            try
            {
                SQLConn.sqL = "Select top(1) ID From BankAccounts";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);

                if (SQLConn.cmd.ExecuteScalar() != null)
                {
                    id = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                //SQLConn.cmd.Dispose();
                //SQLConn.conn.Close();
            }
            return id;
        }


        //Select Treasury Balance 
        private decimal GetTreasuryBalance(int treasuryID, SqlTransaction trans)
        {
            decimal Balance = 0.0m;
            try
            {

                SQLConn.sqL = "Select Balance From Treasury Where ID = @id";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, trans);
                SQLConn.cmd.Parameters.AddWithValue("@id", treasuryID);
                if (SQLConn.cmd.ExecuteScalar() != null)
                {
                    Balance = Common.ConvertTxtToDecimal(SQLConn.cmd.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                //SQLConn.cmd.Dispose();
                //SQLConn.conn.Close();
            }
            return Balance;
        }
        ////Update Casheir Treasury 
        //private void UpdateUserTreasury(int treasuryID, decimal amount, SqlTransaction transaction)
        //{
        //    try
        //    {
        //        SQLConn.sqL = "Update Treasury Set Balance =Balance +  @NewBalance where ID = @treasuryID";
        //        //SQLConn.ConnDB();
        //        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
        //        SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
        //        SQLConn.cmd.Parameters.AddWithValue("@treasuryID", @treasuryID);
        //        SQLConn.cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox(ex.ToString());
        //    }
        //    finally
        //    {
        //        //SQLConn.cmd.Dispose();
        //        //SQLConn.conn.Close();
        //    }

        //}


        //private void UpdateUserTreasuryTransactions(int treasuryID, decimal amount, SqlTransaction transaction)
        //{
        //    try
        //    {
        //        SQLConn.sqL = "insert into TreasuryTransactions (TransfertAmount, treasuryID) values( @NewBalance, @treasuryID )";
        //        //SQLConn.ConnDB();
        //        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
        //        SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
        //        SQLConn.cmd.Parameters.AddWithValue("@treasuryID", @treasuryID);
        //        SQLConn.cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox(ex.ToString());
        //    }
        //    finally
        //    {
        //        //SQLConn.cmd.Dispose();
        //        //SQLConn.conn.Close();
        //    }
        //}
        ////Update BankAccountTransactions
        //private void UpdateBankAccountTransactions(int bankId, decimal amount, SqlTransaction transaction)
        //{
        //    try
        //    {
        //        SQLConn.sqL = "insert into BankAccountTransactions (Amount, BankID) values( @NewBalance, @BankID )";
        //        //SQLConn.ConnDB();
        //        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
        //        SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
        //        SQLConn.cmd.Parameters.AddWithValue("@BankID", bankId);
        //        SQLConn.cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox(ex.ToString());
        //    }
        //    finally
        //    {
        //        //SQLConn.cmd.Dispose();
        //        //SQLConn.conn.Close();
        //    }
        //}


        //Update BanckAccount 
        private decimal GetBankAccountBalance(SqlTransaction transaction)
        {
            decimal Balance = 0.0m;
            try
            {

                SQLConn.sqL = "Select Balance From BankAccounts Where ID = 1";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);

                if (SQLConn.cmd.ExecuteScalar() != null && !string.IsNullOrEmpty(SQLConn.cmd.ExecuteScalar().ToString()))
                {
                    Balance = Common.ConvertTxtToDecimal(SQLConn.cmd.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                //SQLConn.cmd.Dispose();
                //SQLConn.conn.Close();
            }
            return Balance;
        }

        //private void UpdateBankAccount(decimal amount, SqlTransaction transaction)
        //{
        //    try
        //    {
        //        //Get Current Balance For Treasury
        //        //decimal currentBalance = GetBankAccountBalance(SQLConn.trans);
        //        SQLConn.sqL = "Update BankAccounts Set Balance = Balance +  @NewBalance";
        //        //SQLConn.ConnDB();
        //        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
        //        SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
        //        SQLConn.cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox(ex.ToString());
        //    }
        //    finally
        //    {
        //        //SQLConn.cmd.Dispose();
        //        //SQLConn.conn.Close();
        //    }
        //}
        #endregion

        /// <summary>
        /// Methode for printing tickets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (idTicket > 0)
            {
                frmPrintTicket pr = new frmPrintTicket(idTicket);
                pr.Show();
                pr.Hide();
            }
        }

        private void cmbTypeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtSearchBoatByID.Focus();
        }

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                cmbTypeID.Focus();
        }

        private void cmbDuration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtpaycard.Focus();
        }

        private void txtpaycard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                transpay.Focus();

        }

        private void txtpaycash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBox6.Focus();
            }
        }

        private void cmbSeaTransportID_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DQ();
            PrintTicket();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void cmbDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDrivers.SelectedIndex != -1)
            {
                txtSearchDriverByID.Text = cmbDrivers.SelectedValue.ToString();
                // If we also wanted to get the displayed text we could use
                // the SelectedItem item property:
                // string s = ((USState)ListBox1.SelectedItem).LongName;
            }

        }

        private void cmbDrivers_SelectedValueChanged(object sender, EventArgs e)
        {

            if (cmbDrivers.SelectedIndex != -1)
            {
                txtSearchDriverByID.Text = cmbDrivers.SelectedValue.ToString();
                // If we also wanted to get the displayed text we could use
                // the SelectedItem item property:
                // string s = ((USState)ListBox1.SelectedItem).LongName;
            }
        }

        private void txtSearchBoatByID_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void getcmbtype()
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
                        if (dgvAddons.Rows.Count > 1)
                        {
                            var AO = Convert.ToDecimal(lblAddonTotal.Text);
                            var Res = price + AO;
                        }
                        lblPriceAfterDiscount.Text = price.ToString();
                    }
                }
            }
            SetTotal();
        }
        private void Btnchangetot_Click(object sender, EventArgs e)
        {
            txtDiscountValue.Text = "0.00";
            lblPrice.Text = "0.00";
            lblTotal.Text = "0.00";
            lblVAT.Text = "0.00";
            lblTotalAfterVAT.Text = "0.00";
            var Duration = cmbDuration.Text; // 
            if (Duration != null)
            {
                var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();
                var price = GetPrice(int.Parse(SelectedValue), false, Duration);
                lblPrice.Text = price.ToString();
                if (dgvAddons.Rows.Count > 1)
                {
                    var AO = Convert.ToDecimal(lblAddonTotal.Text);
                    var Res = price + AO;
                }
                lblPriceAfterDiscount.Text = price.ToString();
            }
            SetTotal();
            // لو السعر لم يتعدى المطلوب
            var DP = Convert.ToDouble(txtDiscountPercent.Text);
            var Perce = DP / 100;
            // AD = Aollow Discount
            var AD = Convert.ToDouble(lblTotalAfterVAT.Text) * Perce;
            var GAD = Math.Round(AD, 2).ToString();


            //السعر الحالي
            var Price = Convert.ToDouble(txtchangetot.Text);
            var TBV = Price / 1.15;
            var GTBV = Math.Round(Convert.ToDouble(TBV), 2).ToString();
            if (ISVAT)
            {
                // الضريبة
                var Tax = Convert.ToDouble(GTBV) * VP;
                var GTax = Math.Round(Convert.ToDouble(Tax), 2).ToString();
                

                // الخصم
                var Disc = Convert.ToDouble(lblTotal.Text) - TBV;
                var GDisc = Math.Round(Convert.ToDouble(Disc), 2).ToString();
                //السعر الكلي
                var TAV = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(GDisc);

                if (Disc <= AD)
                {
                    lblVAT.Text = "0.00";
                    lblTotalAfterVAT.Text = "0.00";
                    lblTotalAfterVAT.Text = txtchangetot.Text;
                    lblVAT.Text = GTax;
                    txtDiscountValue.Text = Convert.ToString(GDisc);
                    lblTotal.Text = Convert.ToString(TAV);
                    lblPriceAfterDiscount.Text = lblTotal.Text;
                }
                else
                {
                    MessageBox.Show("غير مسموح لك بأضافة اكثر من " + GAD + "");
                    return;
                }
            }
        }
        double VP;
        bool ISVAT;
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
        private void button1_Click_3(object sender, EventArgs e)
        {
            var a = Convert.ToDecimal(lblTotalAfterVAT.Text);
            var CA = a.ToString();
            if (CA.Contains("."))
            {
                var Res = Convert.ToDouble(String.Format("{0:0}", a));


                lblVAT.Text = "0.00";
                lblTotalAfterVAT.Text = "0.00";
                lblTotalAfterVAT.Text = Res.ToString();

                ////السعر الحالي
                var Price = Res;
                var TBV = Price / 1.15;
                var GTBV = Math.Round(Convert.ToDouble(TBV), 2).ToString();
                if (ISVAT)
                {
                    // الضريبة
                    var Tax = Convert.ToDouble(GTBV) * VP;
                    var GTax = Math.Round(Convert.ToDouble(Tax), 2).ToString();
                    lblVAT.Text = GTax;

                    // الخصم
                    var Disc = Convert.ToDouble(lblTotal.Text) - TBV;
                    var GDisc = Math.Round(Convert.ToDouble(Disc), 2).ToString();
                    txtDiscountValue.Text = Convert.ToString(GDisc);
                    //txtDiscountValue.Text = txtDiscountValue.Text;

                    //السعر الكلي
                    var TAV = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(GDisc);
                    lblTotal.Text = Convert.ToString(TAV);


                    lblPriceAfterDiscount.Text = lblTotal.Text;
                }
            }
        }

        private void cmbTypeID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var Duration = "0";

            var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();

            if (int.Parse(SelectedValue) > 0)
            {
                FillSeaTransportFill(int.Parse(SelectedValue));

                FillDuration();

                Duration = cmbDuration.Text; // 

                //if (Duration != null)
                //{
                //    var price = GetPrice(int.Parse(SelectedValue), false, Duration);
                //    lblPrice.Text = price.ToString();
                //    lblPriceAfterDiscount.Text = price.ToString();
                //}
            }
        }

        private void cmbDuration_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSeaTransportID.SelectedItem != null)
            {
                var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();
                if (int.Parse(SelectedValue) > 0)
                {
                    GetPrice();
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                GetTotalPay();
            }
        }

        private void transpay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtpaycash.Focus();
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                btnSave.Focus();
        }

        private void transpay_TextChanged(object sender, EventArgs e)
        {
            if (transpay.Text != "")
            {
                GetTotalPay();
            }
        }
    }
}
