using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Core.Response;
using Web.Core.IModule;

namespace Web.Portal.Controllers
{
    [Export]
    [Authorize]
    public class ElfController : Controller
    {
        [Import]
        public IElfService ElfService { get; set; }

        // GET: Elf
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public CodeListViewModel Index(string key)
        {
            var ViewModel = new CodeListViewModel();
            ViewModel.items = ElfService.Get(key);
            return ViewModel;
        }
    }
}