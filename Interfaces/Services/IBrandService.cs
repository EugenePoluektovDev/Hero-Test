using HeroTest.DTOs;

namespace HeroTest.Interfaces.Services
{
    public interface IBrandService
    {
        Task<IList<BrandDto>> GetAllActiveBrandAsync();
    }
}
