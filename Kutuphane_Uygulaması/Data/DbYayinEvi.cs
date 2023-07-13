using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Uygulaması.Data
{
    static class DbYayinEvi
    {
        public static List<YayinEvi> ListeyeEkle()
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {
                try
                {
                    var Yayinevleri = db.YayinEvi.ToList();
                    return Yayinevleri;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static bool sil(YayinEvi y)
        {
            using(KutuphaneEntities2 db = new KutuphaneEntities2())
            {
                var kitapkontrol = db.Kitap.FirstOrDefault(x => x.YayinEviID == y.ID);
                if(kitapkontrol != null) {
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
                        var silinecekyayinevi = db.YayinEvi.FirstOrDefault(x => x.Adi == y.Adi);
                        db.YayinEvi.Remove(silinecekyayinevi);
                        db.SaveChanges();
                        return true;

                    }
                }
            }
        }
        public static bool EkleDuzenle(YayinEvi y)
        {

            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {
                if (y.ID == 0)
                {
                    y.KayitTarihi = DateTime.Now;
                    db.YayinEvi.Add(y);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    var yayinevi = db.YayinEvi.FirstOrDefault(x => x.ID == y.ID);

                    yayinevi.Adi = y.Adi;

                    db.SaveChanges();
                    return false;
                }
            }
        }

        public static bool YK(YayinEvi kntrl)
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {

                var yayinevi = db.YayinEvi.FirstOrDefault(x => x.Adi == kntrl.Adi);
                if (yayinevi != null)
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
