namespace WebApiAlumnos.Entidades
{
    public class Alumno
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public List<Materia> Materias { get; set; }
    }
}
