using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region Person

        public async Task<bool> AddPersonAsync(Person person)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/persons", person);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/persons/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Person>();
        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            var response = await _httpClient.GetAsync("/api/persons");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<Person>>();
        }
        #endregion

        #region Transaction
        public async Task<TransactionResponse> GetTransactionAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/transactions/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TransactionResponse>();
        }
        public async Task<List<TransactionResponse>> GetTransactionsAsync()
        {
            var response = await _httpClient.GetAsync("/api/transactions");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<TransactionResponse>>();
        }

        public async Task PutTransactionAsync(Transaction transaction)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/transactions/{transaction.Id}", transaction);

            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> AddTransactionAsync(Transaction transaction)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/transactions", transaction);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
        #endregion

        #region Bill
        public async Task<bool> AddBillAsync(Bill bill)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/bills", bill);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<Bill> GetBillAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/bills/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Bill>();
        }

        public async Task<List<Bill>> GetBillsAsync()
        {
            var response = await _httpClient.GetAsync("/api/bills");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<Bill>>();
        }
        public async Task DeleteBillAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/bills/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return;
            }

            response.EnsureSuccessStatusCode();
        }
        public async Task PutBillAsync(Bill bill)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/bills/{bill.Id}", bill);

            response.EnsureSuccessStatusCode();
        }

        public Task DeleteTransactionAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}
