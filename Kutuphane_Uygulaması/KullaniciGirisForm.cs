using Kutuphane_Uygulaması.Data;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static Kutuphane_Uygulaması.Data.Degiskenler;


namespace Kutuphane_Uygulaması
{
    public partial class KullaniciGirisForm : Form
    {

        private string selectedImagePath; // Seçilen resmin yolunu tutmak için değişken

        public KullaniciGirisForm(Kullanici kullanici)
        {
            InitializeComponent();

            label2.Text = kullanici.ToString();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void KullaniciGirisForm_Load(object sender, EventArgs e)
        {

            lookKitapTuru.Properties.DataSource = DbKitapTuru.ListeyeEkle();
            LookUpYayinEvi.Properties.DataSource = DbYayinEvi.ListeyeEkle();
            LookUpYazar.Properties.DataSource = DbYazar.ListeyeEkle();
            gridControl1.DataSource = DbKitap.ListeyeEkle();




        }
        private void Kaydet_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            string ss = textEdit2.Text;
            string barkod = textEdit3.Text;
            EntityFullKitap kitap = new EntityFullKitap();
            kitap.ID = Int32.Parse(label1.Text);
            kitap.KayitYapan = StaticDegiskenler.Kullanici.KullaniciAdi;
            kitap.Adi = textEdit1.Text;
            kitap.KitapTurID = (int)lookKitapTuru.EditValue;
            kitap.YazarID = (int)LookUpYazar.EditValue;
            kitap.YayinEviID = (int)LookUpYayinEvi.EditValue;
            kitap.SayfaSayisi = Int32.Parse(ss);
            kitap.Barkod = Int32.Parse(barkod);
            kitap.Resim = imageToByteArray();



            bool kaydedildi = DbKitap.EkleDuzenle(kitap);
            if (kaydedildi)
            {
                MessageBox.Show("Kitap başarıyla kaydedildi");
                gridControl1.DataSource = DbKitap.ListeyeEkle();
            }
            else
            {
                MessageBox.Show("Kitap kaydedilirken bir hata oluştu");
            }
        }
        private void Guncelle_Click(object sender, EventArgs e)
        {

            int silinecek = Int32.Parse(label1.Text);
            string ss = textEdit2.Text;
            string barkod = textEdit3.Text;
            EntityFullKitap selectedKitap = new EntityFullKitap();
            selectedKitap.KayitYapan = label1.Text;
            selectedKitap.Adi = textEdit1.Text;
            selectedKitap.KitapTurID = (int)lookKitapTuru.EditValue;
            selectedKitap.YazarID = (int)LookUpYazar.EditValue;
            selectedKitap.YayinEviID = (int)LookUpYayinEvi.EditValue;
            selectedKitap.SayfaSayisi = Int32.Parse(ss);
            selectedKitap.Barkod = Int32.Parse(barkod);
            selectedKitap.ID = silinecek;
            selectedKitap.Resim = imageToByteArray();

            bool güncellendi = DbKitap.EkleDuzenle(selectedKitap);
            if (güncellendi)
            {
                MessageBox.Show("Kitap Başarıyla Güncellendi");

                gridControl1.DataSource = DbKitap.ListeyeEkle();
            }
            else
            {

                MessageBox.Show("Kitap Güncellenirken Bir Hata Oluştu");
                gridControl1.DataSource = DbKitap.ListeyeEkle();

            }
        }
        private void Sil_Click(object sender, EventArgs e)
        {
            int _id = Int32.Parse(label1.Text);
            if (_id != null)
            {
                var data = DbKitap.sil((int)_id);
                if (data == true)
                {
                    MessageBox.Show("Kitap başarıyla Silindi");
                }
                else
                {
                    MessageBox.Show("Kitap Silinemedi");

                }
                gridControl1.DataSource = DbKitap.ListeyeEkle();


            }
        }
        private void kitapToolStripMenuItem_Click(object sender, EventArgs e)
        {


            entityKitapBindingSource.DataSource = DbKitap.ListeyeEkle();
            gridControl1.DataSource = DbKitap.ListeyeEkle();

            LookUpYayinEvi.Properties.DataSource = DbYayinEvi.ListeyeEkle();
            LookUpYazar.Properties.DataSource = DbYazar.ListeyeEkle();


        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            int? _id = (int?)gridView1.GetFocusedRowCellValue("ID");
            if (_id != null)
            {
                var data = DbKitap.KitapGetir((int)_id);
                if (data != null)
                {
                    textEdit1.Text = data.Adi;
                    textEdit2.Text = data.SayfaSayisi.ToString();
                    lookKitapTuru.EditValue = data.KitapTurID;
                    LookUpYayinEvi.EditValue = data.YayinEviID;
                    LookUpYazar.EditValue = data.YazarID;
                    textEdit3.Text = data.Barkod.ToString();
                    label1.Text = data.ID.ToString();
                    if (data.Resim != null && data.Resim.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(data.Resim))
                        {
                            pictureEdit1.Image = Image.FromStream(ms);
                            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        pictureEdit1.Image = null;
                    }
                }
            }
        }
        private void yazarEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string kad = label2.Text;

            YazarEkleForm GrsForm = new YazarEkleForm(kad);
            GrsForm.Show();
        }
        private void yayınEviEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string kad = label2.Text;

            YayineviEkleForm GrsForm = new YayineviEkleForm(kad);
            GrsForm.Show();
        }
        private void kitapTürüEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string kad = label2.Text;

            KitapTurEkleForm GrsForm = new KitapTurEkleForm(kad);
            GrsForm.Show();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            int id = Int32.Parse(label1.Text);
            GridGuncelle form = new GridGuncelle(id);
            form.Show();

        }
        private void öğrenciKitapToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int kad = 0;
            kad = StaticDegiskenler.Kullanici.ID;
            OgrenciKitapForm form = new OgrenciKitapForm(kad);
            form.Show();
        }
        public byte[] imageToByteArray()
        {
            if (pictureEdit1.Image == null)
            {
                return null;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                Image imageIn = pictureEdit1.Image;
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }
        private void ResimYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;

                // Resmi PictureEdit kontrolüne getirme ve sığdırma
                Image originalImage = Image.FromFile(selectedImagePath);
                pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                pictureEdit1.Image = originalImage;
            }
        }
        private void ResimSil_Click(object sender, EventArgs e)
        {
            if (pictureEdit1.Image == null)
            {

                MessageBox.Show("Bu Alanda Bir Resim Yok");
            }
            else
            {
                int _id = Int32.Parse(label1.Text);
                if (_id != null)
                {
                    var data = DbKitap.Resimsil((int)_id);
                    if (data == true)
                    {
                        MessageBox.Show("Resim başarıyla Silindi");
                    }
                    else
                    {
                        MessageBox.Show("Resim Silinemedi");

                    }
                    gridControl1.DataSource = DbKitap.ListeyeEkle();
                }
            }


        }
        private void bisiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bisiToolStripMenuItem.Text = StaticDegiskenler.Kullanici.ID.ToString();

        }
    }
}

