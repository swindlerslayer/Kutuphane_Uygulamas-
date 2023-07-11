using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Kutuphane_Uygulaması.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace Kutuphane_Uygulaması
{
    public partial class KullaniciGirisForm : Form
    {

        private string kullaniciAdi;


        public KullaniciGirisForm(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
        }
        private void KullaniciGirisForm_Load(object sender, EventArgs e)
        {
            label1.Text = kullaniciAdi;

            
            lookKitapTuru.Properties.DataSource= DbKitapTuru.ListeyeEkle(); 
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
            }
            else
            {
                MessageBox.Show("Kitap kaydedilirken bir hata oluştu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void kitapToolStripMenuItem_Click(object sender, EventArgs e)
        {


            entityKitapBindingSource.DataSource = DbKitap.ListeyeEkle();
            //gridControl1.DataSource = DbKitap.ListeyeEkle();

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        
            
            
            //    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
            //        MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
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
    }
}
