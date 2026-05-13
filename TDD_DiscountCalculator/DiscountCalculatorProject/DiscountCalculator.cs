namespace DiscountCalculatorProject
{
    public class DiscountCalculator
    {
        //write your finction definitions
        public decimal CalculateTheFinalPrice(decimal salesAmount)
        {
            decimal discountedPercentage = GetDicountPercentage(salesAmount);
            decimal discountAmount = salesAmount * discountedPercentage / 100;
            decimal finalPrice = salesAmount - discountAmount;
            return finalPrice;
        }

        public decimal GetDicountPercentage(decimal salesAmount)
        {
            if (salesAmount < 100)
            {
                return 0;
            }
            else if (salesAmount >= 100 && salesAmount < 500)
            {
                return 10;
            }
            else if (salesAmount >= 500 && salesAmount < 1000)
            {
                return 20;
            }
            else
                return 30;
        }
    }
}
