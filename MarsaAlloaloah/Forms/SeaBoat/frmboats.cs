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
using System.Globalization;
using System.Threading;
using MarsaAlloaloah.Utility.Ado.net;
using MarsaAlloaloah.Utility;

namespace MarsaAlloaloah
{
    public partial class frmboats : Form
    {
        int SelectedPriceGroup;
        int SelectedCustomerID;
        string SelectedCustomerName;
        byte[] logo = null;
        public static byte[] SelectedImage;
        int SelectedSeaTransportID;

        DataTable dtimages = new DataTable();



        public frmboats()
        {
            InitializeComponent();
            dtimages.Clear();
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("ar-SA");
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-SA");
            //dtpLastDateIn.Format = DateTimePickerFormat.Custom;
            //dtpLastDateIn.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;

            //DateTimeFormatInfo DTFormat = new CultureInfo("ar-sa", false).DateTimeFormat;
            //DTFormat.Calendar = new HijriCalendar();
            //DTFormat.ShortDatePattern = "dd/mm/yyyy";
            //DateTime.Today.Date.ToString("f", DTFormat);
            //this.dtpLastDateIn.Culture = new System.Globalization.CultureInfo("ar-sa");
        }
        private void CreateImageTable()
        {
            if (dtimages.Columns.Count == 0)
            {
                //dtimages.Columns.Add("SlNo");
                dtimages.Columns.Add("DocumentFile");
                dtimages.Columns.Add("ImageBytes", typeof(Byte[]));
                dtimages.Columns.Add("DocumentName");

            }

        }
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            pnlclientdata.Visible = true;
        }
        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmboats_Load(object sender, EventArgs e)
        {

            SeaTransportTypeFill();
            PriceGroupFill();
            PriceGridFill();
            OwnersFill();
            DriversFill();
            GridFill();


            //DataGridViewRow row = (DataGridViewRow)dgvPriceGroup.Rows[0].Clone();
            //dgvPriceGroup.Rows.Add("1", "15", "100", "", "", "");
            //dgvPriceGroup.Rows.Add("2", "30", "200", "", "", "");
            //dgvPriceGroup.Rows.Add("3", "45", "300", "", "", "");
            //dgvPriceGroup.Rows.Add("4", "ساعة", "400","","", "");

            //for (int i = 0; i < dgvPriceGroup.Rows.Count - 2; i++)
            //{
            //    dgvPriceGroup.Rows[i].Cells[1].Value = dgvPriceGroup.Rows[i].Cells[1].Value + "دقيقة";
            //}

            //DataGridViewRow row1 = (DataGridViewRow)gvChangedgvPriceGroup.Rows[0].Clone();
            //gvChangedgvPriceGroup.Rows.Add("1", "15", "100", "", "", "");
            //gvChangedgvPriceGroup.Rows.Add("2", "30", "200", "", "", "");
            //gvChangedgvPriceGroup.Rows.Add("3", "45", "300", "", "", "");
            //gvChangedgvPriceGroup.Rows.Add("4", "ساعة", "400", "", "", "");

            //for (int i = 0; i < gvChangedgvPriceGroup.Rows.Count - 2; i++)
            //{
            //    gvChangedgvPriceGroup.Rows[i].Cells[1].Value = gvChangedgvPriceGroup.Rows[i].Cells[1].Value + "دقيقة";
            //}

        }
        public void OwnersFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM Drivers Where DriverTypeID = 2");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbOwnerID.DataSource = dtbl;
                cmbOwnerID.ValueMember = "ID";
                cmbOwnerID.DisplayMember = "Name";

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }

        }
        public void DriversFill()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM Drivers");
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

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsDifferentPricing.Checked == true)
            {
                dgvPriceGroupChange.Visible = true;
            }
            else
            {

                dgvPriceGroupChange.Visible = false;

            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

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




        }
        public void PriceGroupFill()
        {

            try
            {

                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT SeaTransportType.Name, SeaTransportType.ID FROM SeaTransportType");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbPriceGroupID.DataSource = dtbl;
                cmbPriceGroupID.ValueMember = "ID";
                cmbPriceGroupID.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }


        }
        public DataTable GetPriceTable(int SelectedPriceGroup)
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {

                SQLConn.sqL = "select ID, Duration, Price, CashierCommission, CashierExternCommission, SeaTransportTypeID  from Price Where SeaTransportTypeID= " + SelectedPriceGroup + "";
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
        private void PriceGridFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                DataTable dtbl2 = new DataTable();
                dtbl = GetPriceTable(SelectedPriceGroup);
                dtbl2 = GetPriceTable(SelectedPriceGroup);
                if (dtbl.Rows.Count > 0)
                {
                    dgvPriceGroup.DataSource = dtbl;

                    dgvPriceGroupChange.DataSource = dtbl2;
                }
                else
                {
                    dtbl.Rows.Clear();
                    dtbl2.Rows.Clear();
                    dgvPriceGroup.DataSource = dtbl;
                    dgvPriceGroupChange.DataSource = dtbl2;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        private void cmbPriceGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {

            var SelectedValue = ((DataRowView)cmbPriceGroupID.SelectedItem).Row[1].ToString();
            //if (cmbPriceGroupID.SelectedValue.ToString() != "0")
            //{
            SelectedPriceGroup = int.Parse(SelectedValue);
            PriceGridFill();
            //}

        }

        private void cbOwnerClient_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOwnerClient.Checked == true)
            {

                cbOwnerMarsa.Checked = false;
                pnlclientdata.Visible = true;

            }
            else
            {
                //cbOwnerMarsa.Checked = true;
                pnlclientdata.Visible = false;
            }
        }

        private void cbOwnerMarsa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOwnerMarsa.Checked == true)
            {

                cbOwnerMarsa.Checked = true;
                cbOwnerClient.Checked = false;
                pnlclientdata.Visible = false;
            }
            else
            {
                cbOwnerMarsa.Checked = false;

            }


        }

        DataTable Customers = new DataTable();


        private void cmbClientID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        OpenFileDialog ofdDocuments = new OpenFileDialog();

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            ofdDocuments.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";
            ofdDocuments.FileName = string.Empty;
            ofdDocuments.FileOk += OfdDocuments_FileOk;
            CreateImageTable();
            if (DialogResult.OK == ofdDocuments.ShowDialog())
            {
                if (ofdDocuments.FileName != string.Empty)
                {

                    try
                    {

                        logo = ReadFile(ofdDocuments.FileName);
                        if (btnSave.Text == "حفظ")
                        {
                            DataRow dr = dtimages.NewRow();
                            dr["DocumentFile"] = Path.GetFileName(ofdDocuments.FileName);
                            dr["DocumentName"] = txtDocumentName.Text;
                            dr["ImageBytes"] = logo;
                            //dr["DocumentFile"] = logo;
                            dtimages.Rows.Add(dr);
                            dgvdocuments.DataSource = dtimages;
                        }
                        else if (btnSave.Text == "تحديث")
                        {
                            if (dgvdocuments.DataSource != null)
                            {
                                dtimages = (DataTable)dgvdocuments.DataSource;
                                DataRow drToAdd = dtimages.NewRow();
                                drToAdd["DocumentFile"] = Path.GetFileName(ofdDocuments.FileName);
                                drToAdd["DocumentName"] = txtDocumentName.Text;
                                drToAdd["ImageBytes"] = logo;
                                // drToAdd["ID"] = 0;
                                dtimages.Rows.Add(drToAdd);
                                dtimages.AcceptChanges();
                            }
                            else
                            {
                                DataRow drToAdd = dtimages.NewRow();
                                drToAdd["DocumentFile"] = Path.GetFileName(ofdDocuments.FileName);
                                drToAdd["DocumentName"] = txtDocumentName.Text;
                                drToAdd["ImageBytes"] = logo;
                                // drToAdd["ID"] = 0;
                                dtimages.Rows.Add(drToAdd);
                                dgvdocuments.DataSource = dtimages;
                            }



                        }

                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox(ex.Message);
                    }
                }
            }
        }

        private void OfdDocuments_FileOk(object sender, CancelEventArgs e)
        {

            FileInfo info = new FileInfo(ofdDocuments.FileName);
            if (info.Length > 1024 * 1024)
            {
                Interaction.MsgBox("حجم الملف أكبر من 1 ميجا");
                e.Cancel = true;
            }
        }

        byte[] ReadFile(String strPath)
        {
            byte[] data = null;
            try
            {
                FileInfo fInfo = new FileInfo(strPath);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                data = br.ReadBytes((int)numBytes);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
            return data;
        }

        private void btnDeleteDocument_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا المستند", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int SelectedRowsCount = dgvdocuments.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (SelectedRowsCount > 0)
                {
                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        dgvdocuments.Rows.RemoveAt(dgvdocuments.SelectedRows[0].Index);
                    }
                }
            }
            else
            {
                return;
            }

        }

        private void btnShowDocument_Click(object sender, EventArgs e)
        {
            int index = dgvdocuments.SelectedRows[0].Index;
            DataGridViewRow SelectedRow = dgvdocuments.Rows[index];
            SelectedImage = (byte[])SelectedRow.Cells[3].Value;
            frmShowImage si = new frmShowImage();
            si.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "الوسائط البحرية", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "حفظ")
            {
                AddSeaTransport();
                GridFill();
            }
            else
            {
                UpdateSeaTransport();
                //txtSeaTrasportType.Text = "";
                // btnSave.Text = "حفظ";
                GridFill();
            }
        }

        #region Insert       
        private void AddSeaTransport()
        {
            try
            {
                if (txtName.Text == "")
                {
                    Interaction.MsgBox("من فضلك أدخل إسم الواسطة البحرية");
                    return;
                }
                //Check if SeaTransport No Dublicate
                if (txtNumber.Text != "")
                {
                    if (IsNumberDublicateWhenInsert(int.Parse(txtNumber.Text)) == true)
                    {
                        Interaction.MsgBox("رقم الواسطة البحرية موجود بالفعل ,من فضلك قم بإدخال رقم آخر");
                        return;
                    }
                }

                if (txtNumRefBoat.Text != "")
                {
                    if (IsNumRefBoatDublicateWhenInsert(int.Parse(txtNumRefBoat.Text)) == true)
                    {
                        Interaction.MsgBox("رقم الواسطة التعريفي موجود بالفعل ,من فضلك قم بإدخال رقم آخر");
                        return;
                    }
                }

                int newID;
                SQLConn.sqL = @"INSERT INTO SeaTransport(Name,TypeID,height,Width,ContractStartDate,ContractEndDate,
                    Number,LicenseDate,MachineType,MachineNumber,OwnerID,OwnerTypeID,ConsumingByHour,PersonsNumbers,LastDateIn,LastDateOut,
                    DelegationDate,CurrentCounter,PriceGroupID,InService,IsDifferentPricing,DriverID, NumberReference)
                    VALUES(@Name,@TypeID,@height,@Width,@ContractStartDate,@ContractEndDate,
                    @Number,@LicenseDate,@MachineType,@MachineNumber,@OwnerID,@OwnerTypeID,@ConsumingByHour,@PersonsNumbers,@LastDateIn,@LastDateOut,
                    @DelegationDate,@CurrentCounter,@PriceGroupID,@InService,@IsDifferentPricing,@DriverID, @NumberReference);SELECT CAST(scope_identity() AS int)";
                SQLConn.ConnDB();
                //Create Transaction 
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtName.Text);
                SQLConn.cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = int.Parse(cmbTypeID.SelectedValue.ToString());
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@height", txtheight.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Width", txtWidth.Text));

                SQLConn.cmd.Parameters.Add("@ContractStartDate", SqlDbType.DateTime).Value = dtpContractStartDate.Value;
                SQLConn.cmd.Parameters.Add("@ContractEndDate", SqlDbType.DateTime).Value = dtpContractEndDate.Value;
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Number", txtNumber.Text));

                //SQLConn.cmd.Parameters.Add("@Number", SqlDbType.Int).Value = int.Parse(txtNumber.Text);
                SQLConn.cmd.Parameters.Add("@LicenseDate", SqlDbType.DateTime).Value = dtpLicenseDate.Value;
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@MachineType", txtMachineType.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@MachineNumber", txtMachineNumber.Text));

                if (cbOwnerClient.Checked == true)
                {
                    SQLConn.cmd.Parameters.Add("@OwnerTypeID", SqlDbType.Int).Value = 1;
                    SQLConn.cmd.Parameters.Add("@OwnerID", SqlDbType.Int).Value = int.Parse(cmbOwnerID.SelectedValue.ToString());
                }
                else
                {
                    SQLConn.cmd.Parameters.Add("@OwnerTypeID", SqlDbType.Int).Value = 2;
                    SQLConn.cmd.Parameters.Add("@OwnerID", SqlDbType.Int).Value = 0;
                }
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@ConsumingByHour", txtConsumingByHour.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@PersonsNumbers", txtPersonsNumbers.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@CurrentCounter", txtCurrentCounter.Text));
                SQLConn.cmd.Parameters.Add("@LastDateIn", SqlDbType.Date).Value = dtpLastDateIn.Value;
                SQLConn.cmd.Parameters.Add("@LastDateOut", SqlDbType.Date).Value = dtpLastDateOut.Value;
                SQLConn.cmd.Parameters.Add("@DelegationDate", SqlDbType.Date).Value = dtpDelegationDate.Value;
                //SQLConn.cmd.Parameters.Add("@CurrentCounter", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCurrentCounter.Text);
                SQLConn.cmd.Parameters.Add("@PriceGroupID", SqlDbType.Int).Value = int.Parse(cmbPriceGroupID.SelectedValue.ToString());
                SQLConn.cmd.Parameters.Add("@InService", SqlDbType.Bit).Value = cbInService.Checked;
                SQLConn.cmd.Parameters.Add("@IsDifferentPricing", SqlDbType.Bit).Value = cbIsDifferentPricing.Checked;
                SQLConn.cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = int.Parse(cmbDrivers.SelectedValue.ToString());
                //NumberReference
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@NumberReference", txtNumRefBoat.Text));

                // SQLConn.cmd.ExecuteNonQuery();
                newID = (int)SQLConn.cmd.ExecuteScalar();

                //Insert PriceChanging
                if (cbIsDifferentPricing.Checked == true)
                {
                    for (int i = 0; i < dgvPriceGroupChange.Rows.Count; i++)
                    {
                        var Duration = dgvPriceGroupChange.Rows[i].Cells["dgvchangeDuration"].Value;
                        var Price = dgvPriceGroupChange.Rows[i].Cells["dgvchangePrice"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["dgvchangePrice"].Value) : 0.0m;
                        var CashierCommission = dgvPriceGroupChange.Rows[i].Cells["dgvchangeCashierCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["dgvchangeCashierCommission"].Value.ToString()) : 0.0m;
                        //var DriverCommission = dgvPriceGroupChange.Rows[i].Cells["dgvchangeDriverCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["dgvchangeDriverCommission"].Value) : 0.0m;
                        var CashierExternCommission = dgvPriceGroupChange.Rows[i].Cells["dgvchangeCashierExternCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["dgvchangeCashierExternCommission"].Value) : 0.0m;
                        InsertPriceGroupChanging(newID, int.Parse(cmbPriceGroupID.SelectedValue.ToString()),
                        Price, Duration.ToString(), CashierCommission, 0, CashierExternCommission,
                        SQLConn.trans);
                    }
                }
                //insert Images
                if (dgvdocuments.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvdocuments.Rows.Count; i++)
                    {
                        var DocumentFile = dgvdocuments.Rows[i].Cells["DocumentFile"].Value.ToString();
                        var DocumentName = dgvdocuments.Rows[i].Cells["DocumentName"].Value.ToString();
                        var ImageBytes = (byte[])dgvdocuments.Rows[i].Cells["ImageBytes"].Value;
                        var Notes = dgvdocuments.Rows[i].Cells["Notes"].Value != null ? dgvdocuments.Rows[i].Cells["Notes"].Value.ToString() : "";
                        InsertDocuments(newID, DocumentName, DocumentFile, Notes, ImageBytes, SQLConn.trans);
                    }
                }
                SQLConn.trans.Commit();
                Interaction.MsgBox("تم حفظ بيانات الواسطة البحرية بنجاح.", MsgBoxStyle.Information, "اضافة واسطة بحرية");

                Clear();
                //Gridfill();
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
        private void AddSeatransportCustomer(int SeaTransportID, int OwnerID, SqlTransaction transaction)
        {

            try
            {
                SQLConn.sqL = "INSERT INTO lnkSeaTransportOwner(SeaTransportID,OwnerID) VALUES(@SeaTransportID,@OwnerID)";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", SeaTransportID);
                SQLConn.cmd.Parameters.AddWithValue("@OwnerID", OwnerID);
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
        private void InsertPriceGroupChanging(int SeaTransportID, int PriceGroupID, decimal Price, string Duration, decimal CashierCommission, decimal DriverCommission, decimal CashierExternCommission, SqlTransaction transaction)
        {

            try
            {
                //PriceGroup = Same SeaTransportTypeId
                SQLConn.sqL = @"INSERT INTO PriceChanging(SeaTransportID,SeaTransportTypeID,Price,Duration,CashierCommission,CashierExternCommission) 
                                VALUES(@SeaTransportID,@PriceGroupID,@Price,@Duration,@CashierCommission,@CashierExternCommission)";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", SeaTransportID);
                SQLConn.cmd.Parameters.AddWithValue("@PriceGroupID", PriceGroupID);
                SQLConn.cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
                SQLConn.cmd.Parameters.AddWithValue("@Duration", Duration);
                SQLConn.cmd.Parameters.Add("@CashierCommission", SqlDbType.Decimal).Value = CashierCommission;
                //SQLConn.cmd.Parameters.Add("@DriverCommission", SqlDbType.Decimal).Value = DriverCommission;
                SQLConn.cmd.Parameters.Add("@CashierExternCommission", SqlDbType.Decimal).Value = CashierExternCommission;
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
        private void InsertDocuments(int SeaTransportID, string DocumentName, string DocumentFile, string Notes, byte[] ImageBytes, SqlTransaction transaction)
        {
            try
            {

                SQLConn.sqL = "INSERT INTO SeaTransportDocuments(DocumentName,Notes,DocumentFile,ImageBytes,SeaTransportID) VALUES(@DocumentName,@Notes,@DocumentFile,@ImageBytes,@SeaTransportID)";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", SeaTransportID);
                SQLConn.cmd.Parameters.AddWithValue("@DocumentName", DocumentName);
                SQLConn.cmd.Parameters.Add("@ImageBytes", SqlDbType.Binary).Value = ImageBytes;
                SQLConn.cmd.Parameters.AddWithValue("@Notes", Notes);
                SQLConn.cmd.Parameters.AddWithValue("@DocumentFile", DocumentFile);
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
        #endregion

        public void GridFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = SeaTransportGridFill();
                dgvData.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }


        public DataTable SeaTransportGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {

                SQLConn.sqL = "select ID,Name,height,Width,ConsumingByHour,Number,LicenseDate,MachineType,PersonsNumbers,InService,LastDateIn,LastDateOut,MachineNumber,NumberReference from SeaTransport";
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
        private void Clear()
        {
            btnSave.Text = "حفظ";
            txtName.Text = "";
            txtheight.Text = "";
            txtWidth.Text = "";
            dtpContractStartDate.Value = DateTime.Now;
            dtpContractEndDate.Value = DateTime.Now;
            dtpDelegationDate.Value = DateTime.Now;
            dtpLastDateIn.Value = DateTime.Now;
            dtpLastDateOut.Value = DateTime.Now;
            dtpLicenseDate.Value = DateTime.Now;
            txtNumber.Text = "";
            txtNumRefBoat.Text = "";
            txtMachineType.Text = "";
            txtPersonsNumbers.Text = "";
            txtConsumingByHour.Text = "";
            txtCurrentCounter.Text = "";
            cbInService.Checked = false;
            txtDocumentName.Text = "";
            cbOwnerClient.Checked = false;
            cbOwnerMarsa.Checked = false;
            cbIsDifferentPricing.Checked = false;

            //dgvdocuments.DataSource = dtimages;        
            SeaTransportTypeFill();
            PriceGroupFill();
            cmbPriceGroupID.SelectedValue = 0;
            SelectedPriceGroup = int.Parse(((DataRowView)cmbPriceGroupID.SelectedItem).Row[1].ToString());
            PriceGridFill();
            OwnersFill();
            DriversFill();
            dtimages.Clear();
            foreach (DataGridViewRow item in dgvdocuments.Rows)
            {
                dgvdocuments.Rows.Remove(item);
            }

        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1) 
                {
                    SelectedSeaTransportID = Convert.ToInt32(dgvData.CurrentRow.Cells["dgvSeaTransportID"].Value);
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

        #region FillSelectedControls

        public void FillControls()
        {
            try
            {
                DataTable SeatransportInfo = SeaTransportView(SelectedSeaTransportID);

                txtName.Text = SeatransportInfo.Rows[0]["Name"].ToString();
                cmbTypeID.SelectedValue = SeatransportInfo.Rows[0]["TypeID"].ToString();
                txtheight.Text = SeatransportInfo.Rows[0]["height"].ToString();
                txtWidth.Text = SeatransportInfo.Rows[0]["Width"].ToString();
                dtpContractStartDate.Text = SeatransportInfo.Rows[0]["ContractStartDate"].ToString();
                dtpContractEndDate.Text = SeatransportInfo.Rows[0]["ContractEndDate"].ToString();
                txtNumber.Text = SeatransportInfo.Rows[0]["Number"].ToString();
                txtNumRefBoat.Text = SeatransportInfo.Rows[0]["NumberReference"].ToString();//NumberReference
                dtpLicenseDate.Text = SeatransportInfo.Rows[0]["LicenseDate"].ToString();
                txtMachineType.Text = SeatransportInfo.Rows[0]["MachineType"].ToString();
                txtMachineNumber.Text = SeatransportInfo.Rows[0]["MachineNumber"].ToString();
                cmbDrivers.SelectedValue = SeatransportInfo.Rows[0]["DriverID"].ToString() == "" ? "0" : SeatransportInfo.Rows[0]["DriverID"].ToString();
                var OwnerTypeID = int.Parse(SeatransportInfo.Rows[0]["OwnerTypeID"].ToString());
                if (OwnerTypeID == 1)
                {
                    cbOwnerClient.Checked = true;
                    pnlclientdata.Visible = true;
                    cmbOwnerID.SelectedValue = SeatransportInfo.Rows[0]["OwnerID"].ToString() == "" ? "0" : SeatransportInfo.Rows[0]["OwnerID"].ToString();

                }
                else
                {
                    pnlclientdata.Visible = false;
                    cbOwnerMarsa.Checked = true;
                }

                cmbPriceGroupID.SelectedValue = SeatransportInfo.Rows[0]["PriceGroupID"].ToString();
                var IsDifferentPricing = Convert.ToBoolean(SeatransportInfo.Rows[0]["IsDifferentPricing"].ToString());
                if (IsDifferentPricing == true)
                {
                    cbIsDifferentPricing.Checked = true;
                    //Fill dgvPriceGroupChange                 
                    DataTable dtbl3 = new DataTable();
                    dtbl3 = GetPriceChangeTable(SelectedPriceGroup, SelectedSeaTransportID);
                    if (dtbl3.Rows.Count > 0)
                    {
                        dgvPriceGroupChange.DataSource = dtbl3;

                    }


                }
                else
                {
                    cbIsDifferentPricing.Checked = false;

                }

                //Fill Documents Table
                DocumentsGridFill();

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable SeaTransportView(int SeaTransportID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = @"select ID,Name,TypeID,height,Width,ConsumingByHour,Number,LicenseDate,MachineType,PersonsNumbers,InService,LastDateIn,LastDateOut,MachineNumber,ContractStartDate,ContractEndDate,OwnerID,OwnerTypeID,PriceGroupID,DriverID,IsDifferentPricing, NumberReference " +
                    "from SeaTransport where ID = @Id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", SeaTransportID);
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

        public DataTable GetPriceChangeTable(int SelectedPriceGroup, int SeaTransportID)
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                SQLConn.sqL = "select ID, Duration, Price, CashierCommission, CashierExternCommission, SeaTransportTypeID from PriceChanging Where SeaTransportTypeID = " + SelectedPriceGroup + " and SeatransportID = " + SeaTransportID + "";
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

        //Fill Documents Table
        public DataTable GetDocumentsTable(int SeaTransportID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select ID,DocumentName,Notes,ImageBytes,DocumentFile from SeaTransportDocuments Where SeatransportID = " + SeaTransportID + "";
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
        private void DocumentsGridFill()
        {

            try
            {

                DataTable dtbl = new DataTable();
                dtbl = GetDocumentsTable(SelectedSeaTransportID);
                if (dtbl.Rows.Count > 0)
                {

                    dgvdocuments.DataSource = dtbl;

                }

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        #endregion

        #region Update
        private void UpdateSeaTransport()
        {
            try
            {
                if (txtName.Text == "")
                {
                    Interaction.MsgBox("من فضلك أدخل إسم الواسطة البحرية");
                    return;

                }
                //Check if SeaTransport No Dublicate
                if (txtNumber.Text != "")
                {
                    if (IsNumberDublicateWhenUpdate(int.Parse(txtNumber.Text)) == true)
                    {
                        Interaction.MsgBox("رقم الواسطة البحرية موجود بالفعل ,من فضلك قم بإدخال رقم آخر");
                        return;
                    }

                }
                if (txtNumRefBoat.Text != "")
                {
                    if (IsNumRefBoatDublicateWhenUpdate(int.Parse(txtNumRefBoat.Text)) == true)
                    {
                        Interaction.MsgBox("رقم الواسطة التعريفي موجود بالفعل ,من فضلك قم بإدخال رقم آخر");
                        return;
                    }

                }

                int newID;
                SQLConn.sqL = @"Update SeaTransport Set Name = @Name,TypeID = @TypeID,height = @height,Width = @Width,
                    ContractStartDate = @ContractStartDate,
                    ContractEndDate = @ContractEndDate,Number=@Number,
                    LicenseDate=@LicenseDate,MachineType=@MachineType,
                    MachineNumber=@MachineNumber,OwnerTypeID=@OwnerTypeID, OwnerID=@OwnerID,
                    ConsumingByHour=@ConsumingByHour,PersonsNumbers=@PersonsNumbers,LastDateIn=@LastDateIn,
                    LastDateOut=@LastDateOut,
                    DelegationDate=@DelegationDate,CurrentCounter=@CurrentCounter,PriceGroupID=@PriceGroupID,
                    InService=@InService,IsDifferentPricing=@IsDifferentPricing,
                    DriverID = @DriverID, NumberReference=@NumberReference
                    where ID = @ID ";
                SQLConn.ConnDB();

                //Create Transaction 
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
               
                SQLConn.cmd.Parameters.Add("@ID", SqlDbType.Int).Value = SelectedSeaTransportID;
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtName.Text);
                SQLConn.cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = int.Parse(cmbTypeID.SelectedValue.ToString());
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@height", txtheight.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Width", txtWidth.Text));

                SQLConn.cmd.Parameters.Add("@ContractStartDate", SqlDbType.DateTime).Value = dtpContractStartDate.Value;
                SQLConn.cmd.Parameters.Add("@ContractEndDate", SqlDbType.DateTime).Value = dtpContractEndDate.Value;
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Number", txtNumber.Text));

                //SQLConn.cmd.Parameters.Add("@Number", SqlDbType.Int).Value = int.Parse(txtNumber.Text);
                SQLConn.cmd.Parameters.Add("@LicenseDate", SqlDbType.DateTime).Value = dtpLicenseDate.Value;
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@MachineType", txtMachineType.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@MachineNumber", txtMachineNumber.Text));

                if (cbOwnerClient.Checked == true)
                {
                    SQLConn.cmd.Parameters.Add("@OwnerTypeID", SqlDbType.Int).Value = 1;
                    SQLConn.cmd.Parameters.Add("@OwnerID", SqlDbType.Int).Value = int.Parse(cmbOwnerID.SelectedValue.ToString());
                }
                else
                {
                    SQLConn.cmd.Parameters.Add("@OwnerTypeID", SqlDbType.Int).Value = 2;
                    SQLConn.cmd.Parameters.Add("@OwnerID", SqlDbType.Int).Value = 0;
                }
              
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@ConsumingByHour", txtConsumingByHour.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@PersonsNumbers", txtPersonsNumbers.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@CurrentCounter", txtCurrentCounter.Text));
                SQLConn.cmd.Parameters.Add("@LastDateIn", SqlDbType.Date).Value = dtpLastDateIn.Value;
                SQLConn.cmd.Parameters.Add("@LastDateOut", SqlDbType.Date).Value = dtpLastDateOut.Value;
                SQLConn.cmd.Parameters.Add("@DelegationDate", SqlDbType.Date).Value = dtpDelegationDate.Value;
                
                SQLConn.cmd.Parameters.Add("@PriceGroupID", SqlDbType.Int).Value = int.Parse(cmbPriceGroupID.SelectedValue.ToString());
                SQLConn.cmd.Parameters.Add("@InService", SqlDbType.Bit).Value = cbInService.Checked;
                SQLConn.cmd.Parameters.Add("@IsDifferentPricing", SqlDbType.Bit).Value = cbIsDifferentPricing.Checked;
                SQLConn.cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = int.Parse(cmbDrivers.SelectedValue.ToString());
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@NumberReference", txtNumRefBoat.Text ));//
                
                SQLConn.cmd.ExecuteNonQuery();
                

                //Update PriceChanging
                DeletePriceChangingTable(SQLConn.trans);

                if (cbIsDifferentPricing.Checked == true)
                {
                    for (int i = 0; i < dgvPriceGroupChange.Rows.Count; i++)
                    {
                        var Duration = dgvPriceGroupChange.Rows[i].Cells["dgvchangeDuration"].Value;
                        var Price = dgvPriceGroupChange.Rows[i].Cells["dgvchangePrice"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["dgvchangePrice"].Value) : 0.0m;
                        var CashierCommission = dgvPriceGroupChange.Rows[i].Cells["dgvchangeCashierCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["dgvchangeCashierCommission"].Value.ToString()) : 0.0m;
                        //var DriverCommission = dgvPriceGroupChange.Rows[i].Cells["dgvchangeDriverCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["dgvchangeDriverCommission"].Value) : 0.0m;
                        var CashierExternCommission = dgvPriceGroupChange.Rows[i].Cells["dgvchangeCashierExternCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["dgvchangeCashierExternCommission"].Value) : 0.0m;
                        InsertPriceGroupChanging(SelectedSeaTransportID, int.Parse(cmbPriceGroupID.SelectedValue.ToString()),
                        Price, Duration.ToString(), CashierCommission, 0, CashierExternCommission,
                        SQLConn.trans);
                    }
                }

                //Update Images
                DeleteDocumentsTable(SQLConn.trans);
                if (dgvdocuments.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvdocuments.Rows.Count; i++)
                    {
                        var DocumentFile = dgvdocuments.Rows[i].Cells["DocumentFile"].Value.ToString();
                        var DocumentName = dgvdocuments.Rows[i].Cells["DocumentName"].Value.ToString();
                        var ImageBytes = (byte[])dgvdocuments.Rows[i].Cells["ImageBytes"].Value;
                        var Notes = dgvdocuments.Rows[i].Cells["Notes"].Value != null ? dgvdocuments.Rows[i].Cells["Notes"].Value.ToString() : "";
                        InsertDocuments(SelectedSeaTransportID, DocumentName, DocumentFile, Notes, ImageBytes, SQLConn.trans);
                    }
                }
                SQLConn.trans.Commit();
                Interaction.MsgBox("تم تحديث  بيانات الواسطة البحرية بنجاح.", MsgBoxStyle.Information, "تحديث واسطة بحرية");

                Clear();
                btnSave.Text = "حفظ";
                //Gridfill();
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

        private void DeletePriceChangingTable(SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = "Delete From PriceChanging WHERE SeaTransportID = " + SelectedSeaTransportID + "";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.ExecuteNonQuery();
                // Gridfill();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                // SQLConn.cmd.Dispose();
                //SQLConn.conn.Close();
            }
        }
        private void DeleteDocumentsTable(SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = "Delete From SeaTransportDocuments WHERE SeaTransportID = " + SelectedSeaTransportID + "";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.ExecuteNonQuery();
                // Gridfill();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                // SQLConn.cmd.Dispose();
                //SQLConn.conn.Close();
            }
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذه الواسطة", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
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
                SQLConn.sqL = "Delete From SeaTransport WHERE ID = " + SelectedSeaTransportID + "";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف  الواسطة البحرية");
                GridFill();
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
        //Insert Null Value
        private SqlParameter SetDBNullIfEmpty(string Parmname, string Parmvalue)
        {
            return new SqlParameter(Parmname, String.IsNullOrEmpty(Parmvalue) ? DBNull.Value : (object)Parmvalue);
        }
        private void btnAddFile_Click(object sender, EventArgs e)
        {

        }
        public bool IsNumberDublicateWhenInsert(int number)
        {
            bool IsDublicated = false;
            try
            {
                SQLConn.sqL = @"select Count(Number) from SeaTransport where Number = @Number";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Number", number);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    IsDublicated = true;
                }
                else
                {
                    IsDublicated = false;
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
            return IsDublicated;
        }

        public bool IsNumberDublicateWhenUpdate(int number)
        {
            bool IsDublicated = false;
            try
            {
                SQLConn.sqL = @"select Count(Number) from SeaTransport where Number = @Number and ID <> @Id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Number", number);                
                SQLConn.cmd.Parameters.AddWithValue("@Id", SelectedSeaTransportID);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    IsDublicated = true;
                }
                else
                {
                    IsDublicated = false;
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
            return IsDublicated;
        }

        public bool IsNumRefBoatDublicateWhenInsert(int NumRefBoat)
        {
            bool isDublicated = false;
            try
            {
                SQLConn.sqL = @"select Count(NumberReference) from SeaTransport where NumberReference = @NumRefBoat";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@NumRefBoat", NumRefBoat);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    isDublicated = true;
                }
                else
                {
                    isDublicated = false;
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
            return isDublicated;
        }

        public bool IsNumRefBoatDublicateWhenUpdate(int NumRefBoat)
        {
            bool isDublicated = false;
            try
            {
                SQLConn.sqL = @"select Count(NumberReference) from SeaTransport where NumberReference = @NumRefBoat and ID <> @Id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@NumRefBoat", NumRefBoat);
                SQLConn.cmd.Parameters.AddWithValue("@Id", SelectedSeaTransportID);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    isDublicated = true;
                }
                else
                {
                    isDublicated = false;
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
            return isDublicated;
        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnHijriDateIn_Click(object sender, EventArgs e)
        {
            dtpLastDateIn.Value = GetHijriDate();
        }


        private void btnHijriDateLicenseDate_Click(object sender, EventArgs e)
        {
            dtpLicenseDate.Value = GetHijriDate();
        }

        /// <summary>
        /// Return gregorian date from a hijri date
        /// </summary>
        /// <returns></returns>
        private DateTime GetHijriDate()
        {
            DateTime date = DateTime.Now;

            using (var frmhijri = new frmHijriDate())
            {
                if (DialogResult.OK == frmhijri.ShowDialog(this))
                {
                    if (!string.IsNullOrEmpty(frmhijri.TextboxDay) && !string.IsNullOrEmpty(frmhijri.TextboxMonth) && !string.IsNullOrEmpty(frmhijri.TextboxYear))
                    {
                        date = Common.GetGregorianDate(frmhijri.TextboxDay, frmhijri.TextboxMonth, frmhijri.TextboxYear);
                    }
                }
            }
            return date;
        }

        private void btnHijriDateLastDateOut_Click(object sender, EventArgs e)
        {
            dtpLastDateOut.Value = GetHijriDate();
        }

        private void btnHijriDateDelegationDate_Click(object sender, EventArgs e)
        {
            dtpDelegationDate.Value = GetHijriDate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpContractStartDate.Value = GetHijriDate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dtpContractEndDate.Value = GetHijriDate();
        }

        private void btnEditDocument_Click(object sender, EventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
