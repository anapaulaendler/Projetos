using CulturalEvents.Interfaces;

namespace CulturalEvents.Models;

public class CardPayment : IPayment
{
    public void IssueRecipt()
    {
        throw new NotImplementedException();
    }

    public void ProcessPayment(decimal amount)
    {
        throw new NotImplementedException();
    }
}
