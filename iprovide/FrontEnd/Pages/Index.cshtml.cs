using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        protected readonly IApiClient _apiClient;
        private readonly ILogger<IndexModel> _logger;
        public Person Person { get; set; }

        [BindProperty]
        public TransactionResponse Transaction { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task<IActionResult> OnGet()
        {
            var person = await _apiClient.GetPersonAsync(User.GetPersonId());

            if (person == null)
            {
                return NotFound();
            }
            
            Person = person;



            return Page();
        }

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
