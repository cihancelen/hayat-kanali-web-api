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
    public class UserController : ApiController
    {
        HayatKanaliDB db = new HayatKanaliDB();

        public HttpResponseMessage GetUserInfo(int userId)
        {
            User u = db.Kullanicilar.Select(x => new User()
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
            }).FirstOrDefault(x => x.Id == userId);

            return Request.CreateResponse(HttpStatusCode.Accepted, u);
        }
    }
}
