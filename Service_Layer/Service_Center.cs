using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer
{
    public abstract class Service_Center
    {
        public static iUser_Authentication_Service GetUser_Authentication_Service()
        {
            return new User_Authentication_Service(DataAccess_Center.GetUser_Authentication());
        }

        public static iUser_Info_Service GetUser_Info_Service()
        {
            return new User_Info_Service(DataAccess_Center.GetUser_Info_Data());
        }

        public static iProject_Info_Service GetProject_Info_Service()
        {
            return new Project_Info_Service(DataAccess_Center.GetProject_Info_Data());
        }

        public static iAssign_Person_Service GetAssign_Person_Service()
        {
            return new Assign_Person_Service(DataAccess_Center.GetAssign_Person_Data());
        }

        public static iProject_Task_Service GetProject_Task_Service()
        {
            return new Project_Task_Service(DataAccess_Center.GetProject_Task_Data());
        }
        public static iComment_Service GetComment_Service()
        {
            return new Comment_Service(DataAccess_Center.GetComment_Data());
        }
    }
}
