﻿using System.ComponentModel.DataAnnotations;

namespace MvcModel.Models
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