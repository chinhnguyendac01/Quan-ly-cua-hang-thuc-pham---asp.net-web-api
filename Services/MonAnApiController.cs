using Christoc.Modules.DNNModule1.Interface;
using Christoc.Modules.DNNModule1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Christoc.Modules.DNNModule1.Services
{
    [System.Web.Http.AllowAnonymous]
    public class MonAnApiController : ApiController
    {
        private readonly IMonAnRepository _MonAnRepository;
        public MonAnApiController()
        {
            _MonAnRepository = new MonAnRepository();
        }
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> Gets()
        {
            try
            {
                IEnumerable<DNNDB_MonAn_LoaiMon_MediaFile> lst = null;
                lst = await _MonAnRepository.Gets();
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpGet]
        [Route("Sort/{SortExpr}/{SortDir}/{MaLoai}/{CungCap}")]
        public async Task<HttpResponseMessage> Sort(string SortExpr,string SortDir,int MaLoai,int CungCap)
        {
            try
            {
                IEnumerable<DNNDB_MonAn_LoaiMon_MediaFile> lst = null;
                lst = await _MonAnRepository.Sort(SortExpr, SortDir,MaLoai,CungCap);
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
       
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetById/{MaMonAn}")]
        public async Task<HttpResponseMessage> GetById(int MaMonAn)
        {
            try
            {
                DNNDB_MonAn_LoaiMon_MediaFile lst = null;
                lst = await _MonAnRepository.GetById(MaMonAn);
                return Request.CreateResponse(HttpStatusCode.OK, lst, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("Delete/{MaMonAn}")]
        public HttpResponseMessage Delete(int MaMonAn)
        {
            try
            {
                _MonAnRepository.Delete(MaMonAn);
                return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa Lỗi :" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Insert(DNNDB_MonAn_LoaiMon_MediaFile data)
        {
            try
            {
                _MonAnRepository.Insert(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm mới thành công!", "application/json");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm mới thất bại:" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Update(DNNDB_MonAn_LoaiMon_MediaFile data)
        {
            try
            {
                _MonAnRepository.Update(data);
                return Request.CreateResponse(HttpStatusCode.OK, data, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cập nhật Thể loại thất bại:" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("DeleteMutiple/{lstMaMon}")]
        public HttpResponseMessage DeleteMutiple(string lstMaMon)
        {
            try
            {
                _MonAnRepository.DeleteMutiple(lstMaMon);
                return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage InsertFile(DNNDB_MonAn_LoaiMon_MediaFile data)
        {
            try
            {
                 _MonAnRepository.InsertFile(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm mới thành công!", "application/json");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm mới thất bại:" + ex.Message, "application/json");
            }

        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetByIdFile/{path}")]
        public async Task<HttpResponseMessage> GetByIdFile(string path)
        {
            try
            {
                DNNDB_MonAn_LoaiMon_MediaFile lst = null;
                lst = await _MonAnRepository.GetByIdFile(path);
                return Request.CreateResponse(HttpStatusCode.OK, lst.FileID, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }
        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage UpdateFile(DNNDB_MonAn_LoaiMon_MediaFile data)
        {
            try
            {
                _MonAnRepository.UpdateFile(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Cập nhật Thể loại thành công!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cập nhật Thể loại thất bại:" + ex.Message, "application/json");
            }

        }
    }
    
}