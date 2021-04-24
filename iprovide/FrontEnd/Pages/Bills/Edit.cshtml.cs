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
    public class EditModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public EditModel(IApiClient apiClient)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.PutBillAsync(Bill);

            return RedirectToPage("./Index");
        }

        //private bool BillExists(int id)
        //{
        //    return _context.Bill.Any(e => e.Id == id);
        //}
    }
}
