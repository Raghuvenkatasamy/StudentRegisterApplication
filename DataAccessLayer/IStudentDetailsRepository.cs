using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public interface IStudentDetailsRepository
    {
        public StudentDetails InsertRecord(StudentDetails product);
        public IEnumerable<StudentDetails> ListAll();
        public StudentDetails SelectByID(long id);
        public StudentDetails DeleteRecord(long id);
        public StudentDetails UpdateRecord(long id, StudentDetails prd);
    }
}
