using AprioriSite.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AprioriSite.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService _productsService)
        {
            productsService = _productsService;
        }

        public IActionResult Products()
        {
            var clothes = productsService.GetAllProducts();

            var model = new
            {
                Clothes = clothes
            };

            return View(model);
        }
    }
}
