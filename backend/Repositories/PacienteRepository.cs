using backend.Data;
using backend.Model;
using backend.Model.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace backend.Repositories
{
    public class PacienteRepository(DbconnectionMedicos connection)
    {
        public async Task<List<Paciente>> GetPacientesAll()
        {
                
            using var createConnection = connection.CreateConnection();

            using var command = new SqlCommand("GetAllPacientes", createConnection);

            await createConnection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            var pacientes = new List<Paciente>();

            while( await reader.ReadAsync())
            {
                var pac = new Paciente
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    tipo_documento = reader.GetString(reader.GetOrdinal("tipo_documento")),
                    numero_documento = reader.GetString(reader.GetOrdinal("numero_documento")),
                    nombre_paciente = reader.GetString(reader.GetOrdinal("nombre_paciente")),
                    fecha_nacimiento = DateOnly.FromDateTime( reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento"))),
                    correo_electronico = reader.GetString(reader.GetOrdinal("correo_electronico")),
                    genero = reader.GetString(reader.GetOrdinal("genero")),
                    direccion = reader.GetString(reader.GetOrdinal("direccion")),
                    telefono = reader.GetString(reader.GetOrdinal("telefono")),
                    estado = reader.GetString(reader.GetOrdinal("estado")),

                };

                pacientes.Add(pac);
            }





            return pacientes;
        }

        public async Task<int> CreatePaciente(Paciente paciente)
        {
            using var createConnection = connection.CreateConnection();

            using var command = new SqlCommand("CreatePaciente", createConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@tipo_documento", paciente.tipo_documento);
            command.Parameters.AddWithValue("@numero_documento", paciente.numero_documento);
            command.Parameters.AddWithValue("@nombre_paciente", paciente.nombre_paciente);
            command.Parameters.AddWithValue("@fecha_nacimiento", paciente.fecha_nacimiento.ToDateTime(TimeOnly.MinValue));
            command.Parameters.AddWithValue("@correo_electronico", paciente.correo_electronico);
            command.Parameters.AddWithValue("@genero", paciente.genero);
            command.Parameters.AddWithValue("@direccion", paciente.direccion);
            command.Parameters.AddWithValue("@telefono", paciente.telefono);
            command.Parameters.AddWithValue("@estado", paciente.estado);

            await createConnection.OpenAsync();

            var id = await command.ExecuteScalarAsync();

            return Convert.ToInt32(id);
        }
    }
}
