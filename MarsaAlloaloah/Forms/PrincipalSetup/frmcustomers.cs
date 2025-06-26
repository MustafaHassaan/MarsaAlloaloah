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


    public partial class frmcustomers : Form
    {
        int SelectedCustomerID;
        public frmcustomers(string name, string mobile, string nid)
        {
            InitializeComponent();

            txtCustomerName.Text = name;
            txtMobileNo.Text = mobile;
            txtNID.Text = nid;

        }
        public frmcustomers()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال إسم العميل.", MsgBoxStyle.Information, "العملاء");
                return;
            }

            if (btnSave.Text == "حفظ")
            {
                if (CheckIfCustomerNameDublicate(txtCustomerName.Text))
                {
                    Interaction.MsgBox("لايمكن تكرار إسم العميل");
                    return;
                }
                if (CheckIfMobileDublicate(txtMobileNo.Text))
                {
                    Interaction.MsgBox("رقم الموبايل مستخدم من قبل");
                    return;
                }
                if (CheckIfNIDDublicate(txtNID.Text))
                {
                    Interaction.MsgBox("رقم الهوية مستخدم من قبل");
                    return;
                }

                AddFunction();
                ClearFunction();
            }
            else
            {

                if (CheckIfCustomerDublicateForUpdate(txtCustomerName.Text))
                {
                    Interaction.MsgBox("لايمكن تكرار إسم العميل");
                    return;
                }
                if (CheckIfMobileDublicateForUpdate(txtMobileNo.Text))
                {
                    Interaction.MsgBox("رقم الموبايل مستخدم من قبل");
                    return;
                }
                if (CheckIfNIDDublicateForUpdate(txtNID.Text))
                {
                    Interaction.MsgBox("رقم الهوية مستخدم من قبل");
                    return;
                }
                UpdateFunction();
                ClearFunction();


            }
        }

        private void UpdateFunction()
        {
            try
            {
                SQLConn.sqL = "UPDATE Customers SET Name=@Name ,Mobile=@Mobile ,NID=@NID,Taxnumber=@Taxnumber,Address=@Address  WHERE ID = '" + SelectedCustomerID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Mobile", txtMobileNo.Text);
                SQLConn.cmd.Parameters.AddWithValue("@NID", txtNID.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Taxnumber", textBox2.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Address", textBox1.Text);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات العميل");
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

        private void AddFunction()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO Customers(Name,Mobile,NID,Address,Taxnumber) VALUES (@Name,@Mobile,@NID,@Address,@Taxnumber) ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Mobile", txtMobileNo.Text);
                SQLConn.cmd.Parameters.AddWithValue("@NID", txtNID.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Address", textBox1.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Taxnumber", textBox2.Text);

                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حفظ بيانات العميل بنجاح.", MsgBoxStyle.Information, "اضافة عميل");
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

        private void GridFill()
        {

            try
            {
                DataTable dtbl = new DataTable();               
                dtbl = CustomersGridFill();
                dgvCusomers.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        public DataTable CustomersGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                SQLConn.sqL = "select * from Customers";
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

        private void dgvCusomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    SelectedCustomerID = Convert.ToInt32(dgvCusomers.CurrentRow.Cells["dgvCustomerID"].Value);
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

        private void FillControls()
        {
            try
            {
                DataTable SeatransportInfo = CustomerView(SelectedCustomerID);
                txtCustomerName.Text = SeatransportInfo.Rows[0]["Name"].ToString();
                txtMobileNo.Text = SeatransportInfo.Rows[0]["Mobile"].ToString();
                txtNID.Text = SeatransportInfo.Rows[0]["NID"].ToString();
                textBox2.Text = SeatransportInfo.Rows[0]["Taxnumber"].ToString();
                textBox1.Text = SeatransportInfo.Rows[0]["Address"].ToString();

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable CustomerView(int CustomerID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select * from Customers where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", CustomerID);
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
        public void ClearFunction()
        {
            try
            {
                textBox1.Clear();
                textBox2.Clear();
                txtCustomerName.Clear();
                txtMobileNo.Clear();
                txtNID.Clear();
                btnSave.Text = "حفظ";
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void frmcustomers_Load(object sender, EventArgs e)
        {
            try
            {
                GridFill();
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFunction();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا العميل", "رسالة تأكيد", MessageBoxButtons.YesNo);
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
                SQLConn.sqL = "Delete From Customers WHERE ID = " + SelectedCustomerID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف عميل");
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "العملاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
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
        public bool CheckIfCustomerDublicateForUpdate(string ClientName)
        {

            bool IsNameDublicated = false;
            try
            {

                SQLConn.sqL = @"select Count(Name) from Customers where Name = @ClientName and ID != " + SelectedCustomerID + "";
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
        public bool CheckIfMobileDublicateForUpdate(string Mobile)
        {

            bool IsMobileDublicated = false;
            try
            {

                SQLConn.sqL = @"select Count(Mobile) from Customers where Mobile = @Mobile and ID != " + SelectedCustomerID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Mobile", @Mobile);
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
        public bool CheckIfNIDDublicateForUpdate(string NID)
        {

            bool IsNIDDublicated = false;
            try
            {

                SQLConn.sqL = @"select Count(NID) from Customers where Mobile = @NID and NID != " + SelectedCustomerID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@NID", @NID);
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

        private void txtSearchByMobile_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchByMobile.Text))
            {
                GridFillByCriteria(txtSearchByMobile.Text, "Mobile");
            }
            else
                GridFill();
        }

        private void txtSearchByNID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchByNID.Text))
            {
                GridFillByCriteria(txtSearchByNID.Text, "NID");
            }
            else
                GridFill();
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchByName.Text))
            {
                GridFillByCriteria(txtSearchByName.Text, "Name");
            }
            else
                GridFill();
        }
       
        private void GridFillByCriteria(string criteriaName, string fieldName)
        {
            try
            {
                string sqlQuery = @"select * from Customers where " + fieldName + " like N'%" + criteriaName + "%' ";
                DataTable dtbl = new DataTable();
                dtbl = GetCustomersListByCriteria(sqlQuery);
                dgvCusomers.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        public DataTable GetCustomersListByCriteria(string sqlQuery)
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                SQLConn.sqL = sqlQuery;
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Documents (*.xls)|*.xlsx",
                FileName = "قائمة العملاء - مرسى كنز أبحر.xlsx"
            };
            //// Insert below
            //Response.ContentEncoding = System.Text.Encoding.Unicode;
            //Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SmartArab.XLSXData.ExportDataGridViewToXLSX(dgvCusomers, sfd.FileName);
                    MessageBox.Show("تم تصدير البيانات بنجاح ", "Info");

                    //SearchTicketsByParametres();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("لا يوجد معلومات للتصدير !!!", "Info");
            }
        }
    }
}
