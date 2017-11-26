using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    public abstract class DataAccess_Center
    {
        public static iUser_Authentication_Data GetUser_Authentication()
        {
            return new User_Authentication_Data(new SPMT_databaseContext());
        }

        public static iUser_Info_Data GetUser_Info_Data()
        {
            return new User_Info_Data(new SPMT_databaseContext());
        }

        public static iProject_Info_Data GetProject_Info_Data()
        {
            return new Project_Info_Data(new SPMT_databaseContext());
        }

        public static iAssign_Person_Data GetAssign_Person_Data()
        {
            return new Assign_Person_Data(new SPMT_databaseContext());
        }

        public static iProject_Task_Data GetProject_Task_Data()
        {
            return new Project_Task_Data(new SPMT_databaseContext());
        }

        public static iComment_Data GetComment_Data()
        {
            return new Comment_Data(new SPMT_databaseContext());
        }
    }
}
