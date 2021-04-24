using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTO;
using FrontEnd.Services;
using System.Security.Claims;

namespace FrontEnd.Pages.Transactions
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient _apiClient;
        public bool IsAdmin { get; set; }

        public IndexModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IList<TransactionResponse> Transaction { get;set; }

        public async Task OnGetAsync()
        {
            var transactions = await _apiClient.GetTransactionsAsync();
            Transaction = transactions.OrderByDescending(x => x.Date).ToList();
        }
    }
}
