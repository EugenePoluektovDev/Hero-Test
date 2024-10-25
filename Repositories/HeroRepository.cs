using HeroTest.Interfaces.Repositories;
using HeroTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly SampleContext _dbContext;

        public HeroRepository(SampleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Hero>> GetAllActiveHeroesAsync()
        {
            try
            {
                var heroes = await _dbContext.Heroes
                    .Where(h => h.IsActive == true)
                    .Include(h => h.Brand)
                    .ToListAsync();

                return heroes;
            }
            catch (Exception ex)
            {
                return new List<Hero>();
            }
        }

        public async Task<Hero> AddHeroAsync(Hero hero)
        {
            try
            {
                await _dbContext.Heroes.AddAsync(hero);

                await _dbContext.SaveChangesAsync();

                return hero;
            } catch (Exception ex)
            {
                return new Hero();
            }
        }

        public async Task DeleteHeroAsync(int heroId)
        {

            var heroToDelete = await _dbContext.Heroes.FindAsync(heroId);

            if (heroToDelete is not null)
            {
                heroToDelete.IsActive = false;

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
