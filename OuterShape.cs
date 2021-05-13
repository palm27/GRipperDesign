﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Gripper_Design
{
    public partial class OuterShape : UserControl
    {
        int Shape_index = 0;
        public OuterShape()
        {
            InitializeComponent();
        }

        private void OuterShape_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }
        public int OuterShape_index
        {
            get
            {
                //System.Diagnostics.Debug.WriteLine("Mass_1: {0}", Mass_1);
                return this.Shape_index;
            }
            set
            {
                this.Shape_index = value;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shape_index = comboBox1.SelectedIndex;
            pictureBox1.Image = imageList1.Images[Shape_index];
        }
    }
}
