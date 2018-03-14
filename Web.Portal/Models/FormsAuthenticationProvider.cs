using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;

namespace Web.Portal
{
    internal class FormsAuthenticationProvider : ICookieAuthenticationProvider
    {
        public void ApplyRedirect(CookieApplyRedirectContext context)
        {
            //throw new NotImplementedException();
        }

        public void Exception(CookieExceptionContext context)
        {
            //throw new NotImplementedException();
        }

        public void ResponseSignedIn(CookieResponseSignedInContext context)
        {
            //throw new NotImplementedException();
        }

        public void ResponseSignIn(CookieResponseSignInContext context)
        {
            //throw new NotImplementedException();
        }

        public void ResponseSignOut(CookieResponseSignOutContext context)
        {
            //throw new NotImplementedException();
        }

        public Task ValidateIdentity(CookieValidateIdentityContext context)
        {
            return Task.FromResult(0);
            //throw new NotImplementedException();
        }
    }
}