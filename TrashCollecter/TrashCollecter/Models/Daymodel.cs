using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollecter.Models
{
    public class Daymodel
    {
        public int Id { get; set; }
       
        //[DisplayName("PickUp Time")]

        //public DateTime? PickUpTIme { get; set; }
        [Display(Name = "Account Suspend Start Date")]
       [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
       public DateTime VacationStart { get; set; }
          
       [Display(Name = "Account Suspend End Date")]
       [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
       public DateTime VacationEnd { get; set; }
        //[DisplayName("End Subcription")]

        //public bool IsActive { get; set; }  


        public enum calender
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }
        //public enum DateTime
        //{

        //}
        //public calender PickupDay { get; set; }
    }
}