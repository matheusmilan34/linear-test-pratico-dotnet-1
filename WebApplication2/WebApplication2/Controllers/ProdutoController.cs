using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProdutoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetProduto")]
        public List<Produto> Get([FromQuery] string? descricao)
        {
            if (descricao == null)
                return _context.Produtos.ToList();
            var teste = _context.Produtos.Where(x => x.Descricao == descricao).ToList();
            return _context.Produtos.Where(x => x.Descricao == descricao).ToList();
        }

        [HttpPost(Name = "InserirProduto")]
        public async Task<ActionResult<Produto>> PostTodoItem(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpGet("{id}")]
        public Produto GetProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            return produto;
        }
    }
}
