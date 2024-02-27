using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IPracticaService
    {
        Task<IEnumerable<PracticaDtoOut>> GetAll();
        Task<Practica?> GetById(int id);
        Task<PracticaDtoOut?> GetDtoById(int id);
        Task<Practica> Create(PracticaDtoIn newPracticaDTO);
        Task Update(int id, PracticaDtoIn practica);
        Task Delete(int id);
    }
}