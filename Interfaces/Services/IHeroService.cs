using HeroTest.DTOs;

namespace HeroTest.Interfaces.Services
{
    public interface IHeroService
    {
        Task<IList<HeroDto>> GetAllActiveHeroesAsync();
        Task<HeroDto> AddHeroAsync(AddHeroDto addHeroDto);
        Task DeleteHeroAsync(int heroId);
    }
}
