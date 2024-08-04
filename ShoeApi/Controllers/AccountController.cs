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
    public class AccountController : ApiController
    {
        private ShoeApiContext db;
        DateTime createdDate = DateTime.Now;

       

        //Get User By Id
        public HttpResponseMessage GetUserById(int id)
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


        //User Login
       
        public HttpResponseMessage UserLogin(tblUsers u)
        {
            using (db = new ShoeApiContext())
            {
                string encodedPass = PasswordHelper.EncodePassword(u.U_Password);

                var checkUser = db.tUser.Where(x => x.U_Email == u.U_Email && x.U_Password == encodedPass).FirstOrDefault();

                if (checkUser != null)
                {
                    
                    return Request.CreateResponse(HttpStatusCode.OK, checkUser);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "InCorrect EmailID or Password");
                }
            }
        }

        //AddUser
        public HttpResponseMessage PostUser(tblUsers t)
        {
            using (db = new ShoeApiContext())
            {
                if (t != null)
                {
                    //var emailcheck = t.U_Email.ToString();
                    string emailcheck = string.IsNullOrEmpty(t.U_Email) ? "" : t.U_Email.ToString();
                    string userNamecheck = string.IsNullOrEmpty(t.U_UserName) ? "" : t.U_UserName.ToString();
                    string passwordcheck = string.IsNullOrEmpty(t.U_Password) ? "" : t.U_Password.ToString();
                    string firstNamecheck = string.IsNullOrEmpty(t.U_FirstName) ? "" : t.U_FirstName.ToString();


                    //var a = db.tUser.Where(x => x.U_UserName == null || x.U_Password == null || x.U_Email == null || x.U_FirstName == null);
                    //if (a == null)
                    //{
                    //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Please Enter mandatry fields");
                    //}

                    if (emailcheck == "")
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "Email Cannot be Empty");
                    }

                    else if (userNamecheck == "")
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "UserName Cannot be Empty");
                    }

                    else if (passwordcheck == "")
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "Password Cannot be Empty");
                    }

                    //else if (firstNamecheck == "")
                    //{
                    //    return Request.CreateResponse(HttpStatusCode.Found, "First Cannot be Empty");
                    //}

                    else if (db.tUser.Any(x => x.U_UserName == t.U_UserName))
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "UserName already Exists");
                    }

                    //else if (PasswordHelper.ValidateEmail(emailcheck) == false)
                    //{
                    //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Email is not in Correct Format");
                    //}

                    else if (db.tUser.Any(x => x.U_Email == emailcheck))
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "Email already Exists");
                    }
                    else
                    {
                        string encodedPassword = PasswordHelper.EncodePassword(t.U_Password);

                        tblUsers users = new tblUsers
                        {
                            U_UserName = t.U_UserName,
                            U_Password = encodedPassword,
                            U_Email = t.U_Email,
                            U_FirstName = t.U_FirstName,
                            U_LastName = t.U_LastName,
                            U_CreatedDate = createdDate,
                            isActive = true,
                            UserType=true,
                            U_LastUpdatedDate = createdDate,
                        };

                        db.tUser.Add(users);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.Created, users);
                    }

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Provide Required Info");
                }
            }

        }


        //Update User
        public HttpResponseMessage PutUser(int id, tblUsers t)
        {
            using (db = new ShoeApiContext())
            {
                var editusr = db.tUser.Where(x => x.User_Id == id).FirstOrDefault();

                if (editusr != null)
                {
                    editusr.U_FirstName = t.U_FirstName;
                    editusr.U_LastName = t.U_LastName;
                    editusr.U_Password = t.U_Password;
                    editusr.U_LastUpdatedDate = createdDate;

                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, editusr);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "User id " + id + " Not Found");
                }

            }
        }


        //Delete User by Id
        public HttpResponseMessage DeleteUser(int id)
        {
            using (db = new ShoeApiContext())
            {
                var delUser = db.tUser.Where(x => x.User_Id == id).FirstOrDefault();

                if (delUser != null)
                {
                    db.tUser.Remove(delUser);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with id = " + id + " not found");
                }

            }
        }



    }
}
