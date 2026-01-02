using Restaurant.Domain.Common;

namespace Restaurant.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; }

    private Category() { } // Para ORM (más adelante)

    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name is required");

        Name = name;
    }
}
