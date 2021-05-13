using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Gripper_Design
{
    public partial class CombineShape : UserControl
    {
        int Mass_1 = 0, Support =0;
        public CombineShape()
        {
            InitializeComponent();
        }

        private void CombineShape_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }
        public int Mass_value
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Mass_1: {0}", Mass_1);
                return this.Mass_1;
            }
            set
            {
                this.Mass_1 = value;
            }
        }
        public int Support_value
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Support_value: {0}", Support);
                return this.Support;
            }
            set
            {
                this.Support = value;
            }
        }
        public PictureBox Set_picture
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Mass_1: {0}", Mass_1);
                return this.pictureBox1;
            }
            set
            {
                this.pictureBox1 = value;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                Mass_1 = int.Parse(textBox1.Text);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.CheckState == CheckState.Checked)
            {
                Support = 1;
                System.Diagnostics.Debug.WriteLine("Checked");
                System.Diagnostics.Debug.WriteLine(Support);
            }
            else
            {
                Support = 0;
                System.Diagnostics.Debug.WriteLine("not Checked");
                System.Diagnostics.Debug.WriteLine(Support);
            }
            
        }
    }
}
