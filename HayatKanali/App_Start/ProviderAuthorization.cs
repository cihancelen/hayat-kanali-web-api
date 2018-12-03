using HayatKanali.Helpers;
using HayatKanali.Models.DAL;
using HayatKanali.Models.ORM;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;

namespace HayatKanali.App_Start
{
    public class ProviderAuthorization : OAuthAuthorizationServerProvider
    {
        string login_type = "default-user";

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            login_type = context.Parameters.Where(x => x.Key == "login_type").Select(f => f.Value).FirstOrDefault()[0];
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                string pass = Crypto.GetMd5Hash(MD5.Create(), context.Password);

                if (login_type == "default-user")
                {
                    var users = db.Kullanicilar.ToList();

                    if (db.Kullanicilar.Where(user => user.Mail == context.UserName && user.Parola == pass).FirstOrDefault() != null)
                    {
                        ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                        identity.AddClaim(new Claim("sub", context.UserName));
                        identity.AddClaim(new Claim("role", "user"));

                        context.Validated(identity);
                    }
                    else
                    {
                        context.SetError("hata", "Kullanıcı adı veya şifre hatalı.");
                    }
                }
                else if (login_type == "hospital")
                {
                    var hospitals = db.Hastaneler.ToList();

                    if (db.Hastaneler.Where(user => user.Mail == context.UserName && user.Parola == pass).FirstOrDefault() != null)
                    {
                        ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                        identity.AddClaim(new Claim("sub", context.UserName));
                        identity.AddClaim(new Claim("role", "user"));

                        context.Validated(identity);
                    }
                    else
                    {
                        context.SetError("hata", "Kullanıcı adı veya şifre hatalı.");
                    }
                }
                else if (login_type == "employee")
                {
                    var employees = db.Personeller.ToList();

                    if (db.Personeller.Where(user => user.Mail == context.UserName && user.Parola == pass).FirstOrDefault() != null)
                    {
                        ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                        identity.AddClaim(new Claim("sub", context.UserName));
                        identity.AddClaim(new Claim("role", "user"));

                        context.Validated(identity);
                    }
                    else
                    {
                        context.SetError("hata", "Kullanıcı adı veya şifre hatalı.");
                    }
                }

            }
        }
    }
}