using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane_Uygulaması.Data;
using static Kutuphane_Uygulaması.Data.Degiskenler;

namespace Kutuphane_Uygulaması
{
    public partial class GridGuncelle : Form
    {
        private object acilankitap;
        private string acilankisi;
        
        private string selectedImagePath;
        public GridGuncelle(object acilankitap, string acilankisi)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.acilankitap = acilankitap;
            int _id = Convert.ToInt32(acilankitap);
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
               
                    pictureEdit1.EditValue = data.Resim;
                    pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                
            }
        }
        private void GridGuncelle_Load(object sender, EventArgs e)
        {
            searchLookUpEdit1.Properties.DataSource = DbKitapTuru.ListeyeEkle();
            searchLookUpEdit2.Properties.DataSource = DbYayinEvi.ListeyeEkle();
            searchLookUpEdit3.Properties.DataSource = DbYazar.ListeyeEkle();
        }
        public byte[] imgToByteConverter()
        {
            Image inImg = pictureEdit1.Image;
            //Image inImg = pictureEdit1.Image;
            ImageConverter imgCon = new ImageConverter();
            return (byte[])imgCon.ConvertTo(inImg, typeof(byte[]));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit2.Text == "" && textEdit3.Text == "" && textEdit1.Text == "" && searchLookUpEdit1 == null && searchLookUpEdit2 == null && searchLookUpEdit3 == null)
            {
                MessageBox.Show("Bütün Bilgileri Doldurunuz");

            }
            else
            {
                int silinecek = Int32.Parse(label1.Text);
                string ss = textEdit2.Text;
                string barkod = textEdit3.Text;
                EntityFullKitap selectedKitap = new EntityFullKitap();
                //selectedKitap.KayitYapan = acilankisi;
                selectedKitap.Adi = textEdit1.Text;
                selectedKitap.DegisiklikTarihi = DateTime.Now;
                selectedKitap.DegisiklikYapan = acilankisi;
                selectedKitap.KitapTurID = (int)searchLookUpEdit1.EditValue;
                selectedKitap.YazarID = (int)searchLookUpEdit3.EditValue;
                selectedKitap.YayinEviID = (int)searchLookUpEdit2.EditValue;
                selectedKitap.SayfaSayisi = Int32.Parse(ss);
                selectedKitap.Barkod = Int32.Parse(barkod);
                selectedKitap.ID = silinecek;
                selectedKitap.Resim = imgToByteConverter();
                bool güncellendi = DbKitap.EkleDuzenle(selectedKitap);
                if (güncellendi)
                {
                    MessageBox.Show("Kitap Başarıyla Güncellendi");

                }
                else
                {

                    MessageBox.Show("Kitap Güncellenirken Bir Hata Oluştu");

                }
            }
        }

        private void ResimYukleButon_Click(object sender, EventArgs e)
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
    }
}
