using HeroTest.DTOs;
using HeroTest.Interfaces.Repositories;
using HeroTest.Interfaces.Services;

namespace HeroTest.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IList<BrandDto>> GetAllActiveBrandAsync()
        {
            try
            {
                var brands = await _brandRepository.GetAllActiveBrandsAsync();

                return brands.Select(brand => new BrandDto(brand)).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        } 
    }
}
