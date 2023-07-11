using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Kutuphane_Uygulaması.Data;

namespace Kutuphane_Uygulaması
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();

            textEdit2.Properties.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }


        string SHA256Hash(string text)
        {
            string source = text;
            using (SHA256 sha1Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return (hash);
            }
        }
        
        private void Kayit_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            string Kadi, Ksifre, SifreliKsifre;
            Kadi = textEdit1.Text;
            Ksifre = textEdit2.Text;
            SifreliKsifre = SHA256Hash(Ksifre);

            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciAdi = Kadi;
            kullanici.Parola = SifreliKsifre;
            bool kaydedildi = DbKullanici.EkleDuzenle(kullanici);
            if (kaydedildi)
            {
                MessageBox.Show("Kullanıcı başarıyla kaydedildi");
            }
            else
            {
                MessageBox.Show("Kullanıcı kaydedilirken bir hata oluştu");
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

            Form1 GrsForm = new Form1();
            GrsForm.Show();
            this.Hide();
        }
    }
}
