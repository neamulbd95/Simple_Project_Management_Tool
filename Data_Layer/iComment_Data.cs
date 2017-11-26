using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    public interface iComment_Data
    {
        IEnumerable<Comment> GetAll();
        IEnumerable<Comment> GetByProjectAndTask(int projectID, int taskID);
        Comment GetSingle(int Id);
        void Insert(Comment com);
        void Update(Comment com);
        void Delete(int Id);
        void DeleteTask(int taskID);
        void DeleteProject(int project);
    }
}
