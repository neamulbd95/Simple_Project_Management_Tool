using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    class Comment_Data : iComment_Data
    {
        private SPMT_databaseContext context;
        public Comment_Data(SPMT_databaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return this.context.Comment.ToList();
        }
        public IEnumerable<Comment> GetByProjectAndTask(int projectID, int taskID)
        {
            return this.context.Comment.Where(x=> x.ProjectID == projectID && x.TaskID == taskID);
        }
        public Comment GetSingle(int Id)
        {
            return this.context.Comment.SingleOrDefault(x=> x.Id == Id);
        }
        public void Insert(Comment com)
        {
            this.context.Comment.Add(com);
            this.context.SaveChanges();
        }
        public void Update(Comment com)
        {
            Comment comm = this.context.Comment.SingleOrDefault(x=>x.Id == com.Id);
            comm.Content = com.Content;
            this.context.SaveChanges();
        }
        public void Delete(int Id)
        {
            Comment comm = this.context.Comment.SingleOrDefault(x=> x.Id == Id);
            this.context.Comment.Remove(comm);
            this.context.SaveChanges();
        }
        public void DeleteTask(int taskID)
        {
            IEnumerable<Comment> comms = this.context.Comment.Where(x=> x.TaskID == taskID);
            this.context.Comment.RemoveRange(comms);
            this.context.SaveChanges();
        }
        public void DeleteProject(int project)
        {
            IEnumerable<Comment> comms = this.context.Comment.Where(x => x.ProjectID == project);
            this.context.Comment.RemoveRange(comms);
            this.context.SaveChanges();
        }
    }
}
