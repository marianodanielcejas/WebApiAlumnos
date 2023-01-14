using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAlumnos.Entidades;

namespace WebApiAlumnos.Controllers
{
    [ApiController]
    [Route("api/Materias")]
    public class MateriasController:ControllerBase  
    {
        private readonly AplicattionDbContext context;

        public MateriasController(AplicattionDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Materia>> Get(int id)
        {
            //Aca traigo una materia pero tambien incluyo al alumno que la cursa.
            return await context.Materias.Include(x => x.Alumno).FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Materia materia)
        {
            var existeAlumno = await context.Alumnos.AnyAsync(x => x.Id == materia.AlumnoId);

            if (!existeAlumno)
            {
                return NotFound($"No existe el alumno con id{materia.AlumnoId}");
            }

            context.Add(materia);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
