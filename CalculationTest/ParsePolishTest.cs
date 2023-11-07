using Calculation.Node;
using Calculation.NotationParser;

namespace CalculationTest;

public class ParsePolishTest
{
    [Test]
    public void ParsePolishNotationTest1()
    {
        const string polishExpression = "+ 1 2";
        var parser = new Parser(new PrefixNotationParser());
        var node = parser.Parse(polishExpression) as OperatorNode;
        Assert.Multiple(() =>
        {
            Assert.That(node?.Value, Is.EqualTo("+"));
            Assert.That(node?.Left.Value, Is.EqualTo("1"));
            Assert.That(node?.Right.Value, Is.EqualTo("2"));
        });
    }

    [Test]
    public void ParsePolishNotationTest2()
    {
        const string polishExpression = "+ * 1 2 / 3 4";
        var parser = new Parser(new PrefixNotationParser());
        var node = parser.Parse(polishExpression) as OperatorNode;
        Assert.Multiple(() =>
        {
            Assert.That(node?.Value, Is.EqualTo("+"));
            Assert.That(node?.Left.Value, Is.EqualTo("*"));
            Assert.That(node?.Right.Value, Is.EqualTo("/"));
            Assert.That(node?.Left.Left.Value, Is.EqualTo("1"));
            Assert.That(node?.Left.Right.Value, Is.EqualTo("2"));
            Assert.That(node?.Right.Left.Value, Is.EqualTo("3"));
            Assert.That(node?.Right.Right.Value, Is.EqualTo("4"));
        });
    }
}