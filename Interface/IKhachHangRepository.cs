using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christoc.Modules.DNNModule1.Interface
{
    public interface IKhachHangRepository
    {
        Task<IEnumerable<KhachHang>> Gets();
        Task<KhachHang> GetById(int MaKh);
        Task<KhachHang> Insert(KhachHang data);
        Task<int> Delete(int MaKhanGia);
        Task<KhachHang> Update(KhachHang data);
        Task<int> DeleteMutiple(string lstMakh);

    }
}
