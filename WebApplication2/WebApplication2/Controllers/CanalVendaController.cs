using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CanalVendaController : ControllerBase
    {
        private readonly DataContext _context;

        public CanalVendaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetCanalVenda")]
        public List<CanalVenda> Get()
        {
            return _context.CanaisVendas.ToList();
        }

        [HttpPost(Name = "InserirCanalVenda")]
        public async Task<ActionResult<CanalVenda>> PostTodoItem(CanalVenda canalVenda)
        {
            _context.CanaisVendas.Add(canalVenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCanalVenda), new { id = canalVenda.Id }, canalVenda);
        }

        [HttpGet("{id}")]
        public CanalVenda GetCanalVenda(int id)
        {
            var canalVenda = _context.CanaisVendas.Find(id);
            return canalVenda;
        }
    }
}
