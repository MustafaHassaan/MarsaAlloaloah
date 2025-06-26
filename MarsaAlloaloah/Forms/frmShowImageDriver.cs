using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{

    
    public partial class frmShowImageDriver : Form
    {
        byte[] Logo;
        public frmShowImageDriver()
        {
            InitializeComponent();
        }

        private void frmShowImageDriver_Load(object sender, EventArgs e)
        {

            Logo = frmdriversAndListing.SelectedImage;
            MemoryStream ms = new MemoryStream(Logo);
            Image newimage = Image.FromStream(ms);
            pictureBox1.Image = newimage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("هل تريد بالتأكيد الإنهاء", "عرض الصور", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog Pd = new PrintDialog();
            PrintDocument PD = new PrintDocument();
            PD.PrintPage += Printimg;
            Pd.Document = PD;
            if (Pd.ShowDialog() == DialogResult.OK)
            {
                PD.Print();
            }
        }
        private void Printimg(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }
    }
}
