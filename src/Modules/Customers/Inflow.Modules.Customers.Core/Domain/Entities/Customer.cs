namespace Inflow.Modules.Customers.Core.Domain.Entities;

public sealed class Customer
{
    public Guid Id { get; private set; }

    public string Email { get; private set; }

    public string Name { get; private set; }

    public string FullName { get; private set; }

    public string Address { get; private set; }

    public string Nationality { get; private set; }

    public string Identity { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? CompletedAt { get; private set; }

    public DateTime? VerifiedAt { get; private set; }

    private Customer()
    {
        // EF
    }

    public Customer(Guid id, string email, DateTime createdAt)
    {
        Id = id;
        Email = email;
        CreatedAt = createdAt;
    }
}