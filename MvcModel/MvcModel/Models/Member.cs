﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MvcModel.Extensions;

namespace MvcModel.Models
{
    //[CustomValidation(typeof(Member), "CheckMarriedAndEmail")]
    public class Member: IValidatableObject
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [RegularExpression("[^a-zA-Z0-9]*", ErrorMessage = "{0}には半角英数字を含めないでください。")]
        public string Name { get; set; }

        [DisplayName("メールアドレス")]
        [EmailAddress(ErrorMessage = "メールアドレスの形式で入力してください。")]
        public string Email { get; set; }

        //[DisplayName("メールアドレス(確認様)")]
        //[NotMapped]
        //[Compare("Email", ErrorMessage = "{1}と一致していません。")]
        //public string EmailConfirmed { get; set; }

        [DisplayName("生年月日")]
        [Required(ErrorMessage = "{0}は必須です。")]
        public DateTime Birth { get; set; }

        [DisplayName("既婚")]
        public bool Married { get; set; }

        [DisplayName("自己紹介")]
        [StringLength(100, ErrorMessage = "{0}は{1}文字以内で入力してください。")]
        [Blackword("違法,麻薬,毒")]
        //[CustomValidation(typeof(Member), "CheckBlackWord")]
        public string Memo { get; set; }

        //public static ValidationResult CheckBlackWord(string memo)
        //{
        //    string[] list = new string[] { "違法", "麻薬", "毒" };
        //    foreach (var data in list)
        //    {
        //        if(memo.Contains(data))
        //        {
        //            return new ValidationResult("NGワードが含まれています。");
        //        }
        //    }
        //    return ValidationResult.Success;
        //}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var m = (Member)validationContext.ObjectInstance;
            if (m.Married && m.Email == null)
            {
                yield return new ValidationResult("既婚者はメールアドレスを入力してください。", new[] { "Email", "Married" });
            }
        }

        //public static ValidationResult CheckMarriedAndEmail(Member m)
        //{
        //    //既婚で、メールアドレスが空の場合にエラー
        //    if(m.Married && m.Email == null)
        //    {
        //        return new ValidationResult("既婚者はメールアドレスを入力してください。");
        //    }
        //    return ValidationResult.Success;
        //}

    }
}