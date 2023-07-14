using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Uygulaması.Data
{
    public class DbOgrenci
    {

        public List<OgrenciViewModel> GetOgrenciListesi()
        {
            using (var dbContext = new KutuphaneEntities2())
            {
                var ogrencilistesi = dbContext.Ogrenci.Select(k => new OgrenciViewModel
                {
                    AdiSoyadi = k.AdiSoyadi,
                    OkulNo = k.OkulNo
                }).ToList();

                return ogrencilistesi;
            }
        }
    }

    public class OgrenciViewModel
    {
        public string AdiSoyadi { get; set; }
        public int? OkulNo { get; set; }
    }
}
