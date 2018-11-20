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
    public class HastaneController : ApiController
    {
        HayatKanaliDB db = new HayatKanaliDB();

        [Route("api/hastane/hastanegetir")]
        [HttpGet]
        public IEnumerable<Hospital> HastaneleriGetir() => db.Hastaneler.Select(hastane => new Hospital
        {
            Id = hastane.Id,
            Ad = hastane.Ad,
            Adres = hastane.Adres,
            KullaniciAdi = hastane.KullaniciAdi,
            Mail = hastane.Mail,
            Telefon = hastane.Telefon 
        }).ToList();

        [Route("api/hastane/hastanegetir/{id}")]
        [HttpGet]
        public Hospital HastaneGetir(int id) => db.Hastaneler.Select(hastane => new Hospital
        {
            Id = hastane.Id,
            Ad = hastane.Ad
        }).FirstOrDefault(x => x.Id == id);
    }
}
