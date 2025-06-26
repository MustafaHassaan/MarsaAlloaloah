using CrystalDecisions.CrystalReports.ViewerObjectModel;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.draw;
using System.Drawing;
using System.Drawing.Drawing2D;
using CrystalDecisions.ReportAppServer.CubeDefModel;
using System.util;

namespace MarsaKanzAbhar
{
    public partial class FrmTickets : Form
    {
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

                DisCompanydtbl = SQLConn.getTable("SELECT ID,CompanyName,DiscountValue FROM CompanyDiscount where IsActive = 1 and EndDate >= GetDate() ");
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
                dtbl = SQLConn.getTable(@"SELECT ID,Name,TypeID FROM SeaTransport Where TypeID = " + TypeID + " " +
                    @"  and ID not IN(
                        SELECT      SeaTransport.ID
                        FROM         Tickets Inner JOIN
                        SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID
                        WHERE(Tickets.StartDate = CAST(GETDATE() as DATE)) and(EndTime > CONVERT(TIME, SYSDATETIME()))
                        )" +
                    "Order by TypeID, ID, Name ");
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

        private void FrmTickets_Load(object sender, EventArgs e)
        {

            // Load all tickets details
            try
            {
                Gridfill();
                SeaTransportTypeFill();
                CompanyDiscountFill();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public void Gridfill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = GetAllTickets();
                dataGridView1.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable GetAllTickets()
        {
            DataTable dtbl = new DataTable();
            //dtbl.Columns.Add("SlNo", typeof(int));
            //dtbl.Columns["SlNo"].AutoIncrement = true;
            //dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            try
            {
                string sql = @"SELECT     Tickets.ID,   SeaTransportType.Name AS SeaTransportTypeName, SeaTransport.Name AS SeaTransportName,Customers.Name AS CustomerName,Customers.Mobile, Customers.NID, 
                       Tickets.StartDate, Tickets.DurationValue , CAST(Tickets.StartTime AS time(0)) AS StartTimeTicket,CAST(Tickets.EndTime AS time(0)) AS EndTimeTicket, 
                      Drivers.Name AS DriverName,CompanyDiscount.CompanyName, CompanyDiscount.DiscountValue, Tickets.DiscountAmount, Tickets.PriceAfterDiscount
                      FROM         Tickets INNER JOIN
                      Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                      SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID LEFT OUTER JOIN
                      Drivers ON Tickets.DriverID = Drivers.ID LEFT OUTER JOIN
                      SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID 
                      LEFT OUTER JOIN
                      CompanyDiscount ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue 
                      order by Tickets.ID desc";
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

        public DataTable GetTicket()
        {
            DataTable dtbl = new DataTable();
            //dtbl.Columns.Add("SlNo", typeof(int));
            //dtbl.Columns["SlNo"].AutoIncrement = true;
            //dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            try
            {
                string sql = @"SELECT     Tickets.ID,   SeaTransportType.Name AS SeaTransportTypeName, SeaTransport.Name AS SeaTransportName,Customers.Name AS CustomerName,Customers.Mobile, Customers.NID, 
                       Tickets.StartDate, Tickets.DurationValue , CAST(Tickets.StartTime AS time(0)) AS StartTimeTicket,CAST(Tickets.EndTime AS time(0)) AS EndTimeTicket, 
                      Drivers.Name AS DriverName,CompanyDiscount.CompanyName, CompanyDiscount.DiscountValue, Tickets.DiscountAmount, Tickets.PriceAfterDiscount
                      FROM         Tickets INNER JOIN
                      Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                      SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID LEFT OUTER JOIN
                      Drivers ON Tickets.DriverID = Drivers.ID LEFT OUTER JOIN
                      SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID 
                      LEFT OUTER JOIN
                      CompanyDiscount ON Tickets.DiscountPercent = CompanyDiscount.DiscountValue 
                      where  CompanyDiscount.CompanyName=@name and SeaTransportType.Name=@namtypetranport and  SeaTransport.Name=@nameseatransp and Tickets.StartDate>= @timedeb and Tickets.StartDate<=@timeend
                    ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(sql, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@name", cmbCompanyDiscount.Text);
                SQLConn.cmd.Parameters.AddWithValue("@namtypetranport", cmbTypeID.Text);
                SQLConn.cmd.Parameters.AddWithValue("@nameseatransp", cmbSeaTransportID.Text);
                SQLConn.cmd.Parameters.AddWithValue("@timedeb", SqlDbType.DateTime).Value = dtpStart.Value;
                SQLConn.cmd.Parameters.AddWithValue("@timeend", SqlDbType.DateTime).Value = dtpEnd.Value;
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

            DataTable dtbl = new DataTable();
            if (int.Parse(cmbTypeID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر نوع الواسطة البحرية");
                return;
            }
            if (int.Parse(cmbSeaTransportID.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر الواسطة البحرية");
                return;
            }
            if (int.Parse(cmbCompanyDiscount.SelectedValue.ToString()) == 0)
            {
                Interaction.MsgBox("من فضلك إختر نوع الخصم ");
                return;
            }
            if (int.Parse(cmbTypeID.SelectedValue.ToString()) != 0 && int.Parse(cmbSeaTransportID.SelectedValue.ToString()) != 0 && int.Parse(cmbCompanyDiscount.SelectedValue.ToString()) != 0)
            {


                try
                {
                    dtbl = GetTicket();
                    dataGridView1.DataSource = dtbl;
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.ToString());
                }

            }

        }
        /*
        private void ExportPDF()
        {

            var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = "PDF (*.pdf)|*.pdf";
            sfd.FileName = "فاتورة مرسى كنز أبحر.pdf";
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
                            string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arabtype.TTF");

//Create a base font object making sure to specify IDENTITY-H
BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL);
//f.SetStyle(PdfFontStyle.BOLD);
Color c = Color.DarkRed;
f.Size = 15;
                            iTextSharp.text.pdf.PdfPTable tb = new iTextSharp.text.pdf.PdfPTable(15);
tb.WidthPercentage = 100;
                            tb.PaddingTop = 1;
                            tb.SpacingAfter = 0;
                            tb.SpacingBefore = 30;
                            float[] widths = { 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f };
tb.SetWidths(widths);// largeur par cellule


                            iTextSharp.text.Image Jpg = iTextSharp.text.Image.GetInstance("logoK.png");
Jpg.Alignment = Element.ALIGN_CENTER;
                            Jpg.SpacingAfter = 1f;
                            Jpg.SpacingBefore = 10f;
                            Jpg.ScaleAbsolute(159f, 159f);
                            pdfDoc.Add(Jpg);
                            //Create a specific font object

                            iTextSharp.text.pdf.PdfPCell celprix = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " السعر بعد الخصم :  ", f));

celprix.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celprix);

                            iTextSharp.text.pdf.PdfPCell celdiscontamount = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  قيمة الخصم:  ", f));

celdiscontamount.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celdiscontamount);

                            iTextSharp.text.pdf.PdfPCell celDiscountValu = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  نسبة الخصم(%):  ", f));

celDiscountValu.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celDiscountValu);
                            iTextSharp.text.pdf.PdfPCell celdiscount = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  نوع الخصم:  ", f));

celdiscount.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celdiscount);

                            iTextSharp.text.pdf.PdfPCell cell8 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "    السائق:  ", f));

cell8.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell8);
                            iTextSharp.text.pdf.PdfPCell celtimeend = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  وقت العودة:  ", f));

celtimeend.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celtimeend);
                            iTextSharp.text.pdf.PdfPCell celtimedeb = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  وقت الانطلاق:  ", f));

celtimedeb.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celtimedeb);

                            iTextSharp.text.pdf.PdfPCell celdatdeb = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "   ميعاد بداية الرحلة:  ", f));

celdatdeb.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celdatdeb);

                            iTextSharp.text.pdf.PdfPCell cell6 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  لمدة الزمنية:  ", f));

cell6.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell6);
                            iTextSharp.text.pdf.PdfPCell cell3 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " رقم الجوال : ", f));

cell3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell3);

                            iTextSharp.text.pdf.PdfPCell cell2 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "رقم الهوية :", f));

cell2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell2);
                            iTextSharp.text.pdf.PdfPCell cell1 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "إسم العميل:   ", f));

cell1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell1);
                            iTextSharp.text.pdf.PdfPCell cell7 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  الواسطة البحرية:  ", f));

cell7.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell7);

                            iTextSharp.text.pdf.PdfPCell cell5 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  نوع الواسطة البحرية:  ", f));

cell5.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell5);
                            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " رقم الفاتورة:", f));

cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell);
                            foreach (DataGridViewRow Row in dataGridView1.Rows)
                            {
                                if (Row != null && Row.Cells[1].Value != null &&
                                    Row.Cells[2].Value != null && Row.Cells[3].Value != null && Row.Cells[4].Value != null && Row.Cells[5].Value != null && Row.Cells[6].Value != null &&
                                    Row.Cells[7].Value != null && Row.Cells[7].Value != null && Row.Cells[8].Value != null && Row.Cells[9].Value != null && Row.Cells[10].Value != null
                                    && Row.Cells[11].Value != null && Row.Cells[12].Value != null && Row.Cells[13].Value != null && Row.Cells[14].Value != null && Row.Cells[15].Value != null)
                                {
                                    string s = Row.Cells[1].Value.ToString();
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
                                    iTextSharp.text.pdf.PdfPCell cel7 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column10"].Value.ToString(), f));
cel7.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                    iTextSharp.text.pdf.PdfPCell cel8 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, Row.Cells["Column7"].Value.ToString(), f));
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
    
        */

        //private void ExportPDF()
        //{

        //    var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "PDF (*.pdf)|*.pdf";
        //    sfd.FileName = "فاتورة مرسى كنز أبحر.pdf";
        //    bool fileError = false;
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        if (File.Exists(sfd.FileName))
        //        {

        //            try
        //            {
        //                File.Delete(sfd.FileName);
        //            }
        //            catch (IOException ex)
        //            {
        //                fileError = true;
        //                MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
        //            }
        //        }
        //        if (!fileError)
        //        {
        //            try
        //            {
        //                pdfDoc.Open();

        //                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
        //                {

        //                    PdfWriter.GetInstance(pdfDoc, stream);
        //                    pdfDoc.Open();
        //                    string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");

        //                    //Create a base font object making sure to specify IDENTITY-H
        //                    BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //                    iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL);
        //                    //f.SetStyle(PdfFontStyle.BOLD);
        //                    iTextSharp.text.Font f1 = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.BOLD);
        //                    f1.Size = 9;

        //                    Color c = Color.DarkRed;
        //                    f.Size = 10;
        //                    iTextSharp.text.pdf.PdfPTable tb = new iTextSharp.text.pdf.PdfPTable(15);
        //                    tb.WidthPercentage = 100;
        //                    tb.PaddingTop = 1;
        //                    tb.SpacingAfter = 0;
        //                    tb.SpacingBefore = 30;
        //                    float[] widths = { 0.7f, 0.7f, 0.9f, 0.7f, 0.7f, 0.7f, 0.7f, 0.9f, 0.9f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f };
        //                    tb.SetWidths(widths);// largeur par cellule


        //                    iTextSharp.text.Image Jpg = iTextSharp.text.Image.GetInstance("logoK.png");
        //                    Jpg.Alignment = Element.ALIGN_CENTER;
        //                    Jpg.SpacingAfter = 1f;
        //                    Jpg.SpacingBefore = 10f;
        //                    Jpg.ScaleAbsolute(159f, 178f);
        //                    pdfDoc.Add(Jpg);
        //                    //Create a specific font object





        //                    iTextSharp.text.pdf.PdfPCell celprix = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " السعر بعد الخصم :  ", f1));

        //                    celprix.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(celprix);

        //                    iTextSharp.text.pdf.PdfPCell celdiscontamount = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  قيمة الخصم:  ", f1));

        //                    celdiscontamount.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(celdiscontamount);

        //                    iTextSharp.text.pdf.PdfPCell celDiscountValu = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  نسبة الخصم(%):  ", f1));

        //                    celDiscountValu.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(celDiscountValu);
        //                    iTextSharp.text.pdf.PdfPCell celdiscount = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  نوع الخصم:  ", f1));

        //                    celdiscount.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(celdiscount);

        //                    iTextSharp.text.pdf.PdfPCell cell8 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "    السائق:  ", f1));

        //                    cell8.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(cell8);
        //                    iTextSharp.text.pdf.PdfPCell celtimeend = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  وقت العودة:  ", f1));

        //                    celtimeend.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(celtimeend);
        //                    iTextSharp.text.pdf.PdfPCell celtimedeb = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  وقت الانطلاق:  ", f1));

        //                    celtimedeb.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(celtimedeb);

        //                    iTextSharp.text.pdf.PdfPCell celdatdeb = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "   ميعاد بداية الرحلة:  ", f1));

        //                    celdatdeb.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(celdatdeb);

        //                    iTextSharp.text.pdf.PdfPCell cell6 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  لمدة الزمنية:  ", f1));

        //                    cell6.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(cell6);
        //                    iTextSharp.text.pdf.PdfPCell cell3 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " رقم الجوال : ", f1));

        //                    cell3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(cell3);

        //                    iTextSharp.text.pdf.PdfPCell cell2 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "رقم الهوية :", f1));

        //                    cell2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(cell2);
        //                    iTextSharp.text.pdf.PdfPCell cell1 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "إسم العميل:   ", f1));

        //                    cell1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(cell1);
        //                    iTextSharp.text.pdf.PdfPCell cell7 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  الواسطة البحرية:  ", f1));

        //                    cell7.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(cell7);

        //                    iTextSharp.text.pdf.PdfPCell cell5 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "  نوع الواسطة البحرية:  ", f1));

        //                    cell5.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(cell5);
        //                    iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " رقم الفاتورة:", f1));

        //                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                    tb.AddCell(cell);
        //                    foreach (DataGridViewRow Row in dataGridView1.Rows)
        //                    {
        //                        if (Row != null && Row.Cells[1].Value != null &&
        //                            Row.Cells[2].Value != null && Row.Cells[3].Value != null && Row.Cells[4].Value != null && Row.Cells[5].Value != null && Row.Cells[6].Value != null &&
        //                            Row.Cells[7].Value != null && Row.Cells[7].Value != null && Row.Cells[8].Value != null && Row.Cells[9].Value != null && Row.Cells[10].Value != null
        //                            && Row.Cells[11].Value != null && Row.Cells[12].Value != null && Row.Cells[13].Value != null && Row.Cells[14].Value != null && Row.Cells[15].Value != null)
        //                        {
        //                            string s = Row.Cells[1].Value.ToString();
        //                            iTextSharp.text.pdf.PdfPCell cel = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, s, f));
        //                            cel.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel1 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["Column3"].Value.ToString(), f));
        //                            cel1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel2 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["DiscountAmount"].Value.ToString(), f));
        //                            cel2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel3 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["DiscountValue"].Value.ToString(), f));
        //                            cel3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel4 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["CompanyName"].Value.ToString(), f));
        //                            cel4.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel5 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["Column6"].Value.ToString(), f));
        //                            cel5.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel6 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["Column11"].Value.ToString(), f));
        //                            cel6.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel7 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["Column10"].Value.ToString(), f));
        //                            cel7.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

        //                            string[] date_Etablile = Row.Cells["Column7"].Value.ToString().Split(new char[] { ' ' });

        //                            iTextSharp.text.pdf.PdfPCell cel8 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, date_Etablile[0], f));
        //                            cel8.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel9 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["Column2"].Value.ToString(), f));
        //                            cel9.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel10 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["Column9"].Value.ToString(), f));
        //                            cel10.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel11 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["Column8"].Value.ToString(), f));
        //                            cel11.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel12 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["dgclientname"].Value.ToString(), f));
        //                            cel12.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //                            iTextSharp.text.pdf.PdfPCell cel13 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["Column5"].Value.ToString(), f));
        //                            cel13.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

        //                            iTextSharp.text.pdf.PdfPCell cel14 = new iTextSharp.text.pdf.PdfPCell(new Phrase(5, Row.Cells["Column1"].Value.ToString(), f));
        //                            cel14.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

        //                            tb.AddCell(cel1);
        //                            tb.AddCell(cel2);
        //                            tb.AddCell(cel3);
        //                            tb.AddCell(cel4);
        //                            tb.AddCell(cel5);
        //                            tb.AddCell(cel6);
        //                            tb.AddCell(cel7);
        //                            tb.AddCell(cel8);
        //                            tb.AddCell(cel9);
        //                            tb.AddCell(cel10);
        //                            tb.AddCell(cel11);
        //                            tb.AddCell(cel12);
        //                            tb.AddCell(cel13);
        //                            tb.AddCell(cel);
        //                            tb.AddCell(cel14);
        //                        }
        //                    }


        //                    pdfDoc.Add(tb);


        //                    pdfDoc.Close();
        //                    stream.Close();
        //                }

        //                MessageBox.Show("تم تصدير البيانات بنجاح ", "Info");
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Error :" + ex.Message);
        //            }

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("لا يوجد سجل للتصدير !!!", "Info");
        //    }
        //}
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
                            iTextSharp.text.pdf.PdfPTable tb = new iTextSharp.text.pdf.PdfPTable(15);
                            tb.WidthPercentage = 100;
                            tb.PaddingTop = 1;
                            tb.SpacingAfter = 0;
                            tb.SpacingBefore = 30;


                            float[] widths = { 0.5f, 0.7f, 0.5f, 0.7f, 0.9f, 0.7f, 0.7f, 0.9f, 0.9f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f };
                            tb.SetWidths(widths);// largeur par cellule


                            iTextSharp.text.Image Jpg = iTextSharp.text.Image.GetInstance("logoK.png");
                            Jpg.Alignment = Element.ALIGN_CENTER;
                            Jpg.SpacingAfter = 1f;
                            Jpg.SpacingBefore = 10f;
                            Jpg.WidthPercentage = 80;
                            Jpg.ScaleAbsolute(159f, 178f);
                            pdfDoc.Add(Jpg);
                            //Create a specific font object





                            iTextSharp.text.pdf.PdfPCell celprix = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " السعر بعد الخصم : ", f1));

                            celprix.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celprix);

                            iTextSharp.text.pdf.PdfPCell celdiscontamount = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " قيمة الخصم: ", f1));

                            celdiscontamount.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celdiscontamount);

                            iTextSharp.text.pdf.PdfPCell celDiscountValu = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " نسبة الخصم(%): ", f1));

                            celDiscountValu.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celDiscountValu);
                            iTextSharp.text.pdf.PdfPCell celdiscount = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " نوع الخصم: ", f1));

                            celdiscount.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celdiscount);

                            iTextSharp.text.pdf.PdfPCell cell8 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " السائق: ", f1));

                            cell8.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell8);
                            iTextSharp.text.pdf.PdfPCell celtimeend = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " وقت العودة: ", f1));

                            celtimeend.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celtimeend);
                            iTextSharp.text.pdf.PdfPCell celtimedeb = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " وقت الانطلاق: ", f1));

                            celtimedeb.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celtimedeb);

                            iTextSharp.text.pdf.PdfPCell celdatdeb = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " ميعاد بداية الرحلة: ", f1));

                            celdatdeb.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(celdatdeb);

                            iTextSharp.text.pdf.PdfPCell cell6 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " لمدة الزمنية: ", f1));

                            cell6.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell6);
                            iTextSharp.text.pdf.PdfPCell cell3 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " رقم الجوال : ", f1));

                            cell3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell3);

                            iTextSharp.text.pdf.PdfPCell cell2 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "رقم الهوية :", f1));

                            cell2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell2);
                            iTextSharp.text.pdf.PdfPCell cell1 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, "إسم العميل: ", f1));

                            cell1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell1);
                            iTextSharp.text.pdf.PdfPCell cell7 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " الواسطة البحرية: ", f1));

                            cell7.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            tb.AddCell(cell7);

                            iTextSharp.text.pdf.PdfPCell cell5 = new iTextSharp.text.pdf.PdfPCell(new Phrase(8, " نوع الواسطة البحرية: ", f1));

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
                                    string s = Row.Cells[1].Value.ToString();
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

                        MessageBox.Show("تم تصدير البيانات بنجاح !!!", "Info");
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
    }
}
