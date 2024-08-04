using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeApi.Models
{
    public class tblUserBill
    {
        [Key]
        public int BillId { get; set; }

        public int? user_Id { get; set; }

        
        public decimal? TotalProd_Price { get; set; }

        [Column(TypeName = "varchar"), MaxLength(1000)]
        public string Address { get; set; }

        [Column(TypeName = "varchar"), MaxLength(20)]
        public string Mobile { get; set; }

        [Column(TypeName = "varchar"), MaxLength(100)]
        public string OrderId { get; set; }

        public int? Pid { get; set; }

        public decimal? TotalBillPrice { get; set; }

        public DateTime? Created_Date { get; set; }

        public int? Cart_Id { get; set; }

        public int? Prod_Qty { get; set; }

        [Column(TypeName = "varchar"), MaxLength(100)]
        public string PaymentId { get; set; }

    }
}