using Christoc.Modules.DNNModule1.Interface;
using Christoc.Modules.DNNModule1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Christoc.Modules.DNNModule1.Services
{
    [System.Web.Http.AllowAnonymous]
    public class CungCapApiController : ApiBaseController
    {
        private readonly ICungCapRepository _cungcapRepository;
        public CungCapApiController()
        {
            _cungcapRepository = new CungCapRepository();
        }
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> Gets()
        {
            try
            {
                IEnumerable<DNNDB_CungCap> lst = null;
                lst = await _cungcapRepository.Gets();
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetsByName/{TenLienHe}")]
        public async Task<HttpResponseMessage> GetsByName(string TenLienHe)
        {
            try
            {
                IEnumerable<DNNDB_CungCap> lst = null;
                lst = await _cungcapRepository.GetsByName(TenLienHe);
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetById/{CungCapId}")]
        public async Task<HttpResponseMessage> GetById(int CungCapId)
        {
            try
            {
                DNNDB_CungCap lst = null;
                lst = await _cungcapRepository.GetById(CungCapId);
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Insert(DNNDB_CungCap data)
        {
            try
            {
                _cungcapRepository.Insert(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm mới thành công!", "application/json");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm mới thất bại:" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(DNNDB_CungCap data)
        {
            try
            {
                _cungcapRepository.Update(data);
                return Request.CreateResponse(HttpStatusCode.OK, "cap nhat loai mon thanh cong", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cập nhật Thể loại thất bại:" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("DeleteMutiple/{lstCungCap}")]
        public HttpResponseMessage DeleteMutiple(string lstCungCap)
        {
            try
            {
                _cungcapRepository.DeleteMutiple(lstCungCap);
                return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("Delete/{CungCapId}")]
        public HttpResponseMessage Delete(int CungCapId)
        {
            try
            {
                _cungcapRepository.Delete(CungCapId);
                return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa Lỗi :" + ex.Message, "application/json");
            }

        }
    }
}