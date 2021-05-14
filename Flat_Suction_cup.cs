using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRipperDesign
{
    public partial class Flat_Suction_cup : Form
    {
        public Flat_Suction_cup()
        {
            InitializeComponent();
        }

        private void Flat_Suction_cup_Load(object sender, EventArgs e)
        {
            PictureBox pb1 = new PictureBox();
            pb1.ImageLocation = "C:/Users/palmdotax/source/repos/GRipperDesign/Picture/Flat.png";
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
