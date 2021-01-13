using Microsoft.AspNetCore.Mvc;
using Wellmer.Domain;

namespace Wellmer.Areas.Admin.Controllers   //admin pradinis puslapis
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index()
        {
            return View(dataManager.ServiceItems.GetServiceItems());
        }
    }
}
