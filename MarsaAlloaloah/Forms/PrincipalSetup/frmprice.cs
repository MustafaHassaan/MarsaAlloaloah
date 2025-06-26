using MarsaAlloaloah.Forms.PrincipalSetup;
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
    public partial class frmprice : Form
    {
        int SelectedPriceGroup;
        public frmprice()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 1)
            //{
            //    if ((MessageBox.Show("هل تريد بالتأكيد مسح بيانات التسعير؟", "التسعير", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            //    {
            //        DeleteFunction(int.Parse(dgvPriceGroupChange.CurrentRow.Cells[3].Value.ToString()));
            //    }
            //}
            
        }

        private void frmprice_Load(object sender, EventArgs e)
        {

            loadSeaTransportType();
            try
            {
                Gridfill();
                //FillNewPrice();
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
                if (SelectedPriceGroup > 0)
                {
                    DataTable dtbl = new DataTable();
                    dtbl = PriceGridFill(SelectedPriceGroup);
                    if (dtbl.Rows.Count > 0)
                    {
                        dgvPriceGroupChange.DataSource = dtbl;
                        btnSave.Text = "تحديث";
                        btnClear.Enabled = false;
                    }
                    else
                    {
                        btnSave.Text = "حفظ";
                        FillNewPrice();
                        btnClear.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public DataTable PriceGridFill(int SelectedPriceGroup)
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            try
            {
                SQLConn.sqL = @"select ID, Duration, Price,Percentage, DriverCommission, CashierCommission, CashierExternCommission, SeaTransportTypeID
                                from Price Where SeaTransportTypeID= " + SelectedPriceGroup + " order by DurationValue";
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
            frmpricegroup objSettings = new frmpricegroup();
            frmpricegroup open = Application.OpenForms["frmpricegroup"] as frmpricegroup;
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

        public void loadSeaTransportType()
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
                cmbPriceGroup.DataSource = dtbl;
                cmbPriceGroup.ValueMember = "ID";
                cmbPriceGroup.DisplayMember = "Name";
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

        private void cbPriceGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedPriceGroup = int.Parse(cmbPriceGroup.SelectedValue.ToString());
            Gridfill();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Frmabg abg = new Frmabg();
            btnSave.Text = "تعديل";
            abg.PGID = int.Parse(DID);
            cmbPriceGroup.SelectedValue = int.Parse(STTID);
            abg.Duration.Minimum = int.Parse(DDuration);
            abg.Price.Text = DPrice;
            abg.txtPercentage.Text = DPercent;
            abg.CashierCommission.Text = DCashierper;
            abg.CashierExternCommission.Text = Outper;
            abg.DriverCommission.Text = Driverper;
            abg.Show();
            //if (btnSave.Text == "حفظ")
            //{
            //    for (int i = 0; i < dgvPriceGroupChange.Rows.Count; i++)
            //    {
            //        var Duration = dgvPriceGroupChange.Rows[i].Cells["Duration"].Value;
            //        var Price = dgvPriceGroupChange.Rows[i].Cells["Price"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["Price"].Value) : 0.0m;
            //        var per = dgvPriceGroupChange.Rows[i].Cells["Percentage"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["Percentage"].Value) : 0.0m;
            //        var CashierCommission = dgvPriceGroupChange.Rows[i].Cells["CashierCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["CashierCommission"].Value.ToString()) : 0.0m;
            //        var DriverCommission = dgvPriceGroupChange.Rows[i].Cells["DriverCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["DriverCommission"].Value) : 0.0m;
            //        var CashierExternCommission = dgvPriceGroupChange.Rows[i].Cells["CashierExternCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["CashierExternCommission"].Value) : 0.0m;
            //        // dataGridView3.Rows[i].Cells[1].Value = dataGridView3.Rows[i].Cells[1].Value + "دقيقة";
            //        AddFunction(Price, per, Duration.ToString(), CashierCommission, DriverCommission, CashierExternCommission, SelectedPriceGroup);
            //    }
            //    Interaction.MsgBox("تم حفظ بيانات  التسعير بنجاح.", MsgBoxStyle.Information, "اضافة مجموعة التسعير");
            //    SelectedPriceGroup = int.Parse(cmbPriceGroup.SelectedValue.ToString());
            //    Gridfill();
            //    //ClearFunction();
            //}
            //else
            //{
            //    for (int i = 0; i < dgvPriceGroupChange.Rows.Count; i++)
            //    {
            //        var Duration = dgvPriceGroupChange.Rows[i].Cells["Duration"].Value;
            //        var Price = dgvPriceGroupChange.Rows[i].Cells["Price"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["Price"].Value) : 0.0m;
            //        var per = dgvPriceGroupChange.Rows[i].Cells["Percentage"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["Percentage"].Value) : 0.0m;
            //        var CashierCommission = dgvPriceGroupChange.Rows[i].Cells["CashierCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["CashierCommission"].Value.ToString()) : 0.0m;
            //        var DriverCommission = dgvPriceGroupChange.Rows[i].Cells["DriverCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["DriverCommission"].Value) : 0.0m;
            //        var CashierExternCommission = dgvPriceGroupChange.Rows[i].Cells["CashierExternCommission"].Value.ToString() != "" ? Convert.ToDecimal(dgvPriceGroupChange.Rows[i].Cells["CashierExternCommission"].Value) : 0.0m;
            //        var ID = Convert.ToInt32(dgvPriceGroupChange.Rows[i].Cells["ID"].Value);

            //        UpdateFunction(Price, per, Duration.ToString(), CashierCommission, DriverCommission, CashierExternCommission, ID, SelectedPriceGroup);
            //    }
            //    Interaction.MsgBox("تم تحديث بيانات  التسعير بنجاح.", MsgBoxStyle.Information, "تحديث مجموعة التسعير");
            //    Gridfill();
            //    //ClearFunction();
            //}
        }

        private void AddFunction(decimal Price, decimal Percent, string Duration, decimal CashierCommission, decimal DriverCommission, decimal CashierExternCommission, int PriceGroupID)
        {
            try
            {
                SQLConn.sqL = @"INSERT INTO Price(Price,Percentage,Duration,CashierCommission,DriverCommission,CashierExternCommission,SeaTransportTypeID) 
                                VALUES(@Price,@Percentage,@Duration,@CashierCommission,@DriverCommission,@CashierExternCommission,@SeaTransportTypeID)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Price", Price);
                SQLConn.cmd.Parameters.AddWithValue("@Percentage", Percent);
                SQLConn.cmd.Parameters.AddWithValue("@Duration", Duration);
                SQLConn.cmd.Parameters.AddWithValue("@CashierCommission", CashierCommission);
                SQLConn.cmd.Parameters.AddWithValue("@DriverCommission", DriverCommission);
                SQLConn.cmd.Parameters.AddWithValue("@CashierExternCommission", CashierExternCommission);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportTypeID", PriceGroupID);

                SQLConn.cmd.ExecuteNonQuery();
                //Interaction.MsgBox("تم حفظ بيانات مجموعة التسعير بنجاح.", MsgBoxStyle.Information, "اضافة مجموعة التسعير");
                btnSave.Text = "تحديث";
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
        private void FillNewPrice()
        {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("SlNo");
            dtData.Columns.Add("Duration");
            dtData.Columns.Add("Price");
            dtData.Columns.Add("Percentage");
            dtData.Columns.Add("CashierCommission");
            dtData.Columns.Add("DriverCommission");
            dtData.Columns.Add("CashierExternCommission");
            dtData.Columns.Add("SeaTransportTypeID");
            dtData.Columns.Add("ID");

            DataRow row1 = dtData.NewRow();
            row1["Duration"] = "15" + " " + "دقيقة";
            row1["SlNo"] = "1";
            DataRow row2 = dtData.NewRow();
            row2["Duration"] = "30" + " " + "دقيقة";
            row2["SlNo"] = "2";
            DataRow row3 = dtData.NewRow();
            row3["Duration"] = "45" + " " + "دقيقة";
            row3["SlNo"] = "3";
            DataRow row4 = dtData.NewRow();
            row4["Duration"] = "ساعة";
            row4["SlNo"] = "4";
            dtData.Rows.Add(row1);
            dtData.Rows.Add(row2);
            dtData.Rows.Add(row3);
            dtData.Rows.Add(row4);
            dgvPriceGroupChange.DataSource = dtData;
        }

        private void UpdateFunction(decimal Price,decimal Percent, string Duration, decimal CashierCommission, decimal DriverCommission, decimal CashierExternCommission, int ID, int SelectedPriceGroup)
        {
            try
            {
                decimal a = 0, b, c;
                //Decimal.TryParse();
                //Decimal.TryParse();
                //Decimal.TryParse();
                

                SQLConn.sqL = @"Update Price Set Price = @Price, Percentage = @Percent, Duration = @Duration ,CashierCommission = @CashierCommission,DriverCommission = @DriverCommission,CashierExternCommission=@CashierExternCommission
                    Where ID = @ID and SeaTransportTypeID=@SeaTransportTypeID ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Price", Price);
                SQLConn.cmd.Parameters.AddWithValue("@Percent", Percent);
                SQLConn.cmd.Parameters.AddWithValue("@Duration", Duration);
                SQLConn.cmd.Parameters.AddWithValue("@CashierCommission", CashierCommission);
                SQLConn.cmd.Parameters.AddWithValue("@DriverCommission", DriverCommission);
                SQLConn.cmd.Parameters.AddWithValue("@CashierExternCommission", CashierExternCommission);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportTypeID", SelectedPriceGroup);
                SQLConn.cmd.Parameters.AddWithValue("@ID", ID);
                int nbLineRes = SQLConn.cmd.ExecuteNonQuery();

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DeleteFunction(SelectedPriceGroup);
            //FillNewPrice();


        }

        private void DeleteFunction(int id)
        {
            try
            {
                SQLConn.sqL = "Delete From Price Where ID = @ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@ID", id);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حذف بيانات التسعير بنجاح.", MsgBoxStyle.Information, "حذف التسعير");
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
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "التسعير", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FillNewPrice();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvPriceGroupChange.Rows.Count; i++)
            {
                string duration = string.Empty;
                decimal price = 0, cashierCommission = 0, driverCommission = 0, cashierExternCommission = 0;
                int id = 1;
                if (dgvPriceGroupChange.Rows[i].Cells[2].Value != null)
                    id = Int32.Parse(dgvPriceGroupChange.Rows[i].Cells[2].Value.ToString());

                if (dgvPriceGroupChange.Rows[i].Cells["Duration"].Value != null)
                    duration = dgvPriceGroupChange.Rows[i].Cells["Duration"].Value.ToString();

                if (dgvPriceGroupChange.Rows[i].Cells["Price"].Value != null)
                    price = Common.ConvertTxtToDecimal(dgvPriceGroupChange.Rows[i].Cells["Price"].Value.ToString());

                if (dgvPriceGroupChange.Rows[i].Cells["CashierCommission"].Value != null)
                    cashierCommission = Common.ConvertTxtToDecimal(dgvPriceGroupChange.Rows[i].Cells["CashierCommission"].Value.ToString());

                if (dgvPriceGroupChange.Rows[i].Cells["DriverCommission"].Value != null)
                    driverCommission = Common.ConvertTxtToDecimal(dgvPriceGroupChange.Rows[i].Cells["DriverCommission"].Value.ToString());

                if (dgvPriceGroupChange.Rows[i].Cells["CashierExternCommission"].Value != null)
                    cashierExternCommission = Common.ConvertTxtToDecimal(dgvPriceGroupChange.Rows[i].Cells["CashierExternCommission"].Value.ToString());
                // TODO: update table : only prices, not duration
                UpdatePrice(id, int.Parse(cmbPriceGroup.SelectedValue.ToString()),
                price, duration.ToString(), cashierCommission, driverCommission, cashierExternCommission);
                Gridfill();
            }
        }

        private void UpdatePrice(int id, int SeaTransportTypeID, decimal Price, string Duration, decimal CashierCommission, decimal DriverCommission, decimal CashierExternCommission)
        {
            try
            {
                SQLConn.sqL = @"Update Price (SeaTransportTypeID,Price,Duration,CashierCommission,DriverCommission,CashierExternCommission) 
                                         SET VALUES (@SeaTransportTypeID,@Price,@Duration,@CashierCommission,@DriverCommission,@CashierExternCommission)
                                where ID=@ID";
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@ID", id);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportTypeID", SeaTransportTypeID);
                SQLConn.cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
                SQLConn.cmd.Parameters.AddWithValue("@Duration", Duration);
                SQLConn.cmd.Parameters.Add("@CashierCommission", SqlDbType.Decimal).Value = CashierCommission;
                SQLConn.cmd.Parameters.Add("@DriverCommission", SqlDbType.Decimal).Value = DriverCommission;
                SQLConn.cmd.Parameters.Add("@CashierExternCommission", SqlDbType.Decimal).Value = CashierExternCommission;
                int newID = (int)SQLConn.cmd.ExecuteScalar();

                if (newID > 0)
                {
                    SQLConn.trans.Commit();
                    Interaction.MsgBox("تم حفظ بيانات مجموعة التسعير بنجاح.", MsgBoxStyle.Information, "اضافة مجموعة التسعير");

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

        private void InsertPrice(int SeaTransportTypeID, decimal Price, string Duration, decimal CashierCommission, decimal DriverCommission, decimal CashierExternCommission)
        {
            try
            {
                SQLConn.sqL = @"INSERT INTO Price(SeaTransportTypeID,Price,Duration,CashierCommission,DriverCommission,CashierExternCommission) 
                                          VALUES (@SeaTransportTypeID,@Price,@Duration,@CashierCommission,@DriverCommission,@CashierExternCommission)";
                SQLConn.ConnDB();
                SQLConn.BeginTransaction();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@SeaTransportTypeID", SeaTransportTypeID);
                SQLConn.cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
                SQLConn.cmd.Parameters.AddWithValue("@Duration", Duration);
                SQLConn.cmd.Parameters.Add("@CashierCommission", SqlDbType.Decimal).Value = CashierCommission;
                SQLConn.cmd.Parameters.Add("@DriverCommission", SqlDbType.Decimal).Value = DriverCommission;
                SQLConn.cmd.Parameters.Add("@CashierExternCommission", SqlDbType.Decimal).Value = CashierExternCommission;
                int newID = (int)SQLConn.cmd.ExecuteScalar();

                if (newID > 0)
                {
                    SQLConn.trans.Commit();
                    Interaction.MsgBox("تم حفظ بيانات مجموعة التسعير بنجاح.", MsgBoxStyle.Information, "اضافة مجموعة التسعير");

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
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "مجموعة التسعير", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

        public void ClearFunction()
        {
            try
            {
                cmbPriceGroup.SelectedIndex = -1;
                btnSave.Text = "حفظ";

                Gridfill();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearFunction();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Frmabg abg = new Frmabg();
            abg.Show();
        }
        public string MyProperty { get; set; }
        public string Outper { get; set; }
        public string Driverper { get; set; }
        public string DCashierper { get; set; }
        public string DPercent { get; set; }
        public string DPrice { get; set; }
        public string DV { get; set; }
        public string DDuration { get; set; }
        public string STTID { get; set; }
        public string DID { get; set; }
        //private void dgvPriceGroupChange_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    //if (dgvPriceGroupChange.CurrentCell.ColumnIndex == 6)
        //    //{
        //    //    var per = Convert.ToDecimal(dgvPriceGroupChange.CurrentRow.Cells[6].Value.ToString());
        //    //    var Percent = per / 100;
        //    //    var Amount = Convert.ToDecimal(dgvPriceGroupChange.CurrentRow.Cells[5].Value.ToString());
        //    //    dgvPriceGroupChange.CurrentRow.Cells[8].Value = Math.Round(Percent * Amount, 2);
        //    //    dgvPriceGroupChange.CurrentRow.Cells[9].Value = Math.Round(Percent * Amount, 2);
        //    //}
        //}

        private void dgvPriceGroupChange_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPriceGroupChange.Rows.Count > 0)
            {
                var data = dgvPriceGroupChange.Rows[e.RowIndex].Cells[0].Value.ToString();
                STTID = dgvPriceGroupChange.CurrentRow.Cells[1].Value.ToString();
                DDuration = dgvPriceGroupChange.CurrentRow.Cells[2].Value.ToString();
                DV = dgvPriceGroupChange.CurrentRow.Cells[4].Value.ToString();
                DPrice = dgvPriceGroupChange.CurrentRow.Cells[5].Value.ToString();
                DPercent = dgvPriceGroupChange.CurrentRow.Cells[6].Value.ToString();
                DCashierper = dgvPriceGroupChange.CurrentRow.Cells[8].Value.ToString();
                Driverper = dgvPriceGroupChange.CurrentRow.Cells[7].Value.ToString();
                Outper = dgvPriceGroupChange.CurrentRow.Cells[9].Value.ToString();
            }
        }
    }
}
