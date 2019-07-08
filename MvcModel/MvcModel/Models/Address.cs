using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcModel.Models
{
    [ComplexType]
    public class Address
    {
        [Column("Prefecture")]
        public string Prefecture { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("Street")]
        public string Street { get; set; }
    }
}