using GraduationAuction.API.Persistance;
using Microsoft.EntityFrameworkCore;
using raduationAuction.API.Model;

namespace raduationAuction.API.Repositories
{
    public class ItemRepository : IItemRepository
    {

        private readonly webDbContext  _context;
        public ItemRepository(webDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
        }
        public async Task<Item> GetByIdAsync(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.ItemID == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
