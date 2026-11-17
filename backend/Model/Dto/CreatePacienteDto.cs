using System.ComponentModel.DataAnnotations;

namespace backend.Model.Dto
{
    public class CreatePacienteDto
    {
        [Required, StringLength(50)]
        public string TipoDocumento { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string NumeroDocumento { get; set; } = string.Empty;

        [Required, StringLength(120)]
        public string NombrePaciente { get; set; } = string.Empty;

        [Required]
        public DateOnly FechaNacimiento { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string CorreoElectronico { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Genero { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Direccion { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Estado { get; set; } = string.Empty;

        public Paciente ToEntity() => new()
        {
            tipo_documento = TipoDocumento,
            numero_documento = NumeroDocumento,
            nombre_paciente = NombrePaciente,
            fecha_nacimiento = FechaNacimiento,
            correo_electronico = CorreoElectronico,
            genero = Genero,
            direccion = Direccion,
            telefono = Telefono,
            estado = Estado,
        };
    }
}
