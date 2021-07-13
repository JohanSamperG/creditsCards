using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using l = BackEnd.Logic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaCreditoController
    {
        private readonly AplicationDbContext _context;
        private l.Logic _logica;

        public TarjetaCreditoController(AplicationDbContext context)
        {
            _context = context;
            _logica = new l.Logic(context);
        }

        // GET: api/TarjetaCreditoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarjetaCredito>>> GetTarjetaCredito()
        {
            return await _logica.GetAll();
        }

        // GET: api/TarjetaCreditoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarjetaCredito>> GetTarjetaCredito(int id)
        {
            return await _logica.GetById(id);
        }

        // PUT: api/TarjetaCreditoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarjetaCredito(int id, TarjetaCredito tarjetaCredito)
        {
            return await _logica.Put(id, tarjetaCredito);
        }

        // POST: api/TarjetaCreditoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TarjetaCredito>> PostTarjetaCredito(TarjetaCredito tarjetaCredito)
        {
            return await _logica.Post(tarjetaCredito);
        }

        // DELETE: api/TarjetaCreditoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarjetaCredito>> DeleteTarjetaCredito(int id)
        {
            return await _logica.Delete(id);
        }

    }
}
