using System.Reflection;

namespace Calculation.Operator;

public static class OperatorFactory
{
    private static readonly Dictionary<string, Type> OperatorCache = new();

    private static void CacheOperatorInstance()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var operatorTypes = assembly.GetTypes()
            .Where(t => typeof(IOperator).IsAssignableFrom(t) && !t.IsInterface);

        foreach (var type in operatorTypes)
        {
            var valueProperty = type.GetProperty("OperatorValue",
                BindingFlags.Static | BindingFlags.NonPublic);

            if (valueProperty == null) continue;
            var value = (string)valueProperty.GetValue(null)!;

            OperatorCache[value] = type;
        }
    }

    public static IOperator Create(string symbol)
    {
        if (OperatorCache.Count == 0)
            CacheOperatorInstance();

        if (OperatorCache.TryGetValue(symbol, out var operatorType))
            return (IOperator)Activator.CreateInstance(operatorType)!;


        throw new ArgumentException($"Unknown operator: {symbol}", nameof(symbol));
    }
}