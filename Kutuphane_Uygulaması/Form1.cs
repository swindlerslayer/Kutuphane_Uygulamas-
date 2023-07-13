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
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;
using DevExpress.XtraEditors.Repository;

namespace Kutuphane_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textEdit2.Properties.PasswordChar = '*';
            this.StartPosition = FormStartPosition.CenterScreen;
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
        public bool KullaniciHatirla(bool hatirla)
        {
            if (checkEdit1.Checked)
            {
                string Kadi = textEdit1.Text;
                string Ksifre = textEdit2.Text;
                string checkkontrol = checkEdit1.Checked.ToString();
                string dosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "KullaniciBilgileri.xml");
                XmlDocument doc = new XmlDocument();
                
                doc.Load(dosyaYolu);
                XmlNodeList aNodes = doc.SelectNodes("/KullaniciBilgileri");
                doc.SelectNodes("KullaniciBilgileri")[0].SelectSingleNode("KullaniciAdi").InnerText = Kadi;

                doc.SelectNodes("KullaniciBilgileri")[0].SelectSingleNode("Sifre").InnerText = Ksifre;

                doc.SelectNodes("KullaniciBilgileri")[0].SelectSingleNode("checkbox").InnerText = checkkontrol;
                doc.Save(dosyaYolu);
                 return true;
            }
            string dosyaYoluu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "KullaniciBilgileri.xml");
            XmlDocument docc = new XmlDocument();

            docc.Load(dosyaYoluu);
            XmlNodeList aaNodes = docc.SelectNodes("/KullaniciBilgileri");
            docc.SelectNodes("KullaniciBilgileri")[0].SelectSingleNode("KullaniciAdi").InnerText = "";

            docc.SelectNodes("KullaniciBilgileri")[0].SelectSingleNode("Sifre").InnerText = "";

            docc.SelectNodes("KullaniciBilgileri")[0].SelectSingleNode("checkbox").InnerText = "False";
            docc.Save(dosyaYoluu);

            return false;
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


            bool hatirla = checkEdit1.Checked;
 
            KullaniciHatirla(hatirla);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string dosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "KullaniciBilgileri.xml");

            if (File.Exists(dosyaYolu))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(dosyaYolu);

                XmlNode kullaniciAdiNode = xmlDoc.SelectSingleNode("//KullaniciAdi");
                XmlNode sifreNode = xmlDoc.SelectSingleNode("//Sifre");
                XmlNode checboxNode = xmlDoc.SelectSingleNode("//checkbox");

                if (kullaniciAdiNode != null && sifreNode != null && checboxNode != null)
                {
                    
                    if (checboxNode.InnerText == "True")
                    {
                        checkEdit1.Checked = true;
                        string kullaniciAdi = kullaniciAdiNode.InnerText;
                        string sifre = sifreNode.InnerText;
                        
                        textEdit1.Text = kullaniciAdi;
                        textEdit2.Text = sifre;
                    }
                    else
                    {
                        
                    }
                }
            }
        }
    }
}
