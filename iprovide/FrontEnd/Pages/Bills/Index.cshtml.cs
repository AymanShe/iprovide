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
    public class IndexModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public IndexModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IList<Bill> Bill { get;set; }

        public async Task OnGetAsync()
        {
            Bill = await _apiClient.GetBillsAsync();
        }
    }
}
