using Microsoft.AspNetCore.Mvc;
using WebapiCelulares.Entities;

namespace WebapiCelulares.Controllers
{


    [ApiController]
    [Route("api/celulares")]
    public class CelularesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Celular>> Get()
        {
            return new List<Celular>()
            {
                new Celular() {id = 1, precio = 3000, modelo = "xiaomi redmi 10", descripcion = "precio calidad", id_marca = 1},
                new Celular() {id = 2,precio = 3500, modelo = "samsung a30", descripcion = "buen celular" , id_marca = 2}
            };
        }
    }
}
