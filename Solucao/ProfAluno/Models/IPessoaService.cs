namespace ProfAluno.Models;

public interface IPessoaService
{
    void Adicionar(Pessoa pessoa);
    void Remover(string nome);
    List<Pessoa> Listar();
}
