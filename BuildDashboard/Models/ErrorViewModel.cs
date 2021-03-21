using System;
using System.Collections.Generic;

namespace BuildDashboard.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class DashboardContent
    {
        public string ResponseData { get; set; }
    }

    
    public class BuildDetails
    {
        public string _class { get; set; }
        public List<Build> builds { get; set; }
    }

    public class Build
    {
        public string _class { get; set; }
        public string id { get; set; }

        public int number { get; set; }

        public string result { get; set; }

        public string timestamp { get; set; }

    }
}
