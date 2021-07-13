using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Logic
{
    public class Logic : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public Logic(AplicationDbContext context) 
        {
            _context = context;
        }
        
        public async Task<ActionResult<IEnumerable<TarjetaCredito>>> GetAll()
        {
            return await _context.TarjetaCredito.ToListAsync();
        }

        public async Task<ActionResult<TarjetaCredito>> GetById(int id)
        {
            var tarjetaCredito = await _context.TarjetaCredito.FindAsync(id);

            if (tarjetaCredito == null)
            {
                return NotFound();
            }

            return tarjetaCredito;
        }

        public async Task<IActionResult> Put(int id, TarjetaCredito tarjetaCredito)
        {
            if (id != tarjetaCredito.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarjetaCredito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetaCreditoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public async Task<ActionResult<TarjetaCredito>> Post(TarjetaCredito tarjetaCredito)
        {
            _context.TarjetaCredito.Add(tarjetaCredito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarjetaCredito", new { id = tarjetaCredito.Id }, tarjetaCredito);
        }


        public async Task<ActionResult<TarjetaCredito>> Delete(int id)
        {
            var tarjetaCredito = await _context.TarjetaCredito.FindAsync(id);
            if (tarjetaCredito == null)
            {
                return NotFound();
            }

            _context.TarjetaCredito.Remove(tarjetaCredito);
            await _context.SaveChangesAsync();

            return tarjetaCredito;
        }

        private bool TarjetaCreditoExists(int id)
        {
            return _context.TarjetaCredito.Any(e => e.Id == id);
        }

    }
}
