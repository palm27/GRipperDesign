using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GRipperDesign;

namespace Gripper_Design
{
    public partial class DraftVacuumGripper : UserControl
    {
        //bool Picture_state = false;

        public DraftVacuumGripper()
        {
            InitializeComponent();
        }
        public Label NumberOfCup
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
        public Label NumberOfVacuum
        {
            get
            {
                return this.label11;
            }
            set
            {
                this.label11 = value;
            }
        }
        public Label PadDiameter
        {
            get
            {
                return this.label9;
            }
            set
            {
                this.label9 = value;
            }
        }
        //public bool state
        //{
        //    get
        //    {
        //        return this.Picture_state;
        //    }
        //    set
        //    {
        //        this.Picture_state = value;
        //    }
        //}


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DraftVacuumGripper_Load(object sender, EventArgs e)
        {

        }
       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            //Picture_state = true;

            Flat_Suction_cup NewForm = new Flat_Suction_cup();
            NewForm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Vacuum_Ejector vc = new Vacuum_Ejector();
            vc.Show();
        }
        // To see Suction

    }
}
