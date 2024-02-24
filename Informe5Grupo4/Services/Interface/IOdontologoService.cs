using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IOdontologoService
    {
        Task<IEnumerable<OdontologoDtoOut>> GetAll();
        Task<Odontologo?> GetById(int id);
        Task<Odontologo> Create(OdontologoDtoIn newOdontologoDTO);
        Task Update(int id, OdontologoDtoIn odontologo);
        Task Delete(int id);
    }
}