using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCalculatorProject;

namespace DiscountCalculatorXUnit
{
    /**
    * Sample Requirements:
       A higher sales amount results in a higher discount.
       The discount percentage should be determined based on predefined ranges:
           Sales amount below 100: 0% discount
           Sales amount between 100 and 500: 10% discount
           Sales amount between 500 and 1000: 20% discount
           Sales amount above 1000: 30% discount
   
   Calculate the final price based on the discount percentage.

    * */

    public class DiscountCalculatorTests
    {
        // write your unit test methods over here

        // Sales amount below 100: 0% discount

        [Fact]
        public void salesBelow100ShouldHave_0_Discount()
        {
            //assign or arrange
            // need a class for dicount calculator and create new instance of discount calculator
            // assume sales price as 50

            var discCalcr = new DiscountCalculator();
            decimal salesAmount = 50;


            //act

            var finalPrice= discCalcr.CalculateTheFinalPrice(salesAmount);


            //assert

            Assert.Equal(50, finalPrice);

        }

        //[Fact]
        //public void salesBetween100_and_500_ShouldHave_10_Discount()
        //{
        //    //assign or arrange
        //    // need a class for dicount calculator and create new instance of discount calculator
        //    // assume sales price as 50

        //    var discCalcr = new DiscountCalculator();
        //    decimal salesAmount = 200;


        //    //act

        //    var finalPrice = discCalcr.CalculateTheFinalPrice(salesAmount);


        //    //assert

        //    Assert.Equal(180, finalPrice);

        //}

        [Theory]
        [InlineData(200, 180)]
        [InlineData(300, 270)]
        [InlineData(400, 360)]

        public void salesBetween100_and_500_ShouldHave_10_Discount(decimal salesAmount, decimal expected)
        {
            //assign or arrange
            // need a class for dicount calculator and create new instance of discount calculator
            // assume sales price as 50

            var discCalcr = new DiscountCalculator();
            //decimal salesAmount = 200;


            //act

            var finalPrice = discCalcr.CalculateTheFinalPrice(salesAmount);


            //assert

            Assert.Equal(expected, finalPrice);

        }
    }
}
