namespace backend.Model.Dto
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public string NombrePaciente { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        public static PacienteDto FromEntity(Paciente p) => new()
        {
            Id = p.Id,
            TipoDocumento = p.tipo_documento,
            NumeroDocumento = p.numero_documento,
            NombrePaciente = p.nombre_paciente,
            FechaNacimiento = p.fecha_nacimiento,
            CorreoElectronico = p.correo_electronico,
            Genero = p.genero,
            Direccion = p.direccion,
            Telefono = p.telefono,
            Estado = p.estado,
        };
    }
}
