using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IOdontologoEstadoService
    {
        Task<IEnumerable<OdontologoEstadoDtoOut>> GetAll();
        Task<OdontologoEstado?> GetById(int id);
        Task<OdontologoEstado> Create(OdontologoEstadoDtoIn newOdontologoEstadoDTO);
        Task Update(int id, OdontologoEstadoDtoIn odontologoEstado);
        Task Delete(int id);
    }
}