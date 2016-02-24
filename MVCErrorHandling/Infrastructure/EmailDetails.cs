using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCErrorHandling.Infrastructure
{
    public class EmailDetails
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ToAddresses { get; set; }
        public string From { get; set; }

    }
}