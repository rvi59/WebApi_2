using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoeApi.Models
{
    public class tblUsers
    {
        [Key]
        public int User_Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        [Required]  
        public string U_UserName { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        [Required]
        public string U_Password { get; set; }

        [Column(TypeName = "varchar(max)")]
        [Required]
        
        public string U_Email { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        [Required]
        public string U_FirstName { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string? U_LastName { get; set; }
        public DateTime U_CreatedDate { get; set; }
        public DateTime U_LastUpdatedDate { get; set; }

        [Column(TypeName = "bit")]
        public bool isActive { get; set; }

        [Column(TypeName = "bit")]
        public bool UserType { get; set; }


    }
}