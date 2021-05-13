using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.RestServices
{
    public class AppSettings
    {
        public string SchedulerEndPoint { get; set; } = "SchedulerEndPoint";
        public string SchedulerEndPointOnline { get; set; } = "SchedulerEndPointOnline";
        public string BaseURl { get; set; } = ConfigurationManager.AppSettings["SchedulerEndPointOnline"].ToString();
        public static string TestUrl { get; set; } = ConfigurationManager.AppSettings["SchedulerEndPointOnline"].ToString() + "divisions";
        public AppSettings (bool online = true) => BaseURl = ConfigurationManager.AppSettings[online ? SchedulerEndPointOnline : SchedulerEndPoint].ToString();
    }
}
