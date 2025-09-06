using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeLinqWebDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Sample data
                List<Employee> employees = new List<Employee>
                {
                    new Employee { Id = 1, Name = "Shirish", Department = "IT", Salary = 60000 },
                    new Employee { Id = 2, Name = "Varun", Department = "HR", Salary = 40000 },
                    new Employee { Id = 3, Name = "Kumar", Department = "IT", Salary = 70000 },
                    new Employee { Id = 4, Name = "Anil", Department = "Finance", Salary = 50000 }
                };

                // LINQ query → IT employees with salary > 50000
                var highPaidIT = from emp in employees
                                 where emp.Department == "IT" && emp.Salary > 50000
                                 orderby emp.Salary descending
                                 select emp;

                // Bind to GridView
                GridView1.DataSource = highPaidIT.ToList();
                GridView1.DataBind();
            }
        }
    }
}