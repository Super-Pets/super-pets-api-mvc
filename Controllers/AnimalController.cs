using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Animals;
using SuperPetsApi.Data;

namespace SuperPetsApi.Controllers
{
    [ApiController]
    [Route(template:"v1")]
    public class AnimalController : ControllerBase
    {
        [HttpGet]
        [Route(template:"animals")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var Animals = await context
                .Animals
                .AsNoTracking()
                .ToListAsync();

            return Ok(Animals);
        }

        [HttpGet]
        [Route(template: "animals/{id}")]
        public async Task<IActionResult> GetByIdAsync(
        [FromServices] AppDbContext context, 
        [FromRoute] int id)
        {
            var Animals = await context
                .Animals
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return Animals == null
                ? NotFound()
                : Ok();
        }
    }
}
