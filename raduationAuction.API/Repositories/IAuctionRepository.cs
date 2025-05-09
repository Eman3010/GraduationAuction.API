using raduationAuction.API.Model;

namespace GraduationAuction.API.Repositories
{
    public interface IAuctionRepository
    {
        Task AddAsync(Auction auction);  // لإضافة مزاد جديد
        Task SaveAsync();
    }
}
