using Calculation.Node;

namespace Calculation.NotationParser;

public sealed class Parser
{
    private readonly IParserStrategy _strategy;

    public Parser(IParserStrategy strategy)
    {
        _strategy = strategy;
    }

    public INode Parse(string expression)
    {
        return _strategy.Parse(expression);
    }
}