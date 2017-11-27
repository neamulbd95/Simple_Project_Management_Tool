using Entity;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer
{
    class Comment_Service : iComment_Service
    {
        private iComment_Data data;
        public Comment_Service(iComment_Data data)
        {
            this.data = data;
        }
        public IEnumerable<Comment> GetAll()
        {
            return this.data.GetAll();
        }
        public IEnumerable<Comment> GetByProjectAndTask(int projectID, int taskID)
        {
            return this.data.GetByProjectAndTask(projectID,taskID);
        }
        public Comment GetSingle(int Id)
        {
            return this.data.GetSingle(Id);
        }
        public void Insert(Comment com)
        {
            this.data.Insert(com);
        }
        public void Update(Comment com)
        {
            this.data.Update(com);
        }
        public void Delete(int Id)
        {
            this.data.Delete(Id);
        }
        public void DeleteTask(int taskID)
        {
            this.data.DeleteTask(taskID);
        }
        public void DeleteProject(int project)
        {
            this.data.DeleteProject(project);
        }

    }
}
