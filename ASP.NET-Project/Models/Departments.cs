using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class Departments
    {
        public string DepName { get; set; }
        public int ID { get; set; }
        public int Manager { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public override bool Equals(object obj)
        {
            return this.DepName.Equals(((Departments)obj).DepName) && this.Manager.Equals(((Departments)obj).Manager) && this.EmpId.Equals(((Departments)obj).EmpId) && this.ID.Equals(((Departments)obj).ID);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}