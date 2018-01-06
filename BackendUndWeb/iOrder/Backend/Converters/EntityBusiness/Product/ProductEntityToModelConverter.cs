using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class ProductEntityToModelConverter : IConverter<ProductEntity, Product>
    {


        public Product Convert(ProductEntity Source)
        {
            if (null == Source) return null;
            return new Product
            {
                Id = Source.Id,
                BuyingPrice = Source.BuyingPrice,
                CategoryId = Source.CategoryId,
                Name = Source.Name,
                OwnerId = Source.OwnerId,
                SupplierId = Source.SupplierId
            };
        }


        public IEnumerable<Product> Convert(IEnumerable<ProductEntity> Source)
        {
            if (null == Source) return null;
            var products = new List<Product>();
            foreach (var p in Source)
            {
                products.Add(new Product
                {
                    Id = p.Id,
                    BuyingPrice = p.BuyingPrice,
                    CategoryId = p.CategoryId,
                    Name = p.Name,
                    OwnerId = p.OwnerId,
                    SupplierId = p.SupplierId
                });
            }
            return products;

        }

    }
}
