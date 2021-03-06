namespace Klir.TechChallenge.Domain.Entities
{
    public class Product
    {
        public int Id { get; }
        public string Name { get;  }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
