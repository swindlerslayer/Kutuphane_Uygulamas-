﻿using System;
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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
using Kutuphane_Uygulaması.Data;
using DevExpress.XtraEditors;
using static Kutuphane_Uygulaması.Data.Degiskenler;

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
             
            string Kadi, Ksifre, sifreliKsifre;
            Kadi = textEdit1.Text;
            Ksifre = textEdit2.Text;
            sifreliKsifre = SHA256Hash(Ksifre);
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {

                var kullanici = db.Kullanici.FirstOrDefault(k => k.KullaniciAdi == Kadi && k.Parola == sifreliKsifre);

                if (kullanici != null)
                {
                    EntityKullanici kullanici1 = new EntityKullanici();
                    KullaniciGirisForm GrsForm = new KullaniciGirisForm(kullanici);
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
