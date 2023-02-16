using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGPeshawarAPI.Provider
{
    public class DbConnection
    {
        public static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
                //return EncryptAndDecrypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["DBContext"], true);
            }
        }
    }
}