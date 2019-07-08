using System;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace MvcView.Extensions
{
  public class XslTransformView : IView
  {
    private String _viewPath;

    public XslTransformView(String viewPath)
    {
      this._viewPath = viewPath;
    }

    public void Render(ViewContext viewContext, System.IO.TextWriter writer)
    {
      var doc = (XDocument)viewContext.ViewData.Model;
      var xsl = new XslCompiledTransform();
      xsl.Load(viewContext.HttpContext.Server.MapPath(this._viewPath));
      var args = new XsltArgumentList();
      foreach (var data in viewContext.ViewData)
      {
        args.AddParam(data.Key, "", data.Value);
      }
      xsl.Transform(doc.CreateReader(), args, writer);
    }
  }
}