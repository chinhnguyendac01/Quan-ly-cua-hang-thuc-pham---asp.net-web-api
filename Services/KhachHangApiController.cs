using Christoc.Modules.DNNModule1.Interface;
using Christoc.Modules.DNNModule1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Christoc.Modules.DNNModule1.Services
{
    [System.Web.Http.AllowAnonymous]
    public class KhachHangApiController : ApiBaseController
    {
        private readonly IKhachHangRepository _khachhangRepository;
        public KhachHangApiController()
        {
            _khachhangRepository = new KhachHangRepository();
        }

        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> Gets()
        {
            try
            {
                IEnumerable<KhachHang> lst = null;
                lst = await _khachhangRepository.Gets();
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetById/{MaKh}")]
        public async Task<HttpResponseMessage> GetById(int MaKh)
        {
            try
            {
                KhachHang lst = null;
                lst = await _khachhangRepository.GetById(MaKh);
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Insert")]
        public HttpResponseMessage Insert(KhachHang data)
        {
            try
            {
                _khachhangRepository.Insert(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm mới thành công!", "application/json");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm mới thất bại:" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("Delete/{makh}")]
        public HttpResponseMessage Delete(int makh)
        {
            try
            {
                _khachhangRepository.Delete(makh);
                return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa Lỗi :" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Update")]
        public HttpResponseMessage Update(KhachHang data)
        {
            try
            {
                _khachhangRepository.Update(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Cập nhật Thể loại thành công!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cập nhật Thể loại thất bại:" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("DeleteMutiple/{lstID}")]
        public HttpResponseMessage DeleteMutiple(string lstMakh)
        {
            try
            {
                _khachhangRepository.DeleteMutiple(lstMakh);
                return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa Lỗi :" + ex.Message, "application/json");
            }
        }
    }
}