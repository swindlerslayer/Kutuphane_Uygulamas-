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
    public partial class KitapTurEkleForm : Form
    {
        public KitapTurEkleForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            gridControl1.DataSource = DbKitapTuru.ListeyeEkle();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            string kitapturadi;
            kitapturadi = textEdit1.Text;
            KitapTuru kitapTuru = new KitapTuru();
            kitapTuru.Adi = kitapturadi;
            bool kontrol = DbKitapTuru.KTK(kitapTuru);
            if (kontrol != true)
            {

                bool kaydedildi = DbKitapTuru.EkleDuzenle(kitapTuru);
                if (kaydedildi)
                {
                    MessageBox.Show("Yazar başarıyla kaydedildi");
                    gridControl1.DataSource = DbKitapTuru.ListeyeEkle();
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


            if (gridView1.GetFocusedRow() is KitapTuru selectedkitapturu)
            {
                string yeniAdi = textEdit1.Text;

                selectedkitapturu.Adi = yeniAdi;

                bool kaydedildi = DbKitapTuru.EkleDuzenle(selectedkitapturu);
                if (kaydedildi)
                {
                    MessageBox.Show("????");

                    gridControl1.DataSource = DbKitapTuru.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Kitap Türü Başarıyla Güncellendi");
                    gridControl1.DataSource = DbKitapTuru.ListeyeEkle();

                }
            }

        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {


            if (gridView1.GetFocusedRow() is KitapTuru selectedkitapturu)
            {
                string silinecek = textEdit1.Text;

                selectedkitapturu.Adi = silinecek;

                bool kaydedildi = DbKitapTuru.sil(selectedkitapturu);
                if (kaydedildi)
                {
                    MessageBox.Show("Kitap türü başarıyla Silindi");

                    gridControl1.DataSource = DbKitapTuru.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Kitap türü Silinemedi");
                    gridControl1.DataSource = DbKitapTuru.ListeyeEkle();
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
