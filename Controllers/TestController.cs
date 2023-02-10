using Microsoft.AspNetCore.Mvc;

namespace Penguin.Cms.Modules.Testing.Controllers
{
    public partial class TestController : Controller
    {
        public ActionResult ClearCookiesStorage()
        {
            return View();
        }

        public ActionResult ClearLocalStorage()
        {
            return View();
        }

        public ActionResult ClearSessionStorage()
        {
            return View();
        }

        public ActionResult ClearStorage()
        {
            return View();
        }
    }
}