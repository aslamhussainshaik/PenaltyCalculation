
// using PenaltyCalculation.Models;
using PenaltyCalculation.Repos;

namespace PenaltyCalculation.Services
{
    public interface IPenaltyRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
        Task<IEnumerable<string?>> GetAllISINsAsync();
        Task<Transaction> GetTransaction(string? isin);

        // IEnumerable<Transaction> GetTransactionsAsync();


        // Task<bool?> UpdateTransactionAsync(int placeofholdingtechnumber, Transaction transaction);
        // Task<Transaction?> GetTransactionAsync(int placeofholdingtechnumber);
        // Task<decimal?> PenaltyCalculation();
        // Task<bool> SaveChangesAsync();
    }
}