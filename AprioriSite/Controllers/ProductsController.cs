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

        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Order(OrderAndItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await productsService.OrderItem(model.OrderItemViewModel))
            {
                ViewData[MessageConstant.SuccessMessage] = "Successful!";
                return Redirect("/user/myprofile");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Error!";
            }
            return Ok();
        }
    }
}
