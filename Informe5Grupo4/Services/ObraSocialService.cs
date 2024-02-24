using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ObraSocialService : IObraSocialService
    {
        private readonly Informe4Context _context;
        public ObraSocialService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ObraSocialDtoOut>> GetAll()
        {
            return await _context.ObraSocial.Select(n => new ObraSocialDtoOut
            {
                //Id = n.Id,
                Nombre = n.Nombre


            }).ToListAsync();

        }

        public async Task<ObraSocialDtoOut?> GetDtoById(int id)
        {
            return await _context.ObraSocial
                .Where(n => n.Id == id)
                .Select(n => new ObraSocialDtoOut
                {
                    //Id = n.Id,
                    Nombre = n.Nombre

                }).SingleOrDefaultAsync();

        }

        public async Task<ObraSocial?> GetById(int id)
        {
            return await _context.ObraSocial.FindAsync(id);
        }

        public async Task<ObraSocial> Create(ObraSocialDtoIn newObraSocialDTO)
        {
            var newObraSocial = new ObraSocial();

            newObraSocial.Nombre = newObraSocialDTO.Nombre;
            


            _context.ObraSocial.Add(newObraSocial);
            await _context.SaveChangesAsync();

            return newObraSocial;

        }

        public async Task Update(int id, ObraSocialDtoIn obraSocial)
        {
            var existingObraSocial = await GetById(id);

            if (existingObraSocial is not null)
            {

                existingObraSocial.Nombre = obraSocial.Nombre;
                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var obraSocialToDelete = await GetById(id);

            if (obraSocialToDelete is not null)
            {

                _context.ObraSocial.Remove(obraSocialToDelete);
                await _context.SaveChangesAsync();
            }

        }
    }
}
