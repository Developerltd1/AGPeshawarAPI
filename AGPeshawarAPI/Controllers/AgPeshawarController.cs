using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Http;
using System.Security.Claims;
using System.Linq;
using ModelLayer.Models;
using DatabaseLayer.Repositories;
using System.Web.Http.Cors;
using ModelLayer;
using AGPeshawarAPI.Provider;
using System.Collections.Generic;

namespace AGPeshawarAPI.Controllers
{
    [EnableCors(origins: "https://agpeshawar.org/apipath", headers: "*", methods: "*")]
    public class AgPeshawarController : ApiController
    {
        [HttpPost]
        [Route("api/AgPeshawar/PostUserRecord")]
        public IHttpActionResult PostUserRecord([FromBody] UserData value)
        {
            StatusModel objStatus = new StatusModel();

            try
            {
                //if (value == null)
                //{
                //    // 400 Bad Request
                //    return Content(HttpStatusCode.BadRequest, new ContentResult("Transaction Failed Null Value", "Invalid Data", new { TransactionNo = value }));
                //}
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}

               

                value.Cnic_image =  StringCompression.Compress(value.Cnic_image);
                value.Cnic_image_back = StringCompression.Compress(value.Cnic_image_back);
                value.Signature_pic = StringCompression.Compress(value.Signature_pic);
                for (int i = 0; i < value.Evidence.Count; i++)
                {
                    value.EvidenceCompress.Add(StringCompression.Compress(value.Evidence[i]));
                }
                   

                
                //Logging.Logger.Error("api/AgPeshawar/PostUserRecord:  Mobile Parameters: " + JsonConvert.SerializeObject(value));

                objStatus = new AccountRepository().UserDetailInsert(value);
                //Logging.Logger.Error("api/AgPeshawar/PostUserRecord:  After Insertion: " + objStatus.status+"  |  "+ objStatus.statusDetail); 
                if (objStatus.status == true)
                {
                    return Content(HttpStatusCode.Created, new ContentResult("Transaction successfully", "Transaction successfully", new { TransactionNo = objStatus.statusDetail }));
                }
                else
                {
                   // Logging.Logger.Error("api/AgPeshawar/PostUserRecord:  Transaction Failed: - Erro From DB: " + objStatus.status + "  |  " + objStatus.statusDetail);
                    return Content(HttpStatusCode.Conflict, new ContentResult("Transaction Failed", "Something went wrong", new { TransactionNo = "0" }));
                }
            }
            catch (Exception ex)
            {
                //Logging.Logger.Error("api/AgPeshawar/PostUserRecord: Exception : " + ex.Message);
                // 500 Internal Server Error
               // Logging.Logger.Error("api/AgPeshawar/PostUserRecord:  Exception: " + ex.Message + "| Inner Message: " + ex + "| DbError: " + objStatus.statusDetail);

                return Content(HttpStatusCode.BadRequest, new ContentResult("Transaction Failed", ex.Message + "| Inner Message: " + ex + "| DbError: "+ objStatus.statusDetail, new { TransactionNo = "0" }));
            }
        }

        [HttpPost]
        [Route("api/AgPeshawar/GetUserRecord")]
        public IHttpActionResult GetUserRecord(int? id)
        {
            try
            {
                var list = new AccountRepository().GetUserRecordList(id);
                if (list != null)
                {
                    return Content(HttpStatusCode.OK, list);
                }
                else
                {
                    return Content(HttpStatusCode.Conflict, new ContentResult("No Record", "No Record Found",  list = null ));
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
