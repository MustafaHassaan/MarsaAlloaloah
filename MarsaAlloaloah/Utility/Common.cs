using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah.Utility
{
    public static class Common
    {
        public const string TreasuryPrincipalName = "الخزينة الإفتراضية";
        public const string BankAccountPrincipalName = "حساب البنك الإفتراضى";
        public const string LocalDriverName = "سائق محلى للمرسى";

        public static  DateTime GetGregorianDate(string day, string month, string year)
        {

            int Day = int.Parse(day);
            int Month = int.Parse(month);
            int Year = int.Parse(year);


            DateTime hijiri = new DateTime(Year, Month, Day, new HijriCalendar());

            var calendar = new GregorianCalendar();
            // var hijiri = ...; // The DateTime value
            var GregorianYear = calendar.GetYear(hijiri);
            var GregorianMonth = calendar.GetMonth(hijiri);
            var GregorianDay = calendar.GetDayOfMonth(hijiri);
            DateTime date = new DateTime(GregorianYear, GregorianMonth, GregorianDay, new GregorianCalendar());
            return date;
        }

        public static Decimal ConvertTxtToDecimal(string text)
        {
            decimal value = 0;
            Decimal.TryParse(text, out value);
            return value;
        }

        public static string ConvertCurrencyFieldToStringOnSqlQuery(string currencyText)
        {
            double currency = num_repl(currencyText);
            return currency.ToString().Replace(',', '.');
        }

        /// <summary>
        /// Convert string to double value
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double num_repl(string a)
        {
            if (double.TryParse(a, out double n))

                return n;
            else
                return 0;
        }

        public static string MettreEnFormeMontantDecimal(string text)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
            {
                try
                {
                    double capital = 0D;
                    if (double.TryParse(text.Trim(), out capital))
                    {
                        text = String.Format("{0:n2}", capital);
                    }
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Erreur dans la méthode MettreEnFormeMontantDecimal, ex=" + ex.Message);
                }
            }
            return text;
        }
    }
}
