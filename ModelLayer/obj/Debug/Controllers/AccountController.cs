using AGPeshawarAPI.Models;
using AGPeshawarAPI.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static AGPeshawarAPI.Models.User;

namespace AGPeshawarAPI.Controllers
{
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
                    return Content(HttpStatusCode.BadRequest, new { Message = "Invalid Data." });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string json = JsonConvert.SerializeObject(model);
                //Logging.Logger.Information("api/Account/Register Parameters : " + json);

                // UserRegistration
                var id = new AccountRepository().RegisterUser(model);
                if (id == 10)
                {
                    //Logging.Logger.Information("UserName already exists in database");
                    return Content(HttpStatusCode.Conflict, new ContentResult("User Name already exists in database"));
                }
                return Content(HttpStatusCode.OK, new ContentResult("User Register Successfully"));

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
