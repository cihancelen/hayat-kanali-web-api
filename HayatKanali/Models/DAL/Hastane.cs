using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HayatKanali.Models.DAL
{
    public class Hastane
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Konum { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
    }
}