using HeroTest.Models;

namespace HeroTest.Interfaces.Repositories
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> GetAllActiveHeroesAsync();
        Task<Hero> AddHeroAsync(Hero hero);
        Task DeleteHeroAsync(int heroId);
    }
}
