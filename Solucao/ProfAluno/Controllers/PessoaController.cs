using Microsoft.AspNetCore.Mvc;
using ProfAluno.Models;

public class PessoaController : Controller
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    public IActionResult Index()
    {
        var pessoas = _pessoaService.Listar();
        return View(pessoas);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Pessoa pessoa)
    {
        if (ModelState.IsValid)
        {
            _pessoaService.Adicionar(pessoa);
            return RedirectToAction(nameof(Index));
        }
        return View(pessoa);
    }

    public IActionResult Delete(string nome)
    {
        _pessoaService.Remover(nome);
        return RedirectToAction(nameof(Index));
    }
}
