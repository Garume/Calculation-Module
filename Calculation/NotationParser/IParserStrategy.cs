using Calculation.Node;

namespace Calculation.NotationParser;

public interface IParserStrategy
{
    INode Parse(string expression);
}