//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kutuphane_Uygulaması
{
    using System;
    using System.Collections.Generic;
    
    public partial class KitapOgrenci
    {
        public int ID { get; set; }
        public Nullable<int> OgrenciID { get; set; }
        public Nullable<int> KitapID { get; set; }
        public Nullable<System.DateTime> AlisTarihi { get; set; }
        public Nullable<System.DateTime> TeslimTarihi { get; set; }
        public Nullable<int> KullanıcıID { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
        public string DegisiklikYapan { get; set; }
        public Nullable<System.DateTime> DegisiklikTarihi { get; set; }
    
        public virtual Kitap Kitap { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
    }
}
