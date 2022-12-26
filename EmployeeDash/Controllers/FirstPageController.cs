using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDash.Models;

namespace EmployeeDash.Controllers
{
    public class FirstPageController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string getEmployeeQuery = @"
                    EXEC getEmployeeData;
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeHRDB"].ConnectionString))
            using (var cmd = new SqlCommand(getEmployeeQuery, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(employee emp)
        {
            try
            {

                string insertEmployeeQuery = @"
                INSERT INTO dbo.HR_Employee_Attrition VALUES
                (" + emp.EmployeeCount + @"," + emp.Age + @",'" + emp.Attrition + @"','" + emp.BusinessTravel + @"'," + emp.DailyRate + @",'" + emp.Department +
                    @"'," + emp.DistanceFromHome + @"," + emp.Education + @",'" + emp.EducationField + @"'," + emp.EmployeeNumber + @"," + emp.EnvironmentSatisfaction +
                    @",'" + emp.Gender + @"'," + emp.HourlyRate + @"," + emp.JobInvolvement + @"," + emp.JobLevel + @",'" + emp.JobRole + @"','" + emp.MaritalStatus +
                    @"'," + emp.MonthlyIncome + @"," + emp.MonthlyRate + @"," + emp.NumCompaniesWorked + @",'" + emp.Over18 + @"','" + emp.OverTime + @"'," + emp.PerformanceRating +
                    @"," + emp.RelationshipSatisfaction + @"," + emp.StandardHours + @"," + emp.StockOptionLevel + @"," + emp.TotalWorkingYears + @"," + emp.TrainingTimesLastYear +
                    @"," + emp.WorkLifeBalance + @")
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeHRDB"].ConnectionString))
                using (var cmd = new SqlCommand(insertEmployeeQuery, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added!!";
            }
            catch (Exception)
            {
                return "Failed!!"; 
            }
        }

        public string Delete(int id)
        {
            try
            {

                string deleteEmployeeQuery = @"
                DELETE FROM dbo.HR_Employee_Attrition WHERE EmployeeId = "+id+@"
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeHRDB"].ConnectionString))
                using (var cmd = new SqlCommand(deleteEmployeeQuery, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted!!";
            }
            catch (Exception)
            {
                return "Failed!!";
            }
        }


    }
}
