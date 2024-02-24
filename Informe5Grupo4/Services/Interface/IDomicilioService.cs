using Core.Request;
using Core.Response;
using Data.Models;

namespace Services
{
    public interface IDomicilioService
    {
        Task<IEnumerable<DomicilioDtoOut>> GetAll();
        Task<Domicilio?> GetById(int id);
        Task<Domicilio> Create(DomicilioDtoIn newDomicilioDTO);
        Task Update(int id, DomicilioDtoIn domicilio);
        Task Delete(int id);
    }
}