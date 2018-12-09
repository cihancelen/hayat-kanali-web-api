using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HayatKanali.Models.DAL
{
    public class BloodRequest
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int? PatientId { get; set; }
        public int? BloodGroupId { get; set; }
        public int? UnitQuantity { get; set; }
        public int? WaitingUnit { get; set; }
        public int? SuppliedUnit { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? EmployeeId { get; set; }

    }
}