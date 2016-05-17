using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var filter=filterContext.Filters.Where(t => t.GetType() == typeof(ResponseCacheFilter)).FirstOrDefault();
            if (filter != null)
            {
                ResponseCacheFilter f = (ResponseCacheFilter)filter;
                f.NoStore = true;
                //f.Duration = 0;
            }
            else
            {
                //Not allowed
                //filterContext.Filters.Add(new ResponseCacheAttribute() { NoStore=true} );
            }
            //For older MVC
            //Microsoft.AspNet.Mvc.ResponseCacheAttribute()
            //filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            //filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            //filterContext.HttpContext.Response.Cache.SetRevalidation(System.Web.HttpCacheRevalidation.AllCaches);
            //filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //filterContext.HttpContext.Response.Cache.SetNoStore();

            base.OnResultExecuting(filterContext);
        }
    }
}
