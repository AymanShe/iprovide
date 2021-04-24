using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DTO;
using FrontEnd.Services;
using System.Security.Claims;

namespace FrontEnd.Pages.Transactions
{
    public class CreateModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public CreateModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TransactionResponse Transaction { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            Transaction.Date = DateTime.Now;
            Transaction.PersonId = User.GetPersonId();
            Transaction.CategoryId = (int)Enums.TransactionCategory.Expense;

            await _apiClient.AddTransactionAsync(Transaction);

            return RedirectToPage("./Index");
        }
    }
}
