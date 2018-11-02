using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollecter.Models
{
    public class Daymodel
    {
        public int Id { get; set; }
        public string PickUpDay { get; set; }

        public DateTime? ChangePickUpDay { get; set; }
        public DateTime? VacationStart { get; set; }
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