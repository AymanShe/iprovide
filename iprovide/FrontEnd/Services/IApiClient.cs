using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Services
{
    public interface IApiClient
    {
        Task<List<TransactionResponse>> GetTransactionsAsync();
        Task<TransactionResponse> GetTransactionAsync(int id);
        Task PutTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(int id);
        Task<bool> AddTransactionAsync(Transaction transaction);

        Task<List<Person>> GetPersonsAsync();
        Task<Person> GetPersonAsync(int id);
        Task<bool> AddPersonAsync(Person person);

        Task<List<Bill>> GetBillsAsync();
        Task<Bill> GetBillAsync(int id);
        Task<bool> AddBillAsync(Bill bill);
        Task DeleteBillAsync(int id);
        Task PutBillAsync(Bill bill);
    }
}
