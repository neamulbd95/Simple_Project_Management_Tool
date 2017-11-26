using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    public interface iUser_Authentication_Data
    {
        IEnumerable<User_Authentication> GetAll();
        User_Authentication GetSingle(string email,string password);
        void Insert(User_Authentication user_authentication);
        void Update(User_Authentication user_authentication);
        void Delete(string email);
    }
}
