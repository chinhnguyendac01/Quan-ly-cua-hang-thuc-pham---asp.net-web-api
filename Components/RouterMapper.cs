using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.DNNModule1.Components
{
    public class RouterMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
            "DNNModule1",
            "default",
            "{controller}/{action}",
            new[] { "Christoc.Modules.DNNModule1.Services" });
        }
    }
}