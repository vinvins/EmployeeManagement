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


        string connectionString = "Data source=.;Initial catalog=EmployeeDB;Integrated Security=True";

        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<Employee> employees;
            using(var connection=new SqlConnection(connectionString))
            {
                var sql = "select * from Employee where IsActive=1";
                employees = connection.Query<Employee>(sql);
            }
            return View(employees);
        }
    }
}