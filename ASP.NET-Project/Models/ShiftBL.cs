using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class ShiftBL
    {
            factoryDBEntities db = new factoryDBEntities();
            public List<ShiftEmp> GetShiftData()
            {
                var result = (from emp in db.employees
                              join
                              emp_sh in db.EmployeeShift on
                              emp.ID equals emp_sh.EmployeeID
                              join shifts in db.shifts on
                              emp_sh.ShiftID equals shifts.ID
                              select new ShiftEmp
                              {
                                  ID = emp.ID,
                                  FullName = emp.FirstName + " " + emp.LastName,
                                  ShiftDate = (System.DateTime)shifts.ShiftDate,
                                  StartTime = (int)shifts.StartTime,
                                  EndTime = (int)shifts.EndTime,
                              }).ToList();

                return result;
            }
            public void Add(shifts sh)
            {
                db.shifts.Add(sh);
                db.SaveChanges();
            }
    }
}