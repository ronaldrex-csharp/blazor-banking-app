using CoreBankingApplication.Application.Services;
using CoreBankingApplication.Application.ViewModels;
using CoreBankingApplication.Domain.Entities;
using CoreBankingApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreBankingApplication.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IDbContextFactory<BankingDbContext> _factory;

        public AccountService(IDbContextFactory<BankingDbContext> factory)
        {
            _factory = factory;
        }
        ///// <summary>
        ///  Retrieves a list of bank accounts with masked account numbers and customer names.
        ///
        public async Task<List<AccountListItemViewModel>> GetAccountListAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();

            var accounts = await context.Accounts
                .AsNoTracking()
                .Include(a => a.Customer) 
                .ToListAsync();

            return accounts.Select(a => new AccountListItemViewModel
            {
                Id = a.Id,
                CustomerName = a.Customer != null
                    ? a.Customer.FullName
                    : "NO CUSTOMER",

                MaskedAccountNumber = MaskAccountNumber(a.AccountNumber),

                Balance = a.Balance

               // Status = a.IsActive ? "Active" : "Closed"
            }).ToList();
        }

        public async Task<BankAccountViewModel?> GetBankAccountViewModelByIdAsync(int id)
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Accounts
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Select(a => new BankAccountViewModel
                {
                    Id = a.Id,
                    FullName = a.Customer != null
                    ? a.Customer.FullName
                    : "No Customer",
                    Name = a.Name,
                    MaskedAccountNumber = MaskAccountNumber(a.AccountNumber),
                    Balance = a.Balance
                })
                .FirstOrDefaultAsync();
        }

        public async Task<BankAccount?> GetAccountByIdAsync(int id)
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<BankAccount> CreateAccountAsync(BankAccount account)
        {
            await using var context = await _factory.CreateDbContextAsync();

            context.Accounts.Add(account);
            await context.SaveChangesAsync();
            return account;
        }

        public async Task UpdateAccountAsync(BankAccount account)
        {
            await using var context = await _factory.CreateDbContextAsync();

            context.Accounts.Update(account);
            await context.SaveChangesAsync();
        }

        private static string MaskAccountNumber(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber) || accountNumber.Length <= 4)
                return accountNumber;

            return $"**** **** **** {accountNumber[^4..]}";
        }
    }
}
