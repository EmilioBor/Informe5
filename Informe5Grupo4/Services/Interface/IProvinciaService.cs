using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IProvinciaService
    {
        Task<IEnumerable<ProvinciaDtoOut>> GetAll();
        Task<Provincia?> GetById(int id);
        Task<Provincia> Create(ProvinciaDtoIn newProvinciaDTO);
        Task Update(int id, ProvinciaDtoIn provincia);
        Task Delete(int id);
    }
}