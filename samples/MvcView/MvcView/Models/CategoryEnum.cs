using System.ComponentModel.DataAnnotations;

namespace MvcView.Models
{
  public enum CategoryEnum
  {
    [Display(Name = ".NET")]
    DotNet,

    [Display(Name = "クラウド")]
    Cloud,

    [Display(Name = "リファレンス")]
    Reference
  }
}