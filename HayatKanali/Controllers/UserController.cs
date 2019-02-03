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
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/user/userInfo")]
        public HttpResponseMessage UserInfo([FromBody] User u)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                User user = db.Kullanicilar.Select(x => new User()
                {
                    Id = x.Id,
                    Name = x.Ad,
                    Surname = x.Soyad,
                    Birthday = x.DogumTarihi,
                    BloodGroupId = x.KanGrubuId,
                    CityId = x.CityId,
                    District = x.District,
                    Email = x.Mail,
                    IdentificationNo = x.TcKimlik,
                    LastBloodDonation = x.SonKanVermeTarihi,
                    Phone = x.Telefon,
                    UsingSmokingAndAlcohol = x.SigaraAlkolKullanimi,
                    BloodGroup = db.KanGruplari.FirstOrDefault(k => k.Id == x.KanGrubuId).KanGrubu
                }).FirstOrDefault(x => x.Email == u.Email);

                return Request.CreateResponse(HttpStatusCode.Accepted, user);
            }

        }

        [HttpGet]
        public HttpResponseMessage GetBloodRequestsByUser(int id)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                var user = db.Kullanicilar.FirstOrDefault(x => x.Id == id);

                var s = (from talep in db.KanTalepleri
                        join hastalar in db.Hastalar on talep.HastaId equals hastalar.Id
                        join hastaneler in db.Hastaneler on hastalar.HastaneId equals hastaneler.Id
                        where hastaneler.District == user.District
                        select new
                        {
                            RequestId = talep.Id,
                            PatientId = hastalar.Id,
                            PatientName = hastaneler.Ad
                        }).ToList();


                return Request.CreateResponse(HttpStatusCode.OK, s);
            }
        }

    }
}
