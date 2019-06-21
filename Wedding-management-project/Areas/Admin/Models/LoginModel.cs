using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wedding_management_project.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bạn cần nhập Username")]
        [Display(Name = "Username")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập Password")]
        [Display(Name = "Password")]
        public string Password { set; get; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { set; get; }
       
    }
}