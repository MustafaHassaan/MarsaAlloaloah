using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    public partial class frmPrintTicket : Form
    {
        int InvoiceNo;
        public frmPrintTicket(int invoiceNo)
        {
            InitializeComponent();
            InvoiceNo = invoiceNo;
        }
        private void frmPrintTicket_Load(object sender, EventArgs e)
        {//compatible font with printer
            // todo : //compatible font with printer
            EPrint = false;
            dgw.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgw.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgw.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

           // GetCompanyInfo();
            lblTitle.Text = lblTitle.Text;

            LoadReceiptInfo();
            PrintDocument1.Print();         
            lblTitle.Size = new Size(280, 159);
        }
        public bool EPrint;
        private void OnEndPrinting(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            EPrint = true;
        }
        private void PrintDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.Panel1.Width, this.Panel1.Height);
            Panel1.DrawToBitmap(bm, new Rectangle(0, 0, this.Panel1.Width, this.Panel1.Height));
            e.Graphics.DrawImage(bm, 7, 0);
            PageSetupDialog aPS = new PageSetupDialog();
            aPS.Document = PrintDocument1;
        }

        private void lblTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadReceiptInfo()
        {            
            try
            {
                SQLConn.sqL = @"SELECT     Tickets.ID, Tickets.StartDate, Tickets.StartTime, Customers.Name AS CustomerName, Customers.Mobile, 
                      Customers.NID, SeaTransport.Name AS SeaTransportName, Tickets.DurationValue, Tickets.VAT, Tickets.PriceAfterDiscount, 
                      Tickets.PriceAfterVAT, Employees.Name AS CashierName, SeaTransportType.Name AS SeaType, Drivers.Name  AS DriverName
                      FROM         Tickets INNER JOIN
                      Users ON Tickets.UserID = Users.ID INNER JOIN
                      Role ON Users.RoleID = Role.ID INNER JOIN
                      Employees ON Users.EmployeeID = Employees.ID INNER JOIN
                      Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                      SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID LEFT OUTER JOIN
                      Drivers ON Tickets.DriverID = Drivers.ID LEFT OUTER JOIN
                      SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID
                      WHERE     (Role.ID = 2) and dbo.Tickets.ID = " + InvoiceNo + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read() == true)
                {
                    string TicketNo = SQLConn.dr["ID"].ToString();
                    lblInvoice.Text = TicketNo;
                    lblCustMobile.Text = SQLConn.dr["Mobile"].ToString(); 
                    lblCustName.Text = SQLConn.dr["CustomerName"].ToString();
                    lblCustNID.Text = SQLConn.dr["NID"].ToString();
                    lblSubtotal.Text =(SQLConn.dr["PriceAfterDiscount"].ToString());
                    lblVat.Text = SQLConn.dr["VAT"].ToString();
                    lblTotal.Text = SQLConn.dr["PriceAfterVAT"].ToString();
                    lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss");
                    DateTime ticketDate = (DateTime)SQLConn.dr["StartDate"];
                    var time = ticketDate.Add((TimeSpan)SQLConn.dr["StartTime"]);
                    lblTicketDate.Text = (ticketDate).ToString("dd/MM/yyyy");
                    lblTicketStartTime.Text = time.ToString("HH:mm:ss");

                    lblCashierName.Text = SQLConn.dr["CashierName"].ToString();
                    lblSeaBoatType.Text = SQLConn.dr["SeaType"].ToString();
                    lblPeriod.Text = SQLConn.dr["DurationValue"].ToString() + "  دقيقة  ";
                    lblSeaBoatName.Text = SQLConn.dr["SeaTransportName"].ToString();
                    lblDriverName.Text = SQLConn.dr["DriverName"].ToString();
                    //lblTicketData.Text = string.Format("{0}{1}{2}{3}{4}", "رحلة بحرية", "-", SQLConn.dr["SeaTransportName"].ToString(), "المدة", SQLConn.dr["DurationValue"].ToString());
                    //if has addons
                    LoadItemstoDatagrid();
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        //Fill Addons DataGrid 
        private void LoadItemstoDatagrid()
        {
            int y = 0;
            dgw.Rows.Clear();
            try
            {

                SQLConn.sqL = @"SELECT dbo.lnkTicketAddon.AddonID, dbo.lnkTicketAddon.Quantity, dbo.lnkTicketAddon.Price, dbo.lnkTicketAddon.Total, dbo.Addons.Name
                  FROM  dbo.lnkTicketAddon LEFT OUTER JOIN
                  dbo.Addons ON dbo.lnkTicketAddon.AddonID = dbo.Addons.ID Where dbo.lnkTicketAddon.TicketID = "+ InvoiceNo + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.HasRows == true)
                {
                    while (SQLConn.dr.Read())
                    {
                        dgw.Rows.Add(SQLConn.dr["Name"].ToString(), SQLConn.dr["Quantity"].ToString(), SQLConn.dr["Price"].ToString(), SQLConn.dr["Total"].ToString());
                        dgw.Height += 19;
                        y += 19;

                    }

                }
                else
                {
                    Label1.Visible = false;
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label5.Visible = false;
                    dgw.Visible = false;
                }
                //Panel3.Location = new Point(9, 244 + (y - 20));
                //Panel1.Height += y;
                //this.Height += y;
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

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
