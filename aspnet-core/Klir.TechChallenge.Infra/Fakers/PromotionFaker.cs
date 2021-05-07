using Klir.TechChallenge.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Infra.Fakers
{
    [ExcludeFromCodeCoverage]
    public static class PromotionFaker
    {
        public static Promotion CreateBuyOneGetOneFree()
        {
            return new Promotion(1, "Buy 1 Get 1 Free");
        }

        public static Promotion CreateThreeForTenEuro()
        {
            return new Promotion(1, "3 for 10 Euro");
        }
    }
}
