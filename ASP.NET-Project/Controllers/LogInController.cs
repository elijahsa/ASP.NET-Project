using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Project.Models;

namespace ASP.NET_Project.Controllers
{
    public class LogInController : Controller
    {
        LogInBL LoginBL = new LogInBL();       
        public ActionResult Index()
        {
            return View("LogIn");
        }
        public ActionResult GetLoginData(string username, string pwd)
        {
            var user = LoginBL.IsAuthenticated(username, pwd);
            if (user != null)
            {
                UserBL userBL = new UserBL(user);
                Session["UserBL"] = userBL;
                if (userBL.CheckActionCounter(1))
                {
                    Session["FullName"] = user.FullName;
                    Session["ActionCounter"] = user.ActionsCounter;
                    return View("HomePage");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Home()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                return View("HomePage");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }
        }
        public ActionResult DepartmentsMenu()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                return RedirectToAction("Index", "Department");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }
        }
        public ActionResult ShiftsMenu()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                return RedirectToAction("ShiftsMenu", "Shift");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }

        }
        public ActionResult EmpMenu()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                return RedirectToAction("EmployeeMenu", "Employee");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }
        }
        public ActionResult LogOut()
        {
            ((UserBL)Session["UserBL"]).UpDateUserData();
            Session.Clear();
            return RedirectToAction("Index", "LogIn");

        }
    }
}