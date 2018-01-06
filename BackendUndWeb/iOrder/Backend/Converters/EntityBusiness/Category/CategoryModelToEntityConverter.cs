using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class CategoryModelToEntityConverter : IConverter<Category, CategoryEntity>
    {
        public CategoryEntity Convert(Category Source)
        {
            if (null == Source) return null;
            return new CategoryEntity
            {
                Id = Source.Id,
                OwnerId = Source.OwnerId,
                Name = Source.Name
            };
        }

        public IEnumerable<CategoryEntity> Convert(IEnumerable<Category> Source)
        {
            if (null == Source) return null;
            var categories = new List<CategoryEntity>();
            foreach (var c in Source)
            {
                categories.Add(new CategoryEntity
                {
                    Id = c.Id,
                    OwnerId = c.OwnerId,
                    Name = c.Name
                });
            }
            return categories;
        }
    }
}
