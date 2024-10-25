using HeroTest.DTOs;
using HeroTest.Interfaces.Repositories;
using HeroTest.Interfaces.Services;
using HeroTest.Models;

namespace HeroTest.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;

        public HeroService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public async Task<IList<HeroDto>> GetAllActiveHeroesAsync()
        {
            var heroes = await _heroRepository.GetAllActiveHeroesAsync();

            return heroes.Select(hero => new HeroDto(hero)).ToList();
        }

        public async Task<HeroDto> AddHeroAsync(AddHeroDto addHeroDto)
        {
            var heroToCreate = new Hero
            {
                Name = addHeroDto.Name,
                Alias = addHeroDto.Alias,
                BrandId = addHeroDto.BrandId
            };

            var createdHero = await _heroRepository.AddHeroAsync(heroToCreate);

            return new HeroDto(createdHero);
        }

        public async Task DeleteHeroAsync(int heroId)
        {
            await _heroRepository.DeleteHeroAsync(heroId); ;
        }
    }
}
