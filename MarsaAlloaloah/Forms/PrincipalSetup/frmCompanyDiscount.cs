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


    public partial class frmCompanyDiscount : Form
    {
        int SelectedConpanyDiscountID;
        public frmCompanyDiscount()
        {

            InitializeComponent();

        }
      

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text.Trim() == string.Empty)
            {
                Interaction.MsgBox("الرجاء إدخال إسم الشركة.", MsgBoxStyle.Information, "العملاء");
                return;
            }

            if (btnSave.Text == "حفظ")
            {
                if (CheckIfCompaneyNameDublicate(txtCompanyName.Text))
                {
                    Interaction.MsgBox("لايمكن تكرار إسم الشركة");
                    return;
                }
             

                AddFunction();
                ClearFunction();
            }
            else
            {

                if (CheckIfCompaneyNameDublicateForUpdate(txtCompanyName.Text))
                {
                    Interaction.MsgBox("لايمكن تكرار إسم الشركة");
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
                decimal discount = 0;
                Decimal.TryParse(txtValue.Text, out discount);

                SQLConn.sqL = "UPDATE CompanyDiscount SET CompanyName = @CompanyName , DiscountValue = @DiscountValue ,StartDate = @StartDate,EndDate = @EndDate,IsActive = @IsActive, Admin = @Admin,Cashier = @Cashier, Comptable = @Comptable, EntringData = @EntringData where ID = @ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);             
                SQLConn.cmd.Parameters.Add("@DiscountValue", SqlDbType.Decimal).Value = discount;
                SQLConn.cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dtbStartDate.Value;
                SQLConn.cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dtbEndDate.Value;
                SQLConn.cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = ckbIsActive.Checked;
                SQLConn.cmd.Parameters.Add("@Admin", SqlDbType.Bit).Value = Admin.Checked;
                SQLConn.cmd.Parameters.Add("@Cashier", SqlDbType.Bit).Value = Cashier.Checked;
                SQLConn.cmd.Parameters.Add("@Comptable", SqlDbType.Bit).Value = Comptable.Checked;
                SQLConn.cmd.Parameters.Add("@EntringData", SqlDbType.Bit).Value = EntringData.Checked;
                SQLConn.cmd.Parameters.AddWithValue("@ID", SelectedConpanyDiscountID);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات خصم الشركات");
                Gridfill();
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
                decimal discount = 0;
                Decimal.TryParse(txtValue.Text, out discount);

                SQLConn.sqL = "INSERT INTO CompanyDiscount(CompanyName,DiscountValue,StartDate,EndDate,IsActive,Admin,Cashier,Comptable,EntringData) VALUES(@CompanyName,@DiscountValue,@StartDate,@EndDate,@IsActive,@Admin,@Cashier,@Comptable,@EntringData)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                SQLConn.cmd.Parameters.Add("@DiscountValue", SqlDbType.Decimal).Value = discount;
                SQLConn.cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dtbStartDate.Value;
                SQLConn.cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dtbEndDate.Value;
                SQLConn.cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = ckbIsActive.Checked;
                SQLConn.cmd.Parameters.Add("@Admin", SqlDbType.Bit).Value = Admin.Checked;
                SQLConn.cmd.Parameters.Add("@Cashier", SqlDbType.Bit).Value = Cashier.Checked;
                SQLConn.cmd.Parameters.Add("@Comptable", SqlDbType.Bit).Value = Comptable.Checked;
                SQLConn.cmd.Parameters.Add("@EntringData", SqlDbType.Bit).Value = EntringData.Checked;

                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حفظ بيانات خصم الشركات.", MsgBoxStyle.Information, "اضافة خصم الشركات");
                Gridfill();
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

        private void Gridfill()
        {

            try
            {
                DataTable dtbl = new DataTable();
                //RoleSP spRole = new RoleSP();
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

                SQLConn.sqL = "select * from CompanyDiscount";
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
                    SelectedConpanyDiscountID = Convert.ToInt32(dgvCusomers.CurrentRow.Cells["dgvCompanyDiscountID"].Value);
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
                DataTable CompanyDiscountInfo = CustomerView(SelectedConpanyDiscountID);
                txtCompanyName.Text = CompanyDiscountInfo.Rows[0]["CompanyName"].ToString();
                txtValue.Text = CompanyDiscountInfo.Rows[0]["DiscountValue"].ToString();
                dtbStartDate.Text = CompanyDiscountInfo.Rows[0]["StartDate"].ToString();
                dtbEndDate.Text = CompanyDiscountInfo.Rows[0]["EndDate"].ToString();
                ckbIsActive.Checked = (bool)CompanyDiscountInfo.Rows[0]["IsActive"];
                var CDA = CompanyDiscountInfo.Rows[0]["Admin"].ToString();
                var CDC = CompanyDiscountInfo.Rows[0]["Cashier"].ToString();
                var CDT = CompanyDiscountInfo.Rows[0]["Comptable"].ToString();
                var CDD = CompanyDiscountInfo.Rows[0]["EntringData"].ToString();
                if (!string.IsNullOrEmpty(CDA) &&
                    !string.IsNullOrEmpty(CDC) &&
                    !string.IsNullOrEmpty(CDT) &&
                    !string.IsNullOrEmpty(CDD) )
                {
                    Admin.Checked = (bool)CompanyDiscountInfo.Rows[0]["Admin"];
                    Cashier.Checked = (bool)CompanyDiscountInfo.Rows[0]["Cashier"];
                    Comptable.Checked = (bool)CompanyDiscountInfo.Rows[0]["Comptable"];
                    EntringData.Checked = (bool)CompanyDiscountInfo.Rows[0]["EntringData"];
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable CustomerView(int CompanyDiscountID)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select * from CompanyDiscount where ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", CompanyDiscountID);
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
                txtCompanyName.Clear();
                txtValue.Clear();
                dtbEndDate.Value = DateTime.Now;
                dtbStartDate.Value = DateTime.Now;
                ckbIsActive.Checked = false;
                btnSave.Text = "حفظ";
                btnDelete.Enabled = false;
                Admin.Checked = false;
                Cashier.Checked = false;
                Comptable.Checked = false;
                EntringData.Checked = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void frmCompanyDiscount_Load(object sender, EventArgs e)
        {
            try
            {
                Gridfill();
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
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا الخصم", "رسالة تأكيد", MessageBoxButtons.YesNo);
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
                SQLConn.sqL = "Delete From CompanyDiscount WHERE ID = " + SelectedConpanyDiscountID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف خصم شركة");
                Gridfill();
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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "خصم الشركات", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        
        public bool CheckIfCompaneyNameDublicate(string Name)
        {

            bool IsNameDublicated = false;
            try
            {

                SQLConn.sqL = @"select Count(CompanyName) from CompanyDiscount where CompanyName = @Name";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Name", Name);
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
        public bool CheckIfCompaneyNameDublicateForUpdate(string Name)
        {

            bool IsNameDublicated = false;
            try
            {

                SQLConn.sqL = @"select Count(CompanyName) from CompanyDiscount where CompanyName = @Name and ID != " + SelectedConpanyDiscountID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Name", Name);
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


    

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ckbIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
