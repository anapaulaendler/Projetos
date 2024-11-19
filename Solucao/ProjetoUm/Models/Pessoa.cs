public abstract class Pessoa
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa (string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public abstract void ExibirDetalhes();
}