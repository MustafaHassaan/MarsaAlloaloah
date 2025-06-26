using MarsaAlloaloah.Utility.Ado.net;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    //public partial class frmPrintTicket : Form
    public partial class frmReportPrint : Form
    {
        //public frmReportPrint()
        //{
        //    InitializeComponent();
        //}

        string printType;
        int userID;
        string searchText;
        DateTime dateStartSearch;
        DateTime dateEndSearch;
        string Name = "";
        private int landingPaymentId;
        private string amountToDisplayInWords;


        public frmReportPrint(DateTime dateStart, DateTime dateEnd, int ID, string INV_TYPE, string name = "")
        {
            InitializeComponent();
            userID = ID;
            printType = INV_TYPE;
            dateStartSearch = dateStart; dateEndSearch = dateEnd;
            Name = name;
        }

        public frmReportPrint(DateTime dateStart, DateTime dateEnd, string text, string INV_TYPE)
        {
            InitializeComponent();
            searchText = text;
            printType = INV_TYPE;
            dateStartSearch = dateStart;
            dateEndSearch = dateEnd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="v"></param>
        public frmReportPrint(int id, string v)
        {
            InitializeComponent();
            this.landingPaymentId = id;
            this.printType = v;
        }

        public frmReportPrint(int id, string amount, string INV_TYPE)
        {
            InitializeComponent();
            this.landingPaymentId = id;
            this.printType = INV_TYPE;
            amountToDisplayInWords = amount;
        }

        public frmReportPrint(DateTime dateStart, DateTime dateEnd, string INV_TYPE)
        {
            //GeneralReport
            InitializeComponent();
            this.printType = INV_TYPE;
            dateStartSearch = dateStart;
            dateEndSearch = dateEnd;
        }

        private void frmReportPrint_Load(object sender, EventArgs e)
        {
            ////Pour que la recherche prend en compte les dates (avec les heures/minutes) dans le m^me jour de recherche
            dateEndSearch = dateEndSearch.AddDays(1);//M/d/yyyy // date format in database is 2020-10-01

            DateTime selectedDate = dateStartSearch;
            if (printType == "Cashier")
            {
                string query = @"SELECT     
                                 Tickets.ID, 
                                 Tickets.UserID, 
                                 Users.UserName, 
                                 Tickets.PriceAfterVAT, Customers.Name AS CustomerName, Tickets.StartDate, Tickets.StartTime, Tickets.PayCash, 
                      Tickets.PayCard, Employees.Name AS EmployeName, Drivers.Name AS DriverName, SeaTransport.Name AS BoatName
                        FROM         Tickets INNER JOIN
                      Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                      Users ON Tickets.UserID = Users.ID INNER JOIN
                      Employees ON Users.EmployeeID = Employees.ID  LEFT OUTER JOIN
                      Drivers ON Tickets.DriverID = Drivers.ID  LEFT OUTER JOIN
                      SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID
                        WHERE     Users.ID = " + userID
                      + @" and ( tickets.startDate >= '" + dateStartSearch.ToString("yyyy-MM-dd") +
                      @"' and  tickets.startDate <= '" + dateEndSearch.ToString("yyyy-MM-dd") + "') order by Tickets.ID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(query, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                dsMarsa Ds = new dsMarsa();
                while (SQLConn.dr.Read())
                {
                    int ID = Convert.ToInt32(SQLConn.dr["ID"].ToString());
                    var Userid = SQLConn.dr["UserID"].ToString();
                    var Name = SQLConn.dr["UserName"].ToString();
                    Ds.Tickets.Rows.Add(new object[] {
                        ID,Userid,
                    });
                }
                //SQLConn.Preview_CashierDetails(query, crystalReportViewer1);
            }
            else if (printType == "Income")
            {
                string query = @"SELECT Income.ID, Income.IncomeName, Income.Description, Income.Amount, Income.VAT, Income.AmountAfterVAT, Income.IncomeTypeID, IncomeType.Name AS IncomeType,
                        Income.IsTaxInvoice, Income.Date
                        FROM  IncomeType INNER JOIN
                        Income ON IncomeType.ID = Income.IncomeTypeID
                         and ( Income.Date < '" + dateEndSearch.ToShortDateString() +
                        @"' and  Income.Date >= '" + dateStartSearch.ToShortDateString() + "') ";

                SQLConn.Preview_IncomeDetails(query, crystalReportViewer1);
            }
            //
            else if (printType == "Expenses")
            {
                string query = @"SELECT    Expenses.ID, Expenses.ExpensesName, Expenses.Amount, Expenses.VAT, Expenses.AmountAfterVAT, Expenses.ExpensesTypeID, 
                      Expenses.SeaTransportID, Expenses.IsTaxInvoice, Expenses.Date, ExpensesType.ExpensesType
                      FROM         Expenses INNER JOIN
                      ExpensesType ON Expenses.ExpensesTypeID = ExpensesType.ID  and ( Expenses.Date < '" + dateEndSearch.ToShortDateString() +
                      @"' and  Expenses.Date >= '" + dateStartSearch.ToShortDateString() + "') ";

                SQLConn.Preview_ExpensesDetails(query, crystalReportViewer1);
            }
            else if (printType == "IncomeCashier")
            {
                string query = @"SELECT     IncomeFromCashier.ID, IncomeFromCashier.StartDate, IncomeFromCashier.PayCash, 
                                IncomeFromCashier.PayCard, Employees.Name AS EmployeName, IncomeFromCashier.UserID
                      FROM Role INNER JOIN
                      Users ON Role.ID = Users.RoleID INNER JOIN
                      Employees ON Users.EmployeeID = Employees.ID INNER JOIN
                      Jobs ON Employees.JobID = Jobs.ID INNER JOIN
                      IncomeFromCashier ON Users.ID = IncomeFromCashier.UserID where Users.ID= " + userID
                      + @" and ( IncomeFromCashier.startDate < '" + dateEndSearch.ToShortDateString() +
                      @"' and  IncomeFromCashier.startDate >= '" + dateStartSearch.ToShortDateString() + "') ";

                SQLConn.Preview_IncomeCashierDetails(query, crystalReportViewer1);
            }
            else if (printType == "SeaTransportWorkingHours")
            {
                string query = @"SELECT DISTINCT SeaTransport.Name,Tickets.ID, Tickets.StartDate AS StartDateTicket, 
                                CAST(Tickets.StartTime AS time(0)) AS StartTimeTicket, Price.Duration, 
                                Customers.Name AS CustomerName,   Drivers.Name AS DriverName, 
                         Tickets.PriceAfterDiscount,Tickets.PriceAfterVAT as PriceTicketAfterVAT,
                         Price.CashierCommission as CashierAmount, Price.CashierExternCommission, 
                      SeaTransport.OwnerID, SeaTransport.OwnerTypeID
                       FROM         Tickets INNER JOIN
                      Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                      SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID INNER JOIN
                      Price ON Tickets.DurationID = Price.ID INNER JOIN
                      SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID INNER JOIN
                      Drivers ON Tickets.DriverID = Drivers.ID where SeaTransport.ID = " + searchText
                        + @" and ( Tickets.StartDate <= '" + dateEndSearch.ToShortDateString() +
                        @"' and  Tickets.StartDate >= '" + dateStartSearch.ToShortDateString() + "')  Order by Tickets.StartDate desc";

                SQLConn.Preview_SeaTransportWorkingHoursDetails(query, crystalReportViewer1);
            }
            else if (printType == "CashierCommission")
            {
                // بديل اللي عملته
                //Price.CashierExternCommission, 
                string query = @"SELECT DISTINCT 
Tickets.ID,
SeaTransport.Name,
Tickets.StartDate AS StartDateTicket, 
CAST(Tickets.StartTime AS time(0)) AS StartTimeTicket, 
Tickets.DurationValue AS 'AccountantAmount', 
Price.Duration, 
Customers.Name AS CustomerName,   
Drivers.Name AS DriverName, 
Tickets.PriceAfterVAT as PriceTicketAfterVAT,
Price.CashierCommission 'CashierAmount' ,
Price.CashierExternCommission,
SeaTransport.OwnerID, 
SeaTransport.OwnerTypeID
FROM Tickets 
Left Outer JOIN Customers 
ON Tickets.CustomerID = Customers.ID 
Left Outer JOIN SeaTransportType 
ON Tickets.SeaTransportTypeID = SeaTransportType.ID 
Left Outer JOIN Price 
ON Tickets.DurationID = Price.ID 
Left Outer JOIN SeaTransport 
ON Tickets.SeaTransportID = SeaTransport.ID 
Left Outer JOIN Drivers 
ON Tickets.DriverID = Drivers.ID 
Left Outer JOIN Users 
ON Tickets.UserID = Users.ID 
                      WHERE  Users.ID = " + userID
                      + @" and Tickets.ID Not IN (Select Invoiceid From Returned Where Type='ارتجاع تذكرة')"
                       + @" and ( Tickets.StartDate <= '" + dateEndSearch.ToShortDateString() +
                       @"' and  Tickets.StartDate >= '" + dateStartSearch.ToShortDateString() + "') Order by Tickets.StartDate desc";

                SQLConn.Preview_CashierCommissionDetails(query, Name, crystalReportViewer1);
            }
            else if (printType == "Treasury")
            {
                string query = @"SELECT TreasuryTransactions.ID, TreasuryTransactions.TransfertAmount, TreasuryTransactions.Libelle, 
                                TreasuryTransactions.Date, Treasury.Name, Treasury.Balance, Treasury.StartingBalance as StartingAmount
                                FROM         Treasury INNER JOIN
                                TreasuryTransactions ON Treasury.ID = TreasuryTransactions.TreasuryID
                                where TreasuryTransactions.TreasuryID = " + userID
                                + @" and ( TreasuryTransactions.Date < '" + dateEndSearch.ToShortDateString() +
                                @"' and  TreasuryTransactions.Date >= '" + dateStartSearch.ToShortDateString() + "')  Order by TreasuryTransactions.Date";

                SQLConn.Preview_TreasuryDetails(query, crystalReportViewer1);
            }
            else if (printType == "Ticket")
            {
                /*
                SELECT     Tickets.ID, Tickets.UserID, Users.UserName, Tickets.PriceAfterVAT, Customers.Name AS CustomerName, Tickets.StartDate, Tickets.StartTime, Tickets.PayCash, 
                      Tickets.PayCard, Employees.Name AS EmployeName
                      */
                string query = @"SELECT  Tickets.ID, Tickets.StartDate,  CAST(Tickets.StartTime AS time(0)) AS StartTime, 
                        Customers.Name AS CustomerName, Customers.Mobile, 
                        Customers.NID, SeaTransport.Name AS SeaTransportName, 
                        Tickets.DurationValue, Tickets.VAT, Tickets.PriceAfterDiscount, 
                        Tickets.PriceAfterVAT, Employees.Name AS CashierName, 
                        SeaTransportType.Name AS SeaType, Drivers.Name AS DriverName, Tickets.PayCash, 
                      Tickets.PayCard
                      FROM         Tickets INNER JOIN
                      Users ON Tickets.UserID = Users.ID INNER JOIN
                      Role ON Users.RoleID = Role.ID INNER JOIN
                      Employees ON Users.EmployeeID = Employees.ID INNER JOIN
                      Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                      SeaTransportType ON Tickets.SeaTransportTypeID = SeaTransportType.ID LEFT OUTER JOIN
                      Drivers ON Tickets.DriverID = Drivers.ID LEFT OUTER JOIN
                      SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID
                      WHERE     (Role.ID = 2) and dbo.Tickets.ID = " + userID + " ";

                string sql = @"SELECT dbo.lnkTicketAddon.AddonID, dbo.lnkTicketAddon.Quantity, dbo.lnkTicketAddon.Price, dbo.lnkTicketAddon.Total, dbo.Addons.Name
                  FROM  dbo.lnkTicketAddon LEFT OUTER JOIN
                  dbo.Addons ON dbo.lnkTicketAddon.AddonID = dbo.Addons.ID Where dbo.lnkTicketAddon.TicketID = " + userID + "";

                SQLConn.Preview_ticket(query, sql, crystalReportViewer1);
            }
            else if (printType == "SeaTransportLandingPayment")
            {
                string query = @"SELECT DISTINCT 
                      LandingPaymentTransaction.ID, LandingPaymentTransaction.PayCash, LandingPaymentTransaction.PayCard, LandingPaymentTransaction.Date, 
                      LandingPaymentTransaction.LandingID, Landing.Amount, Landing.StartDate, Landing.EndDate, Landing.PaymentDoneToDate, 
                      SeaTransport.Name as SeaName, LandingPaymentTransaction.PaymentDoneToDate as PaymentDateTransaction
                      FROM         LandingPaymentTransaction INNER JOIN
                      Landing ON LandingPaymentTransaction.LandingID = Landing.ID INNER JOIN
                      SeaTransport ON Landing.SeaTransportID = SeaTransport.ID where Landing.SeaTransportID = '" + searchText + "'";
                       /* + @" and ( LandingPaymentTransaction.Date < '" + dateEndSearch.ToShortDateString() +
                        @"' and  LandingPaymentTransaction.Date >= '" + dateStartSearch.ToShortDateString() + "')  Order by LandingPaymentTransaction.Date desc";*/

                SQLConn.Preview_LandingPaymentDetails(query, crystalReportViewer1);
            }
            else if (printType == "LandingPaymentPart")
            {
                //string query = @"SELECT DISTINCT 
                //      LandingPaymentTransaction.ID, LandingPaymentTransaction.PayCash, LandingPaymentTransaction.PayCard, LandingPaymentTransaction.Date, 
                //      LandingPaymentTransaction.LandingID, Landing.Amount, Landing.StartDate, Landing.EndDate, Landing.PaymentDoneToDate, SeaTransport.Name AS SeaName, 
                //      LandingPaymentTransaction.PaymentDoneToDate AS PaymentDateTransaction, BankAccounts.Name AS BankName
                //      FROM                  LandingPaymentTransaction INNER JOIN
                //      Landing ON LandingPaymentTransaction.LandingID = Landing.ID INNER JOIN
                //      SeaTransport ON Landing.SeaTransportID = SeaTransport.ID LEFT OUTER JOIN
                //      BankAccountTransactions ON LandingPaymentTransaction.ID = BankAccountTransactions.LandingPaymentID LEFT OUTER JOIN
                //      BankAccounts ON BankAccountTransactions.BankID = BankAccounts.ID where LandingPaymentTransaction.ID = " + landingPaymentId;
                //        //+ @" and ( LandingPaymentTransaction.Date < '" + dateEndSearch.ToShortDateString() +
                //@"' and  LandingPaymentTransaction.Date >= '" + dateStartSearch.ToShortDateString() + "')  Order by LandingPaymentTransaction.Date desc";
                string query = @"SELECT DISTINCT 
                      LandingPaymentTransaction.ID, LandingPaymentTransaction.PayCash, LandingPaymentTransaction.PayCard, LandingPaymentTransaction.Date, 
                      LandingPaymentTransaction.LandingID, Landing.Amount, Landing.StartDate, Landing.EndDate, Landing.PaymentDoneToDate, SeaTransport.Name AS SeaName, 
                      LandingPaymentTransaction.PaymentDoneToDate AS PaymentDateTransaction, BankAccounts.Name AS BankName, 
                        Landing.Owner as OwnerName, 
                      SeaTransport.Number AS BoatNumber, LandingPaymentTransaction.PaymentTransactionStartDate, 
                      LandingPaymentTransaction.PaymentDoneToDate AS PaymentTransactionEndDate

                        FROM         LandingPaymentTransaction INNER JOIN
                      Landing ON LandingPaymentTransaction.LandingID = Landing.ID INNER JOIN
                      SeaTransport ON Landing.SeaTransportID = SeaTransport.ID LEFT OUTER JOIN
                      Drivers ON SeaTransport.OwnerID = Drivers.ID LEFT OUTER JOIN
                      BankAccountTransactions ON LandingPaymentTransaction.ID = BankAccountTransactions.LandingPaymentID LEFT OUTER JOIN
                      BankAccounts ON BankAccountTransactions.BankID = BankAccounts.ID 
                    WHERE      LandingPaymentTransaction.ID = " + landingPaymentId; //(SeaTransport.OwnerTypeID = 1) and

                SQLConn.Preview_LandingPaymentPartDetails(query, amountToDisplayInWords, crystalReportViewer1);
            }
            else if (printType == "DriverCommission")
            {
                string query = @"SELECT DISTINCT 
SeaTransport.ID, 
SeaTransport.Name,
Tickets.ID, 
Tickets.StartDate AS StartDateTicket,
CAST(Tickets.StartTime AS time(0)) AS StartTimeTicket, 
Tickets.DurationValue as 'AccountantAmount', 
Price.Duration, 
Customers.Name AS CustomerName,   
Drivers.Name AS DriverName, 
Tickets.PriceAfterVAT as PriceTicketAfterVAT,
Price.CashierCommission as CashierAmount, 
Price.CashierExternCommission, 
SeaTransport.OwnerID, 
SeaTransport.OwnerTypeID, 
(Price.Percentage/100) * Tickets.PriceAfterDiscount As 'DriverCommission'
FROM Tickets 
Left Outer JOIN Customers 
ON Tickets.CustomerID = Customers.ID 
Left Outer JOIN SeaTransportType 
ON Tickets.SeaTransportTypeID = SeaTransportType.ID 
Left Outer JOIN Price 
ON Tickets.DurationID = Price.ID 
Left Outer JOIN SeaTransport 
ON Tickets.SeaTransportID = SeaTransport.ID 
Left Outer JOIN Drivers 
ON Tickets.DriverID = Drivers.ID 
Left Outer JOIN Users 
ON Tickets.UserID = Users.ID  WHERE  Drivers.ID = " + userID +
                      @" and Tickets.ID Not IN (Select Invoiceid From Returned Where Type='ارتجاع تذكرة')"
                         + @" and ( Tickets.StartDate < '" + dateEndSearch.ToShortDateString() +
                         @"' and  Tickets.StartDate >= '" + dateStartSearch.ToShortDateString() + "')  Order by Tickets.StartDate desc";

                SQLConn.Preview_DriverCommissionDetails(query, Name, crystalReportViewer1);
            }
            else if (printType == "GeneralReport")
            {
                SQLConn.Preview_GeneralReportDetails(selectedDate, dateEndSearch, crystalReportViewer1);
            }
        }
    }
}
