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
    public class ClinicController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddClinic(Clinic clinic)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                Klinikler k = new Klinikler()
                {
                    KlinikAdi = clinic.Name,
                    Aciklama = clinic.Description
                };

                db.Klinikler.Add(k);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, clinic);
            }
        }
    }
}
