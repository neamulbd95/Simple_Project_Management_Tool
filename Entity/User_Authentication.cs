using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class User_Authentication
    {
        [Key]
        public int Id { get; set; }
        public string userEmail { get; set; }
        public string password { get; set; }
        public int userType { get; set; }
    }
}
