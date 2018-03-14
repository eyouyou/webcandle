using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Core.Module;
using Web.Core.Request;
using System.Web.Security;
using Web.Core.IModule;
using System.ComponentModel.Composition;

namespace Web.Portal.Controllers
{
    [Export]
    public class LoginController : Controller
    {
        [Import]
        public ILoginService LoginService { get; set; }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel item)
        {
            if (ModelState.IsValid)
            {
                if (LoginService.Login(item))
                {
                    SetCookie(item.Account, false);
                }
            }
            return new RedirectResult("~/");
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return new RedirectResult("~/Login");
        }
        /// <summary>
        /// 设置cookie core取消system.web
        /// </summary>
        /// <param name="account"></param>
        /// <param name="rememberMe"></param>
        private void SetCookie(string account,bool rememberMe)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, account, DateTime.Now, DateTime.Now.AddDays(2), rememberMe, string.Empty);
            string encrpyTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrpyTicket);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;

            if (rememberMe)
                cookie.Expires = DateTime.Now.AddDays(2);

            System.Web.HttpContext.Current.Response.Cookies.Remove(cookie.Name);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}