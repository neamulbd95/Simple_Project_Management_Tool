using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    class Assign_Person_Data : iAssign_Person_Data
    {
        private SPMT_databaseContext context;
        public Assign_Person_Data(SPMT_databaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<Assign_Person> GetAll()
        {
            return this.context.Assign_Person.ToList();
        }
        public IEnumerable<Assign_Person> GetByProject(int projectID)
        {
            return this.context.Assign_Person.Where(x=> x.ProjectID == projectID);
        }
        public IEnumerable<Assign_Person> GetByUser(int userID)
        {
            return this.context.Assign_Person.Where(x=> x.UserID == userID);
        }
        public Assign_Person GetSingle(int Id)
        {
            return this.context.Assign_Person.SingleOrDefault(x=> x.Id == Id);
        }
        public void Insert(Assign_Person assignPerson)
        {
            this.context.Assign_Person.Add(assignPerson);
            this.context.SaveChanges();
        }
        public void DeleteProject(int Id)
        {
            IEnumerable<Assign_Person> assign = this.context.Assign_Person.Where(x=> x.ProjectID ==Id);
            this.context.Assign_Person.RemoveRange(assign);
            this.context.SaveChanges();
        }
        public void DeleteUser(int userId)
        {
            IEnumerable<Assign_Person> assign = this.context.Assign_Person.Where(x=> x.UserID == userId);
            this.context.Assign_Person.RemoveRange(assign);
            this.context.SaveChanges();
        }
        public int TotalRow(int ProjectId)
        {
            return this.context.Assign_Person.Count(x=>x.ProjectID == ProjectId);
        }
    }
}
