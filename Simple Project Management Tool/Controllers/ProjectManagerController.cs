using Entity;
using Service_Layer;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_Project_Management_Tool.Controllers
{
    public class ProjectManagerController : Controller
    {
        //
        // GET: /ProjectManager/
        iProject_Info_Service projects = Service_Center.GetProject_Info_Service();
        iProject_Task_Service tasks = Service_Center.GetProject_Task_Service();
        iAssign_Person_Service assiPersons = Service_Center.GetAssign_Person_Service();

        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View();
            }
            return View("Index", "Error");
        }

        public ActionResult showProject()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View(projects.GetAll());
            }
            return View("Index", "Error");
        }

        public ActionResult addProject()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View();
            }
            return View("Index", "Error");
        }

        public ActionResult addIngProject(HttpPostedFileBase fileUpload)
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                if (Request.Form["AddBtn"] != null)
                {
                    try
                    {
                        ViewBag.userTypeName = Session["UserTypeName"];
                        ViewBag.userEmail = Session["UserEmail"];

                        var filename = Path.GetFileName(fileUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/Files"), filename);
                        fileUpload.SaveAs(path);

                        DateTime dt1 = Convert.ToDateTime(Request.Form["endDate"]);
                        DateTime dt2 = Convert.ToDateTime(Request.Form["startDate"]);

                        TimeSpan ts = dt1 - dt2;

                        int days = ts.Days;

                        Project_Info project = new Project_Info();

                        project.Name = Request.Form["Name"];
                        project.CodeName = Request.Form["codeName"];
                        project.Description = Request.Form["description"];
                        project.StartDate = Convert.ToDateTime(Request.Form["startDate"]);
                        project.EndDate = Convert.ToDateTime(Request.Form["endDate"]);
                        project.Duration = days;
                        project.Status = Request.Form["status"];
                        project.UploadFile = "~/Files/" + filename.ToString();

                        projects.Insert(project);

                        return RedirectToAction("showProject");
                    }
                    catch(Exception e)
                    {
                        ViewBag.Errormsg = e;
                        Response.Write(e);
                    }
                }
                
            }
            return View("Index", "Error");
        }

        public ActionResult ViewAssignedUser()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View();
            }
            return View("Index", "Error");
        }

        public ActionResult AssignUser()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View();
            }
            return View("Index", "Error");
        }

        public ActionResult Edit(int Id)
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];

                //
                return View();
            }
            return View("Index", "Error");
        }

    }
}
