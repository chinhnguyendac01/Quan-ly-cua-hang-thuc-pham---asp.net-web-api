using Dapper;
using Christoc.Modules.DNNModule1.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Christoc.Modules.DNNModule1.Repository
{
    public class KhachHangRepository:ConnectDatabase,IKhachHangRepository
    {
        private readonly SqlConnection _conn;
        public KhachHangRepository()
        {
            _conn = IConnectData();
        }
        public async Task<IEnumerable<KhachHang>> Gets()
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync(); 
                    IEnumerable<KhachHang> list = conn.Query<KhachHang>("sp_KhachHang_Gets", commandType: CommandType.StoredProcedure);
                    return list;
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
        public async Task<KhachHang> GetById(int MaKh)
        {
            using(SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@makh", MaKh);
                    KhachHang list = conn.QueryFirstOrDefault<KhachHang>("sp_KhachHang_GetById", param: parameters, commandType: CommandType.StoredProcedure);
                    return list;
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
        public async Task<KhachHang> Insert(KhachHang data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    if (data != null)
                    {
                        parameters.Add("@makh", null);
                        parameters.Add("@Hoten", data.Hoten);
                        parameters.Add("@diachi", data.diachi);
                        parameters.Add("@sodt", data.sodt);
                        parameters.Add("@email", data.email);
                    }
                    KhachHang item = await SqlMapper.QueryFirstAsync<KhachHang>(conn, "sp_KhachHangSave", parameters, commandType: CommandType.StoredProcedure);
                    return item;
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
        public async Task<int> Delete(int MaKhachHang)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@makh", MaKhachHang);
                    int kq = await SqlMapper.ExecuteAsync(conn, "sp_KhachHang_Delete", parameters, commandType: CommandType.StoredProcedure);
                    bool updateResult = kq > 0;
                    return kq;
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
        public async Task<KhachHang> Update(KhachHang data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    if (data != null)
                    {
                        parameters.Add("@makh", data.makh);
                        parameters.Add("@Hoten", data.Hoten);
                        parameters.Add("@diachi", data.diachi);
                        parameters.Add("@sodt", data.sodt);
                        parameters.Add("@email", data.email);
                    }
                    KhachHang item = await SqlMapper.QueryFirstAsync<KhachHang>(conn, "sp_KhachHangSave", parameters, commandType: CommandType.StoredProcedure);
                    return item;
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
        public async Task<int> DeleteMutiple(string lstMakh)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@lstMakh", lstMakh);
                    int kq = await SqlMapper.ExecuteAsync(conn, "sp_KhachHang_DelMutiple", parameters, commandType: CommandType.StoredProcedure);
                    bool updateResult = kq > 0;
                    return kq;
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