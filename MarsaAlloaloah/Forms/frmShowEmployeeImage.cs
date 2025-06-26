using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{

    
    public partial class frmShowEmployeeImage : Form
    {
        byte[] Logo;
        public frmShowEmployeeImage()
        {
            InitializeComponent();
        }

        private void frmShowEmployeeImage_Load(object sender, EventArgs e)
        {
            
            Logo = frmemployees.SelectedImage;
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
    }
}
