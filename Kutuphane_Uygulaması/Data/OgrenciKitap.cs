using System.Collections.Generic;
using System.Linq;
using System;


namespace Kutuphane_Uygulaması.Data
{
    public class OgrenciKitap
    {
        public List<KitapViewModel> GetKitapListesi()
        {
            using (KutuphaneEntities2 dbContext = new KutuphaneEntities2())
            {
                var kitapListesi = dbContext.Kitap.Select(k => new KitapViewModel
                {
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
