using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CarRental.DL;

namespace CarRental.BL
{
    public class Adminlogincs
    {
        public bool isvaliduser(string username, string password,string Connection)
        {
            bool output=false;
            DBHelper dBHelper = new DBHelper();
            dBHelper.Connection = Connection;
            string query = $"select count(*) from employee where EMP_NAME='{username}' and EMP_PASSWORD='{password}'";
            dBHelper.SQLQuery = query;
            object result = dBHelper.Getsinglevalue() ?? 0;
            int val = Convert.ToInt32(result);
            if (val > 0)
            {
                output = true;
            }

            return output;
        }

        public string GetRole(string username, string password, string connection)
        {
       
            DBHelper odb = new DBHelper();
            string sql = $"SELECT EMP_ROLE FROM EMPLOYEE WHERE " +
                         $"EMP_NAME='{username}' AND EMP_PASSWORD='{password}'";
            odb.SQLQuery = sql;
            odb.Connection = connection;

            object output = odb.Getsinglevalue() ;
            string role = output.ToString();

            return role;

        }
    }
}
