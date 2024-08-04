using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeApi.Models
{
    public class tblCart
    {

        [Key]
        public int Cartid { get; set; }

        public int Quantity { get; set; }

        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public tblUsers tblUsers { get; set; }

        public int Prod_Id { get; set; }
        [ForeignKey("Prod_Id")]
        public tblProducts tblProducts { get; set; }

        public DateTime Cart_CreatedDate { get; set; }

    }
}