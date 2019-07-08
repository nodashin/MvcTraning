using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcView.Models
{
    public enum CategoryEnum
    {
        [Display(Name =".NET")]
        DotNet,

        [Display(Name = "クラウド")]
        Cloud,

        [Display(Name = "リファレンス")]
        Reference
    }
}