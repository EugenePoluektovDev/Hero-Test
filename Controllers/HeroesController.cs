using HeroTest.DTOs;
using HeroTest.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers;
[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{
    private readonly ILogger<HeroesController> _logger;
    private readonly IHeroService _heroService;

    public HeroesController(ILogger<HeroesController> logger, IHeroService heroService)
    {
        _logger = logger;
        _heroService = heroService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHeroes()
    {
        try
        {
            var result = await _heroService.GetAllActiveHeroesAsync();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddHeroAsync([FromBody] AddHeroDto addHeroDto)
    {
        try
        {
            var result = await _heroService.AddHeroAsync(addHeroDto);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{heroId}")]
    public async Task<IActionResult> DeleteHeroAsync(int heroId)
    {
        try
        {
            await _heroService.DeleteHeroAsync(heroId);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
}

