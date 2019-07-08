using System;
using System.Collections.Generic;
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
            //Route属性経由で渡された引数地を「,」で分解
            _elems = elems.Split(',');
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object elem;

            //パラメータ名({名前:制約(...)}の名前の部分)をキーに値を取得
            if(values.TryGetValue(parameterName, out elem))
            {
                //候補値の中にパラメーター地が含まれていれば、ルートは有効
                return this._elems.Contains(elem);
            }
            //さもなければルートは無効
            return false;
        }
    }
}