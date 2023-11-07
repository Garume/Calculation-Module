using Calculation;

namespace CalculationTest;

public class ParsePolishTest
{
    [Test]
    public void ParsePolishNotationTest1()
    {
        const string polishExpression = "+ 1 2";
        var stringNumber = StringNotation.CreatePolishNotation(polishExpression);
        var nodeParser = new NodeParser(stringNumber);
        var node = nodeParser.Parse();
        Assert.Multiple(() =>
        {
            Assert.That(node.Value, Is.EqualTo("+"));
            Assert.That(node.Left.Value, Is.EqualTo("1"));
            Assert.That(node.Right.Value, Is.EqualTo("2"));
        });
    }

    [Test]
    public void ParsePolishNotationTest2()
    {
        const string polishExpression = "+ * 1 2 / 3 4";
        var stringNumber = StringNotation.CreatePolishNotation(polishExpression);
        var nodeParser = new NodeParser(stringNumber);
        var node = nodeParser.Parse();
        Assert.Multiple(() =>
        {
            Assert.That(node.Value, Is.EqualTo("+"));
            Assert.That(node.Left.Value, Is.EqualTo("*"));
            Assert.That(node.Right.Value, Is.EqualTo("/"));
            Assert.That(node.Left.Left.Value, Is.EqualTo("1"));
            Assert.That(node.Left.Right.Value, Is.EqualTo("2"));
            Assert.That(node.Right.Left.Value, Is.EqualTo("3"));
            Assert.That(node.Right.Right.Value, Is.EqualTo("4"));
        });
    }
}