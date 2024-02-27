using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IBonoEstadoService
    {
        Task<IEnumerable<BonoEstadoDtoOut>> GetAll();
        Task<BonoEstado?> GetById(int id);
        Task<BonoEstadoDtoOut?> GetDtoById(int id);
        Task<BonoEstado> Create(BonoEstadoDtoIn newBonoEstadoDTO);
        Task Update(int id, BonoEstadoDtoIn bonoEstado);
        Task Delete(int id);
    }
}