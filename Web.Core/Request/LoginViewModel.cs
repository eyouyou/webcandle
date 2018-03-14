using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Core.Request
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [Display(Name ="账号")]
        public string Account { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "账号")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="记住我")]
        public bool IsRememberme { get; set; }
        [Display(Name = "游客登录")]
        public bool IsGuest { get; set; }

        public Hevo.Core.UserInfo ToUserInfo()
        {
            return new Hevo.Core.UserInfo(Account, Password, IsRememberme, IsGuest, false);
        }
    }
}