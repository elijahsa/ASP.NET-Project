using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class LogInBL
    {
        factoryDBEntities db = new factoryDBEntities();

        public users IsAuthenticated(string username, string pwd)
        {
            var result = db.users.Where(x => x.UserName == username && x.Pwd == pwd);
            if (result.Count() != 0)
            {
                return result.First();
            }
            else
            {
                return null;
            }
        }
     }
}