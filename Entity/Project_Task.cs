using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Project_Task
    {
        [Key]
        public int Id { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
    }
}
