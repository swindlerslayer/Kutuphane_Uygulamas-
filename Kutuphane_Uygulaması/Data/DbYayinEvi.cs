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
    }
}
