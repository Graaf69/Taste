using Microsoft.AspNetCore.Mvc;
using Taste.DataAccess.Data.Repository.IRepository;

namespace Taste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Category.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {
            var objectFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (objectFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Category.Remove(objectFromDb);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Done!" });
        }
    }
}