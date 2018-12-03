using HayatKanali.Models.DAL;
using HayatKanali.Models.ORM;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using HayatKanali.Helpers;

namespace HayatKanali.Controllers
{
    public class AuthController : ApiController
    {
        HayatKanaliDB db = new HayatKanaliDB();

        [HttpPost]
        [Route("api/auth/registeruser")]
        public HttpResponseMessage RegisterUser(User user)
        {
            if (db.Kullanicilar.FirstOrDefault(x => x.Mail == user.Email) == null)
            {
                string pass = Crypto.GetMd5Hash(MD5.Create(), user.Password);

                Kullanicilar u = new Kullanicilar()
                {
                    Ad = user.Name,
                    Soyad = user.Surname,
                    CityId = user.CityId,
                    District = user.District,
                    DogumTarihi = user.Birthday,
                    KanGrubuId = user.BloodGroupId,
                    Mail = user.Email,
                    Parola = pass,
                    SigaraAlkolKullanimi = user.UsingSmokingAndAlcohol,
                    TcKimlik = user.IdentificationNo,
                    SonKanVermeTarihi = user.LastBloodDonation,
                    Telefon = user.Phone
                };

                db.Kullanicilar.Add(u);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }

                //int count = user.Diseases.Count();

                //if (count > 1)
                //{
                //    foreach (var item in user.Diseases)
                //    {
                //        db.KullaniciKalitsalHastalik.Add(new KullaniciKalitsalHastalik()
                //        {
                //            KalitsalHastalikId = (int)item,
                //            KullaniciId = u.Id
                //        });

                //    }
                //}

                var user_bloodGroup = db.KanGruplari.FirstOrDefault(x => x.Id == u.KanGrubuId).KanGrubu;

                User added_user = new User()
                {
                    Id = u.Id,
                    Name = u.Ad,
                    Surname = u.Soyad,
                    Birthday = u.DogumTarihi,
                    Email = u.Mail,
                    UsingSmokingAndAlcohol = u.SigaraAlkolKullanimi,
                    LastBloodDonation = u.SonKanVermeTarihi,
                    IdentificationNo = u.TcKimlik,
                    Phone = u.Telefon,
                    BloodGroupId = u.KanGrubuId,
                    BloodGroup = user_bloodGroup,
                    CityId = u.CityId,
                    District = u.District
                };

                return Request.CreateResponse(HttpStatusCode.Created, added_user);
            }

            return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Bu email ile daha önce kayıt olunmuştur.");
        }

        [HttpPost]
        [Route("api/auth/userInfo")]
        public HttpResponseMessage UserInfo(string email)
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
            }).FirstOrDefault(x => x.Email == email);

            return Request.CreateResponse(HttpStatusCode.Accepted, user);
        }
    }
}
