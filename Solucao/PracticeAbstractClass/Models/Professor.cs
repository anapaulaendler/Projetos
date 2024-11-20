namespace PracticeAbstractClass.Models;

public class Professor : Person
{
    public required string Course { get; set; }

    public Professor (string name, int age, string course)
        : base(name, age)
    {
        Course = course;
    }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"Professor: {Name}, Age: {Age}, Course: {Course}");
    }
}