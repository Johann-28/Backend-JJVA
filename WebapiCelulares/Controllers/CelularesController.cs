using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebapiCelulares.Entities;

namespace WebapiCelulares.Controllers
{


    [ApiController]
    [Route("api/celulares")]
    public class CelularesController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;

        public CelularesController(AplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        [HttpGet("lista")]
        public async Task<ActionResult<List<Celular>>> Get()
        {
            return await dbContext.Celulares.Include(x => x.marca).ToListAsync(); 
        }

        [HttpPost]
        public async Task<ActionResult> Post(Celular celular)
        {
            dbContext.Add(celular);

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Celular celular, int id)
        {
            if(celular.id != id)
            {
                return BadRequest("El id del alumno no coincide con el establecido en la url");
            }

            dbContext.Update(celular);  
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var exist = await dbContext.Celulares.AnyAsync(x => x.id == id);

            if(!exist)
            {
                return NotFound();
            }

            dbContext.Remove(new Celular()
            {
                id = id
            });
          await dbContext.SaveChangesAsync();
            return Ok();    

        }
    }

    
}
