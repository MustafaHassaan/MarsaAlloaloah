using MarsaAlloaloah.Utility;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SQLConn.sqL = @"SELECT dbo.Users.ID,dbo.Users.UserName, dbo.Role.Name, Role.ID as RoleID
                  FROM dbo.Users LEFT OUTER JOIN  dbo.Role ON dbo.Users.RoleID = dbo.Role.ID WHERE dbo.Users.UserName = @UNAME AND dbo.Users.Password = @UPASS
                  ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@UNAME", txtUserName.Text);
                SQLConn.cmd.Parameters.AddWithValue("@UPASS", txtPassword.Text);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read() == true)
                {    
                    Data.UserID = (Convert.ToInt32(SQLConn.dr["ID"]));
                    Data.UserName = SQLConn.dr["UserName"].ToString();
                    Data.Role = SQLConn.dr["Name"].ToString();
                    Data.RoleID =Int32.Parse( SQLConn.dr["RoleID"].ToString());
                    SQLConn.conn.Close();
                    frmmdi m = new frmmdi();

                    m.Show();
                    m.BringToFront();

                    this.Hide();                
                }
                else
                {
                    //Interaction.MsgBox("Invalid Password. Please try again.",MsgBoxStyle.Exclamation, "Login");
                    MessageBox.Show("يوجد خطا باسم المستخدم او كلمة المرور الرجاء المحاولة مرة اخرى.", "برنامج نقاط البيع", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CancelButton = btnCancel;
            this.AcceptButton = btnLogin;
            SQLConn.getData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
          

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
  
        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
    
        }
    }
}
