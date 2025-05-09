using GraduationAuction.API.Dtos;
using raduationAuction.API.Model;

namespace raduationAuction.API.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<Category> GetByNameAsync(string name);
        Task SaveAsync();
    }
    }
