using ShoeApi.DataContext;
using ShoeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ShoeApi.Controllers
{
    public class BrandController : ApiController
    {
        private ShoeApiContext db;
        DateTime createdDate = DateTime.Now;

        
        
        public HttpResponseMessage GetAllBrands()
        {
            
                List<tblBrands> brand = new List<tblBrands>();

                using (db = new ShoeApiContext())
                {
                    brand = db.tBrand.ToList();
                    if (brand.Count == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "No Record Found");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, brand);
                    }
                }
            
        }

        //Get Brand By Id
        public HttpResponseMessage GetBrandById(int id)
        {
            using (db = new ShoeApiContext())
            {
                var byID = db.tBrand.Where(x => x.Brand_Id == id).FirstOrDefault();
                if (byID != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, byID);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Brand with id = " + id + " not found");
                }
            }
        }


        //Add Brand
        public HttpResponseMessage PostBrand(tblBrands t)
        {
            using (db = new ShoeApiContext())
            {
                if (t != null)
                {
                   
                    //string brandNamecheck = string.IsNullOrEmpty(t.Brand_Name) ? "" : t.Brand_Name.ToString();

                    //if (brandNamecheck == "")
                    //{
                    //    return Request.CreateResponse(HttpStatusCode.Found, "Brand Name Cannot be Empty");
                    //}

                    if (db.tBrand.Any(x => x.Brand_Name == t.Brand_Name))
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "Brand Name already Exists");
                    }

                    else
                    {                         
                        tblBrands brand = new tblBrands
                        {
                            Brand_Name = t.Brand_Name,
                            Brand_CreatedDate = createdDate
                           
                        };

                        db.tBrand.Add(brand);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.Created, t);
                    }

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Provide Required Info");
                }
            }

        }


        //Update Brand
        public HttpResponseMessage PutBrand(tblBrands t)
        {
            using (db = new ShoeApiContext())
            {
                var editbrand = db.tBrand.Where(x => x.Brand_Id == t.Brand_Id).FirstOrDefault();

                if (editbrand != null)
                {
                    editbrand.Brand_Name = t.Brand_Name;
                    //editbrand.Brand_CreatedDate = createdDate;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, editbrand);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Brand id " + t.Brand_Id + " Not Found");
                }

            }
        }


        //Delete Brand by Id
        public HttpResponseMessage DeleteBrand(int id)
        {
            using (db = new ShoeApiContext())
            {
                var delBrand = db.tBrand.Where(x => x.Brand_Id == id).FirstOrDefault();

                if (delBrand != null)
                {
                    db.tBrand.Remove(delBrand);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Brand with id = " + id + " not found");
                }

            }
        }

    }
}
