using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Uygulaması.Data
{
    public static class DbKullanici
    {

        public static bool EkleDuzenle(Kullanici k)
        {
            try
            {
                using (KutuphaneEntities2 db = new KutuphaneEntities2())
                {
                    if (k.ID == 0)
                    {
                        k.KayitTarihi = DateTime.Now;
                        k.KayitYapan = k.KullaniciAdi;                        
                        db.Kullanici.Add(k);
                        db.SaveChanges();
                    }
                    else
                    {
                        var kullanici = db.Kullanici.FirstOrDefault(x => x.ID == k.ID);

                        kullanici.KullaniciAdi = k.KullaniciAdi;
                        kullanici.Parola = k.Parola;
                        kullanici.DegisiklikTarihi = DateTime.Now;
                        kullanici.DegisiklikYapan = k.KullaniciAdi;
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
