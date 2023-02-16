using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Configuration;
using AGPeshawarAPI.Provider;
using static ModelLayer.Models.User;
using ModelLayer.Models;

namespace AGPeshawarAPI.Repositories
{
    public class AccountRepository
    {
        private IDbConnection db = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);

        public List<object> GetCabsWithSeatingVacant(string seating, string status)
        {
            var data = db.Query<object>("Infocab_Revamp..CS_GetCabs_Seating_Vacant",
                new
                {
                    Seating = seating,
                    Vacant = status
                },
               commandType: CommandType.StoredProcedure).ToList();
            return data;
        }


        public int UserDetailInsert(UserData userData)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Applicant_name", userData.Applicant_name);
            parameters.Add("@Relation_type", userData.Relation_type);
            parameters.Add("@Relation_name", userData.Relation_name);
            parameters.Add("@Cnic", userData.Cnic);
            parameters.Add("@Cnic_image", userData.Cnic_image);
            parameters.Add("@Cnic_image_back", userData.Cnic_image_back);
            parameters.Add("@Ownership_type", userData.Ownership_type);
            parameters.Add("@Age", userData.Age);
            parameters.Add("@Gender", userData.Gender);
            parameters.Add("@Religion", userData.Religion);
            parameters.Add("@Status", userData.Status);
            parameters.Add("@No_of_family_members", userData.No_of_family_members);
            parameters.Add("@No_of_men", userData.No_of_men);
            parameters.Add("@No_of_women", userData.No_of_women);
            parameters.Add("@No_of_children", userData.No_of_children);
            parameters.Add("@Current_monthly_income", userData.Current_monthly_income);
            parameters.Add("@Source_of_income", userData.Source_of_income);
            parameters.Add("@Contact", userData.Contact);
            parameters.Add("@Remarks", userData.Remarks);
            userData.Evidence_Join = string.Join(",", userData.Evidence.ToArray());
            parameters.Add("@Evidence", userData.Evidence_Join);
            userData.Selection_criteria_Join = string.Join(",", userData.Selection_criteria.ToArray());
            parameters.Add("@Selection_criteria", userData.Selection_criteria_Join);
            parameters.Add("@Latitude", userData.Latitude);
            parameters.Add("@Longitude", userData.Longitude);
            parameters.Add("@Ref_id", userData.Ref_id);
            parameters.Add("@Signature_pic", userData.Signature_pic);
            parameters.Add("@User_id", userData.User_id);
            parameters.Add("@Role_id", userData.Role_id);
            parameters.Add("@Mobile_created_at", userData.Mobile_created_at);
            parameters.Add("@Mobile_updated_at", userData.Mobile_updated_at);
            parameters.Add("@Sent_server", userData.Sent_server);

            //parameters.Add("@Notes", Job.Notes == null ? "" : Job.Notes);

            parameters.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            db.Execute("sp_UserDetailInsert", parameters, commandType: CommandType.StoredProcedure);
            int id = parameters.Get<int>("@id");
            return id;
        }
        public int RegisterUser(UserDTO model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserName", model.UserName);
            parameters.Add("@Password", model.Password);
            parameters.Add("@Role_Id", model.Role);
            parameters.Add("@CreatedbyUserId", model.CreatedbyUserId);
            parameters.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            db.Execute("sp_RegisterUser", parameters, commandType: CommandType.StoredProcedure);
            int id = parameters.Get<int>("@id");
            return id;
        }

        public LoginModel ValidateUser(LoginModel model)
        {
            try
            {
                LoginModel response = new LoginModel();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@UserName", model.UserName);
                ObjParm.Add("@Password", model.Password);
                response = (LoginModel)Repose.GetSingleModel<LoginModel>("sp_Login", ObjParm);
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}