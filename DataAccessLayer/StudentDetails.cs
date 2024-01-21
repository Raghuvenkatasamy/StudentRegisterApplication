using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Sdk;

namespace DataAccessLayer
{
    public class StudentDetails
    {
        DateTime now;
        public StudentDetails()
        {
            DOB = new DateTime(2002, 05, 30);
            now = new DateTime(2020, 06, 01);
        }
        public long StudentID { get; set; }

        [Required(ErrorMessage = "Please enter your name"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        [RegularExpression("[A-Z]+[a-z]*", ErrorMessage = "Please enter correct formate 1L-Caps is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        //[Range(typeof(DateTime), "01/01/1990", "30/05/2002", ErrorMessage = "Value for Date of Birth must be between 01-01-1990 and 30-05-2002")]
        public DateTime DOB { get; set; }

        [ReadOnly(true)]
        public int Age
        {
            get
            {
                
                int age = now.Year - DOB.Year;

                if (DOB.Date > now.AddYears(-age))
                {
                    age--; // Birthday hasn't occurred yet this year
                }

                return age;
            }
        }
        public string Gender { get; set; }
        [RegularExpression("[0-9]{10}", ErrorMessage = "Please enter correct formate")]
        public long PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email id is required")]
       [EmailAddress]
        public string Email { get; set; }
        [Required]
        public long SubjectId { get; set; }
        public List<Subjects> Subject { get; set; }

    }
}
