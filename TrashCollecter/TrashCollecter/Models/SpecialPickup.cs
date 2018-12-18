using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollecter.Models
{
    public class SpecialPickup
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Special Pickup")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SpecialPickup1 { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string  ItemDescription{ get; set; }
    }
}