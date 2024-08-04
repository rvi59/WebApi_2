using ShoeApi.DataContext;
using ShoeApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ShoeApi.Controllers
{
    public class ProductController : ApiController
    {
        private ShoeApiContext db;
        DateTime createdDate = DateTime.Now;

        //Get ALL
        public HttpResponseMessage GetAllProduct()
        {
            using (db = new ShoeApiContext())
            {
              
                var result = (from p in db.tProducts
                              join b in db.tBrand on p.BrandId equals b.Brand_Id
                              join c in db.tCategory on p.CategoryId equals c.Category_Id
                              join d in db.tSize on p.SizeId equals d.Size_Id
                              select new
                              {
                                  Prod_Id = p.Prod_Id,
                                  Prod_Name = p.Prod_Name,
                                  Prod_ShortName = p.Prod_ShortName,
                                  Prod_Price = p.Prod_Price,
                                  Prod_Selling = p.Prod_Selling,
                                  Prod_Description = p.Prod_Description,
                                  Prod_Image_Path = p.Prod_Image_Path,
                                  BrandId = p.BrandId,
                                  Brand_Name = b.Brand_Name,
                                  CategoryId = p.CategoryId,
                                  Category_Name = c.Category_Name,
                                  SizeId = p.SizeId,
                                  Size_Number = d.Size_Number
                              }).ToList();



                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
        }

        public HttpResponseMessage GetProductByCategory(int Id)
        {
            using (db = new ShoeApiContext())
            {

                var result = (from p in db.tProducts
                              join b in db.tBrand on p.BrandId equals b.Brand_Id
                              join c in db.tCategory on p.CategoryId equals c.Category_Id
                              join d in db.tSize on p.SizeId equals d.Size_Id
                              where p.CategoryId == Id
                              select new
                              {
                                  Prod_Id = p.Prod_Id,
                                  Prod_Name = p.Prod_Name,
                                  Prod_ShortName = p.Prod_ShortName,
                                  Prod_Price = p.Prod_Price,
                                  Prod_Selling = p.Prod_Selling,
                                  Prod_Description = p.Prod_Description,
                                  Prod_Image_Path = p.Prod_Image_Path,
                                  BrandId = p.BrandId,
                                  Brand_Name = b.Brand_Name,
                                  CategoryId = p.CategoryId,
                                  Category_Name = c.Category_Name,
                                  SizeId = p.SizeId,
                                  Size_Number = d.Size_Number
                              })
                              .Take(4)
                              .ToList();



                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
        }


        //Get by ID
        public HttpResponseMessage GetProductbyId(int id)
        {

            using (db = new ShoeApiContext())
            {
                var result = (from p in db.tProducts
                              join b in db.tBrand on p.BrandId equals b.Brand_Id
                              join c in db.tCategory on p.CategoryId equals c.Category_Id
                              join d in db.tSize on p.SizeId equals d.Size_Id
                              where p.Prod_Id == id
                              select new
                              {
                                  Prod_Id = p.Prod_Id,
                                  Prod_Name = p.Prod_Name,
                                  Prod_ShortName = p.Prod_ShortName,
                                  Prod_Price = p.Prod_Price,
                                  Prod_Selling = p.Prod_Selling,
                                  Prod_Description = p.Prod_Description,
                                  Prod_Image_Path = p.Prod_Image_Path,
                                  BrandId = p.BrandId,
                                  Brand_Name = b.Brand_Name,
                                  CategoryId = p.CategoryId,
                                  Category_Name = c.Category_Name,
                                  SizeId = p.SizeId,
                                  Size_Number = d.Size_Number
                              }).FirstOrDefault();

                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }

        }


        //Add Product
        public HttpResponseMessage PostProduct(tblProducts t)
            {
            using (db = new ShoeApiContext())
            {
                if (t != null)
                {
                    if (db.tProducts.Any(x => x.Prod_Name == t.Prod_Name))
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "Product Name already Exists");
                    }
                    else
                    {
                        
                        tblProducts products = new tblProducts
                        {
                            Prod_Name = t.Prod_Name,
                            Prod_ShortName = t.Prod_ShortName,
                            Prod_Price = t.Prod_Price,
                            Prod_Selling = t.Prod_Selling,
                            Prod_Description = t.Prod_Description,
                            BrandId = t.BrandId,
                            CategoryId = t.CategoryId,
                            SizeId = t.SizeId,
                            Prod_CreatedDate = createdDate,
                            Prod_Image_Path=t.Prod_Image_Path,
                            Quantity = t.Quantity

                        };
                        db.tProducts.Add(products);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.Created, products);
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Provide Required Info");
                }
            }
        }

       

        //Update Product
        public HttpResponseMessage PutProduct(tblProducts t)
        {
            using (db = new ShoeApiContext())
            {
                var editProd = db.tProducts.Where(x => x.Prod_Id == t.Prod_Id).FirstOrDefault();

                if (editProd != null)
                {


                    //if (db.tProducts.Any(x => x.Prod_Name == t.Prod_Name))
                    //{
                    //    return Request.CreateResponse(HttpStatusCode.Found, "Product Name already Exists");
                    //}
                    //else
                    //{
                        editProd.Prod_Name = t.Prod_Name;
                        editProd.Prod_ShortName = t.Prod_ShortName;
                        editProd.Prod_Price = t.Prod_Price;
                        editProd.Prod_Selling = t.Prod_Selling;
                        editProd.Prod_Description = t.Prod_Description;
                        editProd.Prod_Image_Path = t.Prod_Image_Path;
                        editProd.BrandId = t.BrandId;
                        editProd.CategoryId = t.CategoryId;
                        editProd.SizeId = t.SizeId;
                        editProd.Quantity = t.Quantity;
                        editProd.Prod_CreatedDate = createdDate;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.Created, editProd);
                    //}

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Product id " + t.Prod_Id + " Not Found");
                }
            }
        }


        //Delete Product
        public HttpResponseMessage DeleteProduct(int id)
        {

            using (db = new ShoeApiContext())
            {
                var delProdcut = db.tProducts.Where(x => x.Prod_Id == id).FirstOrDefault();

                if (delProdcut != null)
                {
                    db.tProducts.Remove(delProdcut);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, delProdcut);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Product with id = " + id + " not found");
                }

            }
        }
    }
}


