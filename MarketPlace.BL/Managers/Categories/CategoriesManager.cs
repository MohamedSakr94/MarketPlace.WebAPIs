using MarketPlace.DAL;

namespace MarketPlace.BL
{
    public class CategoriesManager : ICategoriesManager
    {
        private readonly IUnitOfWork unitOfWork;
        #region Constructor
        public CategoriesManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        public CategoriesReadDetailsDTO GetProductsByCategory(string catName)
        {
            Categories? _category = unitOfWork.CategoriesRepo.GetProductsByCategory(catName);
            if (_category == null) return null;
            CategoriesReadDetailsDTO category = new()
            {
                Id = _category.Id,
                Name = _category.Name,
                Products = _category.Products_Categories.Select(p => new ProductsReadDTO
                {
                    Id = p.Category_Id,
                    Name = p.Product.Name,
                    Price = p.Product.Price
                }).ToList()
            };
            return category;
        }

        #region UnusedCode
        public void Add(CategoriesAddDTO categoryToAdd)
        {
            Categories category = new()
            {
                Name = categoryToAdd.Name,
            };
            unitOfWork.CategoriesRepo.Add(category);
            unitOfWork.SaveChanges();
        }
        public List<CategoriesReadDTO> GetAll()
        {
            List<Categories> Categories = unitOfWork.CategoriesRepo.GetAll();
            return Categories.Select(x => new CategoriesReadDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public CategoriesReadDTO? GetById(int id)
        {
            Categories? _category = unitOfWork.CategoriesRepo.GetById(id);
            if (_category == null)
            { return null; }
            CategoriesReadDTO category = new()
            {
                Id = _category.Id,
                Name = _category.Name,
            };
            return category;
        }

        public bool Delete(int id)
        {
            Categories? category = unitOfWork.CategoriesRepo.GetById(id);
            if (category == null)
            { return false; }
            unitOfWork.CategoriesRepo.Delete(id);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion
    }
}
