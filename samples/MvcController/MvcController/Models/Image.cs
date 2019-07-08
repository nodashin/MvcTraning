using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcController.Models
{
  public class Image
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Ctype { get; set; }
    public byte[] Data { get; set; }
  }
}