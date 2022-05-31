using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT EmployeeId, EmployeeName, Department, CONVERT(VARCHAR(10), DateOfJoining,120) AS DateOfJoining, PhotoFileName FROM dbo.Employee";

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

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Employee emp)
        {
            try
            {
                string query = @"INSERT INTO dbo.Employee VALUES
                                 (
                                 '" + emp.EmployeeName + @"',
                                 '" + emp.Department + @"',
                                 '" + emp.DateOfJoining + @"',
                                 '" + emp.PhotoFileName + @"'
                                 )";

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

                return "Employee added successfully!";
            }
            catch (Exception)
            {
                return "Failed to add Employee!";
            }
        }

        public string Put(Employee emp)
        {
            try
            {
                string query = @"UPDATE dbo.Employee SET 
                                 EmployeeName='" + emp.EmployeeName + @"',
                                 Department='" + emp.Department + @"',
                                 DateOfJoining='" + emp.DateOfJoining + @"',
                                 PhotoFileName='" + emp.PhotoFileName + @"'
                                 WHERE EmployeeId=" + emp.EmployeeId + @"";
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

                return "Employee updated successfully!";
            }
            catch (Exception)
            {
                return "Failed to update Employee!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"DELETE FROM dbo.Employee WHERE EmployeeId = " + id + @"";


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

                return "Employee removed successfully!";
            }
            catch (Exception)
            {
                return "Failed to remove Employee!";
            }


        }

        [Route("api/Employee/GetAllDepartmentNames")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartmentNames()
        {
            string query = @"SELECT DepartmentName FROM dbo.Department";

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

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [Route("api/Employee/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0]; //considers first file upload only in case multiple files uploaded in the request
                string fileName = postedFile.FileName;
                var savePath = HttpContext.Current.Server.MapPath("~/Photos/" + fileName);
                postedFile.SaveAs(savePath);

                return fileName;
            }
            catch(Exception)
            {
                return "anonymous.png";
            }
        }
    }
}
