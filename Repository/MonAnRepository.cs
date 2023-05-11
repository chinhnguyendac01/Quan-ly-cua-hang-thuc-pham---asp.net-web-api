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
    public class MonAnRepository:ConnectDatabase,IMonAnRepository
    {
        private readonly SqlConnection _conn;
        public MonAnRepository()
        {
            _conn = IConnectData();
        }
        //Gets
        public async Task<IEnumerable<DNNDB_MonAn_LoaiMon_MediaFile>> Gets()
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    IEnumerable<DNNDB_MonAn_LoaiMon_MediaFile> list = conn.Query<DNNDB_MonAn_LoaiMon_MediaFile>("sp_MonAn_Gets", commandType: CommandType.StoredProcedure);
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
        //SortDate
        public async Task<IEnumerable<DNNDB_MonAn_LoaiMon_MediaFile>> Sort(string SortExpr, string SortDir,int MaLoai,int CungCap)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    IEnumerable<DNNDB_MonAn_LoaiMon_MediaFile> list = null;
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SortExpr", SortExpr);
                    parameters.Add("@SortDir", SortDir);
                    parameters.Add("@MaLoai", MaLoai);
                    parameters.Add("@CungCap", CungCap);
                    list = conn.Query<DNNDB_MonAn_LoaiMon_MediaFile>("sp_MonAn_Gets_Sort", param: parameters, commandType: CommandType.StoredProcedure);
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
        
        public async Task<DNNDB_MonAn_LoaiMon_MediaFile> GetById(int MaMon)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@MaMonAn", MaMon);
                    DNNDB_MonAn_LoaiMon_MediaFile list = conn.QueryFirstOrDefault<DNNDB_MonAn_LoaiMon_MediaFile>("sp_MonAn_GetById", param: parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<int> Delete(int MaMonAn)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@MaMonAn", MaMonAn);
                    int kq = await SqlMapper.ExecuteAsync(conn, "sp_MonAn_Delete", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<DNNDB_MonAn_LoaiMon_MediaFile> Insert(DNNDB_MonAn_LoaiMon_MediaFile data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    if (data != null)
                    {
                        parameters.Add("@MaMon", null);
                        parameters.Add("@MaLoai", data.maloai);
                        parameters.Add("@MaAnh", data.MaAnh);
                        parameters.Add("@SoLuong", data.soluong);
                        parameters.Add("@TenMon", data.tenmon);
                        parameters.Add("@Gia", data.gia);
                        parameters.Add("@ThanhPhan", data.thanhphan);
                        parameters.Add("@IDCungcap", data.IDCungcap);
                        parameters.Add("@NgayNhap");
                        
                    }   
                   DNNDB_MonAn_LoaiMon_MediaFile item = await SqlMapper.QueryFirstAsync<DNNDB_MonAn_LoaiMon_MediaFile>(conn, "sp_MonAn_Save", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<DNNDB_MonAn_LoaiMon_MediaFile> Update(DNNDB_MonAn_LoaiMon_MediaFile data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    if (data != null)
                    {
                        parameters.Add("@MaMon", data.mamon);
                        parameters.Add("@TenMon", data.tenmon);
                        parameters.Add("@MaLoai", data.maloai);
                        parameters.Add("@SoLuong", data.soluong);
                        parameters.Add("@Gia", data.gia);
                        parameters.Add("@ThanhPhan", data.thanhphan);
                        parameters.Add("@MaAnh", data.MaAnh);
                        parameters.Add("@IDCungcap", data.IDCungcap);
                    }
                    DNNDB_MonAn_LoaiMon_MediaFile item = await SqlMapper.QueryFirstAsync<DNNDB_MonAn_LoaiMon_MediaFile>(conn, "sp_MonAn_Update", parameters, commandType: CommandType.StoredProcedure);
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
       
        public async Task<int> DeleteMutiple(string lstMaMon)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@lstMaMon", lstMaMon);
                    int kq = await SqlMapper.ExecuteAsync(conn, "sp_MonAn_DelMutiple", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<DNNDB_MonAn_LoaiMon_MediaFile> InsertFile(DNNDB_MonAn_LoaiMon_MediaFile data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    if (data != null)
                    {
                        parameters.Add("@FileID", null);
                        parameters.Add("@Path", data.Path);
                        parameters.Add("@Title", data.Title);

                    }
                    DNNDB_MonAn_LoaiMon_MediaFile item = await SqlMapper.QueryFirstAsync<DNNDB_MonAn_LoaiMon_MediaFile>(conn, "sp_MediaFilesSave", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<DNNDB_MonAn_LoaiMon_MediaFile> GetByIdFile(string path)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Path", path);
                    DNNDB_MonAn_LoaiMon_MediaFile list = conn.QueryFirstOrDefault<DNNDB_MonAn_LoaiMon_MediaFile>("sp_MediaFiles_GetByIdFile", param: parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<DNNDB_MonAn_LoaiMon_MediaFile> UpdateFile(DNNDB_MonAn_LoaiMon_MediaFile data)
        {
            using (SqlConnection conn = IConnectData())
            {
                try
                {
                    await conn.OpenAsync();
                    DynamicParameters parameters = new DynamicParameters();
                    if (data != null)
                    {
                        parameters.Add("@FileID", data.FileID);
                        parameters.Add("@Title", data.Title);
                        parameters.Add("@Path", data.Path);

                    }
                    DNNDB_MonAn_LoaiMon_MediaFile item = await SqlMapper.QueryFirstAsync<DNNDB_MonAn_LoaiMon_MediaFile>(conn, "sp_MediaFilesSave", parameters, commandType: CommandType.StoredProcedure);
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
    }
}