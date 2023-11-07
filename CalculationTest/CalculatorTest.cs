using Calculation;

namespace CalculationTest;

public class CalculatorTest
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [TestCase("1 + 2", 3.0)]
    [TestCase("1 - 2", -1.0)]
    [TestCase("2 + 5 * 3 - 4", 13)]
    [TestCase("1.0 + 2 / .3 / ( 0 - 1 )", -5.666666666666667)]
    public void CalculateInfixNotationTest(string expression, double expected)
    {
        var result = _calculator.CalculateInfix(expression);
        Assert.That(result, Is.EqualTo(expected));
    }


    [TestCase("1 / 0")]
    public void DivideByZeroTest(string expression)
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.CalculateInfix(expression));
    }

    [TestCase("1e308 * 1e10")]
    public void OverflowTest(string expression)
    {
        Assert.Throws<OverflowException>(() => _calculator.CalculateInfix(expression));
    }


    [TestCase("+ 3")]
    [TestCase("3 +")]
    public void IncompleteExpressionTest(string expression)
    {
        Assert.Throws<InvalidOperationException>(() => _calculator.CalculateInfix(expression));
    }

    [TestCase("( 3 + 4")]
    public void MismatchedParenthesesTest(string expression)
    {
        Assert.Throws<FormatException>(() => _calculator.CalculateInfix(expression));
    }


    [TestCase("3 + 4 )")]
    public void MismatchedParenthesesTest2(string expression)
    {
        Assert.Throws<InvalidOperationException>(() => _calculator.CalculateInfix(expression));
    }


    [TestCase("3 + + 4")]
    public void ConsecutiveOperatorsTest(string expression)
    {
        Assert.Throws<InvalidOperationException>(() => _calculator.CalculateInfix(expression));
    }


    [TestCase("3.4.5")]
    public void MisusedDecimalPointTest(string expression)
    {
        Assert.Throws<FormatException>(() => _calculator.CalculateInfix(expression));
    }

    [TestCase("+ 1 2", 3.0)]
    [TestCase("- 1 2", -1.0)]
    [TestCase("- + 2 * 5 3 4", 13)]
    [TestCase("+ 1.0 / / 2 .3 - 0 1", -5.666666666666667)]
    public void CalculatePolishNotationTest(string expression, double expected)
    {
        var result = _calculator.CalculatePrefix(expression);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("1 2 +", 3.0)]
    [TestCase("1 2 -", -1.0)]
    [TestCase("2 5 3 * + 4 -", 13)]
    [TestCase("1.0 2 .3 / 0 1 - / +", -5.666666666666667)]
    public void CalculateReversePolishNotationTest(string expression, double expected)
    {
        var result = _calculator.CalculatePostfix(expression);
        Assert.That(result, Is.EqualTo(expected));
    }
}