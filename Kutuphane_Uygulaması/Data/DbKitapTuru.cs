using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Kutuphane_Uygulaması.Data;


namespace Kutuphane_Uygulaması.Data
{
    static class DbKitapTuru
    {
        public static bool EkleDuzenle(KitapTuru y)
        {

            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {
                if (y.ID == 0)
                {
                    y.KayitTarihi = DateTime.Now;
                    db.KitapTuru.Add(y);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    var kitapturu = db.KitapTuru.FirstOrDefault(x => x.ID == y.ID);

                    kitapturu.Adi = y.Adi;

                    db.SaveChanges();
                    return false;
                }
            }
        }
        public static List<KitapTuru> ListeyeEkle()
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {
                try
                {
                    var Kitapturleri = db.KitapTuru.ToList();
                    return Kitapturleri;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static bool sil(KitapTuru y)
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
                        var silinecekkitaptur = db.KitapTuru.FirstOrDefault(x => x.Adi == y.Adi);
                        db.KitapTuru.Remove(silinecekkitaptur);
                        db.SaveChanges();
                        return true;


                    }
                }
            }
        }

        public static bool KTK(KitapTuru kntrl)
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {

                var kitapturu = db.KitapTuru.FirstOrDefault(x => x.Adi == kntrl.Adi);
                if (kitapturu != null)
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
