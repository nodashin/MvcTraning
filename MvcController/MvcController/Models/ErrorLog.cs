using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcController.Models
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public string Stacktrace { get; set; }
        public DateTime Updated { get; set; }
    }
}