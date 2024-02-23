using Core.Request;
using Core.Response;
using Data.Models;

namespace Services
{
    public interface ILocalidadService
    {
        Task<IEnumerable<ProvinciaDtoOut>> GetAll();
        Task<Provincia?> GetById(int id);
        Task<Provincia> Create(ProvinciaDtoIn newProvinciaDTO);
        Task Update(int id, ProvinciaDtoIn provincia);
        Task Delete(int id);
    }
}