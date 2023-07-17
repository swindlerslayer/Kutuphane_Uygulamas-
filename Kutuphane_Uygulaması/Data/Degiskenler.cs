using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Uygulaması.Data
{
    public class Degiskenler
    {
       public class EntityKitap
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public string YazarAdi { get; set; }
            public int? YazarID { get; set; }
        }
        public class EntityYazar
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public string YazarAdi { get; set; }
            public int? YazarID { get; set; }
        }

        public class EntityKullanici
        {
            public int ID { get; set; }
            public string KullaniciAdi { get; set; }
            public string Parola { get; set; }


        }
    }
    
}
