using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace MvcView.Extensions
{
    public class XslTransformView : IView
    {
        private string _viewPath;

        //コンストラクター(ビュースクリプトのパスを初期化)
        public XslTransformView(string viewPath)
        {
            _viewPath = viewPath;
        }

        //実際にビューを描画するための機能を実装
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            //モデルとしてXDocumentオブジェクトを取得
            var doc = (XDocument)viewContext.ViewData.Model;
            //XSLT変換のためのXslCompiledTransformオブジェクトを生成
            var xsl = new XslCompiledTransform();
            //変換に使用するスタイルシートをセット
            xsl.Load(viewContext.HttpContext.Server.MapPath(this._viewPath));
            //ビュー変数からスタイルシートに引き渡すパラメータ情報を取得&セット
            var args = new XsltArgumentList();
            foreach (var data in viewContext.ViewData)
            {
                args.AddParam(data.Key, "", data.Value);
            }
            //変換を実行&実行結果はクライアントに直接出力
            xsl.Transform(doc.CreateReader(), args, writer);
        }
    }
}