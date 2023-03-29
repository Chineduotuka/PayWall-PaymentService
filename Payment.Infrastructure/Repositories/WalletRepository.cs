using Microsoft.EntityFrameworkCore;
using Payment.Core.Interfaces;
using Payment.Domain.Models;

namespace Payment.Infrastructure.Repositories
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        private readonly PaymentDbContext _dbContext;

        public WalletRepository(PaymentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets wallet by id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns wallet</returns>
        public async Task<Wallet?> Get(string id)
        {
           return await _dbContext.Wallets.Include(w => w.VirtualAccount).ThenInclude(v => v.Bank).FirstOrDefaultAsync(w => w.Id == id);
        }

    }
}
