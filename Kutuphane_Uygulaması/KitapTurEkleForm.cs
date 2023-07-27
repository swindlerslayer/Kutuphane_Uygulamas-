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



namespace Kutuphane_Uygulaması
{
    public partial class KitapTurEkleForm : Form
    {

        private string kullaniciiD;

        public KitapTurEkleForm(string KullaniciID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.kullaniciiD = KullaniciID;
            gridControl1.DataSource = DbKitapTuru.ListeyeEkle();

        }

        private void KitapTurEkleForm_Load(object sender, EventArgs e)
        {

        }
        private void KitapTurEkleButton_Click(object sender, EventArgs e)
        {

            if(textEdit1.Text == "") {
                MessageBox.Show("Lütfen Kaydedeceğiniz Türün İsmini Giriniz");
            }
            else { 

            string kitapturadi;
            kitapturadi = textEdit1.Text;
            EntityFullKitapTuru kitapTuru = new EntityFullKitapTuru();
            kitapTuru.Adi = kitapturadi;
            kitapTuru.KayitYapan = kullaniciiD;
            kitapTuru.KayitTarihi = DateTime.Now;

            bool kontrol = DbKitapTuru.KTKontrol(kitapTuru);
            if (kontrol != true)
            {

                bool kaydedildi = DbKitapTuru.EkleDuzenle(kitapTuru);
                if (kaydedildi)
                {
                    MessageBox.Show("Kitap Türü başarıyla kaydedildi");
                    gridControl1.DataSource = DbKitapTuru.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Kitap Türü kaydedilirken bir hata oluştu");
                }

            }
            else
            {
                MessageBox.Show("Bu isim halihazırda kayıtlı");
            }
                
            }

        }

        private void KitapTurGuncelleButton_Click(object sender, EventArgs e)
        {

            if (textEdit1.Text == "")
            {
                MessageBox.Show("Lütfen Güncelleyeceğiniz Türün İsmini Giriniz");
            }
            else
            {

                string kitapturuadi, kitapturuid;
                kitapturuadi = textEdit1.Text;
                kitapturuid = label2.Text;
                EntityFullKitapTuru kitapturu = new EntityFullKitapTuru();
                kitapturu.Adi = kitapturuadi;
                kitapturu.ID = Int32.Parse(kitapturuid);
                kitapturu.KayitTarihi = DateTime.Now;
                kitapturu.KayitYapan = kullaniciiD;


                bool kaydedildi = DbKitapTuru.EkleDuzenle(kitapturu);
                if (kaydedildi)
                {
                    MessageBox.Show("Kitap türü başarıyla güncellendi");
                    gridControl1.DataSource = DbKitapTuru.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Kitap türü güncellenirken bir hata oluştu");
                }
            }
        }
        private void KitapTurSilButton_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                MessageBox.Show("Lütfen Sileceğiniz Türü seçiniz");
            }
            else
            {
                if (gridView1.GetFocusedRow() is EntityKitapTuruListe selectedkitaptur)
                {
                    string silinecek = textEdit1.Text;

                    selectedkitaptur.Adi = silinecek;

                    bool kaydedildi = DbKitapTuru.sil(selectedkitaptur);
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
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            object secilenyayineviID = gridView1.GetFocusedRowCellValue("ID");
            if (secilenyayineviID != null)
            {

                label2.Text = secilenyayineviID.ToString();

            }

            object secilenkitapturu = gridView1.GetFocusedRowCellValue("Adi");
            if (secilenkitapturu != null)
            {
                textEdit1.Text = secilenkitapturu.ToString();
            }
        }

    }
}
