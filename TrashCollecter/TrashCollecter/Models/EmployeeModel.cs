using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollecter.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string  FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        //  public int MyProperty { get; set; }
        [Display(Name = "Address")]
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Daymodel")]
        public int? DayID { get; set; }
        public Daymodel Daymodel { get; set; }

        [ForeignKey("CustomerModels")]
        public int? CustomerID { get; set; }
        public CustomerModels CustomerModels { get; set; }
        [ForeignKey("SpecialPickup")]
        public int? SpecialPickupID { get; set; }
        public SpecialPickup SpecialPickup { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}