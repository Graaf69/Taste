using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taste.DataAccess.Data.Repository.IRepository;
using Taste.Models;
using System.Linq;

namespace Taste.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropwdown()
        {
            return _db.Category.Select(i => new SelectListItem() 
            { 
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Category category)
        {
            var objectFromDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);

            objectFromDb.Name = category.Name;
            objectFromDb.DisplayOrder = category.DisplayOrder;

            _db.SaveChanges();
        }
    }
}
