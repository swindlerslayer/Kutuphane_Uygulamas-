﻿using DevExpress.XtraEditors.Repository;
using Kutuphane_Uygulaması.Data;
using System;
using System.Windows.Forms;
using static Kutuphane_Uygulaması.Data.Degiskenler;
using Kutuphane_Uygulaması.Data.Wait;


namespace Kutuphane_Uygulaması
{
    public partial class OgrenciKitapForm : Form
    {

        private OgrenciKitap ogrenciKitap;
        private OKgrid okgrid;

        private DbOgrenci dbogrenci;

        int kullaniciiD;

        public OgrenciKitapForm(int kullaniciID)
        {          
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.kullaniciiD = kullaniciID;
            int ID = kullaniciiD;

            ogrenciKitap = new OgrenciKitap();
            dbogrenci = new DbOgrenci();
            okgrid = new OKgrid();
        }

        private void OgrenciKitapForm_Load(object sender, EventArgs e)
        {
            var kitapListesi = ogrenciKitap.GetKitapListesi();
            var ogrenciListesi = dbogrenci.GetOgrenciListesi();
            
            searchLookUpEdit1.Properties.DataSource = ogrenciListesi;
            searchLookUpEdit2.Properties.DataSource = kitapListesi;
            gridControl1.DataSource = okgrid.GetGridDoldur();
            Loading.Close();


        }

        private void Teslimetme_Click(object sender, EventArgs e)
        {
            if (searchLookUpEdit1.EditValue == null)
            {
                MessageBox.Show("Malesef Girdiğiniz Değerler Boş");
            }
            else
            {

                EntityFullKitapOgrenci kitapo = new EntityFullKitapOgrenci();
                kitapo.OgrenciID = ((int)searchLookUpEdit1.EditValue);
                kitapo.KitapID = (int)searchLookUpEdit2.EditValue;
                kitapo.AlisTarihi = dateEdit1.DateTime;
                kitapo.KullanıcıID = kullaniciiD;
                kitapo.TeslimDurumu = false;
                

                bool kaydedildi = OgrenciKitap.EkleDuzenle(kitapo);

                if (kaydedildi)
                {
                    MessageBox.Show("Kitap başarıyla kaydedildi");
                    gridControl1.DataSource = okgrid.GetGridDoldur();
                }
                else
                {
                    MessageBox.Show("Kitap kaydedilirken bir hata oluştu");
                }
            }
        }

        private void Teslimalma_Click(object sender, EventArgs e)
        {
            if (searchLookUpEdit1.EditValue == null && dateEdit2.DateTime == null)
            {
                MessageBox.Show("Malesef Girdiğiniz Değerler Boş");
            }
            else
            {
                EntityFullKitapOgrenci kitapo = new EntityFullKitapOgrenci();
                kitapo.ID = Int32.Parse(label6.Text);
                kitapo.OgrenciID = ((int)searchLookUpEdit1.EditValue);
                kitapo.KitapID = (int)searchLookUpEdit2.EditValue;
                kitapo.AlisTarihi = dateEdit1.DateTime;
                kitapo.TeslimTarihi = dateEdit2.DateTime;
                kitapo.KullanıcıID = kullaniciiD;
                kitapo.TeslimDurumu = true;
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

        private void gridControl1_Click(object sender, EventArgs e)
        {


            int? _id = (int?)gridView1.GetFocusedRowCellValue("ID");

            if (_id != null)
            {
                var data = OgrenciKitap.kitapogrencigetir((int)_id);
                if (data != null)
                {
                    label6.Text = data.ID.ToString();
                    searchLookUpEdit1.EditValue = data.OgrenciID;
                    searchLookUpEdit2.EditValue = data.KitapID;
                    dateEdit1.DateTime = (DateTime)data.AlisTarihi;
                    if (data.TeslimTarihi == null)
                    {
                        dateEdit2.EditValue = null;
                    }
                    else
                    {
                        dateEdit2.DateTime = (DateTime)data.TeslimTarihi;
                    }
                }
            }
        }

        private void searchLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void VeriSilme_Click(object sender, EventArgs e)
        {

            if (gridView1.GetFocusedRow() is EntityFullKitapOgrenci selectedkitapogrenci)
            {
                string silinecek = searchLookUpEdit1.EditValue.ToString();
                selectedkitapogrenci.ID =Int32.Parse( silinecek);
                bool kaydedildi = OgrenciKitap.sil(selectedkitapogrenci);
                if (kaydedildi)
                {
                    MessageBox.Show("Kitap türü başarıyla Silindi");
                }
                else
                {
                    MessageBox.Show("Kitap türü Silinemedi");
                }
            }
        }
    }
}
