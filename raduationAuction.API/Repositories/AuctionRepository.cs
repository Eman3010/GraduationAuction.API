using GraduationAuction.API.Persistance;
using Microsoft.EntityFrameworkCore;
using raduationAuction.API.Model;

namespace GraduationAuction.API.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly webDbContext dbContext;
        public AuctionRepository (webDbContext context)
        {
            dbContext = context;
        }
        

        public async Task AddAsync(Auction auction)
        {
            await dbContext.Auctions.AddAsync(auction);
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
    
    
}
