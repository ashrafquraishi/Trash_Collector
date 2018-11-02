using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollecter.Models
{
    public class AddressModel
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Daymodel")]
        public int DayID { get; set; }
        public Daymodel Day { get; set; }

        [ForeignKey("CustomeModels")]
        public int CustomerID { get; set; }
        public CustomerModels Customer { get; set; }

    }
}