using System;
using System.Web;
using System.Web.Routing;

namespace MvcRoute.Extensions
{
  public class TimeLimitConstraint : IRouteConstraint
  {

    private DateTime _begin = DateTime.MinValue;
    private DateTime _end = DateTime.MaxValue;

    public TimeLimitConstraint(DateTime begin, DateTime end)
    {
      if (begin >= end)
      {
        throw new ArgumentException("Invalid Argument.");
      }
      this._begin = begin;
      this._end = end;
    }

    public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
    {
      var current = DateTime.Now;
      if (current < this._begin || current > this._end)
      {
        return false;
      }
      return true;
    }
  }
}