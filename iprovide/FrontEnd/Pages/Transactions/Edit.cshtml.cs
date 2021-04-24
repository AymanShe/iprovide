using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DTO;
using FrontEnd.Services;

namespace FrontEnd.Pages.Transactions
{
    public class EditModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public EditModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public TransactionResponse Transaction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transaction = await _apiClient.GetTransactionAsync(id.Value);

            if (Transaction == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.PutTransactionAsync(Transaction);

            return RedirectToPage("./Index");
        }

        //private bool TransactionExists(int id)
        //{
        //    return _context.Transaction.Any(e => e.Id == id);
        //}
    }
}
