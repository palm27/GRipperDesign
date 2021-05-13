using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRipperDesign
{
    public partial class Topview : UserControl
    {
        int Shape_index = 0;
        public Topview()
        {
            InitializeComponent();
        }
        public ComboBox Topshape
        {
            get
            {
               // System.Diagnostics.Debug.WriteLine("Mass_1: {0}", Mass_1);
                return this.comboBox1;
            }
            set
            {
                this.comboBox1 = value;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shape_index = comboBox1.SelectedIndex;
            pictureBox1.Image = imageList1.Images[Shape_index];
        }
    }
}
