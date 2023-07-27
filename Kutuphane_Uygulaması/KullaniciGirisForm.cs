using DevExpress.Utils.Menu;
using Kutuphane_Uygulaması.Data;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Kutuphane_Uygulaması.Data.Degiskenler;


namespace Kutuphane_Uygulaması
{
    public partial class KullaniciGirisForm : Form
    {

        private string selectedImagePath; // Seçilen resmin yolunu tutmak için değişken
        private byte[] resim;
        private string kullaniciadi;
        public KullaniciGirisForm(string kullaniciadi)
        {
            InitializeComponent();

            label2.Text = kullaniciadi;
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void KullaniciGirisForm_Load(object sender, EventArgs e)
        {

            //lookKitapTuru.Properties.DataSource = DbKitapTuru.ListeyeEkle();
            //LookUpYayinEvi.Properties.DataSource = DbYayinEvi.ListeyeEkle();
            //LookUpYazar.Properties.DataSource = DbYazar.ListeyeEkle();
            gridControl1.DataSource = DbKitap.ListeyeEkle();




        }
        private void Kaydet_Click(object sender, EventArgs e)
        {
           // int id = Int32.Parse(label1.Text);

            KitapEkleForm frm = new KitapEkleForm(kullaniciadi);
            frm.Show();
            //label1.Text = "0";
            //string ss = textEdit2.Text;
            //string barkod = textEdit3.Text;
            //EntityFullKitap kitap = new EntityFullKitap();
            //kitap.ID = Int32.Parse(label1.Text);
            //kitap.KayitYapan = StaticDegiskenler.kullanici.KullaniciAdi;
            //kitap.KayitTarihi = DateTime.Now;
            //kitap.Adi = textEdit1.Text;
            //kitap.KitapTurID = (int)lookKitapTuru.EditValue;
            //kitap.YazarID = (int)LookUpYazar.EditValue;
            //kitap.YayinEviID = (int)LookUpYayinEvi.EditValue;
            //kitap.SayfaSayisi = Int32.Parse(ss);
            //kitap.Barkod = Int32.Parse(barkod);
            //kitap.Resim = imgToByteConverter();



            //bool kaydedildi = DbKitap.EkleDuzenle(kitap);
            //if (kaydedildi)
            //{
            //    MessageBox.Show("Kitap başarıyla kaydedildi");
            //    gridControl1.DataSource = DbKitap.ListeyeEkle();
            //}
            //else
            //{
            //    MessageBox.Show("Kitap kaydedilirken bir hata oluştu");
            //}
        }
        //private void Guncelle_Click(object sender, EventArgs e)
        //{

        //    int silinecek = Int32.Parse(label1.Text);
        //    string ss = textEdit2.Text;
        //    string barkod = textEdit3.Text;
        //    EntityFullKitap selectedKitap = new EntityFullKitap();
        //    selectedKitap.KayitYapan = label1.Text;
        //    selectedKitap.Adi = textEdit1.Text;
        //    selectedKitap.DegisiklikTarihi = DateTime.Now;
        //    selectedKitap.DegisiklikYapan = label2.Text;
        //    selectedKitap.KitapTurID = (int)lookKitapTuru.EditValue;
        //    selectedKitap.YazarID = (int)LookUpYazar.EditValue;
        //    selectedKitap.YayinEviID = (int)LookUpYayinEvi.EditValue;
        //    selectedKitap.SayfaSayisi = Int32.Parse(ss);
        //    selectedKitap.Barkod = Int32.Parse(barkod);
        //    selectedKitap.ID = silinecek;
        //    selectedKitap.Resim = imgToByteConverter();
        //    bool güncellendi = DbKitap.EkleDuzenle(selectedKitap);
        //    if (güncellendi)
        //    {
        //        MessageBox.Show("Kitap Başarıyla Güncellendi");

        //        gridControl1.DataSource = DbKitap.ListeyeEkle();
        //    }
        //    else
        //    {

        //        MessageBox.Show("Kitap Güncellenirken Bir Hata Oluştu");
        //        gridControl1.DataSource = DbKitap.ListeyeEkle();

        //    }
        //}
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
        private void gridControl1_Click(object sender, EventArgs e)
        {
            int? _id = (int?)gridView1.GetFocusedRowCellValue("ID");
            if (_id != null)
            {
                var data = DbKitap.KitapGetir((int)_id);
                if (data != null)
                {
                    textEdit1.Text = data.Adi;
                    // textEdit2.Text = data.SayfaSayisi.ToString();
                    // lookKitapTuru.EditValue = data.KitapTurID;
                    // LookUpYayinEvi.EditValue = data.YayinEviID;
                    //   LookUpYazar.EditValue = data.YazarID;
                    //  textEdit3.Text = data.Barkod.ToString();

                    label1.Text = data.ID.ToString();

                    pictureEdit1.EditValue = data.Resim;
                    pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                    //if (data.Resim != null && data.Resim.Length > 0)
                    //{
                    //    using (MemoryStream ms = new MemoryStream(data.Resim))
                    //    {
                    //        pictureEdit1.Image = Image.FromStream(ms);
                    //        pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                    //    } 
                    //}

                }
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            int id = Int32.Parse(label1.Text);
            GridGuncelle form = new GridGuncelle(id, kullaniciadi);
            form.Show();

        }      
        public byte[] imgToByteConverter()
        {
            Image inImg = pictureEdit1.Image;
            //Image inImg = pictureEdit1.Image;
            ImageConverter imgCon = new ImageConverter();
            return (byte[])imgCon.ConvertTo(inImg, typeof(byte[]));
        }

        //public byte[] imageToByteArray()
        //{
        //    if (pictureEdit1.Image == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        using (var ms = new MemoryStream())
        //        {
        //            Image imageIn = pictureEdit1.Image;

        //            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
        //            return ms.ToArray();
        //        }
        //    }
        //}
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

                        pictureEdit1.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Resim Silinemedi");

                    }
                    gridControl1.DataSource = DbKitap.ListeyeEkle();
                }
            }


        }        
        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                DXMenuItem item = new DXMenuItem("Kitabı Sil");
                item.Click += (o, args) =>
                {
                    //
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
                    //

                };
                e.Menu.Items.Add(item);
            }
        }

        private void ListeGuncelle_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = DbKitap.ListeyeEkle();
        }
    }
}

