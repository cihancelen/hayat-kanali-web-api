using HayatKanali.Models.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HayatKanali.Models.DAL
{
    public class User
    {
        public int Id { get; set; }
        public string IdentificationNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? UsingSmokingAndAlcohol { get; set; }
        public DateTime LastBloodDonation { get; set; }
        public int? BloodGroupId { get; set; }
        public string BloodGroup { get; set; }
        public int CityId { get; set; }
        public string District { get; set; }
        public IEnumerable<int> Diseases { get; set; }
        public string Password { get; set; }
    }
}