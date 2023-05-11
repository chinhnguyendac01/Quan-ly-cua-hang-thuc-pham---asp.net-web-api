using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace Christoc.Modules.DNNModule1.Interface
{
    public interface ILoginRepository
    {
       Task<DNNDB_NhanVien> Login(DNNDB_NhanVien data);
    }
}