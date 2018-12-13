using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TrashCollecter.Models
{
    public class Daymodel
    {
        public int Id { get; set; }
        [DisplayName("Pick Up Day")]

        public string PickUpDay { get; set; }
        [DisplayName("Change Pick Up Day")]

        public DateTime? ChangePickUpDay { get; set; }
        [DisplayName("Vacation Start")]

        public DateTime? VacationStart { get; set; }
        [DisplayName("Vacation End")]

        public DateTime? VacationEnd { get; set; }



        public enum DayList
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }

        public DayList Days { get; set; }
    }
}