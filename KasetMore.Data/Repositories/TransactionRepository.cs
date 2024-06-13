using KasetMore.Data.Models;
using KasetMore.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KasetMore.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly KasetMoreContext _context;

        public TransactionRepository(KasetMoreContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetSellerTransactionsByEmail(string email)
        {
            return await _context.Transactions
                .Where(t => t.SellerEmail == email)
                .ToListAsync();
        }
        public async Task<List<Transaction>> GetBuyerTransactionsByEmail(string email)
        {
            return await _context.Transactions
                .Where(t => t.BuyerEmail == email)
                .ToListAsync();
        }
        public async Task<Transaction?> GetTransactionById(int id)
        {
            return await _context.Transactions
                .Where(t => t.TransactionId == id)
                .FirstOrDefaultAsync();
        }
        public async Task AddTransaction(List<Transaction> transactions)
        {
            try
            {
                _context.Transactions.AddRange(transactions);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
