using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    class Project_Info_Data : iProject_Info_Data
    {
        private SPMT_databaseContext context;

        public Project_Info_Data(SPMT_databaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project_Info> GetAll()
        {
            return this.context.Project_Info.ToList();
        }
        public Project_Info GetSingleByID(int Id)
        {
            return this.context.Project_Info.SingleOrDefault(x=> x.Id == Id);
        }
        public void Insert(Project_Info projectInfo)
        {
            this.context.Project_Info.Add(projectInfo);
            this.context.SaveChanges();
        }
        public void Update(Project_Info projectInfo)
        {
            Project_Info project = this.context.Project_Info.SingleOrDefault(x=> x.Id == projectInfo.Id);
            project.Name = projectInfo.Name;
            project.CodeName = projectInfo.CodeName;

            this.context.SaveChanges();
        }
        public void Delete(int Id)
        {
            Project_Info project = this.context.Project_Info.SingleOrDefault(x => x.Id == Id);
            this.context.Project_Info.Remove(project);
            this.context.SaveChanges();
        }
    }
}
