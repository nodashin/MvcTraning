using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModel.Extensions
{
    //禁止ワードの有無を検証するBlackword属性を定義
    public class BlackwordAttribute : ValidationAttribute, IClientValidatable
    {
        //禁止ワードを表すプライベート変数
        private string _opts;

        //コンストラクター(値リストとエラーメッセージを設定)
        public BlackwordAttribute(string opts)
        {
            this._opts = opts;
            this.ErrorMessage = "{0}には{1}を含むことはできません。";
        }

        //プロパティの表示名と値リストでエラーメッセージを整形
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this._opts);
        }

        public override bool IsValid(object value)
        {
            //入力値が空の場合は検証をスキップ
            if (value == null) { return true; }

            //カンマ区切りテキストを分解し、入力値valueと比較
            string[] list = this._opts.Split(',');
            foreach (var data in list)
            {
                if (((string)value).Contains(data))
                {
                    return false;
                }
            }
            return true;
        }

        //クライアントに送信する検証情報の生成
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            //検証ルールを準備
            var rule = new ModelClientValidationRule
            {
                ValidationType = "blackword", //検証名
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()), //エラーメッセージ
            };
            rule.ValidationParameters["opts"] = _opts; //検証パラメータ
            yield return rule;

        }
    }
}