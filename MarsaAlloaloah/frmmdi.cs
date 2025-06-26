using MarsaAlloaloah.CrystalReports;
using MarsaAlloaloah.Forms;
using MarsaAlloaloah.Forms.Banktransfare;
using MarsaAlloaloah.Forms.Boats;
using MarsaAlloaloah.Forms.PrincipalSetup;
using MarsaAlloaloah.Forms.Returned;
using MarsaAlloaloah.Forms.TransfertMoney;
using MarsaAlloaloah.FrmReports;
using MarsaAlloaloah.Rentals;
using MarsaAlloaloah.Utility;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MarsaAlloaloah.dsMarsa;

namespace MarsaAlloaloah
{
    public partial class frmmdi : Form
    {
        public frmmdi()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            InitializeComponent();           
        }
        public bool Home { get; set; }
        public bool Customers { get; set; }
        public bool Price { get; set; }
        public bool Extentions { get; set; }
        public bool Trsury { get; set; }
        public bool Bankaccount { get; set; }
        public bool Companydiscount { get; set; }
        public bool Systemsetting { get; set; }
        public bool Boats { get; set; }
        public bool Boattype { get; set; }
        public bool Boatlist { get; set; }
        public bool Boatsort { get; set; }
        public bool Boatin { get; set; }
        public bool Boatout { get; set; }
        public bool Boatfix { get; set; }
        public bool Anchor { get; set; }
        public bool Anchorpay { get; set; }
        public bool Tickes { get; set; }
        public bool Ticketlist { get; set; }
        public bool Ticketedit { get; set; }
        public bool Ticketdelete { get; set; }
        public bool Newticket { get; set; }
        public bool Boatowner { get; set; }
        public bool Revenuse { get; set; }
        public bool Revenusetype { get; set; }
        public bool Revenuselist { get; set; }
        public bool Expences { get; set; }
        public bool Expencestype { get; set; }
        public bool Expenceslist { get; set; }
        public bool Mony { get; set; }
        public bool FTTB { get; set; }
        public bool FBTT { get; set; }
        public bool Monrecive { get; set; }
        public bool Monrecivecashier { get; set; }
        public bool Accountsreport { get; set; }
        public bool Trsurep { get; set; }
        public bool Timeworkrep { get; set; }
        public bool Cashbalancerep { get; set; }
        public bool Cashierreciverep { get; set; }
        public bool Excepencesrep { get; set; }
        public bool Revenuserep { get; set; }
        public bool Anchorpayrep { get; set; }
        public bool Cashcomrep { get; set; }
        public bool Drivecomrep { get; set; }
        public bool Generalrep { get; set; }
        public bool Revenusetexrep { get; set; }
        public bool Tickettaxrep { get; set; }
        public bool Comboatoutrep { get; set; }
        public bool Exceptaxrep { get; set; }
        public bool Allanchorpayrep { get; set; }
        public bool Returnedrep { get; set; }
        public bool Emploies { get; set; }
        public bool Jobss { get; set; }
        public bool Drivers { get; set; }
        public bool Emplist { get; set; }
        public bool Users { get; set; }
        public bool Permessions { get; set; }
        public bool Userlist { get; set; }
        public bool Returned { get; set; }
        public bool Returnedlist { get; set; }
        public bool Newreturned { get; set; }
        public bool CBBankaccount { get; set; }
        public bool Rents { get; set; }
        public bool NewRent { get; set; }
        public bool Rentslist { get; set; }
        public bool Rentalrep { get; set; }
        public bool Boatfixrep { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            frmboats objSettings = new frmboats();
            frmboats open = Application.OpenForms["frmboats"] as frmboats;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button2_Click(object sender, EventArgs e)
        {
            frmdrivers objSettings = new frmdrivers();
            frmdrivers open = Application.OpenForms["frmdrivers"] as frmdrivers;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button3_Click(object sender, EventArgs e)
        {
            frmcustomers objSettings = new frmcustomers();
            frmcustomers open = Application.OpenForms["frmcustomers"] as frmcustomers;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button4_Click(object sender, EventArgs e)
        {
            frmemployees objSettings = new frmemployees();
            frmemployees open = Application.OpenForms["frmemployees"] as frmemployees;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button5_Click(object sender, EventArgs e)
        {
            frmoutboat objSettings = new frmoutboat();
            frmoutboat open = Application.OpenForms["frmoutboat"] as frmoutboat;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button6_Click(object sender, EventArgs e)
        {
            frminboat objSettings = new frminboat();
            frminboat open = Application.OpenForms["frminboat"] as frminboat;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button7_Click(object sender, EventArgs e)
        {
            frmpricegroup objSettings = new frmpricegroup();
            frmpricegroup open = Application.OpenForms["frmpricegroup"] as frmpricegroup;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button8_Click(object sender, EventArgs e)
        {
            frmprice objSettings = new frmprice();
            frmprice open = Application.OpenForms["frmprice"] as frmprice;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button9_Click(object sender, EventArgs e)
        {
            frmticket objSettings = new frmticket();
            frmticket open = Application.OpenForms["frmticket"] as frmticket;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button10_Click(object sender, EventArgs e)
        {
            frmIncomeType objSettings = new frmIncomeType();
            frmIncomeType open = Application.OpenForms["frmIncomeType"] as frmIncomeType;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button11_Click(object sender, EventArgs e)
        {
            frmIncome objSettings = new frmIncome();
            frmIncome open = Application.OpenForms["frmIncome"] as frmIncome;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button13_Click(object sender, EventArgs e)
        {
            frmExpensesType objSettings = new frmExpensesType();
            frmExpensesType open = Application.OpenForms["frmExpensesType"] as frmExpensesType;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button12_Click(object sender, EventArgs e)
        {

            frmExpenses objSettings = new frmExpenses();
            frmExpenses open = Application.OpenForms["frmExpenses"] as frmExpenses;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button14_Click(object sender, EventArgs e)
        {
            frmMaintenance objSettings = new frmMaintenance();
            frmMaintenance open = Application.OpenForms["frmMaintenance"] as frmMaintenance;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void button15_Click(object sender, EventArgs e)
        {
            frmSettings objSettings = new frmSettings();
            frmSettings open = Application.OpenForms["frmSettings"] as frmSettings;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void ToolStripMenuItemSeaTrasportType_Click(object sender, EventArgs e)
        {
            try
            {
                frmBoatType frm = new frmBoatType();
                frmBoatType open = Application.OpenForms["frmBoatType"] as frmBoatType;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ToolStripMenuItemClients_Click(object sender, EventArgs e)
        {
            try
            {
                frmcustomers frm = new frmcustomers();
                frmcustomers open = Application.OpenForms["frmcustomers"] as frmcustomers;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ToolStripMenuItemPriceGroup_Click(object sender, EventArgs e)
        {
            try
            {
                frmpricegroup frm = new frmpricegroup();
                frmpricegroup open = Application.OpenForms["frmpricegroup"] as frmpricegroup;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ToolStripMenuItemPrice_Click(object sender, EventArgs e)
        {
            try
            {
                //frmprice frm = new frmprice();
                //frmprice open = Application.OpenForms["frmprice"] as frmprice;
                Frmpricing frm = new Frmpricing();
                Frmpricing open = Application.OpenForms["Frmpricing"] as Frmpricing;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ToolStripMenuItemBoats_Click(object sender, EventArgs e)
        {
            try
            {
                frmboatsAndListing frm = new frmboatsAndListing();
                frmboatsAndListing open = Application.OpenForms["frmboatsAndListing"] as frmboatsAndListing;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            frmtreasury objSettings = new frmtreasury();
            frmtreasury open = Application.OpenForms["frmtreasury"] as frmtreasury;
            if (open == null)
            {
                objSettings.MdiParent = this;
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

        private void ToolStripMenuItemAddon_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAddons frm = new FrmAddons();
                FrmAddons open = Application.OpenForms["FrmAddons"] as FrmAddons;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ToolStripMenuItemٍٍSystemSettings_Click(object sender, EventArgs e)
        {
            try
            {
                frmSettings frm = new frmSettings();
                frmSettings open = Application.OpenForms["frmSettings"] as frmSettings;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ToolStripMenuItemNewTicket_Click(object sender, EventArgs e)
        {
            //if ((int)SQLConn.Role.Cashier != Data.RoleID)
            //{
            //    // msg
            //    Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية كاشير ");
            //    return;
            //}

            try
            {
                frmticket frmticket = Application.OpenForms["frmticket"] as frmticket;
                if (frmticket != null)
                {
                    frmticket.WindowState = FormWindowState.Normal;
                    frmticket.BringToFront();
                    frmticket.Activate();
                }
                else
                {
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                    frmticket = new frmticket
                    {
                        MdiParent = this,
                        Dock = DockStyle.None
                    };
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                    frmticket.Show();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ToolStripMenuItemDrivers_Click(object sender, EventArgs e)
        {
            try
            {
                frmdriversAndListing frm = new frmdriversAndListing();
                frmdriversAndListing open = Application.OpenForms["frmdriversAndListing"] as frmdriversAndListing;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }

        }

        private void ToolStripMenuItemRoles_Click(object sender, EventArgs e)
        {

            try
            {
                frmRole frm = new frmRole();
                frmRole open = Application.OpenForms["frmRole"] as frmRole;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ToolStripMenuItemEmemployee_Click(object sender, EventArgs e)
        {

            try
            {
                frmemployees frm = new frmemployees();
                frmemployees open = Application.OpenForms["frmemployees"] as frmemployees;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ToolStripMenuItemUsers_Click(object sender, EventArgs e)
        {
            try
            {
                frmUsers frm = new frmUsers();
                frmUsers open = Application.OpenForms["frmUsers"] as frmUsers;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void toolStripMenuItemٍSeaTransportOrder_Click(object sender, EventArgs e)
        {

            try
            {
                frmBoatsOrder frm = new frmBoatsOrder();
                frmBoatsOrder open = Application.OpenForms["frmBoatsOrder"] as frmBoatsOrder;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }

        }

        private void toolStripMenuItembusySearransport_Click(object sender, EventArgs e)
        {
            try
            {               
//                frmBusyBoats frmBusyBoats = Application.OpenForms["frmBusyBoats"] as frmBusyBoats;
//                if (frmBusyBoats != null)
//                {
//                    frmBusyBoats.WindowState = FormWindowState.Normal;
//                    frmBusyBoats.BringToFront();
//                    frmBusyBoats.Activate();
//                }
//                else
//                {
//#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
//                    frmBusyBoats = new frmBusyBoats
//                    {
//                        MdiParent = this,
//                        Dock = DockStyle.Fill
//                    };
//#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
//                    frmBusyBoats.Show();
//                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemTreasury_Click(object sender, EventArgs e)
        {
            try
            {
                frmtreasury frm = new frmtreasury();
                frmtreasury open = Application.OpenForms["frmtreasury"] as frmtreasury;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void toolStripMenuItemBankAccount_Click(object sender, EventArgs e)
        {
            try
            {
                frmBankAccount frm = new frmBankAccount();
                frmtreasury open = Application.OpenForms["frmBankA"] as frmtreasury;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                frmticket frm = new frmticket();
                frmticket open = Application.OpenForms["frmticket"] as frmticket;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                frmSettings frm = new frmSettings();
                frmSettings open = Application.OpenForms["frmSettings"] as frmSettings;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //if ((int)SQLConn.Role.Cashier != Data.RoleID)
            //{
            //    // msg
            //    Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية كاشير ");
            //    return;
            //}
            try
            {
                frmticket frm = new frmticket();
                frmticket open = Application.OpenForms["frmticket"] as frmticket;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                frmUsers frm = new frmUsers();
                frmUsers open = Application.OpenForms["frmUsers"] as frmUsers;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                frmSettings frm = new frmSettings();
                frmSettings open = Application.OpenForms["frmSettings"] as frmSettings;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //frmBusyBoats frm = new frmBusyBoats();
                //frmBusyBoats open = Application.OpenForms["frmBusyBoats"] as frmBusyBoats;
                //if (open == null)
                //{
                //    frm.MdiParent = this;
                //    frm.Show();
                //}
                //else
                //{
                //    open.Activate();
                //    if (open.WindowState == FormWindowState.Minimized)
                //    {
                //        open.WindowState = FormWindowState.Normal;
                //    }
                //}
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void frmmdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock && Control.IsKeyLocked(Keys.CapsLock))
            {
                lblCapsLk.BackColor = Color.Aqua;
            }
            else if (e.KeyCode == Keys.CapsLock && Control.IsKeyLocked(Keys.CapsLock) == false)
            {
                lblCapsLk.BackColor = SystemColors.Control;
            }

            else if (e.KeyCode == Keys.NumLock && Control.IsKeyLocked(Keys.NumLock))
            {
                lblNumLk.BackColor = Color.Aqua;
            }
            else if (e.KeyCode == Keys.NumLock && Control.IsKeyLocked(Keys.NumLock) == false)
            {
                lblNumLk.BackColor = SystemColors.Control;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            DateTime now = DateTime.Now;          
            lblclock.Text = now.Hour + ":" + now.Minute + ":" + now.Second;    // DateTime.Now.TimeOfDay.ToString();

        }

        private void toolStripDiscountCompaney_Click(object sender, EventArgs e)
        {
            try
            {
                frmCompanyDiscount frm = new frmCompanyDiscount();
                frmCompanyDiscount open = Application.OpenForms["frmCompanyDiscount"] as frmCompanyDiscount;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
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
                    Home = Convert.ToBoolean(SQLConn.dr["Home"].ToString());
                    Customers = Convert.ToBoolean(SQLConn.dr["Customers"].ToString());
                    Price = Convert.ToBoolean(SQLConn.dr["Price"].ToString());
                    Extentions = Convert.ToBoolean(SQLConn.dr["Extentions"].ToString());
                    Trsury = Convert.ToBoolean(SQLConn.dr["Trsury"].ToString());
                    Bankaccount = Convert.ToBoolean(SQLConn.dr["Bankaccount"].ToString());
                    Companydiscount = Convert.ToBoolean(SQLConn.dr["Companydiscount"].ToString());
                    Systemsetting = Convert.ToBoolean(SQLConn.dr["Systemsetting"].ToString());
                    Boats = Convert.ToBoolean(SQLConn.dr["Boats"].ToString());
                    Boattype = Convert.ToBoolean(SQLConn.dr["Boattype"].ToString());
                    Boatlist = Convert.ToBoolean(SQLConn.dr["Boatlist"].ToString());
                    Boatsort = Convert.ToBoolean(SQLConn.dr["Boatsort"].ToString());
                    Boatin = Convert.ToBoolean(SQLConn.dr["Boatin"].ToString());
                    Boatout = Convert.ToBoolean(SQLConn.dr["Boatout"].ToString());
                    Boatfix = Convert.ToBoolean(SQLConn.dr["Boatfix"].ToString());
                    Anchor = Convert.ToBoolean(SQLConn.dr["Anchor"].ToString());
                    Anchorpay = Convert.ToBoolean(SQLConn.dr["Anchorpay"].ToString());
                    Tickes = Convert.ToBoolean(SQLConn.dr["Tickes"].ToString());
                    Ticketlist = Convert.ToBoolean(SQLConn.dr["Ticketlist"].ToString());
                    //Ticketedit = Convert.ToBoolean(SQLConn.dr["Ticketedit"].ToString());
                    //Ticketdelete = Convert.ToBoolean(SQLConn.dr["Ticketdelete"].ToString());
                    Newticket = Convert.ToBoolean(SQLConn.dr["Newticket"].ToString());
                    Boatowner = Convert.ToBoolean(SQLConn.dr["Boatowner"].ToString());
                    Revenuse = Convert.ToBoolean(SQLConn.dr["Revenuse"].ToString());
                    Revenusetype = Convert.ToBoolean(SQLConn.dr["Revenusetype"].ToString());
                    Revenuselist = Convert.ToBoolean(SQLConn.dr["Revenuselist"].ToString());
                    Expences = Convert.ToBoolean(SQLConn.dr["Expences"].ToString());
                    Expencestype = Convert.ToBoolean(SQLConn.dr["Expencestype"].ToString());
                    Expenceslist = Convert.ToBoolean(SQLConn.dr["Expenceslist"].ToString());
                    Mony = Convert.ToBoolean(SQLConn.dr["Mony"].ToString());
                    FTTB = Convert.ToBoolean(SQLConn.dr["FTTB"].ToString());
                    FBTT = Convert.ToBoolean(SQLConn.dr["FBTT"].ToString());
                    Monrecive = Convert.ToBoolean(SQLConn.dr["Monrecive"].ToString());
                    Monrecivecashier = Convert.ToBoolean(SQLConn.dr["Monrecivecashier"].ToString());
                    Accountsreport = Convert.ToBoolean(SQLConn.dr["Accountsreport"].ToString());
                    Trsurep = Convert.ToBoolean(SQLConn.dr["Trsurep"].ToString());
                    Timeworkrep = Convert.ToBoolean(SQLConn.dr["Timeworkrep"].ToString());
                    Cashbalancerep = Convert.ToBoolean(SQLConn.dr["Cashbalancerep"].ToString());
                    Cashierreciverep = Convert.ToBoolean(SQLConn.dr["Cashierreciverep"].ToString());
                    Excepencesrep = Convert.ToBoolean(SQLConn.dr["Excepencesrep"].ToString());
                    Revenuserep = Convert.ToBoolean(SQLConn.dr["Revenuserep"].ToString());
                    Anchorpayrep = Convert.ToBoolean(SQLConn.dr["Anchorpayrep"].ToString());
                    Cashcomrep = Convert.ToBoolean(SQLConn.dr["Cashcomrep"].ToString());
                    Drivecomrep = Convert.ToBoolean(SQLConn.dr["Drivecomrep"].ToString());
                    Generalrep = Convert.ToBoolean(SQLConn.dr["Generalrep"].ToString());
                    Revenusetexrep = Convert.ToBoolean(SQLConn.dr["Revenusetexrep"].ToString());
                    Tickettaxrep = Convert.ToBoolean(SQLConn.dr["Tickettaxrep"].ToString());
                    Comboatoutrep = Convert.ToBoolean(SQLConn.dr["Comboatoutrep"].ToString());
                    Exceptaxrep = Convert.ToBoolean(SQLConn.dr["Exceptaxrep"].ToString());
                    Allanchorpayrep = Convert.ToBoolean(SQLConn.dr["Allanchorpayrep"].ToString());
                    Returnedrep = Convert.ToBoolean(SQLConn.dr["Returnedrep"].ToString());
                    Emploies = Convert.ToBoolean(SQLConn.dr["Emploies"].ToString());
                    Jobss = Convert.ToBoolean(SQLConn.dr["Jobs"].ToString());
                    Emplist = Convert.ToBoolean(SQLConn.dr["Emplist"].ToString());
                    Drivers = Convert.ToBoolean(SQLConn.dr["Drivers"].ToString());
                    Users = Convert.ToBoolean(SQLConn.dr["Users"].ToString());
                    Permessions = Convert.ToBoolean(SQLConn.dr["Permessions"].ToString());
                    Userlist = Convert.ToBoolean(SQLConn.dr["Userlist"].ToString());
                    Returned = Convert.ToBoolean(SQLConn.dr["Returned"].ToString());
                    Returnedlist = Convert.ToBoolean(SQLConn.dr["Returnedlist"].ToString());
                    Newreturned = Convert.ToBoolean(SQLConn.dr["Newreturned"].ToString());
                    CBBankaccount = Convert.ToBoolean(SQLConn.dr["CBBankaccount"].ToString());
                    Rents = Convert.ToBoolean(SQLConn.dr["Rents"].ToString());
                    NewRent = Convert.ToBoolean(SQLConn.dr["NewRent"].ToString());
                    Rentslist = Convert.ToBoolean(SQLConn.dr["Rentslist"].ToString());
                    Rentalrep = Convert.ToBoolean(SQLConn.dr["Rentalrep"].ToString());
                    Boatfixrep = Convert.ToBoolean(SQLConn.dr["Boatfixrep"].ToString());
                    if (Home)
                    {
                        الرئيسيةToolStripMenuItem.Visible = true;
                    }
                    if (Home)
                    {
                        ToolStripMenuItemClients.Visible = true;
                        //}
                        if (Home && Price)
                        {
                            ToolStripMenuItemPrice.Visible = true;
                        }
                        if (Home && Extentions)
                        {
                            ToolStripMenuItemAddon.Visible = true;
                        }
                        if (Home && Trsury)
                        {
                            toolStripMenuItemTreasury.Visible = true;
                        }
                        if (Home && Bankaccount)
                        {
                            toolStripMenuItemBankAccount.Visible = true;
                        }
                        if (Home && Companydiscount)
                        {
                            tsmDiscountCompaney.Visible = true;
                        }
                        if (Home && Systemsetting)
                        {
                            toolStripButton4.Visible = true;
                            ToolStripMenuItemٍٍSystemSettings.Visible = true;
                        }
                        if (Boats)
                        {
                            الوسائطالبحريةToolStripMenuItem.Visible = true;
                        }
                        if (Boats && Boattype)
                        {
                            ToolStripMenuItemSeaTrasportType.Visible = true;
                        }
                        if (Boats && Boatlist)
                        {
                            ToolStripMenuItemBoats.Visible = true;
                        }
                        if (Boats && Boatsort)
                        {
                            toolStripMenuItemٍSeaTransportOrder.Visible = true;
                        }
                        if (Boats && Boatin)
                        {
                            tsmInBoat.Visible = true;
                        }
                        if (Boats && Boatout)
                        {
                            tsmOutboat.Visible = true;
                        }
                        if (Boats && Boatfix)
                        {
                            tsmMaintenance.Visible = true;
                        }
                        if (Boats && Anchor)
                        {
                            tsmLanding.Visible = true;
                        }
                        if (Boats && Anchorpay)
                        {
                            دفوعاتالإرساءToolStripMenuItem.Visible = true;
                        }
                        if (Tickes)
                        {
                            التذاكرToolStripMenuItem.Visible = true;
                        }
                        if (Tickes && Ticketlist)
                        {
                            tsmTicket.Visible = true;
                        }
                        //if (Tickes && Ticketedit)
                        //{
                        //}
                        //if (Tickes && Ticketdelete)
                        //{

                        //}
                        if (Tickes && Newticket)
                        {
                            toolStripButton2.Visible = true;
                            ToolStripMenuItemNewTicket.Visible = true;
                        }
                        if (Tickes && Boatowner)
                        {
                            شباكاصحابالقواربToolStripMenuItem.Visible = true;
                        }
                        if (Rents)
                        {
                            الحجوزاتToolStripMenuItem.Visible = true;
                        }
                        if (Rents && NewRent)
                        {
                            حجزجديدToolStripMenuItem.Visible = true;
                        }
                        if (Rents && Rentslist)
                        {
                            قائمةالحجوزاتToolStripMenuItem.Visible = true;
                        }
                        if (Revenuse)
                        {
                            tsmIncome.Visible = true;
                        }
                        if (Revenuse && Revenusetype)
                        {
                            tsmIncomeType.Visible = true;
                        }
                        if (Revenuse && Revenuselist)
                        {
                            tsmIncomes.Visible = true;
                        }
                        if (Expences)
                        {
                            tsmExpenses.Visible = true;
                        }
                        if (Expences && Expencestype)
                        {
                            tsmExpenseType.Visible = true;
                        }
                        if (Expences && Expenceslist)
                        {
                            tsmExpensesList.Visible = true;
                        }
                        if (Mony)
                        {
                            tsmTransfertMoney.Visible = true;
                        }
                        if (Mony && FTTB)
                        {
                            tsmTransferTreasuryToBank.Visible = true;
                        }
                        if (Mony && FBTT)
                        {
                            tsmTransferBankToTreasury.Visible = true;
                        }
                        if (Monrecive)
                        {
                            tsmReceiveMoney.Visible = true;
                        }
                        if (Monrecive && Monrecivecashier)
                        {
                            tsmFrmIncomeFromCashier.Visible = true;
                        }
                        if (Accountsreport)
                        {
                            tsmReports.Visible = true;
                        }
                        if (Accountsreport && Trsurep)
                        {
                            tsmReportFilterTreasury.Visible = true;
                        }
                        if (Accountsreport && Rentalrep)
                        {
                            تقريرالحجوزاتToolStripMenuItem.Visible = true;
                        }
                        if (Accountsreport && Timeworkrep)
                        {
                            تقريرساعاتالتشغيلToolStripMenuItem.Visible = true;
                        }
                        if (Accountsreport && Cashbalancerep)
                        {
                            tlsmCashier.Visible = true;
                        }
                        if (Accountsreport && Cashierreciverep)
                        {
                            tsmReportIncomeFromCashier.Visible = true;
                        }
                        if (Accountsreport && Excepencesrep)
                        {
                            تقريرالمصروفاتToolStripMenuItem.Visible = true;
                        }
                        if (Accountsreport && Revenuserep)
                        {
                            تقريرالايراداتToolStripMenuItem.Visible = true;
                        }
                        if (Accountsreport && Anchorpayrep)
                        {
                            تقريردفوعاتالارساءاتلواسطةبحريةToolStripMenuItem.Visible = true;
                        }
                        if (Accountsreport && Cashcomrep)
                        {
                            toolStripMenuItem1.Visible = true;
                        }
                        if (Accountsreport && Drivecomrep)
                        {
                            TlsmDriverCommission.Visible = true;
                        }
                        if (Accountsreport && Generalrep)
                        {
                            TsmiGenerelaReport.Visible = true;
                        }
                        if (Accountsreport && Revenusetexrep)
                        {
                            التقريرالضريبيللايراداتToolStripMenuItem.Visible = true;
                        }
                        if (Accountsreport && Tickettaxrep)
                        {
                            التقريرالضريبيللتذاكرToolStripMenuItem.Visible = true;
                        }
                        if (Accountsreport && Comboatoutrep)
                        {
                            تقريرنسبالتشغيلالخارجيةToolStripMenuItem.Visible = true;
                        }
                        if (Accountsreport && Exceptaxrep)
                        {
                            Expvat.Visible = true;
                        }
                        if (Accountsreport && Allanchorpayrep)
                        {
                            تقريردفوعاتالإرساءToolStripMenuItem.Visible = true;
                        }
                        if (Accountsreport && Returnedrep)
                        {
                            تقريرالمرتجعاتToolStripMenuItem.Visible = true;
                        }
                        //Boatfixrep
                        if (Accountsreport && Boatfixrep)
                        {
                            تقريرصيانةقاربToolStripMenuItem.Visible = true;
                        }
                        if (Emploies)
                        {
                            tsmEmployeeList.Visible = true;
                        }
                        if (Emploies && Jobss)
                        {
                            Jobs.Visible = true;

                        }
                        if (Emploies && Emplist)
                        {
                            tsmEmployee.Visible = true;
                        }
                        if (Emploies && Drivers)
                        {
                            tsmDrivers.Visible = true;
                        }
                        if (Users)
                        {
                            toolStripButton3.Visible = true;
                            tsmUsersMenu.Visible = true;
                        }
                        if (Users && Permessions)
                        {
                            tsmRoles.Visible = true;
                        }
                        if (Users && Userlist)
                        {
                            tsmUsers.Visible = true;
                        }
                        if (Returned)
                        {
                            toolStripMenuItem2.Visible = true;
                        }
                        if (Returned && Returnedlist)
                        {
                            قائمةالمرتجعاتToolStripMenuItem.Visible = true;
                        }
                        if (Returned && Newreturned)
                        {
                            انشاءمرتجعToolStripMenuItem.Visible = true;
                        }
                        if (CBBankaccount)
                        {
                            تقريرالحساباتالبنكيةToolStripMenuItem.Visible = true;
                        }
                    }
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
        private void frmmdi_Load(object sender, EventArgs e)
        {
            GetPerid();
            //if ((int)SQLConn.Role.Cashier == Data.RoleID)
            //{
            //    الرئيسيةToolStripMenuItem.Visible = false;
            //    الوسائطالبحريةToolStripMenuItem.Visible = false;
            //    tsmIncome.Visible = false;
            //    tsmExpenses.Visible = false;
            //    tsmTransfertMoney.Visible = false;
            //    tsmReceiveMoney.Visible = false;
            //    tsmReports.Visible = false;
            //    tsmEmployeeList.Visible = false;
            //    tsmUsersMenu.Visible = false;
            //    toolStripMenuItem2.Visible = false;
            //}
            toolStripTextBox1.Text = Data.UserName;
            lblUserName.Text = Data.UserName;
            lblRoleName.Text = Data.Role;
            ////Check if CapsLk Or NumLock Clicked
            //if (Control.IsKeyLocked(Keys.CapsLock))
            //{
            //    lblCapsLk.BackColor = Color.Aqua;
            //}
            //else
            //{
            //    lblCapsLk.BackColor = SystemColors.Control;
            //}

            //if (Control.IsKeyLocked(Keys.NumLock))
            //{
            //    lblNumLk.BackColor = Color.Aqua;
            //}
            //else
            //{
            //    lblNumLk.BackColor = SystemColors.Control;
            //}

            //timer1.Enabled = true;
            //timer1.Interval = 1000;

            //if (((int)SQLConn.Role.Comptable == Data.RoleID)|| ((int)SQLConn.Role.AdminSys == Data.RoleID))
            //{
            //    tsmReports.Visible = true;
            //    tsmReceiveMoney.Visible = true;
            //    tsmTransfertMoney.Visible = true;                
            //}
            //else
            //{
            //    tsmReports.Visible = false;
            //    tsmReceiveMoney.Visible = false;
            //    tsmTransfertMoney.Visible = false;                
            //}
        }
        private void قائمةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmExpenses
            try
            {
                frmExpenses frm = new frmExpenses();
                frmExpenses open = Application.OpenForms["frmExpenses"] as frmExpenses;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tsmTickets_Click(object sender, EventArgs e)
        {
            try
            {
                //FrmTickets frm = new FrmTickets();
                //FrmTickets open = Application.OpenForms["FrmTickets"] as FrmTickets;
                //if (open == null)
                //{
                //    frm.MdiParent = this;
                //    frm.Show();
                //}
                //else
                //{
                //    open.Activate();
                //    if (open.WindowState == FormWindowState.Minimized)
                //    {
                //        open.WindowState = FormWindowState.Normal;
                //    }
                //}

                FrmTickets FrmTickets = Application.OpenForms["FrmTickets"] as FrmTickets;
                if (FrmTickets != null)
                {
                    FrmTickets.WindowState = FormWindowState.Normal;
                    FrmTickets.BringToFront();
                    FrmTickets.Activate();
                }
                else
                {
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                    FrmTickets = new FrmTickets
                    {
                        MdiParent = this,
                        Dock = DockStyle.Fill
                    };
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                    FrmTickets.Show();
                }

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void الخزائنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmtreasury frm = new frmtreasury();
                frmtreasury open = Application.OpenForms["frmtreasury"] as frmtreasury;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void الإرساءاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (((int)SQLConn.Role.AdminSys != Data.RoleID) && ((int)SQLConn.Role.Comptable != Data.RoleID))
            //{
            //    // msg
            //    Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية محاسب أو مدير النظام  ");
            //    return;
            //}

            try
            {
                frmlanding frm = new frmlanding();
                frmlanding open = Application.OpenForms["frmlanding"] as frmlanding;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void تقريرالخزينةToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void تقريرساعاتالتشغيلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //frminboat
            try
            {
                frminboat frm = new frminboat();
                frminboat open = Application.OpenForms["frminboat"] as frminboat;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //frmoutboat
            try
            {
                frmoutboat frm = new frmoutboat();
                frmoutboat open = Application.OpenForms["frmoutboat"] as frmoutboat;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void صيانةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMaintenance
            try
            {
                frmMaintenance frm = new frmMaintenance();
                frmMaintenance open = Application.OpenForms["frmMaintenance"] as frmMaintenance;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void نوعالإيرادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmIncomeType
            try
            {
                frmIncomeType frm = new frmIncomeType();
                frmIncomeType open = Application.OpenForms["frmIncomeType"] as frmIncomeType;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tsmIncomes_Click(object sender, EventArgs e)
        {
            //frmIncome
            try
            {
                frmIncome frm = new frmIncome();
                frmIncome open = Application.OpenForms["frmIncome"] as frmIncome;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tsmExpenseType_Click(object sender, EventArgs e)
        {
            //frmExpensesType
            try
            {
                frmExpensesType frm = new frmExpensesType();
                frmExpensesType open = Application.OpenForms["frmExpensesType"] as frmExpensesType;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tsmTransferTreasuryToBank_Click(object sender, EventArgs e)
        {
            //frmTransferTreasuryToBank
            try
            {
                frmTransferTreasuryToBank frm = new frmTransferTreasuryToBank();
                frmTransferTreasuryToBank open = Application.OpenForms["frmTransferTreasuryToBank"] as frmTransferTreasuryToBank;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }

        }
        private void tsmTransferBankToTreasury_Click(object sender, EventArgs e)
        {
            //frmTransferBankToTreasury
            try
            {
                frmTransferBankToTreasury frm = new frmTransferBankToTreasury();
                frmTransferBankToTreasury open = Application.OpenForms["frmTransferBankToTreasury"] as frmTransferBankToTreasury;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tsmPriceGroupList_Click(object sender, EventArgs e)
        {
            try
            {
                frmpricegroup frm = new frmpricegroup();
                frmpricegroup open = Application.OpenForms["frmpricegroup"] as frmpricegroup;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void tsmPriceDetails_Click(object sender, EventArgs e)
        {
            try
            {
                frmprice frm = new frmprice();
                frmprice open = Application.OpenForms["frmprice"] as frmprice;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
                

        private void التقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmReportFilterTreasury_Click(object sender, EventArgs e)
        {
            //frmReportFilterTreasury
            try
            {
                frmReportFilterTreasury frm = new frmReportFilterTreasury();
                frmReportFilterTreasury open = Application.OpenForms["frmReportFilterTreasury"] as frmReportFilterTreasury;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void تقريرساعاتالتشغيلToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //frmReportFilterWorkingHours
            try
            {
                frmReportFilterWorkingHours frm = new frmReportFilterWorkingHours();
                frmReportFilterWorkingHours open = Application.OpenForms["frmReportFilterWorkingHours"] as frmReportFilterWorkingHours;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tlsCashier_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportCashier frm = new frmReportCashier();
                frmReportCashier open = Application.OpenForms["frmReportCashier"] as frmReportCashier;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tsmReportIncomeFromCashier_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportIncomeFromCashier frm = new frmReportIncomeFromCashier();
                frmReportIncomeFromCashier open = Application.OpenForms["frmReportIncomeFromCashier"] as frmReportIncomeFromCashier;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tsmFrmIncomeFromCashier_Click(object sender, EventArgs e)
        {
            try
            {
                frmIncomeFromCashier frm = new frmIncomeFromCashier();
                frmIncomeFromCashier open = Application.OpenForms["frmIncomeFromCashier"] as frmIncomeFromCashier;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void frmmdi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void tsmReportExpenses_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportFilterExpenses frm = new frmReportFilterExpenses();
                frmReportFilterExpenses open = Application.OpenForms["frmReportFilterExpenses"] as frmReportFilterExpenses;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tsmReportIncome_Click(object sender, EventArgs e)
        {
            //frmReportFilterIncome
            try
            {
                frmReportFilterIncome frm = new frmReportFilterIncome();
                frmReportFilterIncome open = Application.OpenForms["frmReportFilterIncome"] as frmReportFilterIncome;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void TSMILandingPayment_Click(object sender, EventArgs e)
        {
            //if (((int)SQLConn.Role.AdminSys != Data.RoleID) && ((int)SQLConn.Role.Comptable != Data.RoleID))
            //{
            //    // msg
            //    Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية محاسب أو مدير النظام  ");
            //    return;
            //}
            try
            {
                frmLandingPayment frm = new frmLandingPayment();
                frmLandingPayment open = Application.OpenForms["frmLandingPayment"] as frmLandingPayment;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tlsLandingPayment_Click(object sender, EventArgs e)
        {
            //if (((int)SQLConn.Role.AdminSys != Data.RoleID) && ((int)SQLConn.Role.Comptable != Data.RoleID))
            //{
            //    // msg
            //    Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية محاسب أو مدير النظام  ");
            //    return;
            //}
            try
            {
                MPM frm = new MPM();
                MPM open = Application.OpenForms["MPM"] as MPM;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportCashierCommission frm = new frmReportCashierCommission();
                frmReportCashierCommission open = Application.OpenForms["frmReportCashierCommission"] as frmReportCashierCommission;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void TlsmDriverCommission_Click(object sender, EventArgs e)
        {
            //تقرير عمولة السائق
            try
            {
                frmReportDriverCommission frm = new frmReportDriverCommission();
                frmReportDriverCommission open = Application.OpenForms["frmReportDriverCommission"] as frmReportDriverCommission;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void TsmiGenerelaReport_Click(object sender, EventArgs e)
        {
            //frmReportGeneral
            try
            {
                frmReportGeneral frm = new frmReportGeneral();
                frmReportGeneral open = Application.OpenForms["frmReportGeneral"] as frmReportGeneral;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void tsmExpenses_Click(object sender, EventArgs e)
        {

        }
        private void Expvat_Click(object sender, EventArgs e)
        {
            //if (((int)SQLConn.Role.AdminSys != Data.RoleID) && ((int)SQLConn.Role.Comptable != Data.RoleID))
            //{
            //    // msg
            //    Interaction.MsgBox("لا يمكن فتح هذه الشاشة الا  للمستخدمين الذين يتمتعون بصلاحية محاسب أو مدير النظام  ");
            //    return;
            //}

            try
            {
                FrmRepExpenses FRE = new FrmRepExpenses();
                FrmRepExpenses open = Application.OpenForms["FRE"] as FrmRepExpenses;
                if (open == null)
                {
                    FRE.MdiParent = this;
                    FRE.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void التقريرالضريبيللتذاكرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                try
            {
                FrmRepTicketsvat frm = new FrmRepTicketsvat();
                FrmRepTicketsvat open = Application.OpenForms["FrmRepTicketsvat"] as FrmRepTicketsvat;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void تقريردفوعاتالارساءاتلواسطةبحريةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportFilterLandingPayment frm = new frmReportFilterLandingPayment();
                frmReportFilterLandingPayment open = Application.OpenForms["frmReportFilterLandingPayment"] as frmReportFilterLandingPayment;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void التقريرالضريبيللايراداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRepIncom FRI = new FrmRepIncom();
                FrmRepIncom open = Application.OpenForms["FRI"] as FrmRepIncom;
                if (open == null)
                {
                    FRI.MdiParent = this;
                    FRI.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void تقريرنسبالتشغيلالخارجيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmExratios FER = new FrmExratios();
                FrmExratios open = Application.OpenForms["FER"] as FrmExratios;
                if (open == null)
                {
                    FER.MdiParent = this;
                    FER.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void Jobs_Click(object sender, EventArgs e)
        {
            try
            {
                Jobs frmjob = new Jobs();
                Jobs open = Application.OpenForms["frmjob"] as Jobs;
                if (open == null)
                {
                    frmjob.MdiParent = this;
                    frmjob.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {

        }
        private void انشاءمرتجعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Returnedform RF = new Returnedform();
            Returnedform open = Application.OpenForms["RF"] as Returnedform;
            if (open == null)
            {
                RF.MdiParent = this;
                RF.Show();
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

        private void قائمةالمرتجعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Returnedlist RL = new Returnedlist();
            Returnedlist open = Application.OpenForms["RL"] as Returnedlist;
            if (open == null)
            {
                RL.MdiParent = this;
                RL.Show();
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

        private void تقريرالمرتجعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SFR SForm = new SFR();
            SForm.ShowDialog();
        }

        private void شاشةالصلاحياتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void شباكاصحابالقواربToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Boatowners Boatowners = Application.OpenForms["Boatowners"] as Boatowners;
            if (Boatowners != null)
            {
                Boatowners.WindowState = FormWindowState.Normal;
                Boatowners.BringToFront();
                Boatowners.Activate();
            }
            else
            {
                Boatowners = new Boatowners
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                Boatowners.Show();
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void تقريرصيانةقاربToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoatfixReport BFR = new BoatfixReport();
            BFR.Show();
        }

        private void تقريرالحساباتالبنكيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportFilterbank frm = new frmReportFilterbank();
                frmReportFilterbank open = Application.OpenForms["frmReportFilterbank"] as frmReportFilterbank;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void حجزجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Newrent Newrent = Application.OpenForms["Newrent"] as Newrent;
            if (Newrent != null)
            {
                Newrent.WindowState = FormWindowState.Normal;
                Newrent.BringToFront();
                Newrent.Activate();
            }
            else
            {
                Newrent = new Newrent
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                Newrent.Show();
            }
            //try
            //{
            //    Newrent frmrent = new Newrent(); 
            //    frmrent.MdiParent = this;
            //    frmrent.Show();

            //    //Newrent open = Application.OpenForms["frmrent"] as Newrent;
            //    //if (open == null)
            //    //{
            //    //    frmrent.MdiParent = this;
            //    //    frmrent.WindowState = FormWindowState.Maximized;
            //    //    frmrent.Show();
            //    //}
            //    //else
            //    //{
            //    //    open.Activate();
            //    //    if (open.WindowState == FormWindowState.Minimized)
            //    //    {
            //    //        open.WindowState = FormWindowState.Maximized;
            //    //    }
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    Interaction.MsgBox(ex.ToString());
            //}
        }

        private void قائمةالحجوزاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Rentlist frmrlist = new Rentlist();
                Rentlist open = Application.OpenForms["frmrlist"] as Rentlist;
                if (open == null)
                {
                    frmrlist.MdiParent = this;
                    frmrlist.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void تقريرالحجوزاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportFilterRental frm = new frmReportFilterRental();
                frmReportFilterRental open = Application.OpenForms["frmReportFilterRental"] as frmReportFilterRental;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void Transfiermony_Click(object sender, EventArgs e)
        {
            //frmTransfertreasurytotreasury
            try
            {
                frmTransfertreasurytotreasury frm = new frmTransfertreasurytotreasury();
                frmTransfertreasurytotreasury open = Application.OpenForms["frmTransfertreasurytotreasury"] as frmTransfertreasurytotreasury;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void تقريرالتذاكرالمدفوعهبواسطةتماراToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tamarafilter frm = new Tamarafilter();
                Tamarafilter open = Application.OpenForms["Tamarafilter"] as Tamarafilter;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void تقريرالتذاكرالمدفوعهبواسطةالتحويلالبنكيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Paytransfilter frm = new Paytransfilter();
                Paytransfilter open = Application.OpenForms["Paytransfilter"] as Paytransfilter;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
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
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
    }
}
