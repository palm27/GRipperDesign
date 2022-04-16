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
        int Box_state = 0, Cavities = 0;
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Box_state = 1;
            if (textBox1.Text != null)
            {
                Cavities = int.Parse(textBox1.Text);
            }
        }

        public Mold()
        {
            InitializeComponent();
        }
    
    }
}
