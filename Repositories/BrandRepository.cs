using HeroTest.Interfaces.Repositories;
using HeroTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly SampleContext _dbContext;

        public BrandRepository(SampleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Brand>> GetAllActiveBrandsAsync()
        {
            var brands = await _dbContext.Brands
                .Where(b => b.IsActive == true)
                .ToListAsync();

            return brands;
        }
    }
}
