using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraSplashScreen;
using Kutuphane_Uygulaması.Data;
using static Kutuphane_Uygulaması.Data.Degiskenler;
using Kutuphane_Uygulaması.Wait;
using static Kutuphane_Uygulaması.Data.Wait.Loading;
using Kutuphane_Uygulaması.Data.Wait;

namespace Kutuphane_Uygulaması
{
    public partial class AnaGirisForm : Form
    {
        private OKgrid okgrid;
        private string kullaniciadi;
        private int kullaniciid;
        public AnaGirisForm(EntityKullanici kullanici)
        {
            InitializeComponent();
            okgrid = new OKgrid();
            kullaniciadi = kullanici.KullaniciAdi;
            kullaniciid = kullanici.ID;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

  
        private void AnaGirisForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = okgrid.GetGridDoldur();

            Loading.Close();
        }




        private void KitapEkleButton_Click(object sender, EventArgs e)
        {
            Loading.Open();

            KullaniciGirisForm frm = new KullaniciGirisForm(kullaniciadi);
            frm.Show();

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            int? _id = (int?)gridView1.GetFocusedRowCellValue("ID");
            if (_id != null)
            {
                var data = OgrenciKitap.kitapogrencigetir((int)_id);
                if (data != null)
                {
                    label6.Text = data.ID.ToString();
                }
            }
        }

        private void OgrenciKitapButton_Click(object sender, EventArgs e)
        {
            Loading.Open();

            OgrenciKitapForm frm = new OgrenciKitapForm(kullaniciid);
            frm.Show();
        }

        private void OgrenciEkleButton_Click(object sender, EventArgs e)
        {
            Loading.Open();

            OgrenciEkleForm frm = new OgrenciEkleForm(kullaniciadi);
            frm.Show();

        }

        private void YazarEkleButton_Click(object sender, EventArgs e)
        {
            Loading.Open();

            YazarEkleForm frm = new YazarEkleForm(kullaniciadi);
            frm.Show();
        }

        private void YayıneviEkleButton_Click(object sender, EventArgs e)
        {
            Loading.Open();

            YayineviEkleForm frm = new YayineviEkleForm(kullaniciadi);
            frm.Show();
        }

        private void KitapTurEkleButton_Click(object sender, EventArgs e)
        {
            Loading.Open();

            KitapTurEkleForm frm = new KitapTurEkleForm(kullaniciadi);
            frm.Show();

        }

        private void AnaGirisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                int? _id = (int?)gridView1.GetFocusedRowCellValue("ID");
                if (_id != null)
                {
                        popupMenu1.ShowPopup(MousePosition);
                }
            
            }
        }   

        private void barButtonAlindi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int _id = (int)gridView1.GetFocusedRowCellValue("ID");
            if (_id == null)
            {
                MessageBox.Show("Bir Satır Seçiniz");
            }
            else
            {

                EntityFullKitapOgrenci kitapo = new EntityFullKitapOgrenci();
                var data = OgrenciKitap.kitapogrencigetir(_id);
                kitapo.ID = _id;
                kitapo.TeslimTarihi = DateTime.Now;
                kitapo.KullanıcıID = data.KullanıcıID;
                kitapo.TeslimDurumu = true;
                kitapo.OgrenciID = data.OgrenciID;
                kitapo.KitapID = data.KitapID;
                kitapo.AlisTarihi = data.AlisTarihi;
                kitapo.TeslimDurumu = true;
                kitapo.DegisiklikTarihi = DateTime.Now;
                kitapo.DegisiklikYapan = kullaniciadi;
                bool kaydedildi = OgrenciKitap.EkleDuzenle(kitapo);
                if (kaydedildi)
                {
                    MessageBox.Show("Kitap güncellenirken bir hata oluştu");
                    gridControl1.DataSource = okgrid.GetGridDoldur();

                }
                else
                {
                    MessageBox.Show("Kitap başarıyla güncellendi");
                    gridControl1.DataSource = okgrid.GetGridDoldur();

                }

            }
        }

        private void barButtonAlinmadi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        
            int _id = (int)gridView1.GetFocusedRowCellValue("ID");
            if (_id == null)
            {
                MessageBox.Show("Bir Satır Seçiniz");
            }
            else
            {
                string koid = label6.Text;
                EntityFullKitapOgrenci kitapo = new EntityFullKitapOgrenci();
                var data = OgrenciKitap.kitapogrencigetir(_id);
                kitapo.ID = _id;
                kitapo.TeslimTarihi = null;
                kitapo.KullanıcıID = data.KullanıcıID;
                kitapo.TeslimDurumu = true;
                kitapo.OgrenciID = data.OgrenciID;
                kitapo.KitapID = data.KitapID;
                kitapo.AlisTarihi = data.AlisTarihi;
                kitapo.TeslimDurumu = false;
                kitapo.DegisiklikTarihi = DateTime.Now;
                kitapo.DegisiklikYapan = kullaniciadi;
                bool kaydedildi = OgrenciKitap.EkleDuzenle(kitapo);
                if (kaydedildi)
                {
                    MessageBox.Show("Kitap güncellenirken bir hata oluştu");
                    gridControl1.DataSource = okgrid.GetGridDoldur();

                }
                else
                {
                    MessageBox.Show("Kitap başarıyla güncellendi");
                    gridControl1.DataSource = okgrid.GetGridDoldur();

                }

            }
        }

       
    } }
