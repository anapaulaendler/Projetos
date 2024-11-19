public class Aluno : Pessoa
{
    public required string Curso { get; set; }

    public Aluno(string nome, int idade, string curso) : base(nome, idade)
    {
        Curso = curso;
    }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"Aluno: {Nome}, Idade: {Idade}, Curso: {Curso}");
    }
}