using HayatKanali.Models.DAL;
using HayatKanali.Models.ORM;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace HayatKanali.App_Start
{
    public class ProviderAuthorization : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                var users = db.Kullanicilar.ToList();
                var employees = db.Personeller.ToList();

                if (db.Kullanicilar.Where(user => user.Mail == context.UserName && user.Parola == context.Password).FirstOrDefault() != null)
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