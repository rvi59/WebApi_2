using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoeApi.Models
{
    public class tblCategory
    {
        [Key]
        public int Category_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string Category_Name { get; set; }

        public DateTime Category_CreatedDate { get; set; }

        public ICollection<tblProducts> tblProducts { get; set; }
    }
}
