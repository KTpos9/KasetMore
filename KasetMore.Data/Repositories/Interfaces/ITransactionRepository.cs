using KasetMore.Data.Models;

namespace KasetMore.Data.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddTransaction(List<Transaction> transactions);
        Task<List<Transaction>> GetSellerTransactionsByEmail(string email);
        Task<List<Transaction>> GetBuyerTransactionsByEmail(string email);
        Task<Transaction?> GetTransactionById(int id);
    }
}