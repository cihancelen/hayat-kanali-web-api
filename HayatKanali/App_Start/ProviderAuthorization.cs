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

        private string mail;
        private string password;
        Kullanicilar user;

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Domainler arası etkileşim ve kaynak paylaşımını sağlayan ve bir domainin bir başka domainin kaynağını kullanmasını sağlayan CORS ayarlarını set ediyoruz.
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //Kullanıcının access_token alabilmesi için gerekli validation işlemlerini yapıyoruz.
            using (HayatKanaliDB db = new HayatKanaliDB())
            {
                user = db.Kullanicilar.FirstOrDefault(u => u.Mail == mail && u.Parola == password);
            }

            if (context.UserName == user.Mail && context.Password == user.Parola)
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

        public void Login(string mail, string pass)
        {
            this.mail = mail;
            this.password = pass;
        }
    }
}