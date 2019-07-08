using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace MvcController.Extensions
{
    public class TranslagedXmlResult : ActionResult
    {
        private XslCompiledTransform _xlst;

        //変換対象のXML文書(XDocumentオブジェクト)
        public XDocument Document { get; private set; }

        //コンストラクター(XDocumentプロパティを初期化)
        public TranslagedXmlResult(XDocument doc)
        {
            this.Document = doc;
        }

        //アクション結果の処理方法を定義
        public override void ExecuteResult(ControllerContext context)
        {
            //コントローラー名／アクション名からスタイルシートのパスを生成
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            var path = string.Format("~/Views/{0}/{1}.xslt", controller, action);

            //XSLT変換のためXslCompiledTransformオブジェクトを生成
            _xlst = new XslCompiledTransform();
            //変換に使用するスタイルシートをセット
            _xlst.Load(context.HttpContext.Server.MapPath(path));
            //変換を実行&実行結果はクライアントに直接出力
            _xlst.Transform(Document.CreateReader(), null, context.HttpContext.Response.OutputStream);
        }
    }
}