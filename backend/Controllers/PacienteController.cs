using backend.Model.Dto;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController(PacienteService pacienteService) : ControllerBase
    {
        // GET: PacienteController
        [HttpGet()]
        public async Task<ActionResult> GetPacientesAll()
        {

            var pacientes = await pacienteService.GetPacientesAll();

            return StatusCode(pacientes.StatusCode,pacientes);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePaciente([FromBody] CreatePacienteDto dto)
        {
            var paciente = await pacienteService.CreatePaciente(dto);

            return StatusCode(paciente.StatusCode, paciente);
        }
    }
}
