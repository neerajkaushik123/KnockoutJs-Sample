using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace SampleApp
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Search(string EmpName)
        {
            var emplist = PrepareEmpList();

            var searchedlist= from emp in emplist
                            where emp.Name.Contains(EmpName)
                            select emp;

            return Json(new { Items = searchedlist});
        }

        private static List<Employee> PrepareEmpList()
        {
            var emplist = new List<Employee>();
            //create list of employee
            for (int i = 0; i < 20000; i++)
            {
                var emp = new Employee();
                emp.EmployeeID = i;
                emp.Name = string.Format("Employee-{0}", i);
                emp.Address = string.Format("ABC New Delhi- 1{0}", i);
                if (i % 2 == 0)
                    emp.Dept = "IT";
                else
                    emp.Dept = "Admin";

                emplist.Add(emp);
            }
            return emplist;
        }
    }

    class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Dept { get; set; }

    }
}
