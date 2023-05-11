using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christoc.Modules.DNNModule1.Interface
{
     public interface ILoaiMonRepository
    {
        Task<IEnumerable<DNNDB_LoaiMon>> Gets();       
       Task<IEnumerable<DNNDB_LoaiMon>> GetsByName(string TenLoai);
        Task<DNNDB_LoaiMon> GetById(int MaLoai);
        Task<DNNDB_LoaiMon> Insert(DNNDB_LoaiMon data);
        Task<DNNDB_LoaiMon> Update(DNNDB_LoaiMon data);
        Task<int> Delete(int MaLoai);
        Task<int> DeleteMutiple(string lstID);
    }
}
