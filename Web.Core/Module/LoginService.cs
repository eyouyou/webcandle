using Hevo.CoreEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Request;
using Web.Core.IModule;
using System.ComponentModel.Composition;
namespace Web.Core.Module
{
    [Export(typeof(ILoginService))]
    public class LoginService: ILoginService
    {
        public bool Login(LoginViewModel model)
        {
            var userinfo = model.ToUserInfo();
            var issuccess = false;
            //var tc = new WebCoreCLR.TestCLR();
            //tc.Foobar("Hello");
            //DataService.Current.Start(userinfo, (success, Code, message, Is_cancel_proxy) =>
            //{
            //    if (success)
            //    {
            //        issuccess = true;
            //    }
            //});
            issuccess = true;
            System.Threading.Thread.Sleep(2000);
            return issuccess;
        }
    }
}
