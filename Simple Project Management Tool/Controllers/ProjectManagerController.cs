using Entity;
using Simple_Project_Management_Tool.Models;
using Service_Layer;
using System;
using System.Dynamic;
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
        iUser_Info_Service users = Service_Center.GetUser_Info_Service();

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

                IEnumerable<Assign_Person> assigns = assiPersons.GetAll();
                List<AssignProjectList> assignModels = new List<AssignProjectList>();

                int id = 0;

                foreach(Assign_Person ap in assigns)
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

        public ActionResult AssignUser()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];

                return View();

                /*IEnumerable<Project_Info> projectList = projects.GetAll();
                List<projectListModel> projectModels = new List<projectListModel>();

                foreach(Project_Info pro in projectList)
                {
                    projectListModel proModel = new projectListModel();

                    proModel.projectID = pro.Id;
                    proModel.projectName = pro.Name;

                    projectModels.Add(proModel);
                }

                IEnumerable<User_Info> userList = users.GetAll();
                List<UserList> userModelList = new List<UserList>();

                foreach (User_Info user in userList)
                {
                    UserList u = new UserList();

                    u.userID = user.Id;
                    u.userName = user.Name;

                    userModelList.Add(u);
                }

                dynamic customModel = new ExpandoObject();

                customModel.ProjectList = projectModels;
                customModel.UserList = userModelList;*/                
            }
            return View("Index", "Error");
        }

        public PartialViewResult RenderProject()
        {
            return PartialView(projects.GetAll());
        }

        public PartialViewResult RenderUser()
        {
            return PartialView(users.GetAll());
        }

        public ActionResult AssignIngUser()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                if (Request.Form["SubmitName"] != null)
                {
                    Assign_Person asp = new Assign_Person();
                    asp.ProjectID = Convert.ToInt32(Request.Form["ProjectName"]);
                    asp.UserID = Convert.ToInt32(Request.Form["UserName"]);

                    try
                    {
                        assiPersons.Insert(asp);
                        return View("Index");
                    }
                    catch(Exception e)
                    {
                        Response.Write(e);
                    }
                }
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

        public ActionResult addTask()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];
                return View();
            }
            return View("Index", "Error");
        }

        public ActionResult AddingTask()
        {
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
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
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];

                ViewBag.ProjectName = projects.GetSingleByID(Id).Name;
                ViewBag.TotalTask = tasks.TotalRow(Id);

                IEnumerable<Project_Task> TaskList = tasks.GetByProjectID(Id);
                List<ViewTasksModel> TaskModelList = new List<ViewTasksModel>();
                int c = 0;

                foreach(Project_Task task in TaskList)
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
            if (Convert.ToBoolean(Session["loggedOn"]) == true && Convert.ToInt32(Session["userType"]) == 2)
            {
                ViewBag.userTypeName = Session["UserTypeName"];
                ViewBag.userEmail = Session["UserEmail"];

                ViewBag.ProjectName = projects.GetSingleByID(Id).Name;
                ViewBag.TotalMember = assiPersons.TotalRow(Id);

                IEnumerable<Assign_Person> AssignPersonList = assiPersons.GetByProject(Id);
                List<ViewProjectMemberModel> projectMemberList = new List<ViewProjectMemberModel>();

                foreach(Assign_Person asp in AssignPersonList)
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
