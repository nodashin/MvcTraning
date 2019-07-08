using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcController.Models
{
    public class Image
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string CType { get; set; }
        public byte[] Data { get; set; }
    }
}