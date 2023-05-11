using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Christoc.Modules.DNNModule1.Controllers
{
    public class MonAnController : DnnController
    {
        // GET: MonAn
        public ActionResult Index()
        {
            return View();
        }
    }
}