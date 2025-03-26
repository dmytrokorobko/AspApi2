namespace AspApi2Server.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public float Price { get; set; }
    public string Category { get; set; }
}

public class BaseEntity
{
    public Guid Id { get; set; }
}