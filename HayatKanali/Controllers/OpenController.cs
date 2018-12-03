using HayatKanali.Models.DAL;
using HayatKanali.Models.ORM;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HayatKanali.Controllers
{
    public class OpenController : ApiController
    {
        [Route("api/open/getBloodGroups")]
        public IEnumerable<BloodGroup> GetBloodGroups()
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                return db.KanGruplari.Select(x => new BloodGroup()
                {
                    Id = x.Id,
                    Name = x.KanGrubu
                }).ToList();
            }
        }

        [Route("api/open/getDiseases")]
        public IEnumerable<Diseases> GetDiseases()
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                return db.KalitsalHastaliklar.Select(x => new Diseases()
                {
                    Id = x.Id,
                    Name = x.HastalikAdi
                }).ToList();
            }
        }
    }
}
