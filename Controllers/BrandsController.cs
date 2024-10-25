using HeroTest.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var result = await _brandService.GetAllActiveBrandAsync();

            return Ok(result);
        }
    }
}
