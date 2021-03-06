﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class DepartmentBL
    {
        factoryDBEntities db = new factoryDBEntities();



        public HashSet<Departments> GetDepartmentsData()
        {
            var result = (from dep in db.department
                          join emp in db.employees on dep.Manager equals emp.ID
                          join emp2 in db.employees on dep.ID equals emp2.DepID
                          into gj
                          from leftdep in gj.DefaultIfEmpty()
                          select new Departments
                          {
                              ID = dep.ID,
                              DepName = dep.DepName,
                              Manager = (int)dep.Manager,
                              EmpId = (leftdep.DepID == null ? "null" : leftdep.DepID.ToString()),
                              EmpName = emp.FirstName + " " + emp.LastName
                          }).ToList();

            HashSet<Departments> Ha = new HashSet<Departments>(result);
            return Ha;
        }
        public department GetDepartmentData(int id)
        {
            department dep = db.department.Where(x => x.ID == id).First();
            return dep;
        }
        public void Update(department dep)
        {
            department result = db.department.Where(x => x.ID == dep.ID).First();
            result.DepName = dep.DepName;
            result.Manager = dep.Manager;
            db.SaveChanges();
        }
        public void Delete(department dep)
        {


            department result = db.department.Where(x => x.ID == dep.ID).First();
            db.department.Remove(result);
            db.SaveChanges();
        }
        public void Add(department dep)
        {
            db.department.Add(dep);
            db.SaveChanges();
        }
        public List<EmpData> GetEmpData()
        {
            var result = from emp in db.employees
                         select new EmpData
                         {
                             ID = emp.ID,
                             FullName = emp.FirstName + " " + emp.LastName
                         };
            return result.ToList();
        }
    }
}