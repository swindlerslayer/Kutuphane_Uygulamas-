using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane_Uygulaması.Data;

namespace Kutuphane_Uygulaması
{
    public partial class YayineviEkleForm : Form
    {
        public YayineviEkleForm()
        {
            InitializeComponent();
        }

        private void YayineviEkleForm_Load(object sender, EventArgs e)
        {

            gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string yayineviadi;
            yayineviadi = textEdit1.Text;
            YayinEvi yadi = new YayinEvi();
            yadi.Adi = yayineviadi;

            bool kaydedildi = DbYayinEvi.EkleDuzenle(yadi);
            if (kaydedildi)
            {
                MessageBox.Show("Kullanıcı başarıyla kaydedildi");

                gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
            }
            else
            {
                MessageBox.Show("Kullanıcı kaydedilirken bir hata oluştu");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

            gridControl1.DataSource = DbYayinEvi.ListeyeEkle();
        }
    }
}
