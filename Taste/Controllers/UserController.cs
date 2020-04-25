using Microsoft.AspNetCore.Mvc;
using System;
using Taste.DataAccess.Data.Repository.IRepository;

namespace Taste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.ApplicationUser.GetAll() });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objectFromDb = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == id);

            if (objectFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if (objectFromDb.LockoutEnd != null && objectFromDb.LockoutEnd > DateTime.Now)
            {
                objectFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objectFromDb.LockoutEnd = DateTime.Now.AddYears(100);
            }
            _unitOfWork.Save();

            return Json(new { success = true, message = "Operation Done!" });
        }
    }
}