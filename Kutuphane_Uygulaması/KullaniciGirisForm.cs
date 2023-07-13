using Kutuphane_Uygulaması.Data;
using System;
using System.Linq;
using System.Windows.Forms;


namespace Kutuphane_Uygulaması
{
    public partial class KullaniciGirisForm : Form
    {

        private string kullaniciAdi;


        public KullaniciGirisForm(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void KullaniciGirisForm_Load(object sender, EventArgs e)
        {

            lookKitapTuru.Properties.DataSource = DbKitapTuru.ListeyeEkle();
            LookUpYayinEvi.Properties.DataSource = DbYayinEvi.ListeyeEkle();
            LookUpYazar.Properties.DataSource = DbYazar.ListeyeEkle();



        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ss = textEdit2.Text;
            string barkod = textEdit3.Text;
            Kitap kitap = new Kitap();
            kitap.KayitYapan = label1.Text;
            kitap.Adi = textEdit1.Text;
            kitap.KitapTurID = (int)lookKitapTuru.EditValue;
            kitap.YazarID = (int)LookUpYazar.EditValue;
            kitap.YayinEviID = (int)LookUpYayinEvi.EditValue;
            kitap.SayfaSayisi = Int32.Parse(ss);
            kitap.Barkod = Int32.Parse(barkod);

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

        private void button2_Click(object sender, EventArgs e)
        {

            int silinecek = Int32.Parse(label1.Text);
            string ss = textEdit2.Text;
            string barkod = textEdit3.Text;
            Kitap selectedKitap = new Kitap(); // selectedKitap değişkenine yeni bir Kitap nesnesi oluşturulmalıdır

            selectedKitap.KayitYapan = label1.Text;
            selectedKitap.Adi = textEdit1.Text;
            selectedKitap.KitapTurID = (int)lookKitapTuru.EditValue;
            selectedKitap.YazarID = (int)LookUpYazar.EditValue;
            selectedKitap.YayinEviID = (int)LookUpYayinEvi.EditValue;
            selectedKitap.SayfaSayisi = Int32.Parse(ss);
            selectedKitap.Barkod = Int32.Parse(barkod);
            selectedKitap.ID = silinecek;
            bool güncellendi = DbKitap.EkleDuzenle(selectedKitap);
            if (güncellendi)
            {
                MessageBox.Show("????");

                gridControl1.DataSource = DbKitap.ListeyeEkle();
            }
            else
            {
                MessageBox.Show("Kitap Başarıyla Güncellendi");
                gridControl1.DataSource = DbKitap.ListeyeEkle();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int silinecek = Int32.Parse(label1.Text);
            Kitap selectedKitap = new Kitap(); // selectedKitap değişkenine yeni bir Kitap nesnesi oluşturulmalıdır
            selectedKitap.ID = silinecek;


            bool kaydedildi = DbKitap.sil(selectedKitap);
            if (kaydedildi)
            {
                MessageBox.Show("Yayınevi başarıyla Silindi");

                gridControl1.DataSource = DbKitap.ListeyeEkle();
            }
            else
            {
                MessageBox.Show("Yayinevi Silinemedi");
                gridControl1.DataSource = DbKitap.ListeyeEkle();


            }
        }
        private void kitapToolStripMenuItem_Click(object sender, EventArgs e)
        {


            entityKitapBindingSource.DataSource = DbKitap.ListeyeEkle();
            gridControl1.DataSource = DbKitap.ListeyeEkle();


        }
        private void gridControl1_Click(object sender, EventArgs e)
        {


            int? _id = (int?)gridView1.GetFocusedRowCellValue("ID");
            //object deneme13 = gridView1.GetFocusedRowCellValue("YazarAdi");

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


                }

                //LookUpYazar.Properties.DisplayMember = deneme13.ToString();

            }
            //if (deneme13 != null)
            //{

            //    LookUpYazar.EditValue = deneme13;
            //}

        }
        private void yazarEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            YazarEkleForm GrsForm = new YazarEkleForm();
            GrsForm.Show();
        }
        private void yayınEviEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YayineviEkleForm GrsForm = new YayineviEkleForm();
            GrsForm.Show();
        }
        private void kitapTürüEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KitapTurEkleForm GrsForm = new KitapTurEkleForm();
            GrsForm.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            int id = Int32.Parse(label1.Text);
            GridGuncelle form = new GridGuncelle(id);
            form.Show();

        }
    }
}
