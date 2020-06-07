using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace T.STORE.SYSTEM.WebPage.Controllers
{
    public class LayoutController : Controller
    {
        
        public IActionResult HeaderIndex()
        {
            var name = "主页";

            return PartialView("_HeaderIndex");
        }
    }
}