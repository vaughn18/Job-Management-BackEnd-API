using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Management_API.Models
{
    public class Workers
    {
        [Key]
        public Guid workerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string description { get; set; }

        //Foreign Keys
        public ICollection<WorkersJobs> workersJobs { get; set; }
    }
}
