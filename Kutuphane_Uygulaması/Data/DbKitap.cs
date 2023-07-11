using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kutuphane_Uygulaması.Data.Degiskenler;

namespace Kutuphane_Uygulaması.Data
{
    static class DbKitap
    {
        public static object ListeyeEkle()
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {
                var kitaplar = db.Kitap.Select(x => new EntityKitap
                {
                    ID = x.ID,
                    Adi = x.Adi,
                    YazarID = x.YazarID,
                    YazarAdi = x.Yazar.AdiSoyadi,
                }).ToList();
                return kitaplar;
            }
        }
        public static bool EkleDuzenle(Kitap k)
        {
            try
            {
                using (KutuphaneEntities2 db = new KutuphaneEntities2())
                {

                    if (k.ID == 0)
                    {
                        k.KayitTarihi = DateTime.Now;
                        db.Kitap.Add(k);
                        db.SaveChanges();
                    }


                    else
                    {
                        var kitap = db.Kitap.FirstOrDefault(x => x.ID == k.ID);

                        kitap.Adi = k.Adi;
                        kitap.SayfaSayisi = k.SayfaSayisi;
                        kitap.DegisiklikTarihi = DateTime.Now;
                        kitap.DegisiklikYapan = k.DegisiklikYapan;
                        kitap.Barkod = k.Barkod;
                        kitap.DegisiklikTarihi = DateTime.Now;

                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
