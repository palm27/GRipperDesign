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
    public partial class DraftRigid_Support : UserControl
    {
        public DraftRigid_Support()
        {
            InitializeComponent();
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
