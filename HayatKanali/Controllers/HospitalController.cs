using HayatKanali.Models.DAL;
using HayatKanali.Models.ORM;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HayatKanali.Controllers
{
    public class HospitalController : ApiController
    {
        [HttpPost]
        [Route("api/hospital/hospitalInfo")]
        public HttpResponseMessage HospitalInfo([FromBody] Hospital h)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                Hospital hospital = db.Hastaneler.Select(x => new Hospital()
                {
                    Id = x.Id,
                    Address = x.Adres,
                    CityId = x.CityId,
                    District = x.District,
                    Email = x.Mail,
                    Location = x.Konum,
                    Name = x.Ad,
                    Phone = x.Telefon,
                    Username = x.KullaniciAdi
                }).FirstOrDefault(x => x.Email == h.Email);

                return Request.CreateResponse(HttpStatusCode.Accepted, hospital);
            }

        }

        [HttpGet]
        public HttpResponseMessage GetDoctorsByHosptial(int id)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                IEnumerable<Doctor> doctors = db.Doktorlar.Where(x => x.HastaneId == id).Select(d => new Doctor()
                {
                    Id = d.Id,
                    Email = d.Mail,
                    HospitalId = d.HastaneId,
                    Name = d.Ad,
                    Phone = d.Telefon,
                    Surname = d.Soyad
                }).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, doctors);
            }
        }

        
    }
}
