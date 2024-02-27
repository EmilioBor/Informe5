using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IEntregaService
    {
        Task<IEnumerable<EntregaDtoOut>> GetAll();
        Task<Entrega?> GetById(int id);
        Task<EntregaDtoOut?> GetDtoById(int id);
        Task<Entrega> Create(EntregaDtoIn newEntregaDTO);
        Task Update(int id, EntregaDtoIn entrega);
        Task Delete(int id);
    }
}