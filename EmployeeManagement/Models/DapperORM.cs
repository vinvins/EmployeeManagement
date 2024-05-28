using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace EmployeeManagement.Models
{
    public class DapperORM
    {
        public static string ConnectionString = "Data source=.;Initial Catalog=EmployeeDB;Integrated security=True;";

        public static void ExecuteWithoutReturn(string ProcedureName,DynamicParameters param = null)
        {
            using(SqlConnection con=new SqlConnection(ConnectionString))
            {
                con.Execute(ProcedureName,param,commandType:CommandType.StoredProcedure);
            }
        }

        public static IEnumerable<T> ReturnList<T>(string ProcedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                return con.Query<T>(ProcedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ReturnScalar<T>(string ProcedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                return (T) Convert.ChangeType(con.Query(ProcedureName, param, commandType: CommandType.StoredProcedure),typeof(T));
            }
        }

    }
}