using backend.Model;
using backend.Model.Dto;
using backend.Repositories;

namespace backend.Services
{
    public class PacienteService(PacienteRepository pacienteRepository)
    {


        public async Task<Response<List<PacienteDto>>> GetPacientesAll()
        {
            try
            {

                var pacientes = await pacienteRepository.GetPacientesAll();

                return Response<List<PacienteDto>>.Success(pacientes.Select(PacienteDto.FromEntity).ToList());
            }
            catch (Exception e)
            {
                return Response<List<PacienteDto>>.Fail("ocurrio un problema al consultar los pacientes" + e.Message, StatusCodes.Status500InternalServerError);
            }

            
        }

        public async Task<Response<PacienteDto>> CreatePaciente(CreatePacienteDto dto)
        {
            try
            {
                var paciente = dto.ToEntity();

                paciente.Id = await pacienteRepository.CreatePaciente(paciente);

                return Response<PacienteDto>.Success(
                    PacienteDto.FromEntity(paciente),
                    "Paciente creado correctamente",
                    StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return Response<PacienteDto>.Fail("ocurrio un problema al crear el paciente" + e.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
