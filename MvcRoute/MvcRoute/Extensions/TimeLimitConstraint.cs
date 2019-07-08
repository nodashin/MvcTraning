using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MvcRoute.Extensions
{

    //制約条件は、IRouteConstraintインタフェースを実装
    public class TimeLimitConstraint : IRouteConstraint
    {
        //時間範囲の開始／終了を表すプライベート変数
        private DateTime _begin = DateTime.MinValue;
        private DateTime _end = DateTime.MaxValue;

        //コンストラクター(時間範囲を初期化)
        public TimeLimitConstraint(DateTime begin, DateTime end)
        {
            //開始時間が終了時間以降である場合は例外
            if(begin > end)
            {
                throw new ArgumentException("Invalid Argument.");
            }

            _begin = begin;
            _end = end;
        }

        //ルートを適用するかどうかを判定するMatchメソッド
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var current = DateTime.Now;
            //現在時刻が有効範囲外(開始時刻より前、終了時刻より後)の場合はtrue
            if(current < this._begin || current > this._end)
            {
                return true;
            }
            return false;
        }
    }
}