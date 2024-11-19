
namespace ProfAluno.Models;

public class PessoaInterface : IPessoaService
{
    private readonly List<Pessoa> _pessoas = new List<Pessoa>();

    public void Adicionar(Pessoa pessoa)
    {
        _pessoas.Add(pessoa);
    }

    public List<Pessoa> Listar()
    {
        return _pessoas;
    }

    public void Remover(string nome)
    {
        var pessoa = _pessoas.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

        if (pessoa != null)
        {
            _pessoas.Remove(pessoa);
        }
    }
}