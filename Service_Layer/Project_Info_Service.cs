using Entity;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer
{
    class Project_Info_Service : iProject_Info_Service
    {
        private iProject_Info_Data data;

        public Project_Info_Service(iProject_Info_Data data)
        {
            this.data = data;
        }
        public IEnumerable<Project_Info> GetAll()
        {
            return this.data.GetAll();
        }
        public Project_Info GetSingleByID(int Id)
        {
            return this.data.GetSingleByID(Id);
        }
        public void Insert(Project_Info projectInfo)
        {
            this.data.Insert(projectInfo);
        }
        public void Update(Project_Info projectInfo)
        {
            this.data.Update(projectInfo);
        }
        public void Delete(int Id)
        {
            this.data.Delete(Id);
        }
    }
}
