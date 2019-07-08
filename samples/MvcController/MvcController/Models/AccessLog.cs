using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcController.Models
{
  public class AccessLog
  {
    public int Id { get; set; }
    public string Url { get; set; }
    public string UserAgent { get; set; }
    public DateTime Accessed { get; set; }
  }
}