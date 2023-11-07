using Calculation.Node;
using Calculation.NotationParser;

namespace CalculationTest;

public sealed class ParseReversePolishTest
{
    [Test]
    public void ParseReversePolishTest1()
    {
        const string expression = "1 2 +";
        var parser = new Parser(new PostfixNotationParser());
        var node = parser.Parse(expression) as OperatorNode;
        Assert.Multiple(() =>
        {
            Assert.That(node?.Value, Is.EqualTo("+"));
            Assert.That(node?.Left.Value, Is.EqualTo("1"));
            Assert.That(node?.Right.Value, Is.EqualTo("2"));
        });
    }

    [Test]
    public void ParseReversePolishTest2()
    {
        const string expression = "1 2 * 3 4 / +";
        var parser = new Parser(new PostfixNotationParser());
        var node = parser.Parse(expression) as OperatorNode;
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

    [Test]
    public void ParseReversePolishTest3()
    {
        const string expression = "3 4 2 * 1 5 - / +";
        var parser = new Parser(new PostfixNotationParser());
        var node = parser.Parse(expression) as OperatorNode;
        Assert.Multiple(() =>
        {
            Assert.That(node?.Value, Is.EqualTo("+"));
            Assert.That(node?.Left.Value, Is.EqualTo("3"));
            Assert.That(node?.Right.Value, Is.EqualTo("/"));
            Assert.That(node?.Right.Left.Value, Is.EqualTo("*"));
            Assert.That(node?.Right.Right.Value, Is.EqualTo("-"));
            Assert.That(node?.Right.Left.Left.Value, Is.EqualTo("4"));
            Assert.That(node?.Right.Left.Right.Value, Is.EqualTo("2"));
            Assert.That(node?.Right.Right.Left.Value, Is.EqualTo("1"));
            Assert.That(node?.Right.Right.Right.Value, Is.EqualTo("5"));
        });
    }
}