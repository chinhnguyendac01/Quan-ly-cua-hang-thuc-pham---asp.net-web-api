using Christoc.Modules.DNNModule1.Interface;
using Christoc.Modules.DNNModule1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace Christoc.Modules.DNNModule1.Services
{
    public class LoginApiController : ApiBaseController, IRequiresSessionState
    {
        private readonly ILoginRepository _loginRepository;
        
        public LoginApiController()
        {
            _loginRepository = new LoginRepository();
            
        }
       
        [HttpPost]
        [System.Web.Http.Route("Login")]
        public async Task<HttpResponseMessage> Login([FromBody] DNNDB_NhanVien data )
        {
            try
            {
                var result = await _loginRepository.Login(data);
                
                if (result != null)
                {
                    HttpCookie cookie = new HttpCookie("authentication", data.Email);



                    // Thiết lập thời gian hết hạn của cookie
                    cookie.Expires = DateTime.Now.AddDays(1);
                    // Thiết lập giá trị cho thuộc tính "email"
                    cookie.Values["email"] = data.Email;

                    // Thiết lập giá trị cho thuộc tính "password"
                    cookie.Values["password"] = data.MatKhau;
                    cookie.Values["NhanVienID"] = result.NhanVienID.ToString();
                    cookie.Values["Name"] = result.HoTen;
                    // Thêm cookie vào trong phản hồi
                    HttpContext.Current.Response.Cookies.Add(cookie);


                    return Request.CreateResponse(HttpStatusCode.OK, result);

                }
                else
                {
                    // Đăng nhập thất bại, trả về mã lỗi và thông báo
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //
        [HttpGet]
        [System.Web.Http.Route("GetUserInfo")]
        public HttpResponseMessage GetUserInfo()
        {
            try
            {
                // Lấy cookie từ HTTP request
                HttpCookie cookie = HttpContext.Current.Request.Cookies["authentication"];

                if (cookie != null)
                {
                    // Lấy giá trị NhanVienID từ cookie
                    string nhanVienID = cookie["Name"];

                    // Trả về giá trị NhanVienID
                    return Request.CreateResponse(HttpStatusCode.OK, nhanVienID);
                }
                else
                {
                    // Không tìm thấy cookie, trả về mã lỗi và thông báo
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Bạn chưa đăng nhập.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về mã lỗi và thông báo
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}