using Kutuphane_Uygulaması.Data;
using System;
using System.Windows.Forms;
using static Kutuphane_Uygulaması.Data.Degiskenler;
using Kutuphane_Uygulaması.Data.Wait;


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
            Loading.Close();
        }

        private void YayineviEkleButton_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                MessageBox.Show("Lütfen Kaydedeceğiniz Yayınevinin İsmini Giriniz");
            }
            else
            {
                string yayineviadi;
                yayineviadi = textEdit1.Text;
                EntityFullYayinevi yayinevi = new EntityFullYayinevi();
                yayinevi.Adi = yayineviadi;
                yayinevi.KayitTarihi = DateTime.Now;
                yayinevi.KayitYapan = kullaniciid;


                bool kontrol = DbYayinEvi.YK(yayinevi);
                if (kontrol != true)
                {
                    bool kaydedildi = DbYayinEvi.EkleDuzenle(yayinevi);
                    if (kaydedildi)
                    {
                        gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
                        MessageBox.Show("Yayinevi başarıyla kaydedildi");
                    }
                    else
                    {
                        MessageBox.Show("Yayinevi kaydedilirken bir hata oluştu");
                    }

                }
                else
                {
                    MessageBox.Show("Bu isim halihazırda kayıtlı");

                }
            }
        }


        private void YayineviGuncelleButton_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                MessageBox.Show("Lütfen Güncelleyeceğiniz Yayınevini Listeden Seçiniz");
            }
            else
            {
                string yayineviadi, yayineviid;
                yayineviadi = textEdit1.Text;
                yayineviid = label2.Text;
                EntityFullYayinevi yayinevi = new EntityFullYayinevi();
                yayinevi.Adi = yayineviadi;
                yayinevi.ID = Int32.Parse(yayineviid);
                yayinevi.KayitTarihi = DateTime.Now;
                yayinevi.KayitYapan = kullaniciid;


                bool kaydedildi = DbYayinEvi.EkleDuzenle(yayinevi);
                if (kaydedildi)
                {
                    MessageBox.Show("Yayinevi başarıyla güncellendi");
                    gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Yayinevi güncellenirken bir hata oluştu");
                }
            }
        }

        private void YayineviSilButton_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                MessageBox.Show("Lütfen Sileceğiniz Yayınevini Listeden Seçiniz");
            }
            else
            {
                if (gridView1.GetFocusedRow() is EntityYayineviListe selectedYayinevi)
                {
                    string silinecek = textEdit1.Text;

                    selectedYayinevi.Adi = silinecek;

                    bool kaydedildi = DbYayinEvi.sil(selectedYayinevi);
                    if (kaydedildi)
                    {
                        MessageBox.Show("Yayinevi başarıyla Silindi");

                        gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
                    }
                    else
                    {
                        MessageBox.Show("Yayinevi Silinemedi");
                        gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
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


            object secilenYayinevi = gridView1.GetFocusedRowCellValue("Adi");
            if (secilenYayinevi != null)
            {
                textEdit1.Text = secilenYayinevi.ToString();
            }

        }


    }
}
