using AprioriSite.Core.Constants;
using AprioriSite.Core.Contracts;
using AprioriSite.Core.Models;
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

        public IActionResult Details(Guid id)
        {
            var model = productsService.GetItemsById(id);
            return View(model);
        }

        public IActionResult Customise(Guid id)
        {
            var model = productsService.GetItemsById(id);
            return View(model);
        }

        public IActionResult Order(Guid id)
        {
            var model = productsService.GetItemsAndOrdersById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Order(OrderAndItemViewModel model)
        {
            if (await productsService.OrderItem(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Thanks for your order!";
                return Redirect("/");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "The was an error with your order!";
            }
            return Ok();
        }
    }
}
