﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcModel.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}