using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Response;

namespace Web.Core.IModule
{
    public interface IElfService
    {
        List<CodeListItem> Get(string key);
    }
}
