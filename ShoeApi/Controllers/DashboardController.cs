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
    public class DashboardController : ApiController
    {

        private ShoeApiContext db;
        DateTime createdDate = DateTime.Now;


       
        public HttpResponseMessage GetDashboardCount()
        {
            using (db = new ShoeApiContext())
            {
                var count = new
                {
                    SportCount = db.tProducts.Where(p => p.CategoryId == 3).Count(),
                    CasualCount = db.tProducts.Where(p => p.CategoryId == 1).Count(),
                    FormalCount = db.tProducts.Where(p => p.CategoryId == 2).Count(),
                    CustomerCount = db.tUser.Count(u => u.UserType && u.isActive)
            };
                return Request.CreateResponse(HttpStatusCode.OK, count);
            }
        }
    }
}
