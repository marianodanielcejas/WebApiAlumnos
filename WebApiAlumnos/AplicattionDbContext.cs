using Microsoft.EntityFrameworkCore;
using WebApiAlumnos.Entidades;

namespace WebApiAlumnos
{
    //Clase que maneja mi base de datos
    public class AplicattionDbContext:DbContext
    {
        public AplicattionDbContext(DbContextOptions Options) : base (Options)
        {

        }

        public DbSet<Alumno>Alumnos { get; set; }

        public DbSet<Materia>Materias { get; set; }
    }
}
