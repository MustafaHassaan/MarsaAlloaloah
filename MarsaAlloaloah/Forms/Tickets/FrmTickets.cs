using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;
using MarsaAlloaloah.CrystalReports.CQR;
using MarsaAlloaloah.Utility.Ado.net;
using MarsaAlloaloah.Utility;
using System.Drawing;
using MarsaAlloaloah.Forms.Boats;
using MarsaAlloaloah.Forms.Returned;
using MarsaAlloaloah.Forms;
using MarsaAlloaloah.FrmReports;
using MarsaAlloaloah.Rentals;
using static MarsaAlloaloah.dsMarsa;
using System.Windows.Shell;

namespace MarsaAlloaloah
{
    public partial class FrmTickets : Form
    {
        public static int idTicket;
        public static int id;
        public bool Ticketedit { get; set; }
        public bool Ticketdelete { get; set; }
        public FrmTickets()
        {
            InitializeComponent();
        }
        DataTable DisCompanydtbl = new DataTable();
        public void CompanyDiscountFill()
        {
            try
            {
                SQLConn.ConnDB();

                DisCompanydtbl = SQLConn.getTable("SELECT ID,CompanyName,DiscountValue FROM CompanyDiscount ");
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
        public void FillSeaTransportFill(int TypeID)
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@" SELECT ID,Name,TypeID FROM SeaTransport Where TypeID = " + TypeID + " And InService = 1 " +
                    //@"  and ID not IN(
                    //    SELECT      SeaTransport.ID
                    //    FROM         Tickets Inner JOIN
                    //    SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID
                    //    WHERE(Tickets.StartDate = CAST(GETDATE() as DATE)) and(EndTime > CONVERT(TIME, SYSDATETIME()))
                    //    )" +
                    " Order by TypeID, ID, Name ");
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
        private void GetPerid()
        {
            try
            {
                //SQLConn.sqL = @"SELECT * FROM Rolesper
                //                Left Outer Join Users
                //                On Rolesper.Userid = Users.ID
                //                Where Users.UserName = '" + Data.UserName + "'";
                SQLConn.sqL = @"SELECT * FROM Rolesper
                                Where Rolesper.Userid = " + Data.UserID + " ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read() == true)
                {
                    Ticketedit = Convert.ToBoolean(SQLConn.dr["Ticketedit"].ToString());
                    Ticketdelete = Convert.ToBoolean(SQLConn.dr["Ticketdelete"].ToString());
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
        private void FrmTickets_Load(object sender, EventArgs e)
        {
            if ((int)SQLConn.Role.Cashier == Data.RoleID)
            {
                button3.Visible = false;
            }
            // Load all tickets details
            try
            {
                GetPerid();
                Gridfill();
                SeaTransportTypeFill();
                CompanyDiscountFill();
                //Gridcheack();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        //private void Gridcheack()
        //{
        //    foreach (DataGridViewRow row in dataGridView2.Rows)
        //    {
        //        var val = row.Cells[0].Value;
        //        var Qur = "Select * From Returned Where Invoiceid = " + val + " And Type = 'ارتجاع تذكرة'";
        //        SQLConn.ConnDB();
        //        SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
        //        SQLConn.dr = SQLConn.cmd.ExecuteReader();
        //        if (SQLConn.dr.Read())
        //        {
        //            dataGridView1.Rows[row.Index].Cells[22].Value = "مرتجع";
        //        }
        //    }
        //}

        public void Gridfill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                //dtbl = GetAllTickets();
                dtbl = GetTicketsList("");
                dataGridView1.DataSource = dtbl;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.DisplayIndex = col.Index;
                }

                dataGridView2.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        public DataTable GetAllTickets()
        {
            var Date = DateTime.Now.ToShortDateString();
            DataTable dtbl = new DataTable();
            //dtbl.Columns.Add("SlNo", typeof(int));
            //dtbl.Columns["SlNo"].AutoIncrement = true;
            //dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            try
            {
                string sql = @"SELECT    Tickets.ID,   
                        SeaTransportType.Name AS SeaTransportTypeName,                         
                        SeaTransport.Name AS SeaTransportName, 
                        Customers.Name AS CustomerName, 
                        Customers.NID,  Customers.Mobile, 
                        Employees.Name AS CashierName,
                        Tickets.DurationValue , Tickets.StartDate, 
                       Convert(Char(5),Tickets.StartTime, 108) AS StartTimeTicket,
                       Convert(Char(5),Tickets.EndTime, 108) AS EndTimeTicket,
                        Drivers.Name AS DriverName,CompanyDiscount.CompanyName, 
                        CompanyDiscount.DiscountValue, 
                        Tickets.DiscountAmount, Tickets.PriceAfterDiscount,Tickets.VAT,
                        Tickets.PriceAfterVAT,Tickets.Paytamara
                      
                        FROM         Tickets INNER JOIN
                        Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                        SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID INNER JOIN
                        Users ON Tickets.UserID = Users.ID INNER JOIN
                        Employees ON Users.EmployeeID = Employees.ID LEFT OUTER JOIN
                        Drivers ON Tickets.DriverID = Drivers.ID LEFT OUTER JOIN
                        SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID LEFT OUTER JOIN
                        CompanyDiscount ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue
                        WHERE (Users.RoleID = 2)
                        ORDER BY Tickets.ID DESC ";

                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(sql, SQLConn.conn);
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Modifier")
            {
                if (Ticketedit)
                {
                    id = e.RowIndex;
                    idTicket = int.Parse(dataGridView1.Rows[id].Cells["Column1"].Value.ToString());
                    frmEditTicket edit = new frmEditTicket(idTicket);
                    edit.ShowDialog();
                }
                else
                {
                    Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية مدير النظام او محاسب ");
                    return;
                }
                //if (((int)SQLConn.Role.AdminSys != Data.RoleID) && (int)SQLConn.Role.Comptable != Data.RoleID)
                //{
                //    // msg
                //Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية مدير النظام او محاسب ");
                //return;
                //}
                //else
                //{
                //    id = e.RowIndex;
                //    idTicket = int.Parse(dataGridView1.Rows[id].Cells["Column1"].Value.ToString());

                //    frmEditTicket edit = new frmEditTicket(idTicket);

                //    edit.ShowDialog();
                //}
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Suppr")
            {
                if (Ticketdelete)
                {
                    id = e.RowIndex;
                    idTicket = int.Parse(dataGridView1.Rows[id].Cells["Column1"].Value.ToString());
                    MarkAsDeletedTicket();
                }
                else
                {
                    Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية مدير النظام او محاسب ");
                    return;
                }
                //if (((int)SQLConn.Role.AdminSys != Data.RoleID) && (int)SQLConn.Role.Comptable != Data.RoleID)
                //{
                //    // msg
                //Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية مدير النظام او محاسب ");
                //return;
                //}
                //else
                //{
                //    id = e.RowIndex;
                //    idTicket = int.Parse(dataGridView1.Rows[id].Cells["Column1"].Value.ToString());

                //    MarkAsDeletedTicket();
                //}
            }
        }
        private void MarkAsDeletedTicket()
        {
            if ((MessageBox.Show("هل تريد بالتأكيد حذف هذه التذكرة ؟", "قائمة التذاكر", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                int insertedId = InsertIntoTicketsDeleted();
                if (insertedId > 0)
                    DeleteTicket();
            }
        }
        private int InsertIntoTicketsDeleted()
        {
            int insertedId = -1;
            //string sql = @" INSERT INTO TicketsDeleted (SELECT * FROM Tickets where ID =  " + idTicket + " ;) " +
            //              "SELECT CAST(scope_identity() AS int)";


            var Sql = @"Insert Into TicketsDeleted(TicketID,StartDate,StartTime,
                                                   EndTime,SeaTransportTypeID,
                                                   SeaTransportID,DriverID,
                                                   CustomerID,DurationID,
                                                   DurationValue,Price,
                                                   DiscountAmount,
                                                   DiscountPercent,
                                                   PriceAfterDiscount,
                                                   VAT,PriceAfterVAT,
                                                   UserID,PayCash,
                                                   PayCard) SELECT 
                                                   ID,StartDate,StartTime,
                                                   EndTime,SeaTransportTypeID,
                                                   SeaTransportID,DriverID,
                                                   CustomerID,DurationID,
                                                   DurationValue,Price,
                                                   DiscountAmount,
                                                   DiscountPercent,
                                                   PriceAfterDiscount,
                                                   VAT,PriceAfterVAT,
                                                   UserID,PayCash,
                                                   PayCard FROM Tickets where ID =  " + idTicket + " ;" +
                                                   "SELECT CAST(scope_identity() AS int)";
            try
            {
                SQLConn.ConnDB();
                SQLConn.sqL = Sql;
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                insertedId = (int)SQLConn.cmd.ExecuteScalar();
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

            return insertedId;
        }
        private void DeleteTicket()
        {
            //Update ttreasury and bank account
            decimal cash = 0, card = 0;
            DataTable dtblTicket = SQLConn.GetCardAndCashTicketByID(idTicket);
            if (dtblTicket.Rows.Count > 0)
            {
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();

                int userId = -1;
                if (Int32.TryParse(dtblTicket.Rows[0]["UserID"].ToString(), out userId))
                {

                }
                if (Decimal.TryParse(dtblTicket.Rows[0]["PayCash"].ToString(), out cash) && cash > 0 && userId > 0)
                {
                    //Delete this amount from treasury
                    SQLConn.GetTreasuryIDForCurrentUser(userId);

                    //update TreasuryTransactions
                    if (Data.UserTreasuryID > 0)
                    {
                        SQLConn.UpdateUserTreasuryTicketTransactions(Data.UserTreasuryID, -cash, SQLConn.trans, idTicket, "حذف تذكرة ");

                        SQLConn.UpdateUserTreasury(Data.UserTreasuryID, -cash, SQLConn.trans);
                    }
                }
                if (Decimal.TryParse(dtblTicket.Rows[0]["PayCard"].ToString(), out card))
                {
                    // Delete this amount from bank
                    int bankId = SQLConn.GetBankAccountID();

                    if (bankId > 0)
                    {
                        SQLConn.UpdateBankAccountTicketTransactions(bankId, -card, idTicket, "حذف تذكرة ", SQLConn.trans);
                        SQLConn.UpdateBankAccountByID(bankId, -card, SQLConn.trans);
                    }
                }

                SQLConn.trans.Commit();
            }

            DeleteFromTableTickets();
        }
        private void DeleteFromTableTickets()
        {
            string sql = @"Delete from tickets where ID=" + idTicket;

            try
            {
                SQLConn.ConnDB();
                SQLConn.sqL = sql;
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "قائمة التذاكر");

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
        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Duration = "0";

            var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();

            if (int.Parse(SelectedValue) > 0)
            {
                FillSeaTransportFill(int.Parse(SelectedValue));
            }
        }
        public DataTable GetTicketsList(string query)
        {
            DataTable dtbl = new DataTable();
            //dtbl.Columns.Add("SlNo", typeof(int));
            //dtbl.Columns["SlNo"].AutoIncrement = true;
            //dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            try
            {
                //string sql = @"SELECT  Tickets.ID,   
                //        SeaTransportType.Name AS SeaTransportTypeName,                         
                //        SeaTransport.Name AS SeaTransportName, 
                //        Customers.Name AS CustomerName, 
                //        Customers.NID,  Customers.Mobile, 
                //        Employees.Name AS CashierName,
                //        Tickets.DurationValue , Tickets.StartDate, 
                //        CAST(Tickets.StartTime AS time(0)) AS StartTimeTicket,
                //        CAST(Tickets.EndTime AS time(0)) AS EndTimeTicket, 
                //        Drivers.Name AS DriverName,CompanyDiscount.CompanyName, 
                //        CompanyDiscount.DiscountValue,
                //        Tickets.DiscountAmount,
                //        Tickets.PriceAfterDiscount,
                //        Tickets.PayCash,Tickets.PayCard,
                //        Tickets.VAT,
                //        Tickets.PriceAfterVAT

                //        FROM         Tickets INNER JOIN
                //      Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                //      SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID INNER JOIN
                //      Users ON Tickets.UserID = Users.ID INNER JOIN
                //      Employees ON Users.EmployeeID = Employees.ID LEFT OUTER JOIN
                //      Drivers ON Tickets.DriverID = Drivers.ID LEFT OUTER JOIN
                //      SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID LEFT OUTER JOIN
                //      CompanyDiscount ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue

                //      where " + query + " (Tickets.StartDate >= @timedeb and Tickets.StartDate < @timeend) ";

                var DTT = DateTime.Now.ToString("yyyy-MM-dd");
                var sql = @"SELECT  
                            Tickets.ID,   
                            SeaTransportType.Name AS SeaTransportTypeName,                         
                            SeaTransport.Name AS SeaTransportName, 
                            Customers.Name AS CustomerName, 
                            Customers.NID,  
                            Customers.Mobile, 
                            Users.UserName AS CashierName,
                            Tickets.DurationValue, 
                            Tickets.StartDate, 
                            CAST(Tickets.StartTime AS time(0)) AS StartTimeTicket,
                            CAST(Tickets.EndTime AS time(0)) AS EndTimeTicket, 
                            Drivers.Name AS DriverName,
                            CompanyDiscount.CompanyName, 
                            CompanyDiscount.DiscountValue,
                            Tickets.DiscountAmount,
                            CAST(Round(Tickets.PriceAfterVAT / 1.15,2)As numeric(36,2)) As PriceAfterDiscount,
                            Tickets.PayCash,Tickets.PayCard,Tickets.Paytamara,Tickets.Paytransfer,
                            Tickets.VAT,
                            Tickets.PriceAfterVAT,
                            Tickets.Note
                            FROM Tickets 
                            LEFT OUTER JOIN SeaTransportType 
                            ON Tickets.SeaTransportTypeID = SeaTransportType.ID 
                            LEFT OUTER JOIN SeaTransport 
                            ON Tickets.SeaTransportID = SeaTransport.ID
                            LEFT OUTER JOIN Customers 
                            ON Tickets.CustomerID = Customers.ID 
                            LEFT OUTER JOIN Users
                            ON Tickets.UserID = Users.ID
                            LEFT OUTER JOIN Drivers 
                            ON Tickets.DriverID = Drivers.ID 
                            LEFT OUTER JOIN CompanyDiscount 
                            ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue
                            Left Outer Join Returned
                            On Returned.Invoiceid = Tickets.ID
                            where " + query + " (Tickets.StartDate >= @timedeb and Tickets.StartDate <= @timeend)";
                            //"And Tickets.ID Not In(Select Invoiceid from Returned)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(sql, SQLConn.conn);
                //SQLConn.cmd.Parameters.AddWithValue("@name", cmbCompanyDiscount.Text);
                //SQLConn.cmd.Parameters.AddWithValue("@namtypetranport", cmbTypeID.Text);
                //SQLConn.cmd.Parameters.AddWithValue("@SeaTransportTypeID", cmbSeaTransportID.Text);
                SQLConn.cmd.Parameters.AddWithValue("@timedeb", SqlDbType.DateTime).Value = dtpStart.Value.ToString("yyyy-MM-dd");
                //SQLConn.cmd.Parameters.AddWithValue("@timedeb", SqlDbType.DateTime).Value = dtpStart.Value.ToShortDateString();
                //SQLConn.cmd.Parameters.AddWithValue("@timeend", SqlDbType.DateTime).Value = dtpEnd.Value.AddDays(1).ToShortDateString();
                SQLConn.cmd.Parameters.AddWithValue("@timeend", SqlDbType.DateTime).Value = dtpEnd.Value.ToString("yyyy-MM-dd");
                //SQLConn.cmd.Parameters.AddWithValue("@timeend", SqlDbType.DateTime).Value = dtpEnd.Value.ToShortDateString();
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
        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            SearchTicketsByParametres();
        }
        private void SearchTicketsByParametres()
        {
            DataTable dtbl = new DataTable();
            string query = "";
            if (cmbTypeID.SelectedValue != null && int.Parse(cmbTypeID.SelectedValue.ToString()) > 0)
            {
                query = "  SeaTransportTypeID=" + int.Parse(cmbTypeID.SelectedValue.ToString()) + " and ";

            }
            if (cmbSeaTransportID.SelectedValue != null && int.Parse(cmbSeaTransportID.SelectedValue.ToString()) > 0)
            {
                query += "  SeaTransportID=" + int.Parse(cmbSeaTransportID.SelectedValue.ToString()) + " and ";
            }
            if (cmbCompanyDiscount.SelectedValue != null && cmbCompanyDiscount.SelectedValue.ToString() != "0")
            {
                query += "   CompanyDiscount.CompanyName='" + cmbCompanyDiscount.SelectedValue + "' and ";
            }
            if (CBOut.Checked)
            {
                query += "SeaTransport.OwnerTypeID = 1 and ";
            }
            if (CBLand.Checked)
            {
                query += "SeaTransport.OwnerTypeID = 2 and";
            }
            if (!string.IsNullOrEmpty(Idtxt.Text))
            {
                query += "Tickets.ID like N'%" + Idtxt.Text + "%' And ";
            }
            if (!string.IsNullOrEmpty(STTtxt.Text))
            {
                query += "SeaTransportType.Name like N'%" + STTtxt.Text + "%' And ";
            }
            if (!string.IsNullOrEmpty(STNtxt.Text))
            {
                query += "SeaTransport.Name like N'%" + STNtxt.Text + "%' And ";
            }
            if (!string.IsNullOrEmpty(CNtxt.Text))
            {
                query += "Customers.Name like N'%" + CNtxt.Text + "%' And ";
            }
            if (!string.IsNullOrEmpty(CIdtxt.Text))
            {
                query += "Customers.NID like N'%" + CIdtxt.Text + "%' And ";
            }
            if (!string.IsNullOrEmpty(CPtxt.Text))
            {
                query += " Customers.Mobile like N'%" + CPtxt.Text + "%' And ";
            }
            if (!string.IsNullOrEmpty(ENtxt.Text))
            {
                query += "Users.UserName like N'%" + ENtxt.Text + "%' And ";
            }
            try
            {
                dtbl = GetTicketsList(query);
                dataGridView1.DataSource = dtbl;
                dataGridView2.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void ExportPDF()
        {


            var pdfDoc = new Document(PageSize.A1, 50f, 50f, 0, 0);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF (*.pdf)|*.pdf";
            sfd.FileName = "قائمة التذاكر - مرسى كنز أبحر.pdf";
            bool fileError = false;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                {

                    try
                    {
                        File.Delete(sfd.FileName);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                if (!fileError)
                {
                    try
                    {
                        pdfDoc.Open();

                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {

                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();
                            string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");

                            //Create a base font object making sure to specify IDENTITY-H
                            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL);
                            //f.SetStyle(PdfFontStyle.BOLD);
                            iTextSharp.text.Font f1 = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.BOLD);
                            f1.Size = 15;

                            Color c = Color.DarkRed;
                            f.Size = 15;
                            iTextSharp.text.pdf.PdfPTable tb = new iTextSharp.text.pdf.PdfPTable(16);
                            tb.WidthPercentage = 100;
                            tb.PaddingTop = 1;
                            tb.SpacingAfter = 0;
                            tb.SpacingBefore = 30;


                            float[] widths = { 0.5f, 0.7f, 0.5f, 0.7f, 0.9f, 0.7f, 0.7f, 0.9f, 0.9f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f };
                            tb.SetWidths(widths);// largeur par cellule


                            iTextSharp.text.Image Jpg = iTextSharp.text.Image.GetInstance("logoK.png");
                            Jpg.Alignment = Element.ALIGN_CENTER;
                            Jpg.SpacingAfter = 1f;
                            Jpg.SpacingBefore = 10f;
                            Jpg.WidthPercentage = 80;
                            Jpg.ScaleAbsolute(159f, 178f);
                            pdfDoc.Add(Jpg);
                            //Create a specific font object

                            iTextSharp.text.pdf.PdfPCell celprix = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " السعر بعد الخصم :  ", f1));

                            celprix.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celprix);

                            iTextSharp.text.pdf.PdfPCell celdiscontamount = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  قيمة الخصم:  ", f1));

                            celdiscontamount.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celdiscontamount);

                            iTextSharp.text.pdf.PdfPCell celDiscountValu = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  نسبة الخصم(%):  ", f1));
                            celDiscountValu.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celDiscountValu);

                            iTextSharp.text.pdf.PdfPCell celdiscount = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  نوع الخصم:  ", f1));
                            celdiscount.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celdiscount);

                            iTextSharp.text.pdf.PdfPCell cell8 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "    السائق:  ", f1));
                            cell8.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell8);

                            iTextSharp.text.pdf.PdfPCell celtimeend = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  وقت العودة:  ", f1));
                            celtimeend.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celtimeend);

                            iTextSharp.text.pdf.PdfPCell celtimedeb = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  وقت الانطلاق:  ", f1));
                            celtimedeb.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celtimedeb);

                            iTextSharp.text.pdf.PdfPCell celdatdeb = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "   ميعاد بداية الرحلة:  ", f1));
                            celdatdeb.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celdatdeb);

                            iTextSharp.text.pdf.PdfPCell cell6 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  المدة الزمنية:  ", f1));
                            cell6.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell6);

