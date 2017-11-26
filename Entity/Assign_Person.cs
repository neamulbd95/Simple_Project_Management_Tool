using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Assign_Person
    {
        [Key]
        public int Id { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
    }
}
