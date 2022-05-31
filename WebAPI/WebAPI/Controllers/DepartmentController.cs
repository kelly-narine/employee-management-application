using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM dbo.Department";

            //executes query
            DataTable table = new DataTable();
            using(var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using(var cmd = new SqlCommand(query, con))
            using(var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Department dep)
        {
            try
            {
                string query = @"INSERT INTO dbo.Department VALUES('" + dep.DepartmentName + @"')";

                //executes query
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Department added successfully!";
            }
            catch(Exception)
            {
                return "Failed to add Department!";
            }
        }

        public string Put(Department dep)
        {
            try
            {
                string query = @"UPDATE dbo.Department SET DepartmentName='" + dep.DepartmentName + @"'WHERE DepartmentId=" + dep.DepartmentId + @"";
                //executes query
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Department updated successfully!";
            }
            catch (Exception)
            {
                return "Failed to update Department!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"DELETE FROM dbo.Department WHERE DepartmentId = " + id + @"";


                //executes query
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Department removed successfully!";
            }
            catch (Exception)
            {
                return "Failed to remove Department!";
            }


        }

    }
}
