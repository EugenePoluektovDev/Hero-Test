using HeroTest.Models;

namespace HeroTest.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllActiveBrandsAsync();
    }
}
