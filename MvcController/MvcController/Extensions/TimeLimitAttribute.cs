using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcController.Extensions
{
    public class TimeLimitAttribute : FilterAttribute, IAuthorizationFilter
    {
        private DateTime _begin = DateTime.MinValue;
        private DateTime _end = DateTime.MaxValue;

        public string Begin
        {
            set
            {
                var b = DateTime.Parse(value);
                //開始時刻が終了時刻よりも後の場合はエラー
                if(b >= this._end)
                {
                    throw new ArgumentException("Begin paramter is invalid.");
                }
                this._begin = b;
            }
        }

        public string End
        {
            set
            {
                var e = DateTime.Parse(value);
                //終了時刻が開始時刻よりも前の場合はエラー
                if(e <= this._begin)
                {
                    throw new ArgumentException("End parameter is invalid.");
                }
                this._end = e;
            }
        }

        //コンストラクター(Begin/Endプロパティを初期化)
        public TimeLimitAttribute(string begin, string end)
        {
            Begin = begin;
            End = end;
        }

        //アクションメソッド実行の最初のタイミングで呼び出されるメソッド
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //引数filterContextがnullの場合には例外を発生
            if(filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            //開始時刻<=現在時刻<=終了時刻でない場合にTimeLimitExpection例外を発生
            var current = DateTime.Now;
            if(current < this._begin || current > this._end)
            {
                var msg = string.Format("このページは{0}から{1}までの期間のみ有効です。", this._begin.ToLongDateString(), this._end.ToLongDateString());
                filterContext.Result = new ContentResult() { Content = msg };
            }
        }
    }

    //TimeLimitAttributeクラスで利用するTimeLimitException例外を定義
    public class TimeLimitExceptionn : Exception
    {
        public TimeLimitExceptionn(string message) : base(message)
        {
        }
    }
}