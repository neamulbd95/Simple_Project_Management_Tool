using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    public interface iAssign_Person_Data
    {
        IEnumerable<Assign_Person> GetAll();
        IEnumerable<Assign_Person> GetByProject(int projectID);
        IEnumerable<Assign_Person> GetByUser(int userID);
        Assign_Person GetSingle(int Id);
        void Insert(Assign_Person assignPerson);
        void DeleteProject(int Id);
        void DeleteUser(int userId);
        int TotalRow(int ProjectId);
    }
}
