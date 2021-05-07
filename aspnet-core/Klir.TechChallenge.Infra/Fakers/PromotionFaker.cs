using Klir.TechChallenge.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Infra.Fakers
{
    [ExcludeFromCodeCoverage]
    public static class PromotionFaker
    {
        public static Promotion CreateBuyTwoGetOneFree()
        {
            return new Promotion(1, "Buy 2 Get 1 Free", 2, null);
        }

        public static Promotion CreateThreeForTenEuro()
        {
            return new Promotion(1, "3 for 10 Euro", 3, 10);
        }
    }
}
