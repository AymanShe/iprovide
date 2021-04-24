using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Transaction>()
            //    .HasOne(a => a.Expense)
            //    .WithOne(b => b.Transaction)
            //    .HasForeignKey<Expense>(b => b.TransactionId);

            //modelBuilder.Entity<Transaction>()
            //    .HasOne(a => a.BillPayment)
            //    .WithOne(b => b.Transaction)
            //    .HasForeignKey<BillPayment>(b => b.TransactionId);
        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillCategory> BillCategories { get; set; }
        public DbSet<BillPayment> BillPayments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
    }
}
