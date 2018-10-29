using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollecter.Models
{
    public class CustomerModels
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth ")]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        [Display(Name = "Zip Code")]

        public int ZipCode { get; set; }

       
        



    }
}