using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    public class AccountModel
    {
        private Model1 context = null;
        public AccountModel()
        {
            context = new Model1();
        }
        public bool Login(string userName, string password)
        {
            object[] sqlParam = 
            {
                new SqlParameter("@Username", userName),
                new SqlParameter("@Password",password)
            };
        
        
        var res = context.Database.SqlQuery<bool>("Sp_NhanVien_Login @Username,@Password",sqlParam).SingleOrDefault();
            return res;
        }
}
}
