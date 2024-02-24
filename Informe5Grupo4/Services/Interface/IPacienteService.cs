using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDtoOut>> GetAll();
        Task<Paciente?> GetById(int id);
        Task<Paciente> Create(PacienteDtoIn newPacienteDTO);
        Task Update(int id, PacienteDtoIn paciente);
        Task Delete(int id);
    }
}