using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HayatKanali.Models.DAL
{
    public class Relative
    {
        public int Id { get; set; }
        public string IdentificationNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
    }
}