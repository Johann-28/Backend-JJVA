using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebapiCelulares.Entities;

namespace WebapiCelulares.Controllers
{
    [ApiController]
    [Route("api/marca")]
    public class MarcaController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public MarcaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetById(int id)
        {
            return await _context.Marcas.FirstOrDefaultAsync(x => x.id == id);
        }


        [HttpGet]
        public async Task<ActionResult<List<Marca>>> GetAll()
        {
            return await _context.Marcas.Include(x => x.celulares).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Marca marca)
        {
            var existeMarca = await _context.Marcas.AnyAsync(x => x.id == marca.id);

            if (!existeMarca) {
                return BadRequest("No existe la marca");
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Marca marca, int id)
        {
            var exist = await _context.Marcas.AnyAsync(x =>x.id == id);


            if (!exist)
            {
                return BadRequest("La marca no existe");
            }

            _context.Update(marca);
            await _context.SaveChangesAsync();
            return Ok();    
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var exist = await _context.Marcas.AnyAsync(x => x.id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Remove(new Marca()
            {
                id = id
            });
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}
