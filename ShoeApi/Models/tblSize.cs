using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeApi.Models
{
    public class tblSize
    {
        [Key]
        public int Size_Id { get; set; }

        [Required]
        public int Size_Number { get; set; }
        public DateTime Size_CreatedDate { get; set; }
        public ICollection<tblProducts> tblProducts { get; set; }
    }
}