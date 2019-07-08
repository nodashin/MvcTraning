using System;
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

    [Display(Name = "Email", ResourceType = typeof(MvcOther.Resources.ModelResource))]
    public string Email { get; set; }

    [Display(Name = "Birth", ResourceType = typeof(MvcOther.Resources.ModelResource))]
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MvcOther.Resources.ModelResourceError))]
    public DateTime Birth { get; set; }

    [Display(Name = "Married", ResourceType = typeof(MvcOther.Resources.ModelResource))]
    public bool Married { get; set; }

    [Display(Name = "Memo", ResourceType = typeof(MvcOther.Resources.ModelResource))]
    [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MvcOther.Resources.ModelResourceError))]
    public string Memo { get; set; }

  }
}