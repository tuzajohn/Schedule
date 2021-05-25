using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
    public class Ward
    {
        public string Id { get; set; }
        public string DivisionId { get; set; }
        public string InchargeId { get; set; }
        public string CenterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfWorkers { get; set; }
        public int MinimunHoursAday { get; set; }
        public int MaximumHoursAday { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
