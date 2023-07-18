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
                    Resim = x.Resim
                }).ToList();
                return kitaplar;
            }
        }
        public static bool EkleDuzenle(Kitap k)
        {
                using (KutuphaneEntities2 db = new KutuphaneEntities2())
                {
                    if (k.ID == 0)
                    {
                        k.KayitTarihi = DateTime.Now;
                        db.Kitap.Add(k);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        var kitap = db.Kitap.FirstOrDefault(x => x.ID == k.ID);

                    kitap.Adi = k.Adi;
                    kitap.SayfaSayisi = k.SayfaSayisi;
                    kitap.DegisiklikTarihi = DateTime.Now;
                    kitap.DegisiklikYapan = k.DegisiklikYapan;
                    kitap.Barkod = k.Barkod;
                    kitap.YazarID = k.YazarID; // Güncellenen YazarID
                    kitap.YayinEviID = k.YayinEviID; // Güncellenen YayinEviID
                    kitap.Resim = k.Resim;

                  
                    db.SaveChanges();
                        return false;
                    }
                }
                
            
            
        }

        public static bool KitapKontrolKontrol(Kitap kntrl)
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {

                var kitap = db.Kitap.FirstOrDefault(x => x.Adi == kntrl.Adi);
                if (kitap != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool resimsil(Kitap y)
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {

                if (y.ID == 0)
                {
                    return false;
                }
                else
                {
                    var kitap = db.Kitap.FirstOrDefault(x => x.ID == y.ID);
                    if (kitap != null)
                    {
                        kitap.Resim = null;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }




            }

        }
        public static bool sil(Kitap y)
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {


                var kitapturkontrol = db.Kitap.FirstOrDefault(x => x.KitapTurID == y.ID);
                if (kitapturkontrol != null)
                {
                    return false;
                }
                else
                {
                    if (y.ID == 0)
                    {
                        return false;
                    }
                    else
                    {
                        var kitap = db.Kitap.FirstOrDefault(x => x.ID == y.ID);
                        db.Kitap.Remove(kitap);
                        db.SaveChanges();
                        return true;
                    }
                }           
                
            }
        }
        public static Kitap KitapGetir(int id)
        {
            using (KutuphaneEntities2 db=new KutuphaneEntities2())
            {
                var data = db.Kitap.FirstOrDefault(x => x.ID == id);
                if (data!=null)
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
