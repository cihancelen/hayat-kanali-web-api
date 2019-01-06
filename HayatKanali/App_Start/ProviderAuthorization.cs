using HayatKanali.Helpers;
using HayatKanali.Models.ORM;
using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

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
                    if (db.Kullanicilar.Where(user => user.Mail == context.UserName).FirstOrDefault() != null)
                    {
                        if (db.Kullanicilar.Where(user => user.Parola == pass).FirstOrDefault() != null)
                        {
                            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                            identity.AddClaim(new Claim("sub", context.UserName));
                            identity.AddClaim(new Claim("role", "user"));
                            context.Validated(identity);
                        }
                        else
                        {
                            context.SetError("Wrong Pass", "Parola hatalıdır.");
                        }
                    }
                    else
                    {
                        context.SetError("Not Found User", "Böyle bir kullanıcı kaydı bulunamadı.");
                    }
                }
                else if (login_type == "hospital")
                {
                    if (db.Hastaneler.Where(hos => hos.Mail == context.UserName).FirstOrDefault() != null)
                    {
                        if (db.Hastaneler.Where(hos => hos.Parola == pass).FirstOrDefault() != null)
                        {
                            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                            identity.AddClaim(new Claim("sub", context.UserName));
                            identity.AddClaim(new Claim("role", "user"));
                            context.Validated(identity);
                        }
                        else
                        {
                            context.SetError("Wrong Pass", "Parola hatalıdır.");
                        }
                    }
                    else
                    {
                        context.SetError("Not Found Hospital", "Böyle bir hastane kaydı bulunamadı.");
                    }
                }
                else if (login_type == "employee")
                {
                    if (db.Personeller.Where(user => user.Mail == context.UserName && user.Parola == pass).FirstOrDefault() != null)
                    {
                        if (db.Personeller.Where(per => per.Parola == pass).FirstOrDefault() != null)
                        {
                            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                            identity.AddClaim(new Claim("sub", context.UserName));
                            identity.AddClaim(new Claim("role", "user"));

                            context.Validated(identity);
                        }
                        else
                        {
                            context.SetError("Wrong Pass", "Parola hatalıdır.");
                        }
                    }
                    else
                    {
                        context.SetError("Not Found Employee", "Böyle bir personel kaydı bulunamadı.");
                    }
                }

            }
        }
    }
}