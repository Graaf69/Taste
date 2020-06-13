using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;
using Taste.DataAccess.Data.Repository.IRepository;
using Taste.Models;
using Taste.Models.ViewModels;
using Taste.Utility;

namespace Taste.Pages.Customer.Cart
{
    public class OrderConfirmationModel : PageModel
    {
        [BindProperty]
        public int orderId { get; set; }
        
        public void OnGet(int id)
        {
           orderId = id;     
        }
    }
}