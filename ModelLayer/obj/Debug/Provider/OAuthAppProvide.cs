using AGPeshawarAPI.Models;
using AGPeshawarAPI.Repositories;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using static AGPeshawarAPI.Models.User;

namespace AGPeshawarAPI.Provider
{
    public class OAuthAppProvide : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {

               
                LoginModel loginUser = new LoginModel();
                loginUser.UserName = context.UserName;
                loginUser.Password = context.Password;
                LoginModel user = new AccountRepository().ValidateUser(loginUser);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                            new Claim("obj", JsonConvert.SerializeObject(user)),
                            new Claim("UserId", user.UserId.ToString())
                    };

                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
                }
                catch (Exception)
                {

                    throw;
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}
