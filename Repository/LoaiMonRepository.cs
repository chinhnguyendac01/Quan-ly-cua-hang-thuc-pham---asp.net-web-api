using Christoc.Modules.DNNModule1.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Christoc.Modules.DNNModule1.Repository
{
    public class LoaiMonRepository : ConnectDatabase,ILoaiMonRepository
    {
        private readonly SqlConnection _conn;
        public LoaiMonRepository()
        {
            _conn = IConnectData();
        }
        //Gets
        public async Task<IEnumerable<DNNDB_LoaiMon>> Gets()
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    IEnumerable<DNNDB_LoaiMon> list = conn.Query<DNNDB_LoaiMon>("sp_LoaiMon_Gets", commandType: CommandType.StoredProcedure);
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
        public async Task<IEnumerable<DNNDB_LoaiMon>> GetsByName(string TenLoai)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@TenLoai", TenLoai);
                    IEnumerable<DNNDB_LoaiMon> list = conn.Query<DNNDB_LoaiMon>("sp_LoaiMon_GetsByName", param: parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<DNNDB_LoaiMon> GetById(int MaLoai)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@MaLoai", MaLoai);
                    DNNDB_LoaiMon list = conn.QueryFirstOrDefault<DNNDB_LoaiMon>("sp_LoaiMon_GetById", param: parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<DNNDB_LoaiMon> Insert(DNNDB_LoaiMon data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    if (data != null)
                    {
                        parameters.Add("@MaLoai", null);
                        parameters.Add("@TenLoai", data.tenloai);
                      
                    }
                    DNNDB_LoaiMon item = await SqlMapper.QueryFirstAsync<DNNDB_LoaiMon>(conn, "sp_LoaiMon_Save", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<DNNDB_LoaiMon> Update(DNNDB_LoaiMon data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    if (data != null)
                    {
                        parameters.Add("@MaLoai", data.maloai);
                        parameters.Add("@TenLoai", data.tenloai);
                       
                    }
                    DNNDB_LoaiMon item = await SqlMapper.QueryFirstAsync<DNNDB_LoaiMon>(conn, "sp_LoaiMon_Save", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<int> DeleteMutiple(string lstMaLoai)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@lstMaLoai", lstMaLoai);
                    int kq = await SqlMapper.ExecuteAsync(conn, "sp_LoaiMon_DelMutiple", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<int> Delete(int MaLoai)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@MaLoai", MaLoai);
                    int kq = await SqlMapper.ExecuteAsync(conn, "sp_LoaiMon_Delete", parameters, commandType: CommandType.StoredProcedure);
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