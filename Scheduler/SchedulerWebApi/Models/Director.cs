using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchedulerWebApi.Models
{
    [Table("Director")]
    public class Director
    {
        [Key]
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}