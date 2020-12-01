using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Management_API.Models
{
    public class WorkersJobs
    {
        public Guid workersJobsId { get; set; }
        public Guid workerId { get; set; }
        public Workers worker { get; set; }
        public Guid jobId { get; set; }
        public Jobs job { get; set; }
    }
}
