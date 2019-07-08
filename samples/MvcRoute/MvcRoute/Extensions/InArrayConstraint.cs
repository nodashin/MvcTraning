using System.Linq;
using System.Web;
using System.Web.Routing;


namespace MvcRoute.Extensions
{
    public class InArrayConstraint :IRouteConstraint
  {
    private string[] _elems = null;
    public InArrayConstraint(string elems)
    {
      this._elems = elems.Split(',');
    }

    public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
    {
      object elem;
      if(values.TryGetValue(parameterName, out elem))
      {
        return this._elems.Contains(elem);
      }
      return false;
    }
  }
}
