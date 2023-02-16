using DatabaseLayer.Repositories;

using ModelLayer.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using static ModelLayer.User;

namespace AGPeshawarAPI.Controllers
{
    [EnableCors(origins: "https://agpeshawar.org", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Account/Register")]
        public IHttpActionResult RegisterUser(UserDTO model)
        {
            try
            {
                if (model == null)
                {
                    return Content(HttpStatusCode.BadRequest, new { Message = "Invalid Data", IsSaved = false });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                 
                // UserRegistration
                var id = new AccountRepository().RegisterUser(model);
                if (id == 10)
                {
                    return Content(HttpStatusCode.Conflict, new { Message = "Username Already Exists", IsSaved = false });
                }
                return Content(HttpStatusCode.OK, new { Message = "User Register Successfully", IsSaved = true });

            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        [Route("api/Account/Login")]
        public IHttpActionResult Login(LoginModel.Request model)
        {
            try
            {
                LoginModel.Response user = new AccountRepository().ValidateUser(model);
                if (user != null)
                {
                    return Content(HttpStatusCode.OK, new { LoginStatus = "Login Successfully", UserData = user });
                }
                else
                {
                    return Content(HttpStatusCode.OK, new { LoginStatus = "Login Failed", UserData = user });
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
