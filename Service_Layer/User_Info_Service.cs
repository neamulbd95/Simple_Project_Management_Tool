using Entity;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer
{
    class User_Info_Service : iUser_Info_Service
    {
        private iUser_Info_Data data;
        
        public User_Info_Service(iUser_Info_Data data)
        {
            this.data = data;
        }

        public IEnumerable<User_Info> GetAll()
        {
            return this.data.GetAll();
        }
        public User_Info GetSingleByID(int Id)
        {
            return this.data.GetSingleByID(Id);
        }
        public User_Info GetSingleByEmail(string email)
        {
            return this.data.GetSingleByEmail(email);
        }
        public void Insert(User_Info userInfo)
        {
            this.data.Insert(userInfo);
        }
        public void Update(User_Info userInfo)
        {
            this.data.Update(userInfo);
        }
        public void Delete(int Id)
        {
            this.data.Delete(Id);
        }
    }
}
