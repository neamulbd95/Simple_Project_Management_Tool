using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    class User_Info_Data : iUser_Info_Data
    {
        private SPMT_databaseContext context;

        public User_Info_Data(SPMT_databaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<User_Info> GetAll()
        {
            return this.context.User_Info.ToList();
        }
        public User_Info GetSingleByID(int Id)
        {
            return this.context.User_Info.SingleOrDefault(x=> x.Id == Id);
        }
        public User_Info GetSingleByEmail(string email)
        {
            return this.context.User_Info.SingleOrDefault(x=> x.Email == email);
        }
        public void Insert(User_Info userInfo)
        {
            this.context.User_Info.Add(userInfo);
            this.context.SaveChanges();
        }
        public void Update(User_Info userInfo)
        {
            User_Info user = this.context.User_Info.SingleOrDefault(x=> x.Id == userInfo.Id);
            user.Name = userInfo.Name;

            this.context.SaveChanges();
        }
        public void Delete(int Id)
        {
            User_Info user = this.context.User_Info.SingleOrDefault(x => x.Id == Id);
            this.context.User_Info.Remove(user);
            this.context.SaveChanges();
        }
    }
}
