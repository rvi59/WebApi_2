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
    public class SizeController : ApiController
    {
        private ShoeApiContext db;
        DateTime createdDate = DateTime.Now;
        public HttpResponseMessage GetAllSize()
        {
            List<tblSize> size = new List<tblSize>();

            using (db = new ShoeApiContext())
            {
                size = db.tSize.ToList();
                if (size.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "No Record Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, size);
                }
            }

        }

        //Get Size By Id
        public HttpResponseMessage GetSizeById(int id)
        {
            using (db = new ShoeApiContext())
            {
                var byID = db.tSize.Where(x => x.Size_Id == id).FirstOrDefault();
                if (byID != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, byID);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Size with id = " + id + " not found");
                }
            }
        }


        //Add Size
        public HttpResponseMessage PostSize(tblSize t)
        {
            using (db = new ShoeApiContext())
            {
                if (t != null)
                {

                    int sizeNamecheck = t.Size_Number;


                    if (sizeNamecheck==0)
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "Size  Cannot be Empty");
                    }

                    else if (db.tSize.Any(x => x.Size_Number == t.Size_Number))
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "Size already Exists");
                    }

                    else
                    {
                        tblSize size = new tblSize
                        {
                            Size_Number = t.Size_Number,
                            Size_CreatedDate = createdDate
                        };

                        db.tSize.Add(size);
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


        //Update Size
        public HttpResponseMessage PutSize(tblSize t)
        {
            using (db = new ShoeApiContext())
            {
                var editSize = db.tSize.Where(x => x.Size_Id == t.Size_Id).FirstOrDefault();

                if (editSize != null)
                {
                    editSize.Size_Number = t.Size_Number;
                    editSize.Size_CreatedDate = createdDate;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, editSize);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Size id " + t.Size_Id + " Not Found");
                }

            }
        }


        //Delete Size by Id
        public HttpResponseMessage DeleteSize(int id)
        {
            using (db = new ShoeApiContext())
            {
                var delSize = db.tSize.Where(x => x.Size_Id == id).FirstOrDefault();

                if (delSize != null)
                {
                    db.tSize.Remove(delSize);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Size with id = " + id + " not found");
                }

            }
        }
    }
}
