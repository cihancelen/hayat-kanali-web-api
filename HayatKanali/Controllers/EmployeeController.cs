using HayatKanali.Models.DAL;
using HayatKanali.Models.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HayatKanali.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpPost]
        [Route("api/employee/employeeInfo")]
        public HttpResponseMessage EmployeeInfo([FromBody] Employee e)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                Employee employee = db.Personeller.Select(x => new Employee()
                {
                    Id = x.Id,
                    Email = x.Mail,
                    HospitalId = x.HastaneId,
                    Name = x.Ad,
                    Surname = x.Soyad,
                    Username = x.KullaniciAdi
                }).FirstOrDefault(x => x.Email == e.Email);

                return Request.CreateResponse(HttpStatusCode.Accepted, employee);
            }
        }
    }
}
