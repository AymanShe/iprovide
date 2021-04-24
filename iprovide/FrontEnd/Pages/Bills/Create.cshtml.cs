using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DTO;
using FrontEnd.Services;

namespace FrontEnd.Pages.Bills
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
        public Bill Bill { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.AddBillAsync(Bill);

            return RedirectToPage("./Index");
        }
    }
}
