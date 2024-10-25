using HeroTest.Models;

namespace HeroTest.DTOs
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public BrandDto() { }

        public BrandDto(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;
        }
    }
}
