using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using Kutuphane_Uygulaması.Data;
using static Kutuphane_Uygulaması.Data.Degiskenler;

namespace Kutuphane_Uygulaması
{
    public partial class AnaGirisForm : Form
    {
        private OKgrid okgrid;
        private string kullaniciadi;
        private int kullaniciid;
        public AnaGirisForm(EntityKullanici kullanici)
        {
            InitializeComponent();
            okgrid = new OKgrid();
            kullaniciadi = kullanici.KullaniciAdi;
            kullaniciid = kullanici.ID;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void AnaGirisForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = okgrid.GetGridDoldur();

        }

    
       

        private void KitapEkleButton_Click(object sender, EventArgs e)
        {
            KullaniciGirisForm frm = new KullaniciGirisForm(kullaniciadi);
                frm.Show();

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void OgrenciKitapButton_Click(object sender, EventArgs e)
        {
            OgrenciKitapForm frm = new OgrenciKitapForm(kullaniciid);
            frm.Show();
        }

        private void OgrenciEkleButton_Click(object sender, EventArgs e)
        {
            OgrenciEkleForm frm = new OgrenciEkleForm();
            frm.Show();

        }

        private void YazarEkleButton_Click(object sender, EventArgs e)
        {
            YazarEkleForm frm = new YazarEkleForm(kullaniciadi);
            frm.Show();
        }

        private void YayıneviEkleButton_Click(object sender, EventArgs e)
        {
            YayineviEkleForm frm = new YayineviEkleForm(kullaniciadi);
            frm.Show();
        }

        private void KitapTurEkleButton_Click(object sender, EventArgs e)
        {
            KitapTurEkleForm frm = new KitapTurEkleForm(kullaniciadi);
            frm.Show();

        }

        private void AnaGirisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
             Application.Exit();

        }
    }
}
