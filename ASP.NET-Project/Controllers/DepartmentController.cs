using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Project.Models;

namespace ASP.NET_Project.Controllers
{
    public class DepartmentController : Controller
    {
            DepartmentBL DepartmentBL = new DepartmentBL();

            public ActionResult Index()
            {
                if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
                {
                    var departments = DepartmentBL.GetDepartmentsData();
                    ViewBag.departments = departments;
                    return View("DepartmentPage");
                }
                else
                {
                    return RedirectToAction("Index", "LogIn");
                }
            }
            public ActionResult GetDepartment(int id)
            {
                if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
                {
                    var deparment = DepartmentBL.GetDepartmentData(id);
                    var emp = DepartmentBL.GetEmpData();
                    ViewBag.emp = emp;
                    return View("EditDep", deparment);
                }
                else
                {
                    return RedirectToAction("Index", "LogIn");
                }
            }
            public ActionResult UpdateDep(department dep)
            {
                if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
                {
                    DepartmentBL.Update(dep);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "LogIn");
                }
            }
            public ActionResult DeleteDep(department dep)
            {
                if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
                {
                    DepartmentBL.Delete(dep);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "LogIn");
                }
            }
            public ActionResult GetDepartmentDataFromUser()
            {
                if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
                {
                    var emp = DepartmentBL.GetEmpData();
                    ViewBag.emp = emp;
                    return View("AddDepartment");
                }
                else
                {
                    return RedirectToAction("Index", "LogIn");
                }

            }

            public ActionResult AddDep(department dep)
            {
                if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
                {
                    DepartmentBL.Add(dep);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
        }
}