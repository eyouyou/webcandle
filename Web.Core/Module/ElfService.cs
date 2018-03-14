using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Web.Core.IModule;
using Web.Core.Response;

namespace Web.Core.Module
{
    [Export(typeof(IElfService))]
    public class ElfService : IElfService
    {
        
        public List<CodeListItem> Get(string key)
        {
            return new List<CodeListItem>();
        }
    }
}
