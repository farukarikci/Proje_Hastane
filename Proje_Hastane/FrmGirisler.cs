﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris fr = new FrmSekreterGiris();
            fr.Show();
            this.Hide();

        }

        private void FrmGirisler_Load(object sender, EventArgs e)
        {

        }

        private void BtnDoktorGiris_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris fr = new FrmDoktorGiris();
            fr.Show();
            this.Hide();
        }

        private void BtnHastaGiris_Click(object sender, EventArgs e)
        {

            FrmHastaGiris fr = new FrmHastaGiris();

            fr.Show();
            this.Hide();

            {

            };
        }
    }
}