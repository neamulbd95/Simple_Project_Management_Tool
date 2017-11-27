using Entity;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer
{
    class User_Authentication_Service : iUser_Authentication_Service
    {
        private iUser_Authentication_Data data;

        public User_Authentication_Service(iUser_Authentication_Data data)
        {
            this.data = data;
        }

        public IEnumerable<User_Authentication> GetAll()
        {
            return this.data.GetAll();
        }
        public User_Authentication GetSingle(string email, string password)
        {
            return this.data.GetSingle(email,password);
        }
        public void Insert(User_Authentication user_authentication)
        {
            this.data.Insert(user_authentication);
        }
        public void Update(User_Authentication user_authentication)
        {
            this.data.Update(user_authentication);
        }
        public void Delete(string email)
        {
            this.data.Delete(email);
        }
    }
}
