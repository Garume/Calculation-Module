namespace Calculation;

public static class CalculateUtility
{
    private static readonly List<List<(string op, bool leftAssoc)>> PriorityOperators = new()
    {
        new List<(string op, bool leftAssoc)> { ("~", false) },
        new List<(string op, bool leftAssoc)> { ("**", false) },
        new List<(string op, bool leftAssoc)> { ("*", true), ("/", true), ("%", true) },
        new List<(string op, bool leftAssoc)> { ("+", true), ("-", true) }
    };

    public static bool IsOperator(string? value)
    {
        return value is "+" or "-" or "*" or "/";
    }

    public static bool IsPriorityOperator(string t)
    {
        return PriorityOperatorsDictionary().ContainsKey(t);
    }

    public static Dictionary<string, (int priority, bool leftAssoc)> PriorityOperatorsDictionary()
    {
        return PriorityOperators
            .Select((o, i) => (o, i))
            .SelectMany(e => e.o.Select(o => (o.op, e.i, o.leftAssoc)))
            .ToDictionary(i => i.op, i => (priority: i.i, i.leftAssoc));
    }
}