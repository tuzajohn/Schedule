using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWebApi.Models.Responses
{
    public class ApiResponse<TEntity>
    {
        public TEntity Data { get; set; }
        public string Message { get; set; }
        public bool Check { get; set; }
    }
}