using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    public interface iProject_Info_Data
    {
        IEnumerable<Project_Info> GetAll();
        Project_Info GetSingleByID(int Id);
        void Insert(Project_Info projectInfo);
        void Update(Project_Info projectInfo);
        void Delete(int Id);
    }
}
