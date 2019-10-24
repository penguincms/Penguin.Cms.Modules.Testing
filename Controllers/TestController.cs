using Microsoft.AspNetCore.Mvc;

namespace Penguin.Cms.Modules.Testing.Controllers
{
    public partial class TestController : Controller
    {
        public ActionResult ClearCookiesStorage() => this.View();

        public ActionResult ClearLocalStorage() => this.View();

        public ActionResult ClearSessionStorage() => this.View();

        public ActionResult ClearStorage() => this.View();
    }
}