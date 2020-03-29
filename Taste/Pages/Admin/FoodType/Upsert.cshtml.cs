using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taste.DataAccess.Data.Repository.IRepository;

namespace Taste.Pages.Admin.FoodType
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.FoodType FoodTypeObject { get; set; }
        
        public IActionResult OnGet(int? id)
        {
            FoodTypeObject = new Models.FoodType();

            if (id != null)
            {
                FoodTypeObject = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());

                if(FoodTypeObject == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(FoodTypeObject.Id == 0)
            {
                _unitOfWork.FoodType.Add(FoodTypeObject);
            }
            else
            {
                _unitOfWork.FoodType.Update(FoodTypeObject);
            }

            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}