using Christoc.Modules.DNNModule1.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Christoc.Modules.DNNModule1.Repository
{
    
        public class ConnectDatabase : IConnectDatabase
        {
            public SqlConnection IConnectData()
            {
                try
                {
                    var conn = new SqlConnection
                    {
                        ConnectionString = @"Data Source=LAPTOP-A3HHI742\SQLEXPRESS;Initial Catalog=dnn;User ID=sa; Password=123456"
                    };

                    return conn;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        

    }
     public class test: ConnectDatabase
    {
        static void Main(string[] args)
        {
            ConnectDatabase a = new ConnectDatabase();
            
            Console.Write(a.IConnectData());
        }
    }
}