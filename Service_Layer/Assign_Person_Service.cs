using Entity;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer
{
    class Assign_Person_Service : iAssign_Person_Service
    {
        private iAssign_Person_Data data;

        public Assign_Person_Service(iAssign_Person_Data data)
        {
            this.data = data;
        }
        public IEnumerable<Assign_Person> GetAll()
        {
            return this.data.GetAll();
        }
        public IEnumerable<Assign_Person> GetByProject(int projectID)
        {
            return this.data.GetByProject(projectID);
        }
        public IEnumerable<Assign_Person> GetByUser(int userID)
        {
            return this.data.GetByUser(userID);
        }
        public Assign_Person GetSingle(int Id)
        {
            return this.data.GetSingle(Id);
        }
        public void Insert(Assign_Person assignPerson)
        {
            this.data.Insert(assignPerson);
        }
        public void DeleteProject(int Id)
        {
            this.data.DeleteProject(Id);
        }
        public void DeleteUser(int userId)
        {
            this.data.DeleteUser(userId);
        }
        public int TotalRow(int ProjectId)
        {
            return this.data.TotalRow(ProjectId);
        }
    }
}
