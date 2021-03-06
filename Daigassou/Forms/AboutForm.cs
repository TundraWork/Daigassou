﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Daigassou.Input_Midi;

namespace Daigassou
{
    public partial class AboutForm : Form
    {
        private KeyController kc;
        public AboutForm(KeyController _kc)
        {
            kc = _kc;
            InitializeComponent();
        }

        private int ClickCount = 0;
        private void AboutForm_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Ver " + Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/TundraWork/Daigassou");
        }
    }
}
