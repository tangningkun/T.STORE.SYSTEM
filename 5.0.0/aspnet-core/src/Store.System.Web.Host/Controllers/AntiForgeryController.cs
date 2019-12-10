using Microsoft.AspNetCore.Antiforgery;
using Store.System.Controllers;

namespace Store.System.Web.Host.Controllers
{
    public class AntiForgeryController : SystemControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
