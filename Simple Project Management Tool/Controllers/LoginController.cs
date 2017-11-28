using Entity;
using Service_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_Project_Management_Tool.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        iUser_Authentication_Service userAuthe = Service_Center.GetUser_Authentication_Service();
        iUser_Info_Service users = Service_Center.GetUser_Info_Service();

        public ActionResult Index()
        {
            ViewBag.ErrorMsg = Session["logInErr"];
            return View();
        }

        public ActionResult checkLogin()
        {          
            if(Request.Form["submitBtn"] != null)
            {
                string userEmail = Request.Form["userEmail"];
                string password = Request.Form["pass"];

                if (userAuthe.GetSingle(userEmail, password) == null)
                {
                    Session["logInErr"] = "Log In Falied. Check UserName Or Passwor";

                    return RedirectToAction("Index");
                }
                else
                {
                    int userType = userAuthe.GetSingle(userEmail, password).userType;

                    if (userType == 1)
                    {
                        Session["UserTypeName"] = "IT Admin";
                        Session["userType"] = userType;
                        Session["UserID"] = users.GetSingleByEmail(userEmail).Id;
                        Session["UserEmail"] = userEmail;
                        Session["loggedOn"] = true;

                        return RedirectToAction("Index", "ItAdminHome");
                    }
                    else if (userType == 2)
                    {
                        Session["UserTypeName"] = "Project Manager";
                        Session["userType"] = userType;
                        Session["UserID"] = users.GetSingleByEmail(userEmail).Id;
                        Session["UserEmail"] = userEmail;
                        Session["loggedOn"] = true;

                        return RedirectToAction("Index", "ProjectManager");
                    }
                    else if (userType == 3)
                    {
                        Session["UserTypeName"] = "Team Lead";
                        Session["userType"] = userType;
                        Session["UserID"] = users.GetSingleByEmail(userEmail).Id;
                        Session["UserEmail"] = userEmail;
                        Session["loggedOn"] = true;
                    }
                    else if (userType == 4)
                    {
                        Session["UserTypeName"] = "Developer";
                        Session["userType"] = userType;
                        Session["UserID"] = users.GetSingleByEmail(userEmail).Id;
                        Session["UserEmail"] = userEmail;
                        Session["loggedOn"] = true;
                    }
                    else if (userType == 5)
                    {
                        Session["UserTypeName"] = "QA Engineer";
                        Session["userType"] = userType;
                        Session["UserID"] = users.GetSingleByEmail(userEmail).Id;
                        Session["UserEmail"] = userEmail;
                        Session["loggedOn"] = true;
                    }
                    else if (userType == 6)
                    {
                        Session["UserTypeName"] = "UX Engineer";
                        Session["userType"] = userType;
                        Session["UserID"] = users.GetSingleByEmail(userEmail).Id;
                        Session["UserEmail"] = userEmail;
                        Session["loggedOn"] = true;
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
