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
    [Authorize]
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

        [HttpPost]
        [Route("api/employee/addEmployee")]
        public HttpResponseMessage AddEmployee(Employee employee)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                Personeller p = new Personeller()
                {
                    Ad = employee.Name,
                    Soyad = employee.Surname,
                    KullaniciAdi = employee.Username,
                    Mail = employee.Email,
                    Parola = employee.Password,
                    HastaneId = employee.HospitalId
                };

                db.Personeller.Add(p);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, employee);
            }
        }
    }
}
