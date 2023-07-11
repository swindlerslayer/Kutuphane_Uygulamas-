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
        public static List<KitapTuru> ListeyeEkle()
        {
            using (KutuphaneEntities2 db = new KutuphaneEntities2())
            {
                try
                {
                    //List<KitapTuru> Kitapturleri = db.KitapTuru.ToList();
                    var Kitapturleri = db.KitapTuru.ToList();
                    return Kitapturleri;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
