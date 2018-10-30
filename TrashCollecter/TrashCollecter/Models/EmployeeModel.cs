using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollecter.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth ")]
        public DateTime DateOfBirth { get; set; }
        
        [Display(Name = "PickUps")]
        public string PickUps { get; set; }
       





    }

}