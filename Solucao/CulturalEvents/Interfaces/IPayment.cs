namespace CulturalEvents.Interfaces;

public interface IPayment
{
    void ProcessPayment(decimal amount);
    void IssueRecipt();
}