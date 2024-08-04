using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeApi.Models
{
    public class tblYear
    {
        [Key]
        public int YearId { get; set; }

        [Column(TypeName = "varchar"), MaxLength(20)]
        public string YearText { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }


    }
}