using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class CategoryEntityToModelConverter : IConverter<CategoryEntity, Category>
    {
        public Category Convert(CategoryEntity Source)
        {
            if (null == Source) return null;
            return new Category
            {
                Id = Source.Id,
                ParentId = Source.ParentId,
                OwnerId = Source.OwnerId,
                Name = Source.Name
            };
        }

        public IEnumerable<Category> Convert(IEnumerable<CategoryEntity> Source)
        {

            if (null == Source) return null;
            var categories = new List<Category>();
            foreach (var c in Source)
            {
                categories.Add(new Category
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    OwnerId = c.OwnerId,
                    Name = c.Name
                });
            }
            return categories;
        }
    }
}
