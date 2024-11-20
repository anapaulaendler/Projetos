namespace PracticeAbstractClass.Models;

public abstract class Person
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }

    public Person (string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void ExibirDetalhes();
}