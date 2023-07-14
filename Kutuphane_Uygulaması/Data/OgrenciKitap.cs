using System.Collections.Generic;
using System.Linq;
using System;


namespace Kutuphane_Uygulaması.Data
{
    public class OgrenciKitap
    {
        public static bool EkleDuzenle(KitapOgrenci k)
        {
            try
            {
                using (KutuphaneEntities2 db = new KutuphaneEntities2())
                {
                    if (k.ID == 0)
                    {
                        k.KayitTarihi = DateTime.Now;
                        db.KitapOgrenci.Add(k);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        var kitapogrenci = db.KitapOgrenci.FirstOrDefault(x => x.ID == k.ID);
                        
                        kitapogrenci.OgrenciID = k.OgrenciID;
                        kitapogrenci.KitapID= k.KitapID;
                        kitapogrenci.DegisiklikTarihi = DateTime.Now;
                        kitapogrenci.DegisiklikYapan = k.DegisiklikYapan;
                        kitapogrenci.KullanıcıID = k.KullanıcıID;
                    

                        db.SaveChanges();
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<KitapViewModel> GetKitapListesi()
        {
            using (KutuphaneEntities2 dbContext = new KutuphaneEntities2())
            {
                var kitapListesi = dbContext.Kitap.Select(k => new KitapViewModel
                {
                    ID=k.ID,
                    Adi = k.Adi,
                    YayinEviAdi = k.YayinEvi.Adi
                }).ToList();

                return kitapListesi;
            }
        }
    }
    public class OKgrid { 
    
        public List<OKViewModel> GetGridDoldur()    
        {        
            using (KutuphaneEntities2 dbContext = new KutuphaneEntities2())        
            {  
                
               
                var kitapOgrenciListesi = dbContext.KitapOgrenci.Select(ko => new OKViewModel
                {
                    Adi = ko.Kitap.Adi,
                    AdiSoyadi = ko.Ogrenci.AdiSoyadi,
                    OkulNo = ko.Ogrenci.OkulNo,
                    YayinEviAdi = ko.Kitap.YayinEvi.Adi,
                    AlisTarihi = ko.AlisTarihi,
                    TeslimTarihi = ko.TeslimTarihi
                    
                    
                }).ToList();

                return kitapOgrenciListesi;
            }
        }
    }
    public class KitapViewModel
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string YayinEviAdi { get; set; }
    }


    public class OKViewModel
    {
        //6 adet kolon Ogrenci AdiSoyadi, OkulNo  Kitap Adi, YayinEvi KitapOgrenci AlisTarihi, TeslimTarihi
        public string AdiSoyadi { get; set; }
        public int? OkulNo { get; set; }
        public string Adi { get; set; }
        public string YayinEviAdi { get; set; }
        public DateTime? AlisTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }

    }

}
