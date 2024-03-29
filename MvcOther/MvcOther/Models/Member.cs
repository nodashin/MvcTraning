﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOther.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(MvcOther.Resources.ModelResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MvcOther.Resources.ModelResourceError))]
        [RegularExpression("[^a-zA-Z0-9]*", ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(MvcOther.Resources.ModelResourceError))]
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public bool Married { get; set; }
        public string Memo { get; set; }
    }
}