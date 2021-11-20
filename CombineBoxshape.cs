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
    public partial class CombineBoxshape : UserControl
    {
        int Box_state = 0, Mass_1 = 0;
        int Box2_state = 0, A = 0;
        int Box3_state = 0, B = 0;
        int Box4_state = 0, C = 0;
        public CombineBoxshape()
        {
            InitializeComponent();
        }

       

        public int boxState
        {
            get
            {
                //System.Diagnostics.Debug.WriteLine("Support_value: {0}", Support_value);
                return this.Box_state;
            }
            set
            {
                this.Box_state = value;
            }
        }
        public int boxState2
        {
            get
            {
                //System.Diagnostics.Debug.WriteLine("Support_value: {0}", Support_value);
                return this.Box2_state;
            }
            set
            {
                this.Box2_state = value;
            }
        }
        public int boxState3
        {
            get
            {
                //System.Diagnostics.Debug.WriteLine("Support_value: {0}", Support_value);
                return this.Box3_state;
            }
            set
            {
                this.Box3_state = value;
            }
        }
        public int boxState4
        {
            get
            {
                //System.Diagnostics.Debug.WriteLine("Support_value: {0}", Support_value);
                return this.Box4_state;
            }
            set
            {
                this.Box4_state = value;
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
                this.Mass_1 = value;
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

        private void CombineBoxshape_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Box_state = 1;
            if (textBox1.Text != null)
            {
                Mass_1 = int.Parse(textBox1.Text);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Box2_state = 1;
            if (textBox2.Text != null)
            {
                A = int.Parse(textBox2.Text);
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Box3_state = 1;
            if (textBox3.Text != null)
            {
                B = int.Parse(textBox3.Text);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Box4_state = 1;
            if (textBox4.Text != null)
            {
                C = int.Parse(textBox4.Text);
            }
        }
    }
}
