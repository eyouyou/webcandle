using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Request;

namespace Web.Core.IModule
{
    
    public interface ILoginService
    {
        bool Login(LoginViewModel model);
    }
}
