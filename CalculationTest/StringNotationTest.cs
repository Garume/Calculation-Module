using Calculation.NotationParser;

namespace CalculationTest;

public class StringNotationTest
{
    [Test]
    public void ConvertToReversePolishNotationTest1()
    {
        const string expression = "1 + 2";

        var notationParser = new InfixNotationParser();
        var postfixExpression = notationParser.Convert2Postfix(expression);
        Assert.That(postfixExpression, Is.EqualTo("1 2 +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest2()
    {
        const string expression = "1 - 2 + 3";
        var notationParser = new InfixNotationParser();
        var postfixExpression = notationParser.Convert2Postfix(expression);
        Assert.That(postfixExpression, Is.EqualTo("1 2 - 3 +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest3()
    {
        const string expression = "2 + 5 * ( 3 - 4 )";
        var notationParser = new InfixNotationParser();
        var postfixExpression = notationParser.Convert2Postfix(expression);
        Assert.That(postfixExpression, Is.EqualTo("2 5 3 4 - * +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest4()
    {
        const string expression = "1 / 2 * 3 / 4 - 5 * 6 + 7";
        var notationParser = new InfixNotationParser();
        var postfixExpression = notationParser.Convert2Postfix(expression);
        Assert.That(postfixExpression, Is.EqualTo("1 2 / 3 * 4 / 5 6 * - 7 +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest5()
    {
        const string expression = "2 + 2 + 2 + 2";
        var notationParser = new InfixNotationParser();
        var postfixExpression = notationParser.Convert2Postfix(expression);
        Assert.That(postfixExpression, Is.EqualTo("2 2 + 2 + 2 +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest6()
    {
        const string expression = "1.0 + 2 / .3 / ( 0 - 1 )";
        var notationParser = new InfixNotationParser();
        var postfixExpression = notationParser.Convert2Postfix(expression);
        Assert.That(postfixExpression, Is.EqualTo("1.0 2 .3 / 0 1 - / +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest7()
    {
        const string expression = "1 + 2 * ( 3 + 4 + 6 ) - 5";
        var notationParser = new InfixNotationParser();
        var postfixExpression = notationParser.Convert2Postfix(expression);
        Assert.That(postfixExpression, Is.EqualTo("1 2 3 4 + 6 + * + 5 -"));
    }
}