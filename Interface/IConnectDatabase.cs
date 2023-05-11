using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Christoc.Modules.DNNModule1.Interface
{
   
        public interface IConnectDatabase
        {
            SqlConnection IConnectData();
        }
    
}
