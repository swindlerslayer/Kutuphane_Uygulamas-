using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using Kutuphane_Uygulaması.Data;
using DevExpress.XtraEditors;
using static Kutuphane_Uygulaması.Data.Degiskenler;
using Kutuphane_Uygulaması.Data.Wait;

namespace Kutuphane_Uygulaması
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            textEdit2.Properties.PasswordChar = '*';
            this.StartPosition = FormStartPosition.CenterScreen;
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
                bool checkkontrol = checkEdit1.Checked;

                string dosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "KullaniciBilgileri.json");
                var jsonData = new
                {
                    KullaniciAdi = Kadi,
                    Sifre = Ksifre,
                    Checkbox = checkkontrol
                };

                string jsonString = JsonSerializer.Serialize(jsonData);
                File.WriteAllText(dosyaYolu, jsonString);

                return true;
            }
            else
            {
                string dosyaYoluu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "KullaniciBilgileri.json");
                var jsonData = new
                {
                    KullaniciAdi = "",
                    Sifre = "",
                    Checkbox = false
                };

                string jsonString = JsonSerializer.Serialize(jsonData);
                File.WriteAllText(dosyaYoluu, jsonString);

                return false;
            }
        }        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Loading.Open();    
            string Kadi, Ksifre;
            Kadi = textEdit1.Text;
            Ksifre = textEdit2.Text;

            var res = DbKullanici.KullaniciControl(Kadi, Ksifre, true);
            AnaGirisForm GrsForm = new AnaGirisForm(res);


            StaticDegiskenler.kullanici = res;
            GrsForm.Show();
            this.Hide();


            bool hatirla = checkEdit1.Checked; 
            KullaniciHatirla(hatirla);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string filename = @"C:\Users\deret\OneDrive\Masaüstü\KullaniciBilgileri.json";
            if (File.Exists(filename))
            {

            string json = File.ReadAllText(@"C:\Users\deret\OneDrive\Masaüstü\KullaniciBilgileri.json");
            var veri = JsonSerializer.Deserialize<DbRemember>(json, options);

            textEdit1.Text = veri.KullaniciAdi;
            textEdit2.Text = veri.Sifre;
            checkEdit1.Checked = veri.Checkbox;

            }

        }
    }
}
