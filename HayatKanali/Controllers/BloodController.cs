using HayatKanali.Models.DAL;
using HayatKanali.Models.ORM;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HayatKanali.Controllers
{
    [Authorize]
    public class BloodController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddBloodRequest(BloodRequest request)
        {
            KanTalepleri k = new KanTalepleri()
            {
                Id = request.Id,
                HastaId = request.PatientId,
                KanGrupId = request.BloodGroupId,
                TalepAciklama = request.Description,
                TalepTarihi = DateTime.Now,
                UniteAdet = request.UnitQuantity,
                BeklenenUnite = request.WaitingUnit,
                TeminEdilenUniteAdet = request.SuppliedUnit
            };

            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                db.KanTalepleri.Add(k);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return Request.CreateResponse(HttpStatusCode.Created, k);
            }
        }

    }
}
