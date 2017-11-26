using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    class User_Authentication_Data : iUser_Authentication_Data
    {
        private SPMT_databaseContext context;

        public User_Authentication_Data(SPMT_databaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<User_Authentication> GetAll()
        {
            return this.context.User_Authentication.ToList();
        }

        public User_Authentication GetSingle(string email, string password)
        {
            return this.context.User_Authentication.SingleOrDefault(x => x.userEmail == email && x.password==password);
        }

        public void Insert(User_Authentication user_authentication)
        {
            this.context.User_Authentication.Add(user_authentication);
            this.context.SaveChanges();
        }
        public void Update(User_Authentication user_authentication)
        {
            User_Authentication user = this.context.User_Authentication.SingleOrDefault(x=> x.userEmail == user_authentication.userEmail);
            user.password = user_authentication.password;

            this.context.SaveChanges();
        }
        public void Delete(string email)
        {
            User_Authentication user = this.context.User_Authentication.SingleOrDefault(x=> x.userEmail == email);
            this.context.User_Authentication.Remove(user);
            this.context.SaveChanges();
        }
    }
}
