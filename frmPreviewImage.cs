using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarSellingSystem
{
    public partial class frmPreviewImage : Form
    {
        public frmPreviewImage()
        {
            InitializeComponent();
        }

        public string image_path = "";

        private void frmPreviewImage_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            if (!string.IsNullOrEmpty(image_path))
            {
                pictureBox1.Image = Image.FromFile(image_path);
            }
        }
    }
}
