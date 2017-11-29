using Entity;
using Service_Layer;
using System;
using Simple_Project_Management_Tool.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_Project_Management_Tool.Controllers
{
    public class OthersController : Controller
    {
        //
        // GET: /Others/
        iProject_Info_Service projects = Service_Center.GetProject_Info_Service();
        iProject_Task_Service tasks = Service_Center.GetProject_Task_Service();
        iAssign_Person_Service assiPersons = Service_Center.GetAssign_Person_Service();
        iUser_Info_Service users = Service_Center.GetUser_Info_Service();

        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && (Convert.ToInt32(Session["userType"]) == 3 || Convert.ToInt32(Session["userType"]) == 4 || Convert.ToInt32(Session["userType"]) == 5 || Convert.ToInt32(Session["userType"]) == 6))
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View();
            }
            return View("Index", "Error");
        }

        public ActionResult showProject()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && (Convert.ToInt32(Session["userType"]) == 3 || Convert.ToInt32(Session["userType"]) == 4 || Convert.ToInt32(Session["userType"]) == 5 || Convert.ToInt32(Session["userType"]) == 6))
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View(projects.GetAll());
            }
            return View("Index", "Error");
        }

        public ActionResult ViewAssignedUser()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && (Convert.ToInt32(Session["userType"]) == 3 || Convert.ToInt32(Session["userType"]) == 4 || Convert.ToInt32(Session["userType"]) == 5 || Convert.ToInt32(Session["userType"]) == 6))
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];

                IEnumerable<Assign_Person> assigns = assiPersons.GetAll();
                List<AssignProjectList> assignModels = new List<AssignProjectList>();

                int id = 0;

                foreach (Assign_Person ap in assigns)
                {
                    AssignProjectList assign = new AssignProjectList();

                    assign.Id = ++id;
                    assign.projectName = projects.GetSingleByID(ap.ProjectID).Name;
                    assign.EmployeeName = users.GetSingleByID(ap.UserID).Name;
                    assign.EmployeeDesignation = users.GetSingleByID(ap.UserID).Designation;

                    assignModels.Add(assign);
                }

                return View(assignModels);
            }
            return View("Index", "Error");
        }

        public ActionResult addTask()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && (Convert.ToInt32(Session["userType"]) == 3 || Convert.ToInt32(Session["userType"]) == 4 || Convert.ToInt32(Session["userType"]) == 5 || Convert.ToInt32(Session["userType"]) == 6))
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View();
            }
            return View("Index", "Error");
        }

        public ActionResult AddingTask()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && (Convert.ToInt32(Session["userType"]) == 3 || Convert.ToInt32(Session["userType"]) == 4 || Convert.ToInt32(Session["userType"]) == 5 || Convert.ToInt32(Session["userType"]) == 6))
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                if (Request.Form["SubmitName"] != null)
                {
                    Project_Task task = new Project_Task();

                    task.ProjectID = Convert.ToInt32(Request.Form["ProjectName"]);
                    task.UserID = Convert.ToInt32(Request.Form["user"]);
                    task.Description = Request.Form["description"];
                    task.DueDate = Convert.ToDateTime(Request.Form["dueDate"]);
                    task.Priority = Request.Form["priority"];

                    try
                    {
                        tasks.Insert(task);
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        Response.Write(e);
                    }
                }
            }
            return View("Index", "Error");
        }

        public ActionResult viewTask(int Id)
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && (Convert.ToInt32(Session["userType"]) == 3 || Convert.ToInt32(Session["userType"]) == 4 || Convert.ToInt32(Session["userType"]) == 5 || Convert.ToInt32(Session["userType"]) == 6))
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];

                ViewBag.ProjectName = projects.GetSingleByID(Id).Name;
                ViewBag.TotalTask = tasks.TotalRow(Id);

                IEnumerable<Project_Task> TaskList = tasks.GetByProjectID(Id);
                List<ViewTasksModel> TaskModelList = new List<ViewTasksModel>();
                int c = 0;

                foreach (Project_Task task in TaskList)
                {
                    ViewTasksModel t = new ViewTasksModel();

                    t.Serial = ++c;
                    t.AssignTo = users.GetSingleByID(task.UserID).Name;
                    t.Description = task.Description;
                    t.Status = task.Priority;
                    t.DueDate = task.DueDate.Date;

                    TaskModelList.Add(t);
                }

                return View(TaskModelList);
            }
            return View("Index", "Error");
        }

        public ActionResult viewMembers(int Id)
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && (Convert.ToInt32(Session["userType"]) == 3 || Convert.ToInt32(Session["userType"]) == 4 || Convert.ToInt32(Session["userType"]) == 5 || Convert.ToInt32(Session["userType"]) == 6))
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];

                ViewBag.ProjectName = projects.GetSingleByID(Id).Name;
                ViewBag.TotalMember = assiPersons.TotalRow(Id);

                IEnumerable<Assign_Person> AssignPersonList = assiPersons.GetByProject(Id);
                List<ViewProjectMemberModel> projectMemberList = new List<ViewProjectMemberModel>();

                foreach (Assign_Person asp in AssignPersonList)
                {
                    ViewProjectMemberModel member = new ViewProjectMemberModel();

                    member.memberName = users.GetSingleByID(asp.UserID).Name;
                    member.memberDesignation = users.GetSingleByID(asp.UserID).Designation;

                    projectMemberList.Add(member);
                }

                return View(projectMemberList);
            }
            return View("Index", "Error");
        }

    }
}
