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
    public partial class frmemployees : Form
    {
        OpenFileDialog ofdDocuments = new OpenFileDialog();
        DataTable dtimages = new DataTable();
        byte[] logo = null;
        public static byte[] SelectedImage;
        int SelectedEmployeeID;

        public frmemployees()
        {
            InitializeComponent();
            dtimages.Clear();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmdrivers objSettings = new frmdrivers();
            frmdrivers open = Application.OpenForms["frmdrivers"] as frmdrivers;
            if (open == null)
            {
                objSettings.MdiParent = this.ParentForm;
                objSettings.Show();
            }
            else
            {
                open.Activate();
                if (open.WindowState == FormWindowState.Minimized)
                {
                    open.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "حفظ")
            {
                AddEmployee();
                GridFill();
            }
            else
            {
                UpdateEmployee();

            }

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
                            if (dgvdocuments.DataSource == null)
                            {
                                DataRow dr = dtimages.NewRow();
                                dr["DocumentFile"] = Path.GetFileName(ofdDocuments.FileName);
                                dr["DocumentName"] = txtDocumentName.Text;
                                dr["ImageBytes"] = logo;
                                //dr["DocumentFile"] = logo;
                                dtimages.Rows.Add(dr);
                                dgvdocuments.DataSource = dtimages;
                            }
                            else
                            {
                                dtimages = (DataTable)dgvdocuments.DataSource;
                                DataRow drToAdd = dtimages.NewRow();
                                drToAdd["DocumentFile"] = Path.GetFileName(ofdDocuments.FileName);
                                drToAdd["DocumentName"] = txtDocumentName.Text;
                                drToAdd["ImageBytes"] = logo;
                                //drToAdd["ID"] = 0;
                                dtimages.Rows.Add(drToAdd);
                                dtimages.AcceptChanges();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا الموظف", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
            }
            else
            {
                return;
            }
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
            frmShowEmployeeImage ei = new frmShowEmployeeImage();
            ei.Show();
        }

        #region AddEmployee
        private void AddEmployee()
        {
            try
            {
                if (txtEmployeeName.Text == "")
                {
                    Interaction.MsgBox("من فضلك أدخل إسم الموظف");
                    return;

                }
                if (txtNID.Text == "")
                {
                    Interaction.MsgBox("من فضلك أدخل رقم الهوية");
                    return;

                }
                if (dtpExpireNID.Text == " ")
                {
                    Interaction.MsgBox("من فضلك أدخل تاريخ انتهاء رقم الهوية");
                    return;
                }
                int newID;
                SQLConn.sqL = @"INSERT INTO Employees(Name,NID,NIDExpireDate,Mobile,JobID,BaseSalary,
                    Housing,Transportation,TotalSalary)
                    VALUES(@Name,@NID,@NIDExpireDate,@Mobile,@JobID,@BaseSalary,
                    @Housing,@Transportation,@TotalSalary);SELECT CAST(scope_identity() AS int)";
                SQLConn.ConnDB();
                //Create Transaction 
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtEmployeeName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@NID", txtNID.Text);
                SQLConn.cmd.Parameters.Add("@NIDExpireDate", SqlDbType.DateTime).Value = dtpExpireNID.Value;
                SQLConn.cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = txtMobileNo.Text == "" ? string.Empty : txtMobileNo.Text;
                SQLConn.cmd.Parameters.Add("@JobID", SqlDbType.Int).Value = int.Parse(cmbJobID.SelectedValue.ToString());
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@BaseSalary", txtBaseSalary.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Housing", txtHousing.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Transportation", txtTransportation.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@TotalSalary", lblTotalSalary.Text));

                newID = (int)SQLConn.cmd.ExecuteScalar();


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
                Interaction.MsgBox("تم حفظ بيانات الموظف بنجاح.", MsgBoxStyle.Information, "اضافة موظف");

                Clear();
                GridFill();
            }
            catch (Exception ex)
            {
                SQLConn.trans.Rollback();
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void InsertDocuments(int EmployeeID, string DocumentName, string DocumentFile, string Notes, byte[] ImageBytes, SqlTransaction transaction)
        {

            try
            {

                SQLConn.sqL = "INSERT INTO EmployeeDocuments(DocumentName,Notes,DocumentFile,ImageBytes,EmployeeID) VALUES(@DocumentName,@Notes,@DocumentFile,@ImageBytes,@EmployeeID)";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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
        //Insert Null Value
        private SqlParameter SetDBNullIfEmpty(string Parmname, string Parmvalue)
        {

            return new SqlParameter(Parmname, String.IsNullOrEmpty(Parmvalue) ? DBNull.Value : (object)Parmvalue);
        }
        #endregion
        #region GridFill
        public void GridFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = EmployeeGridFill();
                dgvEmployee.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        public DataTable EmployeeGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {

                SQLConn.sqL = @"SELECT dbo.Jobs.JobName,dbo.Employees.ID, dbo.Employees.TotalSalary, dbo.Employees.Transportation, dbo.Employees.Housing, dbo.Employees.BaseSalary,
                             dbo.Employees.JobID, dbo.Employees.Mobile, dbo.Employees.NIDExpireDate, dbo.Employees.NID, 
                             dbo.Employees.Name FROM dbo.Employees LEFT OUTER JOIN
                             dbo.Jobs ON dbo.Employees.JobID = dbo.Jobs.ID";
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
        #region UpdateEmployee
        private void UpdateEmployee()
        {
            try
            {
                SQLConn.sqL = @"Update Employees Set Name = @Name,NID = @NID,NIDExpireDate = @NIDExpireDate,Mobile = @Mobile,JobID = @JobID,BaseSalary = @BaseSalary,
                    Housing = @Housing,Transportation = @Transportation,TotalSalary = @TotalSalary where ID = @ID ";
                SQLConn.ConnDB();
                //Create Transaction 
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtEmployeeName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@NID", txtNID.Text);
                SQLConn.cmd.Parameters.Add("@NIDExpireDate", SqlDbType.DateTime).Value = dtpExpireNID.Value;
                SQLConn.cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = txtMobileNo.Text == "" ? string.Empty : txtMobileNo.Text;
                SQLConn.cmd.Parameters.Add("@JobID", SqlDbType.Int).Value = int.Parse(cmbJobID.SelectedValue.ToString()); // 1; 
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@BaseSalary", txtBaseSalary.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Housing", txtHousing.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@Transportation", txtTransportation.Text));
                SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@TotalSalary", lblTotalSalary.Text));

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
                        InsertDocuments(SelectedEmployeeID, DocumentName, DocumentFile, Notes, ImageBytes, SQLConn.trans);
                    }
                }
                SQLConn.trans.Commit();
                Interaction.MsgBox("تم تحديث  بيانات الموظف.", MsgBoxStyle.Information, "تحديث موظف");

                Clear();
                GridFill();
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
        private void DeleteDocumentsTable(SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = "Delete From EmployeeDocuments WHERE EmployeeID = " + SelectedEmployeeID + "";
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
        #region DeleteEmployee
        private void DeleteFunction()
        {

            try
            {
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();
                SQLConn.sqL = "Delete From Employees WHERE ID = " + SelectedEmployeeID + "";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.ExecuteNonQuery();
                DeleteDocumentsTable(SQLConn.trans);
                SQLConn.trans.Commit();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف  بيانات الموظف");

                Clear();

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
        public void JobsFill()
        {

            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,JobName FROM Jobs");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["JobName"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbJobID.DataSource = dtbl;
                cmbJobID.ValueMember = "ID";
                cmbJobID.DisplayMember = "JobName";
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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmemployees_Load(object sender, EventArgs e)
        {
            dtpExpireNID.Format = DateTimePickerFormat.Custom;
            dtpExpireNID.CustomFormat = " ";
            JobsFill();
            GridFill();
        }
        #region FillControls
        private void dgvEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                if (e.RowIndex != -1)
                {
                    SelectedEmployeeID = Convert.ToInt32(dgvEmployee.CurrentRow.Cells["dgvEmployeeID"].Value);
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

                DataTable EmployeeInfo = EmployeeView(SelectedEmployeeID);
                txtEmployeeName.Text = EmployeeInfo.Rows[0]["Name"].ToString();
                txtNID.Text = EmployeeInfo.Rows[0]["NID"].ToString();
                dtpExpireNID.Text = EmployeeInfo.Rows[0]["NIDExpireDate"].ToString();
                cmbJobID.SelectedValue = EmployeeInfo.Rows[0]["JobID"].ToString();
                txtMobileNo.Text = EmployeeInfo.Rows[0]["Mobile"].ToString();
                txtBaseSalary.Text = EmployeeInfo.Rows[0]["BaseSalary"].ToString();
                txtHousing.Text = EmployeeInfo.Rows[0]["Housing"].ToString();
                txtTransportation.Text = EmployeeInfo.Rows[0]["Transportation"].ToString();
                lblTotalSalary.Text = EmployeeInfo.Rows[0]["TotalSalary"].ToString();
                //Fill Documents Table
                if (int.Parse(cmbJobID.SelectedValue.ToString()) == 2)
                {
                    linkLabel1.Visible = true;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    linkLabel1.Visible = false;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;
                }
                DocumentsGridFill();

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        public DataTable EmployeeView(int EmployeeID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select ID,Name,NID,NIDExpireDate,Mobile,JobID,BaseSalary,Housing,Transportation,TotalSalary From Employees where ID = @Id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", EmployeeID);
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
                dtbl = GetDocumentsTable(SelectedEmployeeID);
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
        public DataTable GetDocumentsTable(int EmployeeID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select ID,DocumentName,Notes,ImageBytes,DocumentFile from EmployeeDocuments Where EmployeeID = " + EmployeeID + "";
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

        private void txtBaseSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            decimal Total = 0.0m;
            var BaseSalary = txtBaseSalary.Text == "" ? 0.0m : decimal.Parse(txtBaseSalary.Text);
            var Housing = txtHousing.Text == "" ? 0.0m : decimal.Parse(txtHousing.Text);
            var Transportation = txtTransportation.Text == "" ? 0.0m : decimal.Parse(txtTransportation.Text);
            Total = BaseSalary + Housing + Transportation;
            lblTotalSalary.Text = Total.ToString();

        }

        private void cmbJobID_SelectedIndexChanged(object sender, EventArgs e)
        {

            var SelectedValue = ((DataRowView)cmbJobID.SelectedItem).Row[0].ToString();

            if (int.Parse(SelectedValue) == 2)
            {

                linkLabel1.Visible = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                linkLabel1.Visible = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }


        private void Clear()
        {
            btnSave.Text = "حفظ";
            txtEmployeeName.Text = "";
            txtNID.Text = "";
            dtpExpireNID.Value = DateTime.Now;
            txtMobileNo.Text = "";
            cmbJobID.SelectedIndex = 0;
            txtBaseSalary.Text = "";
            txtTransportation.Text = "";
            txtHousing.Text = "";
            lblTotalSalary.Text = "0.0";
            dtpExpireNID.Format = DateTimePickerFormat.Custom;
            dtpExpireNID.CustomFormat = " ";

            if (dtimages != null)
                dtimages.Clear();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "الموظفين", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void dtpExpireNID_ValueChanged(object sender, EventArgs e)
        {
            dtpExpireNID.Format = DateTimePickerFormat.Long;


        }

        private void btnEditDocument_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
