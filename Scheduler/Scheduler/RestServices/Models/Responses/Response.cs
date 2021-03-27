﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.RestServices.Models.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Check { get; set; }
    }
}
