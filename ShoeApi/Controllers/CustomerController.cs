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
    public class CustomerController : ApiController
    {

        private ShoeApiContext db;
        DateTime createdDate = DateTime.Now;

        public HttpResponseMessage GetAllCustomers()
        {
            List<tblUsers> user = new List<tblUsers>();
            using (db = new ShoeApiContext())
            {
                user = db.tUser.Where(u => u.UserType == true).ToList();
                if (user.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "No Record Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
            }
        }


        public HttpResponseMessage GetCustomerById(int id)
        {
            using (db = new ShoeApiContext())
            {
                var byID = db.tUser.Where(x => x.User_Id == id).FirstOrDefault();
                if (byID != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, byID);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User with id = " + id + " not found");
                }
            }
        }

        public HttpResponseMessage PutCustomers(tblUsers t)
        {
            using (db = new ShoeApiContext())
            {
                var editCust = db.tUser.Where(x => x.User_Id == t.User_Id).FirstOrDefault();

                if (editCust != null)
                {
                    editCust.isActive = t.isActive;
                   
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, editCust);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Customer id " + t.User_Id + " Not Found");
                }

            }
        }


        public HttpResponseMessage DeleteCustomer(int id)
        {
            using (db = new ShoeApiContext())
            {
                var delCust = db.tUser.Where(x => x.User_Id == id).FirstOrDefault();

                if (delCust != null)
                {
                    db.tUser.Remove(delCust);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Customer with id = " + id + " not found");
                }

            }
        }

    }
}
