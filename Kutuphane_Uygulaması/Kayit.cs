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
            this.StartPosition = FormStartPosition.CenterScreen;
            textEdit2.Properties.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }


        string hash = "slkjgdngı0243582ej";
        public string Encrypt(string sifre)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(sifre);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
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
            SifreliKsifre = Encrypt(Ksifre);
            //if kullanıcı adına bağlı bir ID var ise Kullanıcı adı kullanılıyor döndür 


            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciAdi = Kadi;
            kullanici.Parola = SifreliKsifre;
            bool kontrol = DbKullanici.KK(kullanici);
            if(kontrol != true)
            {
            bool kaydedildi = DbKullanici.EkleDuzenle(kullanici);
            if (kaydedildi)
            {
                MessageBox.Show("Kullanıcı başarıyla kaydedildi");
            }
            else
            {
                MessageBox.Show("Kullanıcı Zaten Kayıtlı");
            }

            }
            else
            {
                MessageBox.Show("Kullanıcı Zaten Kayıtlı");
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
