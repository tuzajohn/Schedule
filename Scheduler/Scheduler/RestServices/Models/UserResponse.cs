using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.RestServices.Models
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string WardId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string MaritalStatus { get; set; }
        public string MedicalIssues { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Address { get; internal set; }
    }
}
