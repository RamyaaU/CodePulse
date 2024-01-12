using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Interface;

namespace CodePulse.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public CategoryRepository(ApplicationDBContext dBContext)
        {
            this._dBContext = dBContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _dBContext.Categories.AddAsync(category);
            await _dBContext.SaveChangesAsync();

            return category;
        }
    }
}
