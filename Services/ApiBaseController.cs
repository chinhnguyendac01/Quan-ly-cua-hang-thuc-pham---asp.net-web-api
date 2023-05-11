using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Api;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Christoc.Modules.DNNModule1.Services
{
   [AllowAnonymous]
    public class ApiBaseController : DnnApiController
    {
        [AcceptVerbs("GET","POST")]
        public HttpResponseMessage KeepAlive()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "True");
            }
            catch (Exception ex)
            {
                //Log to DotNetNuke and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        

    }
}