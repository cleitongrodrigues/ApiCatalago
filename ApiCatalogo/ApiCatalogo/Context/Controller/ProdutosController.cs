using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiCatalogo.Context.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        // CONSTRUTOR
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get() // Retorna uma lista de produtos
        {
            var produtos = _context.Produtos.ToList();

            if (produtos is null)
            {
                // Necessário utilizar o ActionResult para retornar o NotFound
                return NotFound("Produtos não encontrados.");
            }

            return produtos;
        }

        [HttpGet("{id:int}", Name= "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado.");
            }

            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                return BadRequest();
            }

            // Adiciona o produto ao contexto (em memória)
            _context.Produtos.Add(produto);

            // Salva o produto no banco de dados
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            // FORÇA A ATUALIZAÇÃO DE TODOS OS CAMPOS DO PRODUTO
            _context.Entry(produto).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado.");
            }

            _context.Produtos.Remove(produto);

            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
