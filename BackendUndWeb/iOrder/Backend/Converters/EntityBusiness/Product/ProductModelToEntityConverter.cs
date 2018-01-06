using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class ProductModelToEntityConverter : IConverter<Product, ProductEntity>
    {
        public ProductEntity Convert(Product Source)
        {
            if (null == Source) return null;
            return new ProductEntity
            {
                Id = Source.Id,
                BuyingPrice = Source.BuyingPrice,
                CategoryId = Source.CategoryId,
                Name = Source.Name,
                OwnerId = Source.OwnerId,
                SupplierId = Source.SupplierId
            };
        }

        public IEnumerable<ProductEntity> Convert(IEnumerable<Product> Source)
        {
            if (null == Source) return null;
            var entities = new List<ProductEntity>();
            foreach (var e in Source)
            {
                entities.Add(new ProductEntity
                {
                    Id = e.Id,
                    BuyingPrice = e.BuyingPrice,
                    CategoryId = e.CategoryId,
                    Name = e.Name,
                    OwnerId = e.OwnerId,
                    SupplierId = e.SupplierId
                });
            }
            return entities;
        }
    }
}
