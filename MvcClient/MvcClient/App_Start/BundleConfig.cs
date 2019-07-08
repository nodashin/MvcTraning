using System.Web;
using System.Web.Optimization;

namespace MvcClient
{
    public class BundleConfig
    {
        // バンドルの詳細については、https://go.microsoft.com/fwlink/?LinkId=301862 を参照してください
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.UseCdn = true;
            //var jq = new ScriptBundle("~/bundles/jquery", "//code.jquery.com/jquery-1.11.0.min.js").Include(
            //    "~/Scripts/jquery-{version}.js");
            //jq.CdnFallbackExpression = "window.jQuery";
            //bundles.Add(jq);

            //jQueryを「~/bundles/jquery」に紐付け
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //JQueryUIの紐づけ
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                                    "~/Scripts/jquery-ui-{version}.js"));

            //JQueryUIのCSSを紐づけ
            bundles.Add(new ScriptBundle("~/Content/jqueryui").Include(
                                    "~/Content/themes/base/jquery-ui.min.css"));

            //検証関連のスクリプトを「~/bundles/jqueryval」に紐付け
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 開発と学習には、Modernizr の開発バージョンを使用します。次に、実稼働の準備が
            // 運用の準備が完了したら、https://modernizr.com のビルド ツールを使用し、必要なテストのみを選択します。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            //BootstrapのJSの紐づけ
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //BootstrapのCSSの紐づけ
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
