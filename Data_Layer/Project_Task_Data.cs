using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    class Project_Task_Data : iProject_Task_Data
    {
        private SPMT_databaseContext context;
        public Project_Task_Data(SPMT_databaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<Project_Task> GetAll()
        {
            return this.context.Project_Task.ToList();
        }
        public IEnumerable<Project_Task> GetByProjectID(int projectID)
        {
            return this.context.Project_Task.Where(x=> x.ProjectID == projectID);
        }
        public IEnumerable<Project_Task> GetByUserID(int userID)
        {
            return this.context.Project_Task.Where(x=> x.UserID== userID);
        }
        public Project_Task GetSingle(int Id)
        {
            return this.context.Project_Task.SingleOrDefault(x=> x.Id == Id);
        }
        public void Insert(Project_Task projectTask)
        {
            this.context.Project_Task.Add(projectTask);
            this.context.SaveChanges();
        }
        public void Update(Project_Task projectTask)
        {
            Project_Task task = this.context.Project_Task.SingleOrDefault(x=> x.Id == projectTask.Id);
            task.UserID = projectTask.UserID;
            task.DueDate = projectTask.DueDate;
            this.context.SaveChanges();
        }
        public void DeleteProject(int projectID)
        {
            IEnumerable<Project_Task> tasks = this.context.Project_Task.Where(x=> x.ProjectID == projectID);
            this.context.Project_Task.RemoveRange(tasks);
            this.context.SaveChanges();
        }
        public void DeleteUser(int userId)
        {
            IEnumerable<Project_Task> tasks = this.context.Project_Task.Where(x => x.UserID == userId);
            this.context.Project_Task.RemoveRange(tasks);
            this.context.SaveChanges();
        }
        public void Delete(int id)
        {
            Project_Task task = this.context.Project_Task.SingleOrDefault(x=> x.Id == id);
            this.context.Project_Task.Remove(task);
            this.context.SaveChanges();
        }
        public int TotalRow(int projectID)
        {
            return this.context.Project_Task.Count(x=> x.ProjectID == projectID);
        }
    }
}
