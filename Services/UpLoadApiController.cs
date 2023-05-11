using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Christoc.Modules.DNNModule1.Services
{
    [System.Web.Http.AllowAnonymous]
    public class UpLoadApiController : ApiController
    {
        [HttpPost]
        public List<Object> UploadFiles(string pathFolder, string pathThuMuc)
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            //string[] path = new string[files.Count];
            List<Object> filesUrls = new List<Object>();
            for (var i = 0; i < files.Count; i++)
            {
                try
                {
                    HttpPostedFile file = files[i];
                    var savePath = HttpContext.Current.Server.MapPath(pathFolder);// files folder
                    if (!Directory.Exists(savePath))
                        Directory.CreateDirectory(savePath);
                    string time = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    string _filename = time + "_" + Path.GetFileName(file.FileName);//time + files name
                    string _path = Path.Combine(savePath, _filename);// physical path
                    file.SaveAs(_path);
                    Uri baseuri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
                    var thuMuc = pathThuMuc;
                    var fileBase = $"{thuMuc}/{_filename}";
                    filesUrls.Add(new
                    {
                        url = fileBase,
                        fileName = _filename
                    });
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            return filesUrls;
        }
    }
}