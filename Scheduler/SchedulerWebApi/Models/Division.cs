using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchedulerWebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Division")]
    public class Division
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HealthFacilityId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}