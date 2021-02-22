using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class ShiftEmp
    {
            public int ID { get; set; }
            public string FullName { get; set; }
            public System.DateTime ShiftDate { get; set; }
            public int StartTime { get; set; }
            public int EndTime { get; set; }



        
    }
}