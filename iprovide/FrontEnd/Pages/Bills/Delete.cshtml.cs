using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTO;
using FrontEnd.Services;

namespace FrontEnd.Pages.Bills
{
    public class DeleteModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public DeleteModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public Bill Bill { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bill = await _apiClient.GetBillAsync(id.Value);

            if (Bill == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bill = await _apiClient.GetBillAsync(id.Value);

            if (Bill != null)
            {
                await _apiClient.DeleteBillAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
