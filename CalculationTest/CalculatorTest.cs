using Calculation;

namespace CalculationTest;

public class CalculatorTest
{
    [TestCase("1 + 2", 3.0)]
    [TestCase("1 - 2", -1.0)]
    [TestCase("2 + 5 * 3 - 4", 13)]
    [TestCase("1.0 + 2 / .3 / ( 0 - 1 )", -5.666666666666667)]
    public void CalculateInfixNotationTest(string stringNumber, double expected)
    {
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        var result = Calculator.Calculate(infixNotationNumber);
        Assert.That(result, Is.EqualTo(expected));
    }


    [TestCase("1 / 0")]
    public void DivideByZeroTest(string stringNumber)
    {
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        Assert.Throws<DivideByZeroException>(() => Calculator.Calculate(infixNotationNumber));
    }

    [TestCase("1e308 * 1e10")]
    public void OverflowTest(string stringNumber)
    {
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        Assert.Throws<OverflowException>(() => Calculator.Calculate(infixNotationNumber));
    }


    [TestCase("+ 3")]
    [TestCase("3 +")]
    public void IncompleteExpressionTest(string stringNumber)
    {
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        Assert.Throws<InvalidOperationException>(() => Calculator.Calculate(infixNotationNumber));
    }

    [TestCase("( 3 + 4")]
    public void MismatchedParenthesesTest(string stringNumber)
    {
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        Assert.Throws<FormatException>(() => Calculator.Calculate(infixNotationNumber));
    }


    [TestCase("3 + 4 )")]
    public void MismatchedParenthesesTest2(string stringNumber)
    {
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        Assert.Throws<InvalidOperationException>(() => Calculator.Calculate(infixNotationNumber));
    }


    [TestCase("3 + + 4")]
    public void ConsecutiveOperatorsTest(string stringNumber)
    {
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        Assert.Throws<InvalidOperationException>(() => Calculator.Calculate(infixNotationNumber));
    }


    [TestCase("3.4.5")]
    public void MisusedDecimalPointTest(string stringNumber)
    {
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        Assert.Throws<FormatException>(() => Calculator.Calculate(infixNotationNumber));
    }

    [TestCase("+ 1 2", 3.0)]
    [TestCase("- 1 2", -1.0)]
    [TestCase("- + 2 * 5 3 4", 13)]
    [TestCase("+ 1.0 / / 2 .3 - 0 1", -5.666666666666667)]
    public void CalculatePolishNotationTest(string stringNumber, double expected)
    {
        var polishNotationNumber = StringNotation.CreatePolishNotation(stringNumber);
        var result = Calculator.Calculate(polishNotationNumber);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("1 2 +", 3.0)]
    [TestCase("1 2 -", -1.0)]
    [TestCase("2 5 3 * + 4 -", 13)]
    [TestCase("1.0 2 .3 / 0 1 - / +", -5.666666666666667)]
    public void CalculateReversePolishNotationTest(string stringNumber, double expected)
    {
        var polishNotationNumber = StringNotation.CreateReversePolishNotation(stringNumber);
        var result = Calculator.Calculate(polishNotationNumber);
        Assert.That(result, Is.EqualTo(expected));
    }
}