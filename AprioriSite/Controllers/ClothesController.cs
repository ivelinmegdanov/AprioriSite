using AprioriSite.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AprioriSite.Controllers
{
    public class ClothesController : BaseController
    {
        private readonly IClothesService clothesService;

        public ClothesController(IClothesService _clothesService)
        {
            clothesService = _clothesService;
        }

        public IActionResult ClothesAll()
        {
            var clothes = clothesService.GetAllClothes();

            var model = new
            {
                Clothes = clothes
            };

            return View(model);
        }
    }
}
