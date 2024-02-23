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
    public class EntregaService : IEntregaService
    {
        private readonly Informe4Context _context;
        public EntregaService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EntregaDtoOut>> GetAll()
        {
            return await _context.Entrega.Select(n => new EntregaDtoOut
            {
                //Id = n.Id,
                
                Desde = n.Desde,
                Hasta = n.Hasta,
                NombreObraSocial =n.IdObraSocialNavigation.Nombre,
                NombreOdontologo = n.IdOdontologoNavigation.Nombre


            }).ToListAsync();

        }

        public async Task<EntregaDtoOut?> GetDtoById(int id)
        {
            return await _context.Entrega
                .Where(n => n.Id == id)
                .Select(n => new EntregaDtoOut
                {
                    //Id = n.Id,
                    Desde = n.Desde,
                    Hasta = n.Hasta,
                    NombreObraSocial = n.IdObraSocialNavigation.Nombre,
                    NombreOdontologo = n.IdOdontologoNavigation.Nombre

                }).SingleOrDefaultAsync();

        }

        public async Task<Entrega?> GetById(int id)
        {
            return await _context.Entrega.FindAsync(id);
        }

        public async Task<Entrega> Create(EntregaDtoIn newEntregaDTO)
        {
            var newEntrega = new Entrega();

            newEntrega.Desde = newEntregaDTO.Desde;
            newEntrega.Hasta = newEntregaDTO.Hasta;
            newEntrega.IdObraSocial = newEntregaDTO.IdObraSocial;
            newEntrega.IdOdontologo = newEntregaDTO.IdOdontologo;

            _context.Entrega.Add(newEntrega);
            await _context.SaveChangesAsync();

            return newEntrega;

        }

        public async Task Update(int id, EntregaDtoIn entrega)
        {
            var existingEntrega = await GetById(id);

            if (existingEntrega is not null)
            {

                
                existingEntrega.Desde = entrega.Desde;
                existingEntrega.Hasta = entrega.Hasta;
                existingEntrega.IdObraSocial = entrega.IdObraSocial;
                existingEntrega.IdOdontologo = entrega.IdOdontologo;

                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var entregaToDelete = await GetById(id);

            if (entregaToDelete is not null)
            {

                _context.Entrega.Remove(entregaToDelete);
                await _context.SaveChangesAsync();
            }

        }

        Task<IEnumerable<ProvinciaDtoOut>> IEntregaService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Provincia?> IEntregaService.GetById(int id)
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
