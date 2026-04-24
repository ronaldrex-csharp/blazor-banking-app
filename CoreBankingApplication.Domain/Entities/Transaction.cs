using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CoreBankingApplication.Domain.Entities;

public class Transaction
{
    public int Id { get; set; }
    public TransactionType transactionType { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public int AccountId { get; set; }
    public BankAccount? Account { get; set; }
}
public enum TransactionType
{
    Deposit = 1,
    Withdrawal = 2
}