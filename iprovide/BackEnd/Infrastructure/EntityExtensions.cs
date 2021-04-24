using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data;

namespace BackEnd.Data
{
    public static class EntityExtensions
    {
        public static DTO.TransactionResponse MapTransactionResponse(this Transaction transaction) =>
          new DTO.TransactionResponse 
          { 
              Id = transaction.Id,
              Amount = transaction.Amount,
              PayerDebtBalance = transaction.PayerDebtBalance,
              PayerBillsBalance = transaction.PayerBillsBalance,
              Date = transaction.Date,
              PersonId = transaction.PersonId,
              CategoryId = transaction.CategoryId,
              Category = transaction.Category,
              Expense = transaction.Expense,
              Payment = transaction.Payment
          };
        public static DTO.PersonResponse MapPersonResponse(this Person person) =>
          new DTO.PersonResponse
          { 
              Id = person.Id,
              Name = person.Name,
              CurrentBillBalance = person.CurrentBillBalance,
              CurrentDebtBalance = person.CurrentDebtBalance,
          };
    }
}
