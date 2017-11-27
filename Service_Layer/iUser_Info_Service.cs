using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer
{
    public interface iUser_Info_Service
    {
        IEnumerable<User_Info> GetAll();
        User_Info GetSingleByID(int Id);
        User_Info GetSingleByEmail(string email);
        void Insert(User_Info userInfo);
        void Update(User_Info userInfo);
        void Delete(int Id);
    }
}
