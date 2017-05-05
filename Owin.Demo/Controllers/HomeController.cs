using System.Threading;
using System.Web.Mvc;

namespace Owin.Demo.Controllers
{
    public class HomeController : Controller
    {
        // In manually adding this we also needed to add the following manually:
        // 1. In View: @inherits System.Web.Mvc.WebViewPage
        // 2. Global.asax: Add a route for the controller and action
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}