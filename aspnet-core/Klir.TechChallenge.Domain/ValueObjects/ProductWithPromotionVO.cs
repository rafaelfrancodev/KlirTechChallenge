using Klir.TechChallenge.Domain.Entities;

namespace Klir.TechChallenge.Domain.ValueObjects
{
    public class ProductWithPromotionVo
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; set; }
        public Promotion Promotion { get; }

        public ProductWithPromotionVo(int id, string name, decimal price, Promotion promotion)
        {
            Id = id;
            Name = name;
            Price = price;
            Promotion = promotion;  
        }

        public void SetPrice(decimal price)
        {
            Price = price;
        }
    }
}
