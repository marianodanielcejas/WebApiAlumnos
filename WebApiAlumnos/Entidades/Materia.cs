namespace WebApiAlumnos.Entidades
{
    public class Materia
    {
        public int Id { get; set; }

        public string NombreMateria { get; set; }

        public int AlumnoId { get; set; }

        public Alumno Alumno { get; set; }
    }
}
