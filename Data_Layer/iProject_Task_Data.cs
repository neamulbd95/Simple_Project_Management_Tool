using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    public interface iProject_Task_Data
    {
        IEnumerable<Project_Task> GetAll();
        IEnumerable<Project_Task> GetByProjectID(int projectID);
        IEnumerable<Project_Task> GetByUserID(int userID);
        Project_Task GetSingle(int Id);
        void Insert(Project_Task projectTask);
        void Update(Project_Task projectTask);
        void DeleteProject(int projectID);
        void DeleteUser(int userId);
        void Delete(int id);
        int TotalRow(int projectID);
    }
}
