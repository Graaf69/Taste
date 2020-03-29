using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taste.DataAccess.Data.Repository.IRepository;
using Taste.Models;
using System.Linq;

namespace Taste.DataAccess.Data.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetFoodTypeListForDropdown()
        {
            return _db.FoodType.Select(i => new SelectListItem() 
            { 
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(FoodType foodType)
        {
            var objectFromDb = _db.FoodType.FirstOrDefault(s => s.Id == foodType.Id);

            objectFromDb.Name = foodType.Name;

            _db.SaveChanges();
        }
    }
}
