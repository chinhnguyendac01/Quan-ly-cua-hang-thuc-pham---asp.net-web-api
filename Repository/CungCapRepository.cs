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
    public class CungCapRepository:ConnectDatabase,ICungCapRepository
    {
        private readonly SqlConnection _conn;
        public CungCapRepository()
        {
            _conn = IConnectData();
        }
        //Gets
        public async Task<IEnumerable<DNNDB_CungCap>> Gets()
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    IEnumerable<DNNDB_CungCap> list = conn.Query<DNNDB_CungCap>("sp_CungCap_Gets", commandType: CommandType.StoredProcedure);
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
        //GetByName
        public async Task<IEnumerable<DNNDB_CungCap>> GetsByName(string TenLienHe)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@TenLienHe", TenLienHe);
                    IEnumerable<DNNDB_CungCap> list = conn.Query<DNNDB_CungCap>("sp_CungCap_GetsByName", param: parameters, commandType: CommandType.StoredProcedure);
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
        //GetByName
        public async Task<DNNDB_CungCap> GetById(int CungCapId)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CungCapID", CungCapId);
                    DNNDB_CungCap list = conn.QueryFirstOrDefault<DNNDB_CungCap>("sp_CungCap_GetById", param: parameters, commandType: CommandType.StoredProcedure);
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
        //Insert
        public async Task<DNNDB_CungCap> Insert(DNNDB_CungCap data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    if (data != null)
                    {
                        parameters.Add("@CungCapID", null);
                        parameters.Add("@TenLienHe", data.TenLienHe);
                        parameters.Add("@DiaChi", data.DiaChi);
                        parameters.Add("@MaBuudien", data.MaBuudien);
                        parameters.Add("@Quocgia", data.Quocgia);
                        parameters.Add("@DienThoai", data.DienThoai);

                    }
                    DNNDB_CungCap item = await SqlMapper.QueryFirstAsync<DNNDB_CungCap>(conn, "sp_CungCap_Save", parameters, commandType: CommandType.StoredProcedure);
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
        //Update
        public async Task<DNNDB_CungCap> Update(DNNDB_CungCap data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    if (data != null)
                    {
                        parameters.Add("@CungCapID", data.CungCapID);
                        parameters.Add("@TenLienHe", data.TenLienHe);
                        parameters.Add("@DiaChi", data.DiaChi);
                        parameters.Add("@MaBuuDien", data.MaBuudien);
                        parameters.Add("@QuocGia", data.Quocgia);
                        parameters.Add("@DienThoai", data.DienThoai);

                    }
                    DNNDB_CungCap item = await SqlMapper.QueryFirstAsync<DNNDB_CungCap>(conn, "sp_CungCap_Save", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<int> DeleteMutiple(string lstCungCap)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@lstCungCap", lstCungCap);
                    int kq = await SqlMapper.ExecuteAsync(conn, "sp_CungCap_DelMutiple", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<int> Delete(int CungCapID)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CungCapID", CungCapID);
                    int kq = await SqlMapper.ExecuteAsync(conn, "sp_CungCap_Delete", parameters, commandType: CommandType.StoredProcedure);
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