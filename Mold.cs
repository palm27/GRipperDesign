using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Gripper_Design
{
    public partial class Mold : UserControl
    {
        int Box_state = 0, Cavities = 0, X_mold = 0, Y_mold = 0;
        public int Cavity_N
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Cavities: {0}", Cavities);
                return this.Cavities;
            }
            set
            {
                this.Cavities = value;
            }
        }
        public int XMold
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Width: {0}", X_mold);
                return this.X_mold;
            }
            set
            {
                this.X_mold = value;
            }
        }
        public int YMold
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Lenght: {0}", Y_mold);
                return this.Y_mold;
            }
            set
            {
                this.Y_mold = value;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Box_state = 1;
            if (textBox1.Text != null)
            {
                Cavities = int.Parse(textBox1.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
            {
                X_mold = int.Parse(textBox2.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != null)
            {
                Y_mold = int.Parse(textBox3.Text);
            }
        }

        public Mold()
        {
            InitializeComponent();
        }
    
    }
}
