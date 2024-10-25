using HeroTest.Models;

namespace HeroTest.DTOs
{
    public class HeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Alias { get; set; }
        public string? BrandName { get; set; }

        public HeroDto() { }

        public HeroDto(Hero hero)
        {
            Id = hero.Id;
            Name = hero.Name;
            Alias = hero.Alias;
            BrandName = hero.Brand?.Name;
        }
    }
}
