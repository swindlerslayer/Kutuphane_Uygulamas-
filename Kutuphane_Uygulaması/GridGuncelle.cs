﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane_Uygulaması.Data;

namespace Kutuphane_Uygulaması
{
    public partial class GridGuncelle : Form
    {
        private object acilankisi;
        public GridGuncelle(object acilankisi)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


            this.acilankisi = acilankisi;
            int _id = Convert.ToInt32(acilankisi);
            // veya int _id = int.Parse(acilankisi.ToString());
            var data = DbKitap.KitapGetir(_id);
            if (data != null)
            {
                textEdit1.Text = data.Adi;
                textEdit2.Text = data.SayfaSayisi.ToString();
                searchLookUpEdit1.EditValue = data.KitapTurID;
                searchLookUpEdit2.EditValue = data.YayinEviID;
                searchLookUpEdit3.EditValue = data.YazarID;
                textEdit3.Text = data.Barkod.ToString();
                label1.Text = data.ID.ToString();


            }

        }

        private void GridGuncelle_Load(object sender, EventArgs e)
        {
            searchLookUpEdit1.Properties.DataSource = DbKitapTuru.ListeyeEkle();
            searchLookUpEdit2.Properties.DataSource = DbYayinEvi.ListeyeEkle();
            searchLookUpEdit3.Properties.DataSource = DbYazar.ListeyeEkle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int silinecek = Int32.Parse(label1.Text);
            string ss = textEdit2.Text;
            string barkod = textEdit3.Text;
            Kitap selectedKitap = new Kitap(); // selectedKitap değişkenine yeni bir Kitap nesnesi oluşturulmalıdır

            selectedKitap.KayitYapan = label1.Text;
            selectedKitap.Adi = textEdit1.Text;
            selectedKitap.KitapTurID = (int)searchLookUpEdit1.EditValue;
            selectedKitap.YazarID = (int)searchLookUpEdit2.EditValue;
            selectedKitap.YayinEviID = (int)searchLookUpEdit3.EditValue;
            selectedKitap.SayfaSayisi = Int32.Parse(ss);
            selectedKitap.Barkod = Int32.Parse(barkod);
            selectedKitap.ID = silinecek;
            bool güncellendi = DbKitap.EkleDuzenle(selectedKitap);
            if (güncellendi)
            {
                MessageBox.Show("????");

                gridControl1.DataSource = DbKitap.ListeyeEkle();
            }
            else
            {
                MessageBox.Show("Kitap Başarıyla Güncellendi");
                gridControl1.DataSource = DbKitap.ListeyeEkle();

            }
        }
    }
}
