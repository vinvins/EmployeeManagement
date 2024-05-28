using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{


    public class EmployeeController : Controller
    {

              
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = DapperORM.ReturnList<Employee>("GetEmployeeList");           
            return View(employees);
        }

        [HttpGet]
        public ActionResult AddorEdit(int ID = 0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddorEdit(Employee employee)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID",employee.ID);
            param.Add("@Name", employee.Name);
            param.Add("@Age", employee.Age);
            param.Add("@EmailID", employee.EmailID);
            param.Add("@IsActive", employee.IsActive);
            DapperORM.ExecuteWithoutReturn("AddOrEditEmployee", param);
            return RedirectToAction("Index");
        }
    }
}