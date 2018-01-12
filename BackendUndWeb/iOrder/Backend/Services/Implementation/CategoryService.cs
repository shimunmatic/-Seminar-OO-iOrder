using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository CategoryRepository;
        //private IEstablishmentService EstablishmentService;
        private IProductService ProductService;

        public CategoryService(ICategoryRepository categoryRepository, IProductService productService)//IEstablishmentService establishmentService
        {
            CategoryRepository = categoryRepository;
           // EstablishmentService = establishmentService;
            ProductService = productService;
        }

        public IEnumerable<Category> GetAllForEstablishment(long id)
        {
            return null;
        }

        public IEnumerable<Category> GetAllForOwner(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllForWarehouseId(long id)
        {
            var products = ProductService.GetProductsForWarehouseId(id);
            var categories = new List<Category>();
            var categoryIds = (from s in products
                              select s.CategoryId).Distinct().ToList();
            foreach (var catId in categoryIds)
            {
                var cat = CategoryRepository.GetById(catId);
                cat.Products = ProductService.GetProductsForCategoryId(catId);
                categories.Add(cat); 
            }
            return categories;
        }
    }
}
