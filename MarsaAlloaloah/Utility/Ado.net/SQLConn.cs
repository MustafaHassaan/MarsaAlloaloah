using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using NumberToWord;
using static System.Net.WebRequestMethods;

namespace MarsaAlloaloah.Utility.Ado.net
{
    static class SQLConn
    {

        public static string ServerSQL;
        public static string PortSQL;
        public static string UserNameSQL;
        public static string PwdSQL;
        public static string DBNameSQL;
        public static string sqL;
        public static DataSet ds = new DataSet();
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlTransaction trans;
        public static bool adding;
        public static bool updating;
        public static string strSearch = "";

        public static DataTable sqlDT = new DataTable();

        public static SqlDataAdapter da = new SqlDataAdapter();

        public static SqlConnection conn = new SqlConnection();

        public static object ConfigurationManager { get; private set; }

        //public static Configuration config;

        //public static string GetConnectionString(string key)
        //{

        //    return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        //}

        public static void getData()
        {
            string AppName = Application.ProductName;
            //string  connection = System.Configuration.ConfigurationManager.ConnectionStrings["MarsaKanzConn"].ConnectionString;           
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings["MarsaKanzConn"].ConnectionString);
            string myUser = connection.UserID;
            string myPass = connection.Password;
            string myDB = connection.InitialCatalog;
            string myserver = connection.DataSource;
            //var conn = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            try
            {
                DBNameSQL = Interaction.GetSetting(AppName, "DBSection", "DB_Name", myDB);
                ServerSQL = Interaction.GetSetting(AppName, "DBSection", "DB_IP", myserver);
                //PortMySQL = Interaction.GetSetting(AppName, "DBSection", "DB_Port", "3306");
                UserNameSQL = Interaction.GetSetting(AppName, "DBSection", "DB_User", myUser);
                PwdSQL = Interaction.GetSetting(AppName, "DBSection", "DB_Password", myPass);
            }
            catch
            {
                Interaction.MsgBox("System registry was not established, you can set/save " + "these settings by pressing F1", MsgBoxStyle.Information);
            }
        }

