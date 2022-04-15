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
        int Box1_state = 1,Mass_1 = 0, Support =0;
        int Box2_state = 0, A = 0;
        int Box3_state = 0, B = 0;
        int Box4_state = 0, C = 0;
        int Box5_state = 0, D = 0;
        int Box6_state = 0, E = 0;
        int Box7_state = 0, F = 0;
        public CombineShape()
        {
            InitializeComponent();
        }

        private void CombineShape_Load(object sender, EventArgs e)
        {

        }

        public int boxState
        {
            get
            {
                //System.Diagnostics.Debug.WriteLine("Support_value: {0}", Support_value);
                return this.Box1_state;
            }
            set
            {
                this.Box1_state = value;
            }
        }
        
        public int A_value
        {
            get
            {

                return this.A;
            }
            set
            {
                this.A = value;
            }
        }
        public int B_value
        {
            get
            {

                return this.B;
            }
            set
            {
                this.B = value;
            }
        }
        public int C_value
        {
            get
            {

                return this.C;
            }
            set
            {
                this.C = value;
            }
        }
        public int D_value
        {
            get
            {

                return this.D;
            }
            set
            {
                this.D = value;
            }
        }
        public int E_value
        {
            get
            {

                return this.E;
            }
            set
            {
                this.E = value;
            }
        }
        public int F_value
        {
            get
            {

                return this.F;
            }
            set
            {
                this.F = value;
            }
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
                System.Diagnostics.Debug.WriteLine("Mass_1: {0}", Mass_1);
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
                System.Diagnostics.Debug.WriteLine("show_Mass: {0}", Mass_1);
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
