namespace Klir.TechChallenge.Domain.Entities
{
    public class Promotion
    {
        public int Id { get; }
        public string Description { get; }
        public int MinQuantity { get; }
        public decimal? Price { get; } 

        public Promotion(int id, string description, int minQuantity, decimal? price)
        {
            Id = id;
            Description = description;
            MinQuantity = minQuantity;
            Price = price;  
        }
    }

}
