using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeLinqWebDemo
{
    public class Employee
    {
        public int Id { get; set; }
        //Name of Employee
        public string Name { get; set; }
        //Department
        public string Department { get; set; }
        //Monthly Salary
        public int Salary { get; set; }
    }
}