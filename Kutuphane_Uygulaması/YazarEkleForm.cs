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
using static Kutuphane_Uygulaması.Data.Degiskenler;
using Kutuphane_Uygulaması.Data.Wait;



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

        private void YazarEkleButton_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                MessageBox.Show("Lütfen Kaydedeceğiniz Yazarın İsmini Giriniz");
            }
            else
            {
                string yazaradi;
                yazaradi = textEdit1.Text;
                EntityFullYazar yazar = new EntityFullYazar();
                yazar.AdiSoyadi = yazaradi;
                yazar.KayitTarihi = DateTime.Now;
                yazar.KayitYapan = kullaniciiD;

                bool kontrol = DbYazar.YK(yazar);
                if (kontrol != true)
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
        }

        private void YazarGuncelleButton_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                MessageBox.Show("Lütfen Güncelleyeceğiniz Yazarı Listeden Seçiniz");
            }
            else
            {
                string yazaradi, yazarid;
                yazaradi = textEdit1.Text;
                yazarid = label2.Text;
                EntityFullYazar yazar = new EntityFullYazar();
                yazar.ID = Int32.Parse(yazarid);
                yazar.AdiSoyadi = yazaradi;
                yazar.KayitTarihi = DateTime.Now;
                yazar.KayitYapan = kullaniciiD;


                bool kaydedildi = DbYazar.EkleDuzenle(yazar);
                if (kaydedildi)
                {
                    MessageBox.Show("Yazar başarıyla güncellendi");
                    gridControl1.DataSource = DbYazar.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Yazar güncellenirken bir hata oluştu");
                }

            }
        }

        private void YazarSilButton_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                MessageBox.Show("Lütfen Sileceğinz Yazarı Listeden Seçiniz");
            }
            else
            {

                if (gridView1.GetFocusedRow() is EntityYazarListe selectedYazar)
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
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

            object secilenyazarID = gridView1.GetFocusedRowCellValue("ID");
            if(secilenyazarID != null)
            {
                
                label2.Text = secilenyazarID.ToString();

            }

            object secilenyazar = gridView1.GetFocusedRowCellValue("AdiSoyadi");
            if (secilenyazar != null)
            {
                textEdit1.Text = secilenyazar.ToString();
                
            }
        }

        private void YazarEkleForm_Load(object sender, EventArgs e)
        {
            Loading.Close();
        }
    }
}
