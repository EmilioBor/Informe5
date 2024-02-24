using Core.Request;
using Core.Response;
using Data.Models;

namespace Services
{
    public interface IObraSocialService
    {
        Task<IEnumerable<ObraSocialDtoOut>> GetAll();
        Task<ObraSocial?> GetById(int id);
        Task<ObraSocial> Create(ObraSocialDtoIn newObraSocialDTO);
        Task Update(int id, ObraSocialDtoIn obraSocial);
        Task Delete(int id);
    }
}