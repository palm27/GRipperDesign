using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Gripper_Design
{
    public partial class Factor : UserControl
    {
        public Factor()
        {
            InitializeComponent();
        }
        public PictureBox Set_picture
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("picture");
                return this.pictureBox1;
            }
            set
            {
                this.pictureBox1 = value;
            }
        }
        public Label Mass_result
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
        public Label DemoldingForce
        {
            get
            {
                return this.label6;
            }
            set
            {
                this.label6 = value;
            }
        }
        public Label Gripper_type
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
    }
}
