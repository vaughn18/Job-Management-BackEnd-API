using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Management_API.Models
{
    public class Company
    {
        [Key]
        public Guid companyId { get; set; }
        public string companyName { get; set; }
        public string description { get; set; }
        public string logoUrl { get; set; }


        //Foreign link
        public List<Jobs> jobs { get; set; }
    }
}
