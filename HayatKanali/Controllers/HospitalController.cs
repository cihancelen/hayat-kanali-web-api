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
    public class HospitalController : ApiController
    {
        [HttpPost]
        [Route("api/hospital/hospitalInfo")]
        public HttpResponseMessage UserInfo([FromBody] Hospital h)
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

        //HayatKanaliDB db = new HayatKanaliDB();

        //[Route("api/hastane/hastanegetir")]
        //[HttpGet]
        //public IEnumerable<Hospital> HastaneleriGetir() => db.Hastaneler.Select(hastane => new Hospital
        //{
        //    Id = hastane.Id,
        //    Ad = hastane.Ad,
        //    Adres = hastane.Adres,
        //    KullaniciAdi = hastane.KullaniciAdi,
        //    Mail = hastane.Mail,
        //    Telefon = hastane.Telefon 
        //}).ToList();

        //[Route("api/hastane/hastanegetir/{id}")]
        //[HttpGet]
        //public Hospital HastaneGetir(int id) => db.Hastaneler.Select(hastane => new Hospital
        //{
        //    Id = hastane.Id,
        //    Ad = hastane.Ad
        //}).FirstOrDefault(x => x.Id == id);
    }
}
