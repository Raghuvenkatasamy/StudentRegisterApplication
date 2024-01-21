using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class StudentDetailsRepository : IStudentDetailsRepository
    {
        string DBconnection;

        public StudentDetailsRepository(IConfiguration configuration)
        {
            DBconnection = configuration.GetConnectionString("DbConnection");
        }

        public StudentDetails DeleteRecord(long id)
        {
            try
            {
                var con = new SqlConnection(DBconnection);
                con.Open();
                var product = con.QueryFirstOrDefault<StudentDetails>($"exec DeleteDetails {id}");
                con.Close();
                return product;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public StudentDetails InsertRecord(StudentDetails std)
        {
            try
            {
                var con = new SqlConnection(DBconnection);
                con.Open();
                var insert = con.Execute($"exec InsertDetails '{std.Name}','{std.DOB.ToString("MM-dd-yyyy")}',{std.Age},'{std.Gender}',{std.PhoneNumber},'{std.Email}',{std.SubjectId}");
                con.Close();
                
            }
            catch(Exception ex)
            {
                throw;
            }
            return std;
        }

        public IEnumerable<StudentDetails> ListAll()
        {
            try
            {
                var con = new SqlConnection(DBconnection);
                con.Open();
                var product = con.Query<StudentDetails>($"exec ListDetails");
                con.Close();
                return product.ToList();
            }catch(Exception ex)
            {
                throw;
            }
        }

        public StudentDetails SelectByID(long id)
        {
            try
            {
                var con = new SqlConnection(DBconnection);
                con.Open();
                var product = con.QueryFirstOrDefault<StudentDetails>($"exec SelectByID {id}");
                con.Close();
                return product;
            }catch(Exception ex)
            {
                throw;
            }
        }

        public StudentDetails UpdateRecord(long id, StudentDetails Std)
        {
            try
            {
                var sql = new SqlConnection(DBconnection);
                sql.Open();
                var product = sql.QueryFirstOrDefault<StudentDetails>($"exec UpdateDetails {id},'{Std.Name}','{Std.DOB.ToString("MM-dd-yyyy")}',{Std.Age},'{Std.Gender}',{Std.PhoneNumber},'{Std.Email}',{Std.SubjectId}");
                sql.Close();
                return product;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
