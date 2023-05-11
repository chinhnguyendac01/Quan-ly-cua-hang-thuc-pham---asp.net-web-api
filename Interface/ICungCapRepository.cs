using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christoc.Modules.DNNModule1.Interface
{
    public interface ICungCapRepository
    {
        Task<IEnumerable<DNNDB_CungCap>> Gets();
        Task<IEnumerable<DNNDB_CungCap>> GetsByName(string TenLienHe);
        Task<DNNDB_CungCap> GetById(int CungCapId);
        Task<DNNDB_CungCap> Insert(DNNDB_CungCap data);
        Task<DNNDB_CungCap> Update(DNNDB_CungCap data);
        Task<int> Delete(int MaLoai);
        Task<int> DeleteMutiple(string lstID);
    }
}
