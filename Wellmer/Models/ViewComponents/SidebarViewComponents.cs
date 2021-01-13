using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wellmer.Domain;

namespace Wellmer.Models.ViewComponents     //sidebar. Skaito is DB ir atvaizduoja paslaugas.
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;

        public SidebarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default", dataManager.ServiceItems.GetServiceItems()));
        }
    }
}
