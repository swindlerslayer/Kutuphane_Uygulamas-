using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Uygulaması.Data
{
    static class DbYazar
    {

        public static bool EkleDuzenle(Yazar y)
        {

            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {
                if (y.ID == 0)
                {
                    y.KayitTarihi = DateTime.Now;
                    db.Yazar.Add(y);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    var yazar = db.Yazar.FirstOrDefault(x => x.ID == y.ID);

                    yazar.AdiSoyadi = y.AdiSoyadi;

                    db.SaveChanges();
                    return false;
                }
            }
        }
        public static List<Yazar> ListeyeEkle()
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {
                try
                {
                    var yazarlar = db.Yazar.ToList();
                    return yazarlar;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static bool sil(Yazar y)
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {
                var kitapkontrol = db.Kitap.FirstOrDefault(x => x.YazarID == y.ID);
                if (kitapkontrol != null)
                {
                    return false;
                }                
                else {                 
                    if (y.ID == 0)                  
                    {                    
                        return false;                
                    }                
                    else
                    {
                        var silinecekyazar = db.Yazar.FirstOrDefault(x => x.AdiSoyadi == y.AdiSoyadi);
                        db.Yazar.Remove(silinecekyazar);
                        db.SaveChanges();
                        return true;

                
                    }
                }
            }
        }

        public static bool YK(Yazar kntrl)
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {

                var yazar = db.Yazar.FirstOrDefault(x => x.AdiSoyadi == kntrl.AdiSoyadi);
                if (yazar != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
