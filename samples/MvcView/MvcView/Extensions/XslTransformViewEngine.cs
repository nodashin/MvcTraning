using System.Web.Mvc;

namespace MvcView.Extensions
{
  public class XslTransformViewEngine : VirtualPathProviderViewEngine
  {
    public XslTransformViewEngine()
    {
      this.ViewLocationFormats = new[] {
        "~/Views/{1}/{0}.xslt",
        "~/Views/{1}/{0}.xsl",
        "~/Views/Shared/{0}.xslt",
        "~/Views/Shared/{0}.xsl"
      };
      this.PartialViewLocationFormats = this.ViewLocationFormats;
    }

    protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
    {
      return new XslTransformView(partialPath);
    }

    protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
    {
      return new XslTransformView(viewPath);
    }
  }
}