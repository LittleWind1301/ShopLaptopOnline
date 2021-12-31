using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LastProject_v2.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Hãy nhập User Name")]
        public String UserName { set; get; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Hãy nhập password")]
        public String Password { set; get; }
        public bool RememberMe { set; get; }
    }
}