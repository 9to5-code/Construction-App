namespace SignUp.Tests;

public class UnitTest1
{
    public class CalculatorTests
    {
        [Fact]  // This marks the method as a test case
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(2, 3);

            // Assert
            Assert.Equal(5, result);
        }

[Theory]
[InlineData(2, 3, 5)]
[InlineData(0, 0, 0)]
[InlineData(-1, -1, -2)]
public void Add_ShouldWorkForMultipleInputs(int a, int b, int expected)
{
    var calculator = new Calculator();
    var result = calculator.Add(a, b);
    Assert.Equal(expected, result);
}

    }

    // Example class being tested
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
    }
}