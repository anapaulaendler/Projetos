namespace CulturalEvents.Interfaces;

public interface IPayment
{
    string ProcessPayment(decimal amount);
    string IssueRecipt();
}