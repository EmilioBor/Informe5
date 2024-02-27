using Core.Request;
using Core.Response;
using Data.Models;

namespace Services
{
    public interface ILocalidadService
    {
        Task<IEnumerable<LocalidadDtoOut>> GetAll();
        Task<Localidad?> GetById(int id);
        Task<LocalidadDtoOut?> GetDtoById(int id);
        Task<Localidad> Create(LocalidadDtoIn newLocalidadDTO);
        Task Update(int id, LocalidadDtoIn localidad);
        Task Delete(int id);
    }
}