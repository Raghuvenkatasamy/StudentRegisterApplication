using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
   public class Subjects
    {
        public long SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }
    }
}
