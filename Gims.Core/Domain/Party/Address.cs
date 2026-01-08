namespace Gims.Core.Domain.Party;

public record Address(
    string Line1,
    string? Line2,
    string City,
    string Country,
    string? PostalCode
);