using System;
using setup;
using Xunit;

namespace TestsCalculator
{
    public class Tests
    {
        [Fact]
        public void Add_NineAndFour_ResultsEqual_Thirteen()
        {
            string ans = Calculator.Calculate("9 + 4");
            Assert.Equal(ans, "9 + 4 = 13");
        }  
        
        [Fact]
        public void Subtract_NineAndFour_ResultsEqual_Five()
        {
            string ans = Calculator.Calculate("9 - 4");
            Assert.Equal(ans, "9 - 4 = 5");
        }
        
        [Fact]
        public void Multiply_NineAndFour_ResultsEqual_FortyFive()
        {
            string ans = Calculator.Calculate("9 * 4");
            Assert.Equal(ans, "9 * 4 = 36");
        }
        
        [Fact]
        public void Divide_TenAndTwo_ResultsEqual_Five()
        {
            string ans = Calculator.Calculate("10 / 2");
            Assert.Equal(ans, "10 / 2 = 5");
        }
        
        [Fact]
        public void Power_TenAndTwo_ResultsEqual_Hundred()
        {
            string ans = Calculator.Calculate("10 ** 2");
            Assert.Equal(ans, "10 ** 2 = 100");
        }
        
        [Fact]
        public void Add_NineAndFour_ResultsDoesntEqual_Thirteen()
        {
            string ans = Calculator.Calculate("9 +    4");
            Assert.NotEqual(ans, "9 + 4 = 132");
        }  
        
        [Fact]
        public void Subtract_NineAndFour_ResultsDoesntEqual_Five()
        {
            string ans = Calculator.Calculate("9 - 4");
            Assert.NotEqual(ans, "9 - 4 = 25");
        }
        
        [Fact]
        public void Multiply_NineAndFour_ResultsDoesntEqual_FortyFive()
        {
            string ans = Calculator.Calculate("9 * 4");
            Assert.NotEqual(ans, "9 * 4 = 37");
        }
        
        [Fact]
        public void Divide_TenAndTwo_ResultsDoesntEqual_Five()
        {
            string ans = Calculator.Calculate("10 / 2");
            Assert.NotEqual(ans, "10 / 2 = 6");
        }
        
        [Fact]
        public void Power_TenAndTwo_ResultsDoesntEqual_Hundred()
        {
            string ans = Calculator.Calculate("10 ** 2");
            Assert.NotEqual(ans, "10 ** 2 = 10");
        }
    }
}