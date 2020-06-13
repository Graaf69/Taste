using Taste.DataAccess.Data.Repository.IRepository;
using Taste.Models;
using System.Linq;

namespace Taste.DataAccess.Data.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader orderHeader)
        {
            var orderHeaderFromDb = _db.OrderHeader.FirstOrDefault(o => o.Id == orderHeader.Id);

            _db.OrderHeader.Update(orderHeaderFromDb);
            _db.SaveChanges();
        }
    }
}
