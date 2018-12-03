using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HayatKanali.Models.DAL
{
    public class Employee
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Surname { get; set; }
        public int? HospitalId { get; set; }
        public string Username { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
    }
}