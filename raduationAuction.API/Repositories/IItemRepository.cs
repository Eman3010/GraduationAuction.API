using raduationAuction.API.Model;

namespace raduationAuction.API.Repositories
{
    public interface IItemRepository
    {
        Task AddAsync(Item item);
        Task<Item> GetByIdAsync(int itemId);
        Task SaveAsync();
    }
}