                            // CashierName
                            iTextSharp.text.pdf.PdfPCell cellCashierName = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  الكاشير:  ", f1));
                            cellCashierName.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cellCashierName);

                            iTextSharp.text.pdf.PdfPCell cell3 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " رقم الجوال : ", f1));
                            cell3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell3);

                            iTextSharp.text.pdf.PdfPCell cell2 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "رقم الهوية :", f1));
                            cell2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell2);

                            iTextSharp.text.pdf.PdfPCell cell1 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "إسم العميل:   ", f1));

                            cell1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell1);
                            iTextSharp.text.pdf.PdfPCell cell7 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  الواسطة البحرية:  ", f1));

                            cell7.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell7);

                            iTextSharp.text.pdf.PdfPCell cell5 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  نوع الواسطة البحرية:  ", f1));

                            cell5.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell5);
                            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " رقم الفاتورة:", f1));

                            cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell);
                            foreach (DataGridViewRow Row in dataGridView1.Rows)
                            {
                                if (Row != null && Row.Cells[1].Value != null &&
                                    Row.Cells[2].Value != null && Row.Cells[3].Value != null && Row.Cells[4].Value != null && Row.Cells[5].Value != null && Row.Cells[6].Value != null &&
                                    Row.Cells[7].Value != null && Row.Cells[7].Value != null && Row.Cells[8].Value != null && Row.Cells[9].Value != null && Row.Cells[10].Value != null
                                    && Row.Cells[11].Value != null && Row.Cells[12].Value != null && Row.Cells[13].Value != null && Row.Cells[14].Value != null && Row.Cells[15].Value != null)
                                {
                                    string s = Row.Cells["Column4"].Value.ToString();
                                    iTextSharp.text.pdf.PdfPCell cel = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, s, f));
                                    cel.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel1 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column3"].Value.ToString(), f));
                                    cel1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel2 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["DiscountAmount"].Value.ToString(), f));
                                    cel2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel3 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["DiscountValue"].Value.ToString(), f));
                                    cel3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel4 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["CompanyName"].Value.ToString(), f));
                                    cel4.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel5 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column6"].Value.ToString(), f));
                                    cel5.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel6 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column11"].Value.ToString(), f));
                                    cel6.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                                    iTextSharp.text.pdf.PdfPCell celCashierName = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["CashierName"].Value.ToString(), f));
                                    celCashierName.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                                    iTextSharp.text.pdf.PdfPCell cel7 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column10"].Value.ToString(), f));
                                    cel7.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                                    string[] date_Etablile = Row.Cells["Column7"].Value.ToString().Split(new char[] { ' ' });

                                    iTextSharp.text.pdf.PdfPCell cel8 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, date_Etablile[0], f));
                                    cel8.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel9 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column2"].Value.ToString(), f));
                                    cel9.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel10 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column9"].Value.ToString(), f));
                                    cel10.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel11 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column8"].Value.ToString(), f));
                                    cel11.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel12 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["dgclientname"].Value.ToString(), f));
                                    cel12.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel13 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column5"].Value.ToString(), f));
                                    cel13.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                                    iTextSharp.text.pdf.PdfPCell cel14 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column1"].Value.ToString(), f));
                                    cel14.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                                    tb.AddCell(cel1);
                                    tb.AddCell(cel2);
                                    tb.AddCell(cel3);
                                    tb.AddCell(cel4);
                                    tb.AddCell(cel5);
                                    tb.AddCell(cel6);

                                    tb.AddCell(cel7);
                                    tb.AddCell(cel8);
                                    tb.AddCell(cel9);
                                    tb.AddCell(celCashierName);
                                    tb.AddCell(cel10);
                                    tb.AddCell(cel11);
                                    tb.AddCell(cel12);
                                    tb.AddCell(cel13);
                                    tb.AddCell(cel);
                                    tb.AddCell(cel14);
                                }
                            }


                            pdfDoc.Add(tb);


                            pdfDoc.Close();
                            stream.Close();
                        }

                        MessageBox.Show("تم تصدير البيانات بنجاح ", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("لا يوجد سجل للتصدير !!!", "Info");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ExportPDF();
        }
        private void cmbSeaTransportID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DateTime dt = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["Column10"].Value.ToString());
                    dtpStart.Value = dt;
                    DateTime dt2 = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["Column11"].Value.ToString());
                    dtpEnd.Value = dt2;
                    cmbCompanyDiscount.Text = dataGridView1.SelectedRows[0].Cells["CompanyName"].Value.ToString();
                    cmbTypeID.Text = dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString();
                    cmbSeaTransportID.Text = dataGridView1.SelectedRows[0].Cells["Column5"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.Columns.Contains("Column3"))
            //    dataGridView1.Columns["Column3"].DisplayIndex = 15;

            //if (dataGridView1.Columns.Contains("Modifier"))
            //    dataGridView1.Columns["Modifier"].DisplayIndex = 16;

            //if (dataGridView1.Columns.Contains("Suppr"))
            //    dataGridView1.Columns["Suppr"].DisplayIndex = 17;

            //dataGridView1.Columns["Column7"].DisplayIndex = 7;
        }
        private void dataGridView1_TabIndexChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.Columns.Contains("Column3"))
            //    dataGridView1.Columns["Column3"].DisplayIndex = 15;

            //if (dataGridView1.Columns.Contains("Modifier"))
            //    dataGridView1.Columns["Modifier"].DisplayIndex = 16;

            //if (dataGridView1.Columns.Contains("Suppr"))
            //    dataGridView1.Columns["Suppr"].DisplayIndex = 17;

            //dataGridView1.Columns["Column7"].DisplayIndex = 7;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Gridfill();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Documents (*.xls)|*.xlsx",
                FileName = "قائمة التذاكر - مرسى كنز أبحر.xlsx"
            };
            //// Insert below
            //Response.ContentEncoding = System.Text.Encoding.Unicode;
            //Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SmartArab.XLSXData.ExportDataGridViewToXLSX(dataGridView2, sfd.FileName);
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
                MessageBox.Show("لا يوجد سجل للتصدير !!!", "Info");
            }
        }
        private void SaveExportedData(DataGridView DatGrdV, string fileName)
        {
            string dataExport = "";
            string fColumnHeader = "";
            for (int j = 0; j < DatGrdV.Columns.Count; j++)
            {
                if (DatGrdV.Columns[j].Visible)
                {
                    fColumnHeader = fColumnHeader.ToString() + Convert.ToString(DatGrdV.Columns[j].HeaderText) + "\t";

                }
            }
            dataExport += fColumnHeader + "\r\n";

            for (int i = 0; i < DatGrdV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < DatGrdV.Rows[i].Cells.Count; j++)
                {
                    if (DatGrdV.Rows[i].Cells[j].Visible)
                        stLine = stLine.ToString() + Convert.ToString(DatGrdV.Rows[i].Cells[j].Value) + "\t";
                }

                dataExport += stLine + "\r\n";
            }
            //Encoding utf16 = Encoding.GetEncoding(1254);
            //byte[] output = utf16.GetBytes(dataExport);

            Encoding utf8 = System.Text.Encoding.UTF8; //new UTF8Encoding(true); //System.Text.Encoding.GetEncoding("Arabic");// //Include Preamble/Byte Order Mark
            byte[] output = utf8.GetBytes(dataExport);

            FileStream FleSys = new FileStream(fileName, FileMode.Create);
            BinaryWriter BinryWrtr = new BinaryWriter(FleSys);
            BinryWrtr.Write(output, 0, output.Length);
            BinryWrtr.Flush();
            BinryWrtr.Close();
            FleSys.Close();
        }
        private void CBAll_Click(object sender, EventArgs e)
        {
        }
        private void CBOut_CheckedChanged(object sender, EventArgs e)
        {
            if (CBOut.Checked)
            {
                CBAll.Checked = false;
                CBLand.Checked = false;
            }
            if (dataGridView1.Rows.Count > 0)
            { 
                SearchTicketsByParametres();
            }
        }
        private void CBAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CBAll.Checked)
            {
                CBOut.Checked = false;
                CBLand.Checked = false;
            }
            if (dataGridView1.Rows.Count > 0)
            {
                SearchTicketsByParametres();
            }
        }
        private void CBLand_CheckedChanged(object sender, EventArgs e)
        {
            if (CBLand.Checked)
            {
                CBOut.Checked = false;
                CBAll.Checked = false;
            }
            if (dataGridView1.Rows.Count > 0) 
            {
                SearchTicketsByParametres();
            }
        }
        private void Idtxt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Idtxt.Text) && dataGridView1.Rows.Count > 0)
            {
                SearchTicketsByParametres();
            }
            else
            {
                SearchTicketsByParametres();
            }
        }
        private void STTtxt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(STTtxt.Text) && dataGridView1.Rows.Count > 0)
            {
                SearchTicketsByParametres();
            }
            else
            {
                SearchTicketsByParametres();
            }
        }
        private void STNtxt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(STNtxt.Text) && dataGridView1.Rows.Count > 0)
            {
                SearchTicketsByParametres();
            }
            else
            {
                SearchTicketsByParametres();
            }
        }
        private void CNtxt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CNtxt.Text) && dataGridView1.Rows.Count > 0)
            {
                SearchTicketsByParametres();
            }
            else
            {
                SearchTicketsByParametres();
            }
        }
        private void CIdtxt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CIdtxt.Text) && dataGridView1.Rows.Count > 0)
            {
                SearchTicketsByParametres();
            }
            else
            {
                SearchTicketsByParametres();
            }
        }
        private void CPtxt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CPtxt.Text) && dataGridView1.Rows.Count > 0)
            {
                SearchTicketsByParametres();
            }
            else
            {
                SearchTicketsByParametres();
            }
        }
        private void ENtxt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ENtxt.Text) && dataGridView1.Rows.Count > 0)
            {
                SearchTicketsByParametres();
            }
            else
            {
                SearchTicketsByParametres();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //if ((int)SQLConn.Role.AdminSys != Data.RoleID || (int)SQLConn.Role.Comptable != Data.RoleID)
            //{
            //    // msg
            //    Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية مدير او محاسب ");
            //    return;
            //}
            //else
            //{

            //}

            try
            {
                string Qur = "";
                var DTS = dtpStart.Value.ToString("yyyy-MM-dd");
                var DTE = dtpEnd.Value.ToString("yyyy-MM-dd");
                Qur = @"Select 
Tickets.ID As 'Ticketid', 
SeaTransport.Name As 'SeaTransportname', 
Customers.Name As 'Customersname', 
Users.UserName As 'Username', 
Drivers.Name As 'Drivername',
Tickets.StartDate,
Convert(Char(5),Tickets.StartTime, 108) AS Starttime,
Convert(Char(5),Tickets.EndTime, 108) AS Endtime,
Tickets.PayCash, 
Tickets.PayCard, 
Tickets.DiscountAmount, 
Tickets.Priceafterdiscount,
Tickets.VAT,
Tickets.PriceAfterVAT, 
Tickets.Note
From Tickets
Left Outer Join SeaTransport
On Tickets.SeaTransportID = SeaTransport.ID
Left Outer Join SeaTransportType
On Tickets.SeaTransportTypeID = SeaTransportType.ID
Left Outer Join Customers
On Tickets.CustomerID = Customers.ID
Left Outer Join Users
On Tickets.UserID = Users.ID
Left Outer Join Drivers
On Tickets.DriverID = Drivers.ID
where Tickets.StartDate >= '" + DTS + "' And Tickets.StartDate <= '" + DTE + "'";
//"And Tickets.ID Not In(Select Invoiceid from Returned)";
                if (cmbSeaTransportID.Text != "--اختر--" && cmbSeaTransportID.Text != "")
                {
                    Qur += "And SeaTransport.Name = '" + cmbSeaTransportID.Text + "' ";
                }
                if (CBOut.Checked)
                {
                    //Qur += "And Drivers.IsEmployee = 0 ";
                    Qur += "And OwnerTypeID = 1 ";
                }
                if (CBLand.Checked)
                {
                    //Qur += "And Drivers.IsEmployee = 1 ";
                    Qur += "And OwnerTypeID = 2 ";
                }
                var Cs = Properties.Settings.Default.Connectionstring;
                SqlConnection Con = new SqlConnection(Cs);
                Con.Open();
                SqlDataAdapter Da = new SqlDataAdapter(Qur, Con);
                QRds Ds = new QRds();
                Da.Fill(Ds, "Tikrep");
                Con.Close();
                CRtick CRP = new CRtick();
                Formrp MR = new Formrp();
                CRP.SetDataSource(Ds);
                MR.CRV.ReportSource = CRP;
                MR.CRV.Refresh();
                MR.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
