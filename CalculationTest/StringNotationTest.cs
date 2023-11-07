using Calculation;

namespace CalculationTest;

public class StringNotationTest
{
    [Test]
    public void ConvertToReversePolishNotationTest1()
    {
        const string stringNumber = "1 + 2";
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        var reversePolishNotationNumber = infixNotationNumber.ConvertToReversePolishNotation();
        Assert.That(reversePolishNotationNumber.StringNumber, Is.EqualTo("1 2 +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest2()
    {
        const string stringNumber = "1 - 2 + 3";
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        var reversePolishNotationNumber = infixNotationNumber.ConvertToReversePolishNotation();
        Assert.That(reversePolishNotationNumber.StringNumber, Is.EqualTo("1 2 - 3 +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest3()
    {
        const string stringNumber = "2 + 5 * ( 3 - 4 )";
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        var reversePolishNotationNumber = infixNotationNumber.ConvertToReversePolishNotation();
        Assert.That(reversePolishNotationNumber.StringNumber, Is.EqualTo("2 5 3 4 - * +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest4()
    {
        const string stringNumber = "1 / 2 * 3 / 4 - 5 * 6 + 7";
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        var reversePolishNotationNumber = infixNotationNumber.ConvertToReversePolishNotation();
        Assert.That(reversePolishNotationNumber.StringNumber, Is.EqualTo("1 2 / 3 * 4 / 5 6 * - 7 +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest5()
    {
        const string stringNumber = "2 + 2 + 2 + 2";
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        var reversePolishNotationNumber = infixNotationNumber.ConvertToReversePolishNotation();
        Assert.That(reversePolishNotationNumber.StringNumber, Is.EqualTo("2 2 + 2 + 2 +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest6()
    {
        const string stringNumber = "1.0 + 2 / .3 / ( 0 - 1 )";
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        var reversePolishNotationNumber = infixNotationNumber.ConvertToReversePolishNotation();
        Assert.That(reversePolishNotationNumber.StringNumber, Is.EqualTo("1.0 2 .3 / 0 1 - / +"));
    }

    [Test]
    public void ConvertToReversePolishNotationTest7()
    {
        const string stringNumber = "1 + 2 * ( 3 + 4 + 6 ) - 5";
        var infixNotationNumber = StringNotation.CreateInfixNotation(stringNumber);
        var reversePolishNotationNumber = infixNotationNumber.ConvertToReversePolishNotation();
        Assert.That(reversePolishNotationNumber.StringNumber, Is.EqualTo("1 2 3 4 + 6 + * + 5 -"));
    }
}