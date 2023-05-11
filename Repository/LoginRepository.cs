using Christoc.Modules.DNNModule1.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Christoc.Modules.DNNModule1.Repository
{
    public class LoginRepository : ConnectDatabase, ILoginRepository
    {
        private readonly SqlConnection _conn;
        public LoginRepository()
        {
            _conn = IConnectData();
        }
       
        public async Task<DNNDB_NhanVien> Login(DNNDB_NhanVien data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@username", data.Email);
                    parameters.Add("@password", data.MatKhau);

                    DNNDB_NhanVien nhanvien = await conn.QueryFirstOrDefaultAsync<DNNDB_NhanVien>("sp_CheckLogin", param: parameters, commandType: CommandType.StoredProcedure);
                    return nhanvien;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}