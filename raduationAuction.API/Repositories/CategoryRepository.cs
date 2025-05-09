using GraduationAuction.API.Persistance;
using Microsoft.EntityFrameworkCore;
using raduationAuction.API.Model;

namespace raduationAuction.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly webDbContext _webDb;

        public CategoryRepository(webDbContext webDb)
        {
            _webDb = webDb;
        }

        public async Task AddAsync(Category category)
        {
            await _webDb.Categories.AddAsync(category);
        }

        public async  Task<Category> GetByNameAsync(string name)
        {
            return await _webDb.Categories.
                            Where(c => c.CategoryName.ToLower() == name.ToLower())
                           .FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _webDb.SaveChangesAsync();
        }
    }
}
