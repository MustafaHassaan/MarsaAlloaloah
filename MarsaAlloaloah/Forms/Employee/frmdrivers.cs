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
    public partial class frmdrivers : Form
    {
        byte[] NIDImage = null;
        byte[] LicenseImage = null;
        byte[] Document = null;
        byte[] KafeelNIDImage = null;

        public static byte[] SelectedImage;
        OpenFileDialog ofdNIDImage = new OpenFileDialog();
        OpenFileDialog ofdLicensemage = new OpenFileDialog();
        OpenFileDialog ofdDocuments = new OpenFileDialog();
        OpenFileDialog ofdKafeelNIDImage = new OpenFileDialog();

        DataTable dtimages = new DataTable();
        int DriverType;
        int SelectedDriverID;




        public frmdrivers()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pnldata.Visible = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
        private void ofdNIDImage_FileOk(object sender, CancelEventArgs e)
        {

            FileInfo info = new FileInfo(((OpenFileDialog)sender).FileName);
            if (info.Length > 1024 * 1024)
            {
                Interaction.MsgBox("حجم الملف أكبر من 1 ميجا");
                e.Cancel = true;
            }
        }

        private void btnSelectNIDImage_Click(object sender, EventArgs e)
        {
            ofdNIDImage.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";
            ofdNIDImage.FileName = string.Empty;
            ofdNIDImage.FileOk += ofdNIDImage_FileOk;
            //CreateImageTable();
            if (DialogResult.OK == ofdNIDImage.ShowDialog())
            {
                if (ofdNIDImage.FileName != string.Empty)
                {

                    try
                    {

                        NIDImage = ReadFile(ofdNIDImage.FileName);
                        //if (btnSave.Text == "حفظ")
                        //{

                        MemoryStream ms = new MemoryStream(NIDImage);
                        Image newimage = Image.FromStream(ms);
                        pbNID.Image = newimage;
                        pbNID.SizeMode = PictureBoxSizeMode.StretchImage;

                        //}
                        //else if (btnSave.Text == "تحديث")
                        //{

                        //}

                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox(ex.Message);
                    }
                }
            }
        }

        private void btnSelectDriverLicenseImage_Click(object sender, EventArgs e)
        {
            ofdLicensemage.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";
            ofdLicensemage.FileName = string.Empty;
            ofdLicensemage.FileOk += ofdNIDImage_FileOk;
            //CreateImageTable();
            if (DialogResult.OK == ofdLicensemage.ShowDialog())
            {
                if (ofdLicensemage.FileName != string.Empty)
                {

                    try
                    {

                        LicenseImage = ReadFile(ofdLicensemage.FileName);
                        //if (btnSave.Text == "حفظ")
                        //{

                        MemoryStream ms = new MemoryStream(LicenseImage);
                        Image newimage1 = Image.FromStream(ms);
                        pbDriverLicense.Image = newimage1;
                        pbDriverLicense.SizeMode = PictureBoxSizeMode.StretchImage;

                        //}
                        //else if (btnSave.Text == "تحديث")
                        //{

                        //}

                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox(ex.Message);
                    }
                }
            }
        }

        //#region SeaTransport
        //public void SeaTransportTypeFill()
        //{

        //    try
        //    {
        //        SQLConn.ConnDB();
        //        DataTable dtbl = new DataTable();
        //        dtbl = SQLConn.getTable("SELECT ID,Name FROM SeaTransportType");
        //        DataRow dr = dtbl.NewRow();
        //        dr["ID"] = 0;
        //        dr["Name"] = "--اختر--";
        //        dtbl.Rows.InsertAt(dr, 0);
        //        cmbTypeID.DataSource = dtbl;
        //        cmbTypeID.ValueMember = "ID";
        //        cmbTypeID.DisplayMember = "Name";
        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox(ex.ToString());

        //    }
        //    finally
        //    {
        //        SQLConn.cmd.Dispose();
        //        SQLConn.conn.Close();
        //    }

        //}
        //public void FillSeaTransportFill(int TypeID)
        //{

        //    try
        //    {
        //        SQLConn.ConnDB();
        //        DataTable dtbl = new DataTable();
        //        dtbl = SQLConn.getTable("SELECT ID,Name FROM SeaTransport Where TypeID = " + TypeID + "");
        //        DataRow dr = dtbl.NewRow();
        //        dr["ID"] = 0;
        //        dr["Name"] = "--اختر--";
        //        dtbl.Rows.InsertAt(dr, 0);
        //        cmbSeaTransportID.DataSource = dtbl;
        //        cmbSeaTransportID.ValueMember = "ID";
        //        cmbSeaTransportID.DisplayMember = "Name";
        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox(ex.ToString());

        //    }
        //    finally
        //    {
        //        SQLConn.cmd.Dispose();
        //        SQLConn.conn.Close();
        //    }

        //}
        //private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();
        //    if (int.Parse(SelectedValue) > 0)
        //    {
        //        FillSeaTransportFill(int.Parse(SelectedValue));

        //    }
        //}


        //#endregion

        //private void btnAddSeaTransport_Click(object sender, EventArgs e)
        //{
        //    //Check If Customer Dublicate 
        //    for (int i = 0; i < dgvSeaTransport.Rows.Count; i++)
        //    {
        //        string InsertedRowID = dgvSeaTransport.Rows[i].Cells[2].Value == null ? "" : dgvSeaTransport.Rows[i].Cells[2].Value.ToString();
        //        if (cmbSeaTransportID.SelectedValue.ToString() == InsertedRowID)
        //        {
        //            Interaction.MsgBox("لايمكن تكرار إضافة الواسطة البحرية");
        //            return;
        //        }
        //    }
        //    if (btnSave.Text == "حفظ")
        //    {
        //        DataGridViewRow row = (DataGridViewRow)dgvSeaTransport.Rows[0].Clone();
        //        row.Cells[1].Value = ((DataRowView)cmbSeaTransportID.SelectedItem).Row[1].ToString();
        //        row.Cells[2].Value = cmbSeaTransportID.SelectedValue;
        //        row.Cells[0].Value = dgvSeaTransport.Rows.Count;
        //        dgvSeaTransport.Rows.Add(row);
        //    }
        //    else
        //    {

        //        DataTable dataTable = (DataTable)dgvSeaTransport.DataSource;
        //        DataRow drToAdd = dataTable.NewRow();
        //        drToAdd["SlNo"] = dgvSeaTransport.Rows.Count;
        //        drToAdd["Name"] = ((DataRowView)cmbSeaTransportID.SelectedItem).Row[1].ToString();
        //        drToAdd["SeaTransportID"] = cmbSeaTransportID.SelectedValue;
        //        //drToAdd["dgvID"] = 0;
        //        dataTable.Rows.Add(drToAdd);
        //        dataTable.AcceptChanges();

        //    }
        //}

        private void frmdrivers_Load(object sender, EventArgs e)
        {
            FillDriverTypes();
            GridFill();
        }

        //private void btnRemoveSeaTransport_Click(object sender, EventArgs e)
        //{
        //    int SelectedRowsCount = dgvSeaTransport.Rows.GetRowCount(DataGridViewElementStates.Selected);
        //    if (SelectedRowsCount > 0)
        //    {
        //        for (int i = 0; i < SelectedRowsCount; i++)
        //        {
        //            dgvSeaTransport.Rows.RemoveAt(dgvSeaTransport.SelectedRows[0].Index);

        //        }
        //    }

        //    // ReOrder Serial No
        //    for (int i = 0; i < dgvSeaTransport.Rows.Count - 1; i++)
        //    {
        //        dgvSeaTransport.Rows[i].Cells[0].Value = i + 1;

        //    }

        //}

        private void btnAddFile_Click(object sender, EventArgs e)
        {

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

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            ofdDocuments.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";
            ofdDocuments.FileName = string.Empty;
            ofdDocuments.FileOk += ofdNIDImage_FileOk;
            CreateImageTable();
            if (DialogResult.OK == ofdDocuments.ShowDialog())
            {
                if (ofdDocuments.FileName != string.Empty)
                {
                    try
                    {
                        Document = ReadFile(ofdDocuments.FileName);
                        if (btnSave.Text == "حفظ")
                        {
                            DataRow dr = dtimages.NewRow();
                            dr["DocumentFile"] = Path.GetFileName(ofdDocuments.FileName);
                            dr["DocumentName"] = txtDocumentName.Text;
                            dr["ImageBytes"] = Document;
                            //dr["DocumentFile"] = logo;
                            dtimages.Rows.Add(dr);
                            dgvdocuments.DataSource = dtimages;
                        }
                        else if (btnSave.Text == "تحديث")
                        {
                            dtimages = (DataTable)dgvdocuments.DataSource;
                            DataRow drToAdd = dtimages.NewRow();
                            drToAdd["DocumentFile"] = Path.GetFileName(ofdDocuments.FileName);
                            drToAdd["DocumentName"] = txtDocumentName.Text;
                            drToAdd["ImageBytes"] = Document;
                            drToAdd["ID"] = 0;
                            dtimages.Rows.Add(drToAdd);
                            dtimages.AcceptChanges();
                        }

                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox(ex.Message);
                    }
                }
            }
        }

        private void btnShowDocument_Click(object sender, EventArgs e)
        {
            if (dgvdocuments.RowCount > 0 && dgvdocuments.SelectedRows[0] != null)
            {
                int index = dgvdocuments.SelectedRows[0].Index;
                if (index >= 0)
                {
                    DataGridViewRow SelectedRow = dgvdocuments.Rows[index];
                    SelectedImage = (byte[])SelectedRow.Cells[3].Value;
                    frmShowImageDriver si = new frmShowImageDriver();
                    si.Show();
                }
            }
        }

        private void btnDeleteDocument_Click(object sender, EventArgs e)
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


        //Get 
        public void FillDriverTypes()
        {

            try
            {
                //SQLConn.ConnDB();
                //DataTable dtbl = new DataTable();
                //dtbl = SQLConn.getTable("SELECT ID,Type FROM DriverType");
                //if (dtbl.Rows.Count > 0)
                //{
                //    cmbDriverType.DataSource = dtbl;
                //    cmbDriverType.DisplayMember = "Type";
                //    cmbDriverType.ValueMember = "ID";
                //}

                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Type FROM DriverType");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Type"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbDriverType.DataSource = dtbl;
                cmbDriverType.ValueMember = "ID";
                cmbDriverType.DisplayMember = "Type";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "حفظ")
            {
                AddDriver();
                GridFill();
            }
            else
            {
                UpdateDriver();
                GridFill();
            }


        }
        #region AddDriver
        private void AddDriver()
        {
            try
            {
                //validation
                if (ValidateDriverInfo())
                {
                    SQLConn.ConnDB();
                    SQLConn.BeginTransaction();
                    if (cbIsEmployee.Checked == true)
                    {
                        //Insert Employee Table Then Insert Driver Table
                        int newID;
                        SQLConn.sqL = @"INSERT INTO Employees(Name,NID,NIDExpireDate,Mobile,JobID,BaseSalary,
                    Housing,Transportation,TotalSalary)
                    VALUES(@Name,@NID,@NIDExpireDate,@Mobile,@JobID,@BaseSalary,
                    @Housing,@Transportation,@TotalSalary);SELECT CAST(scope_identity() AS int)";

                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                        SQLConn.cmd.Parameters.AddWithValue("@Name", txtDriverName.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@NID", txtNID.Text);
                        SQLConn.cmd.Parameters.Add("@NIDExpireDate", SqlDbType.DateTime).Value = dtpNIDExpireDate.Value;
                        SQLConn.cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = txtMobile.Text == "" ? string.Empty : txtMobile.Text;
                        SQLConn.cmd.Parameters.Add("@JobID", SqlDbType.Int).Value = 2;
                        SQLConn.cmd.Parameters.Add("@BaseSalary", SqlDbType.Decimal).Value = Common.ConvertCurrencyFieldToStringOnSqlQuery(txtBaseSalary.Text);
                        SQLConn.cmd.Parameters.Add("@Housing", SqlDbType.Decimal).Value = Common.ConvertCurrencyFieldToStringOnSqlQuery(txtHousing.Text);
                        SQLConn.cmd.Parameters.Add("@Transportation", SqlDbType.Decimal).Value = Common.ConvertCurrencyFieldToStringOnSqlQuery(txtTransportation.Text);
                        SQLConn.cmd.Parameters.Add("@TotalSalary", SqlDbType.Decimal).Value = Common.ConvertCurrencyFieldToStringOnSqlQuery(lblTotalSalary.Text);
                        newID = (int)SQLConn.cmd.ExecuteScalar();
                        //Insert Driver Data
                        InsertDriver(newID, cbIsEmployee.Checked, SQLConn.trans);
                        SQLConn.trans.Commit();
                        Interaction.MsgBox("تم حفظ بيانات السائق بنجاح.", MsgBoxStyle.Information, "اضافة سائق");
                        Clear();
                    }
                    else
                    {
                        InsertDriver(0, cbIsEmployee.Checked, SQLConn.trans);
                        SQLConn.trans.Commit();
                        Interaction.MsgBox("تم حفظ بيانات السائق بنجاح.", MsgBoxStyle.Information, "اضافة سائق");
                        Clear();
                    }
                }
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
        public bool ValidateDriverInfo()
        {
            if (txtDriverName.Text == "")
            {
                Interaction.MsgBox("من فضلك أدخل إسم السائق");
                return false;

            }
            if (txtNID.Text == "")
            {
                Interaction.MsgBox("من فضلك رقم هوية السائق");
                return false;

            }
            //if (LicenseImage == null)
            //{
            //    Interaction.MsgBox("من فضلك أضف صورة رخصة القيادة");
            //    return false;
            //}
            //if (NIDImage == null)
            //{
            //    Interaction.MsgBox("من فضلك أضف صورة الهوية");
            //    return false;
            //}
            //if (DriverType == 1)
            //{
            //    if (txtKaeelName.Text == "")
            //    {
            //        Interaction.MsgBox("من فضلك أدخل إسم الكفيل");
            //        return false;
            //    }

            //}

            return true;
        }

        //Insert Driver Data 
        private void InsertDriver(int EmployeeID, bool IsEmployee, SqlTransaction transaction)
        {

            try
            {

                int NewDriverID;
                SQLConn.sqL = @"INSERT INTO Drivers(Name,NID,MobileNo,LicenseExpireDate,
                DriverNIDImage,LicenseImage,DriverTypeID,IsEmployee,EmployeeID) 
                VALUES(@Name,@NID,@MobileNo,@LicenseExpireDate,
                 CONVERT(varbinary(max), @DriverNIDImage, 0) , CONVERT(varbinary(max), @LicenseImage) , @DriverTypeID,@IsEmployee,@EmployeeID);SELECT CAST(scope_identity() AS int)";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtDriverName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@NID", txtNID.Text);
                SQLConn.cmd.Parameters.AddWithValue("@MobileNo", txtMobile.Text);
                SQLConn.cmd.Parameters.Add("@LicenseExpireDate", SqlDbType.DateTime).Value = dtpLicenseExpire.Value;                
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@DriverNIDImage", NIDImage));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@LicenseImage", LicenseImage));
                SQLConn.cmd.Parameters.Add("@IsEmployee", SqlDbType.Bit).Value = IsEmployee;
                SQLConn.cmd.Parameters.Add("@DriverTypeID", SqlDbType.Int).Value = DriverType;

                if (IsEmployee == true)
                {
                    SQLConn.cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;
                }
                else
                {
                    SQLConn.cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = DBNull.Value;
                }
                NewDriverID = (int)SQLConn.cmd.ExecuteScalar();
                if (DriverType == 1)
                {
                    //Insert Kafeel Data Table
                    InsertDriverKafeelData(NewDriverID, transaction);
                }

                //Insert SeaTransport For Driver - LinkDriverSeaTransporttable
                ////Add lnkSeatransportCustomer 
                //for (int i = 0; i < dgvSeaTransport.Rows.Count - 1; i++)
                //{

                //    var SeaTransportID = int.Parse(dgvSeaTransport.Rows[i].Cells["dgvSeaTrsansportID"].Value.ToString());
                //    InsertDriverSeaTransport(NewDriverID, SeaTransportID, SQLConn.trans);

                //}
                //Insert Driver Documents
                if (dgvdocuments.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvdocuments.Rows.Count; i++)
                    {
                        var DocumentFile = dgvdocuments.Rows[i].Cells["DocumentFile"].Value.ToString();
                        var DocumentName = dgvdocuments.Rows[i].Cells["DocumentName"].Value.ToString();
                        var ImageBytes = (byte[])dgvdocuments.Rows[i].Cells["ImageBytes"].Value;
                        var Notes = dgvdocuments.Rows[i].Cells["Notes"].Value != null ? dgvdocuments.Rows[i].Cells["Notes"].Value.ToString() : "";
                        InsertDocuments(NewDriverID, DocumentName, DocumentFile, Notes, ImageBytes, SQLConn.trans);
                    }
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

        }

        private SqlParameter SetDBNullIfEmpty(string v, byte[] nIDImage)
        {
            return new SqlParameter(v, nIDImage == null ? DBNull.Value : (object)nIDImage);
        }

        //Insert Driver Data 
        private void InsertDriverKafeelData(int DriverID, SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = @"INSERT INTO DriverKafeelData(Name,Mobile,NID,Address,Image,DriverID)     
                VALUES(@Name,@Mobile,@NID,@Address, CONVERT(varbinary(max), @Image, 0) ,@DriverID)";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtKaeelName.Text);
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@NID", txtKafeelNID.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Mobile", txtKafeelMobile.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Address", txtKafeelAddress.Text));

                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Image", KafeelNIDImage));

                SQLConn.cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

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
        private void InsertDriverSeaTransport(int DriverID, int SeaTransportID, SqlTransaction transaction)
        {

            try
            {
                SQLConn.sqL = @"INSERT INTO lnkDriverSeaTransport(DriverID,SeaTransportID)     
                VALUES(@DriverID,@SeaTransportID)";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@DriverID", DriverID);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportID", SeaTransportID);
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
                SQLConn.sqL = @"INSERT INTO DriverDocuments(DocumentName,Notes,DocumentFile,ImageBytes,DriverID) 
                    VALUES(@DocumentName,@Notes,@DocumentFile, CONVERT(varbinary(max), @ImageBytes, 0),@DriverID)";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@DriverID", SeaTransportID);
                SQLConn.cmd.Parameters.AddWithValue("@DocumentName", DocumentName);
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@ImageBytes", ImageBytes));
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

        #region GridFill
        public void GridFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = DriversGridFill();
                dgvDrivers.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        public DataTable DriversGridFill()
        {
            DataTable dtbl = new DataTable();            
            try
            {

                SQLConn.sqL = "select ID,Name,NID,MobileNo,LicenseExpireDate, IsEmployee from Drivers";
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
        #endregion

        private void btnSelectKafeelNIDImage_Click(object sender, EventArgs e)
        {
            ofdKafeelNIDImage.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";
            ofdKafeelNIDImage.FileName = string.Empty;
            ofdKafeelNIDImage.FileOk += ofdNIDImage_FileOk;
            //CreateImageTable();
            if (DialogResult.OK == ofdKafeelNIDImage.ShowDialog())
            {
                if (ofdKafeelNIDImage.FileName != string.Empty)
                {

                    try
                    {

                        KafeelNIDImage = ReadFile(ofdKafeelNIDImage.FileName);
                        //if (btnSave.Text == "حفظ")
                        //{

                        MemoryStream ms = new MemoryStream(KafeelNIDImage);
                        Image newimage = Image.FromStream(ms);
                        pbKafeelNID.Image = newimage;
                        pbKafeelNID.SizeMode = PictureBoxSizeMode.StretchImage;

                        //}
                        //else if (btnSave.Text == "تحديث")
                        //{

                        //}

                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox(ex.Message);
                    }
                }
            }
        }

        private void cbIsEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsEmployee.Checked == true)
            {
                grpSalary.Visible = true;
            }
            else
            {
                grpSalary.Visible = false;

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pbDriverLicense_Click(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            btnSave.Text = "حفظ";
            txtDriverName.Text = "";
            txtNID.Text = "";
            txtMobile.Text = "";
            dtpNIDExpireDate.Value = DateTime.Now;
            dtpLicenseExpire.Value = DateTime.Now;
            pbDriverLicense.Image = null;
            pbKafeelNID.Image = null;
            pbNID.Image = null;
            //cmbTypeID.SelectedValue = 0;
            // cmbSeaTransportID.SelectedValue = 0;
            txtKaeelName.Text = "";
            txtKafeelAddress.Text = "";
            txtKafeelMobile.Text = "";
            txtKafeelNID.Text = "";
            
            cbIsEmployee.Checked = false;
            txtDocumentName.Text = "";
            if (dtimages != null)
                dtimages.Clear();
            cmbDriverType.SelectedItem = 0;
            pnldata.Visible = false;
            grpSalary.Visible = false;

            NIDImage = null;
            LicenseImage = null;
            KafeelNIDImage = null;
            //SeaTransportTypeFill();
        }

        private void dgvDrivers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && dgvDrivers.CurrentRow.Cells["dgvDriverID"] != null && dgvDrivers.CurrentRow.Cells["dgvDriverID"].Value != null)
                {
                    SelectedDriverID = Convert.ToInt32(dgvDrivers.CurrentRow.Cells["dgvDriverID"].Value);
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

        #region ViewData

        public void FillControls()
        {
            try
            {
                DataTable DriversInfo = DriverView(SelectedDriverID);
                txtDriverName.Text = DriversInfo.Rows[0]["Name"].ToString();
                //cmb.SelectedValue = SeatransportInfo.Rows[0]["TypeID"].ToString();
                txtNID.Text = DriversInfo.Rows[0]["NID"].ToString();
                txtMobile.Text = DriversInfo.Rows[0]["MobileNo"].ToString();

                dtpLicenseExpire.Text = DriversInfo.Rows[0]["LicenseExpireDate"].ToString();                
                cbIsEmployee.Checked = (bool)DriversInfo.Rows[0]["IsEmployee"];
                //ReadImages
                if (!(DriversInfo.Rows[0]["DriverNIDImage"] is DBNull))
                {
                    NIDImage = (byte[])DriversInfo.Rows[0]["DriverNIDImage"];
                    MemoryStream ms = new MemoryStream(NIDImage);
                    Image newimage = Image.FromStream(ms);
                    pbNID.Image = newimage;
                    pbNID.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pbNID.Image = null;
                }

                if (!(DriversInfo.Rows[0]["LicenseImage"] is DBNull))
                {
                    LicenseImage = (byte[])DriversInfo.Rows[0]["LicenseImage"];
                    MemoryStream ms = new MemoryStream(LicenseImage);
                    Image newimage1 = Image.FromStream(ms);
                    pbDriverLicense.Image = newimage1;
                    pbDriverLicense.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pbDriverLicense.Image = null;
                }
                ////set Driver Type Checked 
                //for (int i = 0; i < cblstDriverType.Items.Count; i++)
                //{
                //    int DriverTypeID = (int)DriversInfo.Rows[0]["DriverTypeID"];
                //    var row = ((DataRowView)cblstDriverType.Items[i]);
                //    DriverType = int.Parse(row[0].ToString());
                //    if (DriverType == DriverTypeID)
                //    {
                //        cblstDriverType.SetItemChecked(i, true);
                //    }
                //}

                cmbDriverType.SelectedValue = DriversInfo.Rows[0]["DriverTypeID"].ToString();

                // lnkDriverSeaTransportGridFill();
                //Fill Documents Table
                DocumentsGridFill();

                if ((int)DriversInfo.Rows[0]["DriverTypeID"] == 1)
                {
                    pnldata.Visible = true;
                    DriverKafeelDataFill();
                }
                //Fill employeeData 
                if ((bool)DriversInfo.Rows[0]["IsEmployee"] == true)
                {
                    var EmployeeID = (int)DriversInfo.Rows[0]["EmployeeID"];
                    EmployeeDataFill(EmployeeID);
                    grpSalary.Visible = true;

                }


            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        //public DataTable GetlnkDriverSeaTransportTable(int id)
        //{
        //    DataTable dtbl = new DataTable();
        //    dtbl.Columns.Add("SlNo", typeof(int));
        //    dtbl.Columns["SlNo"].AutoIncrement = true;
        //    dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
        //    dtbl.Columns["SlNo"].AutoIncrementStep = 1;
        //    try
        //    {
        //        SQLConn.sqL = @"SELECT dbo.SeaTransport.Name, dbo.lnkDriverSeaTransport.SeaTransportID FROM
        //                      dbo.SeaTransport RIGHT OUTER JOIN dbo.lnkDriverSeaTransport ON dbo.SeaTransport.ID = dbo.lnkDriverSeaTransport.SeaTransportID 
        //                      Where dbo.lnkDriverSeaTransport.DriverID = " + id + "";
        //        SQLConn.ConnDB();
        //        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
        //        SQLConn.da = new SqlDataAdapter(SQLConn.cmd);
        //        SQLConn.da.Fill(dtbl);

        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox(ex.ToString());
        //    }
        //    finally
        //    {
        //        SQLConn.cmd.Dispose();
        //        SQLConn.conn.Close();
        //    }
        //    return dtbl;
        //}
        //Fill SeaTransport 
        //private void lnkDriverSeaTransportGridFill()
        //{

        //    try
        //    {

        //        DataTable dtbl = new DataTable();
        //        dtbl = GetlnkDriverSeaTransportTable(SelectedDriverID);
        //        if (dtbl.Rows.Count > 0)
        //        {
        //            dgvSeaTransport.DataSource = dtbl;


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox(ex.ToString());

        //    }
        //}
        public DataTable DriverView(int DriverID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select ID,Name,NID,MobileNo,LicenseExpireDate,DriverNIDImage,LicenseImage,DriverTypeID,IsEmployee,EmployeeID from Drivers where ID = @Id";
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
        //Fill Documents
        public DataTable GetDocumentsTable(int DriverID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select ID,DocumentName,Notes,ImageBytes,DocumentFile from DriverDocuments Where DriverID = " + DriverID + "";
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
                dtbl = GetDocumentsTable(SelectedDriverID);
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

        //Fill Kafeel Data
        public DataTable GetDriverKafeelData(int id)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT Name,Mobile,NID,Address,Image from DriverKafeelData Where DriverID = " + id + "";
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
        private void DriverKafeelDataFill()
        {

            try
            {

                DataTable dtbl = new DataTable();
                dtbl = GetDriverKafeelData(SelectedDriverID);
                if (dtbl.Rows.Count > 0)
                {
                    //dgvSeaTransport.DataSource = dtbl;
                    txtKaeelName.Text = dtbl.Rows[0]["Name"].ToString();
                    txtKafeelAddress.Text = dtbl.Rows[0]["Address"].ToString();
                    txtKafeelMobile.Text = dtbl.Rows[0]["Mobile"].ToString();
                    txtKafeelNID.Text = dtbl.Rows[0]["NID"].ToString();
                    if (dtbl.Rows[0]["Image"] != DBNull.Value)
                    {
                        LicenseImage = (byte[])dtbl.Rows[0]["Image"];
                        MemoryStream ms = new MemoryStream(LicenseImage);
                        Image newimage = Image.FromStream(ms);
                        pbKafeelNID.Image = newimage;
                        pbKafeelNID.SizeMode = PictureBoxSizeMode.StretchImage;
                    }



                }

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        //Fill Employee
        public DataTable GetEmployeeData(int employeeID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT BaseSalary,Housing,Transportation,TotalSalary, NIDExpireDate From Employees Where ID = " + employeeID + "";
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
        private void EmployeeDataFill(int EmployeeID)
        {

            try
            {
                DataTable dtbl = new DataTable();
                dtbl = GetEmployeeData(EmployeeID);
                if (dtbl.Rows.Count > 0)
                {
                    //dgvSeaTransport.DataSource = dtbl;
                    txtBaseSalary.Text = dtbl.Rows[0]["BaseSalary"].ToString();
                    txtHousing.Text = dtbl.Rows[0]["Housing"].ToString();
                    txtTransportation.Text = dtbl.Rows[0]["Transportation"].ToString();
                    lblTotalSalary.Text = dtbl.Rows[0]["TotalSalary"].ToString();
                    dtpNIDExpireDate.Text = dtbl.Rows[0]["NIDExpireDate"].ToString();

                }

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        #endregion
        #region UpdateData
        private void UpdateDriver()
        {
            try
            {
                if (ValidateDriverInfo())
                {

                    SQLConn.ConnDB();
                    SQLConn.BeginTransaction();
                    //Get EmployeeID
                    int EmpID = GetEmployeeID(SelectedDriverID);
                    if (EmpID != 0) cbIsEmployee.Checked = true;
                    if (cbIsEmployee.Checked == true)
                    {
                        //Insert Employee Table Then Insert Driver Table
                        int newID;
                        SQLConn.sqL = @"Update Employees Set Name = @Name,NID = @NID,
                    Mobile = @Mobile,JobID = @JobID,BaseSalary = @BaseSalary,
                    Housing = @Housing,Transportation = @Transportation,TotalSalary = @TotalSalary, NIDExpireDate=@NIDExpireDate Where ID = @EmpID";
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                        SQLConn.cmd.Parameters.AddWithValue("@Name", txtDriverName.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@NID", txtNID.Text);
                        SQLConn.cmd.Parameters.Add("@NIDExpireDate", SqlDbType.DateTime).Value = dtpNIDExpireDate.Value;
                        SQLConn.cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                        SQLConn.cmd.Parameters.Add("@JobID", SqlDbType.Int).Value = 2;
                        SQLConn.cmd.Parameters.Add("@BaseSalary", SqlDbType.Decimal).Value = Common.ConvertCurrencyFieldToStringOnSqlQuery(txtBaseSalary.Text);
                        SQLConn.cmd.Parameters.Add("@Housing", SqlDbType.Decimal).Value = Common.ConvertCurrencyFieldToStringOnSqlQuery(txtHousing.Text);
                        SQLConn.cmd.Parameters.Add("@Transportation", SqlDbType.Decimal).Value = Common.ConvertCurrencyFieldToStringOnSqlQuery(txtTransportation.Text);
                        SQLConn.cmd.Parameters.Add("@TotalSalary", SqlDbType.Decimal).Value = Common.ConvertCurrencyFieldToStringOnSqlQuery(lblTotalSalary.Text);
                        SQLConn.cmd.Parameters.AddWithValue("@EmpID", EmpID);

                        SQLConn.cmd.ExecuteNonQuery();
                        //Insert Driver Data
                        UpdateDriver(EmpID, cbIsEmployee.Checked, SQLConn.trans);
                        SQLConn.trans.Commit();
                        Interaction.MsgBox("تم تحديث بيانات السائق بنجاح.", MsgBoxStyle.Information, "اضافة سائق");
                        Clear();
                    }
                    else
                    {
                        UpdateDriver(0, cbIsEmployee.Checked, SQLConn.trans);
                        SQLConn.trans.Commit();
                        Interaction.MsgBox("تم تحديث بيانات السائق بنجاح.", MsgBoxStyle.Information, "تحديث سائق");
                        Clear();
                    }
                }
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
        private int GetEmployeeID(int DriverID)
        {
            int EmpID = 0;
            try
            {
                SQLConn.sqL = @"Select EmployeeID From Drivers Where ID = @DriverID";
                SQLConn.ConnDB();
                //Create Transaction 
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@DriverID", DriverID);
                if (SQLConn.cmd.ExecuteScalar() != DBNull.Value)
                {
                    EmpID = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
                }

                return EmpID;


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
            return EmpID;

        }
        private void UpdateDriver(int EmpID, bool IsEmployee, SqlTransaction transaction)
        {
            try
            {
                int NewDriverID;
                SQLConn.sqL = @"Update Drivers Set Name=@Name,NID = @NID,MobileNo = @MobileNo,LicenseExpireDate = @LicenseExpireDate,
                DriverNIDImage = CONVERT(varbinary(max), @DriverNIDImage, 0), LicenseImage = CONVERT(varbinary(max), @LicenseImage, 0),DriverTypeID = @DriverTypeID,
                IsEmployee = @IsEmployee ,EmployeeID = @EmployeeID Where ID = @DriverID";

                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtDriverName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@NID", txtNID.Text);
                SQLConn.cmd.Parameters.AddWithValue("@MobileNo", txtMobile.Text);
                SQLConn.cmd.Parameters.Add("@LicenseExpireDate", SqlDbType.DateTime).Value = dtpLicenseExpire.Value;
                SQLConn.cmd.Parameters.Add((SetDBNullIfEmpty("@DriverNIDImage", NIDImage)));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@LicenseImage", LicenseImage));
                SQLConn.cmd.Parameters.Add("@IsEmployee", SqlDbType.Bit).Value = IsEmployee;
                SQLConn.cmd.Parameters.Add("@DriverTypeID", SqlDbType.Int).Value = DriverType;
                SQLConn.cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = SelectedDriverID;
                if (IsEmployee == true)
                {
                    SQLConn.cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmpID;
                }
                else
                {
                    SQLConn.cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = DBNull.Value;
                }
                SQLConn.cmd.ExecuteNonQuery();
                //Update Kafeel Data

                DriverType = (int)cmbDriverType.SelectedValue;
                if (DriverType == 1)// 
                {
                    DeleteKafeelData(transaction);
                    InsertDriverKafeelData(SelectedDriverID, transaction);
                }
                else
                {
                    InsertDriverKafeelData(SelectedDriverID, transaction);
                }




                //Insert SeaTransport For Driver - LinkDriverSeaTransporttable
                //Add lnkSeatransportCustomer 
                //DeleteDriverSeaTransport(SQLConn.trans);
                //for (int i = 0; i < dgvSeaTransport.Rows.Count - 1; i++)
                //{

                //    var SeaTransportID = int.Parse(dgvSeaTransport.Rows[i].Cells["dgvSeaTrsansportID"].Value.ToString());
                //    InsertDriverSeaTransport(SelectedDriverID, SeaTransportID, SQLConn.trans);

                //}

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
                        InsertDocuments(SelectedDriverID, DocumentName, DocumentFile, Notes, ImageBytes, SQLConn.trans);
                    }
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

        }
        private void DeleteKafeelData(SqlTransaction transaction)
        {

            try
            {
                SQLConn.sqL = "Delete From DriverKafeelData WHERE DriverID = " + SelectedDriverID + "";
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
        private void DeleteDriverSeaTransport(SqlTransaction transaction)
        {

            try
            {
                SQLConn.sqL = "Delete From lnkDriverSeaTransport WHERE DriverID = " + SelectedDriverID + "";
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
                SQLConn.sqL = "Delete From DriverDocuments WHERE DriverID = " + SelectedDriverID + "";
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
        #region DeleteDrivers
        private void DeleteEmployee(SqlTransaction transaction, int EmployeeID)
        {
            try
            {
                SQLConn.sqL = "Delete From Employees WHERE ID = " + EmployeeID + "";
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


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا السائق", "رسالة تأكيد", MessageBoxButtons.YesNo);
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
                SQLConn.BeginTransaction();
                SQLConn.sqL = "Delete From Drivers WHERE ID = " + SelectedDriverID + "";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                int x = SQLConn.cmd.ExecuteNonQuery();
                //Delete Document
                DeleteDocumentsTable(SQLConn.trans);
                //Delete SeaTransport 
                DeleteDriverSeaTransport(SQLConn.trans);
                //DeleteEmployee                
                if (cbIsEmployee.Checked == true)
                {
                    //Get EmployeeID
                    int EmpID = GetEmployeeID(SelectedDriverID);
                    DeleteEmployee(SQLConn.trans, EmpID);

                }
                //Delete Kafeel Data If Change Driver Type 
                DriverType = (int)cmbDriverType.SelectedValue;
                if (DriverType == 1)// 
                {
                    DeleteKafeelData(SQLConn.trans);
                }

                SQLConn.trans.Commit();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف  بيانات الموظف");
                GridFill();
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

        #endregion
        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            decimal Total = 0.0m;
            var BaseSalary = txtBaseSalary.Text == "" ? 0.0m : decimal.Parse(txtBaseSalary.Text);
            var Housing = txtHousing.Text == "" ? 0.0m : decimal.Parse(txtHousing.Text);
            var Transportation = txtTransportation.Text == "" ? 0.0m : decimal.Parse(txtTransportation.Text);
            Total = BaseSalary + Housing + Transportation;
            lblTotalSalary.Text = Total.ToString();

        }
        private void dgvDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //Insert Null Value
        private SqlParameter SetDBNullIfEmpty(string Parmname, string Parmvalue)
        {
            return new SqlParameter(Parmname, String.IsNullOrEmpty(Parmvalue) ? DBNull.Value : (object)Parmvalue);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvdocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHijriDateExpireDate_Click(object sender, EventArgs e)
        {
            using (var frmhijri = new frmHijriDate())
            {
                if (DialogResult.OK == frmhijri.ShowDialog(this))
                {

                    DateTime date = Common.GetGregorianDate(frmhijri.TextboxDay, frmhijri.TextboxMonth, frmhijri.TextboxYear);
                    dtpLicenseExpire.Value = date;

                }
            }
        }

        private void btnHijriDateExpireNID_Click(object sender, EventArgs e)
        {
            using (var frmhijri = new frmHijriDate())
            {
                if (DialogResult.OK == frmhijri.ShowDialog(this))
                {

                    DateTime date = Common.GetGregorianDate(frmhijri.TextboxDay, frmhijri.TextboxMonth, frmhijri.TextboxYear);
                    dtpNIDExpireDate.Value = date;

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "السائقين", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnEditDocument_Click(object sender, EventArgs e)
        {

        }

        private void cmbDriverType_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cmbDriverType.SelectedValue != null && cmbDriverType.SelectedIndex > 0)
            {
                DriverType = (int)(cmbDriverType.SelectedValue);
                if (DriverType == 1)
                    pnldata.Visible = true;
                else
                    pnldata.Visible = false;
            }
            else
            {
                pnldata.Visible = false;
            }
        }
    }

}
