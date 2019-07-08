using System.ComponentModel.DataAnnotations;

namespace MvcController.Models
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