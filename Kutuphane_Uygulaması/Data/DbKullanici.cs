using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Kutuphane_Uygulaması.Data.Degiskenler;

namespace Kutuphane_Uygulaması.Data
{
    public static class DbKullanici
    {


        //public static object ListeyeEkle()
        //{
        //    using (KutuphaneEntities2 db = new KutuphaneEntities2())
        //    {
        //        var kullanici = db.Kullanici.Select(x => new EntityKullanici
        //        {
        //            ID = x.ID,
        //            KullaniciAdi = x.KullaniciAdi,
        //            Parola = x.Parola,
        //        }).ToList();
        //        return kullanici;
        //    }
        //}
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
                        return true;
                    }
                    else
                    {
                        return false;
                        //var kullanici = db.Kullanici.FirstOrDefault(x => x.ID == k.ID);

                        //kullanici.KullaniciAdi = k.KullaniciAdi;
                        //kullanici.Parola = k.Parola;
                        //kullanici.DegisiklikTarihi = DateTime.Now;
                        //kullanici.DegisiklikYapan = k.KullaniciAdi;
                        //db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool KK(Kullanici kntrl)
        {
            using(KutuphaneEntities2 db = new KutuphaneEntities2())
            { 

                var kullanici = db.Kullanici.FirstOrDefault(x => x.KullaniciAdi == kntrl.KullaniciAdi);
                if(kullanici != null)
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
