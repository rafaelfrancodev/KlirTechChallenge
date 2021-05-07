namespace Klir.TechChallenge.Domain.Entities
{
    public class ProductPromotion
    {
        public Product Product { get; }
        public Promotion Promotion { get; }

        public ProductPromotion(Product product, Promotion promotion)
        {
            Product = product;
            Promotion = promotion;
        }
    }
}
