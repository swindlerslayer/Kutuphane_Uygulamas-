using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Uygulaması.Data
{
    public static class StaticDegiskenler
    {
        public static Kullanici Kullanici { get; set; }
    }
    public class Degiskenler
    {
        public class EntityFullKitap
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public int? SayfaSayisi { get; set; }
            public int? KitapTurID { get; set; }
            public int? YayinEviID { get; set; }
            public int? YazarID { get; set; }
            public int? Barkod { get; set; }
            public string KayitYapan { get; set; }
            public DateTime? KayitTarihi { get; set; }
            public string DegisiklikYapan { get; set; }
            public DateTime? DegisiklikTarihi { get; set; }
            public byte[] Resim { get; set; }
        }
  
        public class EntityKitap
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public int YazarID { get; set; }
            public string YazarAdi { get; set; }
            public byte[] Resim { get; set; }
        }
        public class TokenClass
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
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
