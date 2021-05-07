namespace Klir.TechChallenge.Domain.Entities
{
    public class Product
    {
        public int Id { get; }
        public string Name { get;  }
        public decimal Price { get;  }
        public Promotion Promotion { get; }

        public Product(int id, string name, decimal price, Promotion promotion)
        {
            Id = id;
            Name = name;
            Price = price;
            Promotion = promotion;  
        }
    }
}
