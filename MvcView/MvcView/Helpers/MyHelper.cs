using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;

namespace MvcView.Helpers
{
    public static class MyHelper
    {
        public static IHtmlString MailTo(string address, string linkText)
        {
            return MvcHtmlString.Create(
                string.Format("<a herf=\"mailto:{0}\">{1}</a>",
                HttpUtility.HtmlAttributeEncode(address),
                HttpUtility.HtmlAttributeEncode(linkText)));
        }

        public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            return MvcHtmlString.Create(
                string.Format("<img src=\"{0}\" alt=\"{1}\" />",
                HttpUtility.HtmlAttributeEncode(UrlHelper.GenerateContentUrl(src, helper.ViewContext.HttpContext)),
                HttpUtility.HtmlAttributeEncode(alt)));
        }

        public static IHtmlString Video(this HtmlHelper helper, string src, object htmlAttrs)
        {
            //<Video>要素を生成
            var bilder = new TagBuilder("video");
            //src, controls属性を追加
            bilder.MergeAttribute("src", UrlHelper.GenerateContentUrl(src, helper.ViewContext.HttpContext));
            bilder.MergeAttribute("controls", "controls");
            //その他の属性(引数htmlAttrs)を追加
            bilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttrs));
            //以上の設定に基づいて、<video>要素を出力
            return MvcHtmlString.Create(bilder.ToString(TagRenderMode.Normal));
        }

        public static IHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, 
                                                                        Expression<Func<TModel, TProperty>> exp,
                                                                        IEnumerable<SelectListItem> list,
                                                                        object htmlAttrs)
        {
            //タグ文字列を保存するためのStringBilder
            var sb = new StringBuilder();

            //ラムダ式expからプロパティ名／値を取得
            var name = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(exp));
            var value = ModelMetadata.FromLambdaExpression(exp, helper.ViewData).Model.ToString();

            int i = 1;
            foreach (var item in list)
            {
                //<プロパティ名>_<連番>の形式でid値を生成
                var id = string.Format("{0}_{1}", name, i++);

                //<label>要素を生成
                var label = new TagBuilder("label");
                label.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttrs));
                //RudioButtonメソッドで生成した<Input type="radio">要素を<label>要素に追加
                //モデルの現在値とラジオボタンの値とが等しい場合は、chekced要素を付与
                label.InnerHtml = helper.RadioButton(name, item.Value, (item.Value == value), new { id = id }).ToString();

                //SelectListオブジェクトのテキスト値を<label>配下に追加
                label.InnerHtml += item.Text;
                //<label>要素をStringBuilderに追加
                sb.Append(label.ToString(TagRenderMode.Normal));
            }

            //StringBuilder型をIHtmlString型に変換したものを返す。
            return MvcHtmlString.Create(sb.ToString());
        }

        public static IHtmlString TemplateMessage(this HtmlHelper helper, Func<string, HelperResult>template, string message)
        {
            return template(message);
        }
    }
}