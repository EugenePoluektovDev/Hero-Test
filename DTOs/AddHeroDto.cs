using System.ComponentModel.DataAnnotations;

namespace HeroTest.DTOs
{
    public class AddHeroDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Alias { get; set; } = null!;

        [Required]
        public int BrandId { get; set; }
    }
}
