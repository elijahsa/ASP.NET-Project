using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class UserBL
    {
        public users user;
        private int limitAction = 1000;
        factoryDBEntities db = new factoryDBEntities();

        public UserBL(users user2)
        {
            user = user2;
        }
        public bool CheckActionCounter(int num)
        {
            CheckDate();
            if (user.ActionsCounter < limitAction)
            {
                user.ActionsCounter = user.ActionsCounter + num;
                HttpContext.Current.Session["ActionCounter"] = user.ActionsCounter;
                UpDateUserData();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckDate()
        {
            if (user.LogInDate == null || (user.LogInDate != null && user.LogInDate != DateTime.Today))
            {
                user.ActionsCounter = 0;
                user.LogInDate = DateTime.Today;
            }
        }
        public void UpDateUserData()
        {
            var result = db.users.Where(x => x.ID == user.ID).First();
            result.ActionsCounter = user.ActionsCounter;
            result.LogInDate = DateTime.Today;
            db.SaveChanges();
        }
    }
}