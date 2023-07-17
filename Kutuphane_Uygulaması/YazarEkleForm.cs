using System;
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
    public partial class YazarEkleForm : Form
    {
        private string kullaniciiD;

        public YazarEkleForm(string KullaniciID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.kullaniciiD = KullaniciID;
            gridControl1.DataSource = DbYazar.ListeyeEkle();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            string yazaradi;
            yazaradi = textEdit1.Text;
            Yazar yazar = new Yazar();
            yazar.AdiSoyadi = yazaradi;
            yazar.KayitTarihi = DateTime.Now;
            yazar.KayitYapan = kullaniciiD;

            bool kontrol = DbYazar.YK(yazar);
            if(kontrol != true)
            {

            bool kaydedildi = DbYazar.EkleDuzenle(yazar);
            if (kaydedildi)
            {
                MessageBox.Show("Yazar başarıyla kaydedildi");
                gridControl1.DataSource = DbYazar.ListeyeEkle();
            }
            else
            {
                MessageBox.Show("Yazar kaydedilirken bir hata oluştu");
            }

            }
            else
            {
                MessageBox.Show("Bu isim halihazırda kayıtlı");

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (gridView1.GetFocusedRow() is Yazar selectedyazar)
            {
                string yeniAdi = textEdit1.Text;

                selectedyazar.AdiSoyadi = yeniAdi;

                selectedyazar.KayitTarihi = DateTime.Now;
                selectedyazar.KayitYapan = kullaniciiD;

                bool kaydedildi = DbYazar.EkleDuzenle(selectedyazar);
                if (kaydedildi)
                {
                    MessageBox.Show("????");

                    gridControl1.DataSource = DbYazar.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Yazar Başarıyla Güncellendi");
                    gridControl1.DataSource = DbYazar.ListeyeEkle();

                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {


            if (gridView1.GetFocusedRow() is Yazar selectedYazar)
            {
                string silinecek = textEdit1.Text;

                selectedYazar.AdiSoyadi = silinecek;

                bool kaydedildi = DbYazar.sil(selectedYazar);
                if (kaydedildi)
                {
                    MessageBox.Show("yazar başarıyla Silindi");

                    gridControl1.DataSource = DbYazar.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Yazar Silinemedi");
                    gridControl1.DataSource = DbYazar.ListeyeEkle();
                }
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

            object deneme12 = gridView1.GetFocusedRowCellValue("AdiSoyadi");
            if (deneme12 != null)
            {
                textEdit1.Text = deneme12.ToString();
            }
        }

    }
}
