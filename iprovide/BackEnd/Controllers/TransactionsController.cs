using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using DTO;
using System.Runtime.CompilerServices;
using BackEnd.Security;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuthAttribute]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetTransactions()
        {
            var transactions = await _context.Transactions.AsNoTracking().Include(x => x.Expense).Include(x => x.Payment).Include(x => x.Category).Select(t => t.MapTransactionResponse()).ToListAsync();

            return transactions;
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionResponse>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.AsNoTracking().Include(x => x.Expense).Include(x => x.Payment).Include(x => x.Category).SingleOrDefaultAsync(s => s.Id == id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction.MapTransactionResponse();
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTransaction(int id, TransactionResponse transaction)
        //{
        //    if (id != transaction.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(transaction).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TransactionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Transactions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> PostTransaction(TransactionResponse transactionResponse)
        {

            var expense = new Data.Expense
            {
                Name = transactionResponse.Expense.Name,
                IsShared = transactionResponse.Expense.IsShared
            };

            var transaction = new Data.Transaction
            {
                Amount = transactionResponse.Amount,
                Date = transactionResponse.Date,
                CategoryId = transactionResponse.CategoryId,
                PersonId = transactionResponse.PersonId,
                Expense = expense,
            };


            _context.Transactions.Add(transaction);

            //update person balance
            var persons = await _context.Persons.ToListAsync();
            double value;
            if (expense.IsShared)
            {
                value = transaction.Amount / 2;
            }
            else
            {
                value = transaction.Amount;
            }

            var payer = persons.Where(x => x.Id == transactionResponse.PersonId).FirstOrDefault();
            var nonPayer = persons.Where(x => x.Id != transactionResponse.PersonId).FirstOrDefault();

            payer.CurrentDebtBalance -= value;
            nonPayer.CurrentDebtBalance += value;
            _context.Persons.Update(payer);
            _context.Persons.Update(nonPayer);

            transaction.PayerBillsBalance = payer.CurrentBillBalance;
            transaction.PayerDebtBalance = payer.CurrentDebtBalance;


            await _context.SaveChangesAsync();

            var result = transaction.MapTransactionResponse();

            return CreatedAtAction(nameof(GetTransaction), new { id = result.Id }, result);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransactionResponse>> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.AsNoTracking().Include(x => x.Expense).Include(x => x.Payment).Include(x => x.Category).SingleOrDefaultAsync(s => s.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            var lastTransaction = await _context.Transactions.AsNoTracking().OrderByDescending(x => x.Id).FirstAsync();
            if (transaction.Id != lastTransaction.Id)
            {
                return BadRequest();
            }

            var amount = transaction.Amount;
            var isShared = transaction.Expense.IsShared;
            var payerId = transaction.PersonId;
            var persons = await _context.Persons.ToListAsync();
            var payer = persons.Where(x => x.Id == transaction.PersonId).FirstOrDefault();
            var nonPayer = persons.Where(x => x.Id != transaction.PersonId).FirstOrDefault();

            if (isShared)
            {
                amount /= 2;
            }

            payer.CurrentDebtBalance += amount;
            nonPayer.CurrentDebtBalance -= amount;

            _context.Persons.Update(payer);
            _context.Persons.Update(nonPayer);

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return transaction.MapTransactionResponse();
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
