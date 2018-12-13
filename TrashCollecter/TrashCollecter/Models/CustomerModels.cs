using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollecter.Models
{
    public class CustomerModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]

        public string LastName { get; set; }
        [DisplayName("Email")]

        public string Email { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
      //     public decimal Balance { get; set; }
      






    }
}