using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HayatKanali.Models.DAL
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? CityId { get; set; }
        public string District { get; set; }
    }
}