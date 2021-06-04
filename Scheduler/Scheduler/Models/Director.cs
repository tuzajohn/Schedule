using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
    public class Director
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
