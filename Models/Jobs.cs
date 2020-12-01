using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Management_API.Models
{
    public class Jobs
    {
        [Key]
        public Guid jobId { get; set; }
        public string jobName { get; set; }
        public bool jobStatus { get; set; }


        //Foreign keys
        public Guid companyId { get; set; }
        public Company company { get; set; }
        public ICollection<WorkersJobs> workersJobs { get; set; }
    }
}
