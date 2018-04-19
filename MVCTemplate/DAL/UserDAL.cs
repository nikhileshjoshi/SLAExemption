using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SLAExemptionTool.DAL
{
    public class UserDAL
    {
        private DBConnection conn;
        public UserDAL()
        {
            conn = new DBConnection();
        }

        public bool isValid(string username, string password, string usertype)
        {
            string query = string.Format("usp_Login");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@Username", DbType.String);
            sqlParameters[0].Value = Convert.ToString(username);

            sqlParameters[1] = new SqlParameter("@Password", DbType.String);
            sqlParameters[1].Value = Convert.ToString(password);

            sqlParameters[2] = new SqlParameter("@Usertype", DbType.String);
            sqlParameters[2].Value = Convert.ToString(usertype);
           
            bool isValidUser = conn.executeQuery(query, sqlParameters);            
            return isValidUser;

        }
    }
}