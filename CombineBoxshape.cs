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
    }
}
