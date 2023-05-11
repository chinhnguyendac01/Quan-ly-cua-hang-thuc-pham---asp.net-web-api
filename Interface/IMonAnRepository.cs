using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christoc.Modules.DNNModule1.Interface
{
    public interface IMonAnRepository
    {
        Task<IEnumerable<DNNDB_MonAn_LoaiMon_MediaFile>> Gets();
        Task<IEnumerable<DNNDB_MonAn_LoaiMon_MediaFile>> Sort(string SortExpr, string cateSort,int MaLoai,int MaCungCap);
       
        Task<DNNDB_MonAn_LoaiMon_MediaFile> GetById(int MaMon);
        Task<int> Delete(int MaMon);
        Task<DNNDB_MonAn_LoaiMon_MediaFile> Insert(DNNDB_MonAn_LoaiMon_MediaFile data);
        Task<DNNDB_MonAn_LoaiMon_MediaFile> Update(DNNDB_MonAn_LoaiMon_MediaFile data);      
        Task<int> DeleteMutiple(string lstMaMon);
        Task<DNNDB_MonAn_LoaiMon_MediaFile> InsertFile(DNNDB_MonAn_LoaiMon_MediaFile data);
        Task<DNNDB_MonAn_LoaiMon_MediaFile> GetByIdFile(string path);
        Task<DNNDB_MonAn_LoaiMon_MediaFile> UpdateFile(DNNDB_MonAn_LoaiMon_MediaFile data);
    }
}
