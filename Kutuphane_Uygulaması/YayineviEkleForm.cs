using Kutuphane_Uygulaması.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Kutuphane_Uygulaması
{
    public partial class YayineviEkleForm : Form
    {
        private string kullaniciid;
        public YayineviEkleForm(string KullaniciID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.kullaniciid = KullaniciID;
        }

        private void YayineviEkleForm_Load(object sender, EventArgs e)
        {

            gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string yayineviadi;
            yayineviadi = textEdit1.Text;
            YayinEvi yadi = new YayinEvi();
            yadi.Adi = yayineviadi;
            yadi.KayitYapan = kullaniciid;
            yadi.KayitTarihi = DateTime.Now;
            bool kontrol = DbYayinEvi.YK(yadi);
            if (kontrol != true)
            {
                bool kaydedildi = DbYayinEvi.EkleDuzenle(yadi);
                if (kaydedildi)
                {
                    MessageBox.Show("Yayınevi başarıyla kaydedildi");

                    gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Yayınevi kaydedilirken bir hata oluştu");
                }
            }
            else
            {
                MessageBox.Show("Bu yayınevi zaten kayıtlı");
            }
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (gridView1.GetFocusedRow() is YayinEvi selectedYayinEvi)
            {
                string yeniAdi = textEdit1.Text;

                selectedYayinEvi.Adi = yeniAdi;

                selectedYayinEvi.KayitYapan = kullaniciid;
                selectedYayinEvi.KayitTarihi = DateTime.Now;

                bool kaydedildi = DbYayinEvi.EkleDuzenle(selectedYayinEvi);
                if (kaydedildi)
                {
                    MessageBox.Show("Yayınevi başarıyla güncellendi");

                    gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Yayinevi Başarıyla Güncellendi");
                    gridControl1.DataSource = DbYayinEvi.ListeyeEkle();

                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            if (gridView1.GetFocusedRow() is YayinEvi selectedYayinEvi)
            {
                string silinecek = textEdit1.Text;

                selectedYayinEvi.Adi = silinecek;

                bool kaydedildi = DbYayinEvi.sil(selectedYayinEvi);
                if (kaydedildi)
                {
                    MessageBox.Show("Yayınevi başarıyla Silindi");

                    gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Yayinevi Silinemedi");
                    gridControl1.DataSource = DbYayinEvi.ListeyeEkle();

                }
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

            object deneme12 = gridView1.GetFocusedRowCellValue("Adi");
            if (deneme12 != null)
            {
                textEdit1.Text = deneme12.ToString();
            }

        }


    }
}
