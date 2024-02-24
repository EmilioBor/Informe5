using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LocalidadService : ILocalidadService
    {
        private readonly Informe4Context _context;
        public LocalidadService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LocalidadDtoOut>> GetAll()
        {
            return await _context.Localidad.Select(n => new LocalidadDtoOut
            {
                //Id = n.Id,
                Cp = n.Cp,
                Descripcion = n.Descripcion,
                NombreProvincia = n.IdProvinciaNavigation.Descripcion


            }).ToListAsync();

        }

        public async Task<LocalidadDtoOut?> GetDtoById(int id)
        {
            return await _context.Localidad
                .Where(n => n.Id == id)
                .Select(n => new LocalidadDtoOut
                {
                    //Id = n.Id,
                    Cp = n.Cp,
                    Descripcion = n.Descripcion,
                    NombreProvincia = n.IdProvinciaNavigation.Descripcion


                }).SingleOrDefaultAsync();

        }

        public async Task<Localidad?> GetById(int id)
        {
            return await _context.Localidad.FindAsync(id);
        }

        public async Task<Localidad> Create(LocalidadDtoIn newLocalidadDTO)
        {
            var newLocalidad = new Localidad();

            newLocalidad.Cp = newLocalidadDTO.Cp;
            newLocalidad.Descripcion = newLocalidadDTO.Descripcion;
            newLocalidad.IdProvincia = newLocalidadDTO.IdProvincia;
            

            _context.Localidad.Add(newLocalidad);
            await _context.SaveChangesAsync();

            return newLocalidad;

        }

        public async Task Update(int id, LocalidadDtoIn localidad)
        {
            var existingLocalidad = await GetById(id);

            if (existingLocalidad is not null)
            {


                existingLocalidad.Cp = localidad.Cp;
                existingLocalidad.Descripcion = localidad.Descripcion;
                existingLocalidad.IdProvincia = localidad.IdProvincia;


                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var localidadToDelete = await GetById(id);

            if (localidadToDelete is not null)
            {

                _context.Localidad.Remove(localidadToDelete);
                await _context.SaveChangesAsync();
            }

        }
    }
}
