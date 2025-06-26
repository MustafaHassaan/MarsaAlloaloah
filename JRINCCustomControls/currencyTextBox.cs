using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace JRINCCustomControls
{
    /// <summary>
    /// This class is taken from the link : https://www.codeproject.com/Articles/248989/A-Currency-Masked-TextBox-from-TextBox-Class
    /// And then I have Add some modification
    /// </summary>
    public partial class CurrencyTextBox : TextBox
    {
        /// <summary>
        /// 
        /// </summary>
        public CurrencyTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public CurrencyTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public CurrencyTextBox(IContainer container, char thousandsSeparator, char decimalsSeparator, int decimalPlaces)
        {
            container.Add(this);

            InitializeComponent();

            _thousandsSeparator = thousandsSeparator;
            _decimalsSeparator = decimalsSeparator;
            _decimalPlaces = decimalPlaces;
        }

        string strZero = "00";// Minimuim c'est 2 décimales
        private string _workingText, _preFix;
        // Initialisation des valeurs par défaut
        private char _thousandsSeparator = ' ', _decimalsSeparator = '.';
        private int _decimalPlaces = 2;

        /// <summary>
        /// Contains the entered text without mask.
        /// </summary>
        public string WorkingText
        {
            get { return _workingText; }
            private set { _workingText = value; }
        }

        /// <summary>
        /// Contains the prefix that preceed the inputted text.
        /// </summary>
        public string PreFix
        {
            get { return _preFix; }
            set { _preFix = value; }
        }

        /// <summary>
        /// Contains the separator symbol for thousands.
        /// </summary>
        public char ThousandsSeparator
        {
            get { return _thousandsSeparator; }
            set { _thousandsSeparator = value; }

        }

        /// <summary>
        /// Contains the separator symbol for decimals.
        /// </summary>
        public char DecimalsSeparator
        {
            get { return _decimalsSeparator; }
            set { _decimalsSeparator = value; }
        }

        /// <summary>
        /// Indicates the total places for decimal values.
        /// </summary>
        public int DecimalPlaces
        {
            get { return _decimalPlaces; }
            set
            {
                _decimalPlaces = value;
                if (_decimalPlaces > 2)
                {
                    // Construire la chaine suivant this.DecimalPlaces                
                    for (int i = 2; i < DecimalPlaces; i++)
                    {
                        NewMethod();
                    }
                }
            }
        }

        private void NewMethod()
        {
            strZero = strZero + "0";
        }

        /// <summary>
        /// Formats the entered text.
        /// </summary>
        /// <returns></returns>
        public string formatText()
        {
            WorkingText = Text.Replace((_preFix != "") ? _preFix : " ", String.Empty)
                                        .Replace((_thousandsSeparator.ToString() != "") ? _thousandsSeparator.ToString() : " ", String.Empty)
                                        .Replace((_decimalsSeparator.ToString() != "") ? _decimalsSeparator.ToString() : " ", String.Empty).Trim();
            int counter = 1;
            int counter2 = 0;
            char[] charArray = WorkingText.ToCharArray();
            StringBuilder str = new StringBuilder();

            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                _ = str.Insert(0, charArray.GetValue(i));
                if (DecimalPlaces == 0 && counter == 3)
                {
                    counter2 = counter;
                }

                if (counter == DecimalPlaces && i > 0)
                {
                    if (_decimalsSeparator != Char.MinValue)
                        _ = str.Insert(0, _decimalsSeparator);
                    counter2 = counter + 3;
                }
                else if (counter == counter2 && i > 0)
                {
                    if (_thousandsSeparator != Char.MinValue)
                        _ = str.Insert(0, _thousandsSeparator);
                    counter2 = counter + 3;
                }
                counter = ++counter;
            }
            return (_preFix != "" && str.ToString() != "") ? _preFix + " " + str.ToString() : (str.ToString() != "") ? str.ToString() : "";
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (!string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(_decimalsSeparator.ToString()))
            {
                string[] splitByDecimal = Text.Split(_decimalsSeparator);
                // Si le nombre de caractère aprés la virgule est > nbre de décimales alors effacer les nombres en plus
                if (splitByDecimal.Length > 1 && splitByDecimal[1].Length > DecimalPlaces)
                {
                    int longeurASuppr = (splitByDecimal[1].Length - DecimalPlaces);
                    Text = Text.Remove(Text.Length - longeurASuppr, longeurASuppr);
                }

                Text = string.Format("{0:n" + DecimalPlaces + "}", double.Parse(Text));
            }
            base.OnLostFocus(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            //this.Text = this.WorkingText;
            base.OnGotFocus(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            string senderText = Text;
            string[] splitByDecimal = senderText.Split(_decimalsSeparator);
            int cursorPosition = SelectionStart;

            char ch = e.KeyChar;
            if (ch == 46 && senderText.IndexOf(_decimalsSeparator) != -1)
            {
                if (splitByDecimal.Length > 1
                    && ((splitByDecimal[1].Length == DecimalPlaces && splitByDecimal[1] == strZero)
                          || (splitByDecimal[1].Length > 0 && Double.Parse(splitByDecimal[1]) == 0)))
                {
                    Text = Text.Remove(Text.Length - splitByDecimal[1].Length, splitByDecimal[1].Length);
                    SelectionStart = splitByDecimal[0].Length + 1;

                    e.Handled = true;
                    return;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }


            if (!char.IsControl(ch) && senderText.IndexOf(_decimalsSeparator) < cursorPosition
                && splitByDecimal.Length > 1
                && splitByDecimal[1].Length == DecimalPlaces)
            {
                e.Handled = true;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (Char)13 || e.KeyChar == (Char)9)// 13 pour Entrée  && 9 pour TAB
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    // Si le nombre de caractère aprés la virgule est > nbre de décimales aors effacer les nombres en plus
                    if (splitByDecimal.Length > 1 && splitByDecimal[1].Length > DecimalPlaces)
                    {
                        int longeurASuppr = (splitByDecimal[1].Length - DecimalPlaces);
                        Text = Text.Remove(Text.Length - longeurASuppr, longeurASuppr);
                    }

                    if (Text.Contains(".") && CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator ==",")
                        Text = Text.Replace('.', ',');

                    Text = string.Format("{0:n" + DecimalPlaces + "}", double.Parse(Text));

                    if (Text.Contains(".") && CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
                        Text = Text.Replace(',', '.');

                }
            }

            base.OnKeyPress(e);
        }
    }
}
