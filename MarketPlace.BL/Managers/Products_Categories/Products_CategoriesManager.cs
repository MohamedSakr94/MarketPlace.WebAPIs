using MarketPlace.DAL;

namespace MarketPlace.BL
{
    public class Products_CategoriesManager : IProducts_CategoriesManager
    {
        private readonly IUnitOfWork unitOfWork;
        #region Constructor
        public Products_CategoriesManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        public void Add(Products_CategoriesAddDTO Products_CategoriesToAdd)
        {
            Products_Categories pro_cat = new()
            {
                Category_Id = Products_CategoriesToAdd.Category_Id,
                Product_Id = Products_CategoriesToAdd.Product_Id,
            };
            unitOfWork.Products_CategoriesRepo.Add(pro_cat);
            unitOfWork.SaveChanges();
        }
        public List<Products_CategoriesReadDTO> GetAll()
        {
            List<Products_Categories> Products_Categories = unitOfWork.Products_CategoriesRepo.GetAll();
            return Products_Categories.Select(x => new Products_CategoriesReadDTO
            {
                Product_Id = x.Product_Id,
                Category_Id = x.Category_Id,
            }).ToList();
        }


    }
}
