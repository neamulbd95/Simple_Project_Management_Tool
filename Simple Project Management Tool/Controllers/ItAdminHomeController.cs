using Entity;
using Service_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_Project_Management_Tool.Controllers
{
    public class ItAdminHomeController : Controller
    {
        //
        // GET: /ItAdminHome/
        iUser_Info_Service users = Service_Center.GetUser_Info_Service();
        iUser_Authentication_Service log = Service_Center.GetUser_Authentication_Service();
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["loggedOn"])== true && Convert.ToInt32(Session["userType"])==1)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View();
            }
            return View("Index","Error");
        }

        public ActionResult showUsers()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 1)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View(users.GetAll());
            }
            return View("Index", "Error");
        }

        public ActionResult addUsers()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 1)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View();
            }
            return View("Index", "Error");
        }

        public ActionResult AddingUsers()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 1)
            {
                if (Request.Form["AddBtn"] != null)
                {
                    try
                    {
                        User_Info user = new User_Info();
                        user.Name = Request.Form["Name"];
                        user.Email = Request.Form["email"];
                        user.Status = Request.Form["status"];
                        //user.Designation = Request.Form["desig"];
                        if(Convert.ToInt32(Request.Form["desig"])==2)
                        {
                            user.Designation = "Project Manager";
                        }
                        else if (Convert.ToInt32(Request.Form["desig"]) == 3)
                        {
                            user.Designation = "Team Lead";
                        }
                        else if (Convert.ToInt32(Request.Form["desig"]) == 4)
                        {
                            user.Designation = "Developer";
                        }
                        else if (Convert.ToInt32(Request.Form["desig"]) == 5)
                        {
                            user.Designation = "QA Engineer";
                        }
                        else if (Convert.ToInt32(Request.Form["desig"]) == 6)
                        {
                            user.Designation = "UX Engineer";
                        }

                        User_Authentication userlog = new User_Authentication();
                        userlog.userEmail = Request.Form["email"];
                        userlog.password = Request.Form["email"] + "123";
                        userlog.userType = Convert.ToInt32(Request.Form["desig"]);

                        users.Insert(user);
                        log.Insert(userlog);

                        return RedirectToAction("showUsers");
                    }
                    catch(Exception e)
                    {
                        ViewBag.Errormsg = e;

                    }
                }
                return View("Index");
            }
            return View("Index", "Error");
        }

        public ActionResult Edit(int Id)
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 1)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View(users.GetSingleByID(Id));
            }
            return View("Index", "Error");
            
        }

        public ActionResult UpdatingUser()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 1)
            {
                if (Request.Form["editBtn"] != null)
                {
                    try
                    {
                        User_Info user = new User_Info();
                        user.Id = Convert.ToInt32(Request.Form["id"]);
                        user.Name = Request.Form["Name"];
                        user.Email = Request.Form["email"];
                        user.Status = Request.Form["status"];
                        user.Designation = Request.Form["desig"];

                        users.Update(user);

                        return RedirectToAction("showUsers");
                    }
                    catch (Exception e)
                    {
                        ViewBag.Errormsg = e;

                    }
                }
            }
            return View("Index");

        }
    }
}
