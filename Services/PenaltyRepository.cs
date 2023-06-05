using Microsoft.EntityFrameworkCore;
// using PenaltyCalculation.Models;
using PenaltyCalculation.Repos;

namespace PenaltyCalculation.Services
{
    public class PenaltyRepository : IPenaltyRepository
    {
        private readonly PenaltyCalculationDBContext _dbcontext;

        public PenaltyRepository(PenaltyCalculationDBContext dbContext)
        {
            _dbcontext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await _dbcontext.Transactions.OrderBy(t => t.Isin).ToListAsync();
        }

        public async Task<IEnumerable<string?>> GetAllISINsAsync()
        {
            return await _dbcontext.Transactions.Select(t => t.Isin).ToListAsync();
        }

        public async Task<Transaction> GetTransaction(string? isin)
        {
            Transaction transaction = new Transaction();
            if (!string.IsNullOrWhiteSpace(isin))
            {
                transaction = await _dbcontext.Transactions.FirstOrDefaultAsync(t => t.Isin == isin) ?? transaction;
            }
            return transaction!;
        }

        // public async Task<Transaction?> GetTransactionAsync(int placeofholdingtechnumber)
        // {
        //     return await _dbcontext.Transactions.Where(t => t.Placeofholdingtechnumber == placeofholdingtechnumber)
        //             .FirstOrDefaultAsync();
        // }

        // public async Task<bool?> UpdateTransactionAsync(int placeofholdingtechnumber, Transaction transaction)
        // {
        //     _dbcontext.Transactions.Update(transaction);
        //     return (await _dbcontext.SaveChangesAsync() >= 0);
        // }
        
        // public async Task<decimal?> PenaltyCalculation()
        // {
        //     var allTransactions = await _dbcontext.Transactions.ToListAsync();
        //     Transaction failedtransaction = new Transaction();
        //     foreach (var transaction in allTransactions)
        //     {
        //         SecurityPriceModel securityPrice = new SecurityPriceModel();
        //         securityPrice.SecurityPrice = 3000;
                
        //         SecurityPenaltyRate securityPenalty = new SecurityPenaltyRate();
        //         securityPenalty.PenaltyRate = 0.8m;

        //         if (failedtransaction is not null){
        //             failedtransaction.Matchingreference = failedtransaction.Matchingreference?.Trim();
        //             failedtransaction.Calendarid = failedtransaction.Calendarid?.Trim();
        //             failedtransaction.Partyid = failedtransaction.Partyid?.Trim();
        //             failedtransaction.Counterpartyid = failedtransaction.Counterpartyid?.Trim();
        //             failedtransaction.Failingpartyrolecd = failedtransaction.Failingpartyrolecd?.Trim();
        //             failedtransaction.Counterpartyrolecd = failedtransaction.Counterpartyrolecd?.Trim();

        //             failedtransaction.Settlementcashamount = transaction.Securityquantity * securityPrice.SecurityPrice 
        //                                                     * securityPenalty.PenaltyRate;
        //         }
        //     }

        //     _dbcontext.Transactions.Add(failedtransaction);
        //     await _dbcontext.SaveChangesAsync();

        //     return failedtransaction.Settlementcashamount;
        // }

        // public async Task<bool> SaveChangesAsync()
        // {
        //     return (await _dbcontext.SaveChangesAsync() >= 0);
        // }

    }
}