using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAlumnos.Entidades;

namespace WebApiAlumnos.Controllers
{
    [ApiController]
    [Route("api/alumnos")]
    public class AlumnosController : ControllerBase
    {
        private readonly AplicattionDbContext context;

        public AlumnosController(AplicattionDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Alumno>> Get()
        {
            return await context.Alumnos.Include(x => x.Materias).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Alumno alumno)
        {
            context.Add(alumno);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> put([FromBody] Alumno alumno, [FromRoute] int id)
        {
            if (alumno.Id != id)
            {
                return BadRequest($"El id {id} no coincide con el enviado en el cuerpo");
            }
            var existeAlumno = await context.Alumnos.AnyAsync(x => x.Id == id);

            if (!existeAlumno)
            {
                return NotFound($"No existe el id {id} en la BD");
            }
            context.Update(alumno);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existeAlumno = await context.Alumnos.AnyAsync(x => x.Id == id);
            if (!existeAlumno)
            {
                return NotFound($"Lo sentimos el alumno con id {id} que usted desea eliminar no existe");
            }

            context.Remove(new Alumno() { Id = id});
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
