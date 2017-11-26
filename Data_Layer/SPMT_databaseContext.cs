using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Data_Layer
{
    class SPMT_databaseContext : DbContext
    {
        public DbSet<User_Authentication> User_Authentication { get; set; }
        public DbSet<User_Info> User_Info { get; set; }
        public DbSet<Project_Info> Project_Info { get; set; }
        public DbSet<Assign_Person> Assign_Person { get; set; }
        public DbSet<Project_Task> Project_Task { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
