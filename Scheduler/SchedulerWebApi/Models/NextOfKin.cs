using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWebApi.Models
{
    public class NextOfKin
    {
        public string Id { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public string Contact { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}