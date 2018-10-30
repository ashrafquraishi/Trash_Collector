using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollecter.Models
{
    public class SchedulePickUp
    {
        [Key]
        public int PickupId { get; set; }
        
        [Display(Name = "PickupDate")]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime PickupDate { get; set; }
    }
}