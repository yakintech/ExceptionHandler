using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCErrorHandling.Data.Entities
{
    public class ErrorLog
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string UserAgent { get; set; }
        public string StackTrace { get; set; }
        public string SessionID { get; set; }
        public string TargetedResult { get; set; }
        public string IPAdress { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ExceptionName { get; set; }


    }
}