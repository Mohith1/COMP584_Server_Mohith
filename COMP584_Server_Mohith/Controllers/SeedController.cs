using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldModel;

namespace COMP584_Server_Mohith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController(Comp584MohithDatabaseContext context,IHostEnvironment environment) : ControllerBase
    {
        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        string path = Path.Combine(environment.ContentRootPath, "Data/worldcities.csv");
        [HttpPost ("Countries")]
        public async Task<ActionResult> PostCountries()
        {

            var countries = await context.Countries.ToDictionaryAsync(c => c.Name, StringComparer.OrdinalIgnoreCase);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost ("Cities")]
        public async Task<ActionResult> PostCities()
        {

            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
