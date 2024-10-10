using ECommerce.WEB.Services;
using ECommerce.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WEB.Controllers
{
    public class ECommerceController : Controller
    {
        private readonly ECommerceService service1;

        public ECommerceController(ECommerceService service) {
            service1 = service;
        }

        public async Task<IActionResult> Search([FromQuery] SearchPageViewModel searchPageView)
        {
            var (eCommerceList, totalCount, pageLinkCount) = await service1.SearchAsync(
                searchPageView.SearchViewModel,
                searchPageView.Page,
                searchPageView.PageSize);

            return View(searchPageView);
        }
    }
}
