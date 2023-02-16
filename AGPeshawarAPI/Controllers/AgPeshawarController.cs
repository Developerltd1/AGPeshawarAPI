using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Http;
using System.Security.Claims;
using System.Linq;
using ModelLayer.Models;
using DatabaseLayer.Repositories;
using System.Web.Http.Cors;

namespace AGPeshawarAPI.Controllers
{
    [EnableCors(origins: "https://agpeshawar.org", headers: "*", methods: "*")]
    public class AgPeshawarController : ApiController
    {
        [HttpPost]
        [Route("api/AgPeshawar/PostUserRecord")]
        public IHttpActionResult PostUserRecord([FromBody] UserData value)
        {
            try
            {
                if (value == null)
                {
                    // 400 Bad Request
                    return Content(HttpStatusCode.BadRequest, new ContentResult("Transaction Failed", "Invalid Data", new { TransactionNo = "0" }));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

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
