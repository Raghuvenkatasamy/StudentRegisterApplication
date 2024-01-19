using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class StudentDetails
    {
        public long StudentID { get; set; }

        [Required(ErrorMessage = "Please enter your name"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        [RegularExpression("[A-Z]+[a-z]*", ErrorMessage = "Please enter correct formate 1L-Caps is Required")]
        public string Name { get; set; }
      
        [Required]
        public DateTime DOB { get; set; }
       
       
        [Range(18, 100, ErrorMessage = "18+ Only")]
        public int Age { get; set; }
        public string Gender { get; set; }


        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Must be a number with 10 digits.")]
        public long PhoneNumber { get; set; }

        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        public int SubjectId { get; set; }
        public List<Subjects> Subject { get; set; }

    }
}
