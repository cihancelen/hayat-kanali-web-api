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
    public class PatientController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetPatientsByHospital(int id)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                IEnumerable<Patient> patients = db.Hastalar.Where(x => x.HastaneId == id).Select(p => new Patient()
                {
                    Id = p.Id,
                    Birthday = p.DogumTarihi,
                    BloodGroupId = p.KanGrubuId,
                    Disease = p.Hastalik,
                    DoctorId = p.DoktorId,
                    Gender = p.Cinsiyet,
                    HospitalId = p.HastaneId,
                    IdentificationNo = p.TcKimlik,
                    Email = p.Mail,
                    Name = p.Ad,
                    Surname = p.Soyad,
                    Phone = p.Telefon,
                    RelativeId = p.HastaYakiniId,
                    BloodGroup = db.KanGruplari.FirstOrDefault(k => k.Id == p.KanGrubuId).KanGrubu
                }).ToList();

                if (patients.Count() > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, patients);
                else
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, patients);
            }
        }

        [HttpGet]
        [Route("api/getPatient/{id}")]
        public Patient GetPatient(int id)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                return db.Hastalar.Where(x => x.Id == id).Select(p => new Patient()
                {
                    Id = p.Id,
                    Birthday = p.DogumTarihi,
                    BloodGroupId = p.KanGrubuId,
                    Disease = p.Hastalik,
                    DoctorId = p.DoktorId,
                    Gender = p.Cinsiyet,
                    HospitalId = p.HastaneId,
                    IdentificationNo = p.TcKimlik,
                    Email = p.Mail,
                    Name = p.Ad,
                    Surname = p.Soyad,
                    Phone = p.Telefon,
                    RelativeId = p.HastaYakiniId,
                    BloodGroup = db.KanGruplari.FirstOrDefault(k => k.Id == p.KanGrubuId).KanGrubu
                }).FirstOrDefault();
            }
        }

        [HttpPost]
        [Route("api/patient/addPatient")]
        public HttpResponseMessage addPatient(Patient p)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                Hastalar h = new Hastalar()
                {
                    Ad = p.Name,
                    Cinsiyet = p.Gender,
                    DogumTarihi = p.Birthday,
                    DoktorId = p.DoctorId,
                    HastaneId = p.HospitalId,
                    HastaYakiniId = p.RelativeId,
                    KanGrubuId = p.BloodGroupId,
                    Mail = p.Email,
                    Soyad = p.Surname,
                    TcKimlik = p.IdentificationNo,
                    Telefon = p.Phone,
                    Hastalik = p.Disease
                };

                db.Hastalar.Add(h);
                try
                {
                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.Created, p);
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

        [HttpPost]
        [Route("api/patient/addRelative")]
        public HttpResponseMessage addRelative(Relative r)
        {
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                HastaYakinlari h = new HastaYakinlari()
                {
                    Ad = r.Name,
                    Cinsiyet = r.Gender,
                    DogumTarihi = r.Birthday,
                    Mail = r.Email,
                    Soyad = r.Surname,
                    TcKimlik = r.IdentificationNo,
                    Telefon = r.Phone
                };

                db.HastaYakinlari.Add(h);

                try
                {
                    db.SaveChanges();

                    var relative = db.HastaYakinlari.Select(x => new Relative()
                    {
                        Id = x.Id,
                        Birthday = x.DogumTarihi,
                        Email = x.Mail,
                        Gender = x.Cinsiyet,
                        IdentificationNo = x.TcKimlik,
                        Name = x.Ad,
                        Phone = x.Telefon,
                        Surname = x.Soyad
                    }).FirstOrDefault();

                    return Request.CreateResponse(HttpStatusCode.Created, relative);
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }
    }
}
