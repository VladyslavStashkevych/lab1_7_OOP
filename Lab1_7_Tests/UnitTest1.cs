using lab1_7;
using Xunit;
using System;

namespace Lab1_7_Tests {
	public class UnitTest1 {
		[Theory]
		[InlineData(3)]
		[InlineData(314.2)]
		public void Methods_GetAndSetSum_Work(double s) {
			//Arrange
			Money m = new Money();
			
			//Act
			m.SetSum(s);

			//Assert
			Assert.Equal(s, m.GetSum());
		}
		[Theory]
		[InlineData(3, 2)]
		[InlineData(314.2, 1.23)]
		public void Method_Multiply_ReturnsCorrectValue(double s, double n) {
			//Arrange
			Money m = new Money();
			m.Init(s);
			double exp = Math.Round(s * n, 2, MidpointRounding.ToZero);

			//Act
			Money result = m.Multiply(n);

			//Assert
			Assert.Equal(exp, result.GetSum());
		}
	}
}