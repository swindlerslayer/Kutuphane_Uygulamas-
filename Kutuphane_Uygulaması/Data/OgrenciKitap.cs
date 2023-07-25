using System.Collections.Generic;
using System.Linq;
using System;
using static Kutuphane_Uygulaması.Data.Degiskenler;

namespace Kutuphane_Uygulaması.Data
{
    public class OgrenciKitap
    {

        public static EntityFullKitapOgrenci kitapogrencigetir(int id)
        {
            return null;
            //using (KutuphaneEntities2 db = new KutuphaneEntities2())
            //{
            //    var data = db.KitapOgrenci.FirstOrDefault(x => x.ID == id);
            //    if (data != null)
            //    {
            //        return data;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
        }
        public static bool sil(EntityFullKitapOgrenci y)
        {
            return true;

            //using(KutuphaneEntities2 db = new KutuphaneEntities2())
            //{

            //    var kitapogrenci= db.KitapOgrenci.FirstOrDefault(x => x.ID == y.ID);
            //    db.KitapOgrenci.Remove(kitapogrenci);
            //    db.SaveChanges();
            //    return true;
            //}
        }
        public static bool EkleDuzenle(EntityFullKitapOgrenci k)
        {
            return true;
            //try
            //{
            //    using (KutuphaneEntities2 db = new KutuphaneEntities2())
            //    {
            //        if (k.ID == 0)
            //        {
            //            k.KayitTarihi = DateTime.Now;
            //            db.KitapOgrenci.Add(k);
            //            db.SaveChanges();
            //            return true;
            //        }
            //        else
            //        {
            //            var kitapogrenci = db.KitapOgrenci.FirstOrDefault(x => x.ID == k.ID);
                        
            //            kitapogrenci.OgrenciID = k.OgrenciID;
            //            kitapogrenci.KitapID= k.KitapID;
            //            kitapogrenci.DegisiklikTarihi = DateTime.Now;
            //            kitapogrenci.DegisiklikYapan = k.DegisiklikYapan;
            //            kitapogrenci.KullanıcıID = k.KullanıcıID;
            //            kitapogrenci.TeslimTarihi = k.TeslimTarihi;
            //            kitapogrenci.TeslimDurumu = k.TeslimDurumu;

            //            db.SaveChanges();
            //            return false;
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }
        public List<KitapViewModel> GetKitapListesi()
        {
            return null;
            //using (KutuphaneEntities2 dbContext = new KutuphaneEntities2())
            //{
            //    var kitapListesi = dbContext.Kitap.Select(k => new KitapViewModel
            //    {
            //        ID=k.ID,
            //        Adi = k.Adi,
            //        YayinEviAdi = k.YayinEvi.Adi
            //    }).ToList();

            //    return kitapListesi;
            //}
        }
    }
    public class OKgrid { 
    
        public List<OKViewModel> GetGridDoldur()    
        {
            return null;
            //using (KutuphaneEntities2 dbContext = new KutuphaneEntities2())        
            //{  
                
               
            //    var kitapOgrenciListesi = dbContext.KitapOgrenci.Select(ko => new OKViewModel
            //    {
            //        ID = ko.ID,
            //        Adi = ko.Kitap.Adi,
            //        AdiSoyadi = ko.Ogrenci.AdiSoyadi,
            //        OkulNo = ko.Ogrenci.OkulNo,
            //        YayinEviAdi = ko.Kitap.YayinEvi.Adi,
            //        AlisTarihi = ko.AlisTarihi,
            //        TeslimTarihi = ko.TeslimTarihi,
            //        TeslimDurumu = ko.TeslimDurumu == true
            //        ? true
            //        : false

            //    }).ToList();

            //    return kitapOgrenciListesi;
            //}
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
        public int? ID { get; set; }

        public string AdiSoyadi { get; set; }
        public int? OkulNo { get; set; }
        public string Adi { get; set; }
        public string YayinEviAdi { get; set; }
        public DateTime? AlisTarihi { get; set; }
        public Nullable<DateTime> TeslimTarihi { get; set; }
        public bool TeslimDurumu { get; set; }

    }

}
