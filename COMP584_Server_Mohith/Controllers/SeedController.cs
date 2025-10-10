using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using WorldModel;

namespace COMP584_Server_Mohith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController(Comp584MohithDatabaseContext context,IHostEnvironment environment) : ControllerBase
    {
        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        string _pathName = Path.Combine(environment.ContentRootPath, "Data/worldcities.csv");
        [HttpPost ("Countries")]
        public async Task<ActionResult> PostCountries()
        {

            Dictionary<string, Country> countries = await context.Countries.AsNoTracking()
                .ToDictionaryAsync(c => c.Name, StringComparer.OrdinalIgnoreCase);
            await context.SaveChangesAsync();

            CsvConfiguration config = new(CultureInfo.InvariantCulture) { HasHeaderRecord = true, HeaderValidated = null }; 
            using StreamReader reader = new(_pathName); 
            using CsvReader csv = new(reader, config); 
            List<Comp584MohithDatabaseContext> records = csv.GetRecords<Comp584MohithDatabaseContext>().ToList();

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
