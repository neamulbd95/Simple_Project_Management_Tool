using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Project_Info
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string UploadFile { get; set; }
        public string Status { get; set; }

    }
}
