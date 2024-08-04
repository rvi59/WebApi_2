using ShoeApi.DataContext;
using ShoeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoeApi.Controllers
{
    public class CategoryController : ApiController
    {

        private ShoeApiContext db;
        DateTime createdDate = DateTime.Now;

        public HttpResponseMessage GetAllCategories()
        {
            List<tblCategory> categories = new List<tblCategory>();

            using (db = new ShoeApiContext())
            {
                categories = db.tCategory.ToList();
                if (categories.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "No Record Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, categories);
                }
            }

        }

        //Get Brand By Id
        public HttpResponseMessage GetCategoryById(int id)
        {
            using (db = new ShoeApiContext())
            {
                var byID = db.tCategory.Where(x => x.Category_Id == id).FirstOrDefault();
                if (byID != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, byID);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Category with id = " + id + " not found");
                }
            }
        }


        //Add Brand
        public HttpResponseMessage PostCategory(tblCategory t)
        {
            using (db = new ShoeApiContext())
            {
                if (t != null)
                {
                    string categoryNamecheck = string.IsNullOrEmpty(t.Category_Name) ? "" : t.Category_Name.ToString();

                    if (categoryNamecheck == "")
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "Category Name Cannot be Empty");
                    }

                    else if (db.tCategory.Any(x => x.Category_Name == t.Category_Name))
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "Category Name already Exists");
                    }

                    else
                    {
                        tblCategory category = new tblCategory
                        {
                            Category_Name = t.Category_Name,
                            Category_CreatedDate = createdDate

                        };
                        db.tCategory.Add(category);
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


        //Update User
        public HttpResponseMessage PutCategory(tblCategory t)
        {
            using (db = new ShoeApiContext())
            {
                var editCategory = db.tCategory.Where(x => x.Category_Id == t.Category_Id).FirstOrDefault();

                if (editCategory != null)
                {
                    editCategory.Category_Name = t.Category_Name;
                    editCategory.Category_CreatedDate = createdDate;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, editCategory);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Category id " + t.Category_Id + " Not Found");
                }

            }
        }


        //Delete Brand by Id
        public HttpResponseMessage DeleteCategory(int id)
        {
            using (db = new ShoeApiContext())
            {
                var delCategory = db.tCategory.Where(x => x.Category_Id == id).FirstOrDefault();

                if (delCategory != null)
                {
                    db.tCategory.Remove(delCategory);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Category with id = " + id + " not found");
                }

            }
        }

    }
}
