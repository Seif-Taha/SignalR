using Microsoft.AspNetCore.Mvc;

namespace SignalR.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
