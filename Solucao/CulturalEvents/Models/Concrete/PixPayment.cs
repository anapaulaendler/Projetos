using CulturalEvents.Interfaces;

namespace CulturalEvents.Models;

public class PixPayment : IPayment, IEntity
{
    public Guid Id { get; set; }
    public void IssueRecipt()
    {
        throw new NotImplementedException();
    }

    public void ProcessPayment(decimal amount)
    {
        throw new NotImplementedException();
    }
}
