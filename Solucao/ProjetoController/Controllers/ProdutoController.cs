using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
namespace ProjetoController.Controllers;

[ApiController]
[Route("api/produtos/")]
public class ProdutoController : ControllerBase
{
    private static List<Produto> _produtos = new List<Produto>
    {
        new Produto { Id = 1, Nome = "Laptop", Preco = 1000.00m, Categoria = "Eletronicos" },
        new Produto { Id = 2, Nome = "Desktop", Preco = 2000.00m, Categoria = "Eletronicos" },
        new Produto { Id = 3, Nome = "Mobile", Preco = 3000.00m, Categoria = "Eletronicos" },
    };


    // listar
    [HttpGet]
    public ActionResult<IEnumerable<Produto>> GetProdutos()
    {
        return _produtos;
    }

    // buscar
    [HttpGet("{id}")]
    public ActionResult<Produto> GetProduto(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
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
        _produtos.Add(produto);
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

        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto is null)
        {
            return NotFound();
        }

        produto.Nome = produtoAlterado.Nome;
        produto.Categoria = produtoAlterado.Categoria;
        produto.Preco = produtoAlterado.Preco;

        return NoContent();
    }

    // deletar
    [HttpDelete("{id}")]
    public IActionResult DeleteProduto(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto is null)
        {
            return NotFound();
        }

        _produtos.Remove(produto);
        return NoContent();  
    }
}
