using MarketPlace.BL;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesManager categoriesManager;

        public CategoriesController(ICategoriesManager categoriesManager)
        {
            this.categoriesManager = categoriesManager;
        }

        [HttpGet]
        [Route("SearchForProductsByCatName")]
        public ActionResult<CategoriesReadDetailsDTO>? SearchByCat(string catName)
        {
            return categoriesManager.GetProductsByCategory(catName);
        }
    }
}
