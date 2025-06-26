using CrystalDecisions.Shared.Json;
using MarsaAlloaloah.Utility;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using SmartArabXLSX.Bibliography;
using SmartArabXLSX.Office.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    public partial class frmlanding : Form
    {
        int id;
        int SelectedLandingID;
        public frmlanding()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (dgvData.SelectedRows.Count > 0)
            {
                id = Int32.Parse(dgvData.SelectedRows[0].Cells["Column5"].Value.ToString());
            }
            if (btnSave.Text == "حفظ")
            {
                AddLanding();
                GridFill();
            }
            else
            {
                Updatelanding(id);
                GridFill();
            }




        }

        private void Updatelanding(int id)
        {
            string selectedSearch = string.Empty;
            //  MessageBox.Show(id.ToString());

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

            if ((dtpContractEndDate.Value - dtpContractStartDate.Value).Days <= 0)
            {
                Interaction.MsgBox("تاريخ بداية الإرساء لا يمكن ان يكون أكبر أو يساوي تاريخ نهاية الإرساء  ");
                return;
            }
            decimal dailyAmount = 0; int nbdays = 0;
            if (!string.IsNullOrEmpty(txtAmount.Text))
            {
                decimal val = 0;
                Decimal.TryParse(txtAmount.Text, out val);
                nbdays = (dtpContractEndDate.Value - dtpContractStartDate.Value).Days;
                //dailyAmount = Decimal.Round(val / nbdays, 2);
                dailyAmount = Decimal.Round(val / 365, 2);
            }
            //update function 

            int newID;
            SQLConn.sqL = @" update  Landing set Amount=@Amount,StartDate= @StartDate,EndDate=@EndDate,SeaTransportID=@SeaTransportID,DailyAmount=@DailyAmount, Contract=@Contract,Endcontract=@Endcontract,Userid=@Userid,Owner = @Owner where ID=@id ";
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SQLConn.cmd.Parameters.AddWithValue("@Amount", Common.ConvertTxtToDecimal(txtAmount.Text));
            SQLConn.cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dtpContractStartDate.Value;
            SQLConn.cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dtpContractEndDate.Value;
            SQLConn.cmd.Parameters.Add("@SeaTransportID", SqlDbType.Int).Value = int.Parse(cmbSeaTransportID.SelectedValue.ToString());
            SQLConn.cmd.Parameters.AddWithValue("@DailyAmount", dailyAmount);
            SQLConn.cmd.Parameters.AddWithValue("@Contract", CBA.Checked);
            SQLConn.cmd.Parameters.AddWithValue("@Userid", Data.UserID);
            SQLConn.cmd.Parameters.Add("@Owner", SqlDbType.NVarChar).Value = Cmbowner.Text;

            if (CBA.Checked)
            {
                SQLConn.cmd.Parameters.AddWithValue("@Endcontract", SqlDbType.DateTime).Value = DTP.Value;
            }
            else
            {
                SqlDateTime sqldatenull;
                sqldatenull = SqlDateTime.Null;
                SQLConn.cmd.Parameters.AddWithValue("@Endcontract","").Value = sqldatenull;
            }
            SQLConn.cmd.Parameters.AddWithValue("@id", id);
            newID = SQLConn.cmd.ExecuteNonQuery();
            {
                if (newID > 0)
                    Interaction.MsgBox("تم تحديث الإرساء   بنجاح.", MsgBoxStyle.Information, " تحديث الإرساء");
                Clear();
                btnSave.Text = "حفظ";
            }
        }

        private void AddLanding()
        {
            string selectedSearch = string.Empty;

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

            if ((dtpContractEndDate.Value - dtpContractStartDate.Value).Days <= 0)
            {
                Interaction.MsgBox("تاريخ بداية الإرساء لا يمكن ان يكون أكبر أو يساوي تاريخ نهاية الإرساء  ");
                return;
            }
            decimal dailyAmount = GetDailyAmoutPayment();

            int newID;
            SQLConn.sqL = @" INSERT INTO Landing( Amount, StartDate, EndDate, SeaTransportID, DailyAmount, Contract,Endcontract,Userid,Owner)
                    VALUES ( @Amount, @StartDate, @EndDate, @SeaTransportID,@DailyAmount,@Contract,@Endcontract,@Userid,@Owner); SELECT CAST(scope_identity() AS int) ";
            SQLConn.ConnDB();
            //Create Transaction 
            //SQLConn.BeginTransaction();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
            SQLConn.cmd.Parameters.AddWithValue("@Amount", Common.ConvertTxtToDecimal(txtAmount.Text));
            SQLConn.cmd.Parameters.Add("@SeaTransportID", SqlDbType.Int).Value = int.Parse(cmbSeaTransportID.SelectedValue.ToString());
            SQLConn.cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dtpContractStartDate.Value;
            SQLConn.cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dtpContractEndDate.Value;
            SQLConn.cmd.Parameters.AddWithValue("@DailyAmount", dailyAmount);
            SQLConn.cmd.Parameters.AddWithValue("@Contract", CBA.Checked);
            SQLConn.cmd.Parameters.AddWithValue("@Userid", Data.UserID);
            SQLConn.cmd.Parameters.AddWithValue("@Owner", Cmbowner.Text);
            if (CBA.Checked)
            {
                SQLConn.cmd.Parameters.AddWithValue("@Endcontract", SqlDbType.DateTime).Value = DTP.Value;
            }
            else
            {
                SqlDateTime sqldatenull;
                sqldatenull = SqlDateTime.Null;
                SQLConn.cmd.Parameters.AddWithValue("@Endcontract", "").Value = sqldatenull;
            }
            //SQLConn.cmd.Parameters.Add("@PaymentDoneToDate", SqlDbType.DateTime).Value = dtpContractStartDate.Value.AddDays(nbdays);

            newID = (int)SQLConn.cmd.ExecuteScalar();



        }

        private decimal  GetDailyAmoutPayment()
        {
            decimal dailyAmount = 0; int nbdays = 0;
            if (!string.IsNullOrEmpty(txtAmount.Text))
            {
                decimal val = 0;
                Decimal.TryParse(txtAmount.Text, out val);
                nbdays = (dtpContractEndDate.Value -
                          dtpContractStartDate.Value).Days;
                //dailyAmount = Decimal.Round(val / nbdays , 2);
                dailyAmount = Decimal.Round(val / 365 , 2);
            }

            return dailyAmount;
        }

        public void GridFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = LandingGridFill();
                dgvData.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private DataTable LandingGridFill()
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = @"SELECT     
                                Landing.ID,  
                                SeaTransport.Name, 
                                SeaTransportType.Name AS SeaTransportType, 
                                Landing.Amount,
                                Landing.DailyAmount,
                                Landing.StartDate, 
                                Landing.EndDate,
                                Landing.Contract,
                                Landing.Endcontract,
                                Landing.Owner As 'Drivername'
                                FROM Landing 
                                INNER JOIN SeaTransport 
                                ON Landing.SeaTransportID = SeaTransport.ID 
                                INNER JOIN SeaTransportType 
                                ON SeaTransport.TypeID = SeaTransportType.ID";
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "عقد الإرساء", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void frmlanding_Load(object sender, EventArgs e)
        {
            Getowner();
            SeaTransportTypeFill();
            GridFill();
        }

        /// <summary>
        /// Avoir la liste des type de transport boat types
        /// </summary>
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


        public void FillSeaTransportFill(int TypeID)
        {
            try
            {
                SQLConn.ConnDB();
                DataTable dtbl = new DataTable();
                dtbl = SQLConn.getTable(@"SELECT ID, Name, TypeID FROM SeaTransport Where TypeID = " + TypeID + " "
                        //+ @"  and ID not IN(
                        //    SELECT      SeaTransport.ID
                        //    FROM         Tickets LEFT OUTER JOIN
                        //    SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID
                        //   WHERE(Tickets.StartDate = CAST(GETDATE() as DATE)) and(EndTime > CONVERT(TIME, SYSDATETIME()))
                        //    ) 
                        + " Order by TypeID, ID, Name ");
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

        private void cmbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedValue = ((DataRowView)cmbTypeID.SelectedItem).Row[0].ToString();

            if (int.Parse(SelectedValue) > 0)
            {
                FillSeaTransportFill(int.Parse(SelectedValue));
            }
        }





        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvData.SelectedRows.Count > 0)
                {
                    cmbTypeID.Text = dgvData.SelectedRows[0].Cells["Column6"].Value.ToString();
                    DateTime dt = DateTime.Parse(dgvData.SelectedRows[0].Cells["Column2"].Value.ToString());
                    dtpContractStartDate.Value = dt;
                    DateTime dt2 = DateTime.Parse(dgvData.SelectedRows[0].Cells["Column4"].Value.ToString());
                    dtpContractEndDate.Value = dt2;
                    txtAmount.Text = dgvData.SelectedRows[0].Cells["Column3"].Value.ToString();
                    cmbSeaTransportID.Text = dgvData.SelectedRows[0].Cells["Column1"].Value.ToString();
                    Cmbowner.Text = dgvData.SelectedRows[0].Cells["Drivername"].Value.ToString();
                    //Name
                    //CBA.Checked = Convert.ToBoolean(dgvData.SelectedRows[0].Cells["Contract"].Value);
                    //var getdata = Convert.ToInt32(dgvData.SelectedRows[0].Cells["Contract"].Value.ToString());
                    var getdata = dgvData.SelectedRows[0].Cells["Contract"].Value.ToString();
                    if (getdata != "")
                    {
                        var Isbool = Convert.ToBoolean(getdata);
                        CBA.Checked = Isbool;
                        if (Isbool)
                        {
                            DateTime dt3 = DateTime.Parse(dgvData.SelectedRows[0].Cells["Endcontract"].Value.ToString());
                            DTP.Value = dt3;
                        }
                    }
                    btnSave.Text = "تحديث";
                    btnDelete.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void DeleteFunction()
        {
            SelectedLandingID = Convert.ToInt32(dgvData.CurrentRow.Cells[0].Value);
            try
            {
                DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا الارساء", "رسالة تأكيد", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQLConn.ConnDB();
                    SQLConn.sqL = "Delete From Landing WHERE ID = " + SelectedLandingID + "";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.ExecuteNonQuery();
                    Interaction.MsgBox("تم الحذف بنجاح ", MsgBoxStyle.Information, "حذف عقد الارساء");
                    GridFill();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("لا يمكن حذف هذه الارساء لأرتباطه بواسطة بحرية", MsgBoxStyle.Information, "حذف الارساء");

                //Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا الارساء", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
                Clear();
            }
            else
            {
                return;
            }
        }
        private void Clear()
        {
            btnSave.Text = "حفظ";
            cmbTypeID.Text = "";
            txtAmount.Text = "";
            dtpContractStartDate.Value = DateTime.Now;
            dtpContractEndDate.Value = DateTime.Now;
            cmbSeaTransportID.Text = "";
            SeaTransportTypeFill();
            Getowner();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cmbSeaTransportID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Getowner();
        }

        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CBA_CheckedChanged(object sender, EventArgs e)
        {
            if (CBA.Checked)
            {
                DTP.Visible = true;
            }
            else
            {
                DTP.Visible = false;
            }
        }

        private void cmbSeaTransportID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Getowner();
        }
        public void Getowner()
        {
            var Qur = @"Select
                        SeaTransport.OwnerID,
                        Drivers.Name
                        From Drivers
                        Left outer Join SeaTransport
                        On SeaTransport.OwnerID = Drivers.ID
                        Group By SeaTransport.OwnerID,Drivers.Name";
            SQLConn.ConnDB();
            DataTable dtbl = new DataTable();
            dtbl = SQLConn.getTable(Qur);
            DataRow dr = dtbl.NewRow();
            dr["OwnerID"] = 0;
            dr["Name"] = "--اختر--";
            dtbl.Rows.InsertAt(dr, 0);
            Cmbowner.DataSource = dtbl;
            Cmbowner.ValueMember = "OwnerID";
            Cmbowner.DisplayMember = "Name";
        }
    }
}
