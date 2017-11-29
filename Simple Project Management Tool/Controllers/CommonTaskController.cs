using Entity;
using Service_Layer;
using Simple_Project_Management_Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_Project_Management_Tool.Controllers
{
    public class CommonTaskController : Controller
    {
        //
        // GET: /CommonTask/
        iAssign_Person_Service asPersons = Service_Center.GetAssign_Person_Service();
        iUser_Info_Service users = Service_Center.GetUser_Info_Service();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers(string project)
        {
            IEnumerable<Assign_Person> asP = asPersons.GetByProject(Convert.ToInt32(project));
            List<AssignPersonListModel> aspModelList = new List<AssignPersonListModel>();

            foreach(Assign_Person a in asP)
            {
                AssignPersonListModel AspModel = new AssignPersonListModel();

                AspModel.userId = a.UserID;
                AspModel.userName = users.GetSingleByID(a.UserID).Name;

                aspModelList.Add(AspModel);
            }

            return Json(aspModelList,JsonRequestBehavior.AllowGet) ;
        }
    }
}
