using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HayatKanali.Models.DAL
{
    public class User
    {
        public int Id { get; set; }
        public string TcKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Parola { get; set; }
        public bool SigaraAlkolKullanimi { get; set; }
        public DateTime SonKanVermeTarihi { get; set; }
        public string KanGrubu { get; set; }
    }
}