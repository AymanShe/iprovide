using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTO;
using FrontEnd.Services;

namespace FrontEnd.Pages.Transactions
{
    public class DetailsModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public DetailsModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

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
    }
}
