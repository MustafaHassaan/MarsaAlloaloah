using MarsaAlloaloah.FrmReports;
using MarsaAlloaloah.Utility.Ado.net;
using Microsoft.VisualBasic;
using SmartArabXLSX.Bibliography;
using SmartArabXLSX.EMMA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarsaAlloaloah.Forms
{
    public partial class Roles : Form
    {
        public Roles()
        {
            InitializeComponent();
        }
        public int Userid { get; set; }
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
           public bool Jobs { get; set; }
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

        List<String> CheckedNames(TreeNodeCollection theNodes)
        {
            List<String> aResult = new List<String>();

            if (theNodes != null)
            {
                foreach (TreeNode aNode in theNodes)
                {
                    if (aNode.Checked)
                    {
                        aResult.Add(aNode.Text);
                    }

                    aResult.AddRange(CheckedNames(aNode.Nodes));
                }
            }

            return aResult;
        }
        private void AddRole()
        {
            var Gettree = CheckedNames(Treerole.Nodes);
            for (int i = 0; i < Gettree.Count; i++)
            {
                var TN = Gettree[i].ToString();
                if (TN == "الرئيسية")
                {
                    Home = true;
                }
                    if (TN == "العملاء")
                    {
                        Customers = true;
                    }
                    if (TN == "التسعير")
                    {
                        Price = true;
                    }
                    if (TN == "الاضافات")
                    {
                        Extentions = true;
                    }
                    if (TN == "الخزائن")
                    {
                        Trsury = true;
                    }
                    if (TN == "الحسابات البنكية")
                    {
                        Bankaccount = true;
                    }
                    if (TN == "خصومات الشركات")
                    {
                        Companydiscount = true;
                    }
                    if (TN == "اعدادات النظام")
                    {
                        Systemsetting = true;
                    }

                if (TN == "الوسائط البحرية")
                {
                    Boats = true;
                }
                    if (TN == "نوع الواسطة البحرية")
                    {
                        Boattype = true;
                    }
                    if (TN == "الوسائط البحرية")
                    {
                        Boatlist = true;
                    }
                    if (TN == "ترتيب سير الوسائط البحرية")
                    {
                        Boatsort = true;
                    }
                    if (TN == "دخول واسطة بحرية")
                    {
                        Boatin = true;
                    }
                    if (TN == "خروج واسطة بحرية")
                    {
                        Boatout = true;
                    }
                    if (TN == "كارت صيانة")
                    {
                        Boatfix = true;
                    }
                    if (TN == "الارساءات")
                    {
                        Anchor = true;
                    }
                    if (TN == "دفوعات الارساءات")
                    {
                        Anchorpay = true;
                    }

                if (TN == "التذاكر")
                {
                    Tickes = true;
                }
                    if (TN == "قائمة التذاكر")
                    {
                        Ticketlist = true;
                    }
                        if (TN == "تعديل تذكرة")
                        {
                            Ticketedit = true;
                        }
                        if (TN == "حذف تذكرة")
                        {
                            Ticketdelete = true;
                        }
                    if (TN == "تذكرة جديدة")
                    {
                        Newticket = true;
                    }
                    if (TN == "شباك اصحاب القوارب")
                    {
                        Boatowner = true;
                    }
                if (TN == "الحجوزات")
                {
                    Rents = true;
                }
                    if (TN == "حجز جديد")
                    {
                        NewRent = true;
                    }
                    if (TN == "قائمة الحجوزات")
                    {
                        Rentslist = true;
                    }
                if (TN == "الايرادات")
                {
                    Revenuse = true;
                }
                    if (TN == "نوع الايراد")
                    {
                        Revenusetype = true;
                    }
                    if (TN == "قائمة الايرادات")
                    {
                        Revenuselist = true;
                    }

                if (TN == "المصروفات")
                {
                    Expences = true;
                }
                    if (TN == "نوع المصروف")
                    {
                        Expencestype = true;
                    }
                    if (TN == "قائمة المصروفات")
                    {
                        Expenceslist = true;
                    }

                if (TN == "تحويل الاموال")
                {
                    Mony = true;
                }
                    if (TN == "من الخزينة الى البنك")
                    {
                        FTTB = true;
                    }
                    if (TN == "من البنك الى الخزينة")
                    {
                        FBTT = true;
                    }

                if (TN == "استلام الاموال")
                {
                    Monrecive = true;
                }
                    if (TN == "استلام الاموال من الكاشير")
                    {
                        Monrecivecashier = true;
                    }

                if (TN == "التقارير المحاسبية")
                {
                    Accountsreport = true;
                }
                    if (TN == "تقرير الخزينة")
                    {
                       Trsurep  = true;
                    }
                    if (TN == "تقرير الحجوزات")
                    {
                        Rentalrep = true;
                    }
                    if (TN == "تقرير الحسابات البنكية")
                    {
                        Bankaccount = true;
                    }
                    if (TN == "تقرير ساعات التشغيل")
                    {
                        Timeworkrep = true;
                    }
                    if (TN == "تقرير رصيد الكاشير")
                    {
                        Cashbalancerep = true;
                    }
                    if (TN == "تقرير استلام الكاشير")
                    {
                        Cashierreciverep = true;
                    }
                    if (TN == "تقرير المصروفات")
                    {
                        Excepencesrep = true;
                    }
                    if (TN == "تقرير الايرادات")
                    {
                        Revenuserep = true;
                    }
                    if (TN == "تقرير دفوعات الارساءات لواسطة بحرية")
                    {
                        Anchorpayrep = true;
                    }
                    if (TN == "تقرير عمولة الكاشير")
                    {
                        Cashcomrep = true;
                    }
                    if (TN == "تقرير عمولة السائق")
                    {
                        Drivecomrep = true;
                    }
                    if (TN == "التقرير الشامل")
                    {
                        Generalrep = true;
                    }
                    if (TN == "التقرير الضريبي للايرادات")
                    {
                        Revenusetexrep = true;
                    }
                    if (TN == "التقرير الضريبي للتذاكر")
                    {
                        Tickettaxrep = true;
                    }
                    if (TN == "تقرير نسب التشغيل الخارجية")
                    {
                        Comboatoutrep = true;
                    }
                    if (TN == "تقرير المصروفات الضريبي")
                    {
                        Exceptaxrep = true;
                    }
                    if (TN == "تقرير دفوعات الارساء لجميع الوسائط البحرية")
                    {
                        Allanchorpayrep = true;
                    }
                    if (TN == "تقرير المرتجعات")
                    {
                        Returnedrep = true;
                    }
                    if (TN == "تقرير صيانة قارب")
                    {
                        Boatfixrep = true;
                    }

                if (TN == "الموظفين")
                {
                    Emploies = true;
                }
                    if (TN == "الوظائف")
                    {
                        Jobs = true;
                    }
                    if (TN == "الموظفين")
                    {
                        Emplist = true;
                    }
                    if (TN == "السائقين")
                    {
                        Drivers = true;
                    }

                if (TN == "المستخدمين")
                {
                    Users = true;
                }
                    if (TN == "الصلاحيات")
                    {
                        Permessions = true;
                    }
                    if (TN == "المستخدمين")
                    {
                        Userlist = true;
                    }

                if (TN == "المرتجعات")
                {
                    Returned = true;
                }
                    if (TN == "قائمة المرتجعات")
                    {
                        Returnedlist = true;
                    }
                    if (TN == "انشاء مرتجع")
                    {
                        Newreturned = true;
                    }
            }
            try
            {
                SQLConn.sqL = "INSERT INTO Rolesper(" +
                    "Userid," +
                    "Home," +
                    "Customers," +
                    "Price," +
                    "Extentions," +
                    "Trsury," +
                    "Bankaccount," +
                    "Companydiscount," +
                    "Systemsetting," +
                    "Boats," +
                    "Boattype," +
                    "Boatlist," +
                    "Boatsort," +
                    "Boatin," +
                    "Boatout," +
                    "Boatfix," +
                    "Anchor," +
                    "Anchorpay," +
                    "Tickes," +
                    "Ticketlist," +
                    "Ticketedit," +
                    "Ticketdelete," +
                    "Newticket," +
                    "Boatowner," +
                    "Revenuse," +
                    "Revenusetype," +
                    "Revenuselist," +
                    "Expences," +
                    "Expencestype," +
                    "Expenceslist," +
                    "Mony," +
                    "FTTB," +
                    "FBTT," +
                    "Monrecive," +
                    "Monrecivecashier," +
                    "Accountsreport," +
                    "Trsurep," +
                    "Timeworkrep," +
                    "Cashbalancerep," +
                    "Cashierreciverep," +
                    "Excepencesrep," +
                    "Revenuserep," +
                    "Anchorpayrep," +
                    "Cashcomrep," +
                    "Drivecomrep," +
                    "Generalrep," +
                    "Revenusetexrep," +
                    "Tickettaxrep," +
                    "Comboatoutrep," +
                    "Exceptaxrep," +
                    "Allanchorpayrep," +
                    "Returnedrep," +
                    "Emploies," +
                    "Jobs," +
                    "Drivers," +
                    "Emplist," +
                    "Users," +
                    "Permessions," +
                    "Userlist," +
                    "Returned," +
                    "Returnedlist," +
                    "Newreturned," +
                    "CBBankaccount," +
                    "Rents," +
                    "NewRent," +
                    "Rentslist," +
                    "Rentalrep," +
                    "Boatfixrep" +
                    ") " +
                    "VALUES(" +
                    "'" + Userid + "'," +
                    "'" + Home + "'," +
                    "'" + Customers + "'," +
                    "'" + Price + "'," +
                    "'" + Extentions + "'," +
                    "'" + Trsury + "'," +
                    "'" + Bankaccount + "'," +
                    "'" + Companydiscount + "'," +
                    "'" + Systemsetting + "'," +
                    "'" + Boats + "'," +
                    "'" + Boattype + "'," +
                    "'" + Boatlist + "'," +
                    "'" + Boatsort + "'," +
                    "'" + Boatin + "'," +
                    "'" + Boatout + "'," +
                    "'" + Boatfix + "'," +
                    "'" + Anchor + "'," +
                    "'" + Anchorpay + "'," +
                    "'" + Tickes + "'," +
                    "'" + Ticketlist + "'," +
                    "'" + Ticketedit + "'," +
                    "'" + Ticketdelete + "'," +
                    "'" + Newticket + "'," +
                    "'" + Boatowner + "'," +
                    "'" + Revenuse + "'," +
                    "'" + Revenusetype + "'," +
                    "'" + Revenuselist + "'," +
                    "'" + Expences + "'," +
                    "'" + Expencestype + "'," +
                    "'" + Expenceslist + "'," +
                    "'" + Mony + "'," +
                    "'" + FTTB + "'," +
                    "'" + FBTT + "'," +
                    "'" + Monrecive + "'," +
                    "'" + Monrecivecashier + "'," +
                    "'" + Accountsreport + "'," +
                    "'" + Trsurep + "'," +
                    "'" + Timeworkrep + "'," +
                    "'" + Cashbalancerep + "'," +
                    "'" + Cashierreciverep + "'," +
                    "'" + Excepencesrep + "'," +
                    "'" + Revenuserep + "'," +
                    "'" + Anchorpayrep + "'," +
                    "'" + Cashcomrep + "'," +
                    "'" + Drivecomrep + "'," +
                    "'" + Generalrep + "'," +
                    "'" + Revenusetexrep + "'," +
                    "'" + Tickettaxrep + "'," +
                    "'" + Comboatoutrep + "'," +
                    "'" + Exceptaxrep + "'," +
                    "'" + Allanchorpayrep + "'," +
                    "'" + Returnedrep + "'," +
                    "'" + Emploies + "'," +
                    "'" + Jobs + "'," +
                    "'" + Drivers + "'," +
                    "'" + Emplist + "'," +
                    "'" + Users + "'," +
                    "'" + Permessions + "'," +
                    "'" + Userlist + "'," +
                    "'" + Returned + "'," +
                    "'" + Returnedlist + "'," +
                    "'" + Newreturned + "'," +
                    "'" + Bankaccount + "'," +
                    "'" + Rents + "'," +
                    "'" + NewRent + "'," +
                    "'" + Rentslist + "'," +
                    "'" + Rentalrep + "'," +
                    "'" + Boatfixrep + "'" +
                    ")";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم حفظ بيانات الصلاحية.", MsgBoxStyle.Information, "اضافة صلاحية");

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
        private void UpdateRole()
        {
            try
            {
                Rolesservices RS = new Rolesservices();
                var Gettree = CheckedNames(Treerole.Nodes);
                for (int i = 0; i < Gettree.Count; i++)
                {
                    var TN = Gettree[i].ToString();
                    if (TN == "الرئيسية")
                    {
                        Home = true;
                        RS.Home = true;
                    }
                    if (TN == "العملاء")
                    {
                        Customers = true;
                        RS.Customers = true;
                    }
                    if (TN == "التسعير")
                    {
                        Price = true;
                        RS.Price = true;
                    }
                    if (TN == "الاضافات")
                    {
                        Extentions = true;
                        RS.Extentions = true;
                    }
                    if (TN == "الخزائن")
                    {
                        Trsury = true;
                        RS.Trsury = true;
                    }
                    if (TN == "الحسابات البنكية")
                    {
                        Bankaccount = true;
                        RS.Bankaccount = true;
                    }
                    if (TN == "خصومات الشركات")
                    {
                        Companydiscount = true;
                        RS.Companydiscount = true;
                    }
                    if (TN == "اعدادات النظام")
                    {
                        Systemsetting = true;
                        RS.Systemsetting = true;

                    }
                    if (TN == "الوسائط البحرية")
                    {
                        Boats = true;
                        RS.Boats = true;

                    }
                    if (TN == "نوع الواسطة البحرية")
                    {
                        Boattype = true;
                        RS.Boattype = true;

                    }
                    if (TN == "الوسائط البحرية")
                    {
                        Boatlist = true;
                        RS.Boatlist = true;

                    }
                    if (TN == "ترتيب سير الوسائط البحرية")
                    {
                        Boatsort = true;
                        RS.Boatsort = true;

                    }
                    if (TN == "دخول واسطة بحرية")
                    {
                        Boatin = true;
                        RS.Boatin = true;

                    }
                    if (TN == "خروج واسطة بحرية")
                    {
                        Boatout = true;
                        RS.Boatout = true;

                    }
                    if (TN == "كارت صيانة")
                    {
                        Boatfix = true;
                        RS.Boatfix = true;

                    }
                    if (TN == "الارساءات")
                    {
                        Anchor = true;
                        RS.Anchor = true;

                    }
                    if (TN == "دفوعات الارساءات")
                    {
                        Anchorpay = true;
                        RS.Anchorpay = true;

                    }

                    if (TN == "التذاكر")
                    {
                        Tickes = true;
                        RS.Tickes = true;

                    }
                    if (TN == "قائمة التذاكر")
                    {
                        Ticketlist = true;
                        RS.Ticketlist = true;

                    }
                    if (TN == "تعديل تذكرة")
                    {
                        Ticketedit = true;
                        RS.Ticketedit = true;

                    }
                    if (TN == "حذف تذكرة")
                    {
                        Ticketdelete = true;
                        RS.Ticketdelete = true;

                    }
                    if (TN == "تذكرة جديدة")
                    {
                        Newticket = true;
                        RS.Newticket = true;

                    }
                    if (TN == "شباك اصحاب القوارب")
                    {
                        Boatowner = true;
                        RS.Boatowner = true;

                    }
                    if (TN == "الحجوزات")
                    {
                        Rents = true;
                        RS.Rents = true;

                    }
                    if (TN == "حجز جديد")
                    {
                        NewRent = true;
                        RS.NewRent = true;

                    }
                    if (TN == "قائمة الحجوزات")
                    {
                        Rentslist = true;
                        RS.Rentslist = true;

                    }
                    if (TN == "الايرادات")
                    {
                        Revenuse = true;
                        RS.Revenuse = true;

                    }
                    if (TN == "نوع الايراد")
                    {
                        Revenusetype = true;
                        RS.Revenusetype = true;

                    }
                    if (TN == "قائمة الايرادات")
                    {
                        Revenuselist = true;
                        RS.Revenuselist = true;

                    }

                    if (TN == "المصروفات")
                    {
                        Expences = true;
                        RS.Expences = true;

                    }
                    if (TN == "نوع المصروف")
                    {
                        Expencestype = true;
                        RS.Expencestype = true;

                    }
                    if (TN == "قائمة المصروفات")
                    {
                        Expenceslist = true;
                        RS.Expenceslist = true;

                    }

                    if (TN == "تحويل الاموال")
                    {
                        Mony = true;
                        RS.Mony = true;

                    }
                    if (TN == "من الخزينة الى البنك")
                    {
                        FTTB = true;
                        RS.FTTB = true;

                    }
                    if (TN == "من البنك الى الخزينة")
                    {
                        FBTT = true;
                        RS.FBTT = true;

                    }

                    if (TN == "استلام الاموال")
                    {
                        Monrecive = true;
                        RS.Monrecive = true;

                    }
                    if (TN == "استلام الاموال من الكاشير")
                    {
                        Monrecivecashier = true;
                        RS.Monrecivecashier = true;

                    }

                    if (TN == "التقارير المحاسبية")
                    {
                        Accountsreport = true;
                        RS.Accountsreport = true;

                    }
                    if (TN == "تقرير الخزينة")
                    {
                        Trsurep = true;
                        RS.Trsurep = true;

                    }
                    if (TN == "تقرير الحجوزات")
                    {
                        Rentalrep = true;
                        RS.Rentalrep = true;

                    }
                    if (TN == "تقرير الحسابات البنكية")
                    {
                        Bankaccount = true;
                        RS.Bankaccount = true;

                    }
                    if (TN == "تقرير ساعات التشغيل")
                    {
                        Timeworkrep = true;
                        RS.Timeworkrep = true;

                    }
                    if (TN == "تقرير رصيد الكاشير")
                    {
                        Cashbalancerep = true;
                        RS.Cashbalancerep = true;

                    }
                    if (TN == "تقرير استلام الكاشير")
                    {
                        Cashierreciverep = true;
                        RS.Cashierreciverep = true;

                    }
                    if (TN == "تقرير المصروفات")
                    {
                        Excepencesrep = true;
                        RS.Excepencesrep = true;

                    }
                    if (TN == "تقرير الايرادات")
                    {
                        Revenuserep = true;
                        RS.Revenuserep = true;

                    }
                    if (TN == "تقرير دفوعات الارساءات لواسطة بحرية")
                    {
                        Anchorpayrep = true;
                        RS.Anchorpayrep = true;

                    }
                    if (TN == "تقرير عمولة الكاشير")
                    {
                        Cashcomrep = true;
                        RS.Cashcomrep = true;

                    }
                    if (TN == "تقرير عمولة السائق")
                    {
                        Drivecomrep = true;
                        RS.Drivecomrep = true;

                    }
                    if (TN == "التقرير الشامل")
                    {
                        Generalrep = true;
                        RS.Generalrep = true;

                    }
                    if (TN == "التقرير الضريبي للايرادات")
                    {
                        Revenusetexrep = true;
                        RS.Revenusetexrep = true;

                    }
                    if (TN == "التقرير الضريبي للتذاكر")
                    {
                        Tickettaxrep = true;
                        RS.Tickettaxrep = true;

                    }
                    if (TN == "تقرير نسب التشغيل الخارجية")
                    {
                        Comboatoutrep = true;
                        RS.Comboatoutrep = true;

                    }
                    if (TN == "تقرير المصروفات الضريبي")
                    {
                        Exceptaxrep = true;
                        RS.Exceptaxrep = true;

                    }
                    if (TN == "تقرير دفوعات الارساء لجميع الوسائط البحرية")
                    {
                        Allanchorpayrep = true;
                        RS.Allanchorpayrep = true;

                    }
                    if (TN == "تقرير المرتجعات")
                    {
                        Returnedrep = true;
                        RS.Returnedrep = true;

                    }
                    if (TN == "تقرير صيانة قارب")
                    {
                        Boatfixrep = true;
                        RS.Boatfixrep = true;
                    }
                    if (TN == "الموظفين")
                    {
                        Emploies = true;
                        RS.Emploies = true;

                    }
                    if (TN == "الوظائف")
                    {
                        Jobs = true;
                        RS.Jobs = true;

                    }
                    if (TN == "الموظفين")
                    {
                        Emplist = true;
                        RS.Emplist = true;

                    }
                    if (TN == "السائقين")
                    {
                        Drivers = true;
                        RS.Drivers = true;

                    }

                    if (TN == "المستخدمين")
                    {
                        Users = true;
                        RS.Users = true;

                    }
                    if (TN == "الصلاحيات")
                    {
                        Permessions = true;
                        RS.Permessions = true;

                    }
                    if (TN == "المستخدمين")
                    {
                        Userlist = true;
                        RS.Userlist = true;

                    }

                    if (TN == "المرتجعات")
                    {
                        Returned = true;
                        RS.Returned = true;

                    }
                    if (TN == "قائمة المرتجعات")
                    {
                        Returnedlist = true;
                        RS.Returnedlist = true;

                    }
                    if (TN == "انشاء مرتجع")
                    {
                        Newreturned = true;
                        RS.Newreturned = true;

                    }
                }
                SQLConn.sqL = "UPDATE Rolesper SET " +
                                           "Home= '" + RS.Home + "', " +
                                           "Customers='" + RS.Customers + "'," +
                                           "Price='" + RS.Price + "'," +
                                           "Extentions='" + RS.Extentions + "'," +
                                           "Trsury='" + RS.Trsury + "'," +
                                           "Bankaccount='" + RS.Bankaccount + "'," +
                                           "Companydiscount='" + RS.Companydiscount + "'," +
                                           "Systemsetting='" + RS.Systemsetting + "'," +
                                           "Boats='" + RS.Boats + "'," +
                                           "Boattype='" + RS.Boattype + "'," +
                                           "Boatlist='" + RS.Boatlist + "'," +
                                           "Boatsort='" + RS.Boatsort + "'," +
                                           "Boatin='" + RS.Boatin + "'," +
                                           "Boatout='" + RS.Boatout + "'," +
                                           "Boatfix='" + RS.Boatfix + "'," +
                                           "Anchor='" + RS.Anchor + "'," +
                                           "Anchorpay='" + RS.Anchorpay + "'," +
                                           "Tickes='" + RS.Tickes + "'," +
                                           "Ticketlist='" + RS.Ticketlist + "'," +
                                           "Ticketedit='" + RS.Ticketedit + "'," +
                                           "Ticketdelete='" + RS.Ticketdelete + "'," +
                                           "Newticket='" + RS.Newticket + "'," +
                                           "Boatowner='" + RS.Boatowner + "'," +
                                           "Revenuse='" + RS.Revenuse + "'," +
                                           "Revenusetype='" + RS.Revenusetype + "'," +
                                           "Revenuselist='" + RS.Revenuselist + "'," +
                                           "Expences='" + RS.Expences + "'," +
                                           "Expencestype='" + RS.Expencestype + "'," +
                                           "Expenceslist='" + RS.Expenceslist + "'," +
                                           "Mony='" + RS.Mony + "'," +
                                           "FTTB='" + RS.FTTB + "'," +
                                           "FBTT='" + RS.FBTT + "'," +
                                           "Monrecive='" + RS.Monrecive + "'," +
                                           "Monrecivecashier='" + RS.Monrecivecashier + "'," +
                                           "Accountsreport='" + RS.Accountsreport + "'," +
                                           "Trsurep='" + RS.Trsurep + "'," +
                                           "Timeworkrep='" + RS.Timeworkrep + "'," +
                                           "Cashbalancerep='" + RS.Cashbalancerep + "'," +
                                           "Cashierreciverep='" + RS.Cashierreciverep + "'," +
                                           "Excepencesrep='" + RS.Excepencesrep + "'," +
                                           "Revenuserep='" + RS.Revenuserep + "'," +
                                           "Anchorpayrep='" + RS.Anchorpayrep + "'," +
                                           "Cashcomrep='" + RS.Cashcomrep + "'," +
                                           "Drivecomrep='" + RS.Drivecomrep + "'," +
                                           "Generalrep='" + RS.Generalrep + "'," +
                                           "Revenusetexrep='" + RS.Revenusetexrep + "'," +
                                           "Tickettaxrep='" + RS.Tickettaxrep + "'," +
                                           "Comboatoutrep='" + RS.Comboatoutrep + "'," +
                                           "Exceptaxrep='" + RS.Exceptaxrep + "'," +
                                           "Allanchorpayrep='" + RS.Allanchorpayrep + "'," +
                                           "Returnedrep='" + RS.Returnedrep + "'," +
                                           "Emploies='" + RS.Emploies + "'," +
                                           "Jobs='" + RS.Jobs + "'," +
                                           "Drivers='" + RS.Drivers + "'," +
                                           "Emplist='" + RS.Emplist + "'," +
                                           "Users='" + RS.Users + "'," +
                                           "Permessions='" + RS.Permessions + "'," +
                                           "Userlist='" + RS.Userlist + "'," +
                                           "Returned='" + RS.Returned + "'," +
                                           "Returnedlist='" + RS.Returnedlist + "'," +
                                           "Newreturned='" + RS.Newreturned + "'," +
                                           "CBBankaccount='" + RS.Bankaccount + "', " +
                                           "Rents='" + RS.Rents + "', " +
                                           "NewRent='" + RS.NewRent + "'," +
                                           "Rentslist='" + RS.Rentslist + "'," +
                                           "Rentalrep='" + RS.Rentalrep + "', " +
                                           "Boatfixrep='" + RS.Boatfixrep + "' " +
                                           "WHERE Userid = '" + Userid + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "تحديث بيانات الصلاحية");
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
        List<String> Checkeboxes(TreeNodeCollection theNodes)
        {
            List<String> aResult = new List<String>();

            if (theNodes != null)
            {
                foreach (TreeNode aNode in theNodes)
                {
                    if (!aNode.Checked)
                    {
                        aResult.Add(aNode.Text);
                    }

                    aResult.AddRange(Checkeboxes(aNode.Nodes));
                }
            }

            return aResult;
        }
        private void GetPerid()
        {
            try
            {
                SQLConn.sqL = @"SELECT * FROM Rolesper WHERE Userid = @Userid";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Userid", Userid);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read() == true)
                {
                    Btnadd.Enabled = false;
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
                    Ticketedit = Convert.ToBoolean(SQLConn.dr["Ticketedit"].ToString());
                    Ticketdelete = Convert.ToBoolean(SQLConn.dr["Ticketdelete"].ToString());
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
                    Jobs = Convert.ToBoolean(SQLConn.dr["Jobs"].ToString());
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
                        Treerole.Nodes[0].Checked = true;
                    }
                    if (Home && Customers)
                    {
                        Treerole.Nodes[0].Nodes[0].Checked = true;
                    }
                    if (Home && Price)
                    {
                        Treerole.Nodes[0].Nodes[1].Checked = true;
                    }
                    if (Home && Extentions)
                    {
                        Treerole.Nodes[0].Nodes[2].Checked = true;
                    }
                    if (Home && Trsury)
                    {
                        Treerole.Nodes[0].Nodes[3].Checked = true;
                    }
                    if (Home && Bankaccount)
                    {
                        Treerole.Nodes[0].Nodes[4].Checked = true;
                    }
                    if (Home && Companydiscount)
                    {
                        Treerole.Nodes[0].Nodes[5].Checked = true;
                    }
                    if (Home && Systemsetting)
                    {
                        Treerole.Nodes[0].Nodes[6].Checked = true;
                    }
                    if (Boats)
                    {
                        Treerole.Nodes[1].Checked = true;
                    }
                    if (Boats && Boattype)
                    {
                        Treerole.Nodes[1].Nodes[0].Checked = true;
                    }
                    if (Boats && Boatlist)
                    {
                        Treerole.Nodes[1].Nodes[1].Checked = true;
                    }
                    if (Boats && Boatsort)
                    {
                        Treerole.Nodes[1].Nodes[2].Checked = true;
                    }
                    if (Boats && Boatin)
                    {
                        Treerole.Nodes[1].Nodes[3].Checked = true;
                    }
                    if (Boats && Boatout)
                    {
                        Treerole.Nodes[1].Nodes[4].Checked = true;
                    }
                    if (Boats && Boatfix)
                    {
                        Treerole.Nodes[1].Nodes[4].Checked = true;
                    }
                    if (Boats && Anchor)
                    {
                        Treerole.Nodes[1].Nodes[5].Checked = true;
                    }
                    if (Boats && Anchorpay)
                    {
                        Treerole.Nodes[1].Nodes[6].Checked = true;
                    }
                    if (Tickes)
                    {
                        Treerole.Nodes[2].Checked = true;
                    }
                    if (Tickes && Ticketlist)
                    {
                        Treerole.Nodes[2].Nodes[0].Checked = true;
                    }
                    if (Tickes && Ticketedit)
                    {
                        Treerole.Nodes[2].Nodes[0].Nodes[0].Checked = true;
                    }
                    if (Tickes && Ticketdelete)
                    {
                        Treerole.Nodes[2].Nodes[0].Nodes[1].Checked = true;
                    }
                    if (Tickes && Newticket)
                    {
                        Treerole.Nodes[2].Nodes[1].Checked = true;
                    }
                    if (Tickes && Boatowner)
                    {
                        Treerole.Nodes[2].Nodes[2].Checked = true;
                    }
                    if (Rents)
                    {
                        Treerole.Nodes[3].Checked = true;
                    }
                    if (Rents && NewRent)
                    {
                        Treerole.Nodes[3].Nodes[0].Checked = true;
                    }
                    if (Rents && Rentslist)
                    {
                        Treerole.Nodes[3].Nodes[1].Checked = true;
                    }
                    if (Revenuse)
                    {
                        Treerole.Nodes[4].Checked = true;
                    }
                    if (Revenuse && Revenusetype)
                    {
                        Treerole.Nodes[4].Nodes[0].Checked = true;
                    }
                    if (Revenuse && Revenuselist)
                    {
                        Treerole.Nodes[4].Nodes[1].Checked = true;
                    }
                    if (Expences)
                    {
                        Treerole.Nodes[5].Checked = true;
                    }
                    if (Expences && Expencestype)
                    {
                        Treerole.Nodes[5].Nodes[0].Checked = true;
                    }
                    if (Expences && Expenceslist)
                    {
                        Treerole.Nodes[5].Nodes[1].Checked = true;
                    }
                    if (Mony)
                    {
                        Treerole.Nodes[6].Checked = true;
                    }
                    if (Mony && FTTB)
                    {
                        Treerole.Nodes[6].Nodes[0].Checked = true;
                    }
                    if (Mony && FBTT)
                    {
                        Treerole.Nodes[6].Nodes[1].Checked = true;
                    }
                    if (Monrecive)
                    {
                        Treerole.Nodes[7].Checked = true;
                    }
                    if (Monrecive && Monrecivecashier)
                    {
                        Treerole.Nodes[7].Nodes[0].Checked = true;
                    }
                    if (Accountsreport)
                    {
                        Treerole.Nodes[8].Checked = true;
                    }
                    if (Accountsreport && Trsurep)
                    {
                        Treerole.Nodes[8].Nodes[0].Checked = true;
                    }
                    if (Accountsreport && Rentalrep)
                    {
                        Treerole.Nodes[8].Nodes[1].Checked = true;
                    }
                    if (Accountsreport && Timeworkrep)
                    {
                        Treerole.Nodes[8].Nodes[2].Checked = true;
                    }
                    if (Accountsreport && Cashbalancerep)
                    {
                        Treerole.Nodes[8].Nodes[3].Checked = true;
                    }
                    if (Accountsreport && Cashierreciverep)
                    {
                        Treerole.Nodes[8].Nodes[4].Checked = true;
                    }
                    if (Accountsreport && Excepencesrep)
                    {
                        Treerole.Nodes[8].Nodes[5].Checked = true;
                    }
                    if (Accountsreport && Revenuserep)
                    {
                        Treerole.Nodes[8].Nodes[6].Checked = true;
                    }
                    if (Accountsreport && Anchorpayrep)
                    {
                        Treerole.Nodes[8].Nodes[7].Checked = true;
                    }
                    if (Accountsreport && Cashcomrep)
                    {
                        Treerole.Nodes[8].Nodes[8].Checked = true;
                    }
                    if (Accountsreport && Drivecomrep)
                    {
                        Treerole.Nodes[8].Nodes[9].Checked = true;
                    }
                    if (Accountsreport && Generalrep)
                    {
                        Treerole.Nodes[8].Nodes[10].Checked = true;
                    }
                    if (Accountsreport && Revenusetexrep)
                    {
                        Treerole.Nodes[8].Nodes[11].Checked = true;
                    }
                    if (Accountsreport && Tickettaxrep)
                    {
                        Treerole.Nodes[8].Nodes[12].Checked = true;
                    }
                    if (Accountsreport && Comboatoutrep)
                    {
                        Treerole.Nodes[8].Nodes[13].Checked = true;
                    }
                    if (Accountsreport && Exceptaxrep)
                    {
                        Treerole.Nodes[8].Nodes[14].Checked = true;
                    }
                    if (Accountsreport && Allanchorpayrep)
                    {
                        Treerole.Nodes[8].Nodes[15].Checked = true;
                    }
                    if (Accountsreport && Returnedrep)
                    {
                        Treerole.Nodes[8].Nodes[16].Checked = true;
                    }
                    //Boatfixrep
                    if (Accountsreport && Boatfixrep)
                    {
                        Treerole.Nodes[8].Nodes[18].Checked = true;
                    }
                    if (Emploies)
                    {
                        Treerole.Nodes[9].Checked = true;
                    }
                    if (Emploies && Jobs)
                    {
                        Treerole.Nodes[9].Nodes[0].Checked = true;
                    }
                    if (Emploies && Emplist)
                    {
                        Treerole.Nodes[9].Nodes[1].Checked = true;
                    }
                    if (Emploies && Drivers)
                    {
                        Treerole.Nodes[9].Nodes[2].Checked = true;
                    }
                    if (Users)
                    {
                        Treerole.Nodes[10].Checked = true;
                    }
                    if (Users && Permessions)
                    {
                        Treerole.Nodes[10].Nodes[0].Checked = true;
                    }
                    if (Users && Userlist)
                    {
                        Treerole.Nodes[10].Nodes[1].Checked = true;
                    }
                    if (Returned)
                    {
                        Treerole.Nodes[11].Checked = true;
                    }
                    if (Returned && Returnedlist)
                    {
                        Treerole.Nodes[11].Nodes[0].Checked = true;
                    }
                    if (Returned && Newreturned)
                    {
                        Treerole.Nodes[11].Nodes[1].Checked = true;
                    }
                    if (CBBankaccount)
                    {
                        Treerole.Nodes[8].Nodes[1].Checked = true;
                    }
                }
                else
                {
                    Btnedit.Visible = false;
                    Btndelete.Visible = false;
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
        private void Roles_Load(object sender, EventArgs e)
        {
            GetPerid();
        }
        private void CheckAllChiledNodes(TreeNode TN,bool NC)
        {
            foreach(TreeNode tn in TN.Nodes)
            {
                tn.Checked = NC;
                if(tn.Nodes.Count > 0)
                {
                    this.CheckAllChiledNodes(tn, NC);
                }
            }
        }
        private void Treerole_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    this.CheckAllChiledNodes(e.Node, e.Node.Checked);
                }
            }
        }
        private void Btnadd_Click(object sender, EventArgs e)
        {
            AddRole();
        }
        private void Btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذه الصلاحية", "رسالة تأكيد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SQLConn.sqL = "Delete From Rolesper WHERE Userid = " + Userid + "";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.ExecuteNonQuery();
                    this.Close();
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
            else
            {
                return;
            }
           
        }
        private void Btnedit_Click(object sender, EventArgs e)
        {
            UpdateRole();
        }
    }
}
