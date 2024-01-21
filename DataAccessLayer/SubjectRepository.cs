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
    public class SubjectRepository : ISubjectcsRepository
    {
        string DBconnectionstring;

        public SubjectRepository(IConfiguration configuration)
        {
            DBconnectionstring = configuration.GetConnectionString("DbConnection");
        }

        public IEnumerable<Subjects> Listsubject()
        {
            try
            {
                var con = new SqlConnection(DBconnectionstring);
                con.Open();
                var list = con.Query<Subjects>($"exec ListSubjects").ToList();
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