        public static IDataReader getRecord(string query)
        {
            SqlDataReader reader;
            using (var connection = conn)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {

                    reader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                    return dt.CreateDataReader();
                }
            }
            return null;
        }

        public static DataTable getTable(string query)
        {
            using (var connection = conn)
            {
                using (var cmd = new SqlDataAdapter(query, connection))
                {
                    var dt = new DataTable();
                    cmd.Fill(dt);
                    return dt;
                }
            }
            return null;
        }

        public static void ConnDB()
        {
            conn.Close();
            try
            {
                conn.ConnectionString = "Data Source="+ServerSQL+ "; Initial Catalog="+DBNameSQL+ "; User ID=" + UserNameSQL + "; Password="+ PwdSQL +"; Persist Security Info=True;";
                //conn.ConnectionString = @"Data Source = ASUSX554L; Initial Catalog = MarsaKAnzAbhar; Integrated Security = True";
                //conn.ConnectionString = "Data Source=.\\SQLSERVER2;Initial Catalog=MarsaKAnzAbhar3;Integrated Security=True";
                conn.Open();
            }
            catch(Exception ex)
            {
                Interaction.MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings");
            }
        }
        public static void BeginTransaction()
        {
            trans = conn.BeginTransaction();
        }
        public static void UpdateQuery(string query)
        {
            using (var connection = conn)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        public static void DisconnMyConn()
        {
            conn.Close();
            conn.Dispose();
        }

        public static void SaveData()
        {
            string AppName = Application.ProductName;

            Interaction.SaveSetting(AppName, "DBSection", "DB_Name", DBNameSQL);
            Interaction.SaveSetting(AppName, "DBSection", "DB_IP", ServerSQL);
            //Interaction.SaveSetting(AppName, "DBSection", "DB_Port", PortSQL);
            Interaction.SaveSetting(AppName, "DBSection", "DB_User", UserNameSQL);
            Interaction.SaveSetting(AppName, "DBSection", "DB_Password", PwdSQL);
            Interaction.MsgBox("Database connection settings are saved.", MsgBoxStyle.Information);
        }


        public static DataTable GetCompanyInfo()
        {
            ConnDB();
            using (var cmd = new SqlDataAdapter("SELECT * FROM company LIMIT 1", conn))
            {
                var dt = new DataTable();
                cmd.Fill(dt);
                return dt;
            }
            return null;
        }

        #region Reports

        public static void Preview_CashierDetails(string sql, CrystalReportViewer CrystalReportViewer)
        {
            try
            {
                ReportDocument rpt_Document = new ReportDocument();
                ParameterValues ParamCollection = new ParameterValues();
                rpt_Document.Load(Application.StartupPath + "\\Reports\\rptCollection.rpt");
                SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                dsMarsa my_DataSource = new dsMarsa();
                ConnDB();
                SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
                my_Command.CommandText = sql;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "Tickets");
                rpt_Document.SetDataSource(my_DataSource);
                CrystalReportViewer.ReportSource = rpt_Document;
                DisconnMyConn();
            }
            catch (Exception ex)
            {

            }
        }

        public static void Preview_DriverCommissionDetails(string query, string cashierName, CrystalReportViewer crystalReportViewer)
        {
            try
            {
                ReportDocument rpt_Document = new ReportDocument();
                ParameterValues ParamCollection = new ParameterValues();
                rpt_Document.Load(Application.StartupPath + "\\Reports\\rptDriverCommission.rpt");
                SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                dsMarsa my_DataSource = new dsMarsa();
                ConnDB();
                SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
                my_Command.CommandText = query;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "SeaTransport");
                rpt_Document.SetDataSource(my_DataSource);
                crystalReportViewer.ReportSource = rpt_Document;
                // Ajouter le paramétre nom de cashier //CashierName
                crpCashierName.Value = cashierName;
                _ = ParamCollection.Add(crpCashierName);
                rpt_Document.ParameterFields["CashierName"].CurrentValues = ParamCollection;
                DisconnMyConn();
            }
            catch (Exception ex)
            {

            }
        }

        public static void Preview_CashierCommissionDetails(string query, string cashierName, CrystalReportViewer crystalReportViewer)
        {
            try
            {
                ReportDocument rpt_Document = new ReportDocument();
                ParameterValues ParamCollection = new ParameterValues();
                rpt_Document.Load(Application.StartupPath + "\\Reports\\rptCashierCommission.rpt");
                SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                dsMarsa my_DataSource = new dsMarsa();
                ConnDB();
                SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
                my_Command.CommandText = query;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "SeaTransport");
                rpt_Document.SetDataSource(my_DataSource);
                crystalReportViewer.ReportSource = rpt_Document;
                // Ajouter le paramétre nom de cashier //CashierName
                crpCashierName.Value = cashierName;
                _ = ParamCollection.Add(crpCashierName);
                rpt_Document.ParameterFields["CashierName"].CurrentValues = ParamCollection;
                DisconnMyConn();
            }
            catch (Exception ex)
            {

            }
        }

        public static void Preview_GeneralReportDetails(DateTime selectedDate, DateTime dateEndSearch, CrystalReportViewer crystalReportViewer)
        {
            try
            {
                ///Sql for ticket
                //string queryTicket = @"SELECT  tickets.ID, tickets.startDate, sum(Tickets.PayCash) as PayCash, sum(Tickets.PayCard) as PayCard
                //        FROM         Tickets INNER JOIN
                //      Customers ON Tickets.CustomerID = Customers.ID INNER JOIN
                //      Users ON Tickets.UserID = Users.ID INNER JOIN
                //      Employees ON Users.EmployeeID = Employees.ID  LEFT OUTER JOIN
                //      Drivers ON Tickets.DriverID = Drivers.ID  LEFT OUTER JOIN
                //      SeaTransport ON Tickets.SeaTransportID = SeaTransport.ID
                //        WHERE  (  tickets.startDate >= '" + selectedDate.ToShortDateString() + @"'  )
                //        and (  tickets.startDate <= '" + dateEndSearch.ToShortDateString() + @"'  )
                //        group by tickets.startDate, tickets.ID";
                string queryTicket = @"SELECT 
                                        sum(Tickets.PayCash) as PayCash, 
                                        sum(Tickets.PayCard) as PayCard
                                        FROM Tickets
										Left Outer Join Returned
										On Returned.Invoiceid = Tickets.ID
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
                                       WHERE tickets.startDate >= '" + selectedDate.ToShortDateString() +"' "+ 
                                       "and tickets.startDate < '" + dateEndSearch.ToShortDateString() +"'" +
                                       "And Tickets.ID Not In(Select Invoiceid from Returned)";

                /// sql for ticket income
                var queryIncomeFromCashier = @"SELECT IncomeFromCashier.ID, IncomeFromCashier.StartDate,  sum(IncomeFromCashier.PayCash) as PayCash , 
                        sum(IncomeFromCashier.PayCard) as PayCard
                      FROM Role INNER JOIN
                      Users ON Role.ID = Users.RoleID INNER JOIN
                      Employees ON Users.EmployeeID = Employees.ID INNER JOIN
                      Jobs ON Employees.JobID = Jobs.ID INNER JOIN
                      IncomeFromCashier ON Users.ID = IncomeFromCashier.UserID
                      Where ( IncomeFromCashier.StartDate >= '" + selectedDate.ToShortDateString() + @"' )
                        and ( IncomeFromCashier.StartDate < '" + dateEndSearch.ToShortDateString() + @"' )  
                        group by IncomeFromCashier.StartDate, IncomeFromCashier.ID ";

                /// sql for incomes
                var queryIncomes = @"SELECT sum (Income.AmountAfterVAT) as Amount
                        FROM  IncomeType INNER JOIN
                        Income ON IncomeType.ID = Income.IncomeTypeID
                         and  ( Income.Date >= '" + selectedDate.ToShortDateString() + @"' )
                        and ( Income.Date < '" + dateEndSearch.ToShortDateString() + @"' )";

                /// //for expenses
                string queryExpenses = @"SELECT sum(Expenses.AmountAfterVAT)  as Amount
                FROM         Expenses INNER JOIN
                ExpensesType ON Expenses.ExpensesTypeID = ExpensesType.ID  
                and ( Expenses.Date >= '" + selectedDate.ToShortDateString() + @"' )
                        and ( Expenses.Date < '" + dateEndSearch.ToShortDateString() + @"' )";

                /// landing payments
                string queryLandingPayment = @"SELECT sum(LandingPaymentTransaction.PayCash) as PayCash, 
                         sum(LandingPaymentTransaction.PayCard) as PayCard
                        FROM         LandingPaymentTransaction INNER JOIN
                      Landing ON LandingPaymentTransaction.LandingID = Landing.ID INNER JOIN
                      SeaTransport ON Landing.SeaTransportID = SeaTransport.ID LEFT OUTER JOIN
                      Drivers ON SeaTransport.OwnerID = Drivers.ID LEFT OUTER JOIN
                      BankAccountTransactions ON LandingPaymentTransaction.ID = BankAccountTransactions.LandingPaymentID LEFT OUTER JOIN
                      BankAccounts ON BankAccountTransactions.BankID = BankAccounts.ID 
                      WHERE      LandingPaymentTransaction.Date <= '" + dateEndSearch.ToShortDateString() + "' " +
                    " and LandingPaymentTransaction.Date >= '" + selectedDate.ToShortDateString() + "' And Landing.ID Not In(Select Invoiceid from Returned)";
                // Returnedticket
                string queryreturnedticket = @"Select 
                                               Sum(Tickets.Paycash),
                                               Sum(Tickets.PayCard)
                                               From Tickets
                                               Left Outer Join Returned
                                               On Tickets.ID = Returned.Invoiceid
                                               Where Tickets.ID IN (Select Invoiceid from Returned) 
                                               And tickets.startDate >= '" + selectedDate.ToShortDateString() + "' "+
                                              " And tickets.startDate <= '" + dateEndSearch.ToShortDateString() + "' ";

                // ReturnedLanding
                string queryreturnedlanding = @"SELECT 
                                                sum(LandingPaymentTransaction.PayCash) as PayCash, 
                                                sum(LandingPaymentTransaction.PayCard) as PayCard
                                                FROM LandingPaymentTransaction 
                                                INNER JOIN Landing 
                                                ON LandingPaymentTransaction.LandingID = Landing.ID 
                                                INNER JOIN SeaTransport 
                                                ON Landing.SeaTransportID = SeaTransport.ID 
                                                LEFT OUTER JOIN Drivers 
                                                ON SeaTransport.OwnerID = Drivers.ID 
                                                LEFT OUTER JOIN BankAccountTransactions 
                                                ON LandingPaymentTransaction.ID = BankAccountTransactions.LandingPaymentID 
                                                LEFT OUTER JOIN BankAccounts 
                                                ON BankAccountTransactions.BankID = BankAccounts.ID 
                                                WHERE LandingPaymentTransaction.Date <= '"+ dateEndSearch.ToShortDateString() + "' "+
                                               "And LandingPaymentTransaction.Date >= '"+ dateEndSearch.ToShortDateString() + "' "+
                                               " And Landing.ID In (Select Invoiceid from Returned)";
                ReportDocument rpt_Document = new ReportDocument();
                ParameterValues ParamCollection = new ParameterValues();
                rpt_Document.Load(Application.StartupPath + "\\Reports\\rptGeneralReport.rpt");
                SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                dsMarsa my_DataSource = new dsMarsa();
                ConnDB();
                SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);

                my_Command.CommandText = queryTicket;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "Tickets");

                my_Command.CommandText = queryIncomeFromCashier;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "IncomeFromCashier");

                my_Command.CommandText = queryExpenses;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "Expense");

                my_Command.CommandText = queryIncomes;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "Income");

                my_Command.CommandText = queryLandingPayment;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "LandingPayment");

                my_Command.CommandText = queryreturnedticket;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "Returnedticket");


                my_Command.CommandText = queryreturnedlanding;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "Returnedlanding");

                rpt_Document.SetDataSource(my_DataSource);
                crystalReportViewer.ReportSource = rpt_Document;

                //crpDate
                crpDate.Value = selectedDate.ToShortDateString();
                _ = ParamCollection.Add(crpDate);
                rpt_Document.ParameterFields["DateReport"].CurrentValues = ParamCollection;

                DisconnMyConn();
            }
            catch (Exception ex)
            {

            }
        }

        public static void Preview_IncomeDetails(string sql, CrystalReportViewer crystalReportViewer)
        {
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\rptIncome.rpt");
            SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
            dsMarsa my_DataSource = new dsMarsa();
            ConnDB();
            SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            _ = my_DataAdapter.Fill(my_DataSource, "Income");
            rpt_Document.SetDataSource(my_DataSource);
            crystalReportViewer.ReportSource = rpt_Document;
        }


        public static void Preview_ExpensesDetails(string sql, CrystalReportViewer crystalReportViewer)
        {
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\rptExpenses.rpt");
            SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
            dsMarsa my_DataSource = new dsMarsa();
            ConnDB();
            SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            _ = my_DataAdapter.Fill(my_DataSource, "Expense");
            rpt_Document.SetDataSource(my_DataSource);
            crystalReportViewer.ReportSource = rpt_Document;
        }

        public static void UpdatePrincipalTreasuryLandingTransactions(decimal amount, SqlTransaction trans, int landingPaymentID, string libelle)
        {
            try
            {
                //int treasuryID = GetPrincipalTreasuryID(trans);
                int treasuryID = SQLConn.GetTreasuryIDForCurrentUser(Data.UserID);
                if (treasuryID > 0)
                {
                    SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, TreasuryID, LandingPaymentID,Libelle, Date) " +
                        "values( @NewBalance, @treasuryID,@LandingPaymentID ,@Libelle,@Date)";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, trans);
                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", treasuryID);
                    SQLConn.cmd.Parameters.AddWithValue("@LandingPaymentID", landingPaymentID);
                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", libelle);
                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    SQLConn.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }


        //Preview_IncomeCashierDetails
        public static void Preview_IncomeCashierDetails(string sql, CrystalReportViewer CrystalReportViewer)
        {
            ReportDocument rpt_Document = new ReportDocument();
            ParameterValues ParamCollection = new ParameterValues();
            rpt_Document.Load(Application.StartupPath + "\\Reports\\rptIncomeCashier.rpt");
            SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
            SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
            dsMarsa my_DataSource = new dsMarsa();
            ConnDB();
            SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
            my_Command.CommandText = sql;
            my_Command.Connection = My_Connection;
            my_Command.CommandType = CommandType.Text;
            my_DataAdapter.SelectCommand = my_Command;
            _ = my_DataAdapter.Fill(my_DataSource, "IncomeFromCashier");
            rpt_Document.SetDataSource(my_DataSource);
            CrystalReportViewer.ReportSource = rpt_Document;
            DisconnMyConn();
        }

        public static void Preview_SeaTransportWorkingHoursDetails(string sql, CrystalReportViewer CrystalReportViewer)
        {
            try
            {
                ReportDocument rpt_Document = new ReportDocument();
                ParameterValues ParamCollection = new ParameterValues();
                rpt_Document.Load(Application.StartupPath + "\\Reports\\rptSeaTransportWorkingHours.rpt");
                SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                dsMarsa my_DataSource = new dsMarsa();
                ConnDB();
                SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
                my_Command.CommandText = sql;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "SeaTransport");
                rpt_Document.SetDataSource(my_DataSource);
                CrystalReportViewer.ReportSource = rpt_Document;
                DisconnMyConn();
            }
            catch (Exception ex)
            {

            }
        }

        //public static void Preview_ticket(string sql, string addonsQuery, Byte[] Photo)
        public static void Preview_ticket(string sql, string addonsQuery)
        {
            try
            {
                ReportDocument rpt_Document = new ReportDocument();
                ParameterValues ParamCollection = new ParameterValues();
                rpt_Document.Load(Application.StartupPath + "\\Reports\\sales_receipt.rpt");
                SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                dsMarsa my_DataSource = new dsMarsa();
                ConnDB();
                SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
                //my_Command.CommandText = sql;
                //my_Command.Connection = My_Connection;
                //my_Command.CommandType = CommandType.Text;
                //my_DataAdapter.SelectCommand = my_Command;
                //_ = my_DataAdapter.Fill(my_DataSource, "ClientTicket");
                //rpt_Document.SetDataSource(my_DataSource);





                //CrystalReportViewer.ReportSource = rpt_Document;
                // sous rapport des addons
                my_Command.CommandText = addonsQuery;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "AddOn");

                DisconnMyConn();

                rpt_Document.PrintOptions.PrinterName = "Microsoft Print to PDF";
                //rpt_Document.PrintOptions.PrinterName = "BIXOLON SRP-E300";
                rpt_Document.PrintToPrinter(2, false, 2, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex,"Error");
            }
        }

        public static void Preview_ticket(string sql, string queryAddons, CrystalReportViewer CrystalReportViewer)
        {
            try
            {
                ReportDocument rpt_Document = new ReportDocument();
                ParameterValues ParamCollection = new ParameterValues();
                rpt_Document.Load(Application.StartupPath + "\\Reports\\sales_receipt.rpt");
                SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                dsMarsa my_DataSource = new dsMarsa();
                ConnDB();
                SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
                my_Command.CommandText = sql;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "ClientTicket");
                rpt_Document.SetDataSource(my_DataSource);
                CrystalReportViewer.ReportSource = rpt_Document;
                DisconnMyConn();

                my_Command.CommandText = queryAddons;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "AddOn");

                //rpt_Document.PrintOptions.PrinterName = "BIXOLON SRP-E300";
                //rpt_Document.PrintToPrinter(2, false, 0, 0);
            }
            catch (Exception ex)
            {

            }
        }

        public static void Preview_TreasuryDetails(string sql, CrystalReportViewer CrystalReportViewer)
        {
            try
            {
                ReportDocument rpt_Document = new ReportDocument();
                ParameterValues ParamCollection = new ParameterValues();
                rpt_Document.Load(Application.StartupPath + "\\Reports\\rptTreasury.rpt");
                SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                dsMarsa my_DataSource = new dsMarsa();
                ConnDB();
                SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
                my_Command.CommandText = sql;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "Treasury");
                rpt_Document.SetDataSource(my_DataSource);
                CrystalReportViewer.ReportSource = rpt_Document;
                DisconnMyConn();
            }
            catch (Exception ex)
            {

            }
        }

        public static void Preview_LandingPaymentDetails(string sql, CrystalReportViewer CrystalReportViewer)
        {
            try
            {
                ReportDocument rpt_Document = new ReportDocument();
                ParameterValues ParamCollection = new ParameterValues();
                rpt_Document.Load(Application.StartupPath + "\\Reports\\rptLandingPayment.rpt");
                SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                dsMarsa my_DataSource = new dsMarsa();
                ConnDB();
                SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
                my_Command.CommandText = sql;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "LandingPayment");
                rpt_Document.SetDataSource(my_DataSource);
                CrystalReportViewer.ReportSource = rpt_Document;
                DisconnMyConn();
            }
            catch (Exception ex)
            {

            }
        }

        public static void Preview_LandingPaymentPartDetails(string sql, string amountToDisplayInWords, CrystalReportViewer CrystalReportViewer)
        {
            try
            {
                ReportDocument rpt_Document = new ReportDocument();
                ParameterValues ParamCollection = new ParameterValues();
                rpt_Document.Load(Application.StartupPath + "\\Reports\\rptLandingPaymentPart.rpt");
                SqlCommand my_Command = new SqlCommand();
#pragma warning disable IDE0067 // Supprimer les objets avant la mise hors de portée
                SqlDataAdapter my_DataAdapter = new SqlDataAdapter();
#pragma warning restore IDE0067 // Supprimer les objets avant la mise hors de portée
                dsMarsa my_DataSource = new dsMarsa();
                ConnDB();
                SqlConnection My_Connection = new SqlConnection(conn.ConnectionString);
                my_Command.CommandText = sql;
                my_Command.Connection = My_Connection;
                my_Command.CommandType = CommandType.Text;
                my_DataAdapter.SelectCommand = my_Command;
                _ = my_DataAdapter.Fill(my_DataSource, "LandingPayment");
                rpt_Document.SetDataSource(my_DataSource);
                // Get the amount and translate it to arabic words
                decimal value = 0;
                if (Decimal.TryParse(amountToDisplayInWords, out value))
                {
                    ToWord toWord = new ToWord(value, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));

                    string textInArabWord = toWord.ConvertToArabic();

                    crpAmountInArabLetters.Value = textInArabWord;
                    _ = ParamCollection.Add(crpAmountInArabLetters);
                    rpt_Document.ParameterFields["AmountInArabLettres"].CurrentValues = ParamCollection;
                }
                //Display decimal part and integer part
                string[] res = new string[2];
                if (amountToDisplayInWords.Contains('.'))
                    res = amountToDisplayInWords.Split('.');
                else
                    res = amountToDisplayInWords.Split(',');

                crpIntergerAmount.Value = res[0];
                _ = ParamCollection.Add(crpIntergerAmount);
                rpt_Document.ParameterFields["IntergerAmount"].CurrentValues = ParamCollection;


                crpDecimalAmount.Value = res[1];
                _ = ParamCollection.Add(crpDecimalAmount);
                rpt_Document.ParameterFields["DecimalAmount"].CurrentValues = ParamCollection;

                CrystalReportViewer.ReportSource = rpt_Document;
                DisconnMyConn();
            }
            catch (Exception ex)
            {

            }
        }



        public static ParameterDiscreteValue crpCashierName = new ParameterDiscreteValue();
        public static ParameterDiscreteValue crpAmountInArabLetters = new ParameterDiscreteValue();
        public static ParameterDiscreteValue crpDecimalAmount = new ParameterDiscreteValue();
        public static ParameterDiscreteValue crpIntergerAmount = new ParameterDiscreteValue();
        public static ParameterDiscreteValue crpDate = new ParameterDiscreteValue();

        /// <summary>
        /// La même méthode précedente mais avec une autre signature: pour garantir que la requete s'éxécute vraiment avant d'afficher le msg de succés
        /// </summary>
        /// <param name="SQLQuery"></param>
        /// <param name="resultat"></param>
        /// <returns></returns>
        public static DataTable ExecuteSQLQuery(string SQLQuery, out bool resultat)
        {
            sqlDT = new DataTable();
            try
            {
                SqlConnection sqlCon = new SqlConnection(conn.ConnectionString);
                SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, sqlCon);
                SqlCommandBuilder sqlCB = new SqlCommandBuilder(sqlDA);
                sqlDT.Reset();
                sqlDA.Fill(sqlDT);

                resultat = true;
            }
            catch (Exception ex)
            {
                resultat = false;
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sqlDT;
        }

        #endregion

        public enum Role
        {
            AdminSys = 1,
            Cashier = 2,
            Comptable = 3,
            EntringData = 4,
        }

        public static DataTable GetSystemSettingsData()
        {
            DataTable dtbl = new DataTable();
            try
            {

                SQLConn.sqL = "select * from SystemSettings";
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

        public static void UpdateBankAccountByID(int bankId, decimal amount, SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = "Update BankAccounts Set Balance = Balance +  @NewBalance where ID =" + bankId;

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdateBankAccountTransactions(int bankId, decimal amount, string libelle, SqlTransaction transaction)
        {
            var DT = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                SQLConn.sqL = "insert into BankAccountTransactions (Amount, BankID, Libelle,Date) values( @NewBalance, @BankID ,@Libelle,@Date)";

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@BankID", bankId);
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", libelle);
                SQLConn.cmd.Parameters.AddWithValue("@Date", DT);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdateBankAccountLandingPaymentTransactions(int bankId, decimal amount, int landingPaymentID, string libelle, SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = @"insert into BankAccountTransactions (Amount, BankID, LandingPaymentID, Libelle,Date)  
                        values( @NewBalance, @BankID ,@LandingPaymentID, @Libelle,@Date)";

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@BankID", bankId);
                SQLConn.cmd.Parameters.AddWithValue("@LandingPaymentID", landingPaymentID);
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", libelle);
                SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdateBankAccountTicketTransactions(int bankId, decimal amount, int ticketID, string libelle, SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = @"insert into BankAccountTransactions (Amount, BankID, TicketID, Libelle,Date)  
                        values( @NewBalance, @BankID ,@TicketID, @Libelle,@Date)";

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@BankID", bankId);
                SQLConn.cmd.Parameters.AddWithValue("@TicketID", ticketID);
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", libelle);
                SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        //Update Cashier Treasury 
        public static void UpdateUserTreasury(int treasuryID, decimal amount, SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = "Update Treasury Set Balance = Balance +  @NewBalance where ID = @treasuryID";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@treasuryID", @treasuryID);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdateUserTreasuryTransactions(int treasuryID, decimal amount, SqlTransaction transaction)
        {
            try
            {
                SQLConn.sqL = "insert into TreasuryTransactions (TransfertAmount, treasuryID) values( @NewBalance, @treasuryID )";

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@treasuryID", @treasuryID);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }


        public static void UpdateUserTreasuryTransactions(int treasuryID, decimal amount, SqlTransaction transaction, int bankId, string libelle)
        {
            try
            {
                SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID, BankAccountsID,Libelle, Date) 
                                    values( @NewBalance, @treasuryID,@BankAccountsID , @Libelle, @Date)";

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@treasuryID", treasuryID);
                SQLConn.cmd.Parameters.AddWithValue("@BankAccountsID", bankId);
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", libelle);
                SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdateUserTreasuryTicketTransactions(int userTreasuryID, decimal payCash, SqlTransaction trans, int? ticketId, string libelle)
        {
            try
            {
                SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, TreasuryID,TicketID, Libelle, Date) 
values( @NewBalance, @treasuryID, @TicketID, @Libelle,@Date )";

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, trans);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", payCash);
                SQLConn.cmd.Parameters.AddWithValue("@treasuryID", userTreasuryID);
                SQLConn.cmd.Parameters.AddWithValue("@TicketID", ticketId);
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", libelle);
                SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static int GetTreasuryIDForCurrentUser(int userid)
        {
            int ID = 0;
            try
            {
                SQLConn.sqL = "Select ID From Treasury Where UserID = @id";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL,SQLConn.conn,SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@id", userid);
                var dr = SQLConn.cmd.ExecuteScalar();
                if (dr != null)
                {
                    ID = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
                    Data.UserTreasuryID = ID;
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
            return ID;
        }
        public static int GetPrincipalTreasuryID()
        {
            int ID = 0;
            try
            {
                SQLConn.sqL = "Select top(1) ID From Treasury Where name=@name";

                SQLConn.ConnDB();

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@name", Common.TreasuryPrincipalName);

                if (SQLConn.cmd.ExecuteScalar() != null)
                {
                    ID = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
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
            return ID;
        }

        //public static int GetPrincipalTreasuryID(SqlTransaction transaction)
        public static int GetPrincipalTreasuryID(int ID)
        {
            var Accountid = 0;
            try
            {
                SQLConn.sqL = "Select ID From Treasury Where UserID = @id";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@id", ID);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read())
                {
                    Accountid = Convert.ToInt32(SQLConn.dr["ID"].ToString());
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
            SQLConn.ConnDB();
            //int ID = 0;
            //try
            //{
            //    SQLConn.sqL = "Select top(1) ID From Treasury Where name=@name";

            //    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
            //    SQLConn.cmd.Parameters.AddWithValue("@name", Common.TreasuryPrincipalName);

            //    if (SQLConn.cmd.ExecuteScalar() != null)
            //    {
            //        ID = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Interaction.MsgBox(ex.ToString());
            //}
            return Accountid;
        }

        public static void UpdatePrincipalTreasuryBalance(decimal amount, SqlTransaction transaction)
        {
            try
            {
                //SQLConn.sqL = "Update Treasury Set Balance = Balance +  @NewBalance where name=@name";
                //SQLConn.ConnDB();
                //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                //SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                //SQLConn.cmd.Parameters.AddWithValue("@name", Common.TreasuryPrincipalName);
                //SQLConn.cmd.Parameters.AddWithValue("@UserID", Data.UserID);
                //SQLConn.cmd.ExecuteNonQuery();

                var Qur = @"Update Treasury Set Balance = Balance +  @NewBalance where UserID=@UserID";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(Qur, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@UserID", Data.UserID);
                SQLConn.cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdatePrincipalTreasuryTransactions(decimal amount, SqlTransaction transaction)
        {
            try
            {
                int treasuryID = GetPrincipalTreasuryID(Data.UserID);
                if (treasuryID > 0)
                {
                    SQLConn.sqL = "insert into TreasuryTransactions (TransfertAmount, treasuryID) values( @NewBalance, @treasuryID )";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", treasuryID);
                    SQLConn.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdatePrincipalTreasuryExpensesTransactions(decimal amount, SqlTransaction trans, int expensesId, string libelle)
        {
            try
            {
                int treasuryID = GetPrincipalTreasuryID(Data.UserID);
                if (treasuryID > 0)
                {
                    SQLConn.sqL = "insert into TreasuryTransactions (TransfertAmount, treasuryID, ExpensesID,Libelle, Date) values( @NewBalance, @treasuryID,@ExpensesID ,@Libelle,@Date)";
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, trans);
                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", treasuryID);
                    SQLConn.cmd.Parameters.AddWithValue("@ExpensesID", expensesId);
                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", libelle);
                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    SQLConn.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdatePrincipalTreasuryIncomeTransactions(decimal amount, SqlTransaction transaction, int? selectedIncomeID, string text)
        {
            try
            {
                int treasuryID = GetPrincipalTreasuryID(Data.UserID);
                if (treasuryID > 0)
                {
                    SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID, IncomeID,Libelle, Date) 
                                    values( @NewBalance, @treasuryID, @IncomeID, @Libelle,@Date)";

                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", treasuryID);
                    SQLConn.cmd.Parameters.Add(SetDBNullIfEmpty("@IncomeID", selectedIncomeID + " "));//Add(SetDBNullIfEmpty("@DriverNIDImage", NIDImage));
                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", text);
                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    SQLConn.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdateTreasuryStartingTransactions(int treasuryID, decimal amount, SqlTransaction transaction, string text)
        {
            try
            {
                SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID, Libelle, Date) 
                                    values( @NewBalance, @treasuryID, @Libelle, @Date)";

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@treasuryID", treasuryID);
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", text);
                SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                SQLConn.cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdatePrincipalTreasuryIncomeFromCashierTransactions(decimal amount, SqlTransaction transaction, int? selectedIncomeID, string text)
        {
            try
            {
                int treasuryID = GetPrincipalTreasuryID(Data.UserID);
                if (treasuryID > 0)
                {
                    SQLConn.sqL = @"insert into TreasuryTransactions (TransfertAmount, treasuryID, IncomeFromCashierID,Libelle, Date) 
                                    values( @NewBalance, @treasuryID, @IncomeFromCashierID, @Libelle,@Date)";

                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                    SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                    SQLConn.cmd.Parameters.AddWithValue("@treasuryID", treasuryID);
                    SQLConn.cmd.Parameters.AddWithValue("@IncomeFromCashierID", selectedIncomeID);
                    SQLConn.cmd.Parameters.AddWithValue("@Libelle", text);
                    SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    SQLConn.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        public static void UpdatePrincipalTreasuryIncomeFromCashierTransactions(int treasuryID, decimal amount, SqlTransaction transaction, int? selectedIncomeID, string text)
        {
            try
            {
                SQLConn.sqL = @"insert into TreasuryTransactions(TransfertAmount, treasuryID, IncomeFromCashierID, Libelle, Date) 
                                    values(@NewBalance, @treasuryID, @IncomeFromCashierID, @Libelle,@Date)";

                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                SQLConn.cmd.Parameters.AddWithValue("@treasuryID", @treasuryID);
                SQLConn.cmd.Parameters.AddWithValue("@IncomeFromCashierID", selectedIncomeID);
                SQLConn.cmd.Parameters.AddWithValue("@Libelle", text);
                SQLConn.cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }



        public static void InsertException()
        {
            try
            {
                //SQLConn.sqL = "insert into BankAccountTransactions (Amount, BankID) values( @NewBalance, @BankID )";
                //SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, transaction);
                //SQLConn.cmd.Parameters.AddWithValue("@NewBalance", amount);
                //SQLConn.cmd.Parameters.AddWithValue("@BankID", bankId);
                //SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }


        public static int GetExistingBankAccountIDByName(string name)
        {
            int ID = 0;
            try
            {
                string sql = "";
                if (!name.Equals(Common.BankAccountPrincipalName) && !name.Contains(Common.BankAccountPrincipalName))
                {
                    sql = "Select top(1) ID From BankAccounts Where (name=@name) ";
                }
                else if (name.Equals(Common.BankAccountPrincipalName) || name.Contains(Common.BankAccountPrincipalName))
                {
                    sql = "Select top(1) ID From BankAccounts Where (name=@name) ";
                    name = Common.BankAccountPrincipalName;
                    return 1;
                }
                SQLConn.sqL = sql;
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);
                SQLConn.cmd.Parameters.AddWithValue("@name", name);

                if (SQLConn.cmd.ExecuteScalar() != null)
                {
                    ID = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
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
            return ID;
        }


        public static SqlParameter SetDBNullIfEmpty(string Parmname, string Parmvalue)
        {
            return new SqlParameter(Parmname, String.IsNullOrEmpty(Parmvalue) ? DBNull.Value : (object)Parmvalue);
        }


        public static int GetBankAccountID()
        {
            int id = 0;
            try
            {
                SQLConn.sqL = "Select top(1) ID From BankAccounts";
                //SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn, SQLConn.trans);

                if (SQLConn.cmd.ExecuteScalar() != null)
                {
                    id = Convert.ToInt32(SQLConn.cmd.ExecuteScalar());
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
            return id;
        }

        public static DataTable GetCustomerByNID(string NID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = "select ID, Name, Mobile , NID from Customers Where NID = '" + NID + "'";
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

        public static DataTable GetCustomerByMobile(string Mobile)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = "select ID,Name,Mobile,NID from Customers Where Mobile = '" + Mobile + "'";
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

        public static DataTable GetCardAndCashTicketByID(int ticketID)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SQLConn.sqL = "Select PayCash, PayCard, UserID from Tickets Where ID = " + ticketID + "";
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
    }
}

