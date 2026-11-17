namespace backend.Model
{
    public class Paciente
    {

        public int Id { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string nombre_paciente { get; set; }
        public DateOnly fecha_nacimiento { get; set; }
        public string correo_electronico { get; set; }
        public string genero { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string estado { get; set; }


    }
}
