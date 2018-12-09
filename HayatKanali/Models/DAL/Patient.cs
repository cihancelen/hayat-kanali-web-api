using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HayatKanali.Models.DAL
{
    public class Patient
    {
        public int Id { get; set; }
        public string IdentificationNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string Disease { get; set; }
        public string Gender { get; set; }

        public int? RelativeId { get; set; }
        public int? BloodGroupId { get; set; }
        public int? DoctorId { get; set; }
        public int? HospitalId { get; set; }

        public string BloodGroup { get; set; }
    }
}