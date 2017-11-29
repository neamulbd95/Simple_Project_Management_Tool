using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple_Project_Management_Tool.Models
{
    public class AssignProjectList
    {
        public int Id { get; set; }
        public string projectName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDesignation { get; set; }

    }
}