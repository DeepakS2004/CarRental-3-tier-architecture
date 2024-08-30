using CarRental.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRental.BL
{
    public class Workerreg
    {
        public int Toregister(string connection,string username,string password,string age,string gender,string email,string phone,string designation,string location,string role,string datejoin,string dateend,string workinghrs,string salary)
        {
           
            DBHelper dBHelper = new DBHelper();
            dBHelper.Connection = connection;
            string query = $"insert into employee values ('{username}' ," + $"{password},{age},'{gender}','{email}',{phone},'{designation}'," + $"'{location}','{role}','{datejoin}','{dateend}','{workinghrs}',{salary})";
            dBHelper.SQLQuery = query;
            object result = dBHelper.Insertvalue() ;
            int val = Convert.ToInt32(result);
           
            return val;
        }
    }
}
