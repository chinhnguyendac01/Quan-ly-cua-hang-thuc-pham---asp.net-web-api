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
    public class LoaiMonApiController : ApiBaseController
    {
        private readonly ILoaiMonRepository _loaimonRepository;
        public LoaiMonApiController()
        {
            _loaimonRepository = new LoaiMonRepository();
        }

        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> Gets()
        {
            try
            {
                IEnumerable<DNNDB_LoaiMon> lst = null;
                lst = await _loaimonRepository.Gets();
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetsByName/{TenLoai}")]
        public async Task<HttpResponseMessage> GetsByName(string TenLoai)
        {
            try
            {
                IEnumerable<DNNDB_LoaiMon> lst = null;
                lst = await _loaimonRepository.GetsByName(TenLoai);
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetById/{MaLoai}")]
        public async Task<HttpResponseMessage> GetById(int MaLoai)
        {
            try
            {
                DNNDB_LoaiMon lst = null;
                lst = await _loaimonRepository.GetById(MaLoai);
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Insert(DNNDB_LoaiMon data)
        {
            try
            {
                _loaimonRepository.Insert(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm mới thành công!", "application/json");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm mới thất bại:" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(DNNDB_LoaiMon data)
        {
            try
            {
                _loaimonRepository.Update(data);
                return Request.CreateResponse(HttpStatusCode.OK,"cap nhat loai mon thanh cong", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cập nhật Thể loại thất bại:" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("DeleteMutiple/{lstMaLoai}")]
        public HttpResponseMessage DeleteMutiple(string lstMaLoai)
        {
            try
            {
                _loaimonRepository.DeleteMutiple(lstMaLoai);
                return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("Delete/{MaLoai}")]
        public HttpResponseMessage Delete(int MaLoai)
        {
            try
            {
                _loaimonRepository.Delete(MaLoai);
                return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa Lỗi :" + ex.Message, "application/json");
            }

        }
    }
}