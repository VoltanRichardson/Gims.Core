namespace Gims.Core.Party;

public record Address(
    string Line1,
    string? Line2,
    string City,
    string Country,
    string? PostalCode
);