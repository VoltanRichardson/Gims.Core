namespace Gims.Core.Party;

public class Identifier
{
    public string Type { get; private set; }
    public string Value { get; private set; }

    private Identifier() { } // EF Core

    public Identifier(string type, string value)
    {
        Type = type;
        Value = value;
    }
}