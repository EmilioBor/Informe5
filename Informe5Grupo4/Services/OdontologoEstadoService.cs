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
    public class OdontologoEstadoService : IOdontologoEstadoService
    {
        private readonly Informe4Context _context;
        public OdontologoEstadoService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OdontologoEstadoDtoOut>> GetAll()
        {
            return await _context.OdontologoEstado.Select(n => new OdontologoEstadoDtoOut
            {
                //Id = n.Id,
                Nombre = n.Nombre
            }).ToListAsync();

        }

        public async Task<OdontologoEstadoDtoOut?> GetDtoById(int id)
        {
            return await _context.OdontologoEstado
                .Where(n => n.Id == id)
                .Select(n => new OdontologoEstadoDtoOut
                {
                    //Id = n.Id,
                    Nombre = n.Nombre

                }).SingleOrDefaultAsync();

        }

        public async Task<OdontologoEstado?> GetById(int id)
        {
            return await _context.OdontologoEstado.FindAsync(id);
        }

        public async Task<OdontologoEstado> Create(OdontologoEstadoDtoIn newOdontologoEstadoDTO)
        {
            var newOdontologoEstado = new OdontologoEstado();

            newOdontologoEstado.Nombre = newOdontologoEstadoDTO.Nombre;


            _context.OdontologoEstado.Add(newOdontologoEstado);
            await _context.SaveChangesAsync();

            return newOdontologoEstado;

        }

        public async Task Update(int id, OdontologoEstadoDtoIn odontologoEstado)
        {
            var existingOdontologoEstado = await GetById(id);

            if (existingOdontologoEstado is not null)
            {


                existingOdontologoEstado.Nombre = odontologoEstado.Nombre;


                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var odontologoEstadoToDelete = await GetById(id);

            if (odontologoEstadoToDelete is not null)
            {

                _context.OdontologoEstado.Remove(odontologoEstadoToDelete);
                await _context.SaveChangesAsync();
            }

        }

        Task<IEnumerable<ProvinciaDtoOut>> IOdontologoEstadoService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Provincia?> IOdontologoEstadoService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Provincia> Create(ProvinciaDtoIn newProvinciaDTO)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, ProvinciaDtoIn provincia)
        {
            throw new NotImplementedException();
        }
    }
}
