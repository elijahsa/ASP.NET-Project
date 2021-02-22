using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Project.Models;

namespace ASP.NET_Project.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeBL EmployeeBL = new EmployeeBL();
        // GET: Employee
        public ActionResult EmployeeMenu()
        {

            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                var result = EmployeeBL.EmployeeList();
                ViewBag.EmpData = result;
                return View("Employees");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }
        }


        public ActionResult GetDataEditEmp(int id)
        {

            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                var result = EmployeeBL.GetEmployee(id);
                var dep = EmployeeBL.GetDepartments();
                ViewBag.Departments = dep;

                return View("EditEmployee", result);
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }
        }
        public ActionResult UpdateEmp(employees emp)
        {

            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                EmployeeBL.UpdateEmp(emp);
                return RedirectToAction("EmployeeMenu");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }
        }

        public ActionResult AddShiftToEmployee(int id)
        {

            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                EmployeeShift emp = new EmployeeShift();
                emp.EmployeeID = id;
                return View("AddEmployeeShift", emp);
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }
        }

        public ActionResult AddShiftEmp(EmployeeShift emp)
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                EmployeeBL.AddShift(emp);
                return RedirectToAction("EmployeeMenu");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }
        }
        public ActionResult DelEmp(int id)
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                EmployeeBL.Remove(id);
                return RedirectToAction("EmployeeMenu");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }
        }
        [HttpGet]
        public ActionResult SearchEmp(string text)
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                var result = EmployeeBL.SearchEmp(text);
                ViewBag.EmpData = result;
                return View("SearchResult");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "LogIn");
            }
        }
    }
}