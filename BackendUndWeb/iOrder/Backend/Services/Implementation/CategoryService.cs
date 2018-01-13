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

        public void Delete(object id)
        {
            CategoryRepository.Delete(CategoryRepository.GetById(id));
        }

        public IEnumerable<Category> GetAll()
        {
            return CategoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAllForEstablishment(long id)
        {
            return null;
        }

        public IEnumerable<Category> GetAllForOwner(string username)
        {
            return CategoryRepository.GetCategoriesOfOwner(username);
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
                cat.Products = (from p in products
                                where p.CategoryId == catId
                                select p).ToList();

                categories.Add(cat);
            }
            return categories;
        }

        public Category GetById(object id)
        {
            return CategoryRepository.GetById(id);
        }

        public void Save(Category t)
        {
            CategoryRepository.Save(t);
        }

        public void Update(object id, Category t)
        {
            CategoryRepository.Update(id, t);
        }
    }
}
