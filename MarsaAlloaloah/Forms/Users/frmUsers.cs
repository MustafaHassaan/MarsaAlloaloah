using MarsaAlloaloah.Forms;
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
    public partial class frmUsers : Form
    {
        public int SelectedUserID;

        public frmUsers()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "المستخدمين", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            GridFill();
            FillRoles();
            FillUsers();
        }
        public void FillRoles()
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM Role");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbRoleID.DataSource = dtbl;
                cmbRoleID.ValueMember = "ID";
                cmbRoleID.DisplayMember = "Name";

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
        public void FillUsers()
        {
            try
            {

                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable("SELECT ID,Name FROM Employees");
                DataRow dr = dtbl.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "--اختر--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbEmployeeID.DataSource = dtbl;
                cmbEmployeeID.ValueMember = "ID";
                cmbEmployeeID.DisplayMember = "Name";

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
        private void Validation()
        {
            if (txtUserName.Text == "")
            {
                Interaction.MsgBox("من فضلك أدخل اسم المستخدم ");
                return;
            }
            if (txtPassword.Text == "")
            {
                Interaction.MsgBox("من فضلك أدخل كلمة المرور ");
                return;
            }
            if ((int)cmbRoleID.SelectedValue == 0)
            {
                Interaction.MsgBox("من فضلك إختر الصلاحية ");
                return;
            }
            if (cmbEmployeeID.SelectedItem != null && cmbEmployeeID.SelectedIndex != -1)
            {
                var SelectedEmployeeValue = ((DataRowView)cmbEmployeeID.SelectedItem).Row[0].ToString();
                if (int.Parse(SelectedEmployeeValue) == 0)
                {
                    Interaction.MsgBox("من فضلك إختر الموظف ");
                    return;
                }
            }
            else
            {
                Interaction.MsgBox("من فضلك إختر الموظف ");
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validation 
            Validation();
            //Validate Password 
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                Interaction.MsgBox("كلمة المرور غير متطابقة ");
                return;
            }

            if (btnSave.Text == "حفظ")
            {
                //Check If Employee has User
                if (CheckIfEmployeeHasUser(int.Parse(cmbEmployeeID.SelectedValue.ToString())))
                {
                    Interaction.MsgBox("تم إضافة مستخدم لهذا الموظف من قبل ");
                    return;
                }
                // Check If UserDublicate
                if (CheckIfUserNameDublicate(txtUserName.Text))
                {
                    Interaction.MsgBox("لايمكن تكرار إسم المستخدم");
                    return;
                }
                AddUsers();
                GridFill();
            }
            else
            {
                //Check If Employee has User
                //if (CheckIfEmployeeHasUser(int.Parse(cmbEmployeeID.SelectedValue.ToString())))
                //{
                //    Interaction.MsgBox("تم إضافة مستخدم لهذا الموظف من قبل ");
                //    return;
                //}
                // Check If UserDublicate
                if (CheckIfUserNameDublicateForUpdate(txtUserName.Text))
                {
                    Interaction.MsgBox("لايمكن تكرار إسم المستخدم");
                    return;
                }

                UpdateUsers();

                GridFill();
            }
        }

        private void AddUsers()
        {
            try
            {
                int newID;
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();
                SQLConn.sqL = "INSERT INTO Users(UserName,Password,RoleID,EmployeeID,Discountpercent) VALUES(@UserName,@Password,@RoleID,@EmployeeID,@Discountpercent);SELECT CAST(scope_identity() AS int)";

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                SQLConn.cmd.Parameters.AddWithValue("@RoleID", cmbRoleID.SelectedValue ?? DBNull.Value);
                SQLConn.cmd.Parameters.AddWithValue("@EmployeeID", cmbEmployeeID.SelectedValue ?? DBNull.Value);
                if (!string.IsNullOrEmpty(Discounttext.Text))
                {
                    SQLConn.cmd.Parameters.AddWithValue("@Discountpercent", Convert.ToDecimal(Discounttext.Text));
                }
                else
                {
                    SQLConn.cmd.Parameters.AddWithValue("@Discountpercent", DBNull.Value);
                }
                newID = (int)SQLConn.cmd.ExecuteScalar();
                var SelectedValue = ((DataRowView)cmbRoleID.SelectedItem).Row[0].ToString();
                int val = Int32.Parse(SelectedValue);
                //if ((val == (int)SQLConn.Role.AdminSys) || (val == (int)SQLConn.Role.Cashier))
                //{
                //    AddTreasury(newID, SQLConn.trans, txtTreasuryName.Text);
                //}
                AddTreasury(newID, SQLConn.trans, txtUserName.Text);
                SQLConn.trans.Commit();
                Interaction.MsgBox("تم حفظ بيانات المستخدم.", MsgBoxStyle.Information, "اضافة مستخدم");
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
        private void UpdateUsers()
        {
            try
            {
                SQLConn.sqL = "Update Users Set UserName = @UserName,Password =@Password,RoleID = @RoleID,EmployeeID = @EmployeeID, Discountpercent=@Discountpercent Where ID=@id";
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                SQLConn.cmd.Parameters.AddWithValue("@RoleID", cmbRoleID.SelectedValue ?? DBNull.Value);
                SQLConn.cmd.Parameters.AddWithValue("@EmployeeID", cmbEmployeeID.SelectedValue ?? DBNull.Value);
                if (!string.IsNullOrEmpty(Discounttext.Text))
                {
                    SQLConn.cmd.Parameters.AddWithValue("@Discountpercent", Convert.ToDecimal(Discounttext.Text));
                }
                else
                {
                    SQLConn.cmd.Parameters.AddWithValue("@Discountpercent", DBNull.Value);
                }
                SQLConn.cmd.Parameters.AddWithValue("@id", SelectedUserID);
                
                SQLConn.cmd.ExecuteNonQuery();

                //check if this user is cashier and has a treasury
                var SelectedValue = ((DataRowView)cmbRoleID.SelectedItem).Row[0].ToString();
                int val = Int32.Parse(SelectedValue);
                if ((val == (int)SQLConn.Role.AdminSys) || (val == (int)SQLConn.Role.Cashier))
                {
                    //Check
                    if (!CheckIfUserHasTreasury(SelectedUserID, SQLConn.trans))
                        AddTreasury(SelectedUserID, SQLConn.trans, txtTreasuryName.Text);
                }

                SQLConn.trans.Commit();
                Interaction.MsgBox("تم حفظ بيانات المستخدم.", MsgBoxStyle.Information, "اضافة مستخدم");
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

        public bool CheckIfUserHasTreasury(int userID, SqlTransaction transaction)
        {
            bool IsUserHasTreasury = false;
            try
            {
                SQLConn.sqL = @"select Count(ID) from Treasury where UserID = @userID";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@userID", userID);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    IsUserHasTreasury = true;
                }
                else
                {
                    IsUserHasTreasury = false;
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
            return IsUserHasTreasury;
        }

        public void GridFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = UsersGridFill();
                dgvUsers.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }
        public DataTable UsersGridFill()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                SQLConn.sqL = @"SELECT     Users.ID, Users.UserName, Users.RoleID, Role.Name AS RoleName, Employees.Name AS EmployeeName, Users.EmployeeID,Users.Discountpercent
                      FROM         Users Left Outer JOIN
                      Employees ON Users.EmployeeID = Employees.ID INNER JOIN
                      Role ON Users.RoleID = Role.ID";
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

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    SelectedUserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["gvID"].Value);
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
                DataTable UserInfo = UserView(SelectedUserID);
                if (UserInfo.Rows.Count > 0)
                {
                    txtUserName.Text = UserInfo.Rows[0]["UserName"].ToString();
                    txtPassword.Text = UserInfo.Rows[0]["Password"].ToString();
                    txtConfirmPassword.Text = UserInfo.Rows[0]["Password"].ToString();
                    cmbEmployeeID.SelectedValue = UserInfo.Rows[0]["EmployeeID"].ToString();
                    cmbRoleID.SelectedValue = UserInfo.Rows[0]["RoleID"].ToString();
                    Discounttext.Text = UserInfo.Rows[0]["Discountpercent"].ToString();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable UserView(int UserID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = @"SELECT Users.ID, Users.UserName, Users.RoleID, Users.Password, Role.Name AS RoleName, Employees.Name AS EmployeeName, Users.EmployeeID,Users.Discountpercent
                        FROM   Users LEFT OUTER JOIN
                      Employees ON Users.EmployeeID = Employees.ID LEFT OUTER JOIN
                      Role ON Users.RoleID = Role.ID Where dbo.Users.ID = @id";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@id", UserID);
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
        public bool CheckIfEmployeeHasUser(int EmployeeID)
        {
            bool IsEmployeeHasUser = false;
            try
            {

                SQLConn.sqL = @"select Count(EmployeeID) from Users where EmployeeID = @EmployeeID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    IsEmployeeHasUser = true;
                }
                else
                {
                    IsEmployeeHasUser = false;
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
            return IsEmployeeHasUser;
        }
        public bool CheckIfUserNameDublicate(string UserName)
        {
            bool IsUserDublicated = false;
            try
            {
                SQLConn.sqL = @"select Count(UserName) from Users where UserName = @UserName";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@UserName", UserName);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    IsUserDublicated = true;
                }
                else
                {
                    IsUserDublicated = false;
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
            return IsUserDublicated;


        }
        public bool CheckIfUserNameDublicateForUpdate(string UserName)
        {

            bool IsUserDublicated = false;
            try
            {

                SQLConn.sqL = @"select Count(UserName) from Users where UserName = @UserName and ID != " + SelectedUserID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@UserName", UserName);
                int Count = (int)SQLConn.cmd.ExecuteScalar();
                if (Count > 0)
                {
                    IsUserDublicated = true;
                }
                else
                {
                    IsUserDublicated = false;

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
            return IsUserDublicated;

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا المستخدم", "رسالة تأكيد", MessageBoxButtons.YesNo);
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
                SQLConn.sqL = "Delete From Users WHERE ID = " + SelectedUserID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف مستخدم");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            btnSave.Text = "حفظ";
            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            cmbEmployeeID.SelectedValue = 0;
            cmbRoleID.SelectedValue = 0;

        }
        private void AddTreasury(int userID, SqlTransaction transaction, string treasuryName)
        {
            try
            {
                SQLConn.sqL = "INSERT INTO Treasury(Name,UserID, Balance, StartingBalance) VALUES (@Name, @UserID, 0, 0) ";
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@Name", treasuryName);
                SQLConn.cmd.Parameters.AddWithValue("@UserID", userID);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }

        }

        private void cmbRoleID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoleID.SelectedItem != null)
            {
                var SelectedValue = ((DataRowView)cmbRoleID.SelectedItem).Row[0].ToString();
                int val = Int32.Parse(SelectedValue);
                if ((val == (int)SQLConn.Role.AdminSys) || (val == (int)SQLConn.Role.Cashier)) 
                {
                    lblTreasuryName.Visible = true;
                    txtTreasuryName.Visible = true;
                    txtTreasuryName.Text = " خزينة" + txtUserName.Text;
                }
                else
                {
                    //lblTreasuryName.Enabled = false;
                    //txtTreasuryName.Enabled = false;
                }
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (cmbRoleID.SelectedItem != null)
            {
                var SelectedValue = ((DataRowView)cmbRoleID.SelectedItem).Row[0].ToString();
                int val = Int32.Parse(SelectedValue);
                if ((val == (int)SQLConn.Role.AdminSys) || (val == (int)SQLConn.Role.Cashier))
                {
                    lblTreasuryName.Visible = true;
                    txtTreasuryName.Visible = true;
                    txtTreasuryName.Text = "خزينة " + txtUserName.Text;

                }
                else
                {
                    lblTreasuryName.Enabled = false;
                    txtTreasuryName.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                Interaction.MsgBox("من فضلك أدخل اسم المستخدم ");
                return;
            }
            if (txtPassword.Text == "")
            {
                Interaction.MsgBox("من فضلك أدخل كلمة المرور ");
                return;
            }
            if ((int)cmbRoleID.SelectedValue == 0)
            {
                Interaction.MsgBox("من فضلك إختر الصلاحية ");
                return;
            }
            if (cmbEmployeeID.SelectedItem != null && cmbEmployeeID.SelectedIndex != -1)
            {
                var SelectedEmployeeValue = ((DataRowView)cmbEmployeeID.SelectedItem).Row[0].ToString();
                if (int.Parse(SelectedEmployeeValue) == 0)
                {
                    Interaction.MsgBox("من فضلك إختر الموظف ");
                    return;
                }
            }
            else
            {
                Interaction.MsgBox("من فضلك إختر الموظف ");
                return;
            }
            Roles Frmrol = new Roles();
            Roles open = Application.OpenForms["Roles"] as Roles;
            if (open == null)
            {
                Frmrol.MdiParent = this.MdiParent;
                Frmrol.Userid = SelectedUserID;
                Frmrol.Show();
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
        private void Discounttext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && 
                !char.IsDigit(e.KeyChar) &&
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
    }
}
