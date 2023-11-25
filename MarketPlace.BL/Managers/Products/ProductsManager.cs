using MarketPlace.DAL;

namespace MarketPlace.BL
{
    public class ProductsManager : IProductsManager
    {
        private readonly IUnitOfWork unitOfWork;
        #region Constructor
        public ProductsManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion


        public void Add(ProductsAddDTO productToAdd)
        {
            Products product = new()
            {
                Name = productToAdd.Name,
                Price = productToAdd.Price,
                Products_Categories = productToAdd.Products_Categories.Select(pc => new Products_Categories
                {
                    Category_Id = pc.Category_Id,
                    Product_Id = pc.Product_Id,
                }).ToList()
            };
            unitOfWork.ProductsRepo.Add(product);
            unitOfWork.SaveChanges();
        }

        public bool Delete(int id)
        {
            Products? product = unitOfWork.ProductsRepo.GetById(id);
            if (product == null)
            { return false; }
            unitOfWork.ProductsRepo.Delete(id);
            unitOfWork.SaveChanges();
            return true;
        }

        public ProductsReadDetailsDTO GetByName(string name)
        {
            Products? _product = unitOfWork.ProductsRepo.GetByName(name);
            if (_product == null) return null;
            ProductsReadDetailsDTO product = new()
            {
                Id = _product.Id,
                Name = _product.Name,
                Price = _product.Price,
                Categories = _product.Products_Categories.Select(c => new CategoriesReadDTO
                {
                    Id = c.Category_Id,
                    Name = c.Category.Name
                }).ToList()
            };
            return product;
        }

        public List<ProductsReadDTO> GetByPriceRange(decimal from, decimal to)
        {
            List<Products> _products = unitOfWork.ProductsRepo.GetByPriceRange(from, to);
            if (_products == null) return null;
            return _products.Select(p => new ProductsReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }

        public List<ProductsReadDetailsDTO> GetAllWithDetails()
        {
            List<Products> products = unitOfWork.ProductsRepo.GetAllWithDetails();
            return products.Select(p => new ProductsReadDetailsDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Categories = p.Products_Categories.Select(c => new CategoriesReadDTO
                {
                    Id = c.Category_Id,
                    Name = c.Category.Name
                }).ToList()
            }).ToList();
        }

        public int GetCount()
        {
            return unitOfWork.ProductsRepo.GetCount();
        }



        #region unusedCode
        public List<ProductsReadDTO> GetAll()
        {
            List<Products> products = unitOfWork.ProductsRepo.GetAll();
            return products.Select(p => new ProductsReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }

        public ProductsReadDTO? GetById(int id)
        {
            Products? _product = unitOfWork.ProductsRepo.GetById(id);
            if (_product == null)
            { return null; }
            ProductsReadDTO product = new()
            {
                Id = _product.Id,
                Name = _product.Name,
                Price = _product.Price
            };
            return product;
        }

        //public ProductsReadDetailsDTO? GetDetailsById(int id)
        //{
        //    Products? _product = unitOfWork.ProductsRepo.GetByIdWithDetails(id);
        //    if (_product == null)
        //    { return null; }
        //    ProductsReadDetailsDTO product = new()
        //    {
        //        Id = _product.Id,
        //        Name = _product.Name,
        //        Price = _product.Price,
        //        Categories = _product.Categories.Select(c => new CategoriesReadDTO
        //        {
        //            Id = c.Id,
        //            Name = c.Name,
        //        }).ToList()
        //    };
        //    return product;
        //}


        #endregion
    }
}
