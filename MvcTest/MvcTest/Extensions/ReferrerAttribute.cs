﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Extensions
{
    public class ReferrerAttribute : ActionMethodSelectorAttribute
    {

        public bool CanNull { get; private set; }

        public ReferrerAttribute(bool canNull)
        {
            this.CanNull = canNull;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            var req = controllerContext.HttpContext.Request;
            var referrer = req.UrlReferrer;
            if (referrer == null) { return CanNull; }
            var refHost = referrer.Host;
            var currentHost = req.Url.Host;
            return refHost.Equals(currentHost, StringComparison.InvariantCultureIgnoreCase);
        }

    }
}