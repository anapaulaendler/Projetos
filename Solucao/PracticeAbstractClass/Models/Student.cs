namespace PracticeAbstractClass.Models;

public class Student : Person
{
    public required string Major { get; set; }
    
    public Student (string name, int age, string major)
        : base(name, age)
    {
        Major = major;
    }

    public override string ExibirDetalhes()
    {
        return $"Student: {Name}, Age: {Age}, Major: {Major}";
    }
}