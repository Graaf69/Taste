using Taste.DataAccess.Data.Repository.IRepository;
using Taste.Models;
using System.Linq;

namespace Taste.DataAccess.Data.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetails orderDetails)
        {
            var orderDetailsFromDb = _db.OrderDetail.FirstOrDefault(o => o.Id == orderDetails.Id);

            _db.OrderDetail.Update(orderDetailsFromDb);
            _db.SaveChanges();
        }
    }
}
