using MarketPlace.BL;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Constructor & fields
        private readonly IProductsManager productsManager;
        private readonly IProducts_CategoriesManager products_categoriesManager;

        public ProductsController(IProductsManager _productsManager, IProducts_CategoriesManager products_categoriesManager)
        {
            this.productsManager = _productsManager;
            this.products_categoriesManager = products_categoriesManager;
        }
        #endregion


        //1. Add a new product to the marketplace.
        #region Task1
        [HttpPost]
        public ActionResult AddNewProduct(ProductsAddDTO productAddDTO)
        {
            productsManager.Add(productAddDTO);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        //2. Remove an existing product from the marketplace.
        #region Task2
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var result = productsManager.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        //3.1. Search for a product by its name.
        #region Task3.1
        [HttpGet]
        [Route("SearchByName")]
        public ActionResult<ProductsReadDetailsDTO>? GetByName(string name)
        {
            return productsManager.GetByName(name);
        }
        #endregion

        //3.2. Search for a product by category.
        #region Task3.2
        //Please see Categories Controller

        #endregion

        //3.3 Search for a product by price range.
        #region Task3.3
        [HttpGet]
        [Route("SearchByPriceRange")]
        public ActionResult<List<ProductsReadDTO>> GetByPriceRange(int from, int to)
        {
            return productsManager.GetByPriceRange(from, to);
        }


        #endregion

        //4. Display all products in the marketplace.
        #region Task4
        [HttpGet]
        [Route("Index")]
        public ActionResult<List<ProductsReadDetailsDTO>> Index()
        {
            return productsManager.GetAllWithDetails();
        }
        #endregion

        //5. Display the number of products in the marketplace.
        #region Task5
        [HttpGet]
        [Route("Count")]
        public ActionResult GetCount()
        {
            return Content(productsManager.GetCount().ToString());
        }
        #endregion


        //6. manage user profiles & their shopping cart






        #region UnusedCode


        //[HttpGet]
        //[Route("{id}")]
        //public ActionResult<ProductsReadDTO> GetById(int id)
        //{
        //    ProductsReadDTO? product = productsManager.GetById(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return product;
        //}
        #endregion
    }
}
