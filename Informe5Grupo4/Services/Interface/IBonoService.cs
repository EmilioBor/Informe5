using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IBonoService
    {
        Task<IEnumerable<BonoDtoOut>> GetAll();
        Task<Bono?> GetById(int id);
        Task<BonoDtoOut?> GetDtoById(int id);
        Task<Bono> Create(BonoDtoIn newBonoDTO);
        Task Update(int id, BonoDtoIn bono);
        Task Delete(int id);
    }
}