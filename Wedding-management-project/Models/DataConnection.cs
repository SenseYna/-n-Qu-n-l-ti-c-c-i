using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wedding_management_project.Models
{
    public class DataConnection
    {
        string strCon;
        public DataConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["QuanLiTiecCuoiConnectionString"].ConnectionString;
        }

        public IEnumerable<object> Categories { get; internal set; }

        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}