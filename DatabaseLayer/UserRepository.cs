using Dapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.NewUser;

namespace DatabaseLayer
{
    public class UserRepository
    {
        //public int ValidateUser(NewUser.AddUser model)
        //{
        //    try
        //    {

        //        DynamicParameters ObjParm = new DynamicParameters();
        //        ObjParm.Add("@UserName", model.UserName);
        //        ObjParm.Add("@Password", model);
        //        response = Repose.ExcuteNonQuery("sp_Login", ObjParm);
        //        return response;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        public List<GetUserRecord> GetUserList()
        {
            try
            {
                List<GetUserRecord> lst = new List<GetUserRecord>();
                lst = Repose.GetListByProc<GetUserRecord>("sp_Users");
                return lst;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }

}
