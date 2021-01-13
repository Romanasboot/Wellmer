using Microsoft.AspNetCore.Mvc;
using Wellmer.Domain;

namespace Wellmer.Controllers   //pradinis puslapis
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.TextFields.GetTextFieldbyCodeWord("PageIndex"));
        }

        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldbyCodeWord("PageContacts"));
        }
    }
}
