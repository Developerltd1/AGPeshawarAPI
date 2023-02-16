using AGPeshawarAPI.Models;
using AGPeshawarAPI.Repositories;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Http;
using System.Security.Claims;
using static AGPeshawarAPI.Models.User;
using System.Linq;

namespace AGPeshawarAPI.Controllers
{
    public class AgPeshawarController : ApiController
    {
        [Authorize]
        [HttpPost]
        [Route("api/AgPeshawar/PostUserRecord")]
        public IHttpActionResult PostUserRecord([FromBody] UserData value)
        {
            try
            {
                var userObject = (ClaimsIdentity)User.Identity;
                LoginModel user = JsonConvert.DeserializeObject<LoginModel>(userObject.Claims.Where(obj => obj.Type == "obj").Single().Value);


                //Logging.Logger.Information("api/AgPeshawar/PostUserRecord: Initilize: " + JsonConvert.SerializeObject(value));
                if (value == null)
                {
                    // 400 Bad Request
                    //Logging.Logger.Error("api/AgPeshawar/PostUserRecord: value == null, Parameters:" + JsonConvert.SerializeObject(value));
                    return Content(HttpStatusCode.BadRequest, new ContentResult("Transaction Failed", "Invalid Data", new { TransactionNo = "0" }));

                }
                if (!ModelState.IsValid)
                {
                    //Logging.Logger.Error("api/AgPeshawar/PostUserRecord:  ModelState.IsValid == false, Parameters:" + JsonConvert.SerializeObject(value));
                    return BadRequest(ModelState);
                }

                string json = JsonConvert.SerializeObject(value);
                //Logging.Logger.Information("api/AgPeshawar/PostUserRecord: Parameters:" + JsonConvert.SerializeObject(value));

                var IsInserted = new AccountRepository().UserDetailInsert(value);
                if (IsInserted > 0)
                {
                    return Content(HttpStatusCode.Created, new ContentResult("Transaction successfully", "Transaction successfully", new { TransactionNo = IsInserted }));
                }
                else
                {
                    return Content(HttpStatusCode.Conflict, new ContentResult("Transaction Failed", "Something went wrong", new { TransactionNo = "0" }));
                }
            }
            catch (Exception ex)
            {
                //Logging.Logger.Error("api/AgPeshawar/PostUserRecord: Exception : " + ex.Message);
                // 500 Internal Server Error
                return Content(HttpStatusCode.BadRequest, new ContentResult("Transaction Failed", ex.Message, new { TransactionNo = "0" }));
            }
        }





      



    }
}
