using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ProjetoController.Controllers;

[ApiController]
[Route("api/produtos/")]
public class ProdutoController : ControllerBase
{

    private readonly AppDataContext _ctx;
    public ProdutoController(AppDataContext ctx)
    {
        _ctx = ctx;
    }

    // listar
    [HttpGet]
    public ActionResult<IEnumerable<Produto>> GetProdutos()
    {
        return _ctx.Produtos.ToList();
    }

    // buscar
    [HttpGet("{id}")]
    public ActionResult<Produto> GetProduto(int id)
    {
        var produto = _ctx.Produtos.FirstOrDefault(p => p.Id == id);
        if (produto is null)
        {
            return NotFound();
        }
        return produto;
    }

    // cadastrar
    [HttpPost]
    public ActionResult<Produto> PostProduto(Produto produto)
    {
        _ctx.Produtos.Add(produto);
        return CreatedAtAction(nameof(GetProduto), new {id = produto.Id}, produto);
    }

    // update
    [HttpPut("{id}")]
    public  ActionResult<Produto> PutProduto(int id, Produto produtoAlterado)
    {
        if (id != produtoAlterado.Id)
        {
            return BadRequest();
        }

        var produto = _ctx.Produtos.FirstOrDefault(p => p.Id == id);
        if (produto is null)
        {
            return NotFound();
        }

        produto.Nome = produtoAlterado.Nome;
        produto.Categoria = produtoAlterado.Categoria;
        produto.Preco = produtoAlterado.Preco;
        _ctx.Update(produto);

        return NoContent();
    }

    // deletar
    [HttpDelete("{id}")]
    public IActionResult DeleteProduto(int id)
    {
        var produto = _ctx.Produtos.FirstOrDefault(p => p.Id == id);
        if (produto is null)
        {
            return NotFound();
        }

        _ctx.Produtos.Remove(produto);
        return NoContent();  
    }
}
