using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    public partial class frmHijriDate : Form
    {
        public frmHijriDate()
        {
            InitializeComponent();
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public string TextboxDay
        {
            get { return txtDay.Text; }
            private set { txtDay.Text = value; }
        }
        public string TextboxMonth
        {
            get { return txtMonth.Text; }
            private set { txtMonth.Text = value; }
        }

        public string TextboxYear
        {
            get { return txtYear.Text; }
            private set { txtYear.Text = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
