using DevExpress.XtraEditors.Repository;
using Kutuphane_Uygulaması.Data;
using System;
using System.Windows.Forms;
using static Kutuphane_Uygulaması.Data.Degiskenler;

namespace Kutuphane_Uygulaması
{
    public partial class OgrenciEkleForm : Form
    {
        private string kullaniciid;
        public OgrenciEkleForm(string KullaniciID)
        {
            InitializeComponent();
            this.kullaniciid = KullaniciID;

            this.StartPosition = FormStartPosition.CenterScreen;
            gridControl1.DataSource = DbOgrenci.ListeyeEkle();

        }
        private void OgrenciEkleForm_Load(object sender, EventArgs e)
        {
        }
        private void EkleButon_Click(object sender, EventArgs e)
        {
            if (AdiSoyadiTE.Text == "" && textEdit1.Text == "" && textEdit2.Text == "" && textEdit3.Text == "") {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz");
            }
            else { 
            EntityFullOgrenci ogrenci = new EntityFullOgrenci();
            ogrenci.AdiSoyadi = AdiSoyadiTE.Text;
            ogrenci.KayitTarihi = DateTime.Now;
            ogrenci.KayitYapan = kullaniciid;
            ogrenci.Sinif = textEdit2.Text;
            ogrenci.Bölüm = textEdit1.Text;
            ogrenci.OkulNo = Int32.Parse(textEdit3.Text);


            bool kontrol = DbOgrenci.OK(ogrenci);
            if (kontrol != true)
            {

                bool kaydedildi = DbOgrenci.EkleDuzenle(ogrenci);
                if (kaydedildi)
                {
                    MessageBox.Show("Öğrenci başarıyla kaydedildi");
                    gridControl1.DataSource = DbOgrenci.ListeyeEkle();
                }
                else
                {
                    MessageBox.Show("Öğrenci kaydedilirken bir hata oluştu");
                }

            }
            else
            {
                MessageBox.Show("Bu Öğrenci halihazırda kayıtlı");

            }
            }
        }

        private void GuncelleButon_Click(object sender, EventArgs e)
        {
            if (AdiSoyadiTE.Text == "" && textEdit1.Text == "" && textEdit2.Text == "" && textEdit3.Text == "")
            {
                MessageBox.Show("Lütfen Güncellenecek Öğrenciyi Seçiniz");
            }
            else
            {
                EntityFullOgrenci ogrenci = new EntityFullOgrenci();
                ogrenci.ID = Int32.Parse(label2.Text);
                ogrenci.AdiSoyadi = AdiSoyadiTE.Text;
                ogrenci.KayitTarihi = DateTime.Now;
                ogrenci.KayitYapan = kullaniciid;
                ogrenci.Sinif = textEdit2.Text;
                ogrenci.Bölüm = textEdit1.Text;
                ogrenci.OkulNo = Int32.Parse(textEdit3.Text);
                bool kontrol = DbOgrenci.OK(ogrenci);
                if (kontrol != true)
                {
                    bool kaydedildi = DbOgrenci.EkleDuzenle(ogrenci);
                    if (kaydedildi)
                    {
                        MessageBox.Show("Öğrenci başarıyla Güncellendi");
                        gridControl1.DataSource = DbOgrenci.ListeyeEkle();
                    }
                    else
                    {
                        MessageBox.Show("Öğrenci Güncellenirken bir hata oluştu");
                    }
                }
                else
                {
                    MessageBox.Show("Sistem Hatası");
                }
            }
        }

        private void SilButon_Click(object sender, EventArgs e)
        {
            if (AdiSoyadiTE.Text == "" && textEdit1.Text == "" && textEdit2.Text == "" && textEdit3.Text == "")
            {
                MessageBox.Show("Lütfen Bir Öğrenci Seçiniz");
            }
            else
            {
                if (gridView1.GetFocusedRow() is EntityOgrenciListe selectedYazar)
                {
                    string silinecek = AdiSoyadiTE.Text;

                    selectedYazar.AdiSoyadi = silinecek;

                    bool kaydedildi = DbOgrenci.sil(selectedYazar);
                    if (kaydedildi)
                    {
                        MessageBox.Show("Öğrenci başarıyla Silindi");

                        gridControl1.DataSource = DbOgrenci.ListeyeEkle();
                    }
                    else
                    {
                        MessageBox.Show("Öğrenci Silinemedi");
                        gridControl1.DataSource = DbOgrenci.ListeyeEkle();
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = DbOgrenci.ListeyeEkle();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            object secilenOgrenciID = gridView1.GetFocusedRowCellValue("ID");
            if (secilenOgrenciID != null)
            {

                label2.Text = secilenOgrenciID.ToString();

            }
            int? _id = (int?)gridView1.GetFocusedRowCellValue("ID");
            if (_id != null)
            {
                var data = DbOgrenci.OgrenciGetir((int)_id);
                if (data != null)
                {
                    AdiSoyadiTE.Text = data.AdiSoyadi;
                    textEdit2.Text = data.Sinif;

                    textEdit1.Text = data.Bölüm;
                    textEdit3.Text = data.OkulNo.ToString();





                }
            }
        }
    }
}
