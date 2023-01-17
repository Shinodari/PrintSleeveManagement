﻿using PrintSleeveManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintSleeveManagement
{
    public partial class ShipForm : Form
    {
        Ship ship;
        BindingSource bindingSoruce;

        public ShipForm()
        {
            InitializeComponent();

            DataRefresh();
        }

        private void DataRefresh()
        {
            ship = new Ship();
            bindingSoruce = new BindingSource();
            bindingSoruce.DataSource = ship.ShipList;
            dataGridViewShip.DataSource = bindingSoruce;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DataRefresh();
        }

        private void buttonShip_Click(object sender, EventArgs e)
        {

        }
    }
}
