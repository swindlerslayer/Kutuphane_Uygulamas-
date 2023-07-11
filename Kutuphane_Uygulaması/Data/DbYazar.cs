using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Uygulaması.Data
{
    static class DbYazar
    {
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

    }
}
