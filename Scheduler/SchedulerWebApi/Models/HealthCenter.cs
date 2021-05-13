using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchedulerWebApi.Models
{
    [Table("HealthCenter")]
    public class HealthCenter
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Director { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}