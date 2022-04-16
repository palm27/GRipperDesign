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
    public partial class DraftRigid_1 : UserControl
    {
        public DraftRigid_1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public Label NumberOfGripper
        {
            get
            {
                return this.label7;
            }
            set
            {
                this.label7 = value;
            }
        }
        public Label GrippingForce_Label
        {
            get
            {
                return this.label4;
            }
            set
            {
                this.label4 = value;
            }
        }
    }
}
