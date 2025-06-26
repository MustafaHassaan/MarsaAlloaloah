using MarsaAlloaloah.CrystalReports;
using MarsaAlloaloah.CrystalReports.CQR;
using MarsaAlloaloah.Forms.Tickets;
using MarsaAlloaloah.Qrmodel;
using MarsaAlloaloah.Utility;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using QRCoder;
using SmartArabXLSX.Office.Word;
using SmartArabXLSX.Office2010.Excel;
using SmartArabXLSX.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Printing;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using static MarsaAlloaloah.dsMarsa;

namespace MarsaAlloaloah
{
    public partial class frmticket : Form
    {
        Boatorders Dsbo;
        public int Rentalid { get; set; }
        public DateTime DTS { get; set; }
        public DateTime DST { get; set; }
        public string STT { get; set; }
        public string STS { get; set; }
        public string DRV { get; set; }
        public string TDP { get; set; }
        public decimal Payed { get; set; }
        public decimal CRTPaycash { get; set; }
        public decimal CRTPaycard { get; set; }
        public decimal Cash { get; set; }
        public decimal Card { get; set; }

        public decimal Originalprice { get; set; }



        decimal PriceBeforeDiscount = 0.0m;
        decimal VatPercent = 0.0m;
        double VP;
        int PayementType;
        int ticketId = 0;
        //public static int MyProperty { get; set; }
        public int userid { get; set; }
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
        public frmticket()
        {
            InitializeComponent();
            userid = Data.UserID;
            Cheacdiscavilable();
            lbltextrent.Visible = false;
            lblrent.Visible = false;
        }
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
                    Cashierpercent.Text = Convert.ToString(Convert.ToInt32(Discountpercent));
                    //txtchangetot.Visible = false;
                    //Btnchangetot.Visible = false;
                }
            }
            return Discountpercent;
        }
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
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void frmticket_Load(object sender, EventArgs e)
        {
            
            Dsbo = new Boatorders();
            txtchangetot.Visible=false;
            Btnchangetot.Visible = false;
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
            Gvat();
            this.BackgroundImage = (Image)(Properties.Resources.BackgroundImage);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            lblCustIDHidden.Text = string.Empty;
            AddonsFill();
            lblAddonTotal.Text = "0.00";
            //GetProductNo();
            SeaTransportTypeFill();
            FillDuration();
            SelectVATValue();
            FillDrivers();
            CompanyDiscountFill();

            txtCustMobile.Focus();

            //for (int i = 0; i < comboBox3.Items.Count-1;i++)

            //{
            //    comboBox3.Items[i] = comboBox3.Items[i].ToString() + "دقيقة";
            //}

            dtpStartDate.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Now;
            if (Rentalid != 0)
            {
                dtpStartDate.Value = DTS;
                dtpStartTime.Value = DST;
                cmbTypeID.Text = STT;
                cmbSeaTransportID.Text = STS;
                cmbDuration.Text = DRV;
                txtDiscountPercent.Text = TDP;
                lbltextrent.Visible = true;
                lblrent.Visible = true;
            }
            else
            {
                paymentMethod.SelectedIndex = 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "التذاكر", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            label31.Visible = false;
            tamarapay.Visible = false;
            lblTotalCashAndBank.Text = "";
            txtchangetot.Clear();
            cmbTypeID.SelectedValue = -1;
            btnSave.Text = "حفظ";
            textBox5.Clear();
            txtAddonPrice.Text = "";
            txtAddonQty.Text = "";
            txtCustMobile.Text = "";
            txtCustName.Text = "";
            txtCustNID.Text = "";
            txtAddonPrice.Text = "";
            txtDiscountPercent.Clear();
            txtTicketNo.Text = "";
            cmbAddons.SelectedValue = -1;
            cmbDrivers.SelectedValue = -1;
            cmbSeaTransportID.SelectedValue = -1;
            lbldisc.Text = "0.00";
            txtDiscountValue.Text = "";
            txtNote.Clear();
            //dgvAddons.Rows.Clear();
            dgvAddons.DataSource = null;

            txtSearchBoatByID.Text = "";
            txtSearchDriverByID.Text = "";
            txtTicketNo.Clear();
            //Reset Ticket
            AddonsFill();
            //GetProductNo();
            SeaTransportTypeFill();
            FillDuration();
            SelectVATValue();
            cmbDuration.SelectedIndex = -1;
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
            lbltextrent.Visible = false;
            lblrent.Visible = false;
            dgvAddons.DataSource = null;
            if (dgvAddons.Rows.Count > 0)
                dgvAddons.Rows.Clear();

            lblTotalCashAndBank.Text = "0.00";
            Cheackpayment();
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
                    if (cmbAddons.SelectedValue.ToString() == InsertedRowID)

                    {
                        Interaction.MsgBox("لايمكن تكرار إضافة الإضافة");
                        return;
                    }
                }
                if (btnSave.Text == "حفظ")
                {
                    DataGridViewRow row = (DataGridViewRow)dgvAddons.Rows[0].Clone();
                    row.Cells[1].Value = ((DataRowView)cmbAddons.SelectedItem).Row[1].ToString();
                    row.Cells[2].Value = cmbAddons.SelectedValue;
                    row.Cells[0].Value = dgvAddons.Rows.Count;
                    row.Cells[3].Value = txtAddonPrice.Text;
                    row.Cells[4].Value = txtAddonQty.Text == "" ? "1" : txtAddonQty.Text;
                    row.Cells[5].Value = int.Parse(txtAddonQty.Text == "" ? "1" : txtAddonQty.Text) * int.Parse(txtAddonPrice.Text);
                    dgvAddons.Rows.Add(row);
                }
                else
                {

                    DataTable dataTable = (DataTable)dgvAddons.DataSource;
                    DataRow drToAdd = dataTable.NewRow();
                    drToAdd["Name"] = ((DataRowView)cmbAddons.SelectedItem).Row[1].ToString();
                    drToAdd["AddonID"] = cmbAddons.SelectedValue;
                    drToAdd["Price"] = txtAddonPrice.Text;
                    drToAdd["SlNo"] = dgvAddons.Rows.Count;
                    drToAdd["Quantity"] = txtAddonQty.Text == "" ? "1" : txtAddonQty.Text;
                    drToAdd["ID"] = 0;
                    dataTable.Rows.Add(drToAdd);
                    dataTable.AcceptChanges();
                    // dgvCustomers.Rows.Add(row);
                }
                lblAddonTotal.Text = GetAddonsTotal().ToString();

            }
            SetTotal();


        }
        private void cmbAddons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAddons.SelectedItem != null)
            {
                var SelectedValue = ((DataRowView)cmbAddons.SelectedItem).Row[0].ToString();
                if (int.Parse(SelectedValue) > 0)
                {
                    txtAddonPrice.Text = GetAddonPrice(int.Parse(SelectedValue)).ToString();
                }
            }
        }
        private decimal GetAddonsTotal()
        {
            decimal TotalAddon = 0.0m;
            for (int i = 0; i < dgvAddons.Rows.Count - 1; i++)
            {
                if (dgvAddons.Rows[i].Cells["Total"] != null && dgvAddons.Rows[i].Cells["Total"].Value != null
                    && !string.IsNullOrEmpty(dgvAddons.Rows[i].Cells["Total"].Value.ToString()))
                {
                    var AddonPrice = Common.ConvertTxtToDecimal(dgvAddons.Rows[i].Cells["Total"].Value.ToString());
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
                        WHERE (IsBusy = 1) and  (Tickets.StartDate = CAST(GETDATE() as DATE)) and(EndTime > CONVERT(TIME, SYSDATETIME()))
                        )" +
                    "Order by SeaTransportOrder ");
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
                        if (dgvAddons.Rows.Count > 0)
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
        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            getcmbtype();
        }
        public DataTable GetCustomerByNID(string NID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = "select ID, Name, Mobile from Customers Where NID = '" + NID + "'";
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
        private void btnFrmCustomer_Click(object sender, EventArgs e)
        {
            frmcustomers cust = new frmcustomers(txtCustName.Text, txtCustMobile.Text, txtCustNID.Text);
            cust.ShowDialog();
        }
        private void cmbSeaTransportID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DataRowView)cmbSeaTransportID.SelectedItem != null)
            {
                var SelectedValue = ((DataRowView)cmbSeaTransportID.SelectedItem).Row[0].ToString();
                if (int.Parse(SelectedValue) > 0)
                {
                    var DriverID = GetDefaultDriverID(int.Parse(SelectedValue));
                    txtSearchBoatByID.Text = cmbSeaTransportID.SelectedValue.ToString();
                    //set cmbDrivers from SeaTransport Drive
                    if (DriverID != 0)
                    {
                        cmbDrivers.SelectedValue = DriverID;
                    }
                    var Drv = cmbDrivers.SelectedValue;
                    if (Drv != null)
                    {
                        txtSearchDriverByID.Text = cmbDrivers.SelectedValue.ToString();
                    }
                    //FillDrivers(int.Parse(SelectedValue));
                    //Get Price       
                    //GetPrice();
                }
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
            //txtDiscountPercent.Text = "";
            txtDiscountValue.Text = "";
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
        private decimal GetPriceBySeaTransportTypeID(int typeID, string duration)
        {
            decimal price = 0.0m;
            try
            {
                SQLConn.sqL = "SELECT Price FROM Price Where SeaTransportTypeID = " + typeID + " and Duration = @Duration";
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

        }
        private void txtDiscountPercent_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDiscountPercent.Text))
            {
                //var CDV = Cheacdiscavilable();
                decimal Dicper = 0;
                if (!string.IsNullOrEmpty(txtDiscountPercent.Text))
                {
                    Dicper = Convert.ToDecimal(txtDiscountPercent.Text);
                    if (PriceBeforeDiscount == 0)
                    {
                        Decimal.TryParse(lblPrice.Text, out PriceBeforeDiscount);
                    }
                    decimal DiscountPercent = Common.ConvertTxtToDecimal(txtDiscountPercent.Text.ToString() != "" ? txtDiscountPercent.Text.ToString() : "0");
                    decimal DiscountValue = (PriceBeforeDiscount * DiscountPercent) / 100;
                    txtDiscountValue.Text = DiscountValue.ToString();
                    lbldisc.Text = DiscountValue.ToString();
                    decimal PriceAfterDiscount = PriceBeforeDiscount - DiscountValue;
                    lblPriceAfterDiscount.Text = PriceAfterDiscount.ToString();
                    SetTotal();
                    //if (Dicper > CDV)
                    //{
                    //    MessageBox.Show("غير مسموح لك بأضافة اكثر من " + CDV + "");
                    //    getcmbtype();
                    //    return;
                    //    //txtDiscountPercent.Clear();
                    //}
                    //else
                    //{

                    //    //txtDiscountValue.Text = "0";
                    //}
                }

            }
            else
            {
                lbldisc.Text = "0.00";
                SetTotal();
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
        private void SetTotal()
        {
            decimal priceAfterDiscount = 0;
            if (Decimal.TryParse(lblPriceAfterDiscount.Text, out priceAfterDiscount))
            {

            }
            decimal totalAddOn = 0;
            Decimal.TryParse((lblAddonTotal.Text), out totalAddOn);
            decimal totalBeforeVAT = priceAfterDiscount + totalAddOn;
            decimal VatValue = (totalBeforeVAT * VatPercent) / 100;
            decimal totalAfterVAT = totalBeforeVAT + VatValue;
            lblTotal.Text = Math.Round(totalBeforeVAT, 2).ToString();
            lblVAT.Text = Math.Round(VatValue, 2).ToString();
            lblTotalAfterVAT.Text = Math.Round(totalAfterVAT, 2).ToString();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            AddTicket();
            btnSave.Enabled = true;
        }
        private void Changevichle()
        {
            var b = ((DataRowView)cmbDuration.SelectedItem).Row[1].ToString();// Take the value on minutes of duration
            string output = string.Concat(b.Where(Char.IsDigit));
            Dsbo.Orderlist.Rows.Add(new object[] {
                cmbSeaTransportID.SelectedValue,
                cmbSeaTransportID.Text,
                output
            });


            //SQLConn.sqL = @"SELECT 
            //                    ID,
            //                    Name,
            //                    SeaTransportOrder
            //                    FROM SeaTransport 
            //                    Where TypeID =  " + cmbTypeID.SelectedValue + "" +
            //                    @"And InService = 1 
            //                    And ID IN(
            //                    SELECT      
            //                    SeaTransport.ID
            //                    FROM Tickets 
            //                    Inner JOIN SeaTransport 
            //                    ON Tickets.SeaTransportID = SeaTransport.ID
            //                    WHERE (IsBusy = 1) And  
            //                    (Tickets.StartDate = CAST(GETDATE() as DATE)) 
            //                    And(EndTime > CONVERT(TIME, SYSDATETIME())))
            //                    Order by SeaTransportOrder";
            //SQLConn.ConnDB();
            //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            //SqlDataReader readera = SQLConn.cmd.ExecuteReader();
            //DataTable dta = new DataTable();
            //dt.Columns.Add("Orderid");
            //dt.Columns.Add("Ordernum");
            //while (readera.Read())
            //{
            //    var Orderid = (int)readera[0];
            //    var Ordernumstring = readera[2].ToString();
            //    var Ordernum = 0;
            //    if (string.IsNullOrEmpty(Ordernumstring))
            //    {
            //        Ordernum = 0;
            //    }
            //    else
            //    {
            //        Ordernum = (int)reader[2];
            //    }
            //    dt.Rows.Add(new object[] { Orderid, Ordernum });
            //}
            //SQLConn.conn.Close();


            //foreach (DataRow item in dt.Rows)
            //{
            //    var id = Convert.ToInt32(item["Orderid"].ToString());
            //    var num = Convert.ToInt32(item["Ordernum"].ToString());

            //    var Boatnumber = Convert.ToInt32(txtSearchBoatByID.Text);
            //    if (Boatnumber != id)
            //    {
            //        SQLConn.sqL = @"update SeaTransport set  
            //                    SeaTransportOrder=@SeaTransportOrder
            //                    where ID=@id";
            //        SQLConn.ConnDB();
            //        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            //        if (num >= 1 && num > 0 && num != 0)
            //        {
            //            SQLConn.cmd.Parameters.AddWithValue("@SeaTransportOrder", num - 1);
            //        }
            //        SQLConn.cmd.Parameters.AddWithValue("@ID", id);
            //        SQLConn.cmd.ExecuteNonQuery();
            //    }
            //}
        }
        private void Checkvichle()
        {
            int FSQl = 0;
            int numberOfCalls;
            bool result;
            var Db = Dsbo.Orderlist.Rows;
            var Dba = Dsbo.Orderlist.OrderBy(e => e.Duretion);
            DataTable dt = new DataTable();
            SQLConn.sqL = @"SELECT 
                            ID,
                            Name,
                            SeaTransportOrder
                            FROM SeaTransport 
                            Where TypeID =  " + cmbTypeID.SelectedValue + "" +
                @"And InService = 1 
                            And ID Not IN(
                            SELECT      
                            SeaTransport.ID
                            FROM Tickets 
                            Inner JOIN SeaTransport 
                            ON Tickets.SeaTransportID = SeaTransport.ID
                            WHERE (IsBusy = 1) And  
                            (Tickets.StartDate = CAST(GETDATE() as DATE)) 
                            And(EndTime > CONVERT(TIME, SYSDATETIME())))
                            Order by SeaTransportOrder";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SqlDataReader reader = SQLConn.cmd.ExecuteReader();
            dt.Columns.Add("Orderid");
            dt.Columns.Add("Ordernum");
            while (reader.Read())
            {
                var Orderid = (int)reader[0];
                var Ordernumstring = reader[2].ToString();
                var Ordernum = 0;
                if (string.IsNullOrEmpty(Ordernumstring))
                {
                    Ordernum = 0;
                }
                else
                {
                    Ordernum = (int)reader[2];
                }
                dt.Rows.Add(new object[] { Orderid, Ordernum });
            }
            SQLConn.conn.Close();
            // Try parse to 32-bit integer worked
            foreach (DataRow row in dt.Rows)
            {
                FSQl++;
                //Get Data From Database Sql
                int Orid = Convert.ToInt32(row["Orderid"].ToString());

                SQLConn.sqL = @"update SeaTransport set  
                                SeaTransportOrder=@SeaTransportOrder
                                where ID=@id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportOrder", FSQl);
                SQLConn.cmd.Parameters.AddWithValue("@ID", Orid);
                SQLConn.cmd.ExecuteNonQuery();
                SQLConn.ConnDB();
            }
            foreach (DataRow dr in Dba)
            {
                //Get Data From Dataset
                result = Int32.TryParse(dr["Id"].ToString(), out numberOfCalls);
                if (result)
                {
                    FSQl++;
                    var id = Convert.ToInt32(dr["Id"].ToString());
                    SQLConn.sqL = @"update SeaTransport set  
                                SeaTransportOrder=@SeaTransportOrder
                                where ID=@id";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                    SQLConn.cmd.Parameters.AddWithValue("@SeaTransportOrder", FSQl);
                    SQLConn.cmd.Parameters.AddWithValue("@ID", id);
                    SQLConn.cmd.ExecuteNonQuery();
                    SQLConn.ConnDB();
                }
                else
                {
                    // Try parse to 32-bit integer failed

                }
            }
            // We Will Cheack From Count Of SeaTransportOrder And Change Number Of Boatorder
            //var Count = 0;
            //SQLConn.sqL = @"SELECT
            //            COUNT(SeaTransportOrder) As 'Count'
            //            FROM SeaTransport 
            //            Where TypeID = 1
            //            And InService = 1 
            //            And ID Not IN(
            //            SELECT      
            //            SeaTransport.ID
            //            FROM Tickets 
            //            Inner JOIN SeaTransport 
            //            ON Tickets.SeaTransportID = SeaTransport.ID
            //            WHERE (IsBusy = 1) And  
            //            (Tickets.StartDate = CAST(GETDATE() as DATE)) 
            //            And(EndTime > CONVERT(TIME, SYSDATETIME())))";


            //SQLConn.sqL = @"SELECT 
            //                    COUNT(SeaTransportOrder) As 'Count'
            //                    FROM SeaTransport 
            //                    Where TypeID =  " + cmbTypeID.SelectedValue + " " +
            //        @"And InService = 1 
            //                    And ID Not IN(
            //                    SELECT      
            //                    SeaTransport.ID
            //                    FROM Tickets 
            //                    Inner JOIN SeaTransport 
            //                    ON Tickets.SeaTransportID = SeaTransport.ID
            //                    WHERE (IsBusy = 1) And  
            //                    (Tickets.StartDate = CAST(GETDATE() as DATE)) 
            //                    And(EndTime > CONVERT(TIME, SYSDATETIME())))";
            //SQLConn.ConnDB();
            //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            //SqlDataReader reader = SQLConn.cmd.ExecuteReader();
            //if(reader.Read())
            //{
            //    Count = Convert.ToInt32(reader["Count"].ToString());
            //    SQLConn.conn.Close();
            //    SQLConn.sqL = @"update SeaTransport set  
            //                    SeaTransportOrder=@SeaTransportOrder
            //                    where ID=@id";
            //    SQLConn.ConnDB();
            //    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            //    SQLConn.cmd.Parameters.AddWithValue("@SeaTransportOrder", Count);
            //    SQLConn.cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtSearchBoatByID.Text));
            //    SQLConn.cmd.ExecuteScalar();
            //}

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
        private void GQR(string Data)
        {
            QRCodeGenerator QRG = new QRCodeGenerator();
            QRCodeData QCD = QRG.CreateQrCode(Data, QRCodeGenerator.ECCLevel.H);
            QRCode Code = new QRCode(QCD);
            QRPic.Image = Code.GetGraphic(50);
        }
        void DQ()
        {
            String Seller = "شركة مرسى اللؤلؤة للتأجير";
            String VatNo = "311593635600003";
            //UBLXML XMLG = new UBLXML();
            //XMLG.InvoiceTypeCode = "388";
            DateTime dTime = DateTime.Now;
            Double Total = Convert.ToDouble(lblTotalCashAndBank.Text);
            Double Tax = Convert.ToDouble(lblVAT.Text);

            TLV tlv = new TLV(Seller, VatNo, dTime, Total, Tax);
            QRPic.Image = tlv.toQrCode();
            Photo = CTB(QRPic.Image);
            //XMLG.Invoicemethodecode = "0200000";
            //var Payment = paymentMethod.Text;
            //if (Payment == "نقدي")
            //{
            //    XMLG.UUID = "10";
            //}
            //if (Payment == "بنكي")
            //{
            //    XMLG.UUID = "48";
            //}
            //var TAD = Convert.ToDecimal(lblPrice.Text) - Convert.ToDecimal(lbldisc.Text);
            //XMLG.IvoiceId = string.Format("SME{0:00000}", Convert.ToInt32(txtTicketNo.Text));
            //XMLG.Ivoiceno = Convert.ToInt32(txtTicketNo.Text);
            //XMLG.CRN = "";
            //XMLG.StreetName = "";
            //XMLG.BuildingNumber = "";
            //XMLG.CitySubdivisionName = "";
            //XMLG.CityName = "";
            //XMLG.PostalZone = "";
            //XMLG.CompanyID = VatNo;
            //XMLG.Companyname = Seller;
            //List<DGVRows> DGR = new List<DGVRows>();
            //int rownum = 1;
            //DGR.Add(new DGVRows
            //{
            //    Rownum = rownum.ToString(),
            //    Name = cmbSeaTransportID.Text,
            //    InvoicedQuantity = rownum.ToString(),
            //    PriceAmount = lblPrice.Text,
            //    TaxAmount = lblVAT.Text,
            //    TotalAfterDiscount = lblTotal.Text,
            //    Amount = rownum.ToString(),
            //    RoundingAmount = lblTotalAfterVAT.Text,
            //});
            ////خصم على مستوى الفاتورة
            //string Discountmethode = "خصم على مستوى الفاتورة";
            //var OJson = XMLG.UBLXMLGeneration(lblVAT.Text, lblPrice.Text, TAD.ToString(), lblTotalAfterVAT.Text, DGR, Discountmethode);
            //var DJson = JsonConvert.DeserializeObject<UBLEntity>(OJson);
            //try
            //{
            //    var Qur = @"INSERT INTO UBL(Invoiceno,GUID,QRCode,Invoiceubl) " +
            //                        "VALUES(@Invoiceno,@GUID,@QRCode,@Invoiceubl)";
            //    SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
            //    SQLConn.ConnDB();
            //    SQLConn.cmd.Parameters.AddWithValue("@Invoiceno", txtTicketNo.Text);
            //    SQLConn.cmd.Parameters.AddWithValue("@GUID", DJson.UUID);
            //    SQLConn.cmd.Parameters.AddWithValue("@QRCode", DJson.QRCode);
            //    SQLConn.cmd.Parameters.AddWithValue("@Invoiceubl", DJson.Invoiceubl);
            //    SQLConn.cmd.ExecuteNonQuery();
            //    SQLConn.cmd.Parameters.Clear();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //GQR(DJson.QRCode);
            //Photo = CTB(QRPic.Image);
        }
        public int newid { get; set; }
        private void GetInvoiceid()
        {
            SQLConn.sqL = @"SELECT ID FROM Tickets Where ID = '"+ int.Parse(txtTicketNo.Text) +"' ORDER BY ID DESC";
            SQLConn.conn.Open();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);      
            SQLConn.dr = SQLConn.cmd.ExecuteReader();
            int Tid;
            //if (SQLConn.cmd.ExecuteScalar() != null)
            if (SQLConn.dr.Read())
            {
                Tid = Convert.ToInt32(SQLConn.dr["ID"].ToString()) + 1;
            }
            else
            {
                Tid = int.Parse(txtTicketNo.Text);
            }
            txtTicketNo.Text = Tid.ToString();
            newid = Tid;
            SQLConn.conn.Close();
        }
        string Paytamara = "0";
        private void AddTicket()
        {
            DQ();
            // Add new customer
            if (!IsExitingClientByMobile())
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
                    if (Rentalid != 0)
                    {
                        if (Payed + totalCashAndBank != totalAfterVAT)
                        {
                            Interaction.MsgBox("المبلغ المدفوع لايطابق الإجمالى");
                            return;
                        }
                    }
                    else 
                    {
                        if (totalCashAndBank != totalAfterVAT)
                        {
                            Interaction.MsgBox("المبلغ المدفوع لايطابق الإجمالى");
                            return;
                        }
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

            decimal payCash = 0, payCard = 0, TamaraValue = 0, TransValue = 0;
            if (!string.IsNullOrEmpty(txtpaycash.Text))
                Decimal.TryParse(txtpaycash.Text, out payCash);
            if (!string.IsNullOrEmpty(txtpaycard.Text))
                Decimal.TryParse(txtpaycard.Text, out payCard);
            if (!string.IsNullOrEmpty(tamarapay.Text))
                Decimal.TryParse(tamarapay.Text, out TamaraValue);
            if (!string.IsNullOrEmpty(transpay.Text))
                Decimal.TryParse(transpay.Text, out TransValue);

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

            try
            {
                //GetInvoiceid();
                //SQLConn.sqL = @"INSERT INTO Tickets (ID,StartDate,StartTime,EndTime,SeaTransportTypeID,SeaTransportID,UserID,
                //DriverID,CustomerID, DurationID, DurationValue,DiscountAmount,PriceAfterDiscount,VAT,PriceAfterVAT,
                //PayCash,PayCard,Paytamara,Paytransfer,Note,Flagpayment)
                //Values(@ID,@StartDate,@StartTime,@EndTime, @SeaTransportTypeID,@SeaTransportID,
                //@UserID,@DriverID,@CustomerID,@DurationID, @DurationValue,@DiscountAmount,@PriceAfterDiscount,
                //@VAT,@PriceAfterVAT,@PayCash,@PayCard,@Paytamara,@Paytransfer,@Note,@Flagpayment);SELECT SCOPE_IDENTITY();";

                //SQLConn.ConnDB();
                //SQLConn.BeginTransaction();
                //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);


                SQLConn.ConnDB();
                //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SqlCommand cmd = new SqlCommand("AddTicket", SQLConn.conn, SQLConn.trans);
                cmd.CommandType = CommandType.StoredProcedure;

                //SQLConn.cmd.Parameters.AddWithValue("@ID", int.Parse(txtTicketNo.Text));
                //SQLConn.cmd.Parameters.AddWithValue("@ID", newid);
                cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                cmd.Parameters.AddWithValue("@StartTime", dtpStartTime.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@EndTime", endTime.TimeOfDay);

                cmd.Parameters.AddWithValue("@SeaTransportTypeID", cmbTypeID.SelectedValue);
                cmd.Parameters.AddWithValue("@SeaTransportID", cmbSeaTransportID.SelectedValue);
                cmd.Parameters.AddWithValue("@DriverID", cmbDrivers.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CustomerID", int.Parse(lblCustIDHidden.Text));
                //DurationID
                cmd.Parameters.AddWithValue("@DurationID", cmbDuration.SelectedValue);
                //SQLConn.cmd.Parameters.AddWithValue("@DurationValue", b);
                cmd.Parameters.AddWithValue("@DurationValue", Convert.ToInt32(output));
                //var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();

                cmd.Parameters.AddWithValue("@DiscountAmount", discountValue);
                //SQLConn.cmd.Parameters.AddWithValue("@DiscountPercent", Common.ConvertTxtToDecimal(txtDiscountPercent.Text != "" ? txtDiscountPercent.Text : "0"));
                cmd.Parameters.AddWithValue("@PriceAfterDiscount", Common.ConvertTxtToDecimal(lblPriceAfterDiscount.Text));
                cmd.Parameters.AddWithValue("@VAT", Common.ConvertTxtToDecimal(lblVAT.Text));
                cmd.Parameters.AddWithValue("@PriceAfterVAT", Common.ConvertTxtToDecimal(lblTotalAfterVAT.Text));
                // SQLConn.cmd.Parameters.AddWithValue("@PayementType", SqlDbType.Int).Value = PayementType;
                cmd.Parameters.AddWithValue("@UserID", Data.UserID);
                cmd.Parameters.AddWithValue("@PayCash", payCash);
                cmd.Parameters.AddWithValue("@PayCard", payCard);
                cmd.Parameters.AddWithValue("@Paytamara", TamaraValue);
                cmd.Parameters.AddWithValue("@Paytransfer", TransValue);
                cmd.Parameters.AddWithValue("@Note", txtNote.Text);
                cmd.Parameters.AddWithValue("@Flagpayment", paymentMethod.Text);
                //SQLConn.conn.Open();

                //cmd.ExecuteNonQuery();
                //int ticketId = (int)InsertStockInformation.ExecuteScalar();
                int modified = Convert.ToInt32(cmd.ExecuteScalar());
                txtTicketNo.Text = modified.ToString();


                SQLConn.BeginTransaction();




                //Update Treasury Balance For Current User 
                if (txtpaycash.Text != "")
                {
                    SQLConn.GetTreasuryIDForCurrentUser(Data.UserID);

                    SQLConn.ConnDB();
                    //update TreasuryTransactions
                    if (Data.UserTreasuryID > 0)
                    {
                        SQLConn.UpdateUserTreasuryTicketTransactions(Data.UserTreasuryID, payCash, SQLConn.trans, int.Parse(txtTicketNo.Text), "إظافة تذكرة ");

                        SQLConn.UpdateUserTreasury(Data.UserTreasuryID, payCash, SQLConn.trans);
                    }
                }
                //Update Bank Account Balance
                if (txtpaycard.Text != "")
                {
                    //Decimal.TryParse(txtpaycard.Text, out payCard);

                    int bankId = SQLConn.GetBankAccountID();

                    if (bankId > 0)
                    {
                        //SQLConn.UpdateBankAccountTransactions(bankId, payCard, SQLConn.trans);
                        SQLConn.UpdateBankAccountTicketTransactions(bankId, payCard, int.Parse(txtTicketNo.Text), "إظافة تذكرة ", SQLConn.trans);
                        SQLConn.UpdateBankAccountByID(bankId, payCard, SQLConn.trans);
                    }
                }
                if (Rentalid != 0)
                {
                    if (tamarapay.Text != "" || tamarapay.Text != "0.00")
                    {
                        SQLConn.sqL = @"INSERT INTO Tamara (Refnummber,Amount,Ticketid)
                                                 Values(@Refnummber,@Amount,@Ticketid)";
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                        SQLConn.cmd.Parameters.AddWithValue("@Refnummber", textBox5.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@Amount", tamarapay.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@Ticketid", int.Parse(txtTicketNo.Text));
                        SQLConn.ConnDB();
                        SQLConn.cmd.ExecuteNonQuery();
                    }
                    if (transpay.Text != "" || transpay.Text != "0.00")
                    {
                        SQLConn.sqL = @"INSERT INTO Banktransfers (Amount,Ticketid)
                                                 Values(@Amount,@Ticketid)";
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                        SQLConn.cmd.Parameters.AddWithValue("@Amount", transpay.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@Ticketid", int.Parse(txtTicketNo.Text));
                        SQLConn.ConnDB();
                        SQLConn.cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (tamarapay.Text != "" || tamarapay.Text != "0.00")
                    {
                        SQLConn.sqL = @"Update Tamara Set 
                                        Refnummber = @Refnummber,
                                        Amount = @Amount,
                                        Ticketid = @Ticketid 
                                        Where Rentalid = @Rentalid";
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                        SQLConn.cmd.Parameters.AddWithValue("@Refnummber", textBox5.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@Amount", tamarapay.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@Ticketid", int.Parse(txtTicketNo.Text));
                        SQLConn.cmd.Parameters.AddWithValue("@Rentalid", Rentalid);
                        SQLConn.ConnDB();
                        SQLConn.cmd.ExecuteNonQuery();
                    }
                    if (transpay.Text != "" || transpay.Text != "0.00")
                    {
                        SQLConn.sqL = @"Update Banktransfers Set 
                                        Amount = @Amount,
                                        Ticketid = @Ticketid
                                        Where Rentalid = @Rentalid";
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                        SQLConn.cmd.Parameters.AddWithValue("@Amount", transpay.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@Ticketid", int.Parse(txtTicketNo.Text));
                        SQLConn.cmd.Parameters.AddWithValue("@Rentalid", Rentalid);
                        SQLConn.ConnDB();
                        SQLConn.cmd.ExecuteNonQuery();
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
                        AddTicketsAddons(int.Parse(txtTicketNo.Text), addonID, quantity, price, total, SQLConn.trans);
                    }
                }

                // Update SeaTransportID : isBusy= true 
                UpdateSeaTransportByID(true, SQLConn.trans);

                //SQLConn.ConnDB();
                //SQLConn.trans.Commit();


                txtCustMobile.Focus();

                //                DateTime dateStart = DateTime.Now;
                //                DateTime dateEnd = DateTime.Now;
                //                // We use the UserId Corresponding to the cashier
                //                frmReportPrint frmReportPrint = new frmReportPrint(dateStart, dateEnd, ticketId, "Ticket");
                //#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                //                _ = frmReportPrint.ShowDialog();

                //string query = @" SELECT  Tickets.ID, Tickets.StartDate,  CAST(Tickets.StartTime AS time(0)) AS StartTime, 
                //        Customers.Name AS CustomerName, Customers.Mobile, 
                //        Customers.NID, SeaTransport.Name AS SeaTransportName, 
                //        Tickets.DurationValue, Tickets.VAT, Tickets.PriceAfterDiscount, 
                //        Tickets.PriceAfterVAT, Employees.Name AS CashierName, 
                //        SeaTransportType.Name AS SeaType, Drivers.Name AS DriverName, Tickets.PayCash, 
                //      Tickets.PayCard, CompanyDiscount.CompanyName, CompanyDiscount.DiscountValue, Tickets.DiscountAmount

                //      FROM         Tickets INNER JOIN
                //      Users ON Tickets.UserID = Users.ID INNER JOIN
                //      Role ON Users.RoleID = Role.ID INNER JOIN
                //      Employees ON Users.EmployeeID = Employees.ID INNER JOIN
                //      Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                //      SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID LEFT OUTER JOIN
                //      Drivers ON Tickets.DriverID = Drivers.ID LEFT OUTER JOIN
                //      SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID LEFT OUTER JOIN
                //      CompanyDiscount ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue
                //      WHERE     (Role.ID = 2) and dbo.Tickets.ID = " + ticketId + " ";

                var Qur = "Select "+
                          "Tickets.ID,  "+
                          "CAST(Tickets.StartTime AS time(0)) AS StartTime, "+
                          "Tickets.StartDate, "+
                          "Tickets.DurationValue,  "+
                          "Tickets.VAT,  "+
                          "Tickets.PriceAfterDiscount,  "+
                          "Tickets.PriceAfterVAT, "+
                          "Tickets.PayCash,  "+
                          "Tickets.PayCard, "+
                          "Tickets.DiscountAmount, "+
                          "CompanyDiscount.CompanyName,  "+
                          "CompanyDiscount.DiscountValue,  "+
                          "Customers.Name AS CustomerName,  "+
                          "Customers.Mobile,  "+
                          "Customers.NID, "+
                          "SeaTransportType.Name AS SeaType, "+
                          "SeaTransport.Name AS SeaTransportName, "+
                          "Drivers.Name AS DriverName, "+
                          "Users.UserName AS CashierName, "+
                          "Tickets.Note, "+
                          "lnkTicketAddon.Quantity, "+
                          "lnkTicketAddon.Price, "+
                          "lnkTicketAddon.Total, "+
                          "Addons.Name, "+
                          "Customers.Taxnumber, " +
                          "Tickets.Paytamara, " +
                          "Tickets.Paytransfer " +
                          "From Tickets "+
                          "INNER JOIN Customers "+
                          "ON Tickets.CustomerID = Customers.ID "+
                          "LEFT OUTER JOIN SeaTransport "+
                          "ON Tickets.SeaTransportID = SeaTransport.ID "+
                          "INNER JOIN SeaTransportType "+
                          "ON Tickets.SeaTransportTypeID = SeaTransportType.ID "+
                          "LEFT OUTER JOIN CompanyDiscount "+
                          "ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue "+
                          "LEFT OUTER JOIN Drivers "+
                          "ON Tickets.DriverID = Drivers.ID "+
                          "INNER JOIN Users "+
                          "ON Users.ID = Tickets.UserID "+
                          "Left Outer Join lnkTicketAddon "+
                          "On lnkTicketAddon.TicketID = Tickets.ID "+
                          "Left Outer Join Addons "+
                          "On lnkTicketAddon.AddonID = Addons.ID "+
                          "Where Tickets.ID = "+ int.Parse(txtTicketNo.Text) + " ";
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
                    var Paycash = SQLConn.dr[7].ToString();
                    var Paycard = SQLConn.dr[8].ToString();
                    var PT = SQLConn.dr["Paytamara"].ToString();
                    var BT = SQLConn.dr["Paytransfer"].ToString();
                    if (!string.IsNullOrEmpty(PT))
                    {
                        Paytamara = PT;
                    }
                    if (Rentalid != 0)
                    {
                        CRTPaycash = Convert.ToDecimal(Paycash) + Cash;
                        Paycash = CRTPaycash.ToString();
                        CRTPaycard = Convert.ToDecimal(Paycard) + Card;
                        Paycard = CRTPaycard.ToString();
                    }
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
                        AdName,Discound,Paycash,Paycard,BT
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
                if (Rentalid != null)
                {
                    try
                    {
                        SQLConn.sqL = "Update Rental Set " +
                                      "ID = @ID," +
                                      "Ticketid = @Ticketid," +
                                      "Rentstatus = @Rentstatus " +
                                      "Where ID = @ID";
                        SQLConn.ConnDB();
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                        SQLConn.cmd.Parameters.AddWithValue("@ID", Rentalid);
                        SQLConn.cmd.Parameters.AddWithValue("@Ticketid", Convert.ToInt32(txtTicketNo.Text));
                        SQLConn.cmd.Parameters.AddWithValue("@Rentstatus", "مدفوع");
                        SQLConn.cmd.ExecuteNonQuery();
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("تم تعديل الرحلة بنجاح");
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
                qrbill.PrintOptions.PrinterName = Properties.Settings.Default.Printername;
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
                        qrbill.PrintToPrinter(1, true, 1, 1);
                        QRPic.Image = null;
                        txtchangetot.Clear();
                        qrbill.Dispose();
                        SQLConn.conn.Dispose();
                        GC.Collect();
                    }
                }
                else
                {
                    MessageBox.Show("يرجى التحقق من الطابعه", "خطأ");
                }
                
            }
            catch (Exception ex)
            {
                //SQLConn.trans.Rollback();
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
            

            Changevichle();
            Checkvichle();

           ClearFields();
            
        }
        private void UpdateSeaTransportByID(bool isBusy, SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = "Update SeaTransport Set IsBusy =   @IsBusy where ID=" + cmbSeaTransportID.SelectedValue;
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@IsBusy", isBusy ? 1 : 0);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
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
            {
                IsExitingClientByNID();
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtCustName.Focus();
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
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (!IsExitingClientByMobile())
                    txtCustNID.Focus();
            }
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
                if (!string.IsNullOrEmpty(txtSearchBoatByID.Text) && int.TryParse(txtSearchDriverByID.Text, out int DriverByID) && DriverByID > 0)
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
                        MessageBox.Show("لم يتم ايجاد واسطة بحرية برقم'" + txtSearchDriverByID.Text + "'");
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
        public void CompanyDiscountFill()
        {
            var Per = Data.RoleID;
            var Qur = "";
            if (Per == 1)
            {
               Qur = @"SELECT ID,CompanyName,DiscountValue FROM CompanyDiscount where IsActive = 1 and EndDate >= GetDate() And Admin = "+ 1 +" ";
            }
            else if (Per == 2)
            {
                Qur = @"SELECT ID,CompanyName,DiscountValue FROM CompanyDiscount where IsActive = 1 and EndDate >= GetDate() And Cashier =  "+ 1 +" ";

            }
            else if (Per == 3)
            {
                Qur = @"SELECT ID,CompanyName,DiscountValue FROM CompanyDiscount where IsActive = 1 and EndDate >= GetDate() And Comptable = "+ 1 +" ";
            }
            else
            {
                Qur = @"SELECT ID,CompanyName,DiscountValue FROM CompanyDiscount where IsActive = 1 and EndDate >= GetDate() And EntringData = "+ 1 +" ";
            }
            try
            {
                SQLConn.ConnDB();

                //Qur = "SELECT ID,CompanyName,DiscountValue FROM CompanyDiscount where IsActive = 1 and EndDate >= GetDate() ";
                DisCompanydtbl = SQLConn.getTable(Qur);
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
            var SelectedValue = ((DataRowView)cmbCompanyDiscount.SelectedItem).Row[0].ToString();
            if (decimal.Parse(SelectedValue) > 0)
            {
                DataRow x = DisCompanydtbl.AsEnumerable().Where
                (r => r.Field<int>("ID") == int.Parse(SelectedValue.ToString())).FirstOrDefault();
                if (x != null)
                {
                    txtDiscountPercent.Text = x["DiscountValue"].ToString();
                }

                //lbldisc.Text = "0.00";
                //lblPrice.Text = "0.00";
                //lblTotal.Text = "0.00";
                //lblVAT.Text = "0.00";
                //lblTotalAfterVAT.Text = "0.00";
                //Calcchangetot();
            }
            else
            {
                txtDiscountPercent.Clear();
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

        //public int GetBankAccountID()
        //{
        //    int id = 0;
        //    try
        //    {
        //        SQLConn.sqL = "Select top(1) ID From BankAccounts";
        //        //SQLConn.ConnDB();
        //        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);

        //        if (SQLConn.cmd.ExecuteScalar() != null)
        //        {
        //            id = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
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
        //    return id;
        //}


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
            if (ticketId > 0)
            {
                frmPrintTicket pr = new frmPrintTicket(ticketId);
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
                //txtpaycard.Focus();
                paymentMethod.Focus();
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
                tamarapay.Focus();
            }
        }
        private void cmbSeaTransportID_DropDownClosed(object sender, EventArgs e)
        {

        }
        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }
        private void cmbDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void Calcchangetot()
        {
            var Duration = cmbDuration.Text; // 
            if (Duration != null)
            {
                var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();
                var price = GetPrice(int.Parse(SelectedValue), false, Duration);
                lblPrice.Text = price.ToString();
                if (dgvAddons.Rows.Count > 0)
                {
                    var AO = Convert.ToDecimal(lblAddonTotal.Text);
                    var Res = price + AO;
                }
                lblPriceAfterDiscount.Text = price.ToString();
            }
            SetTotal();
            // لو السعر لم يتعدى المطلوب
            var DP = Convert.ToDouble(Cashierpercent.Text);
            var Perce = DP / 100;
            // AD = Aollow Discount
            var AD = Convert.ToDouble(lblTotalAfterVAT.Text) * Perce;
            var GAD = Math.Round(AD, 2).ToString();


            //السعر الحالي
            if (!string.IsNullOrEmpty(txtchangetot.Text) && txtchangetot.Text != "0")
            {
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
                        lbldisc.Text = Convert.ToString(GDisc);
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
        }
        private void Btnchangetot_Click(object sender, EventArgs e)
        {
            lbldisc.Text = "0.00";
            lblPrice.Text = "0.00";
            lblTotal.Text = "0.00";
            lblVAT.Text = "0.00";
            lblTotalAfterVAT.Text = "0.00";
            Calcchangetot();
            //lblVAT.Text = "0.00";
            //lblTotalAfterVAT.Text = "0.00";
            //// لو السعر لم يتعدى المطلوب
            //var CDV = Cheacdiscavilable();
            //decimal Dicper = 0;
            //if (!string.IsNullOrEmpty(txtchangetot.Text))
            //{
            //    Dicper = Convert.ToDecimal(txtchangetot.Text);
            //    if (Dicper > CDV)
            //    {
            //        MessageBox.Show("غير مسموح لك بأضافة اكثر من " + CDV + "");
            //        getcmbtype();
            //        return;
            //    }
            //    else
            //    {
            //        lblTotalAfterVAT.Text = txtchangetot.Text;
            //        //السعر الحالي
            //        var Price = Convert.ToDouble(txtchangetot.Text);
            //        var TBV = Price / 1.15;
            //        var GTBV = Math.Round(Convert.ToDouble(TBV), 2).ToString();
            //        if (ISVAT)
            //        {
            //            // الضريبة
            //            var Tax = Convert.ToDouble(GTBV) * VP;
            //            var GTax = Math.Round(Convert.ToDouble(Tax), 2).ToString();
            //            lblVAT.Text = GTax;

            //            // الخصم
            //            var Disc = Convert.ToDouble(lblTotal.Text) - TBV;
            //            var GDisc = Math.Round(Convert.ToDouble(Disc), 2).ToString();
            //            txtDiscountValue.Text = Convert.ToString(GDisc);
            //            lbldisc.Text = txtDiscountValue.Text;

            //            //السعر الكلي
            //            var TAV = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(GDisc);
            //            lblTotal.Text = Convert.ToString(TAV);


            //            lblPriceAfterDiscount.Text = lblTotal.Text;
            //        }
            //    }
            //}
        }

        private void txtchangetot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDiscountValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (PriceBeforeDiscount == 0)
                {
                    Decimal.TryParse(lblPrice.Text, out PriceBeforeDiscount);
                }

                decimal DiscountValue = Common.ConvertTxtToDecimal(txtDiscountValue.Text.ToString() != "" ? txtDiscountValue.Text.ToString() : "0");
                decimal PriceAfterDiscount = PriceBeforeDiscount - DiscountValue;
                lblPriceAfterDiscount.Text = PriceAfterDiscount.ToString();
                //txtDiscountPercent.Text = "0";
                SetTotal();
            }
        }

        private void lblVAT_Click(object sender, EventArgs e)
        {

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
                    lbldisc.Text = txtDiscountValue.Text;

                    //السعر الكلي
                    var TAV = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(GDisc);
                    lblTotal.Text = Convert.ToString(TAV);


                    lblPriceAfterDiscount.Text = lblTotal.Text;
                }
            }
        }

        private void paymentMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cheackpayment();
        }
        private void HiddenFild()
        {
            label15.Visible = false;
            txtpaycard.Visible = false;
            txtpaycard.Text = "0.00";
            label29.Visible = false;
            transpay.Visible = false;
            transpay.Text = "0.00";
            label9.Visible = false;
            txtpaycash.Visible = false;
            txtpaycash.Text = "0.00";
            label31.Visible = false;
            tamarapay.Visible = false;
            tamarapay.Text = "0.00";
            textBox5.Visible = false;
            textBox5.Text = "";
            label32.Visible = false;
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
                    label9.Visible = true;
                    break;
                case "بنكي":
                    HiddenFild();
                    txtpaycard.Visible = true;
                    label15.Visible = true;
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
                    label9.Visible = true;
                    label15.Visible = true;
                    txtpaycard.Visible = true;
                    txtpaycash.Visible = true;
                    break;
                case "نقدي وتحويل":
                    HiddenFild();
                    txtpaycash.Text = "0.00";
                    txtpaycash.Visible = true;
                    label9.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    transpay.Text = "0.00";
                    break;                           
                case "تمارا ونقدي":
                    HiddenFild();
                    txtpaycash.Visible = true;
                    label9.Visible = true;
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
                    label15.Visible = true;
                    label29.Visible = true;
                    transpay.Visible = true;
                    transpay.Text = "0.00";
                    break;
                case "تمارا وبنكي":
                    HiddenFild();
                    txtpaycard.Visible = true;
                    label15.Visible = true;
                    label31.Visible = true;
                    tamarapay.Visible = true;
                    lblTotalCashAndBank.Text = lblTotalAfterVAT.Text;
                    label32.Visible = true;
                    textBox5.Visible = true;
                    break;
                case "نقدي وبنكي وتحويل":
                    HiddenFild();
                    label9.Visible = true;
                    label15.Visible = true;
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

        private void paymentMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtpaycard.Focus();
                //if (paymentMethod.Text == "نقدي")
                //{
                //    txtpaycash.Focus();
                //}
                //else if (paymentMethod.Text == "بنكي")
                //{
                //    txtpaycard.Focus();
                //}
                //else
                //{
                //    txtpaycash.Focus();
                //}
            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            if (tamarapay.Text != "")
            {
                if (paymentMethod.Text != "نقدي" || paymentMethod.Text != "نقدي وبنكي" || paymentMethod.Text != "بنكي")
                {
                    GetTotalPay();
                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
        }

        private void transpay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtpaycash.Focus();
        }

        private void transpay_TextChanged(object sender, EventArgs e)
        {
            if (transpay.Text != "")
            {
                GetTotalPay();
            }
        }

        private void txtchangetot_TextChanged(object sender, EventArgs e)
        {

        }

        private void paymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cheackpayment();
        }
    }
}
