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

namespace Kutuphane_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textEdit2.Properties.PasswordChar = '*';
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kayit KytForm = new Kayit();
            KytForm.Show();
            this.Hide();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            string Kadi, Ksifre, sifreliKsifre;
            Kadi = textEdit1.Text;
            Ksifre = textEdit2.Text;
            sifreliKsifre = SHA256Hash(Ksifre);
            using (KutuphaneEntities2 context = new KutuphaneEntities2())
            {

                var kullanici = context.Kullanici.FirstOrDefault(k => k.KullaniciAdi == Kadi && k.Parola == sifreliKsifre);

                if (kullanici != null)
                {

                    KullaniciGirisForm GrsForm = new KullaniciGirisForm(Kadi);
                    GrsForm.Show();
                    this.Hide();




                }
                else
                {

                    MessageBox.Show("Geçersiz kullanıcı adı veya parola");
                }

            }
        }
    }
}
