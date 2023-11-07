namespace Calculation;

public interface INotation
{
    public NotationType Notation { get; }
}

public enum NotationType
{
    ReversePolish,
    Polish,
    Infix
}