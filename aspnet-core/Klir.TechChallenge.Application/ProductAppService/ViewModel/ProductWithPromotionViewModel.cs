using Klir.TechChallenge.Domain.Entities;

namespace Klir.TechChallenge.Application.ProductAppService.ViewModel
{
    public class ProductWithPromotionViewModel
    {
        public ProductWithPromotionViewModel()
        {}

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Promotion Promotion { get; set; }
    }
}
