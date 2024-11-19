namespace ProfAluno.Models;

public class Professor : Pessoa
{
    public required string Disciplina { get; set; }

    public Professor (string nome, int idade, string disciplina)
        : base(nome, idade)
    {
        Disciplina = disciplina;
    }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"Professor: {Nome}, Idade: {Idade}, Disciplina: {Disciplina}");
    }
}