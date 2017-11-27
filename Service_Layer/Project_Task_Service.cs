using Entity;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer
{
    class Project_Task_Service : iProject_Task_Service
    {
        private iProject_Task_Data data;
        public Project_Task_Service(iProject_Task_Data data)
        {
            this.data = data;
        }
        public IEnumerable<Project_Task> GetAll()
        {
            return this.data.GetAll();
        }
        public IEnumerable<Project_Task> GetByProjectID(int projectID)
        {
            return this.data.GetByProjectID(projectID);
        }
        public IEnumerable<Project_Task> GetByUserID(int userID)
        {
            return this.data.GetByUserID(userID);
        }
        public Project_Task GetSingle(int Id)
        {
            return this.data.GetSingle(Id);
        }
        public void Insert(Project_Task projectTask)
        {
            this.data.Insert(projectTask);
        }
        public void Update(Project_Task projectTask)
        {
            this.data.Update(projectTask);
        }
        public void DeleteProject(int projectID)
        {
            this.data.DeleteProject(projectID);
        }
        public void DeleteUser(int userId)
        {
            this.data.DeleteUser(userId);
        }
        public void Delete(int id)
        {
            this.data.Delete(id);
        }
        public int TotalRow(int projectID)
        {
            return this.data.TotalRow(projectID);
        }
    }
}
