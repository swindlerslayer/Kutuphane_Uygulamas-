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



        public static bool EkleDuzenle(EntityKullanici k)
        {
            return true;
            //try
            //{
            //    using (KutuphaneEntities2 db = new KutuphaneEntities2())
            //    {
            //        if (k.ID == 0)
            //        {


            //            k.KayitTarihi = DateTime.Now;
            //            k.KayitYapan = k.KullaniciAdi;
            //            db.Kullanici.Add(k);
            //            db.SaveChanges();
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }

        public static bool KK(EntityKullanici kntrl)
        {
            return true;
            //using (KutuphaneEntities2 db = new KutuphaneEntities2())
            //{

            //    var kullanici = db.Kullanici.FirstOrDefault(x => x.KullaniciAdi == kntrl.KullaniciAdi);
            //    if (kullanici != null)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
        }
        public static EntityKullanici KullaniciControl(string kullaniciAdi, string parola, bool loginMi)
        {
            var data = URL.Kullanici.KullaniciKontrol.Get<EntityKullanici>($"?kullaniciAdi={kullaniciAdi}&parola={parola}", kullaniciAdi: kullaniciAdi, parola: parola);
            return data;
        }
    }
}
