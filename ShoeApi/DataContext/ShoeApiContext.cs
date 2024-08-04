using ShoeApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoeApi.DataContext
{
    public class ShoeApiContext:DbContext
    {
        public ShoeApiContext() : base("name=ShoeFactoryDbCon")
        {
            
        }
        public DbSet<tblUsers> tUser { get; set; }
        public DbSet<tblBrands> tBrand { get; set; }
        public DbSet<tblCategory> tCategory { get; set; }
        public DbSet<tblSize> tSize { get; set; }
        public DbSet<tblProducts> tProducts { get; set; }
        public DbSet<tblCart> tblCarts { get; set; }
        public DbSet<tblUserBill> tblUserBills { get; set; }
        public DbSet<tblYear> tblYears { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<tblUsers>()
        //        .Property(p => p.U_UserName)
        //        .HasMaxLength(50)
        //        .HasColumnType("varchar");
        //}
    }
}