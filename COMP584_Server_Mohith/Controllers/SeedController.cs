using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldModel;

namespace COMP584_Server_Mohith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController(Comp584MohithDatabaseContext context) : ControllerBase
    {
        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost ("Countries")]
        public async Task<ActionResult> PostCountries()
        {
           
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
