namespace Klir.TechChallenge.Infra.CrossCutting
{
    public static class RangeNumbers
    {

        public static int GetTotalNumbersOutOfRange(int quantity,  int defaultRange)
        {
            var range = GetRangeNumbers(quantity, defaultRange);

            if (range == 0) return 0;
            
            var total = quantity / (float) range;
            if (total > defaultRange)
            {
                return quantity - (range * defaultRange);
            }

            return 0;
        }

        public static int GetRangeNumbers(int quantity, int range)
        {
            var countRange = 0;
            var sumRange = 0;

            for (int i = 1; i <= quantity; i++)
            {
                countRange++;
                if (countRange == range)
                {
                    countRange = 0;
                    sumRange += 1;
                }
            }
            return sumRange;
        }
    }
}
