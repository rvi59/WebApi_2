using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoeApi.Models
{
    public class tblProducts
    {
        [Key]
        public int Prod_Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(800)]
        [Required]
        public string Prod_Name { get; set; }

        [Column(TypeName = "varchar"), MaxLength(100)]
        [Required]
        public string Prod_ShortName { get; set; }

        [Column(TypeName = "float")]
        [Required]
        public float Prod_Price { get; set; }

        [Column(TypeName = "float")]
        [Required]
        public float Prod_Selling { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public string Prod_Description { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Prod_Image_Path { get; set; }

        [Column(TypeName = "Int")]
        [Required]
        public int Quantity { get; set; }

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public tblBrands tblBrand { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public tblCategory tblCategory { get; set; }

        public int SizeId { get; set; }
        [ForeignKey("SizeId")]
        public tblSize tblSize { get; set; }

        public DateTime Prod_CreatedDate { get; set; }
    }
}