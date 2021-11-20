using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Gripper_Design
{
    public partial class RubberProperty : UserControl
    {
        int Hardness_state = 0, Hardness_value = 0;
        public RubberProperty()
        {
            InitializeComponent();
        }
        public int HNState
        {
            get
            {
                //System.Diagnostics.Debug.WriteLine("Support_value: {0}", Support_value);
                return this.Hardness_state;
            }
            set
            {
                this.Hardness_state = value;
            }
        }
        public int HN_value
        {
            get
            {
                return this.Hardness_value;
            }
            set
            {
                this.Hardness_value = value;
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Hardness_state = 1;
            if (numericUpDown1.Value != null)
            {
                Hardness_value = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
                System.Diagnostics.Debug.WriteLine("Hardness: {0}", Hardness_value);
            }
        }
    }
}
