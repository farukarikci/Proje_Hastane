﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string tc;

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;

            SqlCommand komut = new SqlCommand("Select  HastaAd,HastaSoyad From Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + "  " + dr[1];
                
            }
            bgl.baglanti();

            // Randevu Geçmişi

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  * From Tbl_Randevu Where HastaTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Branş Çekme

            SqlCommand komut2 = new SqlCommand(" Select BransAd From Tbl_Branslar", bgl.baglanti());

;           SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();



        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoctor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",CmbBrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();

            while (dr3.Read())
            {
                CmbDoctor.Items.Add(dr3[0]+" "+dr3[1]);

            }
            bgl.baglanti().Close();
        }

        private void CmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevu Where RandevuBrans ='" + CmbBrans.Text + "'", bgl.baglanti());

            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void LnkBilgiDüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.TCNo = LblTC.Text;
            fr.Show();

        }
    }
}
