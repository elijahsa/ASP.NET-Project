using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class EmployeeBL
    {
        factoryDBEntities db = new factoryDBEntities();
        public List<EmpData> EmployeeList()
        {

            var result = (from emp in db.employees
                          join dep in db.department
                          on emp.DepID equals dep.ID
                          select new EmpData
                          {
                              ID = emp.ID,
                              FullName = emp.FirstName + " " + emp.LastName,
                              Department = dep.DepName,
                              StartWorkYear = emp.YearStarted,

                              Shifts = (from sh_emp in db.EmployeeShift
                                        join sh in db.shifts
                                        on sh_emp.ShiftID equals sh.ID
                                        where emp.ID == sh_emp.EmployeeID
                                        select new ShiftEmp
                                        {
                                            FullName = "",
                                            ShiftDate = (System.DateTime)sh.ShiftDate,
                                            StartTime = (int)sh.StartTime,
                                            EndTime = (int)sh.EndTime,
                                        }).ToList()
                          }).ToList();
            return result;
        }

        public employees GetEmployee(int id)
        {
            var result = db.employees.Where(x => x.ID == id).First();
            return result;
        }
        public List<department> GetDepartments()
        {
            var result = db.department.ToList();
            return result;
        }
        public void UpdateEmp(employees emp)
        {
            var result = db.employees.Where(x => x.ID == emp.ID).First();
            result.FirstName = emp.FirstName;
            result.LastName = emp.LastName;
            result.DepID = emp.DepID;
            db.SaveChanges();
        }

        public void AddShift(EmployeeShift emp)
        {
            db.EmployeeShift.Add(emp);
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            var emp = db.employees.Where(x => x.ID == id).First();
            var shifts = db.EmployeeShift.Where(x => x.EmployeeID == id).ToList();
            db.employees.Remove(emp);
            if (shifts.Count > 0)
            {
                foreach (var shift in shifts)
                {
                    db.EmployeeShift.Remove(shift);
                }
            }
            db.SaveChanges();
        }

        public List<EmpData> SearchEmp(string SearchText)
        {
            var result = (from emp in db.employees
                          join dep in db.department
                          on emp.DepID equals dep.ID
                          select new EmpData
                          {
                              ID = emp.ID,
                              FullName = emp.FirstName + " " + emp.LastName,
                              Department = dep.DepName,
                              StartWorkYear = emp.YearStarted,

                              Shifts = (from sh_emp in db.EmployeeShift
                                        join sh in db.shifts
                                        on sh_emp.ShiftID equals sh.ID
                                        where emp.ID == sh_emp.EmployeeID
                                        select new ShiftEmp
                                        {
                                            FullName = "",
                                            ShiftDate = (System.DateTime)sh.ShiftDate,
                                            StartTime = (int)sh.StartTime,
                                            EndTime = (int)sh.EndTime,
                                        }).ToList()
                          }).ToList();
            var resultFilter = result.Where(x => x.FullName.ToLower().Contains(SearchText.ToLower()) || x.Department.ToLower().Contains(SearchText.ToLower())).ToList();
            return resultFilter;
        }
    }
}